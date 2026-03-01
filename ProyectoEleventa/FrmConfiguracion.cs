using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoEleventa
{
    public partial class FrmConfiguracion : Form
    {
        private class CajeroConfig
        {
            public string Usuario { get; set; }
            public string Contrasena { get; set; }
            public string NombreCompleto { get; set; }
            public HashSet<string> Permisos { get; set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        private readonly BindingSource _bsCajeros = new BindingSource();
        private readonly List<CajeroConfig> _cajeros = new List<CajeroConfig>();
        private CajeroConfig _cajeroActual;

        public FrmConfiguracion()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            ConfigurarGrid();
            SuscribirEventos();

            _cajeros.Add(new CajeroConfig
            {
                Usuario = "admin",
                Contrasena = "",
                NombreCompleto = "admin"
            });

            RefrescarLista();
            SeleccionarCajero(_cajeros.FirstOrDefault());
        }

        private void ConfigurarGrid()
        {
            dgvCajeros.AutoGenerateColumns = false;
            dgvCajeros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCajeros.MultiSelect = false;
            dgvCajeros.ReadOnly = true;
            dgvCajeros.AllowUserToAddRows = false;
            dgvCajeros.AllowUserToDeleteRows = false;
            dgvCajeros.AllowUserToResizeRows = false;
            dgvCajeros.RowHeadersVisible = false;

            dgvCajeros.Columns.Clear();
            var col = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CajeroConfig.NombreCompleto),
                HeaderText = "Nombre del Cajero",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvCajeros.Columns.Add(col);

            dgvCajeros.DataSource = _bsCajeros;
        }

        private void SuscribirEventos()
        {
            btnNuevoCajero.Click += btnNuevoCajero_Click;
            btnDarBajaCajero.Click += btnDarBajaCajero_Click;
            btnGuardarCajeroPermisos.Click += btnGuardarCajeroPermisos_Click;
            btnCancelar.Click += btnCancelar_Click;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            dgvCajeros.SelectionChanged += dgvCajeros_SelectionChanged;
        }

        private void RefrescarLista()
        {
            var q = (txtBuscar.Text ?? string.Empty).Trim();
            var data = string.IsNullOrWhiteSpace(q)
                ? _cajeros.ToList()
                : _cajeros.Where(c => (c.NombreCompleto ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0
                                   || (c.Usuario ?? string.Empty).IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0)
                         .ToList();

            _bsCajeros.DataSource = data;
        }

        private void SeleccionarCajero(CajeroConfig cajero)
        {
            _cajeroActual = cajero;

            if (cajero == null)
            {
                LimpiarCampos();
                return;
            }

            txtUsuario.Text = cajero.Usuario ?? string.Empty;
            txtContrasena.Text = cajero.Contrasena ?? string.Empty;
            txtNombreCompleto.Text = cajero.NombreCompleto ?? string.Empty;

            CargarPermisosEnUI(cajero.Permisos);
        }

        private void LimpiarCampos()
        {
            txtUsuario.Text = string.Empty;
            txtContrasena.Text = string.Empty;
            txtNombreCompleto.Text = string.Empty;
            LimpiarPermisosUI();
        }

        private void LimpiarPermisosUI()
        {
            foreach (var chk in ObtenerTodosLosChecksPermisos())
            {
                chk.Checked = false;
            }
        }

        private IEnumerable<CheckBox> ObtenerTodosLosChecksPermisos()
        {
            return new[]
            {
                chkVentasProductoComun,
                chkVentasAplicarMayoreo,
                chkVentasAplicarDescuento,
                chkVentasRevisarHistorial,
                chkVentasEntradasEfectivo,
                chkVentasSalidasEfectivo,
                chkVentasCobrarTicket,
                chkVentasCobrarCredito,
                chkVentasCancelarTickets,
                chkVentasEliminarArticulosVenta,
                chkVentasFacturar,
                chkVentasVerFacturas,
                chkVentasVenderPagoServicio,
                chkVentasVenderRecargas,
                chkVentasUsarBuscador,

                chkClientesABC,
                chkClientesAsignarVenta,
                chkClientesAsignarCredito,
                chkClientesVerCuenta,

                chkProductosCrear,
                chkProductosModificar,
                chkProductosEliminar,
                chkProductosVerReporteVentas,
                chkProductosCrearPromociones,
                chkProductosModificarVarios,

                chkInventarioAgregarMercancia,
                chkInventarioVerReportes,
                chkInventarioVerMovimientos,
                chkInventarioAjustar,

                chkOtrosCorteTurno,
                chkOtrosCorteTodosTurnos,
                chkOtrosCorteDia,
                chkOtrosVerGananciaDia,
                chkOtrosCambiarConfiguracion,
                chkOtrosAccederReportes,
                chkOtrosCrearOrdenesCompra,
                chkOtrosRecibirOrdenesCompra
            };
        }

        private void CargarPermisosEnUI(HashSet<string> permisos)
        {
            LimpiarPermisosUI();

            if (permisos == null || permisos.Count == 0)
            {
                return;
            }

            foreach (var chk in ObtenerTodosLosChecksPermisos())
            {
                chk.Checked = permisos.Contains(chk.Tag as string);
            }
        }

        private HashSet<string> ObtenerPermisosDeUI()
        {
            var permisos = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var chk in ObtenerTodosLosChecksPermisos())
            {
                if (chk.Checked)
                {
                    permisos.Add(chk.Tag as string);
                }
            }

            return permisos;
        }

        private void btnNuevoCajero_Click(object sender, EventArgs e)
        {
            dgvCajeros.ClearSelection();
            _cajeroActual = null;
            LimpiarCampos();
            txtUsuario.Focus();
        }

        private void btnDarBajaCajero_Click(object sender, EventArgs e)
        {
            var cajero = _cajeroActual;
            if (cajero == null)
            {
                return;
            }

            var dr = MessageBox.Show("¿Dar de baja al cajero seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }

            _cajeros.Remove(cajero);
            _cajeroActual = null;
            RefrescarLista();
            SeleccionarCajero(_cajeros.FirstOrDefault());
        }

        private void btnGuardarCajeroPermisos_Click(object sender, EventArgs e)
        {
            var usuario = (txtUsuario.Text ?? string.Empty).Trim();
            var contrasena = txtContrasena.Text ?? string.Empty;
            var nombre = (txtNombreCompleto.Text ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("El campo Usuario es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El campo Nombre completo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCompleto.Focus();
                return;
            }

            var permisos = ObtenerPermisosDeUI();

            if (_cajeroActual == null)
            {
                var existe = _cajeros.Any(c => string.Equals(c.Usuario, usuario, StringComparison.OrdinalIgnoreCase));
                if (existe)
                {
                    MessageBox.Show("Ya existe un cajero con ese usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }

                _cajeroActual = new CajeroConfig();
                _cajeros.Add(_cajeroActual);
            }
            else
            {
                var duplicado = _cajeros.Any(c => !ReferenceEquals(c, _cajeroActual) && string.Equals(c.Usuario, usuario, StringComparison.OrdinalIgnoreCase));
                if (duplicado)
                {
                    MessageBox.Show("Ya existe otro cajero con ese usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }
            }

            _cajeroActual.Usuario = usuario;
            _cajeroActual.Contrasena = contrasena;
            _cajeroActual.NombreCompleto = nombre;
            _cajeroActual.Permisos = permisos;

            RefrescarLista();
            SeleccionarCajero(_cajeroActual);
            SeleccionarEnGridPorUsuario(_cajeroActual.Usuario);

            MessageBox.Show("Cajero y permisos guardados.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SeleccionarEnGridPorUsuario(string usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario))
            {
                return;
            }

            foreach (DataGridViewRow row in dgvCajeros.Rows)
            {
                if (row.DataBoundItem is CajeroConfig c && string.Equals(c.Usuario, usuario, StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;
                    dgvCajeros.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            SeleccionarCajero(_cajeroActual);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            RefrescarLista();
        }

        private void dgvCajeros_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCajeros.CurrentRow?.DataBoundItem is CajeroConfig cajero)
            {
                SeleccionarCajero(cajero);
            }
        }
    }
}
