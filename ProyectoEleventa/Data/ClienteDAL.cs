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
                SELECT id_cliente, nombre, apellidos, telefono, domicilio1, domicilio2, colonia, 
                       codigo_postal, municipio, estado, notas, tiene_credito_autorizado
                FROM clientes
                ORDER BY nombre";

            return DBConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Obtiene un cliente específico por ID.
        /// </summary>
        public static DataRow ObtenerPorId(int idCliente)
        {
            string query = @"
                SELECT id_cliente, nombre, apellidos, telefono, domicilio1, domicilio2, colonia, 
                       codigo_postal, municipio, estado, notas, tiene_credito_autorizado
                FROM clientes
                WHERE id_cliente = @id";

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
                SELECT id_cliente, nombre, apellidos, telefono, domicilio1, domicilio2, colonia, 
                       codigo_postal, municipio, estado, notas, tiene_credito_autorizado
                FROM clientes
                WHERE nombre LIKE @nombre
                ORDER BY nombre";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nombre", "%" + nombre + "%")
            };

            return DBConnection.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Busca clientes por nombre, apellido o teléfono
        /// </summary>
        public static DataTable Buscar(string busqueda)
        {
            string query = @"
                SELECT id_cliente, nombre, apellidos, telefono, domicilio1, domicilio2, colonia, 
                       codigo_postal, municipio, estado, notas, tiene_credito_autorizado
                FROM clientes
                WHERE (nombre LIKE @busqueda OR apellidos LIKE @busqueda OR telefono LIKE @busqueda)
                ORDER BY nombre";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@busqueda", "%" + busqueda + "%")
            };

            return DBConnection.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Crea un nuevo cliente
        /// </summary>
        public static bool Crear(string nombre, string apellido, string telefono, string domicilio1,
            string domicilio2, string colonia, string codigoPostal, string municipio, string estado, 
            string comentarios, bool tieneCredito)
        {
            try
            {
                string query = @"
                    INSERT INTO clientes (nombre, apellidos, telefono, domicilio1, domicilio2, colonia, 
                                         codigo_postal, municipio, estado, notas, tiene_credito_autorizado, fecha_creacion)
                    VALUES (@nombre, @apellido, @telefono, @domicilio1, @domicilio2, @colonia, 
                            @codigoPostal, @municipio, @estado, @comentarios, @tieneCredito, GETDATE())";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@nombre", nombre),
                    new SqlParameter("@apellido", apellido ?? ""),
                    new SqlParameter("@telefono", telefono ?? ""),
                    new SqlParameter("@domicilio1", domicilio1 ?? ""),
                    new SqlParameter("@domicilio2", domicilio2 ?? ""),
                    new SqlParameter("@colonia", colonia ?? ""),
                    new SqlParameter("@codigoPostal", codigoPostal ?? ""),
                    new SqlParameter("@municipio", municipio ?? ""),
                    new SqlParameter("@estado", estado ?? ""),
                    new SqlParameter("@comentarios", comentarios ?? ""),
                    new SqlParameter("@tieneCredito", tieneCredito)
                };

                return DBConnection.ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Actualiza un cliente
        /// </summary>
        public static bool Actualizar(int idCliente, string nombre, string apellido, string telefono, 
            string domicilio1, string domicilio2, string colonia, string codigoPostal, string municipio, 
            string estado, string comentarios, bool tieneCredito)
        {
            try
            {
                string query = @"
                    UPDATE clientes
                    SET nombre = @nombre, apellidos = @apellido, telefono = @telefono, domicilio1 = @domicilio1,
                        domicilio2 = @domicilio2, colonia = @colonia, codigo_postal = @codigoPostal,
                        municipio = @municipio, estado = @estado, notas = @comentarios, tiene_credito_autorizado = @tieneCredito,
                        fecha_actualizacion = GETDATE()
                    WHERE id_cliente = @idCliente";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@idCliente", idCliente),
                    new SqlParameter("@nombre", nombre),
                    new SqlParameter("@apellido", apellido ?? ""),
                    new SqlParameter("@telefono", telefono ?? ""),
                    new SqlParameter("@domicilio1", domicilio1 ?? ""),
                    new SqlParameter("@domicilio2", domicilio2 ?? ""),
                    new SqlParameter("@colonia", colonia ?? ""),
                    new SqlParameter("@codigoPostal", codigoPostal ?? ""),
                    new SqlParameter("@municipio", municipio ?? ""),
                    new SqlParameter("@estado", estado ?? ""),
                    new SqlParameter("@comentarios", comentarios ?? ""),
                    new SqlParameter("@tieneCredito", tieneCredito)
                };

                return DBConnection.ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un cliente
        /// </summary>
        public static bool Eliminar(int idCliente)
        {
            try
            {
                string query = @"
                    DELETE FROM clientes
                    WHERE id_cliente = @idCliente";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@idCliente", idCliente)
                };

                return DBConnection.ExecuteNonQuery(query, parameters) > 0;
            }
            catch
            {
                return false;
            }
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
