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
using ProyectoEleventa.Models;

namespace ProyectoEleventa
{
    public partial class FormularioProductos : Form
    {
        private Form activeForm = null;
        private int productoActualId = 0;
        private bool editando = false;

        public FormularioProductos()
        {
            InitializeComponent();
        }

        private void FormularioProductos_Load(object sender, EventArgs e)
        {
            // Suscribir eventos de los botones de navegación
            this.button6.Click += new System.EventHandler(this.btnNuevo_Click);
            this.button5.Click += new System.EventHandler(this.btnModificar_Click);
            this.button4.Click += new System.EventHandler(this.btnEliminar_Click);
            this.button3.Click += new System.EventHandler(this.btnDepartamentos_Click);
            this.button2.Click += new System.EventHandler(this.btnVentasPorPeriodo_Click);
            this.button1.Click += new System.EventHandler(this.btnPromociones_Click);

            // Suscribir eventos de los controles del formulario
            this.textBoxPrecioCosto.TextChanged += new System.EventHandler(this.CalcularPrecioVenta_Changed);
            this.numericGanancia.ValueChanged += new System.EventHandler(this.CalcularPrecioVenta_Changed);

            // Evento del checkbox de inventario
            this.checkBoxInventario.CheckedChanged += new System.EventHandler(this.checkBoxInventario_CheckedChanged);

            // Suscribir eventos de botones
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            CargarDepartamentos();
            LimpiarFormulario();
        }

        #region Métodos de Cálculo Automático

        /// <summary>
        /// Calcula automáticamente el precio de venta cuando cambia costo o ganancia.
        /// Fórmula: PrecioVenta = Costo + (Costo * Ganancia / 100)
        /// </summary>
        private void CalcularPrecioVenta_Changed(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.textBoxPrecioCosto.Text))
                    return;

                if (!decimal.TryParse(this.textBoxPrecioCosto.Text, out decimal costo))
                    return;

                if (costo <= 0)
                {
                    this.textBoxPrecioVenta.Text = "0";
                    return;
                }

                decimal ganancia = (decimal)this.numericGanancia.Value;
                decimal precioVenta = costo + (costo * ganancia / 100);

                this.textBoxPrecioVenta.Text = precioVenta.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular precio de venta: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Habilita o deshabilita los campos de inventario según el checkbox.
        /// Si está activado: permite ingresar existencia, mínima y máxima
        /// Si está desactivado: limpia y deshabilita los campos
        /// </summary>
        private void checkBoxInventario_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // Habilitar/deshabilitar campos de inventario
                this.txtExistencia.Enabled = this.checkBoxInventario.Checked;
                this.txtExistenciaMinima.Enabled = this.checkBoxInventario.Checked;
                this.txtExistenciaMaxima.Enabled = this.checkBoxInventario.Checked;

                // Si desactiva, limpiar los campos
                if (!this.checkBoxInventario.Checked)
                {
                    this.txtExistencia.Clear();
                    this.txtExistenciaMinima.Clear();
                    this.txtExistenciaMaxima.Clear();
                }
                else
                {
                    // Si activa, enfocar en el campo de existencia
                    this.txtExistencia.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Métodos CRUD

        /// <summary>
        /// Guarda un producto nuevo o actualiza uno existente.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarFormulario())
                    return;

                Producto producto = ObtenerDatosFormulario();

                if (editando)
                {
                    if (ProductoDAL.ActualizarProducto(
                        productoActualId,
                        producto.CodigoBarras,
                        producto.Nombre,
                        producto.PrecioCosto,
                        producto.PorcentajeGanancia,
                        producto.PrecioVenta,
                        producto.Existencia,
                        producto.DepartamentoId,
                        producto.ExistenciaMinima,
                        producto.ExistenciaMaxima))
                    {
                        MessageBox.Show("Producto actualizado correctamente.", 
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el producto. Verifique que el código no esté duplicado.", 
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (ProductoDAL.CrearProducto(
                        producto.CodigoBarras,
                        producto.Nombre,
                        producto.PrecioCosto,
                        producto.PorcentajeGanancia,
                        producto.PrecioVenta,
                        producto.Existencia,
                        producto.DepartamentoId,
                        producto.ExistenciaMinima,
                        producto.ExistenciaMaxima))
                    {
                        MessageBox.Show("Producto creado correctamente.", 
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el producto. Verifique que el código no esté duplicado.", 
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cancela la edición y limpia el formulario.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        #endregion

        #region Métodos de Validación

        /// <summary>
        /// Valida que los campos requeridos del formulario estén completos.
        /// </summary>
        private bool ValidarFormulario()
        {
            // Código de barras
            if (string.IsNullOrWhiteSpace(this.textBoxCodigo.Text))
            {
                MessageBox.Show("El código de barras es requerido.", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.textBoxCodigo.Focus();
                return false;
            }

            // Nombre
            if (string.IsNullOrWhiteSpace(this.textBoxDescripcion.Text))
            {
                MessageBox.Show("El nombre del producto es requerido.", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.textBoxDescripcion.Focus();
                return false;
            }

            // Costo
            if (!decimal.TryParse(this.textBoxPrecioCosto.Text, out decimal costo) || costo <= 0)
            {
                MessageBox.Show("El precio de costo debe ser mayor a 0.", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.textBoxPrecioCosto.Focus();
                return false;
            }

            // Ganancia
            decimal ganancia = (decimal)this.numericGanancia.Value;
            if (ganancia < 0)
            {
                MessageBox.Show("El porcentaje de ganancia no puede ser negativo.", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.numericGanancia.Focus();
                return false;
            }

            // Precio Venta
            if (!decimal.TryParse(this.textBoxPrecioVenta.Text, out decimal precioVenta) || precioVenta <= 0)
            {
                MessageBox.Show("El precio de venta debe ser mayor a 0.", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.textBoxPrecioVenta.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Métodos Auxiliares

        /// <summary>
        /// Carga los departamentos desde la base de datos en el combo.
        /// </summary>
        private void CargarDepartamentos()
        {
            try
            {
                // TODO: Implementar carga de departamentos si existe tabla
                // Por ahora solo limpiar el combo
                this.comboDepartamento.DataSource = null;
                this.comboDepartamento.Items.Clear();
                this.comboDepartamento.Items.Add("Sin categoría");
                this.comboDepartamento.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar departamentos: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Obtiene los datos del formulario como objeto Producto.
        /// </summary>
        private Producto ObtenerDatosFormulario()
        {
            Producto producto = new Producto
            {
                IdProducto = productoActualId,
                CodigoBarras = this.textBoxCodigo.Text.Trim(),
                Nombre = this.textBoxDescripcion.Text.Trim(),
                PrecioCosto = decimal.Parse(this.textBoxPrecioCosto.Text),
                PorcentajeGanancia = (decimal)this.numericGanancia.Value,
                PrecioVenta = decimal.Parse(this.textBoxPrecioVenta.Text),
                Existencia = decimal.TryParse(this.txtExistencia.Text, out decimal existencia) ? existencia : 0,
                DepartamentoId = 0,
                UsaInventario = this.checkBoxInventario.Checked,
                ExistenciaMinima = decimal.TryParse(this.txtExistenciaMinima.Text, out decimal minima) ? minima : 0,
                ExistenciaMaxima = decimal.TryParse(this.txtExistenciaMaxima.Text, out decimal maxima) ? maxima : 0
            };

            return producto;
        }

        /// <summary>
        /// Limpia el formulario y lo prepara para un nuevo producto.
        /// </summary>
        private void LimpiarFormulario()
        {
            productoActualId = 0;
            editando = false;
            this.textBoxCodigo.Clear();
            this.textBoxCodigo.ReadOnly = false;
            this.textBoxDescripcion.Clear();
            this.textBoxPrecioCosto.Clear();
            this.numericGanancia.Value = 20;
            this.textBoxPrecioVenta.Clear();
            this.textBoxPrecioVenta.ReadOnly = true;
            this.textBox1.Clear();
            this.txtExistencia.Clear();
            this.txtExistenciaMaxima.Clear();
            this.txtExistenciaMinima.Clear();
            this.checkBox1.Checked = false;
            this.checkBox2.Checked = false;
            this.checkBox3.Checked = false;
            this.checkBoxInventario.Checked = false;
            this.comboDepartamento.SelectedIndex = 0;
            this.labelSection.Text = "NUEVO PRODUCTO";
            this.btnGuardar.Text = "Guardar Producto";
            this.textBoxCodigo.Focus();
        }

        /// <summary>
        /// Carga un producto en el formulario para edición.
        /// </summary>
        public void CargarProducto(int idProducto)
        {
            try
            {
                DataRow row = ProductoDAL.ObtenerPorId(idProducto);
                if (row == null)
                {
                    MessageBox.Show("Producto no encontrado.", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                productoActualId = idProducto;
                editando = true;
                this.textBoxCodigo.Text = row["codigo_barras"].ToString();
                this.textBoxCodigo.ReadOnly = true;
                this.textBoxDescripcion.Text = row["nombre"].ToString();
                this.textBoxPrecioCosto.Text = row["precio_compra"].ToString();
                this.numericGanancia.Value = (decimal)row["porcentaje_ganancia"];
                this.textBoxPrecioVenta.Text = row["precio_venta"].ToString();
                this.txtExistencia.Text = row["existencia"].ToString();

                // Cargar datos de existencia mínima y máxima si existen
                if (row.Table.Columns.Contains("existencia_minima") && row["existencia_minima"] != DBNull.Value)
                {
                    this.txtExistenciaMinima.Text = row["existencia_minima"].ToString();
                }

                if (row.Table.Columns.Contains("existencia_maxima") && row["existencia_maxima"] != DBNull.Value)
                {
                    this.txtExistenciaMaxima.Text = row["existencia_maxima"].ToString();
                }

                // Si hay valores en existencia mínima o máxima, marcar el checkbox
                if ((row.Table.Columns.Contains("existencia_minima") && row["existencia_minima"] != DBNull.Value && Convert.ToDecimal(row["existencia_minima"]) > 0) ||
                    (row.Table.Columns.Contains("existencia_maxima") && row["existencia_maxima"] != DBNull.Value && Convert.ToDecimal(row["existencia_maxima"]) > 0))
                {
                    this.checkBoxInventario.Checked = true;
                }

                this.labelSection.Text = "EDITAR PRODUCTO";
                this.btnGuardar.Text = "Actualizar Producto";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar producto: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Métodos Heredados del Formulario

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelContenido.Controls.Add(childForm);
            this.panelContenido.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ModificarProducto());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EliminarProducto());
        }

        private void btnDepartamentos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Departamentos());
        }

        private void btnVentasPorPeriodo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new VentasPorPeriodo());
        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Promociones());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }
            LimpiarFormulario();
        }

        #endregion
    }
}
