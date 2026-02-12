namespace ProyectoEleventa
{
    partial class FormularioProductos
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelSection = new System.Windows.Forms.Label();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.labelPrecioCosto = new System.Windows.Forms.Label();
            this.textBoxPrecioCosto = new System.Windows.Forms.TextBox();
            this.labelGanancia = new System.Windows.Forms.Label();
            this.numericGanancia = new System.Windows.Forms.NumericUpDown();
            this.labelPrecioVenta = new System.Windows.Forms.Label();
            this.textBoxPrecioVenta = new System.Windows.Forms.TextBox();
            this.comboDepartamento = new System.Windows.Forms.ComboBox();
            this.labelDepartamento = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.toolPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminarTool = new System.Windows.Forms.Button();
            this.btnDepartamentos = new System.Windows.Forms.Button();
            this.btnVentasPeriodo = new System.Windows.Forms.Button();
            this.btnPromociones = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnCatalogo = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGanancia)).BeginInit();
            this.toolPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(8, 8);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(137, 24);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "PRODUCTOS";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.SandyBrown;
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1483, 36);
            this.panelHeader.TabIndex = 0;
            // 
            // labelSection
            // 
            this.labelSection.AutoSize = true;
            this.labelSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelSection.Location = new System.Drawing.Point(5, 75);
            this.labelSection.Name = "labelSection";
            this.labelSection.Size = new System.Drawing.Size(174, 20);
            this.labelSection.TabIndex = 1;
            this.labelSection.Text = "NUEVO PRODUCTO";
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Location = new System.Drawing.Point(12, 98);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(88, 13);
            this.labelCodigo.TabIndex = 2;
            this.labelCodigo.Text = "Código de Barras";
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Location = new System.Drawing.Point(106, 95);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(240, 20);
            this.textBoxCodigo.TabIndex = 3;
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Location = new System.Drawing.Point(37, 124);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(63, 13);
            this.labelDescripcion.TabIndex = 4;
            this.labelDescripcion.Text = "Descripción";
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(106, 121);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(486, 20);
            this.textBoxDescripcion.TabIndex = 5;
            // 
            // labelPrecioCosto
            // 
            this.labelPrecioCosto.AutoSize = true;
            this.labelPrecioCosto.Location = new System.Drawing.Point(33, 190);
            this.labelPrecioCosto.Name = "labelPrecioCosto";
            this.labelPrecioCosto.Size = new System.Drawing.Size(67, 13);
            this.labelPrecioCosto.TabIndex = 6;
            this.labelPrecioCosto.Text = "Precio Costo";
            // 
            // textBoxPrecioCosto
            // 
            this.textBoxPrecioCosto.Location = new System.Drawing.Point(106, 187);
            this.textBoxPrecioCosto.Name = "textBoxPrecioCosto";
            this.textBoxPrecioCosto.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrecioCosto.TabIndex = 7;
            // 
            // labelGanancia
            // 
            this.labelGanancia.AutoSize = true;
            this.labelGanancia.Location = new System.Drawing.Point(47, 219);
            this.labelGanancia.Name = "labelGanancia";
            this.labelGanancia.Size = new System.Drawing.Size(53, 13);
            this.labelGanancia.TabIndex = 8;
            this.labelGanancia.Text = "Ganancia";
            // 
            // numericGanancia
            // 
            this.numericGanancia.Location = new System.Drawing.Point(107, 217);
            this.numericGanancia.Name = "numericGanancia";
            this.numericGanancia.Size = new System.Drawing.Size(99, 20);
            this.numericGanancia.TabIndex = 9;
            this.numericGanancia.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // labelPrecioVenta
            // 
            this.labelPrecioVenta.AutoSize = true;
            this.labelPrecioVenta.Location = new System.Drawing.Point(32, 249);
            this.labelPrecioVenta.Name = "labelPrecioVenta";
            this.labelPrecioVenta.Size = new System.Drawing.Size(68, 13);
            this.labelPrecioVenta.TabIndex = 10;
            this.labelPrecioVenta.Text = "Precio Venta";
            // 
            // textBoxPrecioVenta
            // 
            this.textBoxPrecioVenta.Location = new System.Drawing.Point(107, 246);
            this.textBoxPrecioVenta.Name = "textBoxPrecioVenta";
            this.textBoxPrecioVenta.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrecioVenta.TabIndex = 11;
            // 
            // comboDepartamento
            // 
            this.comboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDepartamento.Location = new System.Drawing.Point(106, 311);
            this.comboDepartamento.Name = "comboDepartamento";
            this.comboDepartamento.Size = new System.Drawing.Size(240, 21);
            this.comboDepartamento.TabIndex = 13;
            // 
            // labelDepartamento
            // 
            this.labelDepartamento.AutoSize = true;
            this.labelDepartamento.Location = new System.Drawing.Point(26, 314);
            this.labelDepartamento.Name = "labelDepartamento";
            this.labelDepartamento.Size = new System.Drawing.Size(74, 13);
            this.labelDepartamento.TabIndex = 12;
            this.labelDepartamento.Text = "Departamento";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.Location = new System.Drawing.Point(12, 540);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 30);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar Producto";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(1310, 540);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 30);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 278);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Precio Mayoreo ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Se vende";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(107, 163);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 17);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "Por Unidad/Pza";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(215, 163);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(145, 17);
            this.checkBox2.TabIndex = 22;
            this.checkBox2.Text = "A granel (Usa Decimales)";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(370, 151);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(116, 17);
            this.checkBox3.TabIndex = 23;
            this.checkBox3.Text = "Como Paquete (kit)";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // toolPanel
            // 
            this.toolPanel.Controls.Add(this.btnNuevo);
            this.toolPanel.Controls.Add(this.btnModificar);
            this.toolPanel.Controls.Add(this.btnEliminarTool);
            this.toolPanel.Controls.Add(this.btnDepartamentos);
            this.toolPanel.Controls.Add(this.btnVentasPeriodo);
            this.toolPanel.Controls.Add(this.btnPromociones);
            this.toolPanel.Controls.Add(this.btnImportar);
            this.toolPanel.Controls.Add(this.btnCatalogo);
            this.toolPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolPanel.Location = new System.Drawing.Point(0, 36);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Padding = new System.Windows.Forms.Padding(6);
            this.toolPanel.Size = new System.Drawing.Size(1483, 36);
            this.toolPanel.TabIndex = 2;
            // 
            // btnNuevo
            // 
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNuevo.Location = new System.Drawing.Point(9, 9);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 24);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            // 
            // btnModificar
            // 
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnModificar.Location = new System.Drawing.Point(105, 9);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(0, 3, 6, 3);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 24);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Modificar";
            // 
            // btnEliminarTool
            // 
            this.btnEliminarTool.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEliminarTool.Location = new System.Drawing.Point(201, 9);
            this.btnEliminarTool.Margin = new System.Windows.Forms.Padding(0, 3, 6, 3);
            this.btnEliminarTool.Name = "btnEliminarTool";
            this.btnEliminarTool.Size = new System.Drawing.Size(90, 24);
            this.btnEliminarTool.TabIndex = 2;
            this.btnEliminarTool.Text = "Eliminar";
            // 
            // btnDepartamentos
            // 
            this.btnDepartamentos.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDepartamentos.Location = new System.Drawing.Point(297, 9);
            this.btnDepartamentos.Margin = new System.Windows.Forms.Padding(0, 3, 6, 3);
            this.btnDepartamentos.Name = "btnDepartamentos";
            this.btnDepartamentos.Size = new System.Drawing.Size(110, 24);
            this.btnDepartamentos.TabIndex = 3;
            this.btnDepartamentos.Text = "Departamentos";
            // 
            // btnVentasPeriodo
            // 
            this.btnVentasPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVentasPeriodo.Location = new System.Drawing.Point(413, 9);
            this.btnVentasPeriodo.Margin = new System.Windows.Forms.Padding(0, 3, 6, 3);
            this.btnVentasPeriodo.Name = "btnVentasPeriodo";
            this.btnVentasPeriodo.Size = new System.Drawing.Size(120, 24);
            this.btnVentasPeriodo.TabIndex = 4;
            this.btnVentasPeriodo.Text = "Ventas por Periodo";
            // 
            // btnPromociones
            // 
            this.btnPromociones.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPromociones.Location = new System.Drawing.Point(539, 9);
            this.btnPromociones.Margin = new System.Windows.Forms.Padding(0, 3, 6, 3);
            this.btnPromociones.Name = "btnPromociones";
            this.btnPromociones.Size = new System.Drawing.Size(100, 24);
            this.btnPromociones.TabIndex = 5;
            this.btnPromociones.Text = "Promociones";
            // 
            // btnImportar
            // 
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnImportar.Location = new System.Drawing.Point(645, 9);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(0, 3, 6, 3);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(90, 24);
            this.btnImportar.TabIndex = 6;
            this.btnImportar.Text = "Importar";
            // 
            // btnCatalogo
            // 
            this.btnCatalogo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCatalogo.Location = new System.Drawing.Point(741, 9);
            this.btnCatalogo.Margin = new System.Windows.Forms.Padding(0, 3, 6, 3);
            this.btnCatalogo.Name = "btnCatalogo";
            this.btnCatalogo.Size = new System.Drawing.Size(90, 24);
            this.btnCatalogo.TabIndex = 7;
            this.btnCatalogo.Text = "Catálogo";
            // 
            // FormularioProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 635);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.comboDepartamento);
            this.Controls.Add(this.labelDepartamento);
            this.Controls.Add(this.textBoxPrecioVenta);
            this.Controls.Add(this.labelPrecioVenta);
            this.Controls.Add(this.numericGanancia);
            this.Controls.Add(this.labelGanancia);
            this.Controls.Add(this.textBoxPrecioCosto);
            this.Controls.Add(this.labelPrecioCosto);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.labelDescripcion);
            this.Controls.Add(this.textBoxCodigo);
            this.Controls.Add(this.labelCodigo);
            this.Controls.Add(this.toolPanel);
            this.Controls.Add(this.labelSection);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormularioProductos";
            this.Text = "FormularioProductos";
            this.Load += new System.EventHandler(this.FormularioProductos_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGanancia)).EndInit();
            this.toolPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelSection;
        private System.Windows.Forms.FlowLayoutPanel toolPanel;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminarTool;
        private System.Windows.Forms.Button btnDepartamentos;
        private System.Windows.Forms.Button btnVentasPeriodo;
        private System.Windows.Forms.Button btnPromociones;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnCatalogo;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.Label labelPrecioCosto;
        private System.Windows.Forms.TextBox textBoxPrecioCosto;
        private System.Windows.Forms.Label labelGanancia;
        private System.Windows.Forms.NumericUpDown numericGanancia;
        private System.Windows.Forms.Label labelPrecioVenta;
        private System.Windows.Forms.TextBox textBoxPrecioVenta;
        private System.Windows.Forms.ComboBox comboDepartamento;
        private System.Windows.Forms.Label labelDepartamento;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}