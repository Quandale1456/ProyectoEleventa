using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Suscribir eventos
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnAcceder.Click += new System.EventHandler(this.btnAcceder_Click);
            this.txtPassword.KeyPress += new KeyPressEventHandler(this.txtPassword_KeyPress);

            // Cargar los usuarios en el ComboBox
            CargarUsuarios();

            // Enfocar el ComboBox
            this.cmbUsuario.Focus();
        }

        /// <summary>
        /// Carga los usuarios desde la base de datos en el ComboBox
        /// </summary>
        private void CargarUsuarios()
        {
            try
            {
                string query = "SELECT id_usuario, usuario FROM usuarios WHERE estado = 1 ORDER BY usuario";
                DataTable dtUsuarios = DBConnection.ExecuteQuery(query);

                if (dtUsuarios != null && dtUsuarios.Rows.Count > 0)
                {
                    this.cmbUsuario.DataSource = dtUsuarios;
                    this.cmbUsuario.DisplayMember = "usuario";
                    this.cmbUsuario.ValueMember = "id_usuario";
                }
                else
                {
                    MessageBox.Show("No hay usuarios disponibles en el sistema.", 
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Valida las credenciales del usuario contra la base de datos
        /// </summary>
        private bool ValidarCredenciales(string usuario, string password)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM usuarios WHERE usuario = @usuario AND password = @password AND estado = 1";
                
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@usuario", usuario),
                    new SqlParameter("@password", password)
                };

                object resultado = DBConnection.ExecuteScalar(query, parameters);

                return resultado != null && Convert.ToInt32(resultado) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar credenciales: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Evento del botón Acceder - Valida credenciales y abre el formulario principal
        /// </summary>
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            Acceder();
        }

        /// <summary>
        /// Método general para acceder al sistema
        /// </summary>
        private void Acceder()
        {
            try
            {
                // Validar que se seleccionó un usuario
                if (this.cmbUsuario.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor selecciona un usuario.", 
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cmbUsuario.Focus();
                    return;
                }

                // Validar que se ingresó contraseña
                if (string.IsNullOrWhiteSpace(this.txtPassword.Text))
                {
                    MessageBox.Show("Por favor ingresa la contraseña.", 
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtPassword.Focus();
                    return;
                }

                // Obtener el usuario y contraseña ingresados
                string usuario = this.cmbUsuario.Text;
                string password = this.txtPassword.Text;

                // Validar credenciales
                if (ValidarCredenciales(usuario, password))
                {
                    // Credenciales correctas - Abrir formulario principal
                    Form1 formPrincipal = new Form1();
                    formPrincipal.Show();
                    this.Hide();


                    // Cerrar el formulario de login
                    this.Hide();
                    this.Close();
                }
                else
                {
                    // Credenciales incorrectas
                    MessageBox.Show("Usuario o contraseña incorrectos. Intenta de nuevo.", 
                        "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtPassword.Clear();
                    this.txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al acceder: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Permite presionar Enter en el TextBox de contraseña para acceder
        /// </summary>
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // 13 es el código ASCII de Enter
            {
                e.Handled = true;
                Acceder();
            }
        }

        /// <summary>
        /// Evento del botón Salir - Cierra la aplicación
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Evento del botón Cerrar - Cierra la aplicación
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
