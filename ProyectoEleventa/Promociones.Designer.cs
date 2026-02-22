namespace ProyectoEleventa
{
    partial class Promociones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NombrePromocion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioPromocion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevaPromocion = new System.Windows.Forms.Button();
            this.txtNombrePromocion = new System.Windows.Forms.TextBox();
            this.labelSection = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantidadVaya = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CantidadHasta = new System.Windows.Forms.TextBox();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPrecioCosto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPrecioNormal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombrePromocion,
            this.CodigoProducto,
            this.Desde,
            this.Hasta,
            this.PrecioPromocion});
            this.dataGridView1.Location = new System.Drawing.Point(16, 264);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1149, 425);
            this.dataGridView1.TabIndex = 16;
            // 
            // NombrePromocion
            // 
            this.NombrePromocion.HeaderText = "Nombre de la Promocion";
            this.NombrePromocion.Name = "NombrePromocion";
            this.NombrePromocion.Width = 200;
            // 
            // CodigoProducto
            // 
            this.CodigoProducto.HeaderText = "Codigo Producto";
            this.CodigoProducto.Name = "CodigoProducto";
            this.CodigoProducto.Width = 150;
            // 
            // Desde
            // 
            this.Desde.HeaderText = "Desde";
            this.Desde.Name = "Desde";
            // 
            // Hasta
            // 
            this.Hasta.HeaderText = "Hasta";
            this.Hasta.Name = "Hasta";
            // 
            // PrecioPromocion
            // 
            this.PrecioPromocion.HeaderText = "Precio Promocion";
            this.PrecioPromocion.Name = "PrecioPromocion";
            this.PrecioPromocion.Width = 150;
            // 
            // btnNuevaPromocion
            // 
            this.btnNuevaPromocion.Location = new System.Drawing.Point(174, 188);
            this.btnNuevaPromocion.Name = "btnNuevaPromocion";
            this.btnNuevaPromocion.Size = new System.Drawing.Size(229, 30);
            this.btnNuevaPromocion.TabIndex = 14;
            this.btnNuevaPromocion.Text = "Guardar Nueva Promocion";
            this.btnNuevaPromocion.UseVisualStyleBackColor = true;
            // 
            // txtNombrePromocion
            // 
            this.txtNombrePromocion.Location = new System.Drawing.Point(160, 32);
            this.txtNombrePromocion.Name = "txtNombrePromocion";
            this.txtNombrePromocion.Size = new System.Drawing.Size(281, 20);
            this.txtNombrePromocion.TabIndex = 13;
            // 
            // labelSection
            // 
            this.labelSection.AutoSize = true;
            this.labelSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelSection.ForeColor = System.Drawing.Color.SandyBrown;
            this.labelSection.Location = new System.Drawing.Point(12, 9);
            this.labelSection.Name = "labelSection";
            this.labelSection.Size = new System.Drawing.Size(182, 20);
            this.labelSection.TabIndex = 12;
            this.labelSection.Text = "NUEVA PROMOCION";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Nombre de la Promocion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Cuando la cantidad vaya desde";
            // 
            // txtCantidadVaya
            // 
            this.txtCantidadVaya.Location = new System.Drawing.Point(176, 113);
            this.txtCantidadVaya.Name = "txtCantidadVaya";
            this.txtCantidadVaya.Size = new System.Drawing.Size(90, 20);
            this.txtCantidadVaya.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Codigo de barras";
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Location = new System.Drawing.Point(160, 68);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(182, 20);
            this.txtCodigoBarras.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Hasta";
            // 
            // CantidadHasta
            // 
            this.CantidadHasta.Location = new System.Drawing.Point(313, 113);
            this.CantidadHasta.Name = "CantidadHasta";
            this.CantidadHasta.Size = new System.Drawing.Size(90, 20);
            this.CantidadHasta.TabIndex = 28;
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.Location = new System.Drawing.Point(176, 149);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(90, 20);
            this.txtPrecioUnitario.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Usar precio unitario";
            // 
            // lblPrecioCosto
            // 
            this.lblPrecioCosto.AutoSize = true;
            this.lblPrecioCosto.Location = new System.Drawing.Point(396, 172);
            this.lblPrecioCosto.Name = "lblPrecioCosto";
            this.lblPrecioCosto.Size = new System.Drawing.Size(34, 13);
            this.lblPrecioCosto.TabIndex = 31;
            this.lblPrecioCosto.Text = "$0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Precio Normal:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(297, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Precio Costo:";
            // 
            // lblPrecioNormal
            // 
            this.lblPrecioNormal.AutoSize = true;
            this.lblPrecioNormal.Location = new System.Drawing.Point(396, 149);
            this.lblPrecioNormal.Name = "lblPrecioNormal";
            this.lblPrecioNormal.Size = new System.Drawing.Size(34, 13);
            this.lblPrecioNormal.TabIndex = 34;
            this.lblPrecioNormal.Text = "$0.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.SandyBrown;
            this.label10.Location = new System.Drawing.Point(12, 241);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(235, 20);
            this.label10.TabIndex = 35;
            this.label10.Text = "PROMOCIONES VIGENTES";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(1039, 228);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(126, 30);
            this.btnEliminar.TabIndex = 36;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // Promociones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 701);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblPrecioNormal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPrecioCosto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPrecioUnitario);
            this.Controls.Add(this.CantidadHasta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodigoBarras);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCantidadVaya);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnNuevaPromocion);
            this.Controls.Add(this.txtNombrePromocion);
            this.Controls.Add(this.labelSection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Promociones";
            this.Text = "Promociones";
            this.Load += new System.EventHandler(this.Promociones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnNuevaPromocion;
        private System.Windows.Forms.TextBox txtNombrePromocion;
        private System.Windows.Forms.Label labelSection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCantidadVaya;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CantidadHasta;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPrecioCosto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPrecioNormal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombrePromocion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desde;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioPromocion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnEliminar;
    }
}