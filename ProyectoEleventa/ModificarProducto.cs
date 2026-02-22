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
    public partial class ModificarProducto : Form
    {
        public ModificarProducto()
        {
            InitializeComponent();
        }

        private void ModificarProducto_Load(object sender, EventArgs e)
        {
            // Suscribir evento del botón Aceptar
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);

            // Permitir Enter en el textbox para aceptar
            this.txtCodigoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProducto_KeyPress);

            // Enfocar el textbox al cargar
            this.txtCodigoProducto.Focus();
        }

        /// <summary>
        /// Evento del botón Aceptar - Busca el producto y abre el formulario de edición
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = this.txtCodigoProducto.Text.Trim();

                // Validar que se ingresó un código
                if (string.IsNullOrWhiteSpace(codigo))
                {
                    MessageBox.Show("Por favor ingrese el código del producto.", 
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtCodigoProducto.Focus();
                    return;
                }

                // Buscar el producto por código
                DataRow productoRow = ProductoDAL.BuscarPorCodigo(codigo);

                if (productoRow == null)
                {
                    MessageBox.Show($"Producto con código '{codigo}' no encontrado.", 
                        "Producto No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtCodigoProducto.Clear();
                    this.txtCodigoProducto.Focus();
                    return;
                }

                // Obtener el ID del producto
                int idProducto = (int)productoRow["id_producto"];
                string nombreProducto = productoRow["nombre"].ToString();

                // Obtener el FormularioProductos padre (FormularioProductos)
                // El ModificarProducto es un formulario hijo dentro de FormularioProductos
                Form formularioPrincipal = this.ParentForm;

                // Si es un FormularioProductos
                if (formularioPrincipal != null && formularioPrincipal.GetType().Name == "FormularioProductos")
                {
                    FormularioProductos formProductos = (FormularioProductos)formularioPrincipal;

                    // Cargar el producto en el formulario principal
                    formProductos.CargarProducto(idProducto);

                    // IMPORTANTE: Cerrar este panel para mostrar el FormularioProductos
                    this.Close();

                    // Mostrar mensaje de éxito
                    MessageBox.Show($"Producto '{nombreProducto}' cargado para edición.", 
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error: No se puede acceder al formulario de productos.", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar producto: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Permite usar Enter en el textbox para aceptar
        /// </summary>
        private void txtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                btnAceptar_Click(null, null);
            }
        }
    }
}
