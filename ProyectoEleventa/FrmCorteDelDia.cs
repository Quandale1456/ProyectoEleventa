using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Text;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    public partial class FrmCorteDelDia : Form
    {
        private readonly ServicioCorte _servicio = new ServicioCorte();
        private ResumenCorte _ultimoResumen;

        public FrmCorteDelDia()
        {
            InitializeComponent();
            ConfigurarEstilos();
            CargarCorte();
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

            lblCorteIniciadoTitulo.ForeColor = Color.FromArgb(70, 70, 70);
            lblCorteIniciadoFecha.ForeColor = Color.FromArgb(0, 102, 204);

            foreach (Control c in new Control[]
            {
                groupVentas,
                groupEntradasEfectivo,
                groupIngresosContado,
                groupVentasDepartamento,
                groupGananciaDepartamento,
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

        private void CargarCorte()
        {
            try
            {
                _ultimoResumen = _servicio.ObtenerResumenCorte(TipoCorte.Dia, null, DateTime.Now);

                lblCorteIniciadoFecha.Text = DateTime.Now.ToString("dd/MMM/yyyy");
                lblVentasTotalesValor.Text = _ultimoResumen.VentasTotalesNetas.ToString("C2");
                lblGananciaValor.Text = _ultimoResumen.GananciaTotal.ToString("C2");

                SetMoneyLabel(lblVentaEfectivoValor, _ultimoResumen.VentasEfectivo);
                SetMoneyLabel(lblTarjetaCreditoValor, _ultimoResumen.VentasTarjetaCredito);
                SetMoneyLabel(lblACreditoValor, _ultimoResumen.VentasCredito);
                SetMoneyLabel(lblValesDespensaValor, _ultimoResumen.VentasVales);
                SetMoneyLabel(lblTransferenciaValor, _ultimoResumen.VentasTransferencia);
                SetMoneyLabel(lblChequeValor, _ultimoResumen.VentasCheque);
                SetMoneyLabel(lblDevolucionesVentasValor, -_ultimoResumen.DevolucionesTotal);
                SetMoneyLabel(lblVentasTotalValor, _ultimoResumen.VentasTotalesNetas);

                lblNoEntradasEfectivo.Text = _ultimoResumen.EntradasEfectivo > 0 ? "" : "- No hubo Entradas en Efectivo -";
                lblNoIngresosContado.Text = _ultimoResumen.VentasEfectivo > 0 ? "" : "- No hubo ingresos de contado -";
                lblNoSalidasEfectivo.Text = _ultimoResumen.SalidasEfectivo > 0 ? "" : "- No hubo Salidas en Efectivo -";
                lblNoPagosCreditos.Text = _ultimoResumen.AbonosCreditoEfectivo > 0 ? "" : "- No se recibieron pagos de créditos -";

                lblNoVentasDepartamento.Text = FormatearVentasDepartamento(_ultimoResumen.VentasPorDepartamento, "total_vendido");
                lblNoGananciaDepartamento.Text = FormatearVentasDepartamento(_ultimoResumen.VentasPorDepartamento, "total_ganancia");
                lblNoClientesMasVentas.Text = FormatearTopClientes(_ultimoResumen.ClientesMasVentas, "total_ventas");
                lblNoClientesMasGanancia.Text = FormatearTopClientes(_ultimoResumen.ClientesMasGanancia, "total_ganancia");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando corte del día: {ex.Message}", "Corte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string FormatearVentasDepartamento(System.Data.DataTable dt, string col)
        {
            if (dt == null || dt.Rows.Count == 0)
                return "- No se registró ninguna venta -";

            var sb = new StringBuilder();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                var depto = row["departamento"]?.ToString() ?? "";
                var val = row.Table.Columns.Contains(col) && row[col] != DBNull.Value ? Convert.ToDecimal(row[col]) : 0m;
                sb.AppendLine($"{depto}: {val:C2}");
            }
            return sb.ToString().TrimEnd();
        }

        private static string FormatearTopClientes(System.Data.DataTable dt, string colMonto)
        {
            if (dt == null || dt.Rows.Count == 0)
                return "- No hubo ventas -";

            var sb = new StringBuilder();
            int i = 1;
            foreach (System.Data.DataRow row in dt.Rows)
            {
                var cliente = row.Table.Columns.Contains("cliente") ? (row["cliente"]?.ToString() ?? "") : (row["id_cliente"]?.ToString() ?? "");
                var monto = row.Table.Columns.Contains(colMonto) && row[colMonto] != DBNull.Value ? Convert.ToDecimal(row[colMonto]) : 0m;
                sb.AppendLine($"{i}. {cliente} - {monto:C2}");
                i++;
            }
            return sb.ToString().TrimEnd();
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
            try
            {
                if (_ultimoResumen == null)
                {
                    MessageBox.Show("Primero genera el corte.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string ticket = ConstruirTicket(_ultimoResumen);
                ImprimirTexto(ticket);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error imprimiendo: {ex.Message}", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCorteCajero_Click(object sender, EventArgs e)
        {
            Control parent = this.Parent;
            if (parent == null)
            {
                using (var f = new FrmCorteCaja())
                {
                    f.ShowDialog(this);
                }
                return;
            }

            var childForm = new FrmCorteCaja();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            parent.Controls.Add(childForm);
            parent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.Close();
        }

        private void btnCorteDelDia_Click(object sender, EventArgs e)
        {
            CargarCorte();
        }

        private static string ConstruirTicket(ResumenCorte r)
        {
            var sb = new StringBuilder();
            sb.AppendLine("CORTE DEL DIA");
            sb.AppendLine($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"Rango: {r.Desde:dd/MM HH:mm} - {r.Hasta:dd/MM HH:mm}");
            sb.AppendLine(new string('-', 32));
            sb.AppendLine($"Ventas netas: {r.VentasTotalesNetas:C2}");
            sb.AppendLine($"Ganancia:    {r.GananciaTotal:C2}");
            sb.AppendLine($"Devoluciones:{r.DevolucionesTotal:C2}");
            sb.AppendLine(new string('-', 32));
            sb.AppendLine("PAGOS");
            sb.AppendLine($"Efectivo:   {r.VentasEfectivo:C2}");
            sb.AppendLine($"Tarjeta:    {r.VentasTarjetaCredito:C2}");
            sb.AppendLine($"Crédito:    {r.VentasCredito:C2}");
            sb.AppendLine($"Vales:      {r.VentasVales:C2}");
            sb.AppendLine($"Transfer.:  {r.VentasTransferencia:C2}");
            sb.AppendLine($"Cheque:     {r.VentasCheque:C2}");
            sb.AppendLine(new string('-', 32));
            return sb.ToString();
        }

        private static void ImprimirTexto(string texto)
        {
            var doc = new PrintDocument();
            doc.DocumentName = "Corte";

            doc.PrintPage += (s, e) =>
            {
                using (var font = new Font(FontFamily.GenericMonospace, 9f))
                {
                    e.Graphics.DrawString(texto ?? string.Empty, font, Brushes.Black, e.MarginBounds);
                }
            };

            using (var dlg = new PrintPreviewDialog())
            {
                dlg.Document = doc;
                dlg.Width = 900;
                dlg.Height = 700;
                dlg.ShowDialog();
            }
        }
    }
}
