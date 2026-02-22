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
    public partial class Promociones : Form
    {
        private int _idProductoSeleccionado = -1;

        public Promociones()
        {
            InitializeComponent();
        }

        private void Promociones_Load(object sender, EventArgs e)
        {
            try
            {
                CargarPromociones();
                ConfigurarAutoComplete();
                SuscribirEventos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Configura el AutoComplete para el código de barras
        /// </summary>
        private void ConfigurarAutoComplete()
        {
            try
            {
                AutoCompleteStringCollection codigosProductos = new AutoCompleteStringCollection();
                DataTable productos = ProductoDAL.ObtenerTodos();

                foreach (DataRow row in productos.Rows)
                {
                    codigosProductos.Add(row["codigo_barras"].ToString());
                }

                txtCodigoBarras.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtCodigoBarras.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCodigoBarras.AutoCompleteCustomSource = codigosProductos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error configurando AutoComplete: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SuscribirEventos()
        {
            btnNuevaPromocion.Click += BtnNuevaPromocion_Click;
            btnEliminar.Click += BtnEliminar_Click;
            txtCodigoBarras.KeyDown += TxtCodigoBarras_KeyDown;
            txtCodigoBarras.Leave += TxtCodigoBarras_Leave;
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        /// <summary>
        /// Carga todas las promociones vigentes en el DataGridView
        /// </summary>
        private void CargarPromociones()
        {
            try
            {
                dataGridView1.Rows.Clear();
                DataTable dt = PromociónDAL.ObtenerTodas();

                foreach (DataRow row in dt.Rows)
                {
                    dataGridView1.Rows.Add(
                        row["nombre_promocion"],
                        row["codigo_barras"],
                        row["cantidad_desde"],
                        row["cantidad_hasta"],
                        Convert.ToDecimal(row["precio_promocion"]).ToString("F2")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando promociones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                BuscarProducto();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Busca el producto cuando el TextBox pierde el foco
        /// </summary>
        private void TxtCodigoBarras_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCodigoBarras.Text))
            {
                BuscarProducto();
            }
        }

        /// <summary>
        /// Busca un producto por código de barras
        /// </summary>
        private void BuscarProducto()
        {
            try
            {
                string codigo = txtCodigoBarras.Text.Trim();

                if (string.IsNullOrEmpty(codigo))
                {
                    MessageBox.Show("Ingrese un código de barras", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRow producto = ProductoDAL.BuscarPorCodigo(codigo);

                if (producto == null)
                {
                    MessageBox.Show($"Producto con código '{codigo}' no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigoBarras.Clear();
                    txtCodigoBarras.Focus();
                    _idProductoSeleccionado = -1;
                    return;
                }

                // Cargar datos del producto
                _idProductoSeleccionado = Convert.ToInt32(producto["id_producto"]);

                decimal precioCosto = Convert.ToDecimal(producto["precio_compra"]);
                decimal precioVenta = Convert.ToDecimal(producto["precio_venta"]);

                txtPrecioUnitario.Text = precioCosto.ToString("F2");
                lblPrecioNormal.Text = $"${precioVenta.ToString("F2")}";
                lblPrecioCosto.Text = $"${precioCosto.ToString("F2")}";

                // Enfocar en el campo de nombre de promoción
                txtNombrePromocion.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error buscando producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _idProductoSeleccionado = -1;
            }
        }

        private void BtnNuevaPromocion_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(txtNombrePromocion.Text))
                {
                    MessageBox.Show("Ingrese el nombre de la promoción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombrePromocion.Focus();
                    return;
                }

                if (_idProductoSeleccionado == -1)
                {
                    MessageBox.Show("Seleccione un producto (ingrese código de barras)", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtCantidadVaya.Text, out int cantidadDesde) || cantidadDesde <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida para 'Desde'", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(CantidadHasta.Text, out int cantidadHasta) || cantidadHasta <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida para 'Hasta'", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cantidadDesde > cantidadHasta)
                {
                    MessageBox.Show("La cantidad 'Desde' debe ser menor o igual a 'Hasta'", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPrecioUnitario.Text, out decimal precioPromocion) || precioPromocion <= 0)
                {
                    MessageBox.Show("Ingrese un precio válido para la promoción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear promoción
                bool exito = PromociónDAL.Crear(
                    txtNombrePromocion.Text.Trim(),
                    _idProductoSeleccionado,
                    cantidadDesde,
                    cantidadHasta,
                    precioPromocion
                );

                if (exito)
                {
                    MessageBox.Show("Promoción creada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarPromociones();
                }
                else
                {
                    MessageBox.Show("Error al crear la promoción. Verifique que no exista una promoción superpuesta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creando promoción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                // Guardar el índice de la fila seleccionada para poder eliminar
                row.Tag = e.RowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una promoción para eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string nombrePromocion = row.Cells[0].Value?.ToString();

                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar la promoción '{nombrePromocion}'?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Obtener la promoción por nombre para eliminarla
                    DataTable promociones = PromociónDAL.ObtenerTodas();
                    DataRow promocionEliminar = null;

                    foreach (DataRow r in promociones.Rows)
                    {
                        if (r["nombre_promocion"].ToString() == nombrePromocion)
                        {
                            promocionEliminar = r;
                            break;
                        }
                    }

                    if (promocionEliminar != null)
                    {
                        int idPromocion = Convert.ToInt32(promocionEliminar["id_promocion"]);
                        bool exito = PromociónDAL.Eliminar(idPromocion);

                        if (exito)
                        {
                            MessageBox.Show("Promoción eliminada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarPromociones();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar la promoción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error eliminando promoción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNombrePromocion.Clear();
            txtCodigoBarras.Clear();
            txtCantidadVaya.Clear();
            CantidadHasta.Clear();
            txtPrecioUnitario.Clear();
            lblPrecioNormal.Text = "$0.00";
            lblPrecioCosto.Text = "$0.00";
            _idProductoSeleccionado = -1;
            txtNombrePromocion.Focus();
        }
    }
}
