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
    public partial class FormularioVentas : Form
    {
        public FormularioVentas()
        {
            InitializeComponent();
        }

        private void FormularioVentas_Load(object sender, EventArgs e)
        {
            // Suscribir evento del botón Buscar
            this.button6.Click += new System.EventHandler(this.btnBuscar_Click);

            // Suscribir evento del botón INS Varios
            this.button7.Click += new System.EventHandler(this.btnINSVarios_Click);

            // Suscribir evento del botón Producto Común
            this.btnProductoComun.Click += new System.EventHandler(this.btnProductoComun_Click);

            // Suscribir evento del botón Entradas
            this.button5.Click += new System.EventHandler(this.btnEntradas_Click);

            // Suscribir evento del botón Salidas
            this.button10.Click += new System.EventHandler(this.btnSalidas_Click);

            // Suscribir evento del botón Verificador
            this.button12.Click += new System.EventHandler(this.btnVerificador_Click);

            // Habilitar la detección de teclas
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormularioVentas_KeyDown);
        }

        private void FormularioVentas_KeyDown(object sender, KeyEventArgs e)
        {
            // Detectar F10
            if (e.KeyCode == Keys.F10)
            {
                AbrirBusquedaProductos();
                e.Handled = true;
            }
            // Detectar Insert (INS)
            else if (e.KeyCode == Keys.Insert)
            {
                AbrirINSVarios();
                e.Handled = true;
            }
            // Detectar CTRL + P
            else if (e.KeyCode == Keys.P && e.Control)
            {
                AbrirProductoComun();
                e.Handled = true;
            }
            // Detectar F7
            else if (e.KeyCode == Keys.F7)
            {
                AbrirEntradasEfectivo();
                e.Handled = true;
            }
            // Detectar F8
            else if (e.KeyCode == Keys.F8)
            {
                AbrirSalidasEfectivo();
                e.Handled = true;
            }
            // Detectar F9
            else if (e.KeyCode == Keys.F9)
            {
                AbrirVerificador();
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AbrirBusquedaProductos();
        }

        private void btnINSVarios_Click(object sender, EventArgs e)
        {
            AbrirINSVarios();
        }

        private void btnProductoComun_Click(object sender, EventArgs e)
        {
            AbrirProductoComun();
        }

        private void btnEntradas_Click(object sender, EventArgs e)
        {
            AbrirEntradasEfectivo();
        }

        private void btnSalidas_Click(object sender, EventArgs e)
        {
            AbrirSalidasEfectivo();
        }

        private void btnVerificador_Click(object sender, EventArgs e)
        {
            AbrirVerificador();
        }

        private void AbrirBusquedaProductos()
        {
            BusquedaProductos formBusqueda = new BusquedaProductos();
            formBusqueda.ShowDialog();
        }

        private void AbrirINSVarios()
        {
            INSVarios formINSVarios = new INSVarios();
            formINSVarios.ShowDialog();
        }

        private void AbrirProductoComun()
        {
            ProductoComun formProductoComun = new ProductoComun();
            formProductoComun.ShowDialog();
        }

        private void AbrirEntradasEfectivo()
        {
            EntradasEfectivo formEntradasEfectivo = new EntradasEfectivo();
            formEntradasEfectivo.ShowDialog();
        }

        private void AbrirSalidasEfectivo()
        {
            SalidasEfectivo formSalidasEfectivo = new SalidasEfectivo();
            formSalidasEfectivo.ShowDialog();
        }

        private void AbrirVerificador()
        {
            Verificador formVerificador = new Verificador();
            formVerificador.ShowDialog();
        }
    }
}
