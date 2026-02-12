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
    public partial class Form1 : Form
    {
        private Form activeForm = null;
        public Form1()
        {
            InitializeComponent();
            // Iniciar el formulario en pantalla completa
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            // Suscribir evento del botón Ventas
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // Suscribir evento del botón Productos
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // Abrir FormularioVentas al iniciar
            OpenChildForm(new FormularioVentas());
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
            this.panelContenedor.Controls.Add(childForm);
            this.panelContenedor.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormularioVentas());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormularioProductos());
        }
    }
}
