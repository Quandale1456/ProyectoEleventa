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
    public partial class EliminarProducto : Form
    {
        private int _idProducto = -1;

        public EliminarProducto()
        {
            InitializeComponent();
        }

        private void EliminarProducto_Load(object sender, EventArgs e)
        {
            btnAceptar.Click += BtnAceptar_Click;
            txtCodigoProducto.KeyDown += TxtCodigoProducto_KeyDown;
        }

        private void TxtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                BtnAceptar_Click(null, null);
                e.Handled = true;
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigoProducto.Text.Trim();

                if (string.IsNullOrEmpty(codigo))
                {
                    MessageBox.Show("Ingrese un código de producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoProducto.Focus();
                    return;
                }

                // Buscar el producto por código
                DataRow producto = ProductoDAL.BuscarPorCodigo(codigo);

                if (producto == null)
                {
                    MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigoProducto.Clear();
                    txtCodigoProducto.Focus();
                    return;
                }

                // Cargar el producto y mostrar los detalles
                MostrarDetallesProducto(producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Muestra los detalles del producto
        /// </summary>
        private void MostrarDetallesProducto(DataRow producto)
        {
            try
            {
                _idProducto = Convert.ToInt32(producto["id_producto"]);

                // Guardar controles de búsqueda
                var controlesBusqueda = new Control[] { panel1 };

                // Ocultar panel de búsqueda
                panel1.Visible = false;

                // Obtener panel2 de EliminarProducto2 y agregarlo aquí
                // En su lugar, vamos a crear los controles en este formulario

                // Crear panel para mostrar detalles
                Panel panelDetalles = new Panel();
                panelDetalles.Name = "panelDetalles";
                panelDetalles.Dock = DockStyle.Fill;
                panelDetalles.Padding = new Padding(20);
                panelDetalles.AutoScroll = true;

                // Título
                Label lblTitulo = new Label();
                lblTitulo.Text = "ELIMINAR PRODUCTO";
                lblTitulo.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                lblTitulo.ForeColor = Color.FromArgb(255, 128, 0);
                lblTitulo.AutoSize = true;
                lblTitulo.Location = new Point(12, 9);

                // Código
                Label lblCodigo = new Label();
                lblCodigo.Text = "Código:";
                lblCodigo.Location = new Point(39, 48);
                lblCodigo.AutoSize = true;

                TextBox txtCodigo = new TextBox();
                txtCodigo.Name = "txtCodigo";
                txtCodigo.Text = producto["codigo_barras"]?.ToString() ?? "";
                txtCodigo.Location = new Point(80, 45);
                txtCodigo.Size = new Size(141, 20);
                txtCodigo.ReadOnly = true;

                // Descripción
                Label lblDesc = new Label();
                lblDesc.Text = "Descripción:";
                lblDesc.Location = new Point(16, 81);
                lblDesc.AutoSize = true;

                TextBox txtDesc = new TextBox();
                txtDesc.Name = "txtDesc";
                txtDesc.Text = producto["nombre"]?.ToString() ?? "";
                txtDesc.Location = new Point(80, 78);
                txtDesc.Size = new Size(407, 20);
                txtDesc.ReadOnly = true;

                // Precio Costo
                Label lblCosto = new Label();
                lblCosto.Text = "Precio Costo:";
                lblCosto.Location = new Point(12, 111);
                lblCosto.AutoSize = true;

                TextBox txtCosto = new TextBox();
                txtCosto.Name = "txtCosto";
                txtCosto.Text = Convert.ToDecimal(producto["precio_compra"]).ToString("F2");
                txtCosto.Location = new Point(79, 108);
                txtCosto.Size = new Size(100, 20);
                txtCosto.ReadOnly = true;

                // Precio Venta
                Label lblVenta = new Label();
                lblVenta.Text = "Precio Venta:";
                lblVenta.Location = new Point(11, 137);
                lblVenta.AutoSize = true;

                TextBox txtVenta = new TextBox();
                txtVenta.Name = "txtVenta";
                txtVenta.Text = Convert.ToDecimal(producto["precio_venta"]).ToString("F2");
                txtVenta.Location = new Point(79, 134);
                txtVenta.Size = new Size(100, 20);
                txtVenta.ReadOnly = true;

                // Departamento
                Label lblDepto = new Label();
                lblDepto.Text = "Departamento:";
                lblDepto.Location = new Point(5, 163);
                lblDepto.AutoSize = true;

                TextBox txtDepto = new TextBox();
                txtDepto.Name = "txtDepto";
                txtDepto.Text = producto["departamento"]?.ToString() ?? "";
                txtDepto.Location = new Point(79, 160);
                txtDepto.Size = new Size(142, 20);
                txtDepto.ReadOnly = true;

                // Botón Eliminar
                Button btnEliminar = new Button();
                btnEliminar.Text = "Eliminar este Producto";
                btnEliminar.Location = new Point(80, 223);
                btnEliminar.Size = new Size(141, 23);
                btnEliminar.Click += (s, e) => BtnEliminar_Click();

                // Botón Volver
                Button btnVolver = new Button();
                btnVolver.Text = "Volver";
                btnVolver.Location = new Point(80, 260);
                btnVolver.Size = new Size(141, 23);
                btnVolver.Click += (s, e) => VolverABusqueda();

                // Agregar controles al panel
                panelDetalles.Controls.AddRange(new Control[] {
                    lblTitulo, lblCodigo, txtCodigo, lblDesc, txtDesc,
                    lblCosto, txtCosto, lblVenta, txtVenta, lblDepto, txtDepto,
                    btnEliminar, btnVolver
                });

                // Agregar panel al formulario
                this.Controls.Add(panelDetalles);
                panelDetalles.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error mostrando detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click()
        {
            try
            {
                if (_idProducto == -1)
                {
                    MessageBox.Show("No hay producto cargado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar este producto?",
                    "Confirmación de eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    bool exito = ProductoDAL.EliminarProducto(_idProducto);

                    if (exito)
                    {
                        MessageBox.Show("Producto eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        VolverABusqueda();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error eliminando producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VolverABusqueda()
        {
            try
            {
                // Ocultar panel de detalles
                Panel panelDetalles = this.Controls["panelDetalles"] as Panel;
                if (panelDetalles != null)
                {
                    this.Controls.Remove(panelDetalles);
                    panelDetalles.Dispose();
                }

                // Mostrar panel de búsqueda
                panel1.Visible = true;
                txtCodigoProducto.Clear();
                txtCodigoProducto.Focus();

                _idProducto = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
