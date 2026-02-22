using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    public partial class VentasPorPeriodo : Form
    {
        public VentasPorPeriodo()
        {
            InitializeComponent();
        }

        private void VentasPorPeriodo_Load(object sender, EventArgs e)
        {
            try
            {
                // Llenar el combo con opciones
                comboPeriodo.Items.Clear();
                comboPeriodo.Items.Add("Hoy");
                comboPeriodo.Items.Add("Ayer");
                comboPeriodo.Items.Add("Esta semana");
                comboPeriodo.Items.Add("La semana pasada");
                comboPeriodo.Items.Add("Del Mes");
                comboPeriodo.Items.Add("De un período en particular...");

                comboPeriodo.SelectedIndexChanged += ComboPeriodo_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inicializando: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string periodo = comboPeriodo.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(periodo))
                {
                    dataGridView1.Rows.Clear();
                    lblTotalVendido.Text = "-";
                    return;
                }

                DateTime fechaDesde = DateTime.Now;
                DateTime fechaHasta = DateTime.Now;

                // Determinar rango de fechas según el período seleccionado
                switch (periodo)
                {
                    case "Hoy":
                        fechaDesde = DateTime.Today;
                        fechaHasta = DateTime.Today.AddDays(1).AddSeconds(-1);
                        break;

                    case "Ayer":
                        fechaDesde = DateTime.Today.AddDays(-1);
                        fechaHasta = DateTime.Today.AddSeconds(-1);
                        break;

                    case "Esta semana":
                        // Desde el lunes de esta semana
                        int diasAlunes = (int)DateTime.Today.DayOfWeek - 1;
                        if (diasAlunes < 0) diasAlunes = 6;
                        fechaDesde = DateTime.Today.AddDays(-diasAlunes);
                        fechaHasta = DateTime.Now;
                        break;

                    case "La semana pasada":
                        // Lunes a domingo de la semana pasada
                        int diasAlunes2 = (int)DateTime.Today.DayOfWeek - 1;
                        if (diasAlunes2 < 0) diasAlunes2 = 6;
                        fechaDesde = DateTime.Today.AddDays(-diasAlunes2 - 7);
                        fechaHasta = DateTime.Today.AddDays(-diasAlunes2).AddSeconds(-1);
                        break;

                    case "Del Mes":
                        fechaDesde = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        fechaHasta = DateTime.Now;
                        break;

                    case "De un período en particular...":
                        // Abrir formulario para seleccionar fechas
                        AbrirSelectorFechas();
                        return;

                    default:
                        return;
                }

                CargarVentas(fechaDesde, fechaHasta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga las ventas en el DataGridView según el período
        /// </summary>
        private void CargarVentas(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                dataGridView1.Rows.Clear();

                // Obtener las ventas del período
                DataTable ventas = VentaDAL.ObtenerDetalleVentasPorPeriodo(fechaDesde, fechaHasta);

                decimal totalVendido = 0;

                foreach (DataRow row in ventas.Rows)
                {
                    string codigo = row["codigo_barras"]?.ToString() ?? "";
                    string descripcion = row["nombre"]?.ToString() ?? "";
                    decimal cantidad = Convert.ToDecimal(row["cantidad"]);
                    decimal precioUnitario = Convert.ToDecimal(row["precio_unitario"]);
                    string departamento = row["departamento"]?.ToString() ?? "";

                    decimal subtotal = cantidad * precioUnitario;
                    totalVendido += subtotal;

                    dataGridView1.Rows.Add(
                        codigo,
                        descripcion,
                        cantidad,
                        precioUnitario.ToString("F2"),
                        departamento
                    );
                }

                // Mostrar total
                lblTotalVendido.Text = $"${totalVendido:F2}";
                lblTotalVendido.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abre un diálogo para seleccionar un período personalizado
        /// </summary>
        private void AbrirSelectorFechas()
        {
            try
            {
                // Crear formulario para seleccionar fechas
                Form frmFechas = new Form();
                frmFechas.Text = "Seleccionar Período";
                frmFechas.Width = 300;
                frmFechas.Height = 200;
                frmFechas.StartPosition = FormStartPosition.CenterParent;
                frmFechas.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmFechas.MaximizeBox = false;
                frmFechas.MinimizeBox = false;

                // Fecha Desde
                Label lblDesde = new Label();
                lblDesde.Text = "Fecha Desde:";
                lblDesde.Location = new System.Drawing.Point(10, 20);
                lblDesde.AutoSize = true;

                DateTimePicker dtpDesde = new DateTimePicker();
                dtpDesde.Location = new System.Drawing.Point(100, 20);
                dtpDesde.Width = 150;
                dtpDesde.Value = DateTime.Today.AddMonths(-1);

                // Fecha Hasta
                Label lblHasta = new Label();
                lblHasta.Text = "Fecha Hasta:";
                lblHasta.Location = new System.Drawing.Point(10, 60);
                lblHasta.AutoSize = true;

                DateTimePicker dtpHasta = new DateTimePicker();
                dtpHasta.Location = new System.Drawing.Point(100, 60);
                dtpHasta.Width = 150;
                dtpHasta.Value = DateTime.Today;

                // Botón Aceptar
                Button btnAceptar = new Button();
                btnAceptar.Text = "Aceptar";
                btnAceptar.Location = new System.Drawing.Point(80, 110);
                btnAceptar.Width = 80;
                btnAceptar.Click += (s, e) =>
                {
                    CargarVentas(dtpDesde.Value, dtpHasta.Value.AddDays(1).AddSeconds(-1));
                    frmFechas.Close();
                };

                // Botón Cancelar
                Button btnCancelar = new Button();
                btnCancelar.Text = "Cancelar";
                btnCancelar.Location = new System.Drawing.Point(170, 110);
                btnCancelar.Width = 80;
                btnCancelar.Click += (s, e) => frmFechas.Close();

                frmFechas.Controls.AddRange(new Control[] { lblDesde, dtpDesde, lblHasta, dtpHasta, btnAceptar, btnCancelar });
                frmFechas.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
