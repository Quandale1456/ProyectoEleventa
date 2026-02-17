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
            this.btnNuevoDepartamento = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelSection = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.NombrePromocion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioPromocion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
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
            // btnNuevoDepartamento
            // 
            this.btnNuevoDepartamento.Location = new System.Drawing.Point(174, 188);
            this.btnNuevoDepartamento.Name = "btnNuevoDepartamento";
            this.btnNuevoDepartamento.Size = new System.Drawing.Size(229, 30);
            this.btnNuevoDepartamento.TabIndex = 14;
            this.btnNuevoDepartamento.Text = "Guardar Nueva Promocion";
            this.btnNuevoDepartamento.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(160, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 20);
            this.textBox1.TabIndex = 13;
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
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(176, 113);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(90, 20);
            this.textBox3.TabIndex = 23;
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
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(160, 68);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(182, 20);
            this.textBox4.TabIndex = 25;
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
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(313, 113);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(90, 20);
            this.textBox5.TabIndex = 28;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(176, 149);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(90, 20);
            this.textBox6.TabIndex = 29;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "$0.00";
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(396, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "$0.00";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1039, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 30);
            this.button1.TabIndex = 36;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Promociones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 701);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnNuevoDepartamento);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelSection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Promociones";
            this.Text = "Promociones";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnNuevoDepartamento;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelSection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombrePromocion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desde;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioPromocion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
    }
}