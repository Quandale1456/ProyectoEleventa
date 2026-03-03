namespace ProyectoEleventa
{
    partial class FrmConfiguracion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dgvCajeros = new System.Windows.Forms.DataGridView();
            this.panelLeftTop = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.tableRight = new System.Windows.Forms.TableLayoutPanel();
            this.panelRightTopButtons = new System.Windows.Forms.Panel();
            this.btnDarBajaCajero = new System.Windows.Forms.Button();
            this.btnNuevoCajero = new System.Windows.Forms.Button();
            this.lblNuevoCajero = new System.Windows.Forms.Label();
            this.tableCampos = new System.Windows.Forms.TableLayoutPanel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.tabPermisos = new System.Windows.Forms.TabControl();
            this.tabVentas = new System.Windows.Forms.TabPage();
            this.chkVentasUsarBuscador = new System.Windows.Forms.CheckBox();
            this.chkVentasVenderRecargas = new System.Windows.Forms.CheckBox();
            this.chkVentasVenderPagoServicio = new System.Windows.Forms.CheckBox();
            this.chkVentasVerFacturas = new System.Windows.Forms.CheckBox();
            this.chkVentasFacturar = new System.Windows.Forms.CheckBox();
            this.chkVentasEliminarArticulosVenta = new System.Windows.Forms.CheckBox();
            this.chkVentasCancelarTickets = new System.Windows.Forms.CheckBox();
            this.chkVentasCobrarCredito = new System.Windows.Forms.CheckBox();
            this.chkVentasCobrarTicket = new System.Windows.Forms.CheckBox();
            this.chkVentasSalidasEfectivo = new System.Windows.Forms.CheckBox();
            this.chkVentasEntradasEfectivo = new System.Windows.Forms.CheckBox();
            this.chkVentasRevisarHistorial = new System.Windows.Forms.CheckBox();
            this.chkVentasAplicarDescuento = new System.Windows.Forms.CheckBox();
            this.chkVentasAplicarMayoreo = new System.Windows.Forms.CheckBox();
            this.chkVentasProductoComun = new System.Windows.Forms.CheckBox();
            this.tabClientes = new System.Windows.Forms.TabPage();
            this.chkClientesVerCuenta = new System.Windows.Forms.CheckBox();
            this.chkClientesAsignarCredito = new System.Windows.Forms.CheckBox();
            this.chkClientesAsignarVenta = new System.Windows.Forms.CheckBox();
            this.chkClientesABC = new System.Windows.Forms.CheckBox();
            this.tabProductos = new System.Windows.Forms.TabPage();
            this.chkProductosModificarVarios = new System.Windows.Forms.CheckBox();
            this.chkProductosCrearPromociones = new System.Windows.Forms.CheckBox();
            this.chkProductosVerReporteVentas = new System.Windows.Forms.CheckBox();
            this.chkProductosEliminar = new System.Windows.Forms.CheckBox();
            this.chkProductosModificar = new System.Windows.Forms.CheckBox();
            this.chkProductosCrear = new System.Windows.Forms.CheckBox();
            this.tabInventario = new System.Windows.Forms.TabPage();
            this.chkInventarioAjustar = new System.Windows.Forms.CheckBox();
            this.chkInventarioVerMovimientos = new System.Windows.Forms.CheckBox();
            this.chkInventarioVerReportes = new System.Windows.Forms.CheckBox();
            this.chkInventarioAgregarMercancia = new System.Windows.Forms.CheckBox();
            this.tabOtros = new System.Windows.Forms.TabPage();
            this.chkOtrosRecibirOrdenesCompra = new System.Windows.Forms.CheckBox();
            this.chkOtrosCrearOrdenesCompra = new System.Windows.Forms.CheckBox();
            this.chkOtrosAccederReportes = new System.Windows.Forms.CheckBox();
            this.chkOtrosCambiarConfiguracion = new System.Windows.Forms.CheckBox();
            this.chkOtrosVerGananciaDia = new System.Windows.Forms.CheckBox();
            this.chkOtrosCorteDia = new System.Windows.Forms.CheckBox();
            this.chkOtrosCorteTodosTurnos = new System.Windows.Forms.CheckBox();
            this.chkOtrosCorteTurno = new System.Windows.Forms.CheckBox();
            this.panelBottomButtons = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardarCajeroPermisos = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajeros)).BeginInit();
            this.panelLeftTop.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.tableRight.SuspendLayout();
            this.panelRightTopButtons.SuspendLayout();
            this.tableCampos.SuspendLayout();
            this.tabPermisos.SuspendLayout();
            this.tabVentas.SuspendLayout();
            this.tabClientes.SuspendLayout();
            this.tabProductos.SuspendLayout();
            this.tabInventario.SuspendLayout();
            this.tabOtros.SuspendLayout();
            this.panelBottomButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1224, 71);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(18, 17);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(263, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "CONFIGURACION";
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 71);
            this.splitMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.panelLeft);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.panelRight);
            this.splitMain.Size = new System.Drawing.Size(1224, 713);
            this.splitMain.SplitterDistance = 367;
            this.splitMain.SplitterWidth = 6;
            this.splitMain.TabIndex = 1;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.dgvCajeros);
            this.panelLeft.Controls.Add(this.panelLeftTop);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(367, 713);
            this.panelLeft.TabIndex = 0;
            // 
            // dgvCajeros
            // 
            this.dgvCajeros.BackgroundColor = System.Drawing.Color.White;
            this.dgvCajeros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCajeros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCajeros.Location = new System.Drawing.Point(0, 71);
            this.dgvCajeros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCajeros.Name = "dgvCajeros";
            this.dgvCajeros.RowHeadersWidth = 62;
            this.dgvCajeros.Size = new System.Drawing.Size(367, 642);
            this.dgvCajeros.TabIndex = 1;
            // 
            // panelLeftTop
            // 
            this.panelLeftTop.Controls.Add(this.txtBuscar);
            this.panelLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeftTop.Location = new System.Drawing.Point(0, 0);
            this.panelLeftTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelLeftTop.Name = "panelLeftTop";
            this.panelLeftTop.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.panelLeftTop.Size = new System.Drawing.Size(367, 71);
            this.panelLeftTop.TabIndex = 0;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuscar.Location = new System.Drawing.Point(15, 15);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(337, 26);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.Text = "Buscar ...";
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.tableRight);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.panelRight.Size = new System.Drawing.Size(851, 713);
            this.panelRight.TabIndex = 0;
            // 
            // tableRight
            // 
            this.tableRight.ColumnCount = 1;
            this.tableRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRight.Controls.Add(this.panelRightTopButtons, 0, 0);
            this.tableRight.Controls.Add(this.lblNuevoCajero, 0, 1);
            this.tableRight.Controls.Add(this.tableCampos, 0, 2);
            this.tableRight.Controls.Add(this.tabPermisos, 0, 3);
            this.tableRight.Controls.Add(this.panelBottomButtons, 0, 4);
            this.tableRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableRight.Location = new System.Drawing.Point(15, 15);
            this.tableRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableRight.Name = "tableRight";
            this.tableRight.RowCount = 5;
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableRight.Size = new System.Drawing.Size(821, 683);
            this.tableRight.TabIndex = 0;
            // 
            // panelRightTopButtons
            // 
            this.panelRightTopButtons.Controls.Add(this.btnDarBajaCajero);
            this.panelRightTopButtons.Controls.Add(this.btnNuevoCajero);
            this.panelRightTopButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightTopButtons.Location = new System.Drawing.Point(4, 5);
            this.panelRightTopButtons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelRightTopButtons.Name = "panelRightTopButtons";
            this.panelRightTopButtons.Size = new System.Drawing.Size(813, 55);
            this.panelRightTopButtons.TabIndex = 0;
            // 
            // btnDarBajaCajero
            // 
            this.btnDarBajaCajero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDarBajaCajero.Location = new System.Drawing.Point(192, 9);
            this.btnDarBajaCajero.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDarBajaCajero.Name = "btnDarBajaCajero";
            this.btnDarBajaCajero.Size = new System.Drawing.Size(180, 40);
            this.btnDarBajaCajero.TabIndex = 1;
            this.btnDarBajaCajero.Text = "Dar de Baja Cajero";
            this.btnDarBajaCajero.UseVisualStyleBackColor = true;
            // 
            // btnNuevoCajero
            // 
            this.btnNuevoCajero.Location = new System.Drawing.Point(4, 9);
            this.btnNuevoCajero.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNuevoCajero.Name = "btnNuevoCajero";
            this.btnNuevoCajero.Size = new System.Drawing.Size(178, 40);
            this.btnNuevoCajero.TabIndex = 0;
            this.btnNuevoCajero.Text = "Nuevo Cajero";
            this.btnNuevoCajero.UseVisualStyleBackColor = true;
            // 
            // lblNuevoCajero
            // 
            this.lblNuevoCajero.AutoSize = true;
            this.lblNuevoCajero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNuevoCajero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblNuevoCajero.Location = new System.Drawing.Point(4, 65);
            this.lblNuevoCajero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNuevoCajero.Name = "lblNuevoCajero";
            this.lblNuevoCajero.Padding = new System.Windows.Forms.Padding(3, 6, 0, 0);
            this.lblNuevoCajero.Size = new System.Drawing.Size(813, 37);
            this.lblNuevoCajero.TabIndex = 1;
            this.lblNuevoCajero.Text = "NUEVO CAJERO";
            // 
            // tableCampos
            // 
            this.tableCampos.ColumnCount = 2;
            this.tableCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableCampos.Controls.Add(this.lblUsuario, 0, 0);
            this.tableCampos.Controls.Add(this.lblContrasena, 0, 1);
            this.tableCampos.Controls.Add(this.lblNombreCompleto, 0, 2);
            this.tableCampos.Controls.Add(this.txtUsuario, 1, 0);
            this.tableCampos.Controls.Add(this.txtContrasena, 1, 1);
            this.tableCampos.Controls.Add(this.txtNombreCompleto, 1, 2);
            this.tableCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableCampos.Location = new System.Drawing.Point(4, 107);
            this.tableCampos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableCampos.Name = "tableCampos";
            this.tableCampos.RowCount = 3;
            this.tableCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableCampos.Size = new System.Drawing.Size(813, 128);
            this.tableCampos.TabIndex = 2;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsuario.Location = new System.Drawing.Point(4, 0);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.lblUsuario.Size = new System.Drawing.Size(157, 43);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContrasena.Location = new System.Drawing.Point(4, 43);
            this.lblContrasena.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.lblContrasena.Size = new System.Drawing.Size(157, 43);
            this.lblContrasena.TabIndex = 1;
            this.lblContrasena.Text = "Contraseña";
            this.lblContrasena.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNombreCompleto.Location = new System.Drawing.Point(4, 86);
            this.lblNombreCompleto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.lblNombreCompleto.Size = new System.Drawing.Size(157, 43);
            this.lblNombreCompleto.TabIndex = 2;
            this.lblNombreCompleto.Text = "Nombre completo";
            this.lblNombreCompleto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsuario.Location = new System.Drawing.Point(169, 5);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(640, 26);
            this.txtUsuario.TabIndex = 3;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContrasena.Location = new System.Drawing.Point(169, 48);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(640, 26);
            this.txtContrasena.TabIndex = 4;
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNombreCompleto.Location = new System.Drawing.Point(169, 91);
            this.txtNombreCompleto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(640, 26);
            this.txtNombreCompleto.TabIndex = 5;
            // 
            // tabPermisos
            // 
            this.tabPermisos.Controls.Add(this.tabVentas);
            this.tabPermisos.Controls.Add(this.tabClientes);
            this.tabPermisos.Controls.Add(this.tabProductos);
            this.tabPermisos.Controls.Add(this.tabInventario);
            this.tabPermisos.Controls.Add(this.tabOtros);
            this.tabPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPermisos.Location = new System.Drawing.Point(4, 245);
            this.tabPermisos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPermisos.Name = "tabPermisos";
            this.tabPermisos.SelectedIndex = 0;
            this.tabPermisos.Size = new System.Drawing.Size(813, 335);
            this.tabPermisos.TabIndex = 3;
            // 
            // tabVentas
            // 
            this.tabVentas.Controls.Add(this.chkVentasUsarBuscador);
            this.tabVentas.Controls.Add(this.chkVentasVenderRecargas);
            this.tabVentas.Controls.Add(this.chkVentasVenderPagoServicio);
            this.tabVentas.Controls.Add(this.chkVentasVerFacturas);
            this.tabVentas.Controls.Add(this.chkVentasFacturar);
            this.tabVentas.Controls.Add(this.chkVentasEliminarArticulosVenta);
            this.tabVentas.Controls.Add(this.chkVentasCancelarTickets);
            this.tabVentas.Controls.Add(this.chkVentasCobrarCredito);
            this.tabVentas.Controls.Add(this.chkVentasCobrarTicket);
            this.tabVentas.Controls.Add(this.chkVentasSalidasEfectivo);
            this.tabVentas.Controls.Add(this.chkVentasEntradasEfectivo);
            this.tabVentas.Controls.Add(this.chkVentasRevisarHistorial);
            this.tabVentas.Controls.Add(this.chkVentasAplicarDescuento);
            this.tabVentas.Controls.Add(this.chkVentasAplicarMayoreo);
            this.tabVentas.Controls.Add(this.chkVentasProductoComun);
            this.tabVentas.Location = new System.Drawing.Point(4, 29);
            this.tabVentas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabVentas.Name = "tabVentas";
            this.tabVentas.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.tabVentas.Size = new System.Drawing.Size(805, 302);
            this.tabVentas.TabIndex = 0;
            this.tabVentas.Text = "Ventas";
            this.tabVentas.UseVisualStyleBackColor = true;
            // 
            // chkVentasUsarBuscador
            // 
            this.chkVentasUsarBuscador.AutoSize = true;
            this.chkVentasUsarBuscador.Location = new System.Drawing.Point(525, 232);
            this.chkVentasUsarBuscador.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVentasUsarBuscador.Name = "chkVentasUsarBuscador";
            this.chkVentasUsarBuscador.Size = new System.Drawing.Size(236, 24);
            this.chkVentasUsarBuscador.TabIndex = 14;
            this.chkVentasUsarBuscador.Tag = "ventas_usar_buscador";
            this.chkVentasUsarBuscador.Text = "Usar buscador de productos";
            this.chkVentasUsarBuscador.UseVisualStyleBackColor = true;
            // 
            // chkVentasVenderRecargas
            // 
            this.chkVentasVenderRecargas.AutoSize = true;
            this.chkVentasVenderRecargas.Location = new System.Drawing.Point(525, 197);
            this.chkVentasVenderRecargas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVentasVenderRecargas.Name = "chkVentasVenderRecargas";
            this.chkVentasVenderRecargas.Size = new System.Drawing.Size(251, 24);
            this.chkVentasVenderRecargas.TabIndex = 13;
            this.chkVentasVenderRecargas.Tag = "ventas_vender_recargas";
            this.chkVentasVenderRecargas.Text = "Vender Recargas Electrónicas";
            this.chkVentasVenderRecargas.UseVisualStyleBackColor = true;
            // 
            // chkVentasVenderPagoServicio
            // 
            this.chkVentasVenderPagoServicio.AutoSize = true;
            this.chkVentasVenderPagoServicio.Location = new System.Drawing.Point(525, 162);
            this.chkVentasVenderPagoServicio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVentasVenderPagoServicio.Name = "chkVentasVenderPagoServicio";
            this.chkVentasVenderPagoServicio.Size = new System.Drawing.Size(227, 24);
            this.chkVentasVenderPagoServicio.TabIndex = 12;
            this.chkVentasVenderPagoServicio.Tag = "ventas_vender_pago_servicio";
            this.chkVentasVenderPagoServicio.Text = "Vender un pago de servicio";
            this.chkVentasVenderPagoServicio.UseVisualStyleBackColor = true;
            // 
            // chkVentasVerFacturas
            // 
            this.chkVentasVerFacturas.AutoSize = true;
            this.chkVentasVerFacturas.Location = new System.Drawing.Point(525, 126);
            this.chkVentasVerFacturas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVentasVerFacturas.Name = "chkVentasVerFacturas";
            this.chkVentasVerFacturas.Size = new System.Drawing.Size(127, 24);
            this.chkVentasVerFacturas.TabIndex = 11;
            this.chkVentasVerFacturas.Tag = "ventas_ver_facturas";
            this.chkVentasVerFacturas.Text = "Ver Facturas";
            this.chkVentasVerFacturas.UseVisualStyleBackColor = true;
            // 
            // chkVentasFacturar
            // 
            this.chkVentasFacturar.AutoSize = true;
            this.chkVentasFacturar.Location = new System.Drawing.Point(525, 91);
            this.chkVentasFacturar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVentasFacturar.Name = "chkVentasFacturar";
            this.chkVentasFacturar.Size = new System.Drawing.Size(95, 24);
            this.chkVentasFacturar.TabIndex = 10;
            this.chkVentasFacturar.Tag = "ventas_facturar";
            this.chkVentasFacturar.Text = "Facturar";
            this.chkVentasFacturar.UseVisualStyleBackColor = true;
            // 
            // chkVentasEliminarArticulosVenta
            // 
            this.chkVentasEliminarArticulosVenta.AutoSize = true;
            this.chkVentasEliminarArticulosVenta.Location = new System.Drawing.Point(525, 55);
            this.chkVentasEliminarArticulosVenta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVentasEliminarArticulosVenta.Name = "chkVentasEliminarArticulosVenta";
            this.chkVentasEliminarArticulosVenta.Size = new System.Drawing.Size(219, 24);
            this.chkVentasEliminarArticulosVenta.TabIndex = 9;
            this.chkVentasEliminarArticulosVenta.Tag = "ventas_eliminar_articulos";
            this.chkVentasEliminarArticulosVenta.Text = "Eliminar artículos de venta";
            this.chkVentasEliminarArticulosVenta.UseVisualStyleBackColor = true;
            // 
            // chkVentasCancelarTickets
            // 
            this.chkVentasCancelarTickets.AutoSize = true;
            this.chkVentasCancelarTickets.Location = new System.Drawing.Point(525, 20);
            this.chkVentasCancelarTickets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVentasCancelarTickets.Name = "chkVentasCancelarTickets";
            this.chkVentasCancelarTickets.Size = new System.Drawing.Size(284, 24);
            this.chkVentasCancelarTickets.TabIndex = 8;
            this.chkVentasCancelarTickets.Tag = "ventas_cancelar_tickets";
            this.chkVentasCancelarTickets.Text = "Cancelar tickets y devolver artículos";
            this.chkVentasCancelarTickets.UseVisualStyleBackColor = true;
            // 
            // chkVentasCobrarCredito
            // 
            this.chkVentasCobrarCredito.AutoSize = true;
            this.chkVentasCobrarCredito.Location = new System.Drawing.Point(20, 268);
            this.chkVentasCobrarCredito.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVentasCobrarCredito.Name = "chkVentasCobrarCredito";
            this.chkVentasCobrarCredito.Size = new System.Drawing.Size(148, 24);
            this.chkVentasCobrarCredito.TabIndex = 7;
            this.chkVentasCobrarCredito.Tag = "ventas_cobrar_credito";
            this.chkVentasCobrarCredito.Text = "Cobrar a crédito";
            this.chkVentasCobrarCredito.UseVisualStyleBackColor = true;
            // 
            // chkVentasCobrarTicket
            // 
            this.chkVentasCobrarTicket.AutoSize = true;
            this.chkVentasCobrarTicket.Location = new System.Drawing.Point(20, 232);
            this.chkVentasCobrarTicket.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVentasCobrarTicket.Name = "chkVentasCobrarTicket";
            this.chkVentasCobrarTicket.Size = new System.Drawing.Size(147, 24);
            this.chkVentasCobrarTicket.TabIndex = 6;
            this.chkVentasCobrarTicket.Tag = "ventas_cobrar_ticket";
            this.chkVentasCobrarTicket.Text = "Cobrar un ticket";
            this.chkVentasCobrarTicket.UseVisualStyleBackColor = true;
            // 
            // chkVentasSalidasEfectivo
            // 
            this.chkVentasSalidasEfectivo.AutoSize = true;
            this.chkVentasSalidasEfectivo.Location = new System.Drawing.Point(20, 197);
            this.chkVentasSalidasEfectivo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVentasSalidasEfectivo.Name = "chkVentasSalidasEfectivo";
            this.chkVentasSalidasEfectivo.Size = new System.Drawing.Size(239, 24);
            this.chkVentasSalidasEfectivo.TabIndex = 5;
            this.chkVentasSalidasEfectivo.Tag = "ventas_salidas_efectivo";
            this.chkVentasSalidasEfectivo.Text = "Registrar Salidas de Efectivo";
            this.chkVentasSalidasEfectivo.UseVisualStyleBackColor = true;
            // 
            // chkVentasEntradasEfectivo
            // 
            this.chkVentasEntradasEfectivo.AutoSize = true;
            this.chkVentasEntradasEfectivo.Location = new System.Drawing.Point(20, 162);
            this.chkVentasEntradasEfectivo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVentasEntradasEfectivo.Name = "chkVentasEntradasEfectivo";
            this.chkVentasEntradasEfectivo.Size = new System.Drawing.Size(252, 24);
            this.chkVentasEntradasEfectivo.TabIndex = 4;
            this.chkVentasEntradasEfectivo.Tag = "ventas_entradas_efectivo";
            this.chkVentasEntradasEfectivo.Text = "Registrar Entradas de Efectivo";
            this.chkVentasEntradasEfectivo.UseVisualStyleBackColor = true;
            // 
            // chkVentasRevisarHistorial
            // 
            this.chkVentasRevisarHistorial.AutoSize = true;
            this.chkVentasRevisarHistorial.Location = new System.Drawing.Point(20, 126);
            this.chkVentasRevisarHistorial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVentasRevisarHistorial.Name = "chkVentasRevisarHistorial";
            this.chkVentasRevisarHistorial.Size = new System.Drawing.Size(239, 24);
            this.chkVentasRevisarHistorial.TabIndex = 3;
            this.chkVentasRevisarHistorial.Tag = "ventas_revisar_historial";
            this.chkVentasRevisarHistorial.Text = "Revisar el historial de Ventas";
            this.chkVentasRevisarHistorial.UseVisualStyleBackColor = true;
            // 
            // chkVentasAplicarDescuento
            // 
            this.chkVentasAplicarDescuento.AutoSize = true;
            this.chkVentasAplicarDescuento.Location = new System.Drawing.Point(20, 91);
            this.chkVentasAplicarDescuento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVentasAplicarDescuento.Name = "chkVentasAplicarDescuento";
            this.chkVentasAplicarDescuento.Size = new System.Drawing.Size(165, 24);
            this.chkVentasAplicarDescuento.TabIndex = 2;
            this.chkVentasAplicarDescuento.Tag = "ventas_aplicar_descuento";
            this.chkVentasAplicarDescuento.Text = "Aplicar Descuento";
            this.chkVentasAplicarDescuento.UseVisualStyleBackColor = true;
            // 
            // chkVentasAplicarMayoreo
            // 
            this.chkVentasAplicarMayoreo.AutoSize = true;
            this.chkVentasAplicarMayoreo.Location = new System.Drawing.Point(20, 55);
            this.chkVentasAplicarMayoreo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVentasAplicarMayoreo.Name = "chkVentasAplicarMayoreo";
            this.chkVentasAplicarMayoreo.Size = new System.Drawing.Size(148, 24);
            this.chkVentasAplicarMayoreo.TabIndex = 1;
            this.chkVentasAplicarMayoreo.Tag = "ventas_aplicar_mayoreo";
            this.chkVentasAplicarMayoreo.Text = "Aplicar Mayoreo";
            this.chkVentasAplicarMayoreo.UseVisualStyleBackColor = true;
            // 
            // chkVentasProductoComun
            // 
            this.chkVentasProductoComun.AutoSize = true;
            this.chkVentasProductoComun.Location = new System.Drawing.Point(20, 20);
            this.chkVentasProductoComun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVentasProductoComun.Name = "chkVentasProductoComun";
            this.chkVentasProductoComun.Size = new System.Drawing.Size(206, 24);
            this.chkVentasProductoComun.TabIndex = 0;
            this.chkVentasProductoComun.Tag = "ventas_producto_comun";
            this.chkVentasProductoComun.Text = "Utilizar Producto Común";
            this.chkVentasProductoComun.UseVisualStyleBackColor = true;
            // 
            // tabClientes
            // 
            this.tabClientes.Controls.Add(this.chkClientesVerCuenta);
            this.tabClientes.Controls.Add(this.chkClientesAsignarCredito);
            this.tabClientes.Controls.Add(this.chkClientesAsignarVenta);
            this.tabClientes.Controls.Add(this.chkClientesABC);
            this.tabClientes.Location = new System.Drawing.Point(4, 29);
            this.tabClientes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabClientes.Name = "tabClientes";
            this.tabClientes.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.tabClientes.Size = new System.Drawing.Size(1207, 595);
            this.tabClientes.TabIndex = 1;
            this.tabClientes.Text = "Clientes";
            this.tabClientes.UseVisualStyleBackColor = true;
            // 
            // chkClientesVerCuenta
            // 
            this.chkClientesVerCuenta.AutoSize = true;
            this.chkClientesVerCuenta.Location = new System.Drawing.Point(20, 126);
            this.chkClientesVerCuenta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkClientesVerCuenta.Name = "chkClientesVerCuenta";
            this.chkClientesVerCuenta.Size = new System.Drawing.Size(439, 24);
            this.chkClientesVerCuenta.TabIndex = 3;
            this.chkClientesVerCuenta.Tag = "clientes_ver_cuenta";
            this.chkClientesVerCuenta.Text = "Ver cuenta, recibir abonos y reportes de clientes a crédito";
            this.chkClientesVerCuenta.UseVisualStyleBackColor = true;
            // 
            // chkClientesAsignarCredito
            // 
            this.chkClientesAsignarCredito.AutoSize = true;
            this.chkClientesAsignarCredito.Location = new System.Drawing.Point(20, 91);
            this.chkClientesAsignarCredito.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkClientesAsignarCredito.Name = "chkClientesAsignarCredito";
            this.chkClientesAsignarCredito.Size = new System.Drawing.Size(286, 24);
            this.chkClientesAsignarCredito.TabIndex = 2;
            this.chkClientesAsignarCredito.Tag = "clientes_asignar_credito";
            this.chkClientesAsignarCredito.Text = "Asignar o remover crédito a clientes";
            this.chkClientesAsignarCredito.UseVisualStyleBackColor = true;
            // 
            // chkClientesAsignarVenta
            // 
            this.chkClientesAsignarVenta.AutoSize = true;
            this.chkClientesAsignarVenta.Location = new System.Drawing.Point(20, 55);
            this.chkClientesAsignarVenta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkClientesAsignarVenta.Name = "chkClientesAsignarVenta";
            this.chkClientesAsignarVenta.Size = new System.Drawing.Size(226, 24);
            this.chkClientesAsignarVenta.TabIndex = 1;
            this.chkClientesAsignarVenta.Tag = "clientes_asignar_venta";
            this.chkClientesAsignarVenta.Text = "Asignar cliente a una venta";
            this.chkClientesAsignarVenta.UseVisualStyleBackColor = true;
            // 
            // chkClientesABC
            // 
            this.chkClientesABC.AutoSize = true;
            this.chkClientesABC.Location = new System.Drawing.Point(20, 20);
            this.chkClientesABC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkClientesABC.Name = "chkClientesABC";
            this.chkClientesABC.Size = new System.Drawing.Size(275, 24);
            this.chkClientesABC.TabIndex = 0;
            this.chkClientesABC.Tag = "clientes_abc";
            this.chkClientesABC.Text = "Crear, modificar o eliminar clientes";
            this.chkClientesABC.UseVisualStyleBackColor = true;
            // 
            // tabProductos
            // 
            this.tabProductos.Controls.Add(this.chkProductosModificarVarios);
            this.tabProductos.Controls.Add(this.chkProductosCrearPromociones);
            this.tabProductos.Controls.Add(this.chkProductosVerReporteVentas);
            this.tabProductos.Controls.Add(this.chkProductosEliminar);
            this.tabProductos.Controls.Add(this.chkProductosModificar);
            this.tabProductos.Controls.Add(this.chkProductosCrear);
            this.tabProductos.Location = new System.Drawing.Point(4, 29);
            this.tabProductos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabProductos.Name = "tabProductos";
            this.tabProductos.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.tabProductos.Size = new System.Drawing.Size(1207, 595);
            this.tabProductos.TabIndex = 2;
            this.tabProductos.Text = "Productos";
            this.tabProductos.UseVisualStyleBackColor = true;
            // 
            // chkProductosModificarVarios
            // 
            this.chkProductosModificarVarios.AutoSize = true;
            this.chkProductosModificarVarios.Location = new System.Drawing.Point(20, 197);
            this.chkProductosModificarVarios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkProductosModificarVarios.Name = "chkProductosModificarVarios";
            this.chkProductosModificarVarios.Size = new System.Drawing.Size(148, 24);
            this.chkProductosModificarVarios.TabIndex = 5;
            this.chkProductosModificarVarios.Tag = "productos_modificar_varios";
            this.chkProductosModificarVarios.Text = "Modificar Varios";
            this.chkProductosModificarVarios.UseVisualStyleBackColor = true;
            // 
            // chkProductosCrearPromociones
            // 
            this.chkProductosCrearPromociones.AutoSize = true;
            this.chkProductosCrearPromociones.Location = new System.Drawing.Point(20, 162);
            this.chkProductosCrearPromociones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkProductosCrearPromociones.Name = "chkProductosCrearPromociones";
            this.chkProductosCrearPromociones.Size = new System.Drawing.Size(169, 24);
            this.chkProductosCrearPromociones.TabIndex = 4;
            this.chkProductosCrearPromociones.Tag = "productos_crear_promociones";
            this.chkProductosCrearPromociones.Text = "Crear promociones";
            this.chkProductosCrearPromociones.UseVisualStyleBackColor = true;
            // 
            // chkProductosVerReporteVentas
            // 
            this.chkProductosVerReporteVentas.AutoSize = true;
            this.chkProductosVerReporteVentas.Location = new System.Drawing.Point(20, 126);
            this.chkProductosVerReporteVentas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkProductosVerReporteVentas.Name = "chkProductosVerReporteVentas";
            this.chkProductosVerReporteVentas.Size = new System.Drawing.Size(188, 24);
            this.chkProductosVerReporteVentas.TabIndex = 3;
            this.chkProductosVerReporteVentas.Tag = "productos_ver_reporte_ventas";
            this.chkProductosVerReporteVentas.Text = "Ver reporte de ventas";
            this.chkProductosVerReporteVentas.UseVisualStyleBackColor = true;
            // 
            // chkProductosEliminar
            // 
            this.chkProductosEliminar.AutoSize = true;
            this.chkProductosEliminar.Location = new System.Drawing.Point(20, 91);
            this.chkProductosEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkProductosEliminar.Name = "chkProductosEliminar";
            this.chkProductosEliminar.Size = new System.Drawing.Size(166, 24);
            this.chkProductosEliminar.TabIndex = 2;
            this.chkProductosEliminar.Tag = "productos_eliminar";
            this.chkProductosEliminar.Text = "Eliminar productos";
            this.chkProductosEliminar.UseVisualStyleBackColor = true;
            // 
            // chkProductosModificar
            // 
            this.chkProductosModificar.AutoSize = true;
            this.chkProductosModificar.Location = new System.Drawing.Point(20, 55);
            this.chkProductosModificar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkProductosModificar.Name = "chkProductosModificar";
            this.chkProductosModificar.Size = new System.Drawing.Size(174, 24);
            this.chkProductosModificar.TabIndex = 1;
            this.chkProductosModificar.Tag = "productos_modificar";
            this.chkProductosModificar.Text = "Modificar productos";
            this.chkProductosModificar.UseVisualStyleBackColor = true;
            // 
            // chkProductosCrear
            // 
            this.chkProductosCrear.AutoSize = true;
            this.chkProductosCrear.Location = new System.Drawing.Point(20, 20);
            this.chkProductosCrear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkProductosCrear.Name = "chkProductosCrear";
            this.chkProductosCrear.Size = new System.Drawing.Size(204, 24);
            this.chkProductosCrear.TabIndex = 0;
            this.chkProductosCrear.Tag = "productos_crear";
            this.chkProductosCrear.Text = "Crear nuevos productos";
            this.chkProductosCrear.UseVisualStyleBackColor = true;
            // 
            // tabInventario
            // 
            this.tabInventario.Controls.Add(this.chkInventarioAjustar);
            this.tabInventario.Controls.Add(this.chkInventarioVerMovimientos);
            this.tabInventario.Controls.Add(this.chkInventarioVerReportes);
            this.tabInventario.Controls.Add(this.chkInventarioAgregarMercancia);
            this.tabInventario.Location = new System.Drawing.Point(4, 29);
            this.tabInventario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabInventario.Name = "tabInventario";
            this.tabInventario.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.tabInventario.Size = new System.Drawing.Size(1207, 595);
            this.tabInventario.TabIndex = 3;
            this.tabInventario.Text = "Inventario";
            this.tabInventario.UseVisualStyleBackColor = true;
            // 
            // chkInventarioAjustar
            // 
            this.chkInventarioAjustar.AutoSize = true;
            this.chkInventarioAjustar.Location = new System.Drawing.Point(20, 126);
            this.chkInventarioAjustar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkInventarioAjustar.Name = "chkInventarioAjustar";
            this.chkInventarioAjustar.Size = new System.Drawing.Size(173, 24);
            this.chkInventarioAjustar.TabIndex = 3;
            this.chkInventarioAjustar.Tag = "inventario_ajustar";
            this.chkInventarioAjustar.Text = "Ajustar el inventario";
            this.chkInventarioAjustar.UseVisualStyleBackColor = true;
            // 
            // chkInventarioVerMovimientos
            // 
            this.chkInventarioVerMovimientos.AutoSize = true;
            this.chkInventarioVerMovimientos.Location = new System.Drawing.Point(20, 91);
            this.chkInventarioVerMovimientos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkInventarioVerMovimientos.Name = "chkInventarioVerMovimientos";
            this.chkInventarioVerMovimientos.Size = new System.Drawing.Size(246, 24);
            this.chkInventarioVerMovimientos.TabIndex = 2;
            this.chkInventarioVerMovimientos.Tag = "inventario_ver_movimientos";
            this.chkInventarioVerMovimientos.Text = "Ver movimiento de inventarios";
            this.chkInventarioVerMovimientos.UseVisualStyleBackColor = true;
            // 
            // chkInventarioVerReportes
            // 
            this.chkInventarioVerReportes.AutoSize = true;
            this.chkInventarioVerReportes.Location = new System.Drawing.Point(20, 55);
            this.chkInventarioVerReportes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkInventarioVerReportes.Name = "chkInventarioVerReportes";
            this.chkInventarioVerReportes.Size = new System.Drawing.Size(300, 24);
            this.chkInventarioVerReportes.TabIndex = 1;
            this.chkInventarioVerReportes.Tag = "inventario_ver_reportes";
            this.chkInventarioVerReportes.Text = "Ver reportes de existencias y mínimos";
            this.chkInventarioVerReportes.UseVisualStyleBackColor = true;
            // 
            // chkInventarioAgregarMercancia
            // 
            this.chkInventarioAgregarMercancia.AutoSize = true;
            this.chkInventarioAgregarMercancia.Location = new System.Drawing.Point(20, 20);
            this.chkInventarioAgregarMercancia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkInventarioAgregarMercancia.Name = "chkInventarioAgregarMercancia";
            this.chkInventarioAgregarMercancia.Size = new System.Drawing.Size(169, 24);
            this.chkInventarioAgregarMercancia.TabIndex = 0;
            this.chkInventarioAgregarMercancia.Tag = "inventario_agregar_mercancia";
            this.chkInventarioAgregarMercancia.Text = "Agregar mercancía";
            this.chkInventarioAgregarMercancia.UseVisualStyleBackColor = true;
            // 
            // tabOtros
            // 
            this.tabOtros.Controls.Add(this.chkOtrosRecibirOrdenesCompra);
            this.tabOtros.Controls.Add(this.chkOtrosCrearOrdenesCompra);
            this.tabOtros.Controls.Add(this.chkOtrosAccederReportes);
            this.tabOtros.Controls.Add(this.chkOtrosCambiarConfiguracion);
            this.tabOtros.Controls.Add(this.chkOtrosVerGananciaDia);
            this.tabOtros.Controls.Add(this.chkOtrosCorteDia);
            this.tabOtros.Controls.Add(this.chkOtrosCorteTodosTurnos);
            this.tabOtros.Controls.Add(this.chkOtrosCorteTurno);
            this.tabOtros.Location = new System.Drawing.Point(4, 29);
            this.tabOtros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabOtros.Name = "tabOtros";
            this.tabOtros.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.tabOtros.Size = new System.Drawing.Size(1207, 595);
            this.tabOtros.TabIndex = 4;
            this.tabOtros.Text = "Otros";
            this.tabOtros.UseVisualStyleBackColor = true;
            // 
            // chkOtrosRecibirOrdenesCompra
            // 
            this.chkOtrosRecibirOrdenesCompra.AutoSize = true;
            this.chkOtrosRecibirOrdenesCompra.Location = new System.Drawing.Point(20, 268);
            this.chkOtrosRecibirOrdenesCompra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkOtrosRecibirOrdenesCompra.Name = "chkOtrosRecibirOrdenesCompra";
            this.chkOtrosRecibirOrdenesCompra.Size = new System.Drawing.Size(225, 24);
            this.chkOtrosRecibirOrdenesCompra.TabIndex = 7;
            this.chkOtrosRecibirOrdenesCompra.Tag = "otros_recibir_ordenes_compra";
            this.chkOtrosRecibirOrdenesCompra.Text = "Recibir ordenes de compra";
            this.chkOtrosRecibirOrdenesCompra.UseVisualStyleBackColor = true;
            // 
            // chkOtrosCrearOrdenesCompra
            // 
            this.chkOtrosCrearOrdenesCompra.AutoSize = true;
            this.chkOtrosCrearOrdenesCompra.Location = new System.Drawing.Point(20, 232);
            this.chkOtrosCrearOrdenesCompra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkOtrosCrearOrdenesCompra.Name = "chkOtrosCrearOrdenesCompra";
            this.chkOtrosCrearOrdenesCompra.Size = new System.Drawing.Size(215, 24);
            this.chkOtrosCrearOrdenesCompra.TabIndex = 6;
            this.chkOtrosCrearOrdenesCompra.Tag = "otros_crear_ordenes_compra";
            this.chkOtrosCrearOrdenesCompra.Text = "Crear ordenes de compra";
            this.chkOtrosCrearOrdenesCompra.UseVisualStyleBackColor = true;
            // 
            // chkOtrosAccederReportes
            // 
            this.chkOtrosAccederReportes.AutoSize = true;
            this.chkOtrosAccederReportes.Location = new System.Drawing.Point(20, 197);
            this.chkOtrosAccederReportes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkOtrosAccederReportes.Name = "chkOtrosAccederReportes";
            this.chkOtrosAccederReportes.Size = new System.Drawing.Size(355, 24);
            this.chkOtrosAccederReportes.TabIndex = 5;
            this.chkOtrosAccederReportes.Tag = "otros_acceder_reportes";
            this.chkOtrosAccederReportes.Text = "Acceder a los reportes de ventas y ganancias";
            this.chkOtrosAccederReportes.UseVisualStyleBackColor = true;
            // 
            // chkOtrosCambiarConfiguracion
            // 
            this.chkOtrosCambiarConfiguracion.AutoSize = true;
            this.chkOtrosCambiarConfiguracion.Location = new System.Drawing.Point(20, 162);
            this.chkOtrosCambiarConfiguracion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkOtrosCambiarConfiguracion.Name = "chkOtrosCambiarConfiguracion";
            this.chkOtrosCambiarConfiguracion.Size = new System.Drawing.Size(306, 24);
            this.chkOtrosCambiarConfiguracion.TabIndex = 4;
            this.chkOtrosCambiarConfiguracion.Tag = "otros_cambiar_configuracion";
            this.chkOtrosCambiarConfiguracion.Text = "Cambiar la configuración del programa";
            this.chkOtrosCambiarConfiguracion.UseVisualStyleBackColor = true;
            // 
            // chkOtrosVerGananciaDia
            // 
            this.chkOtrosVerGananciaDia.AutoSize = true;
            this.chkOtrosVerGananciaDia.Location = new System.Drawing.Point(20, 126);
            this.chkOtrosVerGananciaDia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkOtrosVerGananciaDia.Name = "chkOtrosVerGananciaDia";
            this.chkOtrosVerGananciaDia.Size = new System.Drawing.Size(195, 24);
            this.chkOtrosVerGananciaDia.TabIndex = 3;
            this.chkOtrosVerGananciaDia.Tag = "otros_ver_ganancia_dia";
            this.chkOtrosVerGananciaDia.Text = "Ver la ganancia del día";
            this.chkOtrosVerGananciaDia.UseVisualStyleBackColor = true;
            // 
            // chkOtrosCorteDia
            // 
            this.chkOtrosCorteDia.AutoSize = true;
            this.chkOtrosCorteDia.Location = new System.Drawing.Point(20, 91);
            this.chkOtrosCorteDia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkOtrosCorteDia.Name = "chkOtrosCorteDia";
            this.chkOtrosCorteDia.Size = new System.Drawing.Size(330, 24);
            this.chkOtrosCorteDia.TabIndex = 2;
            this.chkOtrosCorteDia.Tag = "otros_corte_dia";
            this.chkOtrosCorteDia.Text = "Realizar el corte del día (Todos los turnos)";
            this.chkOtrosCorteDia.UseVisualStyleBackColor = true;
            // 
            // chkOtrosCorteTodosTurnos
            // 
            this.chkOtrosCorteTodosTurnos.AutoSize = true;
            this.chkOtrosCorteTodosTurnos.Location = new System.Drawing.Point(20, 55);
            this.chkOtrosCorteTodosTurnos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkOtrosCorteTodosTurnos.Name = "chkOtrosCorteTodosTurnos";
            this.chkOtrosCorteTodosTurnos.Size = new System.Drawing.Size(288, 24);
            this.chkOtrosCorteTodosTurnos.TabIndex = 1;
            this.chkOtrosCorteTodosTurnos.Tag = "otros_corte_todos_turnos";
            this.chkOtrosCorteTodosTurnos.Text = "Realizar el corte de todos los turnos";
            this.chkOtrosCorteTodosTurnos.UseVisualStyleBackColor = true;
            // 
            // chkOtrosCorteTurno
            // 
            this.chkOtrosCorteTurno.AutoSize = true;
            this.chkOtrosCorteTurno.Location = new System.Drawing.Point(20, 20);
            this.chkOtrosCorteTurno.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkOtrosCorteTurno.Name = "chkOtrosCorteTurno";
            this.chkOtrosCorteTurno.Size = new System.Drawing.Size(454, 24);
            this.chkOtrosCorteTurno.TabIndex = 0;
            this.chkOtrosCorteTurno.Tag = "otros_corte_turno";
            this.chkOtrosCorteTurno.Text = "Realizar el corte de su turno y ver efectivo esperado en caja";
            this.chkOtrosCorteTurno.UseVisualStyleBackColor = true;
            // 
            // panelBottomButtons
            // 
            this.panelBottomButtons.Controls.Add(this.btnCancelar);
            this.panelBottomButtons.Controls.Add(this.btnGuardarCajeroPermisos);
            this.panelBottomButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomButtons.Location = new System.Drawing.Point(4, 590);
            this.panelBottomButtons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelBottomButtons.Name = "panelBottomButtons";
            this.panelBottomButtons.Size = new System.Drawing.Size(813, 88);
            this.panelBottomButtons.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.Location = new System.Drawing.Point(420, 24);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(240, 46);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardarCajeroPermisos
            // 
            this.btnGuardarCajeroPermisos.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardarCajeroPermisos.Location = new System.Drawing.Point(117, 24);
            this.btnGuardarCajeroPermisos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardarCajeroPermisos.Name = "btnGuardarCajeroPermisos";
            this.btnGuardarCajeroPermisos.Size = new System.Drawing.Size(255, 46);
            this.btnGuardarCajeroPermisos.TabIndex = 0;
            this.btnGuardarCajeroPermisos.Text = "Guardar Cajero y Permisos";
            this.btnGuardarCajeroPermisos.UseVisualStyleBackColor = true;
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1224, 784);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmConfiguracion";
            this.Text = "FrmConfiguracion";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajeros)).EndInit();
            this.panelLeftTop.ResumeLayout(false);
            this.panelLeftTop.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.tableRight.ResumeLayout(false);
            this.tableRight.PerformLayout();
            this.panelRightTopButtons.ResumeLayout(false);
            this.tableCampos.ResumeLayout(false);
            this.tableCampos.PerformLayout();
            this.tabPermisos.ResumeLayout(false);
            this.tabVentas.ResumeLayout(false);
            this.tabVentas.PerformLayout();
            this.tabClientes.ResumeLayout(false);
            this.tabClientes.PerformLayout();
            this.tabProductos.ResumeLayout(false);
            this.tabProductos.PerformLayout();
            this.tabInventario.ResumeLayout(false);
            this.tabInventario.PerformLayout();
            this.tabOtros.ResumeLayout(false);
            this.tabOtros.PerformLayout();
            this.panelBottomButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelLeftTop;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvCajeros;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.TableLayoutPanel tableRight;
        private System.Windows.Forms.Panel panelRightTopButtons;
        private System.Windows.Forms.Button btnDarBajaCajero;
        private System.Windows.Forms.Button btnNuevoCajero;
        private System.Windows.Forms.Label lblNuevoCajero;
        private System.Windows.Forms.TableLayoutPanel tableCampos;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.TabControl tabPermisos;
        private System.Windows.Forms.TabPage tabVentas;
        private System.Windows.Forms.TabPage tabClientes;
        private System.Windows.Forms.TabPage tabProductos;
        private System.Windows.Forms.TabPage tabInventario;
        private System.Windows.Forms.TabPage tabOtros;
        private System.Windows.Forms.Panel panelBottomButtons;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardarCajeroPermisos;

        private System.Windows.Forms.CheckBox chkVentasProductoComun;
        private System.Windows.Forms.CheckBox chkVentasAplicarMayoreo;
        private System.Windows.Forms.CheckBox chkVentasAplicarDescuento;
        private System.Windows.Forms.CheckBox chkVentasRevisarHistorial;
        private System.Windows.Forms.CheckBox chkVentasEntradasEfectivo;
        private System.Windows.Forms.CheckBox chkVentasSalidasEfectivo;
        private System.Windows.Forms.CheckBox chkVentasCobrarTicket;
        private System.Windows.Forms.CheckBox chkVentasCobrarCredito;
        private System.Windows.Forms.CheckBox chkVentasCancelarTickets;
        private System.Windows.Forms.CheckBox chkVentasEliminarArticulosVenta;
        private System.Windows.Forms.CheckBox chkVentasFacturar;
        private System.Windows.Forms.CheckBox chkVentasVerFacturas;
        private System.Windows.Forms.CheckBox chkVentasVenderPagoServicio;
        private System.Windows.Forms.CheckBox chkVentasVenderRecargas;
        private System.Windows.Forms.CheckBox chkVentasUsarBuscador;

        private System.Windows.Forms.CheckBox chkClientesABC;
        private System.Windows.Forms.CheckBox chkClientesAsignarVenta;
        private System.Windows.Forms.CheckBox chkClientesAsignarCredito;
        private System.Windows.Forms.CheckBox chkClientesVerCuenta;

        private System.Windows.Forms.CheckBox chkProductosCrear;
        private System.Windows.Forms.CheckBox chkProductosModificar;
        private System.Windows.Forms.CheckBox chkProductosEliminar;
        private System.Windows.Forms.CheckBox chkProductosVerReporteVentas;
        private System.Windows.Forms.CheckBox chkProductosCrearPromociones;
        private System.Windows.Forms.CheckBox chkProductosModificarVarios;

        private System.Windows.Forms.CheckBox chkInventarioAgregarMercancia;
        private System.Windows.Forms.CheckBox chkInventarioVerReportes;
        private System.Windows.Forms.CheckBox chkInventarioVerMovimientos;
        private System.Windows.Forms.CheckBox chkInventarioAjustar;

        private System.Windows.Forms.CheckBox chkOtrosCorteTurno;
        private System.Windows.Forms.CheckBox chkOtrosCorteTodosTurnos;
        private System.Windows.Forms.CheckBox chkOtrosCorteDia;
        private System.Windows.Forms.CheckBox chkOtrosVerGananciaDia;
        private System.Windows.Forms.CheckBox chkOtrosCambiarConfiguracion;
        private System.Windows.Forms.CheckBox chkOtrosAccederReportes;
        private System.Windows.Forms.CheckBox chkOtrosCrearOrdenesCompra;
        private System.Windows.Forms.CheckBox chkOtrosRecibirOrdenesCompra;
    }
}
