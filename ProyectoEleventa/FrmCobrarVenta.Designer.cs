namespace ProyectoEleventa
{
    partial class FrmCobrarVenta
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnCobrarImprimir = new System.Windows.Forms.Button();
            this.btnCobrarSinImprimir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNotas = new System.Windows.Forms.Button();
            this.lblArticulosTitle = new System.Windows.Forms.Label();
            this.lblTotalArticulos = new System.Windows.Forms.Label();
            this.chkImprimirDatosCliente = new System.Windows.Forms.CheckBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnEfectivo = new System.Windows.Forms.Button();
            this.btnCredito = new System.Windows.Forms.Button();
            this.btnMixto = new System.Windows.Forms.Button();
            this.btnTransferencia = new System.Windows.Forms.Button();
            this.panelEfectivo = new System.Windows.Forms.Panel();
            this.lblPagoCon = new System.Windows.Forms.Label();
            this.txtPagoCon = new System.Windows.Forms.TextBox();
            this.lblCambioTitle = new System.Windows.Forms.Label();
            this.lblCambio = new System.Windows.Forms.Label();
            this.panelTransferencia = new System.Windows.Forms.Panel();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.chkImprimirVoucher = new System.Windows.Forms.CheckBox();
            this.panelCredito = new System.Windows.Forms.Panel();
            this.lblCreditoSinCliente = new System.Windows.Forms.Label();
            this.panelMixto = new System.Windows.Forms.Panel();
            this.lblMixtoEfectivo = new System.Windows.Forms.Label();
            this.txtMixtoEfectivo = new System.Windows.Forms.TextBox();
            this.lblMixtoCredito = new System.Windows.Forms.Label();
            this.txtMixtoCredito = new System.Windows.Forms.TextBox();
            this.lblMixtoTransferencia = new System.Windows.Forms.Label();
            this.txtMixtoTransferencia = new System.Windows.Forms.TextBox();
            this.lblRestanteTitle = new System.Windows.Forms.Label();
            this.lblMixtoRestante = new System.Windows.Forms.Label();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.panelHeader.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelEfectivo.SuspendLayout();
            this.panelTransferencia.SuspendLayout();
            this.panelCredito.SuspendLayout();
            this.panelMixto.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(104)))), ((int)(((byte)(121)))));
            this.panelHeader.Controls.Add(this.lblHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(860, 36);
            this.panelHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(10, 8);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(79, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "COBRAR";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.Gainsboro;
            this.panelRight.Controls.Add(this.chkImprimirDatosCliente);
            this.panelRight.Controls.Add(this.lblTotalArticulos);
            this.panelRight.Controls.Add(this.lblArticulosTitle);
            this.panelRight.Controls.Add(this.btnNotas);
            this.panelRight.Controls.Add(this.btnCancelar);
            this.panelRight.Controls.Add(this.btnCobrarSinImprimir);
            this.panelRight.Controls.Add(this.btnCobrarImprimir);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(640, 36);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(10);
            this.panelRight.Size = new System.Drawing.Size(220, 504);
            this.panelRight.TabIndex = 1;
            // 
            // btnCobrarImprimir
            // 
            this.btnCobrarImprimir.Location = new System.Drawing.Point(12, 12);
            this.btnCobrarImprimir.Name = "btnCobrarImprimir";
            this.btnCobrarImprimir.Size = new System.Drawing.Size(196, 38);
            this.btnCobrarImprimir.TabIndex = 0;
            this.btnCobrarImprimir.Text = "F1 - Cobrar e imprimir";
            this.btnCobrarImprimir.UseVisualStyleBackColor = true;
            this.btnCobrarImprimir.Click += new System.EventHandler(this.btnCobrarImprimir_Click);
            // 
            // btnCobrarSinImprimir
            // 
            this.btnCobrarSinImprimir.Location = new System.Drawing.Point(12, 56);
            this.btnCobrarSinImprimir.Name = "btnCobrarSinImprimir";
            this.btnCobrarSinImprimir.Size = new System.Drawing.Size(196, 38);
            this.btnCobrarSinImprimir.TabIndex = 1;
            this.btnCobrarSinImprimir.Text = "F2 - Cobrar sin imprimir";
            this.btnCobrarSinImprimir.UseVisualStyleBackColor = true;
            this.btnCobrarSinImprimir.Click += new System.EventHandler(this.btnCobrarSinImprimir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 100);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(196, 38);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "ESC - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNotas
            // 
            this.btnNotas.Location = new System.Drawing.Point(12, 160);
            this.btnNotas.Name = "btnNotas";
            this.btnNotas.Size = new System.Drawing.Size(196, 32);
            this.btnNotas.TabIndex = 3;
            this.btnNotas.Text = "F4 - Ingresar notas";
            this.btnNotas.UseVisualStyleBackColor = true;
            this.btnNotas.Click += new System.EventHandler(this.btnNotas_Click);
            // 
            // lblArticulosTitle
            // 
            this.lblArticulosTitle.AutoSize = true;
            this.lblArticulosTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblArticulosTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblArticulosTitle.Location = new System.Drawing.Point(12, 214);
            this.lblArticulosTitle.Name = "lblArticulosTitle";
            this.lblArticulosTitle.Size = new System.Drawing.Size(110, 15);
            this.lblArticulosTitle.TabIndex = 4;
            this.lblArticulosTitle.Text = "Total de Artículos:";
            // 
            // lblTotalArticulos
            // 
            this.lblTotalArticulos.AutoSize = true;
            this.lblTotalArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalArticulos.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalArticulos.Location = new System.Drawing.Point(40, 236);
            this.lblTotalArticulos.Name = "lblTotalArticulos";
            this.lblTotalArticulos.Size = new System.Drawing.Size(32, 31);
            this.lblTotalArticulos.TabIndex = 5;
            this.lblTotalArticulos.Text = "0";
            // 
            // chkImprimirDatosCliente
            // 
            this.chkImprimirDatosCliente.AutoSize = true;
            this.chkImprimirDatosCliente.Location = new System.Drawing.Point(15, 294);
            this.chkImprimirDatosCliente.Name = "chkImprimirDatosCliente";
            this.chkImprimirDatosCliente.Size = new System.Drawing.Size(141, 17);
            this.chkImprimirDatosCliente.TabIndex = 6;
            this.chkImprimirDatosCliente.Text = "Imprimir datos de cliente";
            this.chkImprimirDatosCliente.UseVisualStyleBackColor = true;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.txtNotas);
            this.panelMain.Controls.Add(this.panelMixto);
            this.panelMain.Controls.Add(this.panelCredito);
            this.panelMain.Controls.Add(this.panelTransferencia);
            this.panelMain.Controls.Add(this.panelEfectivo);
            this.panelMain.Controls.Add(this.btnTransferencia);
            this.panelMain.Controls.Add(this.btnMixto);
            this.panelMain.Controls.Add(this.btnCredito);
            this.panelMain.Controls.Add(this.btnEfectivo);
            this.panelMain.Controls.Add(this.lblTotal);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 36);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10);
            this.panelMain.Size = new System.Drawing.Size(640, 504);
            this.panelMain.TabIndex = 2;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 44F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(150)))));
            this.lblTotal.Location = new System.Drawing.Point(10, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(620, 88);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "$0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEfectivo
            // 
            this.btnEfectivo.Location = new System.Drawing.Point(22, 112);
            this.btnEfectivo.Name = "btnEfectivo";
            this.btnEfectivo.Size = new System.Drawing.Size(120, 36);
            this.btnEfectivo.TabIndex = 1;
            this.btnEfectivo.Text = "Efectivo";
            this.btnEfectivo.UseVisualStyleBackColor = true;
            this.btnEfectivo.Click += new System.EventHandler(this.btnEfectivo_Click);
            // 
            // btnCredito
            // 
            this.btnCredito.Location = new System.Drawing.Point(158, 112);
            this.btnCredito.Name = "btnCredito";
            this.btnCredito.Size = new System.Drawing.Size(120, 36);
            this.btnCredito.TabIndex = 2;
            this.btnCredito.Text = "Crédito";
            this.btnCredito.UseVisualStyleBackColor = true;
            this.btnCredito.Click += new System.EventHandler(this.btnCredito_Click);
            // 
            // btnMixto
            // 
            this.btnMixto.Location = new System.Drawing.Point(294, 112);
            this.btnMixto.Name = "btnMixto";
            this.btnMixto.Size = new System.Drawing.Size(120, 36);
            this.btnMixto.TabIndex = 3;
            this.btnMixto.Text = "Mixto";
            this.btnMixto.UseVisualStyleBackColor = true;
            this.btnMixto.Click += new System.EventHandler(this.btnMixto_Click);
            // 
            // btnTransferencia
            // 
            this.btnTransferencia.Location = new System.Drawing.Point(430, 112);
            this.btnTransferencia.Name = "btnTransferencia";
            this.btnTransferencia.Size = new System.Drawing.Size(120, 36);
            this.btnTransferencia.TabIndex = 4;
            this.btnTransferencia.Text = "Transferencia";
            this.btnTransferencia.UseVisualStyleBackColor = true;
            this.btnTransferencia.Click += new System.EventHandler(this.btnTransferencia_Click);
            // 
            // panelEfectivo
            // 
            this.panelEfectivo.Controls.Add(this.lblCambio);
            this.panelEfectivo.Controls.Add(this.lblCambioTitle);
            this.panelEfectivo.Controls.Add(this.txtPagoCon);
            this.panelEfectivo.Controls.Add(this.lblPagoCon);
            this.panelEfectivo.Location = new System.Drawing.Point(22, 168);
            this.panelEfectivo.Name = "panelEfectivo";
            this.panelEfectivo.Size = new System.Drawing.Size(528, 92);
            this.panelEfectivo.TabIndex = 5;
            // 
            // lblPagoCon
            // 
            this.lblPagoCon.AutoSize = true;
            this.lblPagoCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblPagoCon.Location = new System.Drawing.Point(10, 14);
            this.lblPagoCon.Name = "lblPagoCon";
            this.lblPagoCon.Size = new System.Drawing.Size(73, 17);
            this.lblPagoCon.TabIndex = 0;
            this.lblPagoCon.Text = "Pagó con:";
            // 
            // txtPagoCon
            // 
            this.txtPagoCon.Location = new System.Drawing.Point(110, 12);
            this.txtPagoCon.Name = "txtPagoCon";
            this.txtPagoCon.Size = new System.Drawing.Size(200, 20);
            this.txtPagoCon.TabIndex = 1;
            this.txtPagoCon.TextChanged += new System.EventHandler(this.txtPagoCon_TextChanged);
            // 
            // lblCambioTitle
            // 
            this.lblCambioTitle.AutoSize = true;
            this.lblCambioTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCambioTitle.Location = new System.Drawing.Point(10, 52);
            this.lblCambioTitle.Name = "lblCambioTitle";
            this.lblCambioTitle.Size = new System.Drawing.Size(80, 17);
            this.lblCambioTitle.TabIndex = 2;
            this.lblCambioTitle.Text = "Su cambio:";
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblCambio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(150)))));
            this.lblCambio.Location = new System.Drawing.Point(110, 50);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(49, 20);
            this.lblCambio.TabIndex = 3;
            this.lblCambio.Text = "$0.00";
            // 
            // panelTransferencia
            // 
            this.panelTransferencia.Controls.Add(this.chkImprimirVoucher);
            this.panelTransferencia.Controls.Add(this.txtTelefono);
            this.panelTransferencia.Controls.Add(this.lblTelefono);
            this.panelTransferencia.Controls.Add(this.txtReferencia);
            this.panelTransferencia.Controls.Add(this.lblReferencia);
            this.panelTransferencia.Location = new System.Drawing.Point(22, 168);
            this.panelTransferencia.Name = "panelTransferencia";
            this.panelTransferencia.Size = new System.Drawing.Size(528, 118);
            this.panelTransferencia.TabIndex = 6;
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(10, 10);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(59, 13);
            this.lblReferencia.TabIndex = 0;
            this.lblReferencia.Text = "Referencia";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(13, 28);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(500, 20);
            this.txtReferencia.TabIndex = 1;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(10, 56);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(101, 13);
            this.lblTelefono.TabIndex = 2;
            this.lblTelefono.Text = "Número de teléfono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(13, 74);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(240, 20);
            this.txtTelefono.TabIndex = 3;
            // 
            // chkImprimirVoucher
            // 
            this.chkImprimirVoucher.AutoSize = true;
            this.chkImprimirVoucher.Location = new System.Drawing.Point(13, 96);
            this.chkImprimirVoucher.Name = "chkImprimirVoucher";
            this.chkImprimirVoucher.Size = new System.Drawing.Size(148, 17);
            this.chkImprimirVoucher.TabIndex = 4;
            this.chkImprimirVoucher.Text = "Imprimir voucher en terminal";
            this.chkImprimirVoucher.UseVisualStyleBackColor = true;
            // 
            // panelCredito
            // 
            this.panelCredito.Controls.Add(this.lblCreditoSinCliente);
            this.panelCredito.Location = new System.Drawing.Point(22, 168);
            this.panelCredito.Name = "panelCredito";
            this.panelCredito.Size = new System.Drawing.Size(528, 52);
            this.panelCredito.TabIndex = 7;
            // 
            // lblCreditoSinCliente
            // 
            this.lblCreditoSinCliente.AutoSize = true;
            this.lblCreditoSinCliente.ForeColor = System.Drawing.Color.Gray;
            this.lblCreditoSinCliente.Location = new System.Drawing.Point(10, 18);
            this.lblCreditoSinCliente.Name = "lblCreditoSinCliente";
            this.lblCreditoSinCliente.Size = new System.Drawing.Size(53, 13);
            this.lblCreditoSinCliente.TabIndex = 0;
            this.lblCreditoSinCliente.Text = "(Sin cliente)";
            // 
            // panelMixto
            // 
            this.panelMixto.Controls.Add(this.lblMixtoRestante);
            this.panelMixto.Controls.Add(this.lblRestanteTitle);
            this.panelMixto.Controls.Add(this.txtMixtoTransferencia);
            this.panelMixto.Controls.Add(this.lblMixtoTransferencia);
            this.panelMixto.Controls.Add(this.txtMixtoCredito);
            this.panelMixto.Controls.Add(this.lblMixtoCredito);
            this.panelMixto.Controls.Add(this.txtMixtoEfectivo);
            this.panelMixto.Controls.Add(this.lblMixtoEfectivo);
            this.panelMixto.Location = new System.Drawing.Point(22, 168);
            this.panelMixto.Name = "panelMixto";
            this.panelMixto.Size = new System.Drawing.Size(528, 172);
            this.panelMixto.TabIndex = 8;
            // 
            // lblMixtoEfectivo
            // 
            this.lblMixtoEfectivo.AutoSize = true;
            this.lblMixtoEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblMixtoEfectivo.Location = new System.Drawing.Point(10, 16);
            this.lblMixtoEfectivo.Name = "lblMixtoEfectivo";
            this.lblMixtoEfectivo.Size = new System.Drawing.Size(63, 17);
            this.lblMixtoEfectivo.TabIndex = 0;
            this.lblMixtoEfectivo.Text = "Efectivo";
            // 
            // txtMixtoEfectivo
            // 
            this.txtMixtoEfectivo.Location = new System.Drawing.Point(130, 14);
            this.txtMixtoEfectivo.Name = "txtMixtoEfectivo";
            this.txtMixtoEfectivo.Size = new System.Drawing.Size(180, 20);
            this.txtMixtoEfectivo.TabIndex = 1;
            this.txtMixtoEfectivo.TextChanged += new System.EventHandler(this.txtMixto_TextChanged);
            // 
            // lblMixtoCredito
            // 
            this.lblMixtoCredito.AutoSize = true;
            this.lblMixtoCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblMixtoCredito.Location = new System.Drawing.Point(10, 52);
            this.lblMixtoCredito.Name = "lblMixtoCredito";
            this.lblMixtoCredito.Size = new System.Drawing.Size(57, 17);
            this.lblMixtoCredito.TabIndex = 2;
            this.lblMixtoCredito.Text = "Crédito";
            // 
            // txtMixtoCredito
            // 
            this.txtMixtoCredito.Location = new System.Drawing.Point(130, 50);
            this.txtMixtoCredito.Name = "txtMixtoCredito";
            this.txtMixtoCredito.Size = new System.Drawing.Size(180, 20);
            this.txtMixtoCredito.TabIndex = 3;
            this.txtMixtoCredito.TextChanged += new System.EventHandler(this.txtMixto_TextChanged);
            // 
            // lblMixtoTransferencia
            // 
            this.lblMixtoTransferencia.AutoSize = true;
            this.lblMixtoTransferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblMixtoTransferencia.Location = new System.Drawing.Point(10, 88);
            this.lblMixtoTransferencia.Name = "lblMixtoTransferencia";
            this.lblMixtoTransferencia.Size = new System.Drawing.Size(101, 17);
            this.lblMixtoTransferencia.TabIndex = 4;
            this.lblMixtoTransferencia.Text = "Transferencia";
            // 
            // txtMixtoTransferencia
            // 
            this.txtMixtoTransferencia.Location = new System.Drawing.Point(130, 86);
            this.txtMixtoTransferencia.Name = "txtMixtoTransferencia";
            this.txtMixtoTransferencia.Size = new System.Drawing.Size(180, 20);
            this.txtMixtoTransferencia.TabIndex = 5;
            this.txtMixtoTransferencia.TextChanged += new System.EventHandler(this.txtMixto_TextChanged);
            // 
            // lblRestanteTitle
            // 
            this.lblRestanteTitle.AutoSize = true;
            this.lblRestanteTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblRestanteTitle.Location = new System.Drawing.Point(10, 136);
            this.lblRestanteTitle.Name = "lblRestanteTitle";
            this.lblRestanteTitle.Size = new System.Drawing.Size(71, 17);
            this.lblRestanteTitle.TabIndex = 6;
            this.lblRestanteTitle.Text = "Restante";
            // 
            // lblMixtoRestante
            // 
            this.lblMixtoRestante.AutoSize = true;
            this.lblMixtoRestante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblMixtoRestante.ForeColor = System.Drawing.Color.Maroon;
            this.lblMixtoRestante.Location = new System.Drawing.Point(130, 132);
            this.lblMixtoRestante.Name = "lblMixtoRestante";
            this.lblMixtoRestante.Size = new System.Drawing.Size(55, 24);
            this.lblMixtoRestante.TabIndex = 7;
            this.lblMixtoRestante.Text = "$0.00";
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(22, 356);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(528, 84);
            this.txtNotas.TabIndex = 9;
            this.txtNotas.Visible = false;
            // 
            // FrmCobrarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 540);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCobrarVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Venta de Productos: Cobrar";
            this.Load += new System.EventHandler(this.FrmCobrarVenta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCobrarVenta_KeyDown);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelEfectivo.ResumeLayout(false);
            this.panelEfectivo.PerformLayout();
            this.panelTransferencia.ResumeLayout(false);
            this.panelTransferencia.PerformLayout();
            this.panelCredito.ResumeLayout(false);
            this.panelCredito.PerformLayout();
            this.panelMixto.ResumeLayout(false);
            this.panelMixto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button btnCobrarImprimir;
        private System.Windows.Forms.Button btnCobrarSinImprimir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNotas;
        private System.Windows.Forms.Label lblArticulosTitle;
        private System.Windows.Forms.Label lblTotalArticulos;
        private System.Windows.Forms.CheckBox chkImprimirDatosCliente;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnEfectivo;
        private System.Windows.Forms.Button btnCredito;
        private System.Windows.Forms.Button btnMixto;
        private System.Windows.Forms.Button btnTransferencia;
        private System.Windows.Forms.Panel panelEfectivo;
        private System.Windows.Forms.Label lblPagoCon;
        private System.Windows.Forms.TextBox txtPagoCon;
        private System.Windows.Forms.Label lblCambioTitle;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.Panel panelTransferencia;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.CheckBox chkImprimirVoucher;
        private System.Windows.Forms.Panel panelCredito;
        private System.Windows.Forms.Label lblCreditoSinCliente;
        private System.Windows.Forms.Panel panelMixto;
        private System.Windows.Forms.Label lblMixtoEfectivo;
        private System.Windows.Forms.TextBox txtMixtoEfectivo;
        private System.Windows.Forms.Label lblMixtoCredito;
        private System.Windows.Forms.TextBox txtMixtoCredito;
        private System.Windows.Forms.Label lblMixtoTransferencia;
        private System.Windows.Forms.TextBox txtMixtoTransferencia;
        private System.Windows.Forms.Label lblRestanteTitle;
        private System.Windows.Forms.Label lblMixtoRestante;
        private System.Windows.Forms.TextBox txtNotas;
    }
}
