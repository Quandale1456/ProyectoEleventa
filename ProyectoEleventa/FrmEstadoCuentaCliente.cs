using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    public partial class FrmEstadoCuentaCliente : Form
    {
        private readonly int _idCliente;

        public FrmEstadoCuentaCliente(int idCliente)
        {
            _idCliente = idCliente;
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            CargarCliente();
            CargarSaldo();
            ConfigurarGrid();
            CargarMovimientos();
        }

        private void CargarCliente()
        {
            var row = ClienteDAL.ObtenerPorId(_idCliente);
            if (row == null)
            {
                lblCliente.Text = "Cliente";
                return;
            }

            var nombre = row.Table.Columns.Contains("nombre") ? (row["nombre"]?.ToString() ?? "") : "";
            var apellidos = row.Table.Columns.Contains("apellidos") ? (row["apellidos"]?.ToString() ?? "") : "";
            var display = (nombre + " " + apellidos).Trim();
            if (string.IsNullOrWhiteSpace(display))
            {
                display = "Cliente";
            }

            lblCliente.Text = display;
        }

        private void CargarSaldo()
        {
            var saldo = ClienteCreditoDAL.ObtenerSaldoActual(_idCliente);
            lblSaldo.Text = saldo.ToString("$0.00");
        }

        private void ConfigurarGrid()
        {
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.MultiSelect = false;
            dgvMovimientos.RowHeadersVisible = false;

            dgvMovimientos.Columns.Clear();
            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha/Hora", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Folio", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Movimiento", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Monto", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Saldo actual", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cajero", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });

            lblSinMovimientos.Visible = true;
        }

        private void CargarMovimientos()
        {
            DataTable dt = ClienteCreditoDAL.ObtenerMovimientosCredito(_idCliente);
            dgvMovimientos.Rows.Clear();

            if (dt == null || dt.Rows.Count == 0)
            {
                lblSinMovimientos.Visible = true;
                return;
            }

            lblSinMovimientos.Visible = false;

            foreach (DataRow row in dt.Rows)
            {
                var fecha = row.Table.Columns.Contains("fecha_hora") && row["fecha_hora"] != DBNull.Value
                    ? Convert.ToDateTime(row["fecha_hora"]).ToString("g")
                    : string.Empty;
                var folio = row.Table.Columns.Contains("folio") ? row["folio"]?.ToString() ?? string.Empty : string.Empty;
                var mov = row.Table.Columns.Contains("movimiento") ? row["movimiento"]?.ToString() ?? string.Empty : string.Empty;

                var monto = row.Table.Columns.Contains("monto") && row["monto"] != DBNull.Value
                    ? Convert.ToDecimal(row["monto"]).ToString("$0.00")
                    : "$0.00";
                var saldo = row.Table.Columns.Contains("saldo_actual") && row["saldo_actual"] != DBNull.Value
                    ? Convert.ToDecimal(row["saldo_actual"]).ToString("$0.00")
                    : "$0.00";
                var cajero = row.Table.Columns.Contains("cajero") ? row["cajero"]?.ToString() ?? string.Empty : string.Empty;

                dgvMovimientos.Rows.Add(fecha, folio, mov, monto, saldo, cajero);
            }
        }
    }
}
