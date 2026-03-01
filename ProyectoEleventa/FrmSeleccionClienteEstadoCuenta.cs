using System;
using System.Data;
using System.Windows.Forms;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    public partial class FrmSeleccionClienteEstadoCuenta : Form
    {
        public event Action<int> ClienteAceptado;

        private readonly BindingSource _bs = new BindingSource();
        private int _idClienteSeleccionado;

        public FrmSeleccionClienteEstadoCuenta()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.RowHeadersVisible = false;

            dgvClientes.Columns.Clear();
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "nombre_cliente", HeaderText = "Cliente", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "telefono", HeaderText = "Teléfono", Width = 120 });
            dgvClientes.DataSource = _bs;

            txtBuscar.TextChanged += txtBuscar_TextChanged;
            btnAceptar.Click += btnAceptar_Click;
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;

            CargarClientes(string.Empty);
        }

        private void CargarClientes(string q)
        {
            DataTable dt = ClienteCreditoDAL.BuscarClientesEstadoCuenta(q);
            _bs.DataSource = dt;
            _idClienteSeleccionado = 0;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarClientes(txtBuscar.Text);
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow?.DataBoundItem is DataRowView drv)
            {
                if (drv.Row.Table.Columns.Contains("id_cliente"))
                {
                    _idClienteSeleccionado = Convert.ToInt32(drv.Row["id_cliente"]);
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (_idClienteSeleccionado <= 0)
            {
                MessageBox.Show("Selecciona un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClienteAceptado?.Invoke(_idClienteSeleccionado);
        }
    }
}
