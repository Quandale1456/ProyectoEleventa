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
    public partial class FormularioDeInventario : Form
    {
        // Variable para guardar el ID del producto actual
        private int _idProductoActual = -1;
        // Bandera para evitar actualización recursiva
        private bool _actualizando = false;
        // Variable para manejar formularios hijo
        private Form _activeForm = null;

        public FormularioDeInventario()
        {
            InitializeComponent();
        }

        private void FormularioDeInventario_Load(object sender, EventArgs e)
        {

            this.btnAjustes.Click += new System.EventHandler(this.btnAjustes_Click);
            // Suscribir al evento Click del botón Agregar para cerrar AjustesInv
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // Ocultar el panel al cargar el formulario
            panelProducto.Visible = false;

            // Suscribir al evento KeyDown del txtCodigoProducto
            txtCodigoProducto.KeyDown += new KeyEventHandler(this.txtCodigoProducto_KeyDown);

            // Suscribir a los eventos TextChanged para recalcular precio
            txtPrecioCosto.TextChanged += new EventHandler(this.RecalcularPrecioVenta);
            txtPorcentajeDeGanancia.TextChanged += new EventHandler(this.RecalcularPrecioVenta);

            // Suscribir a eventos TextChanged para actualizar automáticamente
            txtDescripcion.TextChanged += new EventHandler(this.ActualizarProducto);
            txtStock.TextChanged += new EventHandler(this.ActualizarProducto);
            txtPrecioCosto.TextChanged += new EventHandler(this.ActualizarProducto);
            txtPorcentajeDeGanancia.TextChanged += new EventHandler(this.ActualizarProducto);
            txtPrecioVenta.TextChanged += new EventHandler(this.ActualizarProducto);

            // Hacer los campos de precio de venta y ganancia solo lectura si es necesario
            txtPrecioVenta.ReadOnly = false;
        }

       

        /// <summary>
        /// Evento KeyDown para detectar cuando se presiona Enter en txtCodigoProducto
        /// </summary>
        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true; // Prevenir el sonido del beep

                string codigo = txtCodigoProducto.Text.Trim();

                if (string.IsNullOrEmpty(codigo))
                {
                    MessageBox.Show("Por favor, ingrese un código de producto.", "Validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    panelProducto.Visible = false;
                    return;
                }

                // Buscar el producto
                BuscarProducto(codigo);
            }
        }

        /// <summary>
        /// Busca un producto en la base de datos por código
        /// </summary>
        private void BuscarProducto(string codigo)
        {
            try
            {
                // Usar el DAL existente para buscar
                DataRow producto = ProductoDAL.BuscarPorCodigo(codigo);

                if (producto != null)
                {
                    // Guardar el ID del producto para actualizaciones posteriores
                    _idProductoActual = Convert.ToInt32(producto["id_producto"]);

                    // Establecer la bandera para que no actualice mientras cargamos datos
                    _actualizando = true;

                    // Cargar los datos en los controles
                    txtDescripcion.Text = producto["nombre"].ToString();
                    txtStock.Text = producto["existencia"].ToString();
                    txtPrecioCosto.Text = Convert.ToDecimal(producto["precio_compra"]).ToString("F2");
                    txtPorcentajeDeGanancia.Text = Convert.ToDecimal(producto["porcentaje_ganancia"]).ToString("F2");
                    txtPrecioVenta.Text = Convert.ToDecimal(producto["precio_venta"]).ToString("F2");
                    txtAgregar.Clear();

                    // Permitir actualizaciones nuevamente
                    _actualizando = false;

                    // Mostrar el panel
                    panelProducto.Visible = true;
                }
                else
                {
                    // Producto no encontrado
                    MessageBox.Show("El producto con código '" + codigo + "' no fue encontrado en la base de datos.", 
                        "Producto no existe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos
                    LimpiarPanel();
                    panelProducto.Visible = false;
                    _idProductoActual = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el producto: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelProducto.Visible = false;
                _idProductoActual = -1;
            }
        }

        /// <summary>
        /// Recalcula el precio de venta basado en precio de costo y porcentaje de ganancia
        /// Fórmula: PrecioVenta = PrecioCosto + (PrecioCosto * PorcentajeGanancia / 100)
        /// </summary>
        private void RecalcularPrecioVenta(object sender, EventArgs e)
        {
            try
            {
                // Solo recalcular si no estamos cargando datos
                if (_actualizando)
                    return;

                // Validar que tengamos valores válidos
                if (decimal.TryParse(txtPrecioCosto.Text, out decimal precioCosto) &&
                    decimal.TryParse(txtPorcentajeDeGanancia.Text, out decimal porcentajeGanancia))
                {
                    // Aplicar la fórmula
                    decimal precioVenta = precioCosto + (precioCosto * porcentajeGanancia / 100);

                    // Actualizar el campo de precio venta sin disparar el evento recursivamente
                    _actualizando = true;
                    txtPrecioVenta.Text = precioVenta.ToString("F2");
                    _actualizando = false;
                }
            }
            catch (Exception ex)
            {
                // Si hay error, simplemente no actualizar
                System.Diagnostics.Debug.WriteLine("Error al recalcular precio: " + ex.Message);
            }
        }

        /// <summary>
        /// Limpia todos los campos del panel
        /// </summary>
        private void LimpiarPanel()
        {
            txtDescripcion.Clear();
            txtStock.Clear();
            txtPrecioCosto.Clear();
            txtPorcentajeDeGanancia.Clear();
            txtPrecioVenta.Clear();
            txtAgregar.Clear();
            _idProductoActual = -1;
        }

        /// <summary>
        /// Actualiza el producto en la base de datos cuando cambian los valores
        /// Se ejecuta automáticamente al cambiar cualquier campo
        /// </summary>
        private void ActualizarProducto(object sender, EventArgs e)
        {
            try
            {
                // No actualizar si estamos cargando datos o si no hay producto seleccionado
                if (_actualizando || _idProductoActual == -1 || !panelProducto.Visible)
                    return;

                // Validar que todos los campos tengan valores válidos
                if (!ValidarCampos())
                    return;

                // Obtener los valores actuales
                string nombre = txtDescripcion.Text.Trim();
                decimal existencia = decimal.Parse(txtStock.Text);
                decimal precioCosto = decimal.Parse(txtPrecioCosto.Text);
                decimal porcentajeGanancia = decimal.Parse(txtPorcentajeDeGanancia.Text);
                decimal precioVenta = decimal.Parse(txtPrecioVenta.Text);

                // Obtener el código del producto (lo guardamos del búsqueda)
                string codigo = txtCodigoProducto.Text.Trim();

                // Actualizar en la BD usando ProductoDAL
                bool actualizado = ProductoDAL.ActualizarProducto(
                    _idProductoActual,
                    codigo,
                    nombre,
                    precioCosto,
                    porcentajeGanancia,
                    precioVenta,
                    existencia,
                    0  // departamento (0 si no aplica)
                );

                if (actualizado)
                {
                    // Mostrar confirmación breve (sin interrumpir)
                    System.Diagnostics.Debug.WriteLine($"✅ Producto actualizado: {nombre}");
                }
                else
                {
                    // Si falla la actualización, mostrar error
                    MessageBox.Show("No se pudo actualizar el producto.", "Error de Actualización",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Ignorar errores de validación silenciosamente (ej: campos vacíos)
                System.Diagnostics.Debug.WriteLine("Error al actualizar: " + ex.Message);
            }
        }

        /// <summary>
        /// Valida que todos los campos tengan valores válidos
        /// </summary>
        private bool ValidarCampos()
        {
            try
            {
                // Validar que no haya campos vacíos
                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                    return false;

                if (string.IsNullOrWhiteSpace(txtStock.Text))
                    return false;

                if (string.IsNullOrWhiteSpace(txtPrecioCosto.Text))
                    return false;

                if (string.IsNullOrWhiteSpace(txtPorcentajeDeGanancia.Text))
                    return false;

                if (string.IsNullOrWhiteSpace(txtPrecioVenta.Text))
                    return false;

                // Validar que sean números
                if (!decimal.TryParse(txtStock.Text, out _))
                    return false;

                if (!decimal.TryParse(txtPrecioCosto.Text, out _))
                    return false;

                if (!decimal.TryParse(txtPorcentajeDeGanancia.Text, out _))
                    return false;

                if (!decimal.TryParse(txtPrecioVenta.Text, out _))
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Abre el formulario de Ajustes de Inventario cuando se hace clic en el botón Ajustes
        /// </summary>
        private void btnAjustes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AjustesInv());
        }

        /// <summary>
        /// Abre un formulario hijo dentro del FormularioDeInventario
        /// Cierra el formulario hijo anterior si existe
        /// </summary>
        private void OpenChildForm(Form childForm)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }
            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelContenido.Controls.Add(childForm);
            this.panelContenido.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnAjustes_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new AjustesInv());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario hijo activo si existe
            if (_activeForm != null)
            {
                _activeForm.Close();
                _activeForm = null;
            }
        }

        private void btnProductoBajos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductosBajoInv());
        }

        private void btnReporteDeInv_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReporteDeInv());
        }

        private void btnReporteDeMovimientos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmReporteMovimientosInventario());
        }
    }
}
