using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    public partial class FrmConfiguracion : Form
    {
        private class CajeroConfig
        {
            public int IdUsuario { get; set; }
            public string Usuario { get; set; }
            public string Contrasena { get; set; }
            public string NombreCompleto { get; set; }
            public HashSet<string> Permisos { get; set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        private readonly BindingSource _bsCajeros = new BindingSource();
        private readonly List<CajeroConfig> _cajeros = new List<CajeroConfig>();
        private CajeroConfig _cajeroActual;

        private static readonly string[] _tagsPermisos =
        {
            "ventas_producto_comun",
            "ventas_aplicar_mayoreo",
            "ventas_aplicar_descuento",
            "ventas_revisar_historial",
            "ventas_entradas_efectivo",
            "ventas_salidas_efectivo",
            "ventas_cobrar_ticket",
            "ventas_cobrar_credito",
            "ventas_cancelar_tickets",
            "ventas_eliminar_articulos",
            "ventas_facturar",
            "ventas_ver_facturas",
            "ventas_vender_pago_servicio",
            "ventas_vender_recargas",
            "ventas_usar_buscador",
            "clientes_abc",
            "clientes_asignar_venta",
            "clientes_asignar_credito",
            "clientes_ver_cuenta",
            "productos_crear",
            "productos_modificar",
            "productos_eliminar",
            "productos_ver_reporte_ventas",
            "productos_crear_promociones",
            "productos_modificar_varios",
            "inventario_agregar_mercancia",
            "inventario_ver_reportes",
            "inventario_ver_movimientos",
            "inventario_ajustar",
            "otros_corte_turno",
            "otros_corte_todos_turnos",
            "otros_corte_dia",
            "otros_ver_ganancia_dia",
            "otros_cambiar_configuracion",
            "otros_acceder_reportes",
            "otros_crear_ordenes_compra",
            "otros_recibir_ordenes_compra"
        };

        public FrmConfiguracion()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            ConfigurarGrid();
            SuscribirEventos();

            CargarCajerosDesdeBD();
        }

        private void CargarCajerosDesdeBD()
        {
            _cajeros.Clear();

            var dt = UsuarioDAL.ObtenerActivos();
            if (dt != null)
            {
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    var cajero = MapearRowACajero(row);
                    if (cajero != null)
                    {
                        _cajeros.Add(cajero);
                    }
                }
            }

            RefrescarLista();
            SeleccionarCajero(_cajeros.FirstOrDefault());
        }

        private CajeroConfig MapearRowACajero(System.Data.DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var cajero = new CajeroConfig();

            cajero.IdUsuario = row.Table.Columns.Contains("id_usuario") ? ConvertToInt(row["id_usuario"]) : 0;
            cajero.Usuario = row.Table.Columns.Contains("usuario") ? (row["usuario"]?.ToString() ?? string.Empty) : string.Empty;
            cajero.Contrasena = row.Table.Columns.Contains("password") ? (row["password"]?.ToString() ?? string.Empty) : string.Empty;
            cajero.NombreCompleto = row.Table.Columns.Contains("nombre_completo") ? (row["nombre_completo"]?.ToString() ?? string.Empty) : string.Empty;
            if (string.IsNullOrWhiteSpace(cajero.NombreCompleto))
            {
                cajero.NombreCompleto = cajero.Usuario;
            }

            foreach (var tag in _tagsPermisos)
            {
                if (row.Table.Columns.Contains(tag) && ConvertToBool(row[tag]))
                {
                    cajero.Permisos.Add(tag);
                }
            }

            return cajero;
        }

        private static int ConvertToInt(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return 0;
            }

            if (value is int i)
            {
                return i;
            }

            int.TryParse(value.ToString(), out var result);
            return result;
        }

        private static bool ConvertToBool(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return false;
            }

            if (value is bool b)
            {
                return b;
            }

            if (value is int i)
            {
                return i != 0;
            }

            var s = value.ToString();
            if (string.Equals(s, "1", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (string.Equals(s, "0", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            bool.TryParse(s, out var result);
            return result;
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

            if (cajero.IdUsuario > 0)
            {
                UsuarioDAL.DarDeBaja(cajero.IdUsuario);
            }

            _cajeroActual = null;
            CargarCajerosDesdeBD();
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
            var permisosDict = permisos.ToDictionary(p => p, p => true, StringComparer.OrdinalIgnoreCase);

            if (_cajeroActual == null)
            {
                if (UsuarioDAL.ExisteUsuario(usuario))
                {
                    MessageBox.Show("Ya existe un cajero con ese usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }

                var newId = UsuarioDAL.Crear(usuario, contrasena, nombre, permisosDict);
                if (newId <= 0)
                {
                    return;
                }
            }
            else
            {
                if (UsuarioDAL.ExisteUsuario(usuario, _cajeroActual.IdUsuario))
                {
                    MessageBox.Show("Ya existe otro cajero con ese usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }

                UsuarioDAL.Actualizar(_cajeroActual.IdUsuario, usuario, contrasena, nombre, permisosDict);
            }

            CargarCajerosDesdeBD();
            SeleccionarEnGridPorUsuario(usuario);

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
            if (_cajeroActual == null)
            {
                LimpiarCampos();
                return;
            }

            var row = UsuarioDAL.ObtenerPorId(_cajeroActual.IdUsuario);
            if (row != null)
            {
                SeleccionarCajero(MapearRowACajero(row));
            }
            else
            {
                CargarCajerosDesdeBD();
            }
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
