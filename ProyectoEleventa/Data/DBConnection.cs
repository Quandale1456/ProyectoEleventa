using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoEleventa.Data
{
    /// <summary>
    /// Clase para manejar la conexión a SQL Server.
    /// Reutilizable en toda la aplicación.
    /// </summary>
    public class DBConnection
    {
        // Cadena de conexión - cambiar según tu servidor
        private static readonly string _connectionString =
            @"Server=DESKTOP-6QV8JQ9\SQLEXPRESS;Database=sistema_ventas;Integrated Security=true;";

        /// <summary>
        /// Obtiene la cadena de conexión configurada.
        /// </summary>
        public static string ConnectionString => _connectionString;

        /// <summary>
        /// Crea y retorna una nueva conexión a la base de datos.
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Ejecuta una consulta SELECT y retorna un DataTable.
        /// </summary>
        public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la consulta: {ex.Message}", "Error de Base de Datos", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>
        /// Ejecuta una consulta sin retornar datos (INSERT, UPDATE, DELETE).
        /// </summary>
        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error ejecutando operación: {ex.Message}", "Error de Base de Datos", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        /// <summary>
        /// Ejecuta una consulta y retorna un valor escalar (un solo valor).
        /// </summary>
        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error obteniendo valor: {ex.Message}", "Error de Base de Datos", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Ejecuta una operación dentro de una transacción.
        /// </summary>
        public static bool ExecuteTransaction(Action<SqlConnection, SqlTransaction> action)
        {
            SqlConnection conn = GetConnection();
            SqlTransaction transaction = null;
            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();
                action(conn, transaction);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Error en la transacción: {ex.Message}", "Error de Base de Datos", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conn?.Close();
                conn?.Dispose();
            }
        }

        /// <summary>
        /// Prueba la conexión a la base de datos.
        /// Útil para verificar que todo está bien antes de usar el sistema.
        /// </summary>
        public static bool ProbarConexion()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT 1";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteScalar();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error conectando a la BD:\n{ex.Message}\n\n" +
                    $"Cadena de conexión:\n{_connectionString}", 
                    "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
