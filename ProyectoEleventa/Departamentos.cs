using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoEleventa.Data;

namespace ProyectoEleventa
{
    public partial class Departamentos : Form
    {
        private Dictionary<string, int> departamentosDict = new Dictionary<string, int>();

        public Departamentos()
        {
            InitializeComponent();
        }

        private void Departamentos_Load(object sender, EventArgs e)
        {
            // Suscribir eventos
            this.btnGuardarDepartamento.Click += new System.EventHandler(this.btnGuardarDepartamento_Click);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnNuevoDepartamento.Click += new System.EventHandler(this.btnNuevoDepartamento_Click);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.txtBuscarDepartamento.TextChanged += new System.EventHandler(this.txtBuscarDepartamento_TextChanged);
            this.dataGridViewDepartamentos.DoubleClick += new System.EventHandler(this.dataGridViewDepartamentos_DoubleClick);
            this.dataGridViewDepartamentos.SelectedIndexChanged += new System.EventHandler(this.dataGridViewDepartamentos_SelectedIndexChanged);

            // Cargar departamentos
            CargarDepartamentos();
        }

        /// <summary>
        /// Carga la lista de departamentos en el ListBox
        /// </summary>
        private void CargarDepartamentos()
        {
            try
            {
                this.dataGridViewDepartamentos.Items.Clear();
                departamentosDict.Clear();

                // Agregar "Sin Departamento" como primer elemento
                this.dataGridViewDepartamentos.Items.Add("- Sin Departamento -");
                departamentosDict["- Sin Departamento -"] = 0;

                // Obtener departamentos de BD
                DataTable dt = DepartamentoDAL.ObtenerTodos();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int id = (int)row["id_departamento"];
                        string nombre = row["nombre"].ToString();

                        this.dataGridViewDepartamentos.Items.Add(nombre);
                        departamentosDict[nombre] = id;
                    }

                    this.lblDepartamentos.Text = $"Departamentos ({dt.Rows.Count + 1})";
                }
                else
                {
                    this.lblDepartamentos.Text = "Departamentos (1)";
                }

                // Seleccionar el primer elemento
                if (this.dataGridViewDepartamentos.Items.Count > 0)
                {
                    this.dataGridViewDepartamentos.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar departamentos: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Busca departamentos mientras se digita
        /// </summary>
        private void txtBuscarDepartamento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textoBusqueda = this.txtBuscarDepartamento.Text.Trim().ToLower();

                this.dataGridViewDepartamentos.Items.Clear();

                if (string.IsNullOrWhiteSpace(textoBusqueda))
                {
                    // Si está vacío, mostrar todos
                    CargarDepartamentos();
                }
                else
                {
                    // Filtrar departamentos
                    int contador = 0;

                    // Agregar "Sin Departamento" si coincide con la búsqueda
                    if ("sin departamento".Contains(textoBusqueda))
                    {
                        this.dataGridViewDepartamentos.Items.Add("- Sin Departamento -");
                        contador++;
                    }

                    // Buscar departamentos que coincidan
                    DataTable dt = DepartamentoDAL.BuscarPorNombre(textoBusqueda);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            string nombre = row["nombre"].ToString();
                            this.dataGridViewDepartamentos.Items.Add(nombre);
                            contador++;
                        }
                    }

                    if (contador > 0)
                    {
                        this.lblDepartamentos.Text = $"Resultados ({contador})";
                        this.dataGridViewDepartamentos.SelectedIndex = 0;
                    }
                    else
                    {
                        this.lblDepartamentos.Text = "- Sin Resultados -";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en búsqueda: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Guarda un nuevo departamento
        /// </summary>
        private void btnGuardarDepartamento_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = this.txtNombreDepartamento.Text.Trim();

                // Validación
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("Por favor ingrese el nombre del departamento.", 
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNombreDepartamento.Focus();
                    return;
                }

                if (nombre.Length < 3)
                {
                    MessageBox.Show("El nombre debe tener al menos 3 caracteres.", 
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNombreDepartamento.Focus();
                    return;
                }

                // Guardar departamento
                if (DepartamentoDAL.CrearDepartamento(nombre))
                {
                    MessageBox.Show("Departamento guardado correctamente.", 
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar y recargar
                    this.txtNombreDepartamento.Clear();
                    this.txtBuscarDepartamento.Clear();
                    CargarDepartamentos();
                    this.txtNombreDepartamento.Focus();
                }
                else
                {
                    MessageBox.Show("El departamento ya existe o hubo un error al guardar.", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Limpia los campos
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.txtNombreDepartamento.Clear();
            this.txtNombreDepartamento.Focus();
        }

        /// <summary>
        /// Prepara el formulario para agregar nuevo departamento
        /// </summary>
        private void btnNuevoDepartamento_Click(object sender, EventArgs e)
        {
            this.txtNombreDepartamento.Clear();
            this.txtBuscarDepartamento.Clear();
            CargarDepartamentos();
            this.txtNombreDepartamento.Focus();
        }

        /// <summary>
        /// Evento cuando se hace doble click en un departamento
        /// </summary>
        private void dataGridViewDepartamentos_DoubleClick(object sender, EventArgs e)
        {
            if (this.dataGridViewDepartamentos.SelectedIndex > 0)
            {
                string nombreSeleccionado = this.dataGridViewDepartamentos.SelectedItem.ToString();
                this.txtNombreDepartamento.Text = nombreSeleccionado;
                this.txtNombreDepartamento.Focus();
            }
        }

        /// <summary>
        /// Elimina el departamento seleccionado
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que hay un departamento seleccionado (no "Sin Departamento")
                if (this.dataGridViewDepartamentos.SelectedIndex <= 0)
                {
                    MessageBox.Show("Por favor seleccione un departamento para eliminar.", 
                        "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombreDepartamento = this.dataGridViewDepartamentos.SelectedItem.ToString();
                int idDepartamento = departamentosDict[nombreDepartamento];

                // Confirmar eliminación
                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el departamento '{nombreDepartamento}'?", 
                    "Confirmar Eliminación", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    if (DepartamentoDAL.EliminarDepartamento(idDepartamento))
                    {
                        MessageBox.Show("Departamento eliminado correctamente.", 
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recargar lista
                        CargarDepartamentos();
                        this.txtNombreDepartamento.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el departamento.", 
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento cuando se selecciona un departamento en el ListBox
        /// Muestra el nombre del departamento seleccionado en el label
        /// </summary>
        private void dataGridViewDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridViewDepartamentos.SelectedIndex >= 0)
                {
                    string departamentoSeleccionado = this.dataGridViewDepartamentos.SelectedItem.ToString();
                    this.lblDepartamentos.Text = departamentoSeleccionado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
