using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoEleventa
{
    public partial class FrmCorteCaja : Form
    {
        public FrmCorteCaja()
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

            btnImprimir.BackColor = Color.FromArgb(243, 243, 243);
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.FlatAppearance.BorderColor = Color.FromArgb(210, 210, 210);

            btnCerrarTurno.BackColor = Color.FromArgb(243, 243, 243);
            btnCerrarTurno.FlatStyle = FlatStyle.Flat;
            btnCerrarTurno.FlatAppearance.BorderColor = Color.FromArgb(210, 210, 210);

            btnCorteCajero.BackColor = Color.FromArgb(243, 243, 243);
            btnCorteCajero.FlatStyle = FlatStyle.Flat;
            btnCorteCajero.FlatAppearance.BorderColor = Color.FromArgb(210, 210, 210);

            btnCorteDelDia.BackColor = Color.FromArgb(243, 243, 243);
            btnCorteDelDia.FlatStyle = FlatStyle.Flat;
            btnCorteDelDia.FlatAppearance.BorderColor = Color.FromArgb(210, 210, 210);

            lblVentasTotalesTitulo.ForeColor = Color.FromArgb(60, 60, 60);
            lblGananciaTitulo.ForeColor = Color.FromArgb(60, 60, 60);

            lblVentasTotalesValor.ForeColor = Color.FromArgb(0, 102, 204);
            lblGananciaValor.ForeColor = Color.FromArgb(0, 102, 204);

            foreach (Control c in new Control[]
            {
                groupDineroCaja,
                groupEntradasEfectivo,
                groupVentasDepartamento,
                groupImpuestos,
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
            decimal ventasTotales = 12850.75m;
            decimal ganancia = 3120.20m;

            lblVentasTotalesValor.Text = ventasTotales.ToString("C2");
            lblGananciaValor.Text = ganancia.ToString("C2");

            SetMoneyLabel(lblFondoCajaValor, 500.00m);
            SetMoneyLabel(lblVentasEfectivoValor, 9850.50m);
            SetMoneyLabel(lblAbonosEfectivoValor, 650.00m);
            SetMoneyLabel(lblEntradasValor, 120.00m);
            SetMoneyLabel(lblSalidasValor, -80.00m);
            SetMoneyLabel(lblDevolucionesEfectivoValor, -35.00m);
            SetMoneyLabel(lblTotalFinalValor, 11005.50m);

            SetMoneyLabel(lblVentaEfectivoValor, 9850.50m);
            SetMoneyLabel(lblTarjetaCreditoValor, 2500.25m);
            SetMoneyLabel(lblACreditoValor, 500.00m);
            SetMoneyLabel(lblValesDespensaValor, 0.00m);
            SetMoneyLabel(lblTransferenciaValor, 0.00m);
            SetMoneyLabel(lblChequeValor, 0.00m);
            SetMoneyLabel(lblDevolucionesVentasValor, -35.00m);
            SetMoneyLabel(lblVentasTotalValor, 12815.75m);

            lblNoEntradasEfectivo.Text = "No hubo entradas en efectivo.";
            lblNoVentasDepartamento.Text = "No se registró ninguna venta.";
            lblNoImpuestos.Text = "No hubo ventas.";

            lblNoIngresosContado.Text = "No hubo ingresos de contado.";
            lblNoSalidasEfectivo.Text = "No hubo salidas en efectivo.";
            lblNoPagosCreditos.Text = "No se recibieron pagos de créditos.";
            lblNoClientesMasVentas.Text = "No hubo ventas.";
            lblNoClientesMasGanancia.Text = "No hubo ventas.";
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
            MessageBox.Show("Vista: Corte de cajero (ejemplo).", "Corte", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCorteDelDia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vista: Corte del día (ejemplo).", "Corte", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblVentasTotalesValor_Click(object sender, EventArgs e)
        {

        }
    }
}
