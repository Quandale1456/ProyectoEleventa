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

            Load += BusquedaProductos_Load;
            textBox1.TextChanged += TextBusqueda_TextChanged;
            dataGridView1.DoubleClick += DataGridView_DoubleClick;
            button5.Click += BtnAceptar_Click;
            button4.Click += BtnCancelar_Click;

            KeyPreview = true;
            KeyDown += BusquedaProductos_KeyDown;
        }

        private void BusquedaProductos_Load(object sender, EventArgs e)
        {
            // Cargar todos los productos al abrir
            CargarProductos("");

            // Enfocar en el TextBox de búsqueda
            textBox1.Focus();
        }

        /// <summary>
        /// Carga los productos en el DataGridView según el filtro.
        /// </summary>
        private void CargarProductos(string filtro)
        {
            DataTable dt;
            if (string.IsNullOrWhiteSpace(filtro))
            {
                dt = ProductoDAL.ObtenerTodos();
            }
            else
            {
                dt = ProductoDAL.BuscarPorNombre(filtro);
            }

            ConfigurarGridSiHaceFalta();
            dataGridView1.DataSource = dt;
        }

        private void ConfigurarGridSiHaceFalta()
        {
            if (dataGridView1.Columns.Count > 0 && dataGridView1.Columns[0].DataPropertyName == "id_producto")
            {
                return;
            }

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            var colId = new DataGridViewTextBoxColumn
            {
                Name = "colIdProducto",
                HeaderText = "ID",
                DataPropertyName = "id_producto",
                Width = 60,
                Visible = false
            };

            var colNombre = new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                HeaderText = "Descripción del Producto",
                DataPropertyName = "nombre",
                Width = 280
            };

            var colPrecio = new DataGridViewTextBoxColumn
            {
                Name = "colPrecioVenta",
                HeaderText = "Precio Venta",
                DataPropertyName = "precio_venta",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            };

            var colDepartamento = new DataGridViewTextBoxColumn
            {
                Name = "colDepartamento",
                HeaderText = "Departamento",
                DataPropertyName = "departamento",
                Width = 200
            };

            var colInventario = new DataGridViewTextBoxColumn
            {
                Name = "colInventario",
                HeaderText = "Inventario",
                DataPropertyName = "existencia",
                Width = 100
            };

            var colCodigo = new DataGridViewTextBoxColumn
            {
                Name = "colCodigoBarras",
                HeaderText = "Código",
                DataPropertyName = "codigo_barras",
                Width = 120,
                Visible = false
            };

            dataGridView1.Columns.AddRange(new DataGridViewColumn[]
            {
                colId,
                colNombre,
                colPrecio,
                colDepartamento,
                colInventario,
                colCodigo
            });
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
            AceptarSeleccionActual();
        }

        /// <summary>
        /// Evento del botón Aceptar.
        /// </summary>
        public void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (!AceptarSeleccionActual())
                MessageBox.Show("Seleccione un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Evento del botón Cancelar.
        /// </summary>
        public void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool AceptarSeleccionActual()
        {
            if (dataGridView1.CurrentRow == null)
                return false;

            object idVal = dataGridView1.CurrentRow.Cells["colIdProducto"].Value;
            object nombreVal = dataGridView1.CurrentRow.Cells["colNombre"].Value;
            if (idVal == null || nombreVal == null)
                return false;

            IdProductoSeleccionado = Convert.ToInt32(idVal);
            NombreProductoSeleccionado = nombreVal.ToString();

            DialogResult = DialogResult.OK;
            Close();
            return true;
        }

        private void BusquedaProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                BtnCancelar_Click(this, EventArgs.Empty);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (AceptarSeleccionActual())
                {
                    e.Handled = true;
                }
            }
        }
    }
}
