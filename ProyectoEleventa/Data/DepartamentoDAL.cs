using System;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoEleventa.Data
{
    public static class DepartamentoDAL
    {
        /// <summary>
        /// Crea un nuevo departamento en la base de datos
        /// </summary>
        public static bool CrearDepartamento(string nombre)
        {
            try
            {
                // Validar que el nombre no esté vacío
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    return false;
                }

                // Validar que el departamento no exista
                if (DepartamentoExiste(nombre))
                {
                    return false;
                }

                string query = @"
                    INSERT INTO departamentos (nombre, estado)
                    VALUES (@nombre, 1)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@nombre", nombre.Trim())
                };

                int resultado = DBConnection.ExecuteNonQuery(query, parameters);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error al crear departamento: {ex.Message}", 
                    "Error", System.Windows.Forms.MessageBoxButtons.OK, 
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Obtiene todos los departamentos activos
        /// </summary>
        public static DataTable ObtenerTodos()
        {
            try
            {
                string query = @"
                    SELECT id_departamento, nombre
                    FROM departamentos
                    WHERE estado = 1
                    ORDER BY nombre";

                return DBConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error al obtener departamentos: {ex.Message}", 
                    "Error", System.Windows.Forms.MessageBoxButtons.OK, 
                    System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Verifica si un departamento ya existe
        /// </summary>
        public static bool DepartamentoExiste(string nombre)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) FROM departamentos 
                    WHERE nombre = @nombre AND estado = 1";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@nombre", nombre.Trim())
                };

                int count = (int)DBConnection.ExecuteScalar(query, parameters);
                return count > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un departamento (cambiar estado a 0)
        /// </summary>
        public static bool EliminarDepartamento(int idDepartamento)
        {
            try
            {
                string query = @"
                    UPDATE departamentos
                    SET estado = 0
                    WHERE id_departamento = @id";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", idDepartamento)
                };

                int resultado = DBConnection.ExecuteNonQuery(query, parameters);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error al eliminar departamento: {ex.Message}", 
                    "Error", System.Windows.Forms.MessageBoxButtons.OK, 
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Obtiene un departamento por ID
        /// </summary>
        public static DataRow ObtenerPorId(int idDepartamento)
        {
            try
            {
                string query = @"
                    SELECT id_departamento, nombre
                    FROM departamentos
                    WHERE id_departamento = @id AND estado = 1";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", idDepartamento)
                };

                DataTable dt = DBConnection.ExecuteQuery(query, parameters);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Busca departamentos por nombre (parcial)
        /// </summary>
        public static DataTable BuscarPorNombre(string nombre)
        {
            try
            {
                string query = @"
                    SELECT id_departamento, nombre
                    FROM departamentos
                    WHERE nombre LIKE @nombre AND estado = 1
                    ORDER BY nombre";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@nombre", "%" + nombre + "%")
                };

                return DBConnection.ExecuteQuery(query, parameters);
            }
            catch
            {
                return null;
            }
        }
    }
}
