using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    public partial class FrmVentasPorCliente : Form
    {
        public FrmVentasPorCliente()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.5f, FontStyle.Bold);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 92, 124);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.RowTemplate.Height = 42;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.CellPainting += dgv_CellPainting;
            dgv.CellFormatting += dgv_CellFormatting;

            dgv.Columns.Clear();

            var colAvatar = new DataGridViewTextBoxColumn
            {
                Name = "avatar",
                HeaderText = "",
                Width = 40,
                DataPropertyName = "avatar"
            };
            colAvatar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colAvatar.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
            colAvatar.DefaultCellStyle.BackColor = Color.White;
            dgv.Columns.Add(colAvatar);

            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "folio", HeaderText = "Folio", Width = 50, DataPropertyName = "folio" });

            var colNombre = new DataGridViewTextBoxColumn
            {
                Name = "nombre",
                HeaderText = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "nombre_cliente"
            };
            colNombre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(colNombre);

            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "numVentas", HeaderText = "Número de ventas", Width = 110, DataPropertyName = "numero_ventas" });

            var colAcumVentas = new DataGridViewTextBoxColumn { Name = "acumVentas", HeaderText = "Acumulado Ventas", Width = 120, DataPropertyName = "acumulado_ventas" };
            colAcumVentas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colAcumVentas.DefaultCellStyle.Format = "C2";
            dgv.Columns.Add(colAcumVentas);

            var colAcumGan = new DataGridViewTextBoxColumn { Name = "acumGan", HeaderText = "Acumulado Ganancia", Width = 130, DataPropertyName = "acumulado_ganancia" };
            colAcumGan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colAcumGan.DefaultCellStyle.Format = "C2";
            dgv.Columns.Add(colAcumGan);

            btnExportar.Click += btnExportar_Click;

            Cargar();
        }

        public void Cargar(DateTime? desde = null, DateTime? hasta = null)
        {
            DateTime d;
            DateTime h;

            if (desde.HasValue && hasta.HasValue)
            {
                d = desde.Value;
                h = hasta.Value;
            }
            else
            {
                var rango = ReporteVentasDAL.ObtenerRangoFechasVentas();
                if (rango != null && rango.Table.Columns.Contains("min_fecha") && rango.Table.Columns.Contains("max_fecha")
                    && rango["min_fecha"] != DBNull.Value && rango["max_fecha"] != DBNull.Value)
                {
                    d = Convert.ToDateTime(rango["min_fecha"]).Date;
                    h = Convert.ToDateTime(rango["max_fecha"]).Date.AddDays(1).AddSeconds(-1);
                }
                else
                {
                    d = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    h = DateTime.Today.AddDays(1).AddSeconds(-1);
                }
            }

            DataTable dt = ReporteVentasDAL.ObtenerVentasPorCliente(d, h);
            if (dt.Rows.Count == 0 && !desde.HasValue && !hasta.HasValue)
            {
                dt = ReporteVentasDAL.ObtenerVentasPorCliente(new DateTime(1753, 1, 1), DateTime.Today.AddDays(1).AddSeconds(-1));
            }

            if (!dt.Columns.Contains("folio"))
            {
                dt.Columns.Add("folio", typeof(int));
            }
            if (!dt.Columns.Contains("avatar"))
            {
                dt.Columns.Add("avatar", typeof(string));
            }

            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                row["folio"] = i++;
                var nombre = row.Table.Columns.Contains("nombre_cliente") ? (row["nombre_cliente"]?.ToString() ?? "") : string.Empty;
                row["avatar"] = ObtenerIniciales(nombre);
            }

            dgv.DataSource = dt;

            lblSinDatos.Visible = dt.Rows.Count == 0;
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dgv.Columns[e.ColumnIndex];
            if (col.Name == "nombre")
            {
                if (dgv.Rows[e.RowIndex].DataBoundItem is DataRowView drv)
                {
                    var nombre = drv.Row.Table.Columns.Contains("nombre_cliente") ? (drv.Row["nombre_cliente"]?.ToString() ?? "") : "";
                    var idCliente = drv.Row.Table.Columns.Contains("id_cliente") ? drv.Row["id_cliente"]?.ToString() ?? "" : "";
                    if (!string.IsNullOrWhiteSpace(idCliente))
                    {
                        e.Value = nombre + Environment.NewLine + "ID: " + idCliente;
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dgv.Columns[e.ColumnIndex];
            if (col.Name != "avatar") return;

            e.Handled = true;
            e.PaintBackground(e.ClipBounds, true);

            var initials = e.FormattedValue?.ToString() ?? string.Empty;

            var diameter = Math.Min(e.CellBounds.Width, e.CellBounds.Height) - 10;
            if (diameter < 10) diameter = Math.Min(e.CellBounds.Width, e.CellBounds.Height);

            var x = e.CellBounds.X + (e.CellBounds.Width - diameter) / 2;
            var y = e.CellBounds.Y + (e.CellBounds.Height - diameter) / 2;
            var rect = new Rectangle(x, y, diameter, diameter);

            Color back = Color.FromArgb(86, 92, 124);
            using (var b = new SolidBrush(back))
            using (var p = new Pen(back))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(b, rect);
                e.Graphics.DrawEllipse(p, rect);
            }

            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            using (var fb = new SolidBrush(Color.White))
            {
                e.Graphics.DrawString(initials, new Font("Microsoft Sans Serif", 9f, FontStyle.Bold), fb, rect, sf);
            }

            e.Paint(e.CellBounds, DataGridViewPaintParts.Border);
        }

        private static string ObtenerIniciales(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return "";
            var parts = nombre.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1)
            {
                return parts[0].Substring(0, Math.Min(2, parts[0].Length)).ToUpperInvariant();
            }
            var a = parts[0].Substring(0, 1);
            var b = parts[1].Substring(0, 1);
            return (a + b).ToUpperInvariant();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            var dt = dgv.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "ventas_por_cliente.csv";

                if (sfd.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("Folio,Nombre,Número de ventas,Acumulado Ventas,Acumulado Ganancia");

                    foreach (DataRow row in dt.Rows)
                    {
                        var folio = row["folio"]?.ToString() ?? "";
                        var nombre = row["nombre_cliente"]?.ToString() ?? "";
                        var numVentas = row["numero_ventas"]?.ToString() ?? "0";
                        var acumVentas = row["acumulado_ventas"] != DBNull.Value ? Convert.ToDecimal(row["acumulado_ventas"]).ToString("0.00") : "0.00";
                        var acumGan = row["acumulado_ganancia"] != DBNull.Value ? Convert.ToDecimal(row["acumulado_ganancia"]).ToString("0.00") : "0.00";

                        sb.AppendLine($"{folio},\"{nombre.Replace("\"", "\"\"")}\",{numVentas},{acumVentas},{acumGan}");
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Exportado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exportando: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
