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
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 46);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 11);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(177, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "CONFIGURACION";
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 46);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.panelLeft);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.panelRight);
            this.splitMain.Size = new System.Drawing.Size(1200, 654);
            this.splitMain.SplitterDistance = 360;
            this.splitMain.TabIndex = 1;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.dgvCajeros);
            this.panelLeft.Controls.Add(this.panelLeftTop);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(360, 654);
            this.panelLeft.TabIndex = 0;
            // 
            // dgvCajeros
            // 
            this.dgvCajeros.BackgroundColor = System.Drawing.Color.White;
            this.dgvCajeros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvCajeros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCajeros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCajeros.Location = new System.Drawing.Point(0, 46);
            this.dgvCajeros.Name = "dgvCajeros";
            this.dgvCajeros.Size = new System.Drawing.Size(360, 608);
            this.dgvCajeros.TabIndex = 1;
            // 
            // panelLeftTop
            // 
            this.panelLeftTop.Controls.Add(this.txtBuscar);
            this.panelLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeftTop.Location = new System.Drawing.Point(0, 0);
            this.panelLeftTop.Name = "panelLeftTop";
            this.panelLeftTop.Padding = new System.Windows.Forms.Padding(10);
            this.panelLeftTop.Size = new System.Drawing.Size(360, 46);
            this.panelLeftTop.TabIndex = 0;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuscar.Location = new System.Drawing.Point(10, 10);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(340, 20);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.Text = "Buscar ...";
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.tableRight);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(10);
            this.panelRight.Size = new System.Drawing.Size(836, 654);
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
            this.tableRight.Location = new System.Drawing.Point(10, 10);
            this.tableRight.Name = "tableRight";
            this.tableRight.RowCount = 5;
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableRight.Size = new System.Drawing.Size(816, 634);
            this.tableRight.TabIndex = 0;
            // 
            // panelRightTopButtons
            // 
            this.panelRightTopButtons.Controls.Add(this.btnDarBajaCajero);
            this.panelRightTopButtons.Controls.Add(this.btnNuevoCajero);
            this.panelRightTopButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightTopButtons.Location = new System.Drawing.Point(3, 3);
            this.panelRightTopButtons.Name = "panelRightTopButtons";
            this.panelRightTopButtons.Size = new System.Drawing.Size(810, 36);
            this.panelRightTopButtons.TabIndex = 0;
            // 
            // btnDarBajaCajero
            // 
            this.btnDarBajaCajero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDarBajaCajero.Location = new System.Drawing.Point(128, 6);
            this.btnDarBajaCajero.Name = "btnDarBajaCajero";
            this.btnDarBajaCajero.Size = new System.Drawing.Size(120, 26);
            this.btnDarBajaCajero.TabIndex = 1;
            this.btnDarBajaCajero.Text = "Dar de Baja Cajero";
            this.btnDarBajaCajero.UseVisualStyleBackColor = true;
            // 
            // btnNuevoCajero
            // 
            this.btnNuevoCajero.Location = new System.Drawing.Point(3, 6);
            this.btnNuevoCajero.Name = "btnNuevoCajero";
            this.btnNuevoCajero.Size = new System.Drawing.Size(119, 26);
            this.btnNuevoCajero.TabIndex = 0;
            this.btnNuevoCajero.Text = "Nuevo Cajero";
            this.btnNuevoCajero.UseVisualStyleBackColor = true;
            // 
            // lblNuevoCajero
            // 
            this.lblNuevoCajero.AutoSize = true;
            this.lblNuevoCajero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNuevoCajero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblNuevoCajero.Location = new System.Drawing.Point(3, 42);
            this.lblNuevoCajero.Name = "lblNuevoCajero";
            this.lblNuevoCajero.Padding = new System.Windows.Forms.Padding(2, 4, 0, 0);
            this.lblNuevoCajero.Size = new System.Drawing.Size(810, 24);
            this.lblNuevoCajero.TabIndex = 1;
            this.lblNuevoCajero.Text = "NUEVO CAJERO";
            // 
            // tableCampos
            // 
            this.tableCampos.ColumnCount = 2;
            this.tableCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableCampos.Controls.Add(this.lblUsuario, 0, 0);
            this.tableCampos.Controls.Add(this.lblContrasena, 0, 1);
            this.tableCampos.Controls.Add(this.lblNombreCompleto, 0, 2);
            this.tableCampos.Controls.Add(this.txtUsuario, 1, 0);
            this.tableCampos.Controls.Add(this.txtContrasena, 1, 1);
            this.tableCampos.Controls.Add(this.txtNombreCompleto, 1, 2);
            this.tableCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableCampos.Location = new System.Drawing.Point(3, 69);
            this.tableCampos.Name = "tableCampos";
            this.tableCampos.RowCount = 3;
            this.tableCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableCampos.Size = new System.Drawing.Size(810, 84);
            this.tableCampos.TabIndex = 2;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsuario.Location = new System.Drawing.Point(3, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblUsuario.Size = new System.Drawing.Size(104, 28);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContrasena.Location = new System.Drawing.Point(3, 28);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblContrasena.Size = new System.Drawing.Size(104, 28);
            this.lblContrasena.TabIndex = 1;
            this.lblContrasena.Text = "Contraseña";
            this.lblContrasena.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNombreCompleto.Location = new System.Drawing.Point(3, 56);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblNombreCompleto.Size = new System.Drawing.Size(104, 28);
            this.lblNombreCompleto.TabIndex = 2;
            this.lblNombreCompleto.Text = "Nombre completo";
            this.lblNombreCompleto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsuario.Location = new System.Drawing.Point(113, 3);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(694, 20);
            this.txtUsuario.TabIndex = 3;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContrasena.Location = new System.Drawing.Point(113, 31);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(694, 20);
            this.txtContrasena.TabIndex = 4;
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNombreCompleto.Location = new System.Drawing.Point(113, 59);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(694, 20);
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
            this.tabPermisos.Location = new System.Drawing.Point(3, 159);
            this.tabPermisos.Name = "tabPermisos";
            this.tabPermisos.SelectedIndex = 0;
            this.tabPermisos.Size = new System.Drawing.Size(810, 408);
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
            this.tabVentas.Location = new System.Drawing.Point(4, 22);
            this.tabVentas.Name = "tabVentas";
            this.tabVentas.Padding = new System.Windows.Forms.Padding(10);
            this.tabVentas.Size = new System.Drawing.Size(802, 382);
            this.tabVentas.TabIndex = 0;
            this.tabVentas.Text = "Ventas";
            this.tabVentas.UseVisualStyleBackColor = true;
            // 
            // Ventas checkboxes
            // 
            this.chkVentasProductoComun.AutoSize = true;
            this.chkVentasProductoComun.Location = new System.Drawing.Point(13, 13);
            this.chkVentasProductoComun.Name = "chkVentasProductoComun";
            this.chkVentasProductoComun.Size = new System.Drawing.Size(132, 17);
            this.chkVentasProductoComun.TabIndex = 0;
            this.chkVentasProductoComun.Tag = "ventas_producto_comun";
            this.chkVentasProductoComun.Text = "Utilizar Producto Común";
            this.chkVentasProductoComun.UseVisualStyleBackColor = true;
            this.chkVentasAplicarMayoreo.AutoSize = true;
            this.chkVentasAplicarMayoreo.Location = new System.Drawing.Point(13, 36);
            this.chkVentasAplicarMayoreo.Name = "chkVentasAplicarMayoreo";
            this.chkVentasAplicarMayoreo.Size = new System.Drawing.Size(96, 17);
            this.chkVentasAplicarMayoreo.TabIndex = 1;
            this.chkVentasAplicarMayoreo.Tag = "ventas_aplicar_mayoreo";
            this.chkVentasAplicarMayoreo.Text = "Aplicar Mayoreo";
            this.chkVentasAplicarMayoreo.UseVisualStyleBackColor = true;
            this.chkVentasAplicarDescuento.AutoSize = true;
            this.chkVentasAplicarDescuento.Location = new System.Drawing.Point(13, 59);
            this.chkVentasAplicarDescuento.Name = "chkVentasAplicarDescuento";
            this.chkVentasAplicarDescuento.Size = new System.Drawing.Size(108, 17);
            this.chkVentasAplicarDescuento.TabIndex = 2;
            this.chkVentasAplicarDescuento.Tag = "ventas_aplicar_descuento";
            this.chkVentasAplicarDescuento.Text = "Aplicar Descuento";
            this.chkVentasAplicarDescuento.UseVisualStyleBackColor = true;
            this.chkVentasRevisarHistorial.AutoSize = true;
            this.chkVentasRevisarHistorial.Location = new System.Drawing.Point(13, 82);
            this.chkVentasRevisarHistorial.Name = "chkVentasRevisarHistorial";
            this.chkVentasRevisarHistorial.Size = new System.Drawing.Size(146, 17);
            this.chkVentasRevisarHistorial.TabIndex = 3;
            this.chkVentasRevisarHistorial.Tag = "ventas_revisar_historial";
            this.chkVentasRevisarHistorial.Text = "Revisar el historial de Ventas";
            this.chkVentasRevisarHistorial.UseVisualStyleBackColor = true;
            this.chkVentasEntradasEfectivo.AutoSize = true;
            this.chkVentasEntradasEfectivo.Location = new System.Drawing.Point(13, 105);
            this.chkVentasEntradasEfectivo.Name = "chkVentasEntradasEfectivo";
            this.chkVentasEntradasEfectivo.Size = new System.Drawing.Size(158, 17);
            this.chkVentasEntradasEfectivo.TabIndex = 4;
            this.chkVentasEntradasEfectivo.Tag = "ventas_entradas_efectivo";
            this.chkVentasEntradasEfectivo.Text = "Registrar Entradas de Efectivo";
            this.chkVentasEntradasEfectivo.UseVisualStyleBackColor = true;
            this.chkVentasSalidasEfectivo.AutoSize = true;
            this.chkVentasSalidasEfectivo.Location = new System.Drawing.Point(13, 128);
            this.chkVentasSalidasEfectivo.Name = "chkVentasSalidasEfectivo";
            this.chkVentasSalidasEfectivo.Size = new System.Drawing.Size(151, 17);
            this.chkVentasSalidasEfectivo.TabIndex = 5;
            this.chkVentasSalidasEfectivo.Tag = "ventas_salidas_efectivo";
            this.chkVentasSalidasEfectivo.Text = "Registrar Salidas de Efectivo";
            this.chkVentasSalidasEfectivo.UseVisualStyleBackColor = true;
            this.chkVentasCobrarTicket.AutoSize = true;
            this.chkVentasCobrarTicket.Location = new System.Drawing.Point(13, 151);
            this.chkVentasCobrarTicket.Name = "chkVentasCobrarTicket";
            this.chkVentasCobrarTicket.Size = new System.Drawing.Size(100, 17);
            this.chkVentasCobrarTicket.TabIndex = 6;
            this.chkVentasCobrarTicket.Tag = "ventas_cobrar_ticket";
            this.chkVentasCobrarTicket.Text = "Cobrar un ticket";
            this.chkVentasCobrarTicket.UseVisualStyleBackColor = true;
            this.chkVentasCobrarCredito.AutoSize = true;
            this.chkVentasCobrarCredito.Location = new System.Drawing.Point(13, 174);
            this.chkVentasCobrarCredito.Name = "chkVentasCobrarCredito";
            this.chkVentasCobrarCredito.Size = new System.Drawing.Size(102, 17);
            this.chkVentasCobrarCredito.TabIndex = 7;
            this.chkVentasCobrarCredito.Tag = "ventas_cobrar_credito";
            this.chkVentasCobrarCredito.Text = "Cobrar a crédito";
            this.chkVentasCobrarCredito.UseVisualStyleBackColor = true;

            this.chkVentasCancelarTickets.AutoSize = true;
            this.chkVentasCancelarTickets.Location = new System.Drawing.Point(350, 13);
            this.chkVentasCancelarTickets.Name = "chkVentasCancelarTickets";
            this.chkVentasCancelarTickets.Size = new System.Drawing.Size(187, 17);
            this.chkVentasCancelarTickets.TabIndex = 8;
            this.chkVentasCancelarTickets.Tag = "ventas_cancelar_tickets";
            this.chkVentasCancelarTickets.Text = "Cancelar tickets y devolver artículos";
            this.chkVentasCancelarTickets.UseVisualStyleBackColor = true;
            this.chkVentasEliminarArticulosVenta.AutoSize = true;
            this.chkVentasEliminarArticulosVenta.Location = new System.Drawing.Point(350, 36);
            this.chkVentasEliminarArticulosVenta.Name = "chkVentasEliminarArticulosVenta";
            this.chkVentasEliminarArticulosVenta.Size = new System.Drawing.Size(152, 17);
            this.chkVentasEliminarArticulosVenta.TabIndex = 9;
            this.chkVentasEliminarArticulosVenta.Tag = "ventas_eliminar_articulos";
            this.chkVentasEliminarArticulosVenta.Text = "Eliminar artículos de venta";
            this.chkVentasEliminarArticulosVenta.UseVisualStyleBackColor = true;
            this.chkVentasFacturar.AutoSize = true;
            this.chkVentasFacturar.Location = new System.Drawing.Point(350, 59);
            this.chkVentasFacturar.Name = "chkVentasFacturar";
            this.chkVentasFacturar.Size = new System.Drawing.Size(66, 17);
            this.chkVentasFacturar.TabIndex = 10;
            this.chkVentasFacturar.Tag = "ventas_facturar";
            this.chkVentasFacturar.Text = "Facturar";
            this.chkVentasFacturar.UseVisualStyleBackColor = true;
            this.chkVentasVerFacturas.AutoSize = true;
            this.chkVentasVerFacturas.Location = new System.Drawing.Point(350, 82);
            this.chkVentasVerFacturas.Name = "chkVentasVerFacturas";
            this.chkVentasVerFacturas.Size = new System.Drawing.Size(91, 17);
            this.chkVentasVerFacturas.TabIndex = 11;
            this.chkVentasVerFacturas.Tag = "ventas_ver_facturas";
            this.chkVentasVerFacturas.Text = "Ver Facturas";
            this.chkVentasVerFacturas.UseVisualStyleBackColor = true;
            this.chkVentasVenderPagoServicio.AutoSize = true;
            this.chkVentasVenderPagoServicio.Location = new System.Drawing.Point(350, 105);
            this.chkVentasVenderPagoServicio.Name = "chkVentasVenderPagoServicio";
            this.chkVentasVenderPagoServicio.Size = new System.Drawing.Size(146, 17);
            this.chkVentasVenderPagoServicio.TabIndex = 12;
            this.chkVentasVenderPagoServicio.Tag = "ventas_vender_pago_servicio";
            this.chkVentasVenderPagoServicio.Text = "Vender un pago de servicio";
            this.chkVentasVenderPagoServicio.UseVisualStyleBackColor = true;
            this.chkVentasVenderRecargas.AutoSize = true;
            this.chkVentasVenderRecargas.Location = new System.Drawing.Point(350, 128);
            this.chkVentasVenderRecargas.Name = "chkVentasVenderRecargas";
            this.chkVentasVenderRecargas.Size = new System.Drawing.Size(138, 17);
            this.chkVentasVenderRecargas.TabIndex = 13;
            this.chkVentasVenderRecargas.Tag = "ventas_vender_recargas";
            this.chkVentasVenderRecargas.Text = "Vender Recargas Electrónicas";
            this.chkVentasVenderRecargas.UseVisualStyleBackColor = true;
            this.chkVentasUsarBuscador.AutoSize = true;
            this.chkVentasUsarBuscador.Location = new System.Drawing.Point(350, 151);
            this.chkVentasUsarBuscador.Name = "chkVentasUsarBuscador";
            this.chkVentasUsarBuscador.Size = new System.Drawing.Size(136, 17);
            this.chkVentasUsarBuscador.TabIndex = 14;
            this.chkVentasUsarBuscador.Tag = "ventas_usar_buscador";
            this.chkVentasUsarBuscador.Text = "Usar buscador de productos";
            this.chkVentasUsarBuscador.UseVisualStyleBackColor = true;
            // 
            // tabClientes
            // 
            this.tabClientes.Controls.Add(this.chkClientesVerCuenta);
            this.tabClientes.Controls.Add(this.chkClientesAsignarCredito);
            this.tabClientes.Controls.Add(this.chkClientesAsignarVenta);
            this.tabClientes.Controls.Add(this.chkClientesABC);
            this.tabClientes.Location = new System.Drawing.Point(4, 22);
            this.tabClientes.Name = "tabClientes";
            this.tabClientes.Padding = new System.Windows.Forms.Padding(10);
            this.tabClientes.Size = new System.Drawing.Size(802, 382);
            this.tabClientes.TabIndex = 1;
            this.tabClientes.Text = "Clientes";
            this.tabClientes.UseVisualStyleBackColor = true;
            // 
            // Clientes checkboxes
            // 
            this.chkClientesABC.AutoSize = true;
            this.chkClientesABC.Location = new System.Drawing.Point(13, 13);
            this.chkClientesABC.Name = "chkClientesABC";
            this.chkClientesABC.Size = new System.Drawing.Size(191, 17);
            this.chkClientesABC.TabIndex = 0;
            this.chkClientesABC.Tag = "clientes_abc";
            this.chkClientesABC.Text = "Crear, modificar o eliminar clientes";
            this.chkClientesABC.UseVisualStyleBackColor = true;
            this.chkClientesAsignarVenta.AutoSize = true;
            this.chkClientesAsignarVenta.Location = new System.Drawing.Point(13, 36);
            this.chkClientesAsignarVenta.Name = "chkClientesAsignarVenta";
            this.chkClientesAsignarVenta.Size = new System.Drawing.Size(147, 17);
            this.chkClientesAsignarVenta.TabIndex = 1;
            this.chkClientesAsignarVenta.Tag = "clientes_asignar_venta";
            this.chkClientesAsignarVenta.Text = "Asignar cliente a una venta";
            this.chkClientesAsignarVenta.UseVisualStyleBackColor = true;
            this.chkClientesAsignarCredito.AutoSize = true;
            this.chkClientesAsignarCredito.Location = new System.Drawing.Point(13, 59);
            this.chkClientesAsignarCredito.Name = "chkClientesAsignarCredito";
            this.chkClientesAsignarCredito.Size = new System.Drawing.Size(189, 17);
            this.chkClientesAsignarCredito.TabIndex = 2;
            this.chkClientesAsignarCredito.Tag = "clientes_asignar_credito";
            this.chkClientesAsignarCredito.Text = "Asignar o remover crédito a clientes";
            this.chkClientesAsignarCredito.UseVisualStyleBackColor = true;
            this.chkClientesVerCuenta.AutoSize = true;
            this.chkClientesVerCuenta.Location = new System.Drawing.Point(13, 82);
            this.chkClientesVerCuenta.Name = "chkClientesVerCuenta";
            this.chkClientesVerCuenta.Size = new System.Drawing.Size(261, 17);
            this.chkClientesVerCuenta.TabIndex = 3;
            this.chkClientesVerCuenta.Tag = "clientes_ver_cuenta";
            this.chkClientesVerCuenta.Text = "Ver cuenta, recibir abonos y reportes de clientes a crédito";
            this.chkClientesVerCuenta.UseVisualStyleBackColor = true;
            // 
            // tabProductos
            // 
            this.tabProductos.Controls.Add(this.chkProductosModificarVarios);
            this.tabProductos.Controls.Add(this.chkProductosCrearPromociones);
            this.tabProductos.Controls.Add(this.chkProductosVerReporteVentas);
            this.tabProductos.Controls.Add(this.chkProductosEliminar);
            this.tabProductos.Controls.Add(this.chkProductosModificar);
            this.tabProductos.Controls.Add(this.chkProductosCrear);
            this.tabProductos.Location = new System.Drawing.Point(4, 22);
            this.tabProductos.Name = "tabProductos";
            this.tabProductos.Padding = new System.Windows.Forms.Padding(10);
            this.tabProductos.Size = new System.Drawing.Size(802, 382);
            this.tabProductos.TabIndex = 2;
            this.tabProductos.Text = "Productos";
            this.tabProductos.UseVisualStyleBackColor = true;
            // 
            // Productos checkboxes
            // 
            this.chkProductosCrear.AutoSize = true;
            this.chkProductosCrear.Location = new System.Drawing.Point(13, 13);
            this.chkProductosCrear.Name = "chkProductosCrear";
            this.chkProductosCrear.Size = new System.Drawing.Size(132, 17);
            this.chkProductosCrear.TabIndex = 0;
            this.chkProductosCrear.Tag = "productos_crear";
            this.chkProductosCrear.Text = "Crear nuevos productos";
            this.chkProductosCrear.UseVisualStyleBackColor = true;
            this.chkProductosModificar.AutoSize = true;
            this.chkProductosModificar.Location = new System.Drawing.Point(13, 36);
            this.chkProductosModificar.Name = "chkProductosModificar";
            this.chkProductosModificar.Size = new System.Drawing.Size(110, 17);
            this.chkProductosModificar.TabIndex = 1;
            this.chkProductosModificar.Tag = "productos_modificar";
            this.chkProductosModificar.Text = "Modificar productos";
            this.chkProductosModificar.UseVisualStyleBackColor = true;
            this.chkProductosEliminar.AutoSize = true;
            this.chkProductosEliminar.Location = new System.Drawing.Point(13, 59);
            this.chkProductosEliminar.Name = "chkProductosEliminar";
            this.chkProductosEliminar.Size = new System.Drawing.Size(106, 17);
            this.chkProductosEliminar.TabIndex = 2;
            this.chkProductosEliminar.Tag = "productos_eliminar";
            this.chkProductosEliminar.Text = "Eliminar productos";
            this.chkProductosEliminar.UseVisualStyleBackColor = true;
            this.chkProductosVerReporteVentas.AutoSize = true;
            this.chkProductosVerReporteVentas.Location = new System.Drawing.Point(13, 82);
            this.chkProductosVerReporteVentas.Name = "chkProductosVerReporteVentas";
            this.chkProductosVerReporteVentas.Size = new System.Drawing.Size(114, 17);
            this.chkProductosVerReporteVentas.TabIndex = 3;
            this.chkProductosVerReporteVentas.Tag = "productos_ver_reporte_ventas";
            this.chkProductosVerReporteVentas.Text = "Ver reporte de ventas";
            this.chkProductosVerReporteVentas.UseVisualStyleBackColor = true;
            this.chkProductosCrearPromociones.AutoSize = true;
            this.chkProductosCrearPromociones.Location = new System.Drawing.Point(13, 105);
            this.chkProductosCrearPromociones.Name = "chkProductosCrearPromociones";
            this.chkProductosCrearPromociones.Size = new System.Drawing.Size(115, 17);
            this.chkProductosCrearPromociones.TabIndex = 4;
            this.chkProductosCrearPromociones.Tag = "productos_crear_promociones";
            this.chkProductosCrearPromociones.Text = "Crear promociones";
            this.chkProductosCrearPromociones.UseVisualStyleBackColor = true;
            this.chkProductosModificarVarios.AutoSize = true;
            this.chkProductosModificarVarios.Location = new System.Drawing.Point(13, 128);
            this.chkProductosModificarVarios.Name = "chkProductosModificarVarios";
            this.chkProductosModificarVarios.Size = new System.Drawing.Size(97, 17);
            this.chkProductosModificarVarios.TabIndex = 5;
            this.chkProductosModificarVarios.Tag = "productos_modificar_varios";
            this.chkProductosModificarVarios.Text = "Modificar Varios";
            this.chkProductosModificarVarios.UseVisualStyleBackColor = true;
            // 
            // tabInventario
            // 
            this.tabInventario.Controls.Add(this.chkInventarioAjustar);
            this.tabInventario.Controls.Add(this.chkInventarioVerMovimientos);
            this.tabInventario.Controls.Add(this.chkInventarioVerReportes);
            this.tabInventario.Controls.Add(this.chkInventarioAgregarMercancia);
            this.tabInventario.Location = new System.Drawing.Point(4, 22);
            this.tabInventario.Name = "tabInventario";
            this.tabInventario.Padding = new System.Windows.Forms.Padding(10);
            this.tabInventario.Size = new System.Drawing.Size(802, 382);
            this.tabInventario.TabIndex = 3;
            this.tabInventario.Text = "Inventario";
            this.tabInventario.UseVisualStyleBackColor = true;
            // 
            // Inventario checkboxes
            // 
            this.chkInventarioAgregarMercancia.AutoSize = true;
            this.chkInventarioAgregarMercancia.Location = new System.Drawing.Point(13, 13);
            this.chkInventarioAgregarMercancia.Name = "chkInventarioAgregarMercancia";
            this.chkInventarioAgregarMercancia.Size = new System.Drawing.Size(114, 17);
            this.chkInventarioAgregarMercancia.TabIndex = 0;
            this.chkInventarioAgregarMercancia.Tag = "inventario_agregar_mercancia";
            this.chkInventarioAgregarMercancia.Text = "Agregar mercancía";
            this.chkInventarioAgregarMercancia.UseVisualStyleBackColor = true;
            this.chkInventarioVerReportes.AutoSize = true;
            this.chkInventarioVerReportes.Location = new System.Drawing.Point(13, 36);
            this.chkInventarioVerReportes.Name = "chkInventarioVerReportes";
            this.chkInventarioVerReportes.Size = new System.Drawing.Size(175, 17);
            this.chkInventarioVerReportes.TabIndex = 1;
            this.chkInventarioVerReportes.Tag = "inventario_ver_reportes";
            this.chkInventarioVerReportes.Text = "Ver reportes de existencias y mínimos";
            this.chkInventarioVerReportes.UseVisualStyleBackColor = true;
            this.chkInventarioVerMovimientos.AutoSize = true;
            this.chkInventarioVerMovimientos.Location = new System.Drawing.Point(13, 59);
            this.chkInventarioVerMovimientos.Name = "chkInventarioVerMovimientos";
            this.chkInventarioVerMovimientos.Size = new System.Drawing.Size(148, 17);
            this.chkInventarioVerMovimientos.TabIndex = 2;
            this.chkInventarioVerMovimientos.Tag = "inventario_ver_movimientos";
            this.chkInventarioVerMovimientos.Text = "Ver movimiento de inventarios";
            this.chkInventarioVerMovimientos.UseVisualStyleBackColor = true;
            this.chkInventarioAjustar.AutoSize = true;
            this.chkInventarioAjustar.Location = new System.Drawing.Point(13, 82);
            this.chkInventarioAjustar.Name = "chkInventarioAjustar";
            this.chkInventarioAjustar.Size = new System.Drawing.Size(104, 17);
            this.chkInventarioAjustar.TabIndex = 3;
            this.chkInventarioAjustar.Tag = "inventario_ajustar";
            this.chkInventarioAjustar.Text = "Ajustar el inventario";
            this.chkInventarioAjustar.UseVisualStyleBackColor = true;
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
            this.tabOtros.Location = new System.Drawing.Point(4, 22);
            this.tabOtros.Name = "tabOtros";
            this.tabOtros.Padding = new System.Windows.Forms.Padding(10);
            this.tabOtros.Size = new System.Drawing.Size(802, 382);
            this.tabOtros.TabIndex = 4;
            this.tabOtros.Text = "Otros";
            this.tabOtros.UseVisualStyleBackColor = true;
            // 
            // Otros checkboxes
            // 
            this.chkOtrosCorteTurno.AutoSize = true;
            this.chkOtrosCorteTurno.Location = new System.Drawing.Point(13, 13);
            this.chkOtrosCorteTurno.Name = "chkOtrosCorteTurno";
            this.chkOtrosCorteTurno.Size = new System.Drawing.Size(258, 17);
            this.chkOtrosCorteTurno.TabIndex = 0;
            this.chkOtrosCorteTurno.Tag = "otros_corte_turno";
            this.chkOtrosCorteTurno.Text = "Realizar el corte de su turno y ver efectivo esperado en caja";
            this.chkOtrosCorteTurno.UseVisualStyleBackColor = true;
            this.chkOtrosCorteTodosTurnos.AutoSize = true;
            this.chkOtrosCorteTodosTurnos.Location = new System.Drawing.Point(13, 36);
            this.chkOtrosCorteTodosTurnos.Name = "chkOtrosCorteTodosTurnos";
            this.chkOtrosCorteTodosTurnos.Size = new System.Drawing.Size(206, 17);
            this.chkOtrosCorteTodosTurnos.TabIndex = 1;
            this.chkOtrosCorteTodosTurnos.Tag = "otros_corte_todos_turnos";
            this.chkOtrosCorteTodosTurnos.Text = "Realizar el corte de todos los turnos";
            this.chkOtrosCorteTodosTurnos.UseVisualStyleBackColor = true;
            this.chkOtrosCorteDia.AutoSize = true;
            this.chkOtrosCorteDia.Location = new System.Drawing.Point(13, 59);
            this.chkOtrosCorteDia.Name = "chkOtrosCorteDia";
            this.chkOtrosCorteDia.Size = new System.Drawing.Size(214, 17);
            this.chkOtrosCorteDia.TabIndex = 2;
            this.chkOtrosCorteDia.Tag = "otros_corte_dia";
            this.chkOtrosCorteDia.Text = "Realizar el corte del día (Todos los turnos)";
            this.chkOtrosCorteDia.UseVisualStyleBackColor = true;
            this.chkOtrosVerGananciaDia.AutoSize = true;
            this.chkOtrosVerGananciaDia.Location = new System.Drawing.Point(13, 82);
            this.chkOtrosVerGananciaDia.Name = "chkOtrosVerGananciaDia";
            this.chkOtrosVerGananciaDia.Size = new System.Drawing.Size(121, 17);
            this.chkOtrosVerGananciaDia.TabIndex = 3;
            this.chkOtrosVerGananciaDia.Tag = "otros_ver_ganancia_dia";
            this.chkOtrosVerGananciaDia.Text = "Ver la ganancia del día";
            this.chkOtrosVerGananciaDia.UseVisualStyleBackColor = true;
            this.chkOtrosCambiarConfiguracion.AutoSize = true;
            this.chkOtrosCambiarConfiguracion.Location = new System.Drawing.Point(13, 105);
            this.chkOtrosCambiarConfiguracion.Name = "chkOtrosCambiarConfiguracion";
            this.chkOtrosCambiarConfiguracion.Size = new System.Drawing.Size(184, 17);
            this.chkOtrosCambiarConfiguracion.TabIndex = 4;
            this.chkOtrosCambiarConfiguracion.Tag = "otros_cambiar_configuracion";
            this.chkOtrosCambiarConfiguracion.Text = "Cambiar la configuración del programa";
            this.chkOtrosCambiarConfiguracion.UseVisualStyleBackColor = true;
            this.chkOtrosAccederReportes.AutoSize = true;
            this.chkOtrosAccederReportes.Location = new System.Drawing.Point(13, 128);
            this.chkOtrosAccederReportes.Name = "chkOtrosAccederReportes";
            this.chkOtrosAccederReportes.Size = new System.Drawing.Size(211, 17);
            this.chkOtrosAccederReportes.TabIndex = 5;
            this.chkOtrosAccederReportes.Tag = "otros_acceder_reportes";
            this.chkOtrosAccederReportes.Text = "Acceder a los reportes de ventas y ganancias";
            this.chkOtrosAccederReportes.UseVisualStyleBackColor = true;
            this.chkOtrosCrearOrdenesCompra.AutoSize = true;
            this.chkOtrosCrearOrdenesCompra.Location = new System.Drawing.Point(13, 151);
            this.chkOtrosCrearOrdenesCompra.Name = "chkOtrosCrearOrdenesCompra";
            this.chkOtrosCrearOrdenesCompra.Size = new System.Drawing.Size(155, 17);
            this.chkOtrosCrearOrdenesCompra.TabIndex = 6;
            this.chkOtrosCrearOrdenesCompra.Tag = "otros_crear_ordenes_compra";
            this.chkOtrosCrearOrdenesCompra.Text = "Crear ordenes de compra";
            this.chkOtrosCrearOrdenesCompra.UseVisualStyleBackColor = true;
            this.chkOtrosRecibirOrdenesCompra.AutoSize = true;
            this.chkOtrosRecibirOrdenesCompra.Location = new System.Drawing.Point(13, 174);
            this.chkOtrosRecibirOrdenesCompra.Name = "chkOtrosRecibirOrdenesCompra";
            this.chkOtrosRecibirOrdenesCompra.Size = new System.Drawing.Size(136, 17);
            this.chkOtrosRecibirOrdenesCompra.TabIndex = 7;
            this.chkOtrosRecibirOrdenesCompra.Tag = "otros_recibir_ordenes_compra";
            this.chkOtrosRecibirOrdenesCompra.Text = "Recibir ordenes de compra";
            this.chkOtrosRecibirOrdenesCompra.UseVisualStyleBackColor = true;
            // 
            // panelBottomButtons
            // 
            this.panelBottomButtons.Controls.Add(this.btnCancelar);
            this.panelBottomButtons.Controls.Add(this.btnGuardarCajeroPermisos);
            this.panelBottomButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomButtons.Location = new System.Drawing.Point(3, 573);
            this.panelBottomButtons.Name = "panelBottomButtons";
            this.panelBottomButtons.Size = new System.Drawing.Size(810, 58);
            this.panelBottomButtons.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.Location = new System.Drawing.Point(414, 16);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(160, 30);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardarCajeroPermisos
            // 
            this.btnGuardarCajeroPermisos.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardarCajeroPermisos.Location = new System.Drawing.Point(238, 16);
            this.btnGuardarCajeroPermisos.Name = "btnGuardarCajeroPermisos";
            this.btnGuardarCajeroPermisos.Size = new System.Drawing.Size(170, 30);
            this.btnGuardarCajeroPermisos.TabIndex = 0;
            this.btnGuardarCajeroPermisos.Text = "Guardar Cajero y Permisos";
            this.btnGuardarCajeroPermisos.UseVisualStyleBackColor = true;
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
