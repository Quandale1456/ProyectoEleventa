using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    public partial class FrmReporteVentas : Form
    {
        public FrmReporteVentas()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            linkSemanaActual.LinkClicked += (s, e) => AplicarSemanaActual();
            linkMesActual.LinkClicked += (s, e) => AplicarMesActual();
            linkMesAnterior.LinkClicked += (s, e) => AplicarMesAnterior();
            linkAnoActual.LinkClicked += (s, e) => AplicarAnoActual();
            linkPeriodo.LinkClicked += (s, e) => ActivarPeriodo();

            dtpDesde.ValueChanged += (s, e) => { if (pnlPeriodo.Enabled) Refrescar(); };
            dtpHasta.ValueChanged += (s, e) => { if (pnlPeriodo.Enabled) Refrescar(); };

            ConfigurarCharts();
            AplicarSemanaActual();
        }

        private void ConfigurarCharts()
        {
            chartDept.Series.Clear();
            chartDept.ChartAreas.Clear();
            chartDept.ChartAreas.Add(new ChartArea("area"));
            var sDept = new Series("Ventas")
            {
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = false
            };
            chartDept.Series.Add(sDept);
            chartDept.Legends.Clear();
            chartDept.Legends.Add(new Legend());

            chartGanancia.Series.Clear();
            chartGanancia.ChartAreas.Clear();
            chartGanancia.ChartAreas.Add(new ChartArea("area"));
            var sGan = new Series("Ganancia")
            {
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = false
            };
            chartGanancia.Series.Add(sGan);
            chartGanancia.Legends.Clear();
            chartGanancia.Legends.Add(new Legend());

            chartPago.Series.Clear();
            chartPago.ChartAreas.Clear();
            chartPago.ChartAreas.Add(new ChartArea("area"));
            chartPago.Legends.Clear();
            chartPago.Legends.Add(new Legend());
        }

        private static DateTime InicioDia(DateTime d) => new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
        private static DateTime FinDia(DateTime d) => new DateTime(d.Year, d.Month, d.Day, 23, 59, 59);

        private void AplicarSemanaActual()
        {
            pnlPeriodo.Enabled = false;
            var today = DateTime.Today;
            var diff = (7 + (int)today.DayOfWeek - (int)DayOfWeek.Monday) % 7;
            var monday = today.AddDays(-diff);
            dtpDesde.Value = monday;
            dtpHasta.Value = today;
            Refrescar();
        }

        private void AplicarMesActual()
        {
            pnlPeriodo.Enabled = false;
            var today = DateTime.Today;
            var first = new DateTime(today.Year, today.Month, 1);
            var last = first.AddMonths(1).AddDays(-1);
            dtpDesde.Value = first;
            dtpHasta.Value = last;
            Refrescar();
        }

        private void AplicarMesAnterior()
        {
            pnlPeriodo.Enabled = false;
            var today = DateTime.Today;
            var first = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
            var last = first.AddMonths(1).AddDays(-1);
            dtpDesde.Value = first;
            dtpHasta.Value = last;
            Refrescar();
        }

        private void AplicarAnoActual()
        {
            pnlPeriodo.Enabled = false;
            var today = DateTime.Today;
            var first = new DateTime(today.Year, 1, 1);
            var last = new DateTime(today.Year, 12, 31);
            dtpDesde.Value = first;
            dtpHasta.Value = last;
            Refrescar();
        }

        private void ActivarPeriodo()
        {
            pnlPeriodo.Enabled = true;
            Refrescar();
        }

        private void Refrescar()
        {
            var desde = InicioDia(dtpDesde.Value);
            var hasta = FinDia(dtpHasta.Value);

            lblHeader.Text = $"RESUMEN DE VENTAS DEL {desde:dd/MMM/yyyy} AL {hasta:dd/MMM/yyyy}".ToUpperInvariant();

            CargarVentasPorTiempo(desde, hasta);
            CargarVentasPorDepartamento(desde, hasta);
            CargarVentasPorPago(desde, hasta);
            CargarGananciaPorDepartamento(desde, hasta);
            CargarImpuestos(desde, hasta);
        }

        private void CargarVentasPorTiempo(DateTime desde, DateTime hasta)
        {
            lstTiempo.Items.Clear();

            DataTable dt;
            var days = (hasta.Date - desde.Date).TotalDays;
            if (days <= 31)
            {
                lblTituloTiempo.Text = "Ventas por día";
                dt = ReporteVentasDAL.ObtenerVentasPorDia(desde, hasta);

                decimal total = 0m;
                foreach (DataRow row in dt.Rows)
                {
                    var dia = row["dia_semana"]?.ToString() ?? "";
                    var monto = row["total"] != DBNull.Value ? Convert.ToDecimal(row["total"]) : 0m;
                    total += monto;
                    lstTiempo.Items.Add(new ListViewItem(new[] { Capitalizar(dia), monto.ToString("$0.00") }));
                }
                lblTotalTiempo.Text = total.ToString("$0.00");
            }
            else
            {
                lblTituloTiempo.Text = "Ventas por mes";
                dt = ReporteVentasDAL.ObtenerVentasPorMes(desde, hasta);

                decimal total = 0m;
                foreach (DataRow row in dt.Rows)
                {
                    var mes = row["mes_nombre"]?.ToString() ?? "";
                    var monto = row["total"] != DBNull.Value ? Convert.ToDecimal(row["total"]) : 0m;
                    total += monto;
                    lstTiempo.Items.Add(new ListViewItem(new[] { Capitalizar(mes), monto.ToString("$0.00") }));
                }
                lblTotalTiempo.Text = total.ToString("$0.00");
            }
        }

        private void CargarVentasPorDepartamento(DateTime desde, DateTime hasta)
        {
            lstDept.Items.Clear();
            var dt = ReporteVentasDAL.ObtenerVentasPorDepartamento(desde, hasta);

            chartDept.Series[0].Points.Clear();

            foreach (DataRow row in dt.Rows)
            {
                var dept = row["departamento"]?.ToString() ?? "Sin departamento";
                var total = row["total"] != DBNull.Value ? Convert.ToDecimal(row["total"]) : 0m;
                lstDept.Items.Add(new ListViewItem(new[] { dept, total.ToString("$0.00") }));

                var p = chartDept.Series[0].Points.AddY((double)total);
                chartDept.Series[0].Points[p].LegendText = $"{dept} ({total.ToString("$0.00")})";
                chartDept.Series[0].Points[p].Label = string.Empty;
            }

            lblSinDept.Visible = dt.Rows.Count == 0;
        }

        private void CargarVentasPorPago(DateTime desde, DateTime hasta)
        {
            lstPago.Items.Clear();
            var dt = ReporteVentasDAL.ObtenerVentasPorFormaPago(desde, hasta);

            chartPago.Series.Clear();

            var serie = new Series("Ventas")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = false
            };
            chartPago.Series.Add(serie);
            chartPago.ChartAreas[0].AxisX.Interval = 1;

            foreach (DataRow row in dt.Rows)
            {
                var metodo = row["metodo_pago"]?.ToString() ?? "";
                var total = row["total"] != DBNull.Value ? Convert.ToDecimal(row["total"]) : 0m;

                lstPago.Items.Add(new ListViewItem(new[] { metodo, total.ToString("$0.00") }));
                serie.Points.AddXY(metodo, (double)total);
            }

            lblSinPago.Visible = dt.Rows.Count == 0;
        }

        private void CargarGananciaPorDepartamento(DateTime desde, DateTime hasta)
        {
            lstGanancia.Items.Clear();
            var dt = ReporteVentasDAL.ObtenerGananciaPorDepartamento(desde, hasta);

            chartGanancia.Series[0].Points.Clear();

            foreach (DataRow row in dt.Rows)
            {
                var dept = row["departamento"]?.ToString() ?? "Sin departamento";
                var total = row["ganancia"] != DBNull.Value ? Convert.ToDecimal(row["ganancia"]) : 0m;
                lstGanancia.Items.Add(new ListViewItem(new[] { dept, total.ToString("$0.00") }));

                var p = chartGanancia.Series[0].Points.AddY((double)total);
                chartGanancia.Series[0].Points[p].LegendText = $"{dept} ({total.ToString("$0.00")})";
                chartGanancia.Series[0].Points[p].Label = string.Empty;
            }

            lblSinGanancia.Visible = dt.Rows.Count == 0;
        }

        private void CargarImpuestos(DateTime desde, DateTime hasta)
        {
            var imp = ReporteVentasDAL.ObtenerImpuestos(desde, hasta);
            lblImpuestosValor.Text = imp > 0 ? imp.ToString("$0.00") : "- No se registró ninguna venta -";
        }

        private static string Capitalizar(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;

            try
            {
                var ti = CultureInfo.CurrentCulture.TextInfo;
                return ti.ToTitleCase(input.ToLower());
            }
            catch
            {
                return input;
            }
        }
    }
}
