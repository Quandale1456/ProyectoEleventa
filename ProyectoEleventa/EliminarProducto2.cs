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
    public partial class EliminarProducto2 : Form
    {
        private int _idProducto = -1;

        public EliminarProducto2()
        {
            InitializeComponent();
        }

        private void EliminarProducto2_Load(object sender, EventArgs e)
        {
            btnEliminarEsteProducto.Click += BtnEliminarEsteProducto_Click;

            // Establecer TextBox como solo lectura
            txtCodigo.ReadOnly = true;
            txtDescripcion.ReadOnly = true;
            txtPrecioCosto.ReadOnly = true;
            txtPrecioVenta.ReadOnly = true;
            txtDepartamento.ReadOnly = true;
        }

        /// <summary>
        /// Carga los datos del producto en los campos
        /// </summary>
        public void CargarProducto(DataRow producto)
        {
            try
            {
                _idProducto = Convert.ToInt32(producto["id_producto"]);

                txtCodigo.Text = producto["codigo_barras"]?.ToString() ?? "";
                txtDescripcion.Text = producto["nombre"]?.ToString() ?? "";
                txtPrecioCosto.Text = Convert.ToDecimal(producto["precio_compra"]).ToString("F2");
                txtPrecioVenta.Text = Convert.ToDecimal(producto["precio_venta"]).ToString("F2");
                txtDepartamento.Text = producto["departamento"]?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarEsteProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idProducto == -1)
                {
                    MessageBox.Show("No hay producto cargado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar este producto?\n\n" +
                    $"Código: {txtCodigo.Text}\n" +
                    $"Descripción: {txtDescripcion.Text}",
                    "Confirmación de eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                    {
                        bool exito = ProductoDAL.EliminarProducto(_idProducto);

                        if (exito)
                        {
                            MessageBox.Show("Producto eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
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
    }
}
