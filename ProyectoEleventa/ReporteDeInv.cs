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
    public partial class ReporteDeInv : Form
    {
        private DataTable _productosCompletos; // Para almacenar todos los productos

        public ReporteDeInv()
        {
            InitializeComponent();
        }

        private void ReporteDeInv_Load(object sender, EventArgs e)
        {
            // Configurar el ComboBox para ser editable
            comboDepartamentos.DropDownStyle = ComboBoxStyle.DropDown;
            comboDepartamentos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboDepartamentos.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Cargar departamentos en el ComboBox
            CargarDepartamentos();

            // Suscribir al evento TextChanged del ComboBox para filtrado dinámico
            comboDepartamentos.TextChanged += new EventHandler(this.comboDepartamentos_TextChanged);

            // Suscribir al evento Click del botón Modificar Producto
            btnModificarProducto.Click += new EventHandler(this.btnModificarProducto_Click);

            // Cargar los productos
            CargarProductosConInventario(null);
        }

        /// <summary>
        /// Carga los departamentos disponibles en el ComboBox
        /// </summary>
        private void CargarDepartamentos()
        {
            try
            {
                comboDepartamentos.Items.Clear();
                comboDepartamentos.Items.Add("- Todos -");

                // Obtener departamentos únicos
                DataTable departamentos = ProductoDAL.ObtenerDepartamentosUnicos();

                foreach (DataRow row in departamentos.Rows)
                {
                    if (row["departamento"] != DBNull.Value && !string.IsNullOrEmpty(row["departamento"].ToString()))
                    {
                        comboDepartamentos.Items.Add(row["departamento"].ToString());
                    }
                }

                // Seleccionar "Todos" por defecto
                comboDepartamentos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar departamentos: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara cuando cambia el texto en el ComboBox (búsqueda dinámica)
        /// </summary>
        private void comboDepartamentos_TextChanged(object sender, EventArgs e)
        {
            string textoIngresado = comboDepartamentos.Text.Trim();

            if (string.IsNullOrEmpty(textoIngresado) || textoIngresado == "- Todos -")
            {
                CargarProductosConInventario(null);
            }
            else
            {
                CargarProductosConInventario(textoIngresado);
            }
        }

        /// <summary>
        /// Evento que se dispara cuando se hace click en el botón Modificar Producto
        /// </summary>
        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que hay una fila seleccionada
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor selecciona un producto de la tabla.", 
                        "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                // Obtener el código del producto (primera columna)
                string codigoProducto = filaSeleccionada.Cells["Codigo"].Value.ToString();

                // Buscar el producto por código
                DataRow productoRow = ProductoDAL.BuscarPorCodigo(codigoProducto);

                if (productoRow == null)
                {
                    MessageBox.Show($"Producto con código '{codigoProducto}' no encontrado.", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el ID del producto
                int idProducto = Convert.ToInt32(productoRow["id_producto"]);

                // Obtener el formulario padre (FormularioDeInventario)
                Form formularioPrincipal = this.ParentForm;

                if (formularioPrincipal != null)
                {
                    // Cerrar ReporteDeInv (este formulario)
                    this.Close();

                    // Crear FormularioProductos con el producto precargado
                    FormularioProductos formProductos = new FormularioProductos();
                    formProductos.IdProductoACargar = idProducto;

                    // Llamar a OpenChildForm del formulario padre para mostrar FormularioProductos
                    var method = formularioPrincipal.GetType().GetMethod("OpenChildForm", 
                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    if (method != null)
                    {
                        method.Invoke(formularioPrincipal, new object[] { formProductos });
                    }
                }
                else
                {
                    MessageBox.Show("Error: No se puede acceder al formulario principal.", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar producto: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga todos los productos que tienen inventario en el DataGridView, opcionalmente filtrados por departamento
        /// </summary>
        private void CargarProductosConInventario(string departamentoFiltro)
        {
            try
            {
                // Obtener todos los productos
                _productosCompletos = ProductoDAL.ObtenerTodos();

                // Limpiar el DataGridView
                dataGridView1.Rows.Clear();

                decimal costoTotal = 0;
                decimal stockTotal = 0;

                // Cargar los datos en el DataGridView
                foreach (DataRow row in _productosCompletos.Rows)
                {
                    // Aplicar filtro por departamento si está especificado
                    if (departamentoFiltro != null)
                    {
                        string departamento = row["departamento"] != DBNull.Value ? row["departamento"].ToString() : "";

                        // Filtrar por coincidencia parcial (búsqueda)
                        if (!departamento.ToLower().Contains(departamentoFiltro.ToLower()))
                        {
                            continue; // Saltar este producto si no coincide el departamento
                        }
                    }

                    decimal existencia = row["existencia"] != DBNull.Value ? Convert.ToDecimal(row["existencia"]) : 0;
                    decimal precioCosto = row["precio_compra"] != DBNull.Value ? Convert.ToDecimal(row["precio_compra"]) : 0;
                    decimal precioVenta = row["precio_venta"] != DBNull.Value ? Convert.ToDecimal(row["precio_venta"]) : 0;
                    decimal existenciaMinima = row["existencia_minima"] != DBNull.Value ? Convert.ToDecimal(row["existencia_minima"]) : 0;
                    decimal existenciaMaxima = row["existencia_maxima"] != DBNull.Value ? Convert.ToDecimal(row["existencia_maxima"]) : 0;

                    // Calcular el costo de inventario para este producto
                    decimal costoProducto = existencia * precioCosto;
                    costoTotal += costoProducto;

                    // Sumar el stock total
                    stockTotal += existencia;

                    dataGridView1.Rows.Add(
                        row["codigo_barras"].ToString(),                  // Código
                        row["nombre"].ToString(),                         // Descripción
                        precioCosto.ToString("F2"),                       // Costo
                        precioVenta.ToString("F2"),                       // Precio Venta
                        existencia.ToString("F2"),                        // Existencia
                        existenciaMinima.ToString("F2"),                  // Inv. Mínimo
                        existenciaMaxima.ToString("F2")                   // Inv. Máximo
                    );
                }

                // Actualizar los labels con los resúmenes
                lblCosto.Text = costoTotal.ToString("C2");
                lblCantidad.Text = stockTotal.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
