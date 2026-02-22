namespace ProyectoEleventa
{
    partial class Departamentos
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
            this.labelSection = new System.Windows.Forms.Label();
            this.txtBuscarDepartamento = new System.Windows.Forms.TextBox();
            this.btnNuevoDepartamento = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dataGridViewDepartamentos = new System.Windows.Forms.ListBox();
            this.lblDepartamentos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreDepartamento = new System.Windows.Forms.TextBox();
            this.btnGuardarDepartamento = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSection
            // 
            this.labelSection.AutoSize = true;
            this.labelSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelSection.ForeColor = System.Drawing.Color.SandyBrown;
            this.labelSection.Location = new System.Drawing.Point(12, 23);
            this.labelSection.Name = "labelSection";
            this.labelSection.Size = new System.Drawing.Size(165, 20);
            this.labelSection.TabIndex = 2;
            this.labelSection.Text = "DEPARTAMENTOS";
            // 
            // txtBuscarDepartamento
            // 
            this.txtBuscarDepartamento.Location = new System.Drawing.Point(16, 46);
            this.txtBuscarDepartamento.Name = "txtBuscarDepartamento";
            this.txtBuscarDepartamento.Size = new System.Drawing.Size(281, 20);
            this.txtBuscarDepartamento.TabIndex = 3;
            // 
            // btnNuevoDepartamento
            // 
            this.btnNuevoDepartamento.Location = new System.Drawing.Point(307, 43);
            this.btnNuevoDepartamento.Name = "btnNuevoDepartamento";
            this.btnNuevoDepartamento.Size = new System.Drawing.Size(133, 25);
            this.btnNuevoDepartamento.TabIndex = 4;
            this.btnNuevoDepartamento.Text = "Nuevo Departamento";
            this.btnNuevoDepartamento.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(446, 43);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(113, 25);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDepartamentos
            // 
            this.dataGridViewDepartamentos.FormattingEnabled = true;
            this.dataGridViewDepartamentos.Location = new System.Drawing.Point(16, 73);
            this.dataGridViewDepartamentos.Name = "dataGridViewDepartamentos";
            this.dataGridViewDepartamentos.Size = new System.Drawing.Size(281, 671);
            this.dataGridViewDepartamentos.TabIndex = 6;
            // 
            // lblDepartamentos
            // 
            this.lblDepartamentos.AutoSize = true;
            this.lblDepartamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblDepartamentos.ForeColor = System.Drawing.Color.SandyBrown;
            this.lblDepartamentos.Location = new System.Drawing.Point(303, 73);
            this.lblDepartamentos.Name = "lblDepartamentos";
            this.lblDepartamentos.Size = new System.Drawing.Size(177, 20);
            this.lblDepartamentos.TabIndex = 7;
            this.lblDepartamentos.Text = "- Sin Departamento -";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(320, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre";
            // 
            // txtNombreDepartamento
            // 
            this.txtNombreDepartamento.Location = new System.Drawing.Point(323, 116);
            this.txtNombreDepartamento.Name = "txtNombreDepartamento";
            this.txtNombreDepartamento.Size = new System.Drawing.Size(269, 20);
            this.txtNombreDepartamento.TabIndex = 9;
            // 
            // btnGuardarDepartamento
            // 
            this.btnGuardarDepartamento.Location = new System.Drawing.Point(323, 142);
            this.btnGuardarDepartamento.Name = "btnGuardarDepartamento";
            this.btnGuardarDepartamento.Size = new System.Drawing.Size(133, 25);
            this.btnGuardarDepartamento.TabIndex = 10;
            this.btnGuardarDepartamento.Text = "Guardar Departamento";
            this.btnGuardarDepartamento.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(462, 142);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(113, 25);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // Departamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 756);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardarDepartamento);
            this.Controls.Add(this.txtNombreDepartamento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDepartamentos);
            this.Controls.Add(this.dataGridViewDepartamentos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevoDepartamento);
            this.Controls.Add(this.txtBuscarDepartamento);
            this.Controls.Add(this.labelSection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Departamentos";
            this.Text = "Departamentos";
            this.Load += new System.EventHandler(this.Departamentos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSection;
        private System.Windows.Forms.TextBox txtBuscarDepartamento;
        private System.Windows.Forms.Button btnNuevoDepartamento;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ListBox dataGridViewDepartamentos;
        private System.Windows.Forms.Label lblDepartamentos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreDepartamento;
        private System.Windows.Forms.Button btnGuardarDepartamento;
        private System.Windows.Forms.Button btnCancelar;
    }
}