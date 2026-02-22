using System;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoEleventa.Data
{
    /// <summary>
    /// Data Access Layer para la tabla promociones.
    /// Maneja todas las operaciones CRUD de promociones.
    /// </summary>
    public class PromociónDAL
    {
        /// <summary>
        /// Obtiene todas las promociones activas.
        /// </summary>
        public static DataTable ObtenerTodas()
        {
            string query = @"
                SELECT p.id_promocion, p.nombre_promocion, pr.codigo_barras, pr.nombre,
                       p.cantidad_desde, p.cantidad_hasta, p.precio_promocion,
                       pr.precio_venta as precio_normal
                FROM promociones p
                JOIN productos pr ON p.id_producto = pr.id_producto
                WHERE p.estado = 1
                ORDER BY p.nombre_promocion";

            return DBConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Obtiene una promoción por ID.
        /// </summary>
        public static DataRow ObtenerPorId(int idPromocion)
        {
            string query = @"
                SELECT p.id_promocion, p.nombre_promocion, p.id_producto, 
                       p.cantidad_desde, p.cantidad_hasta, p.precio_promocion,
                       pr.codigo_barras, pr.nombre, pr.precio_venta
                FROM promociones p
                JOIN productos pr ON p.id_producto = pr.id_producto
                WHERE p.id_promocion = @id AND p.estado = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", idPromocion)
            };

            DataTable dt = DBConnection.ExecuteQuery(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Busca el precio promocional de un producto según la cantidad.
        /// </summary>
        public static decimal ObtenerPrecioPromocion(int idProducto, int cantidad)
        {
            string query = @"
                SELECT TOP 1 precio_promocion
                FROM promociones
                WHERE id_producto = @idProducto 
                  AND cantidad_desde <= @cantidad 
                  AND cantidad_hasta >= @cantidad
                  AND estado = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idProducto", idProducto),
                new SqlParameter("@cantidad", cantidad)
            };

            object result = DBConnection.ExecuteScalar(query, parameters);
            return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }

        /// <summary>
        /// Verifica si existe una promoción para un producto en un rango de cantidad.
        /// </summary>
        public static bool ExistePromocion(int idProducto, int cantidadDesde, int cantidadHasta)
        {
            string query = @"
                SELECT COUNT(*) FROM promociones
                WHERE id_producto = @idProducto 
                  AND estado = 1
                  AND (
                    (cantidad_desde <= @cantidadDesde AND cantidad_hasta >= @cantidadDesde)
                    OR (cantidad_desde <= @cantidadHasta AND cantidad_hasta >= @cantidadHasta)
                    OR (cantidad_desde >= @cantidadDesde AND cantidad_hasta <= @cantidadHasta)
                  )";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idProducto", idProducto),
                new SqlParameter("@cantidadDesde", cantidadDesde),
                new SqlParameter("@cantidadHasta", cantidadHasta)
            };

            object result = DBConnection.ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) > 0;
        }

        /// <summary>
        /// Crea una nueva promoción.
        /// </summary>
        public static bool Crear(string nombrePromocion, int idProducto, 
            int cantidadDesde, int cantidadHasta, decimal precioPromocion)
        {
            try
            {
                // Validar que no exista una promoción superpuesta
                if (ExistePromocion(idProducto, cantidadDesde, cantidadHasta))
                {
                    return false;
                }

                string query = @"
                    INSERT INTO promociones (nombre_promocion, id_producto, cantidad_desde, 
                                            cantidad_hasta, precio_promocion, estado, fecha_creacion)
                    VALUES (@nombre, @idProducto, @cantidadDesde, @cantidadHasta, 
                            @precioPromocion, 1, GETDATE())";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@nombre", nombrePromocion),
                    new SqlParameter("@idProducto", idProducto),
                    new SqlParameter("@cantidadDesde", cantidadDesde),
                    new SqlParameter("@cantidadHasta", cantidadHasta),
                    new SqlParameter("@precioPromocion", precioPromocion)
                };

                return DBConnection.ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Actualiza una promoción existente.
        /// </summary>
        public static bool Actualizar(int idPromocion, string nombrePromocion, int idProducto,
            int cantidadDesde, int cantidadHasta, decimal precioPromocion)
        {
            try
            {
                string query = @"
                    UPDATE promociones
                    SET nombre_promocion = @nombre,
                        id_producto = @idProducto,
                        cantidad_desde = @cantidadDesde,
                        cantidad_hasta = @cantidadHasta,
                        precio_promocion = @precioPromocion,
                        fecha_actualizacion = GETDATE()
                    WHERE id_promocion = @id";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", idPromocion),
                    new SqlParameter("@nombre", nombrePromocion),
                    new SqlParameter("@idProducto", idProducto),
                    new SqlParameter("@cantidadDesde", cantidadDesde),
                    new SqlParameter("@cantidadHasta", cantidadHasta),
                    new SqlParameter("@precioPromocion", precioPromocion)
                };

                return DBConnection.ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina una promoción (soft delete).
        /// </summary>
        public static bool Eliminar(int idPromocion)
        {
            try
            {
                string query = @"
                    UPDATE promociones
                    SET estado = 0, fecha_actualizacion = GETDATE()
                    WHERE id_promocion = @id";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", idPromocion)
                };

                return DBConnection.ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
