namespace ProyectoEleventa
{
    partial class FrmReporteMovimientosInventario
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
            this.tableRoot = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.tableTop = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.flowFiltros = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDelDia = new System.Windows.Forms.Label();
            this.dtpDelDia = new System.Windows.Forms.DateTimePicker();
            this.lblBuscarPor = new System.Windows.Forms.Label();
            this.cmbBuscarPor = new System.Windows.Forms.ComboBox();
            this.lblMovimientos = new System.Windows.Forms.Label();
            this.cmbMovimientos = new System.Windows.Forms.ComboBox();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHabil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.flowBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.tableRoot.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.tableTop.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.flowFiltros.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.flowBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableRoot
            // 
            this.tableRoot.ColumnCount = 1;
            this.tableRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRoot.Controls.Add(this.panelTop, 0, 0);
            this.tableRoot.Controls.Add(this.panelGrid, 0, 1);
            this.tableRoot.Controls.Add(this.panelBottom, 0, 2);
            this.tableRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableRoot.Location = new System.Drawing.Point(0, 0);
            this.tableRoot.Name = "tableRoot";
            this.tableRoot.RowCount = 3;
            this.tableRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableRoot.Size = new System.Drawing.Size(1200, 720);
            this.tableRoot.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.tableTop);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.panelTop.Size = new System.Drawing.Size(1194, 58);
            this.panelTop.TabIndex = 0;
            // 
            // tableTop
            // 
            this.tableTop.ColumnCount = 1;
            this.tableTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTop.Controls.Add(this.lblTitulo, 0, 0);
            this.tableTop.Controls.Add(this.panelFiltros, 0, 1);
            this.tableTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableTop.Location = new System.Drawing.Point(10, 6);
            this.tableTop.Name = "tableTop";
            this.tableTop.RowCount = 2;
            this.tableTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTop.Size = new System.Drawing.Size(1174, 46);
            this.tableTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(3, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1168, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "HISTORIAL DE MOVIMIENTOS DE INVENTARIO";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFiltros
            // 
            this.panelFiltros.Controls.Add(this.flowFiltros);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFiltros.Location = new System.Drawing.Point(0, 24);
            this.panelFiltros.Margin = new System.Windows.Forms.Padding(0);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1174, 22);
            this.panelFiltros.TabIndex = 1;
            // 
            // flowFiltros
            // 
            this.flowFiltros.AutoSize = true;
            this.flowFiltros.Controls.Add(this.lblDelDia);
            this.flowFiltros.Controls.Add(this.dtpDelDia);
            this.flowFiltros.Controls.Add(this.lblBuscarPor);
            this.flowFiltros.Controls.Add(this.cmbBuscarPor);
            this.flowFiltros.Controls.Add(this.lblMovimientos);
            this.flowFiltros.Controls.Add(this.cmbMovimientos);
            this.flowFiltros.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowFiltros.Location = new System.Drawing.Point(0, 0);
            this.flowFiltros.Margin = new System.Windows.Forms.Padding(0);
            this.flowFiltros.Name = "flowFiltros";
            this.flowFiltros.Size = new System.Drawing.Size(700, 22);
            this.flowFiltros.TabIndex = 0;
            this.flowFiltros.WrapContents = false;
            // 
            // lblDelDia
            // 
            this.lblDelDia.AutoSize = true;
            this.lblDelDia.Location = new System.Drawing.Point(3, 3);
            this.lblDelDia.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblDelDia.Name = "lblDelDia";
            this.lblDelDia.Size = new System.Drawing.Size(34, 13);
            this.lblDelDia.TabIndex = 0;
            this.lblDelDia.Text = "Del día:";
            // 
            // dtpDelDia
            // 
            this.dtpDelDia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDelDia.Location = new System.Drawing.Point(43, 0);
            this.dtpDelDia.Margin = new System.Windows.Forms.Padding(3, 0, 12, 0);
            this.dtpDelDia.Name = "dtpDelDia";
            this.dtpDelDia.Size = new System.Drawing.Size(110, 20);
            this.dtpDelDia.TabIndex = 1;
            // 
            // lblBuscarPor
            // 
            this.lblBuscarPor.AutoSize = true;
            this.lblBuscarPor.Location = new System.Drawing.Point(168, 3);
            this.lblBuscarPor.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblBuscarPor.Name = "lblBuscarPor";
            this.lblBuscarPor.Size = new System.Drawing.Size(58, 13);
            this.lblBuscarPor.TabIndex = 2;
            this.lblBuscarPor.Text = "Buscar por:";
            // 
            // cmbBuscarPor
            // 
            this.cmbBuscarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuscarPor.FormattingEnabled = true;
            this.cmbBuscarPor.Items.AddRange(new object[] {
            "Cajero, Producto o Departamento",
            "Cajero",
            "Producto",
            "Departamento"});
            this.cmbBuscarPor.Location = new System.Drawing.Point(232, 0);
            this.cmbBuscarPor.Margin = new System.Windows.Forms.Padding(3, 0, 12, 0);
            this.cmbBuscarPor.Name = "cmbBuscarPor";
            this.cmbBuscarPor.Size = new System.Drawing.Size(220, 21);
            this.cmbBuscarPor.TabIndex = 3;
            // 
            // lblMovimientos
            // 
            this.lblMovimientos.AutoSize = true;
            this.lblMovimientos.Location = new System.Drawing.Point(467, 3);
            this.lblMovimientos.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblMovimientos.Name = "lblMovimientos";
            this.lblMovimientos.Size = new System.Drawing.Size(67, 13);
            this.lblMovimientos.TabIndex = 4;
            this.lblMovimientos.Text = "Movimientos";
            // 
            // cmbMovimientos
            // 
            this.cmbMovimientos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovimientos.FormattingEnabled = true;
            this.cmbMovimientos.Items.AddRange(new object[] {
            "- Todos -",
            "Entradas",
            "Salidas",
            "Ventas"});
            this.cmbMovimientos.Location = new System.Drawing.Point(540, 0);
            this.cmbMovimientos.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.cmbMovimientos.Name = "cmbMovimientos";
            this.cmbMovimientos.Size = new System.Drawing.Size(160, 21);
            this.cmbMovimientos.TabIndex = 5;
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.dgvMovimientos);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(3, 67);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panelGrid.Size = new System.Drawing.Size(1194, 610);
            this.panelGrid.TabIndex = 1;
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHora,
            this.colDescripcion,
            this.colMovimiento,
            this.colHabil,
            this.colTipo,
            this.colCantidad,
            this.colBy,
            this.colCajero,
            this.colDepartamento});
            this.dgvMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovimientos.Location = new System.Drawing.Point(10, 0);
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.Size = new System.Drawing.Size(1174, 610);
            this.dgvMovimientos.TabIndex = 0;
            // 
            // colHora
            // 
            this.colHora.HeaderText = "Hora";
            this.colHora.Name = "colHora";
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripción del Producto";
            this.colDescripcion.Name = "colDescripcion";
            // 
            // colMovimiento
            // 
            this.colMovimiento.HeaderText = "Movimiento";
            this.colMovimiento.Name = "colMovimiento";
            // 
            // colHabil
            // 
            this.colHabil.HeaderText = "";
            this.colHabil.Name = "colHabil";
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            // 
            // colBy
            // 
            this.colBy.HeaderText = "By";
            this.colBy.Name = "colBy";
            // 
            // colCajero
            // 
            this.colCajero.HeaderText = "Cajero";
            this.colCajero.Name = "colCajero";
            // 
            // colDepartamento
            // 
            this.colDepartamento.HeaderText = "Departamento";
            this.colDepartamento.Name = "colDepartamento";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.flowBottom);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(3, 683);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.panelBottom.Size = new System.Drawing.Size(1194, 34);
            this.panelBottom.TabIndex = 2;
            // 
            // flowBottom
            // 
            this.flowBottom.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowBottom.Location = new System.Drawing.Point(914, 6);
            this.flowBottom.Margin = new System.Windows.Forms.Padding(0);
            this.flowBottom.Name = "flowBottom";
            this.flowBottom.Size = new System.Drawing.Size(270, 22);
            this.flowBottom.TabIndex = 0;
            this.flowBottom.WrapContents = false;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(169, 0);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(101, 22);
            this.btnExportar.TabIndex = 0;
            this.btnExportar.Text = "Exportar movimientos";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(88, 0);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 22);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // FrmReporteMovimientosInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.tableRoot);
            this.Name = "FrmReporteMovimientosInventario";
            this.Text = "Reporte de movimientos";
            this.tableRoot.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.tableTop.ResumeLayout(false);
            this.tableTop.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.flowFiltros.ResumeLayout(false);
            this.flowFiltros.PerformLayout();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.flowBottom.ResumeLayout(false);
            this.ResumeLayout(false);

            this.flowBottom.Controls.Add(this.btnExportar);
            this.flowBottom.Controls.Add(this.btnImprimir);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableRoot;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TableLayoutPanel tableTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.FlowLayoutPanel flowFiltros;
        private System.Windows.Forms.Label lblDelDia;
        private System.Windows.Forms.DateTimePicker dtpDelDia;
        private System.Windows.Forms.Label lblBuscarPor;
        private System.Windows.Forms.ComboBox cmbBuscarPor;
        private System.Windows.Forms.Label lblMovimientos;
        private System.Windows.Forms.ComboBox cmbMovimientos;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHabil;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartamento;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.FlowLayoutPanel flowBottom;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnImprimir;
    }
}
