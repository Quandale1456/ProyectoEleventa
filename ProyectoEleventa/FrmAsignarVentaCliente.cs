using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    public partial class FrmAsignarVentaCliente : Form
    {
        public int? ClienteIdSeleccionado { get; private set; }
        public string ClienteNombreSeleccionado { get; private set; }
        public bool Desasignar { get; private set; }

        public FrmAsignarVentaCliente()
        {
            InitializeComponent();
        }

        private void FrmAsignarVentaCliente_Load(object sender, EventArgs e)
        {
            InicializarGrid();
            CargarClientes(string.Empty);
            txtBuscar.Focus();
        }

        private void InicializarGrid()
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
            dgv.RowTemplate.Height = 44;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgv.Columns.Clear();

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id_cliente",
                DataPropertyName = "id_cliente",
                Visible = false
            });

            var colAvatar = new DataGridViewTextBoxColumn
            {
                Name = "avatar",
                HeaderText = "",
                Width = 46,
                DataPropertyName = "avatar"
            };
            colAvatar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(colAvatar);

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "folio",
                HeaderText = "Folio",
                Width = 55,
                DataPropertyName = "folio"
            });

            var colCliente = new DataGridViewTextBoxColumn
            {
                Name = "cliente",
                HeaderText = "Cliente",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "cliente"
            };
            colCliente.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(colCliente);

            dgv.CellPainting += dgv_CellPainting;
            dgv.CellFormatting += dgv_CellFormatting;
            dgv.CellDoubleClick += (s, e) => AsignarSeleccionado();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarClientes(txtBuscar.Text.Trim());
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            AsignarSeleccionado();
        }

        private void btnDesasignar_Click(object sender, EventArgs e)
        {
            ClienteIdSeleccionado = null;
            ClienteNombreSeleccionado = null;
            Desasignar = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            using (var frm = new Clientes())
            {
                frm.ShowDialog(this);
            }
            CargarClientes(txtBuscar.Text.Trim());
        }

        private void FrmAsignarVentaCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            if (e.KeyCode == Keys.Return)
            {
                AsignarSeleccionado();
                e.Handled = true;
            }
        }

        private void AsignarSeleccionado()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var row = dgv.SelectedRows[0];
            if (row.Cells["id_cliente"].Value == null)
            {
                return;
            }

            ClienteIdSeleccionado = Convert.ToInt32(row.Cells["id_cliente"].Value);
            ClienteNombreSeleccionado = row.Cells["cliente"].Value != null ? row.Cells["cliente"].Value.ToString() : null;
            Desasignar = false;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CargarClientes(string filtro)
        {
            DataTable dt;
            if (string.IsNullOrWhiteSpace(filtro))
            {
                dt = ClienteDAL.ObtenerTodos();
            }
            else
            {
                dt = ClienteDAL.Buscar(filtro);
            }

            if (!dt.Columns.Contains("folio"))
            {
                dt.Columns.Add("folio", typeof(int));
            }
            if (!dt.Columns.Contains("avatar"))
            {
                dt.Columns.Add("avatar", typeof(string));
            }
            if (!dt.Columns.Contains("cliente"))
            {
                dt.Columns.Add("cliente", typeof(string));
            }

            int folio = 1;
            foreach (DataRow r in dt.Rows)
            {
                r["folio"] = folio++;
                var nombre = (r.Table.Columns.Contains("nombre") ? (r["nombre"]?.ToString() ?? "") : "").Trim();
                var apellidos = (r.Table.Columns.Contains("apellidos") ? (r["apellidos"]?.ToString() ?? "") : "").Trim();
                var telefono = (r.Table.Columns.Contains("telefono") ? (r["telefono"]?.ToString() ?? "") : "").Trim();

                var nombreCompleto = (nombre + " " + apellidos).Trim();
                r["avatar"] = ObtenerIniciales(nombreCompleto);

                var linea2 = !string.IsNullOrWhiteSpace(telefono) ? telefono : (r.Table.Columns.Contains("id_cliente") ? r["id_cliente"].ToString() : "");
                r["cliente"] = nombreCompleto + Environment.NewLine + linea2;
            }

            dgv.DataSource = dt;

            if (dgv.Rows.Count > 0)
            {
                dgv.Rows[0].Selected = true;
            }
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dgv.Columns[e.ColumnIndex];
            if (col.Name == "cliente")
            {
                e.CellStyle.WrapMode = DataGridViewTriState.True;
            }
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dgv.Columns[e.ColumnIndex];
            if (col.Name != "avatar") return;

            e.Handled = true;
            e.PaintBackground(e.ClipBounds, true);

            var initials = e.FormattedValue != null ? e.FormattedValue.ToString() : string.Empty;

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
    }
}
