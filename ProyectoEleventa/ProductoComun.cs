using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEleventa
{
    public partial class ProductoComun : Form
    {
        public string Descripcion { get; private set; }
        public decimal Cantidad { get; private set; }
        public decimal Precio { get; private set; }
        public bool Aceptado { get; private set; }

        public ProductoComun()
        {
            InitializeComponent();
        }

        private void ProductoComun_Load(object sender, EventArgs e)
        {
            try
            {
                // Suscribir eventos
                button1.Click += Button1_Click; // Aceptar
                button2.Click += Button2_Click; // Cancelar
                textBox1.KeyDown += TextBox1_KeyDown;
                textBox2.KeyDown += TextBox2_KeyDown;
                textBox3.KeyDown += TextBox3_KeyDown;

                // Valores por defecto
                textBox2.Text = "1";
                textBox3.Text = "0";

                textBox1.Focus();
                Aceptado = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                textBox2.Focus();
                e.Handled = true;
            }
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                textBox3.Focus();
                e.Handled = true;
            }
        }

        private void TextBox3_KeyDown(object sender, KeyEventArgs e)
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
                string descripcion = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(descripcion))
                {
                    MessageBox.Show("Ingrese la descripción del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                if (!decimal.TryParse(textBox2.Text, out decimal cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida (mayor a 0)", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Focus();
                    return;
                }

                if (!decimal.TryParse(textBox3.Text, out decimal precio) || precio < 0)
                {
                    MessageBox.Show("Ingrese un precio válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Focus();
                    return;
                }

                // Guardar valores y cerrar
                Descripcion = descripcion;
                Cantidad = cantidad;
                Precio = precio;
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
