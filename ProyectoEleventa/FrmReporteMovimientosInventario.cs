using System;
using System.Drawing;
using System.Globalization;
using System.Data;
using System.Windows.Forms;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    public partial class FrmReporteMovimientosInventario : Form
    {
        private TextBox _txtFiltro;

        public FrmReporteMovimientosInventario()
        {
            InitializeComponent();
            ConfigurarEstilos();

            Load += FrmReporteMovimientosInventario_Load;
        }

        private void FrmReporteMovimientosInventario_Load(object sender, EventArgs e)
        {
            dtpDelDia.Value = DateTime.Today;

            if (cmbBuscarPor.SelectedIndex < 0)
                cmbBuscarPor.SelectedIndex = 0;
            if (cmbMovimientos.SelectedIndex < 0)
                cmbMovimientos.SelectedIndex = 0;

            AsegurarTextBoxFiltro();

            dtpDelDia.ValueChanged += (s, ev) => CargarMovimientos();
            cmbBuscarPor.SelectedIndexChanged += (s, ev) => CargarMovimientos();
            cmbMovimientos.SelectedIndexChanged += (s, ev) => CargarMovimientos();

            CargarMovimientos();
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

        private void AsegurarTextBoxFiltro()
        {
            if (_txtFiltro != null)
                return;

            _txtFiltro = new TextBox();
            _txtFiltro.Width = 220;
            _txtFiltro.Margin = new Padding(12, 0, 0, 0);
            _txtFiltro.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CargarMovimientos();
                    e.Handled = true;
                }
            };
            _txtFiltro.TextChanged += (s, e) => CargarMovimientos();

            // Agregar al final del flow sin modificar el Designer
            flowFiltros.Controls.Add(_txtFiltro);
        }

        private void CargarMovimientos()
        {
            try
            {
                string tipo = cmbMovimientos.SelectedItem != null ? cmbMovimientos.SelectedItem.ToString() : "- Todos -";
                string criterio = cmbBuscarPor.SelectedItem != null ? cmbBuscarPor.SelectedItem.ToString() : "";
                string valor = _txtFiltro != null ? _txtFiltro.Text.Trim() : "";

                DataTable dt = VentaDAL.ObtenerMovimientosInventario(dtpDelDia.Value.Date, tipo, criterio, valor);

                dgvMovimientos.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    DateTime fecha = row["fecha_movimiento"] != DBNull.Value
                        ? Convert.ToDateTime(row["fecha_movimiento"], CultureInfo.InvariantCulture)
                        : DateTime.MinValue;

                    string hora = fecha != DateTime.MinValue ? fecha.ToString("hh:mm tt") : "";
                    string producto = row["producto"] != DBNull.Value ? row["producto"].ToString() : "";
                    string tipoMov = row["tipo_movimiento"] != DBNull.Value ? row["tipo_movimiento"].ToString() : "";
                    string referencia = row["referencia"] != DBNull.Value ? row["referencia"].ToString() : "";
                    string cantidad = row["cantidad"] != DBNull.Value ? Convert.ToDecimal(row["cantidad"]).ToString("0.##") : "0";
                    string departamento = row["departamento"] != DBNull.Value ? row["departamento"].ToString() : "";
                    string cajero = row["cajero"] != DBNull.Value ? row["cajero"].ToString() : "";

                    string movimientoTexto = referencia;
                    if (!string.IsNullOrWhiteSpace(referencia) && referencia.StartsWith("VENTA_", StringComparison.OrdinalIgnoreCase))
                    {
                        string idVentaStr = referencia.Substring(6);
                        if (int.TryParse(idVentaStr, out int idVenta))
                            movimientoTexto = "Venta #" + idVenta;
                    }

                    dgvMovimientos.Rows.Add(
                        hora,
                        producto,
                        movimientoTexto,
                        "",
                        tipoMov,
                        cantidad,
                        "",
                        cajero,
                        departamento
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando movimientos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
