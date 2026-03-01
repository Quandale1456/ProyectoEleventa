using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    public partial class FrmReporteSaldos : Form
    {
        private readonly BindingSource _bs = new BindingSource();

        public FrmReporteSaldos()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            dgvReporte.AutoGenerateColumns = false;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.MultiSelect = false;
            dgvReporte.ReadOnly = true;
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.AllowUserToDeleteRows = false;
            dgvReporte.RowHeadersVisible = false;

            dgvReporte.Columns.Clear();
            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "id_cliente", HeaderText = "Número", Width = 60 });
            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "nombre_cliente", HeaderText = "Nombre / Dirección del Cliente", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "telefono", HeaderText = "Teléfono", Width = 120 });
            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "limite_credito", HeaderText = "Límite de Crédito", Width = 120 });
            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "saldo_actual", HeaderText = "Saldo Actual", Width = 120 });
            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ultimo_pago", HeaderText = "Último Pago", Width = 120 });

            dgvReporte.DataSource = _bs;
            btnImprimir.Click += btnImprimir_Click;

            Cargar();
        }

        private void Cargar()
        {
            DataTable dt = ClienteCreditoDAL.ObtenerReporteSaldos();
            _bs.DataSource = dt;

            decimal total = 0m;
            if (dt != null && dt.Columns.Contains("saldo_actual"))
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["saldo_actual"] != DBNull.Value)
                    {
                        total += Convert.ToDecimal(row["saldo_actual"]);
                    }
                }
            }

            lblTotal.Text = total.ToString("$0.00");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Impresión pendiente de implementar.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
