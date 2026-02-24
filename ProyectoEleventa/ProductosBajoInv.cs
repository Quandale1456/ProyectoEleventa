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
    public partial class ProductosBajoInv : Form
    {
        public ProductosBajoInv()
        {
            InitializeComponent();
        }

        private void ProductosBajoInv_Load(object sender, EventArgs e)
        {
            CargarProductosBajoInvMinimo();
        }

        /// <summary>
        /// Carga los productos que están por debajo de su inventario mínimo en el DataGridView
        /// </summary>
        private void CargarProductosBajoInvMinimo()
        {
            try
            {
                // Obtener los productos bajo inventario mínimo
                DataTable productos = ProductoDAL.ObtenerProductosBajoInvMinimo();

                // Limpiar el DataGridView
                dataGridView1.Rows.Clear();

                // Si no hay productos, mostrar un mensaje
                if (productos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay productos por debajo de su inventario mínimo.", 
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Cargar los datos en el DataGridView
                foreach (DataRow row in productos.Rows)
                {
                    dataGridView1.Rows.Add(
                        row["codigo_barras"].ToString(),                          // Código
                        row["nombre"].ToString(),                                 // Descripción
                        Convert.ToDecimal(row["precio_venta"]).ToString("F2"),    // Precio Venta
                        row["departamento"] != DBNull.Value ? row["departamento"].ToString() : "",  // Departamento
                        Convert.ToDecimal(row["existencia"]).ToString("F2"),      // Existencia
                        Convert.ToDecimal(row["existencia_minima"]).ToString("F2"), // Inventario Mínimo
                        Convert.ToDecimal(row["existencia_maxima"]).ToString("F2")  // Inventario Máximo
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
