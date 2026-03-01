using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ProyectoEleventa
{
    public partial class FrmCobrarVenta : Form
    {
        public string MetodoPagoSeleccionado { get; private set; } = "Efectivo";
        public bool ImprimirTicket { get; private set; }
        public string Referencia { get; private set; }
        public string Telefono { get; private set; }
        public string Notas { get; private set; }

        public decimal MontoEfectivo { get; private set; }
        public decimal MontoCredito { get; private set; }
        public decimal MontoTransferencia { get; private set; }

        private readonly decimal _total;
        private readonly int _articulos;
        private readonly bool _tieneCliente;

        public FrmCobrarVenta(decimal total, int articulos, bool tieneCliente)
        {
            _total = total;
            _articulos = articulos;
            _tieneCliente = tieneCliente;
            InitializeComponent();
        }

        private void FrmCobrarVenta_Load(object sender, EventArgs e)
        {
            lblTotal.Text = _total.ToString("C2", CultureInfo.CurrentCulture);
            lblTotalArticulos.Text = _articulos.ToString();

            chkImprimirVoucher.Checked = true;
            chkImprimirDatosCliente.Checked = true;
            chkImprimirDatosCliente.Visible = _tieneCliente;

            SeleccionarMetodo("Efectivo");
            ActualizarUI();
            txtPagoCon.Text = _total.ToString("0.00");
            txtPagoCon.SelectAll();
            txtPagoCon.Focus();
        }

        private void FrmCobrarVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            if (e.KeyCode == Keys.F1)
            {
                ImprimirTicket = true;
                IntentarCobrar();
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.F2)
            {
                ImprimirTicket = false;
                IntentarCobrar();
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.F4)
            {
                ToggleNotas();
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Return)
            {
                ImprimirTicket = false;
                IntentarCobrar();
                e.Handled = true;
            }
        }

        private void btnEfectivo_Click(object sender, EventArgs e) => SeleccionarMetodo("Efectivo");
        private void btnCredito_Click(object sender, EventArgs e) => SeleccionarMetodo("Crédito");
        private void btnMixto_Click(object sender, EventArgs e) => SeleccionarMetodo("Mixto");
        private void btnTransferencia_Click(object sender, EventArgs e) => SeleccionarMetodo("Transferencia");

        private void SeleccionarMetodo(string metodo)
        {
            MetodoPagoSeleccionado = metodo;

            btnEfectivo.BackColor = metodo == "Efectivo" ? Color.FromArgb(70, 130, 180) : SystemColors.Control;
            btnCredito.BackColor = metodo == "Crédito" ? Color.FromArgb(70, 130, 180) : SystemColors.Control;
            btnMixto.BackColor = metodo == "Mixto" ? Color.FromArgb(70, 130, 180) : SystemColors.Control;
            btnTransferencia.BackColor = metodo == "Transferencia" ? Color.FromArgb(70, 130, 180) : SystemColors.Control;

            btnEfectivo.ForeColor = metodo == "Efectivo" ? Color.White : SystemColors.ControlText;
            btnCredito.ForeColor = metodo == "Crédito" ? Color.White : SystemColors.ControlText;
            btnMixto.ForeColor = metodo == "Mixto" ? Color.White : SystemColors.ControlText;
            btnTransferencia.ForeColor = metodo == "Transferencia" ? Color.White : SystemColors.ControlText;

            ActualizarUI();
        }

        private void ActualizarUI()
        {
            panelEfectivo.Visible = MetodoPagoSeleccionado == "Efectivo";
            panelTransferencia.Visible = MetodoPagoSeleccionado == "Transferencia";
            panelMixto.Visible = MetodoPagoSeleccionado == "Mixto";
            panelCredito.Visible = MetodoPagoSeleccionado == "Crédito";

            if (panelMixto.Visible)
            {
                txtMixtoEfectivo.Text = _total.ToString("0.00");
                txtMixtoCredito.Text = "0.00";
                txtMixtoTransferencia.Text = "0.00";
                ActualizarRestanteMixto();
                txtMixtoEfectivo.SelectAll();
                txtMixtoEfectivo.Focus();
            }

            if (panelTransferencia.Visible)
            {
                txtReferencia.Focus();
            }

            if (panelCredito.Visible)
            {
                lblCreditoSinCliente.Visible = !_tieneCliente;
            }
        }

        private void txtPagoCon_TextChanged(object sender, EventArgs e)
        {
            ActualizarCambio();
        }

        private void ActualizarCambio()
        {
            var pagoCon = ParseDecimal(txtPagoCon.Text);
            var cambio = pagoCon - _total;
            if (cambio < 0) cambio = 0;
            lblCambio.Text = cambio.ToString("C2", CultureInfo.CurrentCulture);
        }

        private void txtMixto_TextChanged(object sender, EventArgs e)
        {
            ActualizarRestanteMixto();
        }

        private void ActualizarRestanteMixto()
        {
            var ef = ParseDecimal(txtMixtoEfectivo.Text);
            var cr = ParseDecimal(txtMixtoCredito.Text);
            var tr = ParseDecimal(txtMixtoTransferencia.Text);
            var restante = _total - (ef + cr + tr);
            if (restante < 0) restante = 0;
            lblMixtoRestante.Text = restante.ToString("C2", CultureInfo.CurrentCulture);
        }

        private void btnCobrarImprimir_Click(object sender, EventArgs e)
        {
            ImprimirTicket = true;
            IntentarCobrar();
        }

        private void btnCobrarSinImprimir_Click(object sender, EventArgs e)
        {
            ImprimirTicket = false;
            IntentarCobrar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            ToggleNotas();
        }

        private void ToggleNotas()
        {
            txtNotas.Visible = !txtNotas.Visible;
            if (txtNotas.Visible)
            {
                txtNotas.Focus();
            }
        }

        private void IntentarCobrar()
        {
            Referencia = txtReferencia.Text.Trim();
            Telefono = txtTelefono.Text.Trim();
            Notas = txtNotas.Text.Trim();

            if (MetodoPagoSeleccionado == "Efectivo")
            {
                var pagoCon = ParseDecimal(txtPagoCon.Text);
                if (pagoCon < _total)
                {
                    MessageBox.Show("El monto recibido es menor al total.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPagoCon.Focus();
                    return;
                }

                MontoEfectivo = _total;
                MontoCredito = 0;
                MontoTransferencia = 0;
            }
            else if (MetodoPagoSeleccionado == "Transferencia")
            {
                if (string.IsNullOrWhiteSpace(Referencia))
                {
                    MessageBox.Show("Ingrese una referencia.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReferencia.Focus();
                    return;
                }

                MontoEfectivo = 0;
                MontoCredito = 0;
                MontoTransferencia = _total;
            }
            else if (MetodoPagoSeleccionado == "Crédito")
            {
                MontoEfectivo = 0;
                MontoCredito = _total;
                MontoTransferencia = 0;
            }
            else if (MetodoPagoSeleccionado == "Mixto")
            {
                var ef = ParseDecimal(txtMixtoEfectivo.Text);
                var cr = ParseDecimal(txtMixtoCredito.Text);
                var tr = ParseDecimal(txtMixtoTransferencia.Text);

                if (ef < 0 || cr < 0 || tr < 0)
                {
                    MessageBox.Show("Los montos no pueden ser negativos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if ((ef + cr + tr) < _total)
                {
                    MessageBox.Show("La suma de montos es menor al total.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MontoEfectivo = ef;
                MontoCredito = cr;
                MontoTransferencia = tr;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private static decimal ParseDecimal(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0m;

            decimal v;
            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out v)) return v;
            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out v)) return v;
            return 0m;
        }
    }
}
