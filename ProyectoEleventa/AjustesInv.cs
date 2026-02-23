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
    public partial class AjustesInv : Form
    {
        // Variable para guardar el ID y datos del producto actual
        private int _idProductoActual = -1;
        private string _codigoProductoActual = "";
        private bool _actualizando = false;

        public AjustesInv()
        {
            InitializeComponent();
        }

        private void AjustesInv_Load(object sender, EventArgs e)
        {
            // Suscribir al evento KeyDown del txtCodigoProducto
            txtCodigoProducto.KeyDown += new KeyEventHandler(this.txtCodigoProducto_KeyDown);

            // Suscribir al evento Click del botón Realizar Ajuste
            btnRealizarAjuste.Click += new EventHandler(this.btnRealizarAjuste_Click);

            // Suscribir a eventos TextChanged para recalcular precio
            txtPrecioCosto.TextChanged += new EventHandler(this.RecalcularPrecioVenta);
            txtPorcentajeDeGanancia.TextChanged += new EventHandler(this.RecalcularPrecioVenta);

            // Inicialmente el panel está deshabilitado
            panelProducto.Enabled = false;
        }

        /// <summary>
        /// Evento KeyDown para detectar cuando se presiona Enter en txtCodigoProducto
        /// </summary>
        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true;

                string codigo = txtCodigoProducto.Text.Trim();

                if (string.IsNullOrEmpty(codigo))
                {
                    MessageBox.Show("Por favor, ingrese un código de producto.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    panelProducto.Enabled = false;
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
                    // Guardar el ID del producto
                    _idProductoActual = Convert.ToInt32(producto["id_producto"]);
                    _codigoProductoActual = codigo;

                    // Establecer bandera para no disparar eventos durante la carga
                    _actualizando = true;

                    // Cargar los datos en los controles
                    txtDescripcion.Text = producto["nombre"].ToString();
                    txtStock.Text = Convert.ToDecimal(producto["existencia"]).ToString("F2");
                    txtPrecioCosto.Text = Convert.ToDecimal(producto["precio_compra"]).ToString("F2");
                    txtPorcentajeDeGanancia.Text = Convert.ToDecimal(producto["porcentaje_ganancia"]).ToString("F2");
                    txtPrecioVenta.Text = Convert.ToDecimal(producto["precio_venta"]).ToString("F2");

                    // Limpiar campos de ajuste
                    txtMasOMenos.Clear();
                    txtMotivo.Clear();
                    txtNuevaCantidad.Clear();

                    // Permitir edición
                    _actualizando = false;
                    panelProducto.Enabled = true;

                    // Enfocar en el campo de ajuste
                    txtMasOMenos.Focus();
                }
                else
                {
                    // Producto no encontrado
                    MessageBox.Show("El producto con código '" + codigo + "' no fue encontrado en la base de datos.",
                        "Producto no existe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos
                    LimpiarFormulario();
                    panelProducto.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el producto: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelProducto.Enabled = false;
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
                // No recalcular si estamos cargando datos
                if (_actualizando)
                    return;

                // Validar que tengamos valores válidos
                if (decimal.TryParse(txtPrecioCosto.Text, out decimal precioCosto) &&
                    decimal.TryParse(txtPorcentajeDeGanancia.Text, out decimal porcentajeGanancia))
                {
                    // Aplicar la fórmula
                    decimal precioVenta = precioCosto + (precioCosto * porcentajeGanancia / 100);

                    // Actualizar el campo de precio venta
                    _actualizando = true;
                    txtPrecioVenta.Text = precioVenta.ToString("F2");
                    _actualizando = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al recalcular precio: " + ex.Message);
            }
        }

        /// <summary>
        /// Realiza el ajuste de inventario cuando se hace clic en el botón
        /// Suma o resta la cantidad indicada en txtMasOMenos al inventario actual
        /// </summary>
        private void btnRealizarAjuste_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que haya producto seleccionado
                if (_idProductoActual == -1)
                {
                    MessageBox.Show("Por favor, busque un producto primero.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que haya cantidad a ajustar
                if (string.IsNullOrWhiteSpace(txtMasOMenos.Text))
                {
                    MessageBox.Show("Por favor, ingrese la cantidad a ajustar (+/-)", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMasOMenos.Focus();
                    return;
                }

                // Validar que sea un número válido
                if (!decimal.TryParse(txtMasOMenos.Text, out decimal cantidadAjuste))
                {
                    MessageBox.Show("La cantidad debe ser un número válido.", "Error de Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMasOMenos.Focus();
                    return;
                }

                // Obtener el stock actual
                if (!decimal.TryParse(txtStock.Text, out decimal stockActual))
                {
                    MessageBox.Show("El stock actual no es válido.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calcular el nuevo stock
                decimal nuevoStock = stockActual + cantidadAjuste;

                // Validar que el nuevo stock no sea negativo
                if (nuevoStock < 0)
                {
                    MessageBox.Show($"El ajuste haría que el stock sea negativo. Stock actual: {stockActual}, Ajuste: {cantidadAjuste}",
                        "Ajuste Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mostrar confirmación
                DialogResult resultado = MessageBox.Show(
                    $"¿Desea ajustar el inventario del producto '{txtDescripcion.Text}'?\n\n" +
                    $"Stock Actual: {stockActual}\n" +
                    $"Ajuste: {(cantidadAjuste > 0 ? "+" : "")}{cantidadAjuste}\n" +
                    $"Nuevo Stock: {nuevoStock}\n" +
                    $"Motivo: {txtMotivo.Text}",
                    "Confirmación de Ajuste",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Actualizar en la BD
                    bool actualizado = ProductoDAL.ActualizarProducto(
                        _idProductoActual,
                        _codigoProductoActual,
                        txtDescripcion.Text.Trim(),
                        decimal.Parse(txtPrecioCosto.Text),
                        decimal.Parse(txtPorcentajeDeGanancia.Text),
                        decimal.Parse(txtPrecioVenta.Text),
                        nuevoStock,
                        0  // departamento
                    );

                    if (actualizado)
                    {
                        // Actualizar el campo de stock visualmente
                        _actualizando = true;
                        txtStock.Text = nuevoStock.ToString("F2");
                        txtNuevaCantidad.Text = nuevoStock.ToString("F2");
                        _actualizando = false;

                        // Limpiar campos de ajuste
                        txtMasOMenos.Clear();
                        txtMotivo.Clear();

                        // Mostrar confirmación
                        MessageBox.Show($"✅ Ajuste realizado exitosamente.\nNuevo stock: {nuevoStock}",
                            "Ajuste Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Enfocar de nuevo en el campo de ajuste
                        txtMasOMenos.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el producto en la base de datos.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el ajuste: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Limpia todos los campos del formulario
        /// </summary>
        private void LimpiarFormulario()
        {
            _actualizando = true;

            txtCodigoProducto.Clear();
            txtDescripcion.Clear();
            txtStock.Clear();
            txtPrecioCosto.Clear();
            txtPorcentajeDeGanancia.Clear();
            txtPrecioVenta.Clear();
            txtMasOMenos.Clear();
            txtMotivo.Clear();
            txtNuevaCantidad.Clear();

            _idProductoActual = -1;
            _codigoProductoActual = "";

            _actualizando = false;
        }
    }
}
