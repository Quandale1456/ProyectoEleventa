using System;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoEleventa.Data
{
    /// <summary>
    /// Data Access Layer para la tabla productos.
    /// Métodos para obtener información de productos.
    /// </summary>
    public class ProductoDAL
    {
        /// <summary>
        /// Busca un producto por código de barras.
        /// </summary>
        public static DataRow BuscarPorCodigo(string codigo)
        {
            string query = @"
                SELECT TOP 1 id_producto, nombre, precio_venta, existencia
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
        /// Busca productos por nombre (para búsqueda general).
        /// </summary>
        public static DataTable BuscarPorNombre(string nombre)
        {
            string query = @"
                SELECT TOP 100 id_producto, nombre, codigo_barras, precio_venta, existencia, departamento
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
        /// Obtiene un producto específico por ID.
        /// </summary>
        public static DataRow ObtenerPorId(int idProducto)
        {
            string query = @"
                SELECT TOP 1 id_producto, nombre, codigo_barras, precio_venta, existencia, departamento
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
        /// Busca un producto por ID (búsqueda rápida).
        /// </summary>
        public static DataRow BuscarPorId(int idProducto)
        {
            return ObtenerPorId(idProducto);
        }

        /// <summary>
        /// Obtiene todos los productos disponibles.
        /// </summary>
        public static DataTable ObtenerTodos()
        {
            string query = @"
                SELECT id_producto, nombre, codigo_barras, precio_venta, existencia, departamento
                FROM productos
                WHERE estado = 1
                ORDER BY nombre";

            return DBConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Actualiza la existencia de un producto (reducción por venta).
        /// Se usa dentro de una transacción.
        /// </summary>
        public static int ActualizarExistencia(int idProducto, decimal cantidad, SqlConnection conn, SqlTransaction trans)
        {
            string query = @"
                UPDATE productos
                SET existencia = existencia - @cantidad
                WHERE id_producto = @idProducto AND existencia >= @cantidad";

            SqlCommand cmd = new SqlCommand(query, conn, trans);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.Parameters.AddWithValue("@idProducto", idProducto);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Obtiene la existencia actual de un producto.
        /// </summary>
        public static decimal ObtenerExistencia(int idProducto)
        {
            string query = "SELECT existencia FROM productos WHERE id_producto = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", idProducto)
            };

            object result = DBConnection.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToDecimal(result) : 0;
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
    }
}
