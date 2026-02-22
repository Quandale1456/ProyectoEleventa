using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    public partial class Clientes : Form
    {
        private int _idClienteSeleccionado = -1;

        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarDataGridView();
                CargarClientes();
                SuscribirEventos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Configura las columnas del DataGridView
        /// </summary>
        private void ConfigurarDataGridView()
        {
            listBoxClientes.Visible = false;

            if (!panelClientes.Controls.OfType<DataGridView>().Any())
            {
                DataGridView dgv = new DataGridView();
                dgv.Name = "dataGridViewClientes";
                dgv.Location = new System.Drawing.Point(3, 38);
                dgv.Size = new System.Drawing.Size(455, 600);
                dgv.AllowUserToAddRows = false;
                dgv.ReadOnly = true;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.MultiSelect = false;
                dgv.BackgroundColor = System.Drawing.Color.White;
                dgv.BorderStyle = BorderStyle.Fixed3D;
                dgv.RowHeadersVisible = true;

                // Columnas
                dgv.Columns.Add("id_cliente", "ID");
                dgv.Columns.Add("nombre", "Nombre");
                dgv.Columns.Add("apellido", "Apellido");
                dgv.Columns.Add("telefono", "Teléfono");
                dgv.Columns.Add("municipio", "Municipio");
                dgv.Columns.Add("estado", "Estado");
                dgv.Columns.Add("tiene_credito", "Crédito");

                // Ancho de columnas
                dgv.Columns[0].Width = 40;
                dgv.Columns[1].Width = 70;
                dgv.Columns[2].Width = 70;
                dgv.Columns[3].Width = 85;
                dgv.Columns[4].Width = 80;
                dgv.Columns[5].Width = 70;
                dgv.Columns[6].Width = 50;

                dgv.CellClick += DataGridViewClientes_CellClick;

                var panel4 = panelClientes.Controls["panel4"];
                if (panel4 != null)
                {
                    panel4.Controls.Add(dgv);
                }
            }
        }

        /// <summary>
        /// Carga todos los clientes en el DataGridView
        /// </summary>
        private void CargarClientes()
        {
            try
            {
                DataGridView dgv = panelClientes.Controls["panel4"]?.Controls["dataGridViewClientes"] as DataGridView;
                if (dgv == null) return;

                dgv.Rows.Clear();
                DataTable dt = ClienteDAL.ObtenerTodos();

                foreach (DataRow row in dt.Rows)
                {
                    dgv.Rows.Add(
                        row["id_cliente"],
                        row["nombre"],
                        row["apellidos"],
                        row["telefono"] ?? "",
                        row["municipio"] ?? "",
                        row["estado"] ?? "",
                        Convert.ToBoolean(row["tiene_credito_autorizado"]) ? "Sí" : "No"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Suscribe eventos a los botones
        /// </summary>
        private void SuscribirEventos()
        {
            button9.Click += (s, e) => NuevoCliente();
            btnGuardar.Click += (s, e) => GuardarCliente();
            btnEliminar.Click += (s, e) => EliminarCliente();
            txtBuscar.TextChanged += (s, e) => BuscarClientes();
        }

        /// <summary>
        /// DataGridView - Seleccionar cliente
        /// </summary>
        private void DataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                if (e.RowIndex < 0 || e.RowIndex >= dgv.Rows.Count) return;

                DataGridViewRow row = dgv.Rows[e.RowIndex];
                _idClienteSeleccionado = Convert.ToInt32(row.Cells[0].Value);

                CargarDatosCliente(_idClienteSeleccionado);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error seleccionando cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga los datos del cliente en los textbox
        /// </summary>
        private void CargarDatosCliente(int idCliente)
        {
            try
            {
                DataRow cliente = ClienteDAL.ObtenerPorId(idCliente);
                if (cliente == null) return;

                txtNombre.Text = cliente["nombre"].ToString();
                txtApellido.Text = cliente["apellidos"].ToString();
                txtTelefono.Text = cliente["telefono"]?.ToString() ?? "";
                txtDomicilio1.Text = cliente["domicilio1"]?.ToString() ?? "";
                txtDomicilio2.Text = cliente["domicilio2"]?.ToString() ?? "";
                txtColonia.Text = cliente["colonia"]?.ToString() ?? "";
                txtCodigoPostal.Text = cliente["codigo_postal"]?.ToString() ?? "";
                comboMunicipio.Text = cliente["municipio"]?.ToString() ?? "";
                comboEstado.Text = cliente["estado"]?.ToString() ?? "";
                txtComentarios.Text = cliente["notas"]?.ToString() ?? "";
                checkBox5.Checked = Convert.ToBoolean(cliente["tiene_credito_autorizado"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nuevo cliente - Limpiar campos
        /// </summary>
        private void NuevoCliente()
        {
            _idClienteSeleccionado = -1;
            LimpiarCampos();
            txtNombre.Focus();
        }

        /// <summary>
        /// Guardar cliente
        /// </summary>
        private void GuardarCliente()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Ingrese el nombre del cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string domicilio1 = txtDomicilio1.Text.Trim();
                string domicilio2 = txtDomicilio2.Text.Trim();
                string colonia = txtColonia.Text.Trim();
                string codigoPostal = txtCodigoPostal.Text.Trim();
                string municipio = comboMunicipio.Text;
                string estado = comboEstado.Text;
                string comentarios = txtComentarios.Text.Trim();
                bool tieneCredito = checkBox5.Checked;

                if (_idClienteSeleccionado == -1)
                {
                    // Nuevo cliente
                    bool exito = ClienteDAL.Crear(nombre, apellido, telefono, domicilio1, 
                        domicilio2, colonia, codigoPostal, municipio, estado, comentarios, tieneCredito);

                    if (exito)
                    {
                        MessageBox.Show("Cliente creado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientes();
                        NuevoCliente();
                    }
                }
                else
                {
                    // Actualizar cliente
                    bool exito = ClienteDAL.Actualizar(_idClienteSeleccionado, nombre, apellido, telefono, 
                        domicilio1, domicilio2, colonia, codigoPostal, municipio, estado, comentarios, tieneCredito);

                    if (exito)
                    {
                        MessageBox.Show("Cliente actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientes();
                        NuevoCliente();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error guardando cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Eliminar cliente
        /// </summary>
        private void EliminarCliente()
        {
            try
            {
                if (_idClienteSeleccionado == -1)
                {
                    MessageBox.Show("Seleccione un cliente para eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", 
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    bool exito = ClienteDAL.Eliminar(_idClienteSeleccionado);
                    if (exito)
                    {
                        MessageBox.Show("Cliente eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientes();
                        NuevoCliente();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error eliminando cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Buscar clientes
        /// </summary>
        private void BuscarClientes()
        {
            try
            {
                string busqueda = txtBuscar.Text.Trim();
                DataGridView dgv = panelClientes.Controls["panel4"]?.Controls["dataGridViewClientes"] as DataGridView;
                if (dgv == null) return;

                if (string.IsNullOrEmpty(busqueda))
                {
                    CargarClientes();
                    return;
                }

                dgv.Rows.Clear();
                DataTable dt = ClienteDAL.Buscar(busqueda);

                foreach (DataRow row in dt.Rows)
                {
                    dgv.Rows.Add(
                        row["id_cliente"],
                        row["nombre"],
                        row["apellidos"],
                        row["telefono"] ?? "",
                        row["municipio"] ?? "",
                        row["estado"] ?? "",
                        Convert.ToBoolean(row["tiene_credito_autorizado"]) ? "Sí" : "No"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error buscando clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Limpiar campos
        /// </summary>
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtDomicilio1.Clear();
            txtDomicilio2.Clear();
            txtColonia.Clear();
            txtCodigoPostal.Clear();
            comboMunicipio.SelectedIndex = -1;
            comboEstado.SelectedIndex = -1;
            txtComentarios.Clear();
            checkBox5.Checked = false;
        }
    }
}
