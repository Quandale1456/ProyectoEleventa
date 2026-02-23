namespace ProyectoEleventa
{
    partial class FormularioDeInventario
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReporteDeMovimientos = new System.Windows.Forms.Button();
            this.btnReporteDeInv = new System.Windows.Forms.Button();
            this.btnProductoBajos = new System.Windows.Forms.Button();
            this.btnAjustes = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.panelProducto = new System.Windows.Forms.Panel();
            this.btnAgregarCantidad = new System.Windows.Forms.Button();
            this.txtPorcentajeDeGanancia = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.txtPrecioCosto = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtAgregar = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelProducto.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnReporteDeMovimientos);
            this.panel1.Controls.Add(this.btnReporteDeInv);
            this.panel1.Controls.Add(this.btnProductoBajos);
            this.panel1.Controls.Add(this.btnAjustes);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1483, 43);
            this.panel1.TabIndex = 27;
            // 
            // btnReporteDeMovimientos
            // 
            this.btnReporteDeMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReporteDeMovimientos.Location = new System.Drawing.Point(536, 6);
            this.btnReporteDeMovimientos.Name = "btnReporteDeMovimientos";
            this.btnReporteDeMovimientos.Size = new System.Drawing.Size(143, 30);
            this.btnReporteDeMovimientos.TabIndex = 26;
            this.btnReporteDeMovimientos.Text = "Reporte De Movimientos";
            this.btnReporteDeMovimientos.UseVisualStyleBackColor = true;
            // 
            // btnReporteDeInv
            // 
            this.btnReporteDeInv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReporteDeInv.Location = new System.Drawing.Point(404, 6);
            this.btnReporteDeInv.Name = "btnReporteDeInv";
            this.btnReporteDeInv.Size = new System.Drawing.Size(126, 30);
            this.btnReporteDeInv.TabIndex = 28;
            this.btnReporteDeInv.Text = "Reporte de Inventario";
            this.btnReporteDeInv.UseVisualStyleBackColor = true;
            this.btnReporteDeInv.Click += new System.EventHandler(this.btnReporteDeInv_Click);
            // 
            // btnProductoBajos
            // 
            this.btnProductoBajos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProductoBajos.Location = new System.Drawing.Point(229, 6);
            this.btnProductoBajos.Name = "btnProductoBajos";
            this.btnProductoBajos.Size = new System.Drawing.Size(169, 30);
            this.btnProductoBajos.TabIndex = 29;
            this.btnProductoBajos.Text = "Productos Bajos en Inventario";
            this.btnProductoBajos.UseVisualStyleBackColor = true;
            this.btnProductoBajos.Click += new System.EventHandler(this.btnProductoBajos_Click);
            // 
            // btnAjustes
            // 
            this.btnAjustes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAjustes.Location = new System.Drawing.Point(121, 6);
            this.btnAjustes.Name = "btnAjustes";
            this.btnAjustes.Size = new System.Drawing.Size(102, 30);
            this.btnAjustes.TabIndex = 30;
            this.btnAjustes.Text = "Ajustes";
            this.btnAjustes.UseVisualStyleBackColor = true;
            this.btnAjustes.Click += new System.EventHandler(this.btnAjustes_Click_1);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregar.Location = new System.Drawing.Point(12, 6);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(102, 30);
            this.btnAgregar.TabIndex = 31;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1483, 36);
            this.panelHeader.TabIndex = 26;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(8, 8);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(135, 24);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "INVENTARIO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "AGREGAR INVENTARIO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "Codigo del Producto";
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Location = new System.Drawing.Point(141, 49);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.Size = new System.Drawing.Size(174, 20);
            this.txtCodigoProducto.TabIndex = 30;
            // 
            // panelProducto
            // 
            this.panelProducto.Controls.Add(this.btnAgregarCantidad);
            this.panelProducto.Controls.Add(this.txtPorcentajeDeGanancia);
            this.panelProducto.Controls.Add(this.txtPrecioVenta);
            this.panelProducto.Controls.Add(this.txtPrecioCosto);
            this.panelProducto.Controls.Add(this.txtStock);
            this.panelProducto.Controls.Add(this.txtAgregar);
            this.panelProducto.Controls.Add(this.txtDescripcion);
            this.panelProducto.Controls.Add(this.label8);
            this.panelProducto.Controls.Add(this.label7);
            this.panelProducto.Controls.Add(this.label6);
            this.panelProducto.Controls.Add(this.label5);
            this.panelProducto.Controls.Add(this.label4);
            this.panelProducto.Controls.Add(this.label2);
            this.panelProducto.Location = new System.Drawing.Point(7, 75);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new System.Drawing.Size(382, 351);
            this.panelProducto.TabIndex = 31;
            // 
            // btnAgregarCantidad
            // 
            this.btnAgregarCantidad.Location = new System.Drawing.Point(134, 185);
            this.btnAgregarCantidad.Name = "btnAgregarCantidad";
            this.btnAgregarCantidad.Size = new System.Drawing.Size(174, 35);
            this.btnAgregarCantidad.TabIndex = 38;
            this.btnAgregarCantidad.Text = "Agregar Cantidad a Inventario";
            this.btnAgregarCantidad.UseVisualStyleBackColor = true;
            // 
            // txtPorcentajeDeGanancia
            // 
            this.txtPorcentajeDeGanancia.Location = new System.Drawing.Point(134, 158);
            this.txtPorcentajeDeGanancia.Name = "txtPorcentajeDeGanancia";
            this.txtPorcentajeDeGanancia.Size = new System.Drawing.Size(174, 20);
            this.txtPorcentajeDeGanancia.TabIndex = 37;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(134, 124);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(174, 20);
            this.txtPrecioVenta.TabIndex = 32;
            // 
            // txtPrecioCosto
            // 
            this.txtPrecioCosto.Location = new System.Drawing.Point(134, 91);
            this.txtPrecioCosto.Name = "txtPrecioCosto";
            this.txtPrecioCosto.Size = new System.Drawing.Size(174, 20);
            this.txtPrecioCosto.TabIndex = 34;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(134, 36);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(174, 20);
            this.txtStock.TabIndex = 35;
            // 
            // txtAgregar
            // 
            this.txtAgregar.Location = new System.Drawing.Point(134, 65);
            this.txtAgregar.Name = "txtAgregar";
            this.txtAgregar.Size = new System.Drawing.Size(174, 20);
            this.txtAgregar.TabIndex = 33;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(134, 7);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(174, 20);
            this.txtDescripcion.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(95, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "Hay";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Precio Mayoreo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(70, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Agregar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(47, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Precio Costo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Precio Venta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descripcion";
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.label1);
            this.panelContenido.Controls.Add(this.panelProducto);
            this.panelContenido.Controls.Add(this.label3);
            this.panelContenido.Controls.Add(this.txtCodigoProducto);
            this.panelContenido.Location = new System.Drawing.Point(0, 77);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(1483, 646);
            this.panelContenido.TabIndex = 32;
            // 
            // FormularioDeInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 724);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormularioDeInventario";
            this.Text = "FormularioDeInventario";
            this.Load += new System.EventHandler(this.FormularioDeInventario_Load);
            this.panel1.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReporteDeMovimientos;
        private System.Windows.Forms.Button btnReporteDeInv;
        private System.Windows.Forms.Button btnProductoBajos;
        private System.Windows.Forms.Button btnAjustes;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigoProducto;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.Button btnAgregarCantidad;
        private System.Windows.Forms.TextBox txtPorcentajeDeGanancia;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.TextBox txtPrecioCosto;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtAgregar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelContenido;
    }
}