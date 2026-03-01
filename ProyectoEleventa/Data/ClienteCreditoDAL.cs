using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoEleventa.Data
{
    public class ClienteCreditoDAL
    {
        private static readonly ConcurrentDictionary<string, HashSet<string>> _columnsCache =
            new ConcurrentDictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

        private static HashSet<string> ObtenerColumnasClientes()
        {
            return _columnsCache.GetOrAdd("clientes", _ =>
            {
                const string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'clientes'";
                var dt = DBConnection.ExecuteQuery(query);
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

        private static HashSet<string> ObtenerColumnasVentas()
        {
            return _columnsCache.GetOrAdd("ventas", _ =>
            {
                const string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'ventas'";
                var dt = DBConnection.ExecuteQuery(query);
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

        private static HashSet<string> ObtenerColumnasUsuarios()
        {
            return _columnsCache.GetOrAdd("usuarios", _ =>
            {
                const string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'usuarios'";
                var dt = DBConnection.ExecuteQuery(query);
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

        private static string ColNombreCompleto(HashSet<string> cols)
        {
            if (cols.Contains("nombre") && cols.Contains("apellidos"))
            {
                return "LTRIM(RTRIM(ISNULL(nombre, ''))) + CASE WHEN ISNULL(apellidos,'')='' THEN '' ELSE ' ' + LTRIM(RTRIM(apellidos)) END";
            }
            if (cols.Contains("nombre"))
            {
                return "ISNULL(nombre,'')";
            }
            return "''";
        }

        private static string ColTelefono(HashSet<string> cols)
        {
            return cols.Contains("telefono") ? "telefono" : "NULL";
        }

        private static string ColLimiteCredito(HashSet<string> cols)
        {
            if (cols.Contains("limite_credito"))
            {
                return "ISNULL(limite_credito,0)";
            }
            return "0";
        }

        private static string ColCreditoUsado(HashSet<string> cols)
        {
            if (cols.Contains("credito_usado"))
            {
                return "ISNULL(credito_usado,0)";
            }
            return "0";
        }

        private static string ExprSaldoActual(HashSet<string> colsClientes)
        {
            if (colsClientes.Contains("credito_usado"))
            {
                return ColCreditoUsado(colsClientes);
            }

            var colsVentas = ObtenerColumnasVentas();
            if (!colsVentas.Contains("id_cliente") || !colsVentas.Contains("total") || !colsVentas.Contains("metodo_pago"))
            {
                return "0";
            }

            var filtroEstado = colsVentas.Contains("estado")
                ? " AND (v.estado IS NULL OR v.estado NOT LIKE 'Cancel%')"
                : string.Empty;

            return $"(SELECT ISNULL(SUM(v.total),0) FROM ventas v WHERE v.id_cliente = clientes.id_cliente AND UPPER(v.metodo_pago) IN ('CRÉDITO','CREDITO'){filtroEstado})";
        }

        private static string ColTieneCredito(HashSet<string> cols)
        {
            if (cols.Contains("tiene_credito_autorizado"))
            {
                return "tiene_credito_autorizado";
            }
            return "1";
        }

        public static DataTable BuscarClientesEstadoCuenta(string texto)
        {
            var cols = ObtenerColumnasClientes();
            var nombreExpr = ColNombreCompleto(cols);
            var telefonoCol = ColTelefono(cols);
            var limiteExpr = ColLimiteCredito(cols);
            var saldoExpr = ExprSaldoActual(cols);
            var tieneCreditoExpr = ColTieneCredito(cols);

            var where = "";
            var parameters = new List<SqlParameter>();
            if (!string.IsNullOrWhiteSpace(texto))
            {
                where = "WHERE (" + nombreExpr + " LIKE @q";
                parameters.Add(new SqlParameter("@q", "%" + texto + "%"));

                if (cols.Contains("telefono"))
                {
                    where += " OR telefono LIKE @q";
                }

                where += ")";
            }

            var query = $@"
SELECT
    id_cliente,
    ({nombreExpr}) AS nombre_cliente,
    {telefonoCol} AS telefono,
    {limiteExpr} AS limite_credito,
    {saldoExpr} AS saldo_actual,
    {tieneCreditoExpr} AS tiene_credito
FROM clientes
{where}
ORDER BY ({nombreExpr})";

            return DBConnection.ExecuteQuery(query, parameters.ToArray());
        }

        public static DataTable ObtenerReporteSaldos()
        {
            var cols = ObtenerColumnasClientes();
            var nombreExpr = ColNombreCompleto(cols);
            var telefonoCol = ColTelefono(cols);
            var limiteExpr = ColLimiteCredito(cols);
            var saldoExpr = ExprSaldoActual(cols);
            var tieneCreditoExpr = ColTieneCredito(cols);

            var query = $@"
SELECT
    id_cliente,
    ({nombreExpr}) AS nombre_cliente,
    {telefonoCol} AS telefono,
    {limiteExpr} AS limite_credito,
    {saldoExpr} AS saldo_actual,
    NULL AS ultimo_pago,
    {tieneCreditoExpr} AS tiene_credito
FROM clientes
ORDER BY ({nombreExpr})";

            return DBConnection.ExecuteQuery(query);
        }

        public static decimal ObtenerSaldoActual(int idCliente)
        {
            var cols = ObtenerColumnasClientes();
            if (cols.Contains("credito_usado"))
            {
                const string query = "SELECT ISNULL(credito_usado,0) FROM clientes WHERE id_cliente = @id";
                var obj = DBConnection.ExecuteScalar(query, new SqlParameter("@id", idCliente));
                return obj != null ? Convert.ToDecimal(obj) : 0m;
            }

            var colsVentas = ObtenerColumnasVentas();
            if (!colsVentas.Contains("id_cliente") || !colsVentas.Contains("total") || !colsVentas.Contains("metodo_pago"))
            {
                return 0m;
            }

            var filtroEstado = colsVentas.Contains("estado")
                ? " AND (estado IS NULL OR estado NOT LIKE 'Cancel%')"
                : string.Empty;

            var query2 = "SELECT ISNULL(SUM(total),0) FROM ventas WHERE id_cliente = @id AND UPPER(metodo_pago) IN ('CRÉDITO','CREDITO')" + filtroEstado;
            var obj2 = DBConnection.ExecuteScalar(query2, new SqlParameter("@id", idCliente));
            return obj2 != null ? Convert.ToDecimal(obj2) : 0m;
        }

        public static DataTable ObtenerMovimientosCredito(int idCliente)
        {
            var colsVentas = ObtenerColumnasVentas();
            if (!colsVentas.Contains("id_cliente") || !colsVentas.Contains("id_venta") || !colsVentas.Contains("total") || !colsVentas.Contains("metodo_pago"))
            {
                return new DataTable();
            }

            var colFecha = colsVentas.Contains("fecha_venta") ? "fecha_venta" : null;
            var colUsuarioId = colsVentas.Contains("id_usuario") ? "id_usuario" : null;
            var filtroEstado = colsVentas.Contains("estado")
                ? " AND (v.estado IS NULL OR v.estado NOT LIKE 'Cancel%')"
                : string.Empty;

            var colsUsuarios = ObtenerColumnasUsuarios();
            string usuarioNombreCol = colsUsuarios.Contains("usuario") ? "usuario" : (colsUsuarios.Contains("nombre_usuario") ? "nombre_usuario" : null);
            var joinUsuario = (!string.IsNullOrWhiteSpace(colUsuarioId) && !string.IsNullOrWhiteSpace(usuarioNombreCol) && colsUsuarios.Contains("id_usuario"))
                ? $"LEFT JOIN usuarios u ON u.id_usuario = v.{colUsuarioId}"
                : string.Empty;
            var cajeroExpr = (!string.IsNullOrWhiteSpace(joinUsuario))
                ? $"u.{usuarioNombreCol}"
                : (string.IsNullOrWhiteSpace(colUsuarioId) ? "NULL" : $"CONVERT(varchar(20), v.{colUsuarioId})");

            var fechaExpr = !string.IsNullOrWhiteSpace(colFecha) ? $"v.{colFecha}" : "NULL";

            var query = $@"
SELECT
    {fechaExpr} AS fecha_hora,
    v.id_venta AS folio,
    'Venta a Crédito' AS movimiento,
    v.total AS monto,
    SUM(v.total) OVER (ORDER BY {(string.IsNullOrWhiteSpace(colFecha) ? "v.id_venta" : $"v.{colFecha}" )}, v.id_venta ROWS UNBOUNDED PRECEDING) AS saldo_actual,
    {cajeroExpr} AS cajero
FROM ventas v
{joinUsuario}
WHERE v.id_cliente = @id
  AND UPPER(v.metodo_pago) IN ('CRÉDITO','CREDITO')
{filtroEstado}
ORDER BY {(string.IsNullOrWhiteSpace(colFecha) ? "v.id_venta" : $"v.{colFecha}" )}, v.id_venta";

            return DBConnection.ExecuteQuery(query, new SqlParameter("@id", idCliente));
        }
    }
}
