namespace ProyectoEleventa
{
    partial class FrmVentasPorCliente
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
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.lblSinDatos = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))));
            this.panelTop.Controls.Add(this.btnExportar);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1192, 40);
            this.panelTop.TabIndex = 0;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Location = new System.Drawing.Point(1100, 8);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(80, 23);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(196, 15);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "REPORTE DE VENTAS POR CLIENTE";
            // 
            // dgv
            // 
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 40);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(1192, 634);
            this.dgv.TabIndex = 1;
            // 
            // lblSinDatos
            // 
            this.lblSinDatos.BackColor = System.Drawing.Color.White;
            this.lblSinDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSinDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSinDatos.Location = new System.Drawing.Point(0, 40);
            this.lblSinDatos.Name = "lblSinDatos";
            this.lblSinDatos.Size = new System.Drawing.Size(1192, 634);
            this.lblSinDatos.TabIndex = 2;
            this.lblSinDatos.Text = "- No se registró ninguna venta -";
            this.lblSinDatos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSinDatos.Visible = false;
            // 
            // FrmVentasPorCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1192, 674);
            this.Controls.Add(this.lblSinDatos);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVentasPorCliente";
            this.Text = "FrmVentasPorCliente";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblSinDatos;
    }
}
