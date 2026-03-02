using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoEleventa.Data
{
    public enum TipoCorte
    {
        Cajero = 1,
        Dia = 2
    }

    public sealed class ResumenCorte
    {
        public TipoCorte Tipo { get; set; }
        public int? IdCajero { get; set; }
        public string NombreCajero { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public int? IdTurno { get; set; }
        public bool TurnoCerrado { get; set; }

        public decimal VentasTotalesNetas { get; set; }
        public decimal DevolucionesTotal { get; set; }
        public decimal GananciaTotal { get; set; }

        public decimal VentasEfectivo { get; set; }
        public decimal VentasTarjetaCredito { get; set; }
        public decimal VentasCredito { get; set; }
        public decimal VentasVales { get; set; }
        public decimal VentasTransferencia { get; set; }
        public decimal VentasCheque { get; set; }

        public decimal FondoInicial { get; set; }
        public decimal AbonosCreditoEfectivo { get; set; }
        public decimal EntradasEfectivo { get; set; }
        public decimal SalidasEfectivo { get; set; }
        public decimal DevolucionesEfectivo { get; set; }
        public decimal DineroEnCajaFinal { get; set; }

        public DataTable VentasPorDepartamento { get; set; }
        public DataTable ClientesMasVentas { get; set; }
        public DataTable ClientesMasGanancia { get; set; }

        public Dictionary<string, decimal> VentasPorMetodo { get; set; }
    }

    public class ServicioCorte
    {
        private static readonly ConcurrentDictionary<string, HashSet<string>> _columnsCache =
            new ConcurrentDictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

        private static SqlParameter[] ClonarParametros(IEnumerable<SqlParameter> parameters)
        {
            if (parameters == null) return new SqlParameter[0];
            var list = new List<SqlParameter>();
            foreach (var p in parameters)
            {
                if (p == null) continue;
                list.Add(new SqlParameter(p.ParameterName, p.Value ?? DBNull.Value));
            }
            return list.ToArray();
        }

        private static HashSet<string> ObtenerColumnas(string tabla)
        {
            if (string.IsNullOrWhiteSpace(tabla))
                return new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            return _columnsCache.GetOrAdd(tabla, _ =>
            {
                const string q = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @t";
                var dt = DBConnection.ExecuteQuery(q, new SqlParameter("@t", tabla));
                var cols = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cols.Add(row["COLUMN_NAME"]?.ToString() ?? string.Empty);
                    }
                }
                return cols;
            });
        }

        private static bool TablaExiste(string tabla)
        {
            const string q = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @t";
            var obj = DBConnection.ExecuteScalar(q, new SqlParameter("@t", tabla));
            return obj != null && obj != DBNull.Value && Convert.ToInt32(obj) > 0;
        }

        public ResumenCorte ObtenerResumenCorte(TipoCorte tipoCorte, int? idCajero, DateTime fecha)
        {
            if (tipoCorte == TipoCorte.Cajero && (!idCajero.HasValue || idCajero.Value <= 0))
                throw new ArgumentException("Se requiere idCajero para el corte de cajero.");

            DateTime desde;
            DateTime hasta;
            int? idTurno = null;
            bool turnoCerrado = false;
            decimal fondoInicial = 0m;

            if (tipoCorte == TipoCorte.Dia)
            {
                desde = fecha.Date;
                hasta = fecha.Date.AddDays(1);
            }
            else
            {
                var turno = ObtenerTurnoActual(idCajero.Value);
                if (turno != null)
                {
                    idTurno = turno.IdTurno;
                    desde = turno.FechaInicio;
                    hasta = turno.FechaFin ?? DateTime.Now;
                    fondoInicial = turno.FondoInicial;
                    turnoCerrado = turno.Cerrado;
                }
                else
                {
                    // No hay tabla turnos (o no se pudo obtener turno activo):
                    // dejamos rango por defecto del día y deshabilitamos "Cerrar turno".
                    desde = fecha.Date;
                    hasta = DateTime.Now;
                    fondoInicial = 0m;
                    turnoCerrado = true;
                }
            }

            var resumen = new ResumenCorte
            {
                Tipo = tipoCorte,
                IdCajero = idCajero,
                NombreCajero = ObtenerNombreCajero(idCajero),
                Desde = desde,
                Hasta = hasta,
                IdTurno = idTurno,
                TurnoCerrado = turnoCerrado,
                FondoInicial = fondoInicial,
                VentasPorMetodo = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase)
            };

            CargarVentas(resumen);
            CargarGanancia(resumen);
            CargarMovimientosCaja(resumen);
            CargarAbonosCredito(resumen);
            CargarVentasPorDepartamento(resumen);
            CargarClientesTop(resumen);

            resumen.DineroEnCajaFinal = resumen.FondoInicial
                + resumen.VentasEfectivo
                + resumen.AbonosCreditoEfectivo
                + resumen.EntradasEfectivo
                - resumen.SalidasEfectivo
                - resumen.DevolucionesEfectivo;

            return resumen;
        }

        private sealed class InfoTurno
        {
            public int IdTurno { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime? FechaFin { get; set; }
            public decimal FondoInicial { get; set; }
            public bool Cerrado { get; set; }
        }

        private InfoTurno ObtenerTurnoActual(int idCajero)
        {
            if (!TablaExiste("turnos")) return null;

            var cols = ObtenerColumnas("turnos");
            if (!cols.Contains("id_turno") || !cols.Contains("id_cajero") || !cols.Contains("fecha_inicio"))
                return null;

            string colFin = cols.Contains("fecha_fin") ? "fecha_fin" : null;
            string colFondo = cols.Contains("fondo_inicial") ? "fondo_inicial" : null;
            string colCerrado = cols.Contains("cerrado") ? "cerrado" : null;

            var q = @"
SELECT TOP 1
    id_turno,
    fecha_inicio,
    " + (string.IsNullOrWhiteSpace(colFin) ? "NULL" : colFin) + @" AS fecha_fin,
    " + (string.IsNullOrWhiteSpace(colFondo) ? "0" : ("ISNULL(" + colFondo + ",0)")) + @" AS fondo_inicial,
    " + (string.IsNullOrWhiteSpace(colCerrado) ? "0" : colCerrado) + @" AS cerrado
FROM turnos
WHERE id_cajero = @id
" + (string.IsNullOrWhiteSpace(colCerrado) ? "" : " AND ISNULL(" + colCerrado + ",0) = 0") + @"
ORDER BY fecha_inicio DESC";

            var dt = DBConnection.ExecuteQuery(q, new SqlParameter("@id", idCajero));
            if (dt == null || dt.Rows.Count == 0) return null;

            var r = dt.Rows[0];
            return new InfoTurno
            {
                IdTurno = Convert.ToInt32(r["id_turno"]),
                FechaInicio = Convert.ToDateTime(r["fecha_inicio"]),
                FechaFin = r["fecha_fin"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["fecha_fin"]),
                FondoInicial = r["fondo_inicial"] == DBNull.Value ? 0m : Convert.ToDecimal(r["fondo_inicial"]),
                Cerrado = r["cerrado"] != DBNull.Value && Convert.ToInt32(r["cerrado"]) == 1
            };
        }

        private string ObtenerNombreCajero(int? idCajero)
        {
            if (!idCajero.HasValue || idCajero.Value <= 0) return "";

            if (!TablaExiste("usuarios")) return idCajero.Value.ToString();

            var cols = ObtenerColumnas("usuarios");
            if (!cols.Contains("id_usuario")) return idCajero.Value.ToString();

            string nombreCol = cols.Contains("nombre_completo") ? "nombre_completo"
                : (cols.Contains("usuario") ? "usuario"
                : (cols.Contains("nombre_usuario") ? "nombre_usuario"
                : (cols.Contains("username") ? "username"
                : (cols.Contains("nombre") ? "nombre" : null))));

            if (string.IsNullOrWhiteSpace(nombreCol)) return idCajero.Value.ToString();

            var obj = DBConnection.ExecuteScalar($"SELECT TOP 1 {nombreCol} FROM usuarios WHERE id_usuario = @id", new SqlParameter("@id", idCajero.Value));
            return obj == null || obj == DBNull.Value ? idCajero.Value.ToString() : obj.ToString();
        }

        private void CargarVentas(ResumenCorte r)
        {
            if (!TablaExiste("ventas"))
                return;

            var cols = ObtenerColumnas("ventas");
            if (!cols.Contains("total"))
                return;

            string colFecha = cols.Contains("fecha_venta") ? "fecha_venta" : (cols.Contains("fecha") ? "fecha" : null);
            if (string.IsNullOrWhiteSpace(colFecha))
                return;

            string colUsuario = cols.Contains("id_usuario") ? "id_usuario" : (cols.Contains("id_cajero") ? "id_cajero" : null);
            string colMetodo = cols.Contains("metodo_pago") ? "metodo_pago" : (cols.Contains("tipo_pago") ? "tipo_pago" : null);
            string colEstado = cols.Contains("estado") ? "estado" : null;
            string colDevol = cols.Contains("es_devolucion") ? "es_devolucion" : null;

            string filtroCajero = (r.Tipo == TipoCorte.Cajero && r.IdCajero.HasValue && !string.IsNullOrWhiteSpace(colUsuario))
                ? $" AND v.{colUsuario} = @idCajero"
                : string.Empty;

            string filtroEstado = !string.IsNullOrWhiteSpace(colEstado)
                ? " AND (v." + colEstado + " IS NULL OR v." + colEstado + " NOT LIKE 'Cancel%')"
                : string.Empty;

            string devolExpr;
            if (!string.IsNullOrWhiteSpace(colDevol))
                devolExpr = "CASE WHEN ISNULL(v." + colDevol + ",0)=1 THEN 1 ELSE 0 END";
            else
                devolExpr = "CASE WHEN v.total < 0 THEN 1 ELSE 0 END";

            string metodoExpr = string.IsNullOrWhiteSpace(colMetodo) ? "''" : ("UPPER(LTRIM(RTRIM(ISNULL(v." + colMetodo + ",''))))");

            string q = @"
SELECT
    ISNULL(SUM(CASE WHEN " + devolExpr + @" = 0 THEN v.total ELSE 0 END),0) AS ventas,
    ISNULL(SUM(CASE WHEN " + devolExpr + @" = 1 THEN ABS(v.total) ELSE 0 END),0) AS devoluciones,
    " + metodoExpr + @" AS metodo,
    ISNULL(SUM(CASE WHEN " + devolExpr + @" = 0 THEN v.total ELSE 0 END),0) AS total_metodo
FROM ventas v
WHERE v." + colFecha + " >= @desde AND v." + colFecha + " < @hasta"
+ filtroCajero + filtroEstado + @"
GROUP BY " + metodoExpr;

";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@desde", r.Desde),
                new SqlParameter("@hasta", r.Hasta)
            };
            if (!string.IsNullOrWhiteSpace(filtroCajero))
                parameters.Add(new SqlParameter("@idCajero", r.IdCajero.Value));

            var dt = DBConnection.ExecuteQuery(q, parameters.ToArray());
            if (dt == null) return;

            decimal ventasNoDevol = 0m;
            decimal devol = 0m;

            foreach (DataRow row in dt.Rows)
            {
                var vNoDev = row["ventas"] == DBNull.Value ? 0m : Convert.ToDecimal(row["ventas"]);
                var vDev = row["devoluciones"] == DBNull.Value ? 0m : Convert.ToDecimal(row["devoluciones"]);

                ventasNoDevol += vNoDev;
                devol += vDev;

                var metodo = row["metodo"]?.ToString() ?? string.Empty;
                var totalMetodo = row["total_metodo"] == DBNull.Value ? 0m : Convert.ToDecimal(row["total_metodo"]);
                if (!string.IsNullOrWhiteSpace(metodo))
                {
                    r.VentasPorMetodo[metodo] = totalMetodo;
                }
            }

            r.DevolucionesTotal = devol;
            r.VentasTotalesNetas = ventasNoDevol - devol;

            r.VentasEfectivo = ObtenerMetodo(r, "EFECTIVO");
            r.VentasTarjetaCredito = ObtenerMetodo(r, "TARJETA") + ObtenerMetodo(r, "TARJETA CREDITO") + ObtenerMetodo(r, "TARJETA_CRÉDITO") + ObtenerMetodo(r, "TARJETA CRÉDITO") + ObtenerMetodo(r, "TARJETA_CREDITO");
            r.VentasCredito = ObtenerMetodo(r, "CRÉDITO") + ObtenerMetodo(r, "CREDITO");
            r.VentasTransferencia = ObtenerMetodo(r, "TRANSFERENCIA");
            r.VentasCheque = ObtenerMetodo(r, "CHEQUE");
            r.VentasVales = ObtenerMetodo(r, "VALES") + ObtenerMetodo(r, "VALE") + ObtenerMetodo(r, "VALES DESPENSA") + ObtenerMetodo(r, "VALES_DESPENSA");

            string colMetodo2 = cols.Contains("metodo_pago") ? "metodo_pago" : (cols.Contains("tipo_pago") ? "tipo_pago" : null);
            if (!string.IsNullOrWhiteSpace(colMetodo2))
            {
                string qDevEf = @"SELECT ISNULL(SUM(ABS(v.total)),0) FROM ventas v WHERE v." + colFecha + " >= @desde AND v." + colFecha + " < @hasta" + filtroCajero + filtroEstado + " AND " + devolExpr + " = 1 AND UPPER(LTRIM(RTRIM(ISNULL(v." + colMetodo2 + ",'')))) IN ('EFECTIVO')";
                var objDevEf = DBConnection.ExecuteScalar(qDevEf, ClonarParametros(parameters));
                r.DevolucionesEfectivo = objDevEf == null || objDevEf == DBNull.Value ? 0m : Convert.ToDecimal(objDevEf);
            }
        }

        private static decimal ObtenerMetodo(ResumenCorte r, string key)
        {
            if (r.VentasPorMetodo == null) return 0m;
            return r.VentasPorMetodo.TryGetValue(key, out var v) ? v : 0m;
        }

        private void CargarGanancia(ResumenCorte r)
        {
            if (!TablaExiste("detalle_ventas") || !TablaExiste("ventas"))
                return;

            var colsDv = ObtenerColumnas("detalle_ventas");
            var colsV = ObtenerColumnas("ventas");

            string colFecha = colsV.Contains("fecha_venta") ? "fecha_venta" : (colsV.Contains("fecha") ? "fecha" : null);
            if (string.IsNullOrWhiteSpace(colFecha))
                return;

            string colUsuario = colsV.Contains("id_usuario") ? "id_usuario" : (colsV.Contains("id_cajero") ? "id_cajero" : null);
            string filtroCajero = (r.Tipo == TipoCorte.Cajero && r.IdCajero.HasValue && !string.IsNullOrWhiteSpace(colUsuario))
                ? $" AND v.{colUsuario} = @idCajero"
                : string.Empty;

            string colEstado = colsV.Contains("estado") ? "estado" : null;
            string filtroEstado = !string.IsNullOrWhiteSpace(colEstado)
                ? " AND (v." + colEstado + " IS NULL OR v." + colEstado + " NOT LIKE 'Cancel%')"
                : string.Empty;

            string colDevol = colsV.Contains("es_devolucion") ? "es_devolucion" : null;
            string devolExpr = !string.IsNullOrWhiteSpace(colDevol)
                ? "CASE WHEN ISNULL(v." + colDevol + ",0)=1 THEN 1 ELSE 0 END"
                : "CASE WHEN v.total < 0 THEN 1 ELSE 0 END";

            string gananciaExpr;
            if (colsDv.Contains("ganancia"))
            {
                gananciaExpr = "ISNULL(dv.ganancia,0)";
            }
            else
            {
                if (!TablaExiste("productos"))
                    return;

                var colsP = ObtenerColumnas("productos");
                if (!colsDv.Contains("cantidad") || !colsDv.Contains("precio_unitario") || !colsP.Contains("precio_compra"))
                    return;

                gananciaExpr = "(ISNULL(dv.precio_unitario,0) - ISNULL(p.precio_compra,0)) * ISNULL(dv.cantidad,0)";
            }

            string joinProductos = TablaExiste("productos") && colsDv.Contains("id_producto")
                ? "LEFT JOIN productos p ON p.id_producto = dv.id_producto"
                : string.Empty;

            string q = @"SELECT ISNULL(SUM(CASE WHEN " + devolExpr + " = 0 THEN " + gananciaExpr + " ELSE -(" + gananciaExpr + ") END),0)\n" +
                       "FROM detalle_ventas dv\n" +
                       "INNER JOIN ventas v ON v.id_venta = dv.id_venta\n" +
                       joinProductos + "\n" +
                       "WHERE v." + colFecha + " >= @desde AND v." + colFecha + " < @hasta" + filtroCajero + filtroEstado;

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@desde", r.Desde),
                new SqlParameter("@hasta", r.Hasta)
            };
            if (!string.IsNullOrWhiteSpace(filtroCajero))
                parameters.Add(new SqlParameter("@idCajero", r.IdCajero.Value));

            var obj = DBConnection.ExecuteScalar(q, parameters.ToArray());
            r.GananciaTotal = obj == null || obj == DBNull.Value ? 0m : Convert.ToDecimal(obj);
        }

        private void CargarMovimientosCaja(ResumenCorte r)
        {
            string tabla;
            bool esMovEfectivo;

            if (TablaExiste("movimientos_caja"))
            {
                tabla = "movimientos_caja";
                esMovEfectivo = false;
            }
            else if (TablaExiste("movimientos_efectivo"))
            {
                tabla = "movimientos_efectivo";
                esMovEfectivo = true;
            }
            else
            {
                return;
            }

            var cols = ObtenerColumnas(tabla);

            string colMonto = cols.Contains("monto") ? "monto" : (cols.Contains("cantidad") ? "cantidad" : null);
            if (string.IsNullOrWhiteSpace(colMonto))
                return;

            string colFecha = cols.Contains("fecha") ? "fecha" : (cols.Contains("fecha_movimiento") ? "fecha_movimiento" : null);
            if (string.IsNullOrWhiteSpace(colFecha))
                return;

            string colTipo = esMovEfectivo
                ? (cols.Contains("tipo") ? "tipo" : null)
                : (cols.Contains("tipo_movimiento") ? "tipo_movimiento" : (cols.Contains("tipomovimiento") ? "tipomovimiento" : null));

            if (string.IsNullOrWhiteSpace(colTipo))
                return;

            string colUsuario = cols.Contains("id_cajero") ? "id_cajero" : (cols.Contains("id_usuario") ? "id_usuario" : null);
            string filtroCajero = (r.Tipo == TipoCorte.Cajero && r.IdCajero.HasValue && !string.IsNullOrWhiteSpace(colUsuario))
                ? $" AND {colUsuario} = @idCajero"
                : string.Empty;

            string q = $@"
SELECT
    UPPER(LTRIM(RTRIM(ISNULL({colTipo},'')))) AS tipo,
    ISNULL(SUM(ISNULL({colMonto},0)),0) AS total
FROM {tabla}
WHERE {colFecha} >= @desde AND {colFecha} < @hasta{filtroCajero}
GROUP BY UPPER(LTRIM(RTRIM(ISNULL({colTipo},''))))";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@desde", r.Desde),
                new SqlParameter("@hasta", r.Hasta)
            };
            if (!string.IsNullOrWhiteSpace(filtroCajero))
                parameters.Add(new SqlParameter("@idCajero", r.IdCajero.Value));

            var dt = DBConnection.ExecuteQuery(q, parameters.ToArray());
            if (dt == null) return;

            decimal entradas = 0m;
            decimal salidas = 0m;

            foreach (DataRow row in dt.Rows)
            {
                var tipo = row["tipo"]?.ToString() ?? string.Empty;
                var total = row["total"] == DBNull.Value ? 0m : Convert.ToDecimal(row["total"]);

                if (tipo.Contains("ENTR"))
                {
                    entradas += total;
                }
                else if (tipo.Contains("SAL"))
                {
                    salidas += Math.Abs(total);
                }
            }

            r.EntradasEfectivo = entradas;
            r.SalidasEfectivo = salidas;
        }

        private void CargarAbonosCredito(ResumenCorte r)
        {
            if (!TablaExiste("abonos_credito") && !TablaExiste("abonoscredito") && !TablaExiste("abonos_creditos"))
            {
                r.AbonosCreditoEfectivo = 0m;
                return;
            }

            string tabla = TablaExiste("abonos_credito") ? "abonos_credito" : (TablaExiste("abonos_creditos") ? "abonos_creditos" : "abonoscredito");
            var cols = ObtenerColumnas(tabla);

            string colFecha = cols.Contains("fecha") ? "fecha" : null;
            string colMonto = cols.Contains("monto") ? "monto" : (cols.Contains("cantidad") ? "cantidad" : null);
            string colUsuario = cols.Contains("id_cajero") ? "id_cajero" : (cols.Contains("id_usuario") ? "id_usuario" : null);

            if (string.IsNullOrWhiteSpace(colFecha) || string.IsNullOrWhiteSpace(colMonto))
            {
                r.AbonosCreditoEfectivo = 0m;
                return;
            }

            string filtroCajero = (r.Tipo == TipoCorte.Cajero && r.IdCajero.HasValue && !string.IsNullOrWhiteSpace(colUsuario))
                ? $" AND {colUsuario} = @idCajero"
                : string.Empty;

            string q = $"SELECT ISNULL(SUM(ISNULL({colMonto},0)),0) FROM {tabla} WHERE {colFecha} >= @desde AND {colFecha} < @hasta{filtroCajero}";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@desde", r.Desde),
                new SqlParameter("@hasta", r.Hasta)
            };
            if (!string.IsNullOrWhiteSpace(filtroCajero))
                parameters.Add(new SqlParameter("@idCajero", r.IdCajero.Value));

            var obj = DBConnection.ExecuteScalar(q, parameters.ToArray());
            r.AbonosCreditoEfectivo = obj == null || obj == DBNull.Value ? 0m : Convert.ToDecimal(obj);
        }

        private void CargarVentasPorDepartamento(ResumenCorte r)
        {
            if (!TablaExiste("detalle_ventas") || !TablaExiste("ventas") || !TablaExiste("productos"))
            {
                r.VentasPorDepartamento = new DataTable();
                return;
            }

            var colsV = ObtenerColumnas("ventas");
            var colsDv = ObtenerColumnas("detalle_ventas");
            var colsP = ObtenerColumnas("productos");

            string colFecha = colsV.Contains("fecha_venta") ? "fecha_venta" : (colsV.Contains("fecha") ? "fecha" : null);
            if (string.IsNullOrWhiteSpace(colFecha))
            {
                r.VentasPorDepartamento = new DataTable();
                return;
            }

            if (!colsDv.Contains("cantidad") || !colsDv.Contains("precio_unitario") || !colsDv.Contains("id_producto"))
            {
                r.VentasPorDepartamento = new DataTable();
                return;
            }

            string colUsuario = colsV.Contains("id_usuario") ? "id_usuario" : (colsV.Contains("id_cajero") ? "id_cajero" : null);
            string filtroCajero = (r.Tipo == TipoCorte.Cajero && r.IdCajero.HasValue && !string.IsNullOrWhiteSpace(colUsuario))
                ? $" AND v.{colUsuario} = @idCajero"
                : string.Empty;

            string colEstado = colsV.Contains("estado") ? "estado" : null;
            string filtroEstado = !string.IsNullOrWhiteSpace(colEstado)
                ? " AND (v." + colEstado + " IS NULL OR v." + colEstado + " NOT LIKE 'Cancel%')"
                : string.Empty;

            string colDevol = colsV.Contains("es_devolucion") ? "es_devolucion" : null;
            string devolExpr = !string.IsNullOrWhiteSpace(colDevol)
                ? "CASE WHEN ISNULL(v." + colDevol + ",0)=1 THEN 1 ELSE 0 END"
                : "CASE WHEN v.total < 0 THEN 1 ELSE 0 END";

            string deptExpr;
            string joinDept = "";

            if (TablaExiste("departamentos"))
            {
                joinDept = "LEFT JOIN departamentos d ON TRY_CONVERT(INT, p.departamento) = d.id_departamento";
                deptExpr = "COALESCE(d.nombre, CONVERT(NVARCHAR(100), p.departamento), 'SIN DEPTO')";
            }
            else
            {
                deptExpr = "CONVERT(NVARCHAR(100), ISNULL(p.departamento,''))";
            }

            string gananciaExpr;
            if (colsDv.Contains("ganancia"))
                gananciaExpr = "ISNULL(dv.ganancia,0)";
            else if (colsP.Contains("precio_compra"))
                gananciaExpr = "(ISNULL(dv.precio_unitario,0) - ISNULL(p.precio_compra,0)) * ISNULL(dv.cantidad,0)";
            else
                gananciaExpr = "0";

            string q = @"
SELECT
    " + deptExpr + @" AS departamento,
    ISNULL(SUM(CASE WHEN " + devolExpr + @" = 0 THEN ISNULL(dv.cantidad,0) * ISNULL(dv.precio_unitario,0) ELSE -(ISNULL(dv.cantidad,0) * ISNULL(dv.precio_unitario,0)) END),0) AS total_vendido,
    ISNULL(SUM(CASE WHEN " + devolExpr + @" = 0 THEN " + gananciaExpr + @" ELSE -(" + gananciaExpr + @") END),0) AS total_ganancia
FROM detalle_ventas dv
INNER JOIN ventas v ON v.id_venta = dv.id_venta
INNER JOIN productos p ON p.id_producto = dv.id_producto
" + joinDept + @"
WHERE v." + colFecha + " >= @desde AND v." + colFecha + " < @hasta" + filtroCajero + filtroEstado + @"
GROUP BY " + deptExpr + @"
ORDER BY total_vendido DESC";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@desde", r.Desde),
                new SqlParameter("@hasta", r.Hasta)
            };
            if (!string.IsNullOrWhiteSpace(filtroCajero))
                parameters.Add(new SqlParameter("@idCajero", r.IdCajero.Value));

            r.VentasPorDepartamento = DBConnection.ExecuteQuery(q, parameters.ToArray()) ?? new DataTable();
        }

        private void CargarClientesTop(ResumenCorte r)
        {
            r.ClientesMasVentas = ObtenerTopClientesPorVentas(r);
            r.ClientesMasGanancia = ObtenerTopClientesPorGanancia(r);
        }

        private DataTable ObtenerTopClientesPorVentas(ResumenCorte r)
        {
            if (!TablaExiste("ventas"))
                return new DataTable();

            var colsV = ObtenerColumnas("ventas");
            if (!colsV.Contains("id_cliente") || !colsV.Contains("total"))
                return new DataTable();

            string colFecha = colsV.Contains("fecha_venta") ? "fecha_venta" : (colsV.Contains("fecha") ? "fecha" : null);
            if (string.IsNullOrWhiteSpace(colFecha))
                return new DataTable();

            string colUsuario = colsV.Contains("id_usuario") ? "id_usuario" : (colsV.Contains("id_cajero") ? "id_cajero" : null);
            string filtroCajero = (r.Tipo == TipoCorte.Cajero && r.IdCajero.HasValue && !string.IsNullOrWhiteSpace(colUsuario))
                ? $" AND v.{colUsuario} = @idCajero"
                : string.Empty;

            string colEstado = colsV.Contains("estado") ? "estado" : null;
            string filtroEstado = !string.IsNullOrWhiteSpace(colEstado)
                ? " AND (v." + colEstado + " IS NULL OR v." + colEstado + " NOT LIKE 'Cancel%')"
                : string.Empty;

            string colDevol = colsV.Contains("es_devolucion") ? "es_devolucion" : null;
            string devolExpr = !string.IsNullOrWhiteSpace(colDevol)
                ? "CASE WHEN ISNULL(v." + colDevol + ",0)=1 THEN 1 ELSE 0 END"
                : "CASE WHEN v.total < 0 THEN 1 ELSE 0 END";

            string nombreClienteExpr = "CONVERT(VARCHAR(20), v.id_cliente)";
            string joinCliente = "";
            if (TablaExiste("clientes"))
            {
                var colsC = ObtenerColumnas("clientes");
                if (colsC.Contains("id_cliente"))
                {
                    joinCliente = "LEFT JOIN clientes c ON c.id_cliente = v.id_cliente";
                    if (colsC.Contains("nombre") && colsC.Contains("apellidos"))
                        nombreClienteExpr = "LTRIM(RTRIM(ISNULL(c.nombre,''))) + CASE WHEN ISNULL(c.apellidos,'')='' THEN '' ELSE ' ' + LTRIM(RTRIM(c.apellidos)) END";
                    else if (colsC.Contains("nombre"))
                        nombreClienteExpr = "ISNULL(c.nombre,'')";
                }
            }

            string q = @"
SELECT TOP 5
    v.id_cliente,
    " + nombreClienteExpr + @" AS cliente,
    ISNULL(SUM(CASE WHEN " + devolExpr + @" = 0 THEN v.total ELSE 0 END),0) AS total_ventas
FROM ventas v
" + joinCliente + @"
WHERE v." + colFecha + " >= @desde AND v." + colFecha + " < @hasta" + filtroCajero + filtroEstado + @"
GROUP BY v.id_cliente, " + nombreClienteExpr + @"
ORDER BY total_ventas DESC";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@desde", r.Desde),
                new SqlParameter("@hasta", r.Hasta)
            };
            if (!string.IsNullOrWhiteSpace(filtroCajero))
                parameters.Add(new SqlParameter("@idCajero", r.IdCajero.Value));

            return DBConnection.ExecuteQuery(q, parameters.ToArray()) ?? new DataTable();
        }

        private DataTable ObtenerTopClientesPorGanancia(ResumenCorte r)
        {
            if (!TablaExiste("detalle_ventas") || !TablaExiste("ventas"))
                return new DataTable();

            var colsV = ObtenerColumnas("ventas");
            var colsDv = ObtenerColumnas("detalle_ventas");

            if (!colsV.Contains("id_cliente") || !colsDv.Contains("id_venta"))
                return new DataTable();

            string colFecha = colsV.Contains("fecha_venta") ? "fecha_venta" : (colsV.Contains("fecha") ? "fecha" : null);
            if (string.IsNullOrWhiteSpace(colFecha))
                return new DataTable();

            string colUsuario = colsV.Contains("id_usuario") ? "id_usuario" : (colsV.Contains("id_cajero") ? "id_cajero" : null);
            string filtroCajero = (r.Tipo == TipoCorte.Cajero && r.IdCajero.HasValue && !string.IsNullOrWhiteSpace(colUsuario))
                ? $" AND v.{colUsuario} = @idCajero"
                : string.Empty;

            string colEstado = colsV.Contains("estado") ? "estado" : null;
            string filtroEstado = !string.IsNullOrWhiteSpace(colEstado)
                ? " AND (v." + colEstado + " IS NULL OR v." + colEstado + " NOT LIKE 'Cancel%')"
                : string.Empty;

            string colDevol = colsV.Contains("es_devolucion") ? "es_devolucion" : null;
            string devolExpr = !string.IsNullOrWhiteSpace(colDevol)
                ? "CASE WHEN ISNULL(v." + colDevol + ",0)=1 THEN 1 ELSE 0 END"
                : "CASE WHEN v.total < 0 THEN 1 ELSE 0 END";

            string gananciaExpr;
            string joinProductos = "";
            if (colsDv.Contains("ganancia"))
            {
                gananciaExpr = "ISNULL(dv.ganancia,0)";
            }
            else
            {
                if (!TablaExiste("productos"))
                    return new DataTable();

                var colsP = ObtenerColumnas("productos");
                if (!colsDv.Contains("id_producto") || !colsDv.Contains("cantidad") || !colsDv.Contains("precio_unitario") || !colsP.Contains("precio_compra"))
                    return new DataTable();

                joinProductos = "LEFT JOIN productos p ON p.id_producto = dv.id_producto";
                gananciaExpr = "(ISNULL(dv.precio_unitario,0) - ISNULL(p.precio_compra,0)) * ISNULL(dv.cantidad,0)";
            }

            string nombreClienteExpr = "CONVERT(VARCHAR(20), v.id_cliente)";
            string joinCliente = "";
            if (TablaExiste("clientes"))
            {
                var colsC = ObtenerColumnas("clientes");
                if (colsC.Contains("id_cliente"))
                {
                    joinCliente = "LEFT JOIN clientes c ON c.id_cliente = v.id_cliente";
                    if (colsC.Contains("nombre") && colsC.Contains("apellidos"))
                        nombreClienteExpr = "LTRIM(RTRIM(ISNULL(c.nombre,''))) + CASE WHEN ISNULL(c.apellidos,'')='' THEN '' ELSE ' ' + LTRIM(RTRIM(c.apellidos)) END";
                    else if (colsC.Contains("nombre"))
                        nombreClienteExpr = "ISNULL(c.nombre,'')";
                }
            }

            string q = @"
SELECT TOP 5
    v.id_cliente,
    " + nombreClienteExpr + @" AS cliente,
    ISNULL(SUM(CASE WHEN " + devolExpr + @" = 0 THEN " + gananciaExpr + @" ELSE -(" + gananciaExpr + @") END),0) AS total_ganancia
FROM ventas v
INNER JOIN detalle_ventas dv ON dv.id_venta = v.id_venta
" + joinProductos + @"
" + joinCliente + @"
WHERE v." + colFecha + " >= @desde AND v." + colFecha + " < @hasta" + filtroCajero + filtroEstado + @"
GROUP BY v.id_cliente, " + nombreClienteExpr + @"
ORDER BY total_ganancia DESC";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@desde", r.Desde),
                new SqlParameter("@hasta", r.Hasta)
            };
            if (!string.IsNullOrWhiteSpace(filtroCajero))
                parameters.Add(new SqlParameter("@idCajero", r.IdCajero.Value));

            return DBConnection.ExecuteQuery(q, parameters.ToArray()) ?? new DataTable();
        }

        public bool CerrarTurnoActual(int idCajero)
        {
            // Si no hay infraestructura de turnos, no hacemos nada.
            if (!TablaExiste("turnos"))
                return false;

            var turno = ObtenerTurnoActual(idCajero);
            if (turno == null)
                return false;

            if (turno.Cerrado)
                return false;

            var cols = ObtenerColumnas("turnos");
            if (!cols.Contains("id_turno"))
                return false;

            var sets = new List<string>();
            var parameters = new List<SqlParameter>();

            if (cols.Contains("fecha_fin"))
            {
                sets.Add("fecha_fin = GETDATE()");
            }

            if (cols.Contains("cerrado"))
            {
                sets.Add("cerrado = 1");
            }

            if (sets.Count == 0)
                return false;

            var q = "UPDATE turnos SET " + string.Join(", ", sets) + " WHERE id_turno = @id";
            parameters.Add(new SqlParameter("@id", turno.IdTurno));

            return DBConnection.ExecuteNonQuery(q, parameters.ToArray()) > 0;
        }
    }
}
