using System;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoEleventa.Data
{
    /// <summary>
    /// Data Access Layer para la tabla clientes.
    /// Métodos para obtener información de clientes y crédito.
    /// </summary>
    public class ClienteDAL
    {
        /// <summary>
        /// Obtiene todos los clientes activos.
        /// </summary>
        public static DataTable ObtenerTodos()
        {
            string query = @"
                SELECT id_cliente, nombre, limite_credito, credito_usado
                FROM clientes
                WHERE estado = 1
                ORDER BY nombre";

            return DBConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Obtiene un cliente específico por ID.
        /// </summary>
        public static DataRow ObtenerPorId(int idCliente)
        {
            string query = @"
                SELECT id_cliente, nombre, email, telefono, limite_credito, credito_usado
                FROM clientes
                WHERE id_cliente = @id AND estado = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", idCliente)
            };

            DataTable dt = DBConnection.ExecuteQuery(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Verifica si un cliente puede usar crédito.
        /// Retorna el crédito disponible.
        /// </summary>
        public static decimal ObtenerCreditoDisponible(int idCliente)
        {
            string query = @"
                SELECT (limite_credito - ISNULL(credito_usado, 0)) as creditoDisponible
                FROM clientes
                WHERE id_cliente = @id AND estado = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", idCliente)
            };

            object result = DBConnection.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToDecimal(result) : 0;
        }

        /// <summary>
        /// Busca un cliente por nombre (para autocompletado).
        /// </summary>
        public static DataTable BuscarPorNombre(string nombre)
        {
            string query = @"
                SELECT id_cliente, nombre, limite_credito, credito_usado
                FROM clientes
                WHERE nombre LIKE @nombre AND estado = 1
                ORDER BY nombre";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nombre", "%" + nombre + "%")
            };

            return DBConnection.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Actualiza el crédito usado del cliente.
        /// Se usa dentro de una transacción.
        /// </summary>
        public static int ActualizarCreditoUsado(int idCliente, decimal monto, SqlConnection conn, SqlTransaction trans)
        {
            string query = @"
                UPDATE clientes
                SET credito_usado = credito_usado + @monto
                WHERE id_cliente = @idCliente";

            SqlCommand cmd = new SqlCommand(query, conn, trans);
            cmd.Parameters.AddWithValue("@monto", monto);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Obtiene el cliente por defecto (ventas sin cliente específico).
        /// Generalmente es un cliente "MOSTRADOR" o "CONSUMIDOR FINAL".
        /// </summary>
        public static int ObtenerClientePorDefecto()
        {
            string query = "SELECT TOP 1 id_cliente FROM clientes WHERE nombre = 'MOSTRADOR' OR nombre = 'CONSUMIDOR FINAL'";
            object result = DBConnection.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 1;
        }
    }
}
