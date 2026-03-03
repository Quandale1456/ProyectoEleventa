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
            this.groupboxProducto = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExistenciaMinima = new System.Windows.Forms.TextBox();
            this.txtExistenciaMaxima = new System.Windows.Forms.TextBox();
            this.txtExistencia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxInventario = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGanancia)).BeginInit();
            this.groupboxProducto.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(12, 12);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(210, 33);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "PRODUCTOS";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.SandyBrown;
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1946, 55);
            this.panelHeader.TabIndex = 0;
            // 
            // labelSection
            // 
            this.labelSection.AutoSize = true;
            this.labelSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelSection.ForeColor = System.Drawing.Color.SandyBrown;
            this.labelSection.Location = new System.Drawing.Point(9, 25);
            this.labelSection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSection.Name = "labelSection";
            this.labelSection.Size = new System.Drawing.Size(256, 29);
            this.labelSection.TabIndex = 1;
            this.labelSection.Text = "NUEVO PRODUCTO";
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Location = new System.Drawing.Point(21, 80);
            this.labelCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(132, 20);
            this.labelCodigo.TabIndex = 2;
            this.labelCodigo.Text = "Código de Barras";
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Location = new System.Drawing.Point(162, 75);
            this.textBoxCodigo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(358, 26);
            this.textBoxCodigo.TabIndex = 3;
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Location = new System.Drawing.Point(52, 120);
            this.labelDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(92, 20);
            this.labelDescripcion.TabIndex = 4;
            this.labelDescripcion.Text = "Descripción";
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(162, 115);
            this.textBoxDescripcion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(727, 26);
            this.textBoxDescripcion.TabIndex = 5;
            // 
            // labelPrecioCosto
            // 
            this.labelPrecioCosto.AutoSize = true;
            this.labelPrecioCosto.Location = new System.Drawing.Point(52, 222);
            this.labelPrecioCosto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrecioCosto.Name = "labelPrecioCosto";
            this.labelPrecioCosto.Size = new System.Drawing.Size(99, 20);
            this.labelPrecioCosto.TabIndex = 6;
            this.labelPrecioCosto.Text = "Precio Costo";
            // 
            // textBoxPrecioCosto
            // 
            this.textBoxPrecioCosto.Location = new System.Drawing.Point(162, 217);
            this.textBoxPrecioCosto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPrecioCosto.Name = "textBoxPrecioCosto";
            this.textBoxPrecioCosto.Size = new System.Drawing.Size(148, 26);
            this.textBoxPrecioCosto.TabIndex = 7;
            // 
            // labelGanancia
            // 
            this.labelGanancia.AutoSize = true;
            this.labelGanancia.Location = new System.Drawing.Point(74, 266);
            this.labelGanancia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGanancia.Name = "labelGanancia";
            this.labelGanancia.Size = new System.Drawing.Size(78, 20);
            this.labelGanancia.TabIndex = 8;
            this.labelGanancia.Text = "Ganancia";
            // 
            // numericGanancia
            // 
            this.numericGanancia.Location = new System.Drawing.Point(164, 263);
            this.numericGanancia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericGanancia.Name = "numericGanancia";
            this.numericGanancia.Size = new System.Drawing.Size(148, 26);
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
            this.labelPrecioVenta.Location = new System.Drawing.Point(51, 312);
            this.labelPrecioVenta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrecioVenta.Name = "labelPrecioVenta";
            this.labelPrecioVenta.Size = new System.Drawing.Size(100, 20);
            this.labelPrecioVenta.TabIndex = 10;
            this.labelPrecioVenta.Text = "Precio Venta";
            // 
            // textBoxPrecioVenta
            // 
            this.textBoxPrecioVenta.Location = new System.Drawing.Point(164, 308);
            this.textBoxPrecioVenta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPrecioVenta.Name = "textBoxPrecioVenta";
            this.textBoxPrecioVenta.ReadOnly = true;
            this.textBoxPrecioVenta.Size = new System.Drawing.Size(148, 26);
            this.textBoxPrecioVenta.TabIndex = 11;
            // 
            // comboDepartamento
            // 
            this.comboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDepartamento.Location = new System.Drawing.Point(162, 408);
            this.comboDepartamento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboDepartamento.Name = "comboDepartamento";
            this.comboDepartamento.Size = new System.Drawing.Size(358, 28);
            this.comboDepartamento.TabIndex = 13;
            // 
            // labelDepartamento
            // 
            this.labelDepartamento.AutoSize = true;
            this.labelDepartamento.Location = new System.Drawing.Point(42, 412);
            this.labelDepartamento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDepartamento.Name = "labelDepartamento";
            this.labelDepartamento.Size = new System.Drawing.Size(112, 20);
            this.labelDepartamento.TabIndex = 12;
            this.labelDepartamento.Text = "Departamento";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.Location = new System.Drawing.Point(18, 801);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(225, 46);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar Producto";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(1982, 918);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(225, 46);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(164, 357);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 26);
            this.textBox1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 362);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Precio Mayoreo ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 180);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Se vende";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(164, 180);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(145, 24);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "Por Unidad/Pza";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(326, 180);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(215, 24);
            this.checkBox2.TabIndex = 22;
            this.checkBox2.Text = "A granel (Usa Decimales)";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(552, 180);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(171, 24);
            this.checkBox3.TabIndex = 23;
            this.checkBox3.Text = "Como Paquete (kit)";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // groupboxProducto
            // 
            this.groupboxProducto.Controls.Add(this.label7);
            this.groupboxProducto.Controls.Add(this.label6);
            this.groupboxProducto.Controls.Add(this.label5);
            this.groupboxProducto.Controls.Add(this.txtExistenciaMinima);
            this.groupboxProducto.Controls.Add(this.txtExistenciaMaxima);
            this.groupboxProducto.Controls.Add(this.txtExistencia);
            this.groupboxProducto.Controls.Add(this.label4);
            this.groupboxProducto.Controls.Add(this.checkBoxInventario);
            this.groupboxProducto.Controls.Add(this.label3);
            this.groupboxProducto.Controls.Add(this.labelSection);
            this.groupboxProducto.Controls.Add(this.checkBox3);
            this.groupboxProducto.Controls.Add(this.labelCodigo);
            this.groupboxProducto.Controls.Add(this.checkBox2);
            this.groupboxProducto.Controls.Add(this.textBoxCodigo);
            this.groupboxProducto.Controls.Add(this.checkBox1);
            this.groupboxProducto.Controls.Add(this.labelDescripcion);
            this.groupboxProducto.Controls.Add(this.label2);
            this.groupboxProducto.Controls.Add(this.textBoxDescripcion);
            this.groupboxProducto.Controls.Add(this.textBox1);
            this.groupboxProducto.Controls.Add(this.labelPrecioCosto);
            this.groupboxProducto.Controls.Add(this.label1);
            this.groupboxProducto.Controls.Add(this.textBoxPrecioCosto);
            this.groupboxProducto.Controls.Add(this.labelGanancia);
            this.groupboxProducto.Controls.Add(this.numericGanancia);
            this.groupboxProducto.Controls.Add(this.comboDepartamento);
            this.groupboxProducto.Controls.Add(this.labelPrecioVenta);
            this.groupboxProducto.Controls.Add(this.labelDepartamento);
            this.groupboxProducto.Controls.Add(this.textBoxPrecioVenta);
            this.groupboxProducto.Location = new System.Drawing.Point(18, 20);
            this.groupboxProducto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupboxProducto.Name = "groupboxProducto";
            this.groupboxProducto.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupboxProducto.Size = new System.Drawing.Size(2176, 698);
            this.groupboxProducto.TabIndex = 24;
            this.groupboxProducto.TabStop = false;
            this.groupboxProducto.Text = "Producto";
            this.groupboxProducto.Enter += new System.EventHandler(this.groupboxProducto_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(120, 645);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 20);
            this.label7.TabIndex = 32;
            this.label7.Text = "Maximo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(348, 565);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "en este momento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 605);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Minimo";
            // 
            // txtExistenciaMinima
            // 
            this.txtExistenciaMinima.Location = new System.Drawing.Point(189, 600);
            this.txtExistenciaMinima.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExistenciaMinima.Name = "txtExistenciaMinima";
            this.txtExistenciaMinima.Size = new System.Drawing.Size(148, 26);
            this.txtExistenciaMinima.TabIndex = 29;
            // 
            // txtExistenciaMaxima
            // 
            this.txtExistenciaMaxima.Location = new System.Drawing.Point(189, 640);
            this.txtExistenciaMaxima.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExistenciaMaxima.Name = "txtExistenciaMaxima";
            this.txtExistenciaMaxima.Size = new System.Drawing.Size(148, 26);
            this.txtExistenciaMaxima.TabIndex = 28;
            // 
            // txtExistencia
            // 
            this.txtExistencia.Location = new System.Drawing.Point(189, 560);
            this.txtExistencia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExistencia.Name = "txtExistencia";
            this.txtExistencia.Size = new System.Drawing.Size(148, 26);
            this.txtExistencia.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 565);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Hay";
            // 
            // checkBoxInventario
            // 
            this.checkBoxInventario.AutoSize = true;
            this.checkBoxInventario.Location = new System.Drawing.Point(189, 529);
            this.checkBoxInventario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxInventario.Name = "checkBoxInventario";
            this.checkBoxInventario.Size = new System.Drawing.Size(272, 24);
            this.checkBoxInventario.TabIndex = 25;
            this.checkBoxInventario.Text = "Este Producto SI utiliza inventario";
            this.checkBoxInventario.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(183, 480);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 24;
            this.label3.Text = "Inventario";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2224, 66);
            this.panel1.TabIndex = 25;
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button8.Location = new System.Drawing.Point(1281, 9);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(171, 46);
            this.button8.TabIndex = 33;
            this.button8.Text = "Catalogo";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button7.Location = new System.Drawing.Point(1104, 9);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(168, 46);
            this.button7.TabIndex = 32;
            this.button7.Text = "Importar";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(903, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 46);
            this.button1.TabIndex = 26;
            this.button1.Text = "Promociones";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(710, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 46);
            this.button2.TabIndex = 27;
            this.button2.Text = "Ventas por Periodo";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(512, 9);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(189, 46);
            this.button3.TabIndex = 28;
            this.button3.Text = "Departamentos";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(344, 9);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(159, 46);
            this.button4.TabIndex = 29;
            this.button4.Text = "Eliminar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Location = new System.Drawing.Point(182, 9);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(153, 46);
            this.button5.TabIndex = 30;
            this.button5.Text = "Modificar";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.Location = new System.Drawing.Point(18, 9);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(153, 46);
            this.button6.TabIndex = 31;
            this.button6.Text = "Nuevo";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.groupboxProducto);
            this.panelContenido.Controls.Add(this.btnGuardar);
            this.panelContenido.Controls.Add(this.btnCancelar);
            this.panelContenido.Location = new System.Drawing.Point(0, 131);
            this.panelContenido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(2224, 985);
            this.panelContenido.TabIndex = 33;
            // 
            // FormularioProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1946, 1106);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormularioProductos";
            this.Text = "FormularioProductos";
            this.Load += new System.EventHandler(this.FormularioProductos_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGanancia)).EndInit();
            this.groupboxProducto.ResumeLayout(false);
            this.groupboxProducto.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelContenido.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelSection;
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
        private System.Windows.Forms.GroupBox groupboxProducto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtExistenciaMinima;
        private System.Windows.Forms.TextBox txtExistenciaMaxima;
        private System.Windows.Forms.TextBox txtExistencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxInventario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelContenido;
    }
}