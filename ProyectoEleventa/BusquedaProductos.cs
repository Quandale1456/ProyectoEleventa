using System;
using System.Data;
using System.Windows.Forms;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    /// <summary>
    /// Formulario para búsqueda y selección de productos.
    /// Permite buscar por nombre y devolver el producto seleccionado.
    /// </summary>
    public partial class BusquedaProductos : Form
    {
        public int IdProductoSeleccionado { get; set; }
        public string NombreProductoSeleccionado { get; set; }

        public BusquedaProductos()
        {
            InitializeComponent();
            IdProductoSeleccionado = -1;
            NombreProductoSeleccionado = "";
        }

        private void BusquedaProductos_Load(object sender, EventArgs e)
        {
            // Cargar todos los productos al abrir
            CargarProductos("");

            // Enfocar en el TextBox de búsqueda
            if (Controls["textBusqueda"] != null)
                Controls["textBusqueda"].Focus();
        }

        /// <summary>
        /// Carga los productos en el DataGridView según el filtro.
        /// </summary>
        private void CargarProductos(string filtro)
        {
            DataGridView dgv = null;

            // Buscar el DataGridView en los controles del formulario
            foreach (Control control in Controls)
            {
                if (control is DataGridView)
                {
                    dgv = (DataGridView)control;
                    break;
                }
            }

            if (dgv == null) return;

            DataTable dt;
            if (string.IsNullOrWhiteSpace(filtro))
            {
                dt = ProductoDAL.ObtenerTodos();
            }
            else
            {
                dt = ProductoDAL.BuscarPorNombre(filtro);
            }

            dgv.DataSource = dt;

            // Configurar columnas si es necesario
            if (dgv.Columns.Count > 0)
            {
                dgv.Columns[0].HeaderText = "ID";
                dgv.Columns[0].Width = 50;
                dgv.Columns[1].HeaderText = "Nombre";
                dgv.Columns[1].Width = 200;
                dgv.Columns[2].HeaderText = "Código";
                dgv.Columns[2].Width = 100;
                dgv.Columns[3].HeaderText = "Precio";
                dgv.Columns[3].Width = 80;
                dgv.Columns[4].HeaderText = "Existencia";
                dgv.Columns[4].Width = 80;
            }
        }

        /// <summary>
        /// Evento cuando el usuario escribe en el cuadro de búsqueda.
        /// </summary>
        public void TextBusqueda_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                CargarProductos(txt.Text);
            }
        }

        /// <summary>
        /// Evento cuando el usuario hace doble clic en una fila.
        /// </summary>
        public void DataGridView_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                int idProducto = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
                string nombreProducto = dgv.SelectedRows[0].Cells[1].Value.ToString();

                IdProductoSeleccionado = idProducto;
                NombreProductoSeleccionado = nombreProducto;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Evento del botón Aceptar.
        /// </summary>
        public void BtnAceptar_Click(object sender, EventArgs e)
        {
            DataGridView dgv = null;
            foreach (Control control in Controls)
            {
                if (control is DataGridView)
                {
                    dgv = (DataGridView)control;
                    break;
                }
            }

            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                int idProducto = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
                string nombreProducto = dgv.SelectedRows[0].Cells[1].Value.ToString();

                IdProductoSeleccionado = idProducto;
                NombreProductoSeleccionado = nombreProducto;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Evento del botón Cancelar.
        /// </summary>
        public void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
