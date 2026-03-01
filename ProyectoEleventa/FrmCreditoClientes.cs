using System;
using System.Windows.Forms;

namespace ProyectoEleventa
{
    public partial class FrmCreditoClientes : Form
    {
        private Form _activeInnerForm;

        public FrmCreditoClientes()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            btnEstadoCuenta.Click += btnEstadoCuenta_Click;
            btnReporteSaldos.Click += btnReporteSaldos_Click;

            AbrirSelectorEstadoCuenta();
        }

        private void AbrirSelectorEstadoCuenta()
        {
            var selector = new FrmSeleccionClienteEstadoCuenta();
            selector.ClienteAceptado += idCliente => AbrirInnerForm(new FrmEstadoCuentaCliente(idCliente));
            AbrirInnerForm(selector);
        }

        private void AbrirInnerForm(Form f)
        {
            if (_activeInnerForm != null)
            {
                _activeInnerForm.Close();
            }

            _activeInnerForm = f;
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        private void btnEstadoCuenta_Click(object sender, EventArgs e)
        {
            AbrirSelectorEstadoCuenta();
        }

        private void btnReporteSaldos_Click(object sender, EventArgs e)
        {
            AbrirInnerForm(new FrmReporteSaldos());
        }
    }
}
