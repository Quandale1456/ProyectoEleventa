using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoEleventa
{
    public partial class FrmCorteCajero : Form
    {
        public FrmCorteCajero()
        {
            InitializeComponent();
            ConfigurarEstilos();
            CargarDatosEjemplo();
        }

        private void ConfigurarEstilos()
        {
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;

            panelHeader.BackColor = Color.FromArgb(22, 77, 63);
            lblTitulo.ForeColor = Color.White;

            btnCorteCajero.BackColor = Color.FromArgb(243, 243, 243);
            btnCorteCajero.FlatStyle = FlatStyle.Flat;
            btnCorteCajero.FlatAppearance.BorderColor = Color.FromArgb(210, 210, 210);

            btnCorteDelDia.BackColor = Color.FromArgb(243, 243, 243);
            btnCorteDelDia.FlatStyle = FlatStyle.Flat;
            btnCorteDelDia.FlatAppearance.BorderColor = Color.FromArgb(210, 210, 210);

            btnImprimir.BackColor = Color.FromArgb(243, 243, 243);
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.FlatAppearance.BorderColor = Color.FromArgb(210, 210, 210);

            btnCerrarTurno.BackColor = Color.FromArgb(243, 243, 243);
            btnCerrarTurno.FlatStyle = FlatStyle.Flat;
            btnCerrarTurno.FlatAppearance.BorderColor = Color.FromArgb(210, 210, 210);

            lblVentasTotalesValor.ForeColor = Color.FromArgb(0, 102, 204);
            lblGananciaValor.ForeColor = Color.FromArgb(0, 102, 204);

            lblCorteTitulo.ForeColor = Color.FromArgb(70, 70, 70);
            lblCorteNombre.ForeColor = Color.FromArgb(0, 102, 204);
            lblCorteFecha.ForeColor = Color.FromArgb(0, 102, 204);
            lblTurnoActual.ForeColor = Color.FromArgb(90, 90, 90);

            foreach (Control c in new Control[]
            {
                groupDineroCaja,
                groupEntradasEfectivo,
                groupVentasDepartamento,
                groupVentas,
                groupIngresosContado,
                groupSalidasEfectivo,
                groupPagosCreditos,
                groupClientesMasVentas,
                groupClientesMasGanancia,
            })
            {
                if (c is GroupBox gb)
                {
                    gb.ForeColor = Color.FromArgb(55, 55, 55);
                    gb.BackColor = Color.White;
                    gb.Padding = new Padding(10);
                }
            }

            panelContenido.BackColor = Color.White;
            panelColIzq.BackColor = Color.White;
            panelColDer.BackColor = Color.White;
        }

        private void CargarDatosEjemplo()
        {
            lblCorteNombre.Text = "--";
            lblCorteFecha.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblTurnoActual.Text = "De -- a -- - (Turno Actual)";

            decimal ventasTotales = 0.00m;
            decimal ganancia = 0.00m;

            lblVentasTotalesValor.Text = ventasTotales.ToString("C2");
            lblGananciaValor.Text = ganancia.ToString("C2");

            SetMoneyLabel(lblFondoCajaValor, 0.00m);
            SetMoneyLabel(lblVentasEfectivoValor, 0.00m);
            SetMoneyLabel(lblAbonosEfectivoValor, 0.00m);
            SetMoneyLabel(lblEntradasValor, 0.00m);
            SetMoneyLabel(lblSalidasValor, 0.00m);
            SetMoneyLabel(lblDevolucionesEfectivoValor, 0.00m);
            SetMoneyLabel(lblTotalFinalValor, 0.00m);

            SetMoneyLabel(lblVentaEfectivoValor, 0.00m);
            SetMoneyLabel(lblTarjetaCreditoValor, 0.00m);
            SetMoneyLabel(lblACreditoValor, 0.00m);
            SetMoneyLabel(lblValesDespensaValor, 0.00m);
            SetMoneyLabel(lblTransferenciaValor, 0.00m);
            SetMoneyLabel(lblChequeValor, 0.00m);
            SetMoneyLabel(lblDevolucionesVentasValor, 0.00m);
            SetMoneyLabel(lblVentasTotalValor, 0.00m);

            lblNoEntradasEfectivo.Text = "- No hubo Entradas en Efectivo -";
            lblNoVentasDepartamento.Text = "- No se registró ninguna venta -";
            lblNoIngresosContado.Text = "- No hubo ingresos de contado -";
            lblNoSalidasEfectivo.Text = "- No hubo Salidas en Efectivo -";
            lblNoPagosCreditos.Text = "- No se recibieron pagos de créditos -";
            lblNoClientesMasVentas.Text = "- No hubo ventas -";
            lblNoClientesMasGanancia.Text = "- No hubo ventas -";
        }

        private void SetMoneyLabel(Label label, decimal value)
        {
            label.Text = value.ToString("C2");

            if (value > 0)
            {
                label.ForeColor = Color.FromArgb(0, 140, 60);
            }
            else if (value < 0)
            {
                label.ForeColor = Color.FromArgb(200, 40, 40);
            }
            else
            {
                label.ForeColor = Color.FromArgb(70, 70, 70);
            }
        }

        private void btnCerrarTurno_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de impresión pendiente.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCorteCajero_Click(object sender, EventArgs e)
        {
            CargarDatosEjemplo();
        }

        private void btnCorteDelDia_Click(object sender, EventArgs e)
        {
            Control parent = this.Parent;
            if (parent == null)
            {
                using (var f = new FrmCorteDelDia())
                {
                    f.ShowDialog(this);
                }
                return;
            }

            var childForm = new FrmCorteDelDia();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            parent.Controls.Add(childForm);
            parent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.Close();
        }
    }
}
