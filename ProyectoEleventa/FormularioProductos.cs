using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEleventa
{
    public partial class FormularioProductos : Form
    {
        private Form activeForm = null;

        public FormularioProductos()
        {
            InitializeComponent();
        }

        private void FormularioProductos_Load(object sender, EventArgs e)
        {
            // Suscribir eventos de los botones
            this.button6.Click += new System.EventHandler(this.btnNuevo_Click);
            this.button5.Click += new System.EventHandler(this.btnModificar_Click);
            this.button4.Click += new System.EventHandler(this.btnEliminar_Click);
            this.button3.Click += new System.EventHandler(this.btnDepartamentos_Click);
            this.button2.Click += new System.EventHandler(this.btnVentasPorPeriodo_Click);
            this.button1.Click += new System.EventHandler(this.btnPromociones_Click);
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelContenido.Controls.Add(childForm);
            this.panelContenido.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ModificarProducto());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EliminarProducto());
        }

        private void btnDepartamentos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Departamentos());
        }

        private void btnVentasPorPeriodo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new VentasPorPeriodo());
        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Promociones());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }
        }
    }
}
