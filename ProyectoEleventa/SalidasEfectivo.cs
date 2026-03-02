using System;
using System.Drawing;
using System.Windows.Forms;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    public partial class SalidasEfectivo : Form
    {
        public SalidasEfectivo()
        {
            InitializeComponent();

            Load += SalidasEfectivo_Load;
            button1.Click += ButtonGuardar_Click;
            button2.Click += ButtonCancelar_Click;
            button3.Click += ButtonVerPasadas_Click;

            KeyPreview = true;
            KeyDown += SalidasEfectivo_KeyDown;
        }

        private void SalidasEfectivo_Load(object sender, EventArgs e)
        {
            BackColor = Color.White;
            textBox2.Focus();
            textBox2.SelectAll();
        }

        private void SalidasEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ButtonCancelar_Click(this, EventArgs.Empty);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F1)
            {
                ButtonGuardar_Click(this, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void ButtonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(textBox2.Text.Trim(), out decimal cantidad))
                {
                    MessageBox.Show("Cantidad inválida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Focus();
                    textBox2.SelectAll();
                    return;
                }

                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor que 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Focus();
                    textBox2.SelectAll();
                    return;
                }

                string comentario = (textBox1.Text ?? string.Empty).Trim();
                if (string.IsNullOrWhiteSpace(comentario))
                {
                    comentario = "Salida de efectivo";
                }

                // Nota: no tenemos un id_usuario global aquí sin tocar más partes. Se guarda nulo.
                int id = EfectivoDAL.RegistrarMovimiento("SALIDA", cantidad, comentario, null);
                if (id <= 0)
                {
                    MessageBox.Show("No se pudo registrar la salida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Salida registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonVerPasadas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función pendiente.", "Salidas pasadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
