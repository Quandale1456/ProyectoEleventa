using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoEleventa
{
    public partial class FrmReporteMovimientosInventario : Form
    {
        public FrmReporteMovimientosInventario()
        {
            InitializeComponent();
            ConfigurarEstilos();
            CargarDatosEjemplo();
        }

        private void ConfigurarEstilos()
        {
            this.BackColor = Color.White;

            lblTitulo.ForeColor = Color.MidnightBlue;

            dgvMovimientos.BackgroundColor = Color.White;
            dgvMovimientos.BorderStyle = BorderStyle.None;
            dgvMovimientos.EnableHeadersVisualStyles = false;
            dgvMovimientos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvMovimientos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvMovimientos.ColumnHeadersDefaultCellStyle.Font = new Font(dgvMovimientos.Font, FontStyle.Bold);
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.MultiSelect = false;
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.AllowUserToResizeRows = false;
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.FlatAppearance.BorderColor = Color.FromArgb(210, 210, 210);

            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.FlatAppearance.BorderColor = Color.FromArgb(210, 210, 210);
        }

        private void CargarDatosEjemplo()
        {
            cmbBuscarPor.SelectedIndex = 0;
            cmbMovimientos.SelectedIndex = 0;

            if (dgvMovimientos.Rows.Count == 0)
            {
                dgvMovimientos.Rows.Add(
                    "10:07 pm",
                    "Mesa Gamer",
                    "Venta #3",
                    "",
                    "",
                    "1",
                    "23",
                    "Poti",
                    "Inmobiliaria"
                );
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de exportación pendiente.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de impresión pendiente.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
