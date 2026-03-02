using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    public partial class Verificador : Form
    {
        public bool Aceptado { get; private set; }
        public string CodigoProducto { get; private set; }

        private Label _lblAviso;
        private DataRow _productoActual;

        public Verificador()
        {
            InitializeComponent();

            Aceptado = false;
            CodigoProducto = string.Empty;

            Load += Verificador_Load;
            textBox1.KeyDown += TextBox1_KeyDown;
            button1.Click += ButtonAgregar_Click;
            button2.Click += ButtonCancelar_Click;

            KeyPreview = true;
            KeyDown += Verificador_KeyDown;
        }

        private void Verificador_Load(object sender, EventArgs e)
        {
            BackColor = Color.WhiteSmoke;

            // Centrar visualmente los labels (sin modificar designer)
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.TextAlign = ContentAlignment.MiddleCenter;

            label2.AutoSize = true;
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Font = new Font(label2.Font.FontFamily, 42f, FontStyle.Regular);
            label2.ForeColor = Color.FromArgb(0, 45, 160);

            lblSumaImpuestos.AutoSize = true;
            lblSumaImpuestos.TextAlign = ContentAlignment.MiddleCenter;
            lblSumaImpuestos.ForeColor = Color.Gray;

            AsegurarAvisoMayoreo();
            LimpiarVista();

            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void AsegurarAvisoMayoreo()
        {
            if (_lblAviso != null) return;

            _lblAviso = new Label();
            _lblAviso.Dock = DockStyle.Top;
            _lblAviso.Height = 22;
            _lblAviso.TextAlign = ContentAlignment.MiddleLeft;
            _lblAviso.Padding = new Padding(8, 0, 8, 0);
            _lblAviso.BackColor = Color.FromArgb(255, 249, 196);
            _lblAviso.ForeColor = Color.FromArgb(80, 80, 80);
            _lblAviso.Visible = false;

            Controls.Add(_lblAviso);
            _lblAviso.BringToFront();
            panel1.BringToFront();
            panel2.BringToFront();
        }

        private void LimpiarVista()
        {
            _productoActual = null;
            lblNombreProducto.Text = "-";
            label2.Text = "$0.00";
            lblSumaImpuestos.Text = "(+ $0.00 de impuestos)";
            if (_lblAviso != null)
                _lblAviso.Visible = false;

            RecentrarLabels();
        }

        private void RecentrarLabels()
        {
            // Centrar horizontalmente con posiciones absolutas (sin tocar designer)
            lblNombreProducto.Left = (ClientSize.Width - lblNombreProducto.Width) / 2;
            label2.Left = (ClientSize.Width - label2.Width) / 2;
            lblSumaImpuestos.Left = (ClientSize.Width - lblSumaImpuestos.Width) / 2;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BuscarYMostrar();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                ButtonCancelar_Click(this, EventArgs.Empty);
            }
        }

        private void Verificador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ButtonCancelar_Click(this, EventArgs.Empty);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F1)
            {
                ButtonAgregar_Click(this, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void BuscarYMostrar()
        {
            try
            {
                string codigo = (textBox1.Text ?? string.Empty).Trim();
                if (string.IsNullOrWhiteSpace(codigo))
                {
                    LimpiarVista();
                    return;
                }

                DataRow producto = ProductoDAL.BuscarPorCodigo(codigo);
                if (producto == null)
                {
                    LimpiarVista();
                    lblNombreProducto.Text = "NO ENCONTRADO";
                    label2.Text = "$0.00";
                    lblSumaImpuestos.Text = "(+ $0.00 de impuestos)";
                    RecentrarLabels();

                    System.Media.SystemSounds.Beep.Play();
                    textBox1.Focus();
                    textBox1.SelectAll();
                    return;
                }

                _productoActual = producto;

                string nombre = producto["nombre"] != DBNull.Value ? producto["nombre"].ToString() : "";
                decimal precioVenta = producto["precio_venta"] != DBNull.Value ? Convert.ToDecimal(producto["precio_venta"]) : 0m;

                // Impuestos: si tu BD no tiene IVA por producto, lo dejamos en 0 para que se vea como la imagen.
                decimal impuestos = 0m;

                lblNombreProducto.Text = nombre;
                label2.Text = precioVenta.ToString("C2");
                lblSumaImpuestos.Text = "(+ " + impuestos.ToString("C2") + " de impuestos)";

                // Aviso mayoreo (placeholder): si después agregas precio_mayoreo/cantidad_mayoreo lo conectamos.
                if (_lblAviso != null)
                {
                    _lblAviso.Text = "Existe precio de mayoreo para el producto, presiona F11 para verlo";
                    _lblAviso.Visible = false;
                }

                RecentrarLabels();
                textBox1.Focus();
                textBox1.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAgregar_Click(object sender, EventArgs e)
        {
            if (_productoActual == null)
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            CodigoProducto = _productoActual["codigo_barras"] != DBNull.Value ? _productoActual["codigo_barras"].ToString() : string.Empty;
            if (string.IsNullOrWhiteSpace(CodigoProducto))
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            Aceptado = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
