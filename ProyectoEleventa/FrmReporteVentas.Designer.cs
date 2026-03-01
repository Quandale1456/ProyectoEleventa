namespace ProyectoEleventa
{
    partial class FrmReporteVentas
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.linkSemanaActual = new System.Windows.Forms.LinkLabel();
            this.linkMesActual = new System.Windows.Forms.LinkLabel();
            this.linkMesAnterior = new System.Windows.Forms.LinkLabel();
            this.linkAnoActual = new System.Windows.Forms.LinkLabel();
            this.linkPeriodo = new System.Windows.Forms.LinkLabel();
            this.pnlPeriodo = new System.Windows.Forms.Panel();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.grpTiempo = new System.Windows.Forms.GroupBox();
            this.lblTotalTiempo = new System.Windows.Forms.Label();
            this.lblTituloTiempo = new System.Windows.Forms.Label();
            this.lstTiempo = new System.Windows.Forms.ListView();
            this.colTiempoNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTiempoTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpPago = new System.Windows.Forms.GroupBox();
            this.lblSinPago = new System.Windows.Forms.Label();
            this.chartPago = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lstPago = new System.Windows.Forms.ListView();
            this.colPagoNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPagoTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpImpuestos = new System.Windows.Forms.GroupBox();
            this.lblImpuestosValor = new System.Windows.Forms.Label();
            this.grpDept = new System.Windows.Forms.GroupBox();
            this.lblSinDept = new System.Windows.Forms.Label();
            this.chartDept = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lstDept = new System.Windows.Forms.ListView();
            this.colDeptNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDeptTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpGanancia = new System.Windows.Forms.GroupBox();
            this.lblSinGanancia = new System.Windows.Forms.Label();
            this.chartGanancia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lstGanancia = new System.Windows.Forms.ListView();
            this.colGanNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGanTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlPeriodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.grpTiempo.SuspendLayout();
            this.grpPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPago)).BeginInit();
            this.grpImpuestos.SuspendLayout();
            this.grpDept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDept)).BeginInit();
            this.grpGanancia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGanancia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.lblHeader.Location = new System.Drawing.Point(12, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(245, 15);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "RESUMEN DE VENTAS";
            // 
            // linkSemanaActual
            // 
            this.linkSemanaActual.AutoSize = true;
            this.linkSemanaActual.Location = new System.Drawing.Point(12, 34);
            this.linkSemanaActual.Name = "linkSemanaActual";
            this.linkSemanaActual.Size = new System.Drawing.Size(75, 13);
            this.linkSemanaActual.TabIndex = 1;
            this.linkSemanaActual.TabStop = true;
            this.linkSemanaActual.Text = "Semana Actual";
            // 
            // linkMesActual
            // 
            this.linkMesActual.AutoSize = true;
            this.linkMesActual.Location = new System.Drawing.Point(105, 34);
            this.linkMesActual.Name = "linkMesActual";
            this.linkMesActual.Size = new System.Drawing.Size(57, 13);
            this.linkMesActual.TabIndex = 2;
            this.linkMesActual.TabStop = true;
            this.linkMesActual.Text = "Mes Actual";
            // 
            // linkMesAnterior
            // 
            this.linkMesAnterior.AutoSize = true;
            this.linkMesAnterior.Location = new System.Drawing.Point(180, 34);
            this.linkMesAnterior.Name = "linkMesAnterior";
            this.linkMesAnterior.Size = new System.Drawing.Size(63, 13);
            this.linkMesAnterior.TabIndex = 3;
            this.linkMesAnterior.TabStop = true;
            this.linkMesAnterior.Text = "Mes Anterior";
            // 
            // linkAnoActual
            // 
            this.linkAnoActual.AutoSize = true;
            this.linkAnoActual.Location = new System.Drawing.Point(261, 34);
            this.linkAnoActual.Name = "linkAnoActual";
            this.linkAnoActual.Size = new System.Drawing.Size(53, 13);
            this.linkAnoActual.TabIndex = 4;
            this.linkAnoActual.TabStop = true;
            this.linkAnoActual.Text = "Año actual";
            // 
            // linkPeriodo
            // 
            this.linkPeriodo.AutoSize = true;
            this.linkPeriodo.Location = new System.Drawing.Point(332, 34);
            this.linkPeriodo.Name = "linkPeriodo";
            this.linkPeriodo.Size = new System.Drawing.Size(46, 13);
            this.linkPeriodo.TabIndex = 5;
            this.linkPeriodo.TabStop = true;
            this.linkPeriodo.Text = "Periodo...";
            // 
            // pnlPeriodo
            // 
            this.pnlPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPeriodo.Controls.Add(this.lblHasta);
            this.pnlPeriodo.Controls.Add(this.lblDesde);
            this.pnlPeriodo.Controls.Add(this.dtpHasta);
            this.pnlPeriodo.Controls.Add(this.dtpDesde);
            this.pnlPeriodo.Enabled = false;
            this.pnlPeriodo.Location = new System.Drawing.Point(700, 24);
            this.pnlPeriodo.Name = "pnlPeriodo";
            this.pnlPeriodo.Size = new System.Drawing.Size(480, 32);
            this.pnlPeriodo.TabIndex = 6;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(250, 9);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(45, 13);
            this.lblHasta.TabIndex = 3;
            this.lblHasta.Text = "Hasta el";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(5, 9);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(45, 13);
            this.lblDesde.TabIndex = 2;
            this.lblDesde.Text = "Desde el";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(300, 6);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(170, 20);
            this.dtpHasta.TabIndex = 1;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(55, 6);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(170, 20);
            this.dtpDesde.TabIndex = 0;
            // 
            // splitMain
            // 
            this.splitMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitMain.Location = new System.Drawing.Point(12, 65);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.grpImpuestos);
            this.splitMain.Panel1.Controls.Add(this.grpPago);
            this.splitMain.Panel1.Controls.Add(this.grpTiempo);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.grpGanancia);
            this.splitMain.Panel2.Controls.Add(this.grpDept);
            this.splitMain.Size = new System.Drawing.Size(1168, 597);
            this.splitMain.SplitterDistance = 560;
            this.splitMain.TabIndex = 7;
            // 
            // grpTiempo
            // 
            this.grpTiempo.Controls.Add(this.lblTotalTiempo);
            this.grpTiempo.Controls.Add(this.lblTituloTiempo);
            this.grpTiempo.Controls.Add(this.lstTiempo);
            this.grpTiempo.Location = new System.Drawing.Point(0, 0);
            this.grpTiempo.Name = "grpTiempo";
            this.grpTiempo.Size = new System.Drawing.Size(560, 180);
            this.grpTiempo.TabIndex = 0;
            this.grpTiempo.TabStop = false;
            // 
            // lblTotalTiempo
            // 
            this.lblTotalTiempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalTiempo.Location = new System.Drawing.Point(410, 20);
            this.lblTotalTiempo.Name = "lblTotalTiempo";
            this.lblTotalTiempo.Size = new System.Drawing.Size(140, 20);
            this.lblTotalTiempo.TabIndex = 2;
            this.lblTotalTiempo.Text = "$0.00";
            this.lblTotalTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTituloTiempo
            // 
            this.lblTituloTiempo.AutoSize = true;
            this.lblTituloTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTituloTiempo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.lblTituloTiempo.Location = new System.Drawing.Point(10, 20);
            this.lblTituloTiempo.Name = "lblTituloTiempo";
            this.lblTituloTiempo.Size = new System.Drawing.Size(104, 20);
            this.lblTituloTiempo.TabIndex = 1;
            this.lblTituloTiempo.Text = "Ventas por día";
            // 
            // lstTiempo
            // 
            this.lstTiempo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTiempoNombre,
            this.colTiempoTotal});
            this.lstTiempo.FullRowSelect = true;
            this.lstTiempo.GridLines = true;
            this.lstTiempo.HideSelection = false;
            this.lstTiempo.Location = new System.Drawing.Point(10, 50);
            this.lstTiempo.Name = "lstTiempo";
            this.lstTiempo.Size = new System.Drawing.Size(540, 120);
            this.lstTiempo.TabIndex = 0;
            this.lstTiempo.UseCompatibleStateImageBehavior = false;
            this.lstTiempo.View = System.Windows.Forms.View.Details;
            // 
            // colTiempoNombre
            // 
            this.colTiempoNombre.Text = "";
            this.colTiempoNombre.Width = 350;
            // 
            // colTiempoTotal
            // 
            this.colTiempoTotal.Text = "";
            this.colTiempoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTiempoTotal.Width = 150;
            // 
            // grpPago
            // 
            this.grpPago.Controls.Add(this.lblSinPago);
            this.grpPago.Controls.Add(this.chartPago);
            this.grpPago.Controls.Add(this.lstPago);
            this.grpPago.Location = new System.Drawing.Point(0, 186);
            this.grpPago.Name = "grpPago";
            this.grpPago.Size = new System.Drawing.Size(560, 280);
            this.grpPago.TabIndex = 1;
            this.grpPago.TabStop = false;
            // 
            // lblSinPago
            // 
            this.lblSinPago.AutoSize = true;
            this.lblSinPago.Location = new System.Drawing.Point(10, 20);
            this.lblSinPago.Name = "lblSinPago";
            this.lblSinPago.Size = new System.Drawing.Size(128, 13);
            this.lblSinPago.TabIndex = 2;
            this.lblSinPago.Text = "- No se registró ninguna venta -";
            this.lblSinPago.Visible = false;
            // 
            // chartPago
            // 
            this.chartPago.Location = new System.Drawing.Point(10, 40);
            this.chartPago.Name = "chartPago";
            this.chartPago.Size = new System.Drawing.Size(340, 230);
            this.chartPago.TabIndex = 1;
            // 
            // lstPago
            // 
            this.lstPago.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPagoNombre,
            this.colPagoTotal});
            this.lstPago.FullRowSelect = true;
            this.lstPago.GridLines = true;
            this.lstPago.HideSelection = false;
            this.lstPago.Location = new System.Drawing.Point(360, 40);
            this.lstPago.Name = "lstPago";
            this.lstPago.Size = new System.Drawing.Size(190, 230);
            this.lstPago.TabIndex = 0;
            this.lstPago.UseCompatibleStateImageBehavior = false;
            this.lstPago.View = System.Windows.Forms.View.Details;
            // 
            // colPagoNombre
            // 
            this.colPagoNombre.Text = "";
            this.colPagoNombre.Width = 90;
            // 
            // colPagoTotal
            // 
            this.colPagoTotal.Text = "";
            this.colPagoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colPagoTotal.Width = 90;
            // 
            // grpImpuestos
            // 
            this.grpImpuestos.Controls.Add(this.lblImpuestosValor);
            this.grpImpuestos.Location = new System.Drawing.Point(0, 472);
            this.grpImpuestos.Name = "grpImpuestos";
            this.grpImpuestos.Size = new System.Drawing.Size(560, 120);
            this.grpImpuestos.TabIndex = 2;
            this.grpImpuestos.TabStop = false;
            this.grpImpuestos.Text = "Impuestos";
            // 
            // lblImpuestosValor
            // 
            this.lblImpuestosValor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImpuestosValor.Location = new System.Drawing.Point(10, 30);
            this.lblImpuestosValor.Name = "lblImpuestosValor";
            this.lblImpuestosValor.Size = new System.Drawing.Size(540, 70);
            this.lblImpuestosValor.TabIndex = 0;
            this.lblImpuestosValor.Text = "- No se registró ninguna venta -";
            this.lblImpuestosValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpDept
            // 
            this.grpDept.Controls.Add(this.lblSinDept);
            this.grpDept.Controls.Add(this.chartDept);
            this.grpDept.Controls.Add(this.lstDept);
            this.grpDept.Location = new System.Drawing.Point(0, 0);
            this.grpDept.Name = "grpDept";
            this.grpDept.Size = new System.Drawing.Size(604, 290);
            this.grpDept.TabIndex = 0;
            this.grpDept.TabStop = false;
            // 
            // lblSinDept
            // 
            this.lblSinDept.AutoSize = true;
            this.lblSinDept.Location = new System.Drawing.Point(10, 20);
            this.lblSinDept.Name = "lblSinDept";
            this.lblSinDept.Size = new System.Drawing.Size(128, 13);
            this.lblSinDept.TabIndex = 2;
            this.lblSinDept.Text = "- No se registró ninguna venta -";
            this.lblSinDept.Visible = false;
            // 
            // chartDept
            // 
            this.chartDept.Location = new System.Drawing.Point(10, 40);
            this.chartDept.Name = "chartDept";
            this.chartDept.Size = new System.Drawing.Size(320, 240);
            this.chartDept.TabIndex = 1;
            // 
            // lstDept
            // 
            this.lstDept.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDeptNombre,
            this.colDeptTotal});
            this.lstDept.FullRowSelect = true;
            this.lstDept.GridLines = true;
            this.lstDept.HideSelection = false;
            this.lstDept.Location = new System.Drawing.Point(340, 40);
            this.lstDept.Name = "lstDept";
            this.lstDept.Size = new System.Drawing.Size(250, 240);
            this.lstDept.TabIndex = 0;
            this.lstDept.UseCompatibleStateImageBehavior = false;
            this.lstDept.View = System.Windows.Forms.View.Details;
            // 
            // colDeptNombre
            // 
            this.colDeptNombre.Text = "";
            this.colDeptNombre.Width = 150;
            // 
            // colDeptTotal
            // 
            this.colDeptTotal.Text = "";
            this.colDeptTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDeptTotal.Width = 90;
            // 
            // grpGanancia
            // 
            this.grpGanancia.Controls.Add(this.lblSinGanancia);
            this.grpGanancia.Controls.Add(this.chartGanancia);
            this.grpGanancia.Controls.Add(this.lstGanancia);
            this.grpGanancia.Location = new System.Drawing.Point(0, 300);
            this.grpGanancia.Name = "grpGanancia";
            this.grpGanancia.Size = new System.Drawing.Size(604, 292);
            this.grpGanancia.TabIndex = 1;
            this.grpGanancia.TabStop = false;
            // 
            // lblSinGanancia
            // 
            this.lblSinGanancia.AutoSize = true;
            this.lblSinGanancia.Location = new System.Drawing.Point(10, 20);
            this.lblSinGanancia.Name = "lblSinGanancia";
            this.lblSinGanancia.Size = new System.Drawing.Size(128, 13);
            this.lblSinGanancia.TabIndex = 2;
            this.lblSinGanancia.Text = "- No se registró ninguna venta -";
            this.lblSinGanancia.Visible = false;
            // 
            // chartGanancia
            // 
            this.chartGanancia.Location = new System.Drawing.Point(10, 40);
            this.chartGanancia.Name = "chartGanancia";
            this.chartGanancia.Size = new System.Drawing.Size(320, 240);
            this.chartGanancia.TabIndex = 1;
            // 
            // lstGanancia
            // 
            this.lstGanancia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGanNombre,
            this.colGanTotal});
            this.lstGanancia.FullRowSelect = true;
            this.lstGanancia.GridLines = true;
            this.lstGanancia.HideSelection = false;
            this.lstGanancia.Location = new System.Drawing.Point(340, 40);
            this.lstGanancia.Name = "lstGanancia";
            this.lstGanancia.Size = new System.Drawing.Size(250, 240);
            this.lstGanancia.TabIndex = 0;
            this.lstGanancia.UseCompatibleStateImageBehavior = false;
            this.lstGanancia.View = System.Windows.Forms.View.Details;
            // 
            // colGanNombre
            // 
            this.colGanNombre.Text = "";
            this.colGanNombre.Width = 150;
            // 
            // colGanTotal
            // 
            this.colGanTotal.Text = "";
            this.colGanTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colGanTotal.Width = 90;
            // 
            // FrmReporteVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 674);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlPeriodo);
            this.Controls.Add(this.linkPeriodo);
            this.Controls.Add(this.linkAnoActual);
            this.Controls.Add(this.linkMesAnterior);
            this.Controls.Add(this.linkMesActual);
            this.Controls.Add(this.linkSemanaActual);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmReporteVentas";
            this.Text = "FrmReporteVentas";
            this.pnlPeriodo.ResumeLayout(false);
            this.pnlPeriodo.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.grpTiempo.ResumeLayout(false);
            this.grpTiempo.PerformLayout();
            this.grpPago.ResumeLayout(false);
            this.grpPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPago)).EndInit();
            this.grpImpuestos.ResumeLayout(false);
            this.grpDept.ResumeLayout(false);
            this.grpDept.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDept)).EndInit();
            this.grpGanancia.ResumeLayout(false);
            this.grpGanancia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGanancia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.LinkLabel linkSemanaActual;
        private System.Windows.Forms.LinkLabel linkMesActual;
        private System.Windows.Forms.LinkLabel linkMesAnterior;
        private System.Windows.Forms.LinkLabel linkAnoActual;
        private System.Windows.Forms.LinkLabel linkPeriodo;
        private System.Windows.Forms.Panel pnlPeriodo;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.GroupBox grpTiempo;
        private System.Windows.Forms.ListView lstTiempo;
        private System.Windows.Forms.ColumnHeader colTiempoNombre;
        private System.Windows.Forms.ColumnHeader colTiempoTotal;
        private System.Windows.Forms.Label lblTituloTiempo;
        private System.Windows.Forms.Label lblTotalTiempo;
        private System.Windows.Forms.GroupBox grpPago;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPago;
        private System.Windows.Forms.ListView lstPago;
        private System.Windows.Forms.ColumnHeader colPagoNombre;
        private System.Windows.Forms.ColumnHeader colPagoTotal;
        private System.Windows.Forms.Label lblSinPago;
        private System.Windows.Forms.GroupBox grpImpuestos;
        private System.Windows.Forms.Label lblImpuestosValor;
        private System.Windows.Forms.GroupBox grpDept;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDept;
        private System.Windows.Forms.ListView lstDept;
        private System.Windows.Forms.ColumnHeader colDeptNombre;
        private System.Windows.Forms.ColumnHeader colDeptTotal;
        private System.Windows.Forms.Label lblSinDept;
        private System.Windows.Forms.GroupBox grpGanancia;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGanancia;
        private System.Windows.Forms.ListView lstGanancia;
        private System.Windows.Forms.ColumnHeader colGanNombre;
        private System.Windows.Forms.ColumnHeader colGanTotal;
        private System.Windows.Forms.Label lblSinGanancia;
    }
}
