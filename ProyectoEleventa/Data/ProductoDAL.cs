using System;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoEleventa.Data
{
    /// <summary>
    /// Data Access Layer para la tabla productos.
    /// Métodos CRUD completos y operaciones de inventario.
    /// </summary>
    public class ProductoDAL
    {
        /// <summary>
        /// Crea un nuevo producto en la base de datos.
        /// </summary>
        public static bool CrearProducto(string codigo, string nombre, decimal costo, 
            decimal porcentajeGanancia, decimal precioVenta, decimal existencia, 
            int departamento, decimal existenciaMinima = 0, decimal existenciaMaxima = 0)
        {
            try
            {
                // Validar que el código no exista
                if (CodigoExiste(codigo))
                {
                    return false;
                }

                string query = @"
                    INSERT INTO productos 
                    (codigo_barras, nombre, precio_compra, porcentaje_ganancia, precio_venta, 
                     existencia, departamento, estado, fecha_creacion, existencia_minima, existencia_maxima)
                    VALUES 
                    (@codigo, @nombre, @costo, @ganancia, @precioVenta, 
                     @existencia, @departamento, 1, GETDATE(), @existenciaMinima, @existenciaMaxima)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@codigo", codigo ?? ""),
                    new SqlParameter("@nombre", nombre ?? ""),
                    new SqlParameter("@costo", costo),
                    new SqlParameter("@ganancia", porcentajeGanancia),
                    new SqlParameter("@precioVenta", precioVenta),
                    new SqlParameter("@existencia", existencia),
                    new SqlParameter("@departamento", departamento > 0 ? (object)departamento : DBNull.Value),
                    new SqlParameter("@existenciaMinima", existenciaMinima),
                    new SqlParameter("@existenciaMaxima", existenciaMaxima)
                };

                int resultado = DBConnection.ExecuteNonQuery(query, parameters);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error al crear producto: {ex.Message}", 
                    "Error", System.Windows.Forms.MessageBoxButtons.OK, 
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        public static bool ActualizarProducto(int idProducto, string codigo, string nombre, 
            decimal costo, decimal porcentajeGanancia, decimal precioVenta, 
            decimal existencia, int departamento, decimal existenciaMinima = 0, 
            decimal existenciaMaxima = 0)
        {
            try
            {
                // Validar código duplicado (si cambió)
                string codigoAnterior = ObtenerCodigoProducto(idProducto);
                if (!codigo.Equals(codigoAnterior) && CodigoExiste(codigo))
                {
                    return false;
                }

                string query = @"
                    UPDATE productos
                    SET codigo_barras = @codigo,
                        nombre = @nombre,
                        precio_compra = @costo,
                        porcentaje_ganancia = @ganancia,
                        precio_venta = @precioVenta,
                        existencia = @existencia,
                        departamento = @departamento,
                        existencia_minima = @existenciaMinima,
                        existencia_maxima = @existenciaMaxima
                    WHERE id_producto = @id AND estado = 1";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", idProducto),
                    new SqlParameter("@codigo", codigo ?? ""),
                    new SqlParameter("@nombre", nombre ?? ""),
                    new SqlParameter("@costo", costo),
                    new SqlParameter("@ganancia", porcentajeGanancia),
                    new SqlParameter("@precioVenta", precioVenta),
                    new SqlParameter("@existencia", existencia),
                    new SqlParameter("@departamento", departamento > 0 ? (object)departamento : DBNull.Value),
                    new SqlParameter("@existenciaMinima", existenciaMinima),
                    new SqlParameter("@existenciaMaxima", existenciaMaxima)
                };

                int resultado = DBConnection.ExecuteNonQuery(query, parameters);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error al actualizar producto: {ex.Message}", 
                    "Error", System.Windows.Forms.MessageBoxButtons.OK, 
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Elimina un producto (borrado lógico, solo cambia estado).
        /// </summary>
        public static bool EliminarProducto(int idProducto)
        {
            try
            {
                string query = "UPDATE productos SET estado = 0 WHERE id_producto = @id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", idProducto)
                };

                int resultado = DBConnection.ExecuteNonQuery(query, parameters);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error al eliminar producto: {ex.Message}", 
                    "Error", System.Windows.Forms.MessageBoxButtons.OK, 
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Obtiene todos los productos disponibles con toda la información.
        /// </summary>
        public static DataTable ObtenerTodos()
        {
            string query = @"
                SELECT id_producto, codigo_barras, nombre, precio_compra, 
                       porcentaje_ganancia, precio_venta, existencia, departamento,
                       ISNULL(existencia_minima, 0) as existencia_minima,
                       ISNULL(existencia_maxima, 0) as existencia_maxima
                FROM productos
                WHERE estado = 1
                ORDER BY nombre";

            return DBConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Busca un producto por código de barras.
        /// </summary>
        public static DataRow BuscarPorCodigo(string codigo)
        {
            string query = @"
                SELECT id_producto, codigo_barras, nombre, precio_compra, 
                       porcentaje_ganancia, precio_venta, existencia, departamento
                FROM productos
                WHERE codigo_barras = @codigo AND estado = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@codigo", codigo)
            };

            DataTable dt = DBConnection.ExecuteQuery(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Busca productos por nombre.
        /// </summary>
        public static DataTable BuscarPorNombre(string nombre)
        {
            string query = @"
                SELECT TOP 100 id_producto, codigo_barras, nombre, precio_compra, 
                       porcentaje_ganancia, precio_venta, existencia, departamento
                FROM productos
                WHERE nombre LIKE @nombre AND estado = 1
                ORDER BY nombre";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nombre", "%" + nombre + "%")
            };

            return DBConnection.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Obtiene un producto por ID.
        /// </summary>
        public static DataRow ObtenerPorId(int idProducto)
        {
            string query = @"
                SELECT id_producto, codigo_barras, nombre, precio_compra, 
                       porcentaje_ganancia, precio_venta, existencia, departamento
                FROM productos
                WHERE id_producto = @id AND estado = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", idProducto)
            };

            DataTable dt = DBConnection.ExecuteQuery(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Obtiene la existencia actual de un producto.
        /// </summary>
        public static decimal ObtenerExistencia(int idProducto)
        {
            string query = "SELECT existencia FROM productos WHERE id_producto = @id AND estado = 1";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", idProducto)
            };

            object result = DBConnection.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToDecimal(result) : 0;
        }

        /// <summary>
        /// Actualiza la existencia de un producto (reducción por venta).
        /// Se usa dentro de una transacción.
        /// </summary>
        public static int ActualizarExistencia(int idProducto, decimal cantidad, 
            SqlConnection conn, SqlTransaction trans)
        {
            string query = @"
                UPDATE productos
                SET existencia = existencia - @cantidad
                WHERE id_producto = @idProducto AND existencia >= @cantidad AND estado = 1";

            SqlCommand cmd = new SqlCommand(query, conn, trans);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.Parameters.AddWithValue("@idProducto", idProducto);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Verifica si un producto existe y está disponible.
        /// </summary>
        public static bool Existe(int idProducto)
        {
            string query = "SELECT COUNT(*) FROM productos WHERE id_producto = @id AND estado = 1";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", idProducto)
            };

            object result = DBConnection.ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) > 0;
        }

        /// <summary>
        /// Verifica si un código de barras ya existe en la base de datos.
        /// </summary>
        public static bool CodigoExiste(string codigo)
        {
            string query = "SELECT COUNT(*) FROM productos WHERE codigo_barras = @codigo AND estado = 1";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@codigo", codigo)
            };

            try
            {
                object result = DBConnection.ExecuteScalar(query, parameters);
                return result != null && Convert.ToInt32(result) > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Obtiene el código de barras de un producto.
        /// </summary>
        private static string ObtenerCodigoProducto(int idProducto)
        {
            string query = "SELECT codigo_barras FROM productos WHERE id_producto = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", idProducto)
            };

            object result = DBConnection.ExecuteScalar(query, parameters);
            return result != null ? result.ToString() : "";
        }

        /// <summary>
        /// Actualiza el stock mínimo y máximo de un producto.
        /// </summary>
        public static bool ActualizarStockMinMax(int idProducto, decimal existenciaMinima, decimal existenciaMaxima)
        {
            try
            {
                string query = @"
                    UPDATE productos
                    SET existencia_minima = @existenciaMinima,
                        existencia_maxima = @existenciaMaxima
                    WHERE id_producto = @id AND estado = 1";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", idProducto),
                    new SqlParameter("@existenciaMinima", existenciaMinima),
                    new SqlParameter("@existenciaMaxima", existenciaMaxima)
                };

                int resultado = DBConnection.ExecuteNonQuery(query, parameters);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error al actualizar stock mín/máx: {ex.Message}", 
                    "Error", System.Windows.Forms.MessageBoxButtons.OK, 
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Obtiene todos los departamentos únicos de los productos.
        /// </summary>
        public static DataTable ObtenerDepartamentosUnicos()
        {
            string query = @"
                SELECT DISTINCT departamento
                FROM productos
                WHERE estado = 1 AND departamento IS NOT NULL
                ORDER BY departamento";

            return DBConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Obtiene todos los productos que están por debajo de su stock mínimo.
        /// </summary>
        public static DataTable ObtenerProductosBajoInvMinimo()
        {
            string query = @"
                SELECT 
                    id_producto,
                    codigo_barras,
                    nombre,
                    precio_venta,
                    departamento,
                    existencia,
                    ISNULL(existencia_minima, 0) as existencia_minima,
                    ISNULL(existencia_maxima, 0) as existencia_maxima
                FROM productos
                WHERE estado = 1 
                  AND existencia_minima IS NOT NULL
                  AND existencia < existencia_minima
                ORDER BY existencia ASC";

            return DBConnection.ExecuteQuery(query);
        }
    }
}
