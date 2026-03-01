using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoEleventa.Data
{
    public class UsuarioDAL
    {
        private static readonly ConcurrentDictionary<string, HashSet<string>> _columnsCache =
            new ConcurrentDictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

        private static readonly HashSet<string> _permisosPermitidos = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "ventas_producto_comun",
            "ventas_aplicar_mayoreo",
            "ventas_aplicar_descuento",
            "ventas_revisar_historial",
            "ventas_entradas_efectivo",
            "ventas_salidas_efectivo",
            "ventas_cobrar_ticket",
            "ventas_cobrar_credito",
            "ventas_cancelar_tickets",
            "ventas_eliminar_articulos",
            "ventas_facturar",
            "ventas_ver_facturas",
            "ventas_vender_pago_servicio",
            "ventas_vender_recargas",
            "ventas_usar_buscador",
            "clientes_abc",
            "clientes_asignar_venta",
            "clientes_asignar_credito",
            "clientes_ver_cuenta",
            "productos_crear",
            "productos_modificar",
            "productos_eliminar",
            "productos_ver_reporte_ventas",
            "productos_crear_promociones",
            "productos_modificar_varios",
            "inventario_agregar_mercancia",
            "inventario_ver_reportes",
            "inventario_ver_movimientos",
            "inventario_ajustar",
            "otros_corte_turno",
            "otros_corte_todos_turnos",
            "otros_corte_dia",
            "otros_ver_ganancia_dia",
            "otros_cambiar_configuracion",
            "otros_acceder_reportes",
            "otros_crear_ordenes_compra",
            "otros_recibir_ordenes_compra"
        };

        private static Dictionary<string, bool> FiltrarPermisos(Dictionary<string, bool> permisos)
        {
            var result = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
            if (permisos == null)
            {
                return result;
            }

            foreach (var kvp in permisos)
            {
                if (!string.IsNullOrWhiteSpace(kvp.Key) && _permisosPermitidos.Contains(kvp.Key))
                {
                    result[kvp.Key] = kvp.Value;
                }
            }

            return result;
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

        private static string ColUsuario(HashSet<string> cols) => cols.Contains("usuario") ? "usuario" : (cols.Contains("nombre_usuario") ? "nombre_usuario" : null);
        private static string ColPassword(HashSet<string> cols) => cols.Contains("password") ? "password" : (cols.Contains("contraseña") ? "contraseña" : null);
        private static string ColNombreCompleto(HashSet<string> cols) => cols.Contains("nombre_completo") ? "nombre_completo" : null;
        private static string ColEstado(HashSet<string> cols) => cols.Contains("estado") ? "estado" : null;

        public static DataTable ObtenerActivos()
        {
            var cols = ObtenerColumnasUsuarios();
            var colUsuario = ColUsuario(cols);
            var colEstado = ColEstado(cols);

            if (string.IsNullOrWhiteSpace(colUsuario) || string.IsNullOrWhiteSpace(colEstado))
            {
                throw new InvalidOperationException("La tabla 'usuarios' no tiene las columnas mínimas requeridas (usuario/nombre_usuario y estado). Ajusta el esquema o el DAL.");
            }

            var query = $"SELECT * FROM usuarios WHERE {colEstado} = 1 ORDER BY {colUsuario}";
            return DBConnection.ExecuteQuery(query);
        }

        public static DataRow ObtenerPorId(int idUsuario)
        {
            const string query = "SELECT * FROM usuarios WHERE id_usuario = @id_usuario";
            var dt = DBConnection.ExecuteQuery(query, new SqlParameter("@id_usuario", idUsuario));
            return dt != null && dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static int Crear(string usuario, string password, string nombreCompleto, Dictionary<string, bool> permisos)
        {
            permisos = FiltrarPermisos(permisos);

            var cols = ObtenerColumnasUsuarios();
            var colUsuario = ColUsuario(cols);
            var colPassword = ColPassword(cols);
            var colNombreCompleto = ColNombreCompleto(cols);
            var colEstado = ColEstado(cols);

            if (string.IsNullOrWhiteSpace(colUsuario) || string.IsNullOrWhiteSpace(colEstado))
            {
                throw new InvalidOperationException("La tabla 'usuarios' no tiene las columnas mínimas requeridas (usuario/nombre_usuario y estado). Ajusta el esquema o el DAL.");
            }

            var columnas = new List<string> { colUsuario };
            var valores = new List<string> { "@usuario" };
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@usuario", usuario),
            };

            if (!string.IsNullOrWhiteSpace(colPassword))
            {
                columnas.Add(colPassword);
                valores.Add("@password");
                parameters.Add(new SqlParameter("@password", password ?? string.Empty));
            }

            if (!string.IsNullOrWhiteSpace(colNombreCompleto))
            {
                columnas.Add(colNombreCompleto);
                valores.Add("@nombre_completo");
                parameters.Add(new SqlParameter("@nombre_completo", (object)nombreCompleto ?? DBNull.Value));
            }

            columnas.Add(colEstado);
            valores.Add("1");

            foreach (var kvp in permisos)
            {
                if (cols.Contains(kvp.Key))
                {
                    columnas.Add(kvp.Key);
                    valores.Add("@" + kvp.Key);
                    parameters.Add(new SqlParameter("@" + kvp.Key, kvp.Value));
                }
            }

            var query = $"INSERT INTO usuarios ({string.Join(", ", columnas)}) VALUES ({string.Join(", ", valores)}); SELECT SCOPE_IDENTITY();";
            var idObj = DBConnection.ExecuteScalar(query, parameters.ToArray());
            return idObj == null ? 0 : Convert.ToInt32(idObj);
        }

        public static int Actualizar(int idUsuario, string usuario, string password, string nombreCompleto, Dictionary<string, bool> permisos)
        {
            permisos = FiltrarPermisos(permisos);

            var cols = ObtenerColumnasUsuarios();
            var colUsuario = ColUsuario(cols);
            var colPassword = ColPassword(cols);
            var colNombreCompleto = ColNombreCompleto(cols);

            if (string.IsNullOrWhiteSpace(colUsuario))
            {
                throw new InvalidOperationException("La tabla 'usuarios' no tiene la columna usuario/nombre_usuario. Ajusta el esquema o el DAL.");
            }

            var sets = new List<string>
            {
                $"{colUsuario} = @usuario"
            };

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@id_usuario", idUsuario),
                new SqlParameter("@usuario", usuario),
            };

            if (!string.IsNullOrWhiteSpace(colPassword))
            {
                sets.Add($"{colPassword} = @password");
                parameters.Add(new SqlParameter("@password", password ?? string.Empty));
            }

            if (!string.IsNullOrWhiteSpace(colNombreCompleto))
            {
                sets.Add($"{colNombreCompleto} = @nombre_completo");
                parameters.Add(new SqlParameter("@nombre_completo", (object)nombreCompleto ?? DBNull.Value));
            }

            foreach (var kvp in permisos)
            {
                if (cols.Contains(kvp.Key))
                {
                    sets.Add(kvp.Key + " = @" + kvp.Key);
                    parameters.Add(new SqlParameter("@" + kvp.Key, kvp.Value));
                }
            }

            var query = $"UPDATE usuarios SET {string.Join(", ", sets)} WHERE id_usuario = @id_usuario";
            return DBConnection.ExecuteNonQuery(query, parameters.ToArray());
        }

        public static int DarDeBaja(int idUsuario)
        {
            var cols = ObtenerColumnasUsuarios();
            var colEstado = ColEstado(cols);
            if (string.IsNullOrWhiteSpace(colEstado))
            {
                throw new InvalidOperationException("La tabla 'usuarios' no tiene la columna estado.");
            }

            var query = $"UPDATE usuarios SET {colEstado} = 0 WHERE id_usuario = @id_usuario";
            return DBConnection.ExecuteNonQuery(query, new SqlParameter("@id_usuario", idUsuario));
        }

        public static bool ExisteUsuario(string usuario, int? ignorarIdUsuario = null)
        {
            var cols = ObtenerColumnasUsuarios();
            var colUsuario = ColUsuario(cols);
            if (string.IsNullOrWhiteSpace(colUsuario))
            {
                throw new InvalidOperationException("La tabla 'usuarios' no tiene la columna usuario/nombre_usuario.");
            }

            string query = $"SELECT COUNT(*) FROM usuarios WHERE {colUsuario} = @usuario";
            var parameters = new List<SqlParameter> { new SqlParameter("@usuario", usuario) };

            if (ignorarIdUsuario.HasValue)
            {
                query += " AND id_usuario <> @id_usuario";
                parameters.Add(new SqlParameter("@id_usuario", ignorarIdUsuario.Value));
            }

            var obj = DBConnection.ExecuteScalar(query, parameters.ToArray());
            return obj != null && Convert.ToInt32(obj) > 0;
        }
    }
}
