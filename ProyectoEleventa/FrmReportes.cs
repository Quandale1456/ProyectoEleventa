using System;
using System.Windows.Forms;

namespace ProyectoEleventa
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            CargarTabVentas();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabVentas)
            {
                CargarTabVentas();
            }
            else if (tabControl1.SelectedTab == tabVentasCliente)
            {
                CargarTabVentasCliente();
            }
        }

        private void CargarTabVentas()
        {
            if (tabVentas.Controls.Count == 0)
            {
                var frm = new FrmReporteVentas();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabVentas.Controls.Add(frm);
                frm.Show();
            }
        }

        private void CargarTabVentasCliente()
        {
            if (tabVentasCliente.Controls.Count == 0)
            {
                var frm = new FrmVentasPorCliente();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabVentasCliente.Controls.Add(frm);
                frm.Show();
            }
        }
    }
}
