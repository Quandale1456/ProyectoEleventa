using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoEleventa.Data
{
    public static class ReporteVentasDAL
    {
        private static readonly ConcurrentDictionary<string, HashSet<string>> _columnsCache =
            new ConcurrentDictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

        private static HashSet<string> ObtenerColumnas(string table)
        {
            return _columnsCache.GetOrAdd(table, t =>
            {
                var dt = DBConnection.ExecuteQuery(
                    "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @t",
                    new SqlParameter("@t", t));

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

        private static bool TablaExiste(string table)
        {
            var dt = DBConnection.ExecuteQuery(
                "SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @t",
                new SqlParameter("@t", table));
            return dt != null && dt.Rows.Count > 0;
        }

        public static DataTable ObtenerVentasPorDia(DateTime desde, DateTime hasta)
        {
            var colsVentas = ObtenerColumnas("ventas");
            if (!colsVentas.Contains("fecha_venta") || !colsVentas.Contains("total"))
            {
                return new DataTable();
            }

            var filtroEstado = colsVentas.Contains("estado")
                ? " AND (estado IS NULL OR estado NOT LIKE 'Cancel%')"
                : string.Empty;

            var query = @"
SELECT
    CAST(fecha_venta AS date) AS fecha,
    DATENAME(WEEKDAY, fecha_venta) AS dia_semana,
    SUM(total) AS total
FROM ventas
WHERE fecha_venta >= @desde AND fecha_venta <= @hasta" + filtroEstado + @"
GROUP BY CAST(fecha_venta AS date), DATENAME(WEEKDAY, fecha_venta)
ORDER BY CAST(fecha_venta AS date)";

            return DBConnection.ExecuteQuery(query,
                new SqlParameter("@desde", desde),
                new SqlParameter("@hasta", hasta));
        }

        public static DataRow ObtenerRangoFechasVentas()
        {
            var colsVentas = ObtenerColumnas("ventas");
            if (!colsVentas.Contains("fecha_venta"))
            {
                return null;
            }

            var filtroEstado = colsVentas.Contains("estado")
                ? " WHERE (estado IS NULL OR estado NOT LIKE 'Cancel%')"
                : string.Empty;

            var query = "SELECT MIN(fecha_venta) AS min_fecha, MAX(fecha_venta) AS max_fecha FROM ventas" + filtroEstado;
            var dt = DBConnection.ExecuteQuery(query);
            return (dt != null && dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }

        public static DataTable ObtenerVentasPorMes(DateTime desde, DateTime hasta)
        {
            var colsVentas = ObtenerColumnas("ventas");
            if (!colsVentas.Contains("fecha_venta") || !colsVentas.Contains("total"))
            {
                return new DataTable();
            }

            var filtroEstado = colsVentas.Contains("estado")
                ? " AND (estado IS NULL OR estado NOT LIKE 'Cancel%')"
                : string.Empty;

            var query = @"
SELECT
    YEAR(fecha_venta) AS anio,
    MONTH(fecha_venta) AS mes,
    DATENAME(MONTH, fecha_venta) AS mes_nombre,
    SUM(total) AS total
FROM ventas
WHERE fecha_venta >= @desde AND fecha_venta <= @hasta" + filtroEstado + @"
GROUP BY YEAR(fecha_venta), MONTH(fecha_venta), DATENAME(MONTH, fecha_venta)
ORDER BY YEAR(fecha_venta), MONTH(fecha_venta)";

            return DBConnection.ExecuteQuery(query,
                new SqlParameter("@desde", desde),
                new SqlParameter("@hasta", hasta));
        }

        public static DataTable ObtenerVentasPorFormaPago(DateTime desde, DateTime hasta)
        {
            var colsVentas = ObtenerColumnas("ventas");
            if (!colsVentas.Contains("metodo_pago") || !colsVentas.Contains("total") || !colsVentas.Contains("fecha_venta"))
            {
                return new DataTable();
            }

            var filtroEstado = colsVentas.Contains("estado")
                ? " AND (estado IS NULL OR estado NOT LIKE 'Cancel%')"
                : string.Empty;

            var query = @"
SELECT
    metodo_pago,
    SUM(total) AS total
FROM ventas
WHERE fecha_venta >= @desde AND fecha_venta <= @hasta" + filtroEstado + @"
GROUP BY metodo_pago
ORDER BY SUM(total) DESC";

            return DBConnection.ExecuteQuery(query,
                new SqlParameter("@desde", desde),
                new SqlParameter("@hasta", hasta));
        }

        public static DataTable ObtenerVentasPorDepartamento(DateTime desde, DateTime hasta)
        {
            if (!TablaExiste("detalle_ventas") || !TablaExiste("productos") || !TablaExiste("ventas"))
            {
                return new DataTable();
            }

            var colsVentas = ObtenerColumnas("ventas");
            var colsDv = ObtenerColumnas("detalle_ventas");
            var colsP = ObtenerColumnas("productos");

            if (!colsVentas.Contains("fecha_venta") || !colsDv.Contains("id_venta") || !colsDv.Contains("id_producto") || !colsDv.Contains("subtotal"))
            {
                return new DataTable();
            }

            var filtroEstado = colsVentas.Contains("estado")
                ? " AND (v.estado IS NULL OR v.estado NOT LIKE 'Cancel%')"
                : string.Empty;

            var joinDept = string.Empty;
            var deptExpr = colsP.Contains("departamento") ? "p.departamento" : "NULL";

            if (TablaExiste("departamentos"))
            {
                var colsD = ObtenerColumnas("departamentos");
                if (colsD.Contains("id_departamento") && colsD.Contains("nombre") && colsP.Contains("departamento"))
                {
                    joinDept = @"
LEFT JOIN departamentos d
    ON d.id_departamento = TRY_CONVERT(int, p.departamento)
    OR d.nombre = p.departamento";
                    deptExpr = "COALESCE(d.nombre, p.departamento, 'Sin departamento')";
                }
            }

            var query = $@"
SELECT
    {deptExpr} AS departamento,
    SUM(dv.subtotal) AS total
FROM detalle_ventas dv
JOIN ventas v ON v.id_venta = dv.id_venta
JOIN productos p ON p.id_producto = dv.id_producto
{joinDept}
WHERE v.fecha_venta >= @desde AND v.fecha_venta <= @hasta{filtroEstado}
GROUP BY {deptExpr}
ORDER BY SUM(dv.subtotal) DESC";

            return DBConnection.ExecuteQuery(query,
                new SqlParameter("@desde", desde),
                new SqlParameter("@hasta", hasta));
        }

        public static DataTable ObtenerGananciaPorDepartamento(DateTime desde, DateTime hasta)
        {
            if (!TablaExiste("detalle_ventas") || !TablaExiste("productos") || !TablaExiste("ventas"))
            {
                return new DataTable();
            }

            var colsVentas = ObtenerColumnas("ventas");
            var colsDv = ObtenerColumnas("detalle_ventas");
            var colsP = ObtenerColumnas("productos");

            if (!colsVentas.Contains("fecha_venta") || !colsDv.Contains("id_venta") || !colsDv.Contains("id_producto") || !colsDv.Contains("subtotal") || !colsDv.Contains("cantidad"))
            {
                return new DataTable();
            }

            var costoExpr = colsP.Contains("precio_compra") ? "ISNULL(p.precio_compra,0)" : "0";

            var filtroEstado = colsVentas.Contains("estado")
                ? " AND (v.estado IS NULL OR v.estado NOT LIKE 'Cancel%')"
                : string.Empty;

            var joinDept = string.Empty;
            var deptExpr = colsP.Contains("departamento") ? "p.departamento" : "NULL";

            if (TablaExiste("departamentos"))
            {
                var colsD = ObtenerColumnas("departamentos");
                if (colsD.Contains("id_departamento") && colsD.Contains("nombre") && colsP.Contains("departamento"))
                {
                    joinDept = @"
LEFT JOIN departamentos d
    ON d.id_departamento = TRY_CONVERT(int, p.departamento)
    OR d.nombre = p.departamento";
                    deptExpr = "COALESCE(d.nombre, p.departamento, 'Sin departamento')";
                }
            }

            var query = $@"
SELECT
    {deptExpr} AS departamento,
    SUM(dv.subtotal - (dv.cantidad * {costoExpr})) AS ganancia
FROM detalle_ventas dv
JOIN ventas v ON v.id_venta = dv.id_venta
JOIN productos p ON p.id_producto = dv.id_producto
{joinDept}
WHERE v.fecha_venta >= @desde AND v.fecha_venta <= @hasta{filtroEstado}
GROUP BY {deptExpr}
ORDER BY SUM(dv.subtotal - (dv.cantidad * {costoExpr})) DESC";

            return DBConnection.ExecuteQuery(query,
                new SqlParameter("@desde", desde),
                new SqlParameter("@hasta", hasta));
        }

        public static decimal ObtenerImpuestos(DateTime desde, DateTime hasta)
        {
            var colsVentas = ObtenerColumnas("ventas");
            if (!colsVentas.Contains("impuesto") || !colsVentas.Contains("fecha_venta"))
            {
                return 0m;
            }

            var filtroEstado = colsVentas.Contains("estado")
                ? " AND (estado IS NULL OR estado NOT LIKE 'Cancel%')"
                : string.Empty;

            var query = "SELECT ISNULL(SUM(impuesto),0) FROM ventas WHERE fecha_venta >= @desde AND fecha_venta <= @hasta" + filtroEstado;
            var obj = DBConnection.ExecuteScalar(query,
                new SqlParameter("@desde", desde),
                new SqlParameter("@hasta", hasta));
            return obj != null && obj != DBNull.Value ? Convert.ToDecimal(obj) : 0m;
        }

        public static DataTable ObtenerVentasPorCliente(DateTime desde, DateTime hasta)
        {
            if (!TablaExiste("ventas") || !TablaExiste("clientes"))
            {
                return new DataTable();
            }

            var colsVentas = ObtenerColumnas("ventas");
            var colsClientes = ObtenerColumnas("clientes");

            if (!colsVentas.Contains("id_cliente") || !colsVentas.Contains("id_venta") || !colsVentas.Contains("fecha_venta") || !colsVentas.Contains("total"))
            {
                return new DataTable();
            }

            var filtroEstado = colsVentas.Contains("estado")
                ? " AND (v.estado IS NULL OR v.estado NOT LIKE 'Cancel%')"
                : string.Empty;

            var nombreExpr = colsClientes.Contains("nombre")
                ? "LTRIM(RTRIM(ISNULL(c.nombre,'')))"
                : "''";
            if (colsClientes.Contains("apellidos"))
            {
                nombreExpr += " + CASE WHEN ISNULL(c.apellidos,'')='' THEN '' ELSE ' ' + LTRIM(RTRIM(c.apellidos)) END";
            }

            var tieneDetalle = TablaExiste("detalle_ventas") && TablaExiste("productos");
            var gananciaExpr = "0";
            var joinGanancia = string.Empty;

            if (tieneDetalle)
            {
                var colsDv = ObtenerColumnas("detalle_ventas");
                var colsP = ObtenerColumnas("productos");

                if (colsDv.Contains("id_venta") && colsDv.Contains("id_producto") && colsDv.Contains("subtotal") && colsDv.Contains("cantidad") && colsP.Contains("id_producto"))
                {
                    var costoExpr = colsP.Contains("precio_compra") ? "ISNULL(p.precio_compra,0)" : "0";
                    gananciaExpr = $"SUM(ISNULL(dv.subtotal,0) - (ISNULL(dv.cantidad,0) * {costoExpr}))";
                    joinGanancia = @"
LEFT JOIN detalle_ventas dv ON dv.id_venta = v.id_venta
LEFT JOIN productos p ON p.id_producto = dv.id_producto";
                }
            }

            var query = $@"
SELECT
    v.id_cliente,
    ({nombreExpr}) AS nombre_cliente,
    COUNT(DISTINCT v.id_venta) AS numero_ventas,
    SUM(v.total) AS acumulado_ventas,
    {gananciaExpr} AS acumulado_ganancia
FROM ventas v
JOIN clientes c ON c.id_cliente = v.id_cliente
{joinGanancia}
WHERE v.fecha_venta >= @desde AND v.fecha_venta <= @hasta{filtroEstado}
GROUP BY v.id_cliente, ({nombreExpr})
ORDER BY SUM(v.total) DESC";

            return DBConnection.ExecuteQuery(query,
                new SqlParameter("@desde", desde),
                new SqlParameter("@hasta", hasta));
        }
    }
}
