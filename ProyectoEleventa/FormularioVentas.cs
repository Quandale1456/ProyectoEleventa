using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    /// <summary>
    /// FORMULARIO PRINCIPAL DE VENTAS - PUNTO DE VENTA
    /// Sistema profesional para gestionar ventas rápidamente.
    /// Adaptado para funcionar con el diseño existente del formulario.
    /// </summary>
    public partial class FormularioVentas : Form
    {
        private const decimal IMPUESTO = 0.16m; // IVA 16%
        private int _idUsuario = 1; // Usuario por defecto

        public FormularioVentas()
        {
            InitializeComponent();
        }

        private void FormularioVentas_Load(object sender, EventArgs e)
        {
            try
            {
                // Habilitar detección de teclas globales
                this.KeyPreview = true;

                // PRIMERO: Probar conexión a BD
                if (!DBConnection.ProbarConexion())
                {
                    MessageBox.Show("No se puede conectar a la BD.\nVerifica:\n" +
                        "1. SQL Server está ejecutándose\n" +
                        "2. Base de datos 'sistema_ventas' existe\n" +
                        "3. Cadena de conexión es correcta",
                        "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Configurar DataGridView
                ConfigurarDataGridView();

                // Suscribir eventos de botones
                SuscribirEventosBotones();

                // Enfocar al campo de código
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inicializando: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Configura las columnas del DataGridView
        /// </summary>
        private void ConfigurarDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("codigo", "Código de Barras");
            dataGridView1.Columns.Add("nombre", "Descripción del Producto");
            dataGridView1.Columns.Add("precio", "Precio Venta");
            dataGridView1.Columns.Add("cantidad", "Cant.");
            dataGridView1.Columns.Add("importe", "Importe");
            dataGridView1.Columns.Add("existencia", "Existencia");

            // Ancho de columnas
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 80;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }

        /// <summary>
        /// Suscribe eventos a los botones
        /// </summary>
        private void SuscribirEventosBotones()
        {
            // Botón Agregar (button3 = ENTER - Agregar Producto)
            button3.Click += (s, e) => AgregarProductoAlTicket();

            // Botón Eliminar
            btnEliminar.Click += (s, e) => EliminarProductoDelTicket();

            // Botón Buscar (button6 = F10 Buscar)
            button6.Click += (s, e) => AbrirBusquedaProductos();

            // Botón Cobrar
            btnCobrar.Click += (s, e) => RealizarCobro();

            // Botón Cambiar (btnCambiar = F5 Cambiar)
            btnCambiar.Click += (s, e) => CancelarVenta();

            // Otros botones del menú
            button7.Click += (s, e) => AbrirINSVarios();
            btnProductoComun.Click += (s, e) => AbrirProductoComun();
            button5.Click += (s, e) => AbrirEntradasEfectivo();
            button10.Click += (s, e) => AbrirSalidasEfectivo();
            button12.Click += (s, e) => AbrirVerificador();

            // Tecla ENTER en textBox1 (código)
            textBox1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Return)
                {
                    AgregarProductoAlTicket();
                    e.Handled = true;
                }
            };
        }

        /// <summary>
        /// AGREGAR PRODUCTO AL TICKET
        /// Busca por código, nombre o ID
        /// </summary>
        private void AgregarProductoAlTicket()
        {
            try
            {
                string entrada = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(entrada))
                {
                    MessageBox.Show("Ingrese código, nombre o ID del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                DataRow producto = null;

                // Intentar buscar por ID (si es número)
                if (int.TryParse(entrada, out int idProducto))
                {
                    producto = ProductoDAL.ObtenerPorId(idProducto);
                }

                // Si no encontró por ID, buscar por código
                if (producto == null)
                {
                    producto = ProductoDAL.BuscarPorCodigo(entrada);
                }

                // Si no encontró por código, buscar por nombre
                if (producto == null)
                {
                    DataTable dtPorNombre = ProductoDAL.BuscarPorNombre(entrada);
                    if (dtPorNombre.Rows.Count > 0)
                    {
                        if (dtPorNombre.Rows.Count == 1)
                        {
                            producto = dtPorNombre.Rows[0];
                        }
                        else
                        {
                            // Si encuentra múltiples, mostrar lista
                            MessageBox.Show($"Se encontraron {dtPorNombre.Rows.Count} productos.\n" +
                                "Usa F10 para búsqueda visual o sé más específico.", "Múltiples resultados",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Clear();
                            textBox1.Focus();
                            return;
                        }
                    }
                }

                // Si aún no encontró
                if (producto == null)
                {
                    MessageBox.Show("Producto no encontrado.\nIntenta con:\n" +
                        "- Código de barras\n" +
                        "- ID del producto\n" +
                        "- Nombre del producto", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox1.Focus();
                    return;
                }

                // Extraer datos del producto
                int id = Convert.ToInt32(producto["id_producto"]);
                string codigo = producto["codigo_barras"].ToString();
                string nombre = producto["nombre"].ToString();
                decimal precioVenta = Convert.ToDecimal(producto["precio_venta"]);
                decimal existencia = Convert.ToDecimal(producto["existencia"]);

                // Cantidad por defecto
                decimal cantidad = 1;

                // Validar stock
                if (cantidad > existencia)
                {
                    MessageBox.Show($"Stock insuficiente.\nProducto: {nombre}\nDisponible: {existencia}", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox1.Focus();
                    return;
                }

                // Calcular importe
                decimal importeLinea = cantidad * precioVenta;

                // Agregar al DataGridView
                dataGridView1.Rows.Add(
                    codigo,
                    nombre,
                    precioVenta,
                    cantidad,
                    importeLinea,
                    existencia
                );

                // Recalcular totales
                RecalcularTotales();

                // Limpiar y enfocar
                textBox1.Clear();
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error agregando producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ELIMINAR PRODUCTO DEL TICKET
        /// </summary>
        private void EliminarProductoDelTicket()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una fila para eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                RecalcularTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error eliminando producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// RECALCULAR TOTALES
        /// label5 = Total (subtotal)
        /// label7 = Pagó Con (impuesto)
        /// label9 = Cambio (total final)
        /// label3 = Cantidad de productos
        /// </summary>
        private void RecalcularTotales()
        {
            try
            {
                decimal subtotalGeneral = 0;

                // Sumar todos los importes (columna 4)
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[4].Value != null)
                    {
                        subtotalGeneral += Convert.ToDecimal(row.Cells[4].Value);
                    }
                }

                // Calcular impuesto
                decimal impuesto = subtotalGeneral * IMPUESTO;
                decimal total = subtotalGeneral + impuesto;

                // Actualizar labels
                label5.Text = $"${subtotalGeneral:F2}";  // Total (subtotal)
                label7.Text = $"${impuesto:F2}";         // Impuesto
                label9.Text = $"${total:F2}";            // Total final
                label3.Text = dataGridView1.Rows.Count.ToString(); // Cantidad de productos
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculando totales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// REALIZAR COBRO
        /// </summary>
        private void RealizarCobro()
        {
            try
            {
                // Validar que hay productos
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("El ticket está vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener cliente por defecto
                int idCliente = ClienteDAL.ObtenerClientePorDefecto();
                string metodoPago = "Efectivo";

                // Extraer valores desde los labels
                decimal subtotal = Convert.ToDecimal(label5.Text.Replace("$", ""));
                decimal impuesto = Convert.ToDecimal(label7.Text.Replace("$", ""));
                decimal total = Convert.ToDecimal(label9.Text.Replace("$", ""));

                // Ejecutar transacción
                bool exito = DBConnection.ExecuteTransaction((conn, trans) =>
                {
                    int idVenta = VentaDAL.RegistrarVenta(idCliente, subtotal, impuesto, 0, total, 
                        metodoPago, _idUsuario, dataGridView1, conn, trans);
                });

                if (exito)
                {
                    MessageBox.Show("¡Venta registrada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarTicket();
                    textBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error realizando cobro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// CANCELAR VENTA
        /// </summary>
        private void CancelarVenta()
        {
            if (MessageBox.Show("¿Está seguro de cancelar la venta?", "Confirmación", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpiarTicket();
            }
        }

        /// <summary>
        /// Limpia completamente el ticket
        /// </summary>
        private void LimpiarTicket()
        {
            dataGridView1.Rows.Clear();
            textBox1.Clear();
            label3.Text = "0";
            label5.Text = "$0.00";
            label7.Text = "$0.00";
            label9.Text = "$0.00";
            textBox1.Focus();
        }

        /// <summary>
        /// Abre el formulario de búsqueda de productos
        /// </summary>
        private void AbrirBusquedaProductos()
        {
            try
            {
                BusquedaProductos formBusqueda = new BusquedaProductos();
                if (formBusqueda.ShowDialog() == DialogResult.OK)
                {
                    // Obtener código del producto seleccionado
                    DataRow producto = ProductoDAL.ObtenerPorId(formBusqueda.IdProductoSeleccionado);
                    if (producto != null)
                    {
                        textBox1.Text = producto["codigo_barras"].ToString();
                        AgregarProductoAlTicket();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error abriendo búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirINSVarios()
        {
            try
            {
                INSVarios formINSVarios = new INSVarios();
                DialogResult resultado = formINSVarios.ShowDialog();

                // Si el usuario aceptó
                if (resultado == DialogResult.OK && formINSVarios.Aceptado)
                {
                    string codigo = formINSVarios.CodigoProducto;
                    decimal cantidadAdicional = formINSVarios.Cantidad;

                    // Buscar el producto
                    DataRow producto = ProductoDAL.BuscarPorCodigo(codigo);

                    if (producto != null)
                    {
                        int id = Convert.ToInt32(producto["id_producto"]);
                        string nombre = producto["nombre"].ToString();
                        decimal precioVenta = Convert.ToDecimal(producto["precio_venta"]);
                        decimal existencia = Convert.ToDecimal(producto["existencia"]);

                        // Validar que haya existencia suficiente
                        if (cantidadAdicional > existencia)
                        {
                            MessageBox.Show($"Stock insuficiente.\nProducto: {nombre}\nDisponible: {existencia}", 
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Buscar si el producto ya está en el ticket
                        bool productoEncontrado = false;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells[0].Value?.ToString() == codigo)
                            {
                                // Producto ya existe, aumentar cantidad
                                decimal cantidadActual = Convert.ToDecimal(row.Cells[3].Value);
                                decimal nuevaCantidad = cantidadActual + cantidadAdicional;

                                if (nuevaCantidad > existencia)
                                {
                                    MessageBox.Show($"Stock insuficiente para la cantidad solicitada.\nDisponible: {existencia}", 
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Actualizar fila
                                decimal nuevoImporte = nuevaCantidad * precioVenta;
                                row.Cells[3].Value = nuevaCantidad;
                                row.Cells[4].Value = nuevoImporte;

                                productoEncontrado = true;
                                break;
                            }
                        }

                        // Si no existe, agregar nueva fila
                        if (!productoEncontrado)
                        {
                            decimal importeLinea = cantidadAdicional * precioVenta;

                            dataGridView1.Rows.Add(
                                codigo,
                                nombre,
                                precioVenta,
                                cantidadAdicional,
                                importeLinea,
                                existencia
                            );
                        }

                        // Recalcular totales
                        RecalcularTotales();

                        MessageBox.Show($"Producto agregado exitosamente.\n{nombre} x {cantidadAdicional}", 
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirProductoComun()
        {
            try
            {
                ProductoComun formProductoComun = new ProductoComun();
                DialogResult resultado = formProductoComun.ShowDialog();

                // Si el usuario aceptó
                if (resultado == DialogResult.OK && formProductoComun.Aceptado)
                {
                    string descripcion = formProductoComun.Descripcion;
                    decimal cantidad = formProductoComun.Cantidad;
                    decimal precio = formProductoComun.Precio;
                    decimal importe = cantidad * precio;

                    // Agregar el producto común al DataGridView
                    // Usamos el código "PC" (Producto Común) para identificarlo
                    dataGridView1.Rows.Add(
                        "PC", // Código (Producto Común)
                        descripcion,
                        precio,
                        cantidad,
                        importe,
                        0 // Sin existencia registrada
                    );

                    // Recalcular totales
                    RecalcularTotales();

                    MessageBox.Show($"Producto común agregado exitosamente.\n{descripcion} x {cantidad} @ ${precio}", 
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirEntradasEfectivo()
        {
            EntradasEfectivo formEntradasEfectivo = new EntradasEfectivo();
            formEntradasEfectivo.ShowDialog();
        }

        private void AbrirSalidasEfectivo()
        {
            SalidasEfectivo formSalidasEfectivo = new SalidasEfectivo();
            formSalidasEfectivo.ShowDialog();
        }

        private void AbrirVerificador()
        {
            Verificador formVerificador = new Verificador();
            formVerificador.ShowDialog();
        }

        /// <summary>
        /// Manejo de teclas globales
        /// </summary>
        private void FormularioVentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                AbrirBusquedaProductos();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Insert)
            {
                AbrirINSVarios();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.P && e.Control)
            {
                AbrirProductoComun();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F7)
            {
                AbrirEntradasEfectivo();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F8)
            {
                AbrirSalidasEfectivo();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F9)
            {
                AbrirVerificador();
                e.Handled = true;
            }
        }
    }
}
