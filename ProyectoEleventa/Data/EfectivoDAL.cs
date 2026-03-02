using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoEleventa.Data
{
    public static class EfectivoDAL
    {
        private const string Tabla = "movimientos_efectivo";

        private static readonly ConcurrentDictionary<string, HashSet<string>> _columnsCache =
            new ConcurrentDictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

        private static bool TablaExiste()
        {
            const string q = "SELECT CASE WHEN OBJECT_ID(@t, 'U') IS NULL THEN 0 ELSE 1 END";
            object obj = DBConnection.ExecuteScalar(q, new SqlParameter("@t", "dbo." + Tabla));
            return obj != null && Convert.ToInt32(obj) == 1;
        }

        private static HashSet<string> ObtenerColumnas()
        {
            return _columnsCache.GetOrAdd(Tabla, _ =>
            {
                const string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @t";
                var dt = DBConnection.ExecuteQuery(query, new SqlParameter("@t", Tabla));
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

        public static int RegistrarMovimiento(string tipo, decimal cantidad, string comentario, int? idUsuario)
        {
            if (!TablaExiste())
            {
                throw new InvalidOperationException("No existe la tabla 'movimientos_efectivo'. Ejecuta el script Scripts_SQL/crear_movimientos_efectivo.sql y vuelve a intentar.");
            }

            var cols = ObtenerColumnas();
            bool tieneUsuario = idUsuario.HasValue && idUsuario.Value > 0 && cols.Contains("id_usuario");

            string query;
            SqlParameter[] parameters;

            if (tieneUsuario)
            {
                query = @"
                    INSERT INTO movimientos_efectivo (tipo, cantidad, comentario, fecha, id_usuario)
                    VALUES (@tipo, @cantidad, @comentario, GETDATE(), @idUsuario);
                    SELECT SCOPE_IDENTITY();";

                parameters = new SqlParameter[]
                {
                    new SqlParameter("@tipo", tipo ?? string.Empty),
                    new SqlParameter("@cantidad", cantidad),
                    new SqlParameter("@comentario", (object)(comentario ?? string.Empty) ?? DBNull.Value),
                    new SqlParameter("@idUsuario", idUsuario.Value),
                };
            }
            else
            {
                query = @"
                    INSERT INTO movimientos_efectivo (tipo, cantidad, comentario, fecha)
                    VALUES (@tipo, @cantidad, @comentario, GETDATE());
                    SELECT SCOPE_IDENTITY();";

                parameters = new SqlParameter[]
                {
                    new SqlParameter("@tipo", tipo ?? string.Empty),
                    new SqlParameter("@cantidad", cantidad),
                    new SqlParameter("@comentario", (object)(comentario ?? string.Empty) ?? DBNull.Value),
                };
            }

            object idObj = DBConnection.ExecuteScalar(query, parameters);
            return idObj == null ? 0 : Convert.ToInt32(idObj);
        }

        public static DataTable ObtenerMovimientos(string tipo, DateTime desde, DateTime hasta)
        {
            if (!TablaExiste())
            {
                throw new InvalidOperationException("No existe la tabla 'movimientos_efectivo'. Ejecuta el script Scripts_SQL/crear_movimientos_efectivo.sql y vuelve a intentar.");
            }

            string whereTipo = string.IsNullOrWhiteSpace(tipo) ? "" : " AND tipo = @tipo";

            string query = @"
                SELECT id_movimiento, tipo, cantidad, comentario, fecha
                FROM movimientos_efectivo
                WHERE fecha >= @desde AND fecha < @hasta" + whereTipo + @"
                ORDER BY fecha DESC";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@desde", desde),
                new SqlParameter("@hasta", hasta),
            };
            if (!string.IsNullOrWhiteSpace(tipo))
                parameters.Add(new SqlParameter("@tipo", tipo));

            return DBConnection.ExecuteQuery(query, parameters.ToArray());
        }
    }
}
