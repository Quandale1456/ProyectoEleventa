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
    public partial class INSVarios : Form
    {
        public string CodigoProducto { get; private set; }
        public decimal Cantidad { get; private set; }
        public bool Aceptado { get; private set; }

        public INSVarios()
        {
            InitializeComponent();
        }

        private void INSVarios_Load(object sender, EventArgs e)
        {
            try
            {
                // Configurar AutoComplete
                ConfigurarAutoComplete();

                // Suscribir eventos
                button1.Click += Button1_Click; // Aceptar
                button2.Click += Button2_Click; // Cancelar
                textBox1.KeyDown += TextBox1_KeyDown;
                numericGanancia.Value = 1; // Cantidad por defecto

                textBox1.Focus();
                Aceptado = false;
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

                textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox1.AutoCompleteCustomSource = codigosProductos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error configurando AutoComplete: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Button1_Click(null, null);
                e.Handled = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(codigo))
                {
                    MessageBox.Show("Ingrese un código de producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                // Verificar que el producto exista
                DataRow producto = ProductoDAL.BuscarPorCodigo(codigo);
                if (producto == null)
                {
                    MessageBox.Show($"Producto con código '{codigo}' no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox1.Focus();
                    return;
                }

                if (numericGanancia.Value <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a 0", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numericGanancia.Focus();
                    return;
                }

                // Guardar valores y cerrar
                CodigoProducto = codigo;
                Cantidad = numericGanancia.Value;
                Aceptado = true;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Aceptado = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
