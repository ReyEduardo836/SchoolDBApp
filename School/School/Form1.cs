using School.AppCore.IServices;
using School.Domain.Entities;
using School.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School
{
    public partial class Form1 : Form
    {
        private IEstudianteService estudianteService;
        public Form1(IEstudianteService estudianteService)
        {
            this.estudianteService = estudianteService;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (StringHelper.Wspaces(getAllCampos()))
            {
                throw new Exception("No pueden haber campos vacios");
            }
            string valErrorString = StringHelper.ValidateEstudiantes(getAllCampos());
            if (valErrorString.Length != 0)
            {
                throw new Exception(valErrorString);
            }
            List<Estudiante> est = estudianteService.FindByCarnet(txtCarnet.Text);
            Estudiante estudiante = getNewEstudiante();
            if (est.Count != 0)
            {
                estudianteService.Update(estudiante);
                LoadDataGridView();
                LimpiarCampos();
                return;
            }
            else
            {
                estudianteService.Create(estudiante);
                LoadDataGridView();
                LimpiarCampos();
            }
        }

        private void LoadDataGridView()
        {
            dgvEstudiantes.DataSource = estudianteService.GetAll();
        }

        private void dgvEstudiantes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) return;
            if (e.RowIndex < 0) return;
            contextMenuStrip1.Show(Cursor.Position);
            dgvEstudiantes.CurrentCell = dgvEstudiantes.Rows[e.RowIndex].Cells[0];
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            estudianteService.Delete(estudianteService.FindById(getId()));
            LoadDataGridView();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Estudiante estudiante = estudianteService.FindById(getId());

            txtNombre.Text = estudiante.Nombres;
            txtApellido.Text = estudiante.Apellidos;
            txtCarnet.Text = estudiante.Carnet;
            txtTelefono.Text = estudiante.Phone;
            txtDireccion.Text = estudiante.Direccion;
            txtCorreo.Text = estudiante.Correo;
            txtMatematica.Text = estudiante.Matematica.ToString();
            txtContabilidad.Text = estudiante.Contabilidad.ToString();
            txtProgramacion.Text = estudiante.Programacion.ToString();
            txtEstadistica.Text = estudiante.Estadistica.ToString();
        }

        private int getId()
        {
            return (int)dgvEstudiantes.CurrentRow.Cells[0].Value;
        }

        private Estudiante getNewEstudiante()
        {
            Estudiante estudiante = new Estudiante()
            {
                Nombres = txtNombre.Text,
                Apellidos = txtApellido.Text,
                Carnet = txtCarnet.Text,
                Phone = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                Correo = txtCorreo.Text,
                Matematica = int.Parse(txtMatematica.Text),
                Contabilidad = int.Parse(txtContabilidad.Text),
                Programacion = int.Parse(txtProgramacion.Text),
                Estadistica = int.Parse(txtEstadistica.Text)
            };
            return estudiante;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCarnet.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtMatematica.Text = "";
            txtContabilidad.Text = "";
            txtProgramacion.Text = "";
            txtEstadistica.Text = "";
        }

        private string[] getAllCampos()
        {
            string[] campos = { txtNombre.Text, txtApellido.Text, txtCarnet.Text, txtTelefono.Text, txtDireccion.Text, txtCorreo.Text, txtMatematica.Text, txtContabilidad.Text, txtProgramacion.Text, txtEstadistica.Text };
            return campos;
        }

        private void mostrarPromedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Estudiante est = estudianteService.FindById(getId());
            float promedio = (float)(est.Contabilidad + est.Programacion + est.Estadistica + est.Matematica) / 4;
            MessageBox.Show($"El Promedio del estudiante {est.Nombres} es de {promedio}");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            string text = txtBuscar.Text;
            int n;
            if (Int32.TryParse(text, out n))
            {
                Estudiante estudianteID = estudianteService.FindById(n);
                if(estudianteID != null)
                {
                    estudiantes.Add(estudianteID);
                }
            }
            Estudiante estudiante = estudianteService.FindByCarnet(text).FirstOrDefault();
            if(estudiante != null)
            {
                estudiantes.Add(estudiante);
            }
            if (text.Length == 0)
            {
                LoadDataGridView();
                return;
            }
            dgvEstudiantes.DataSource = estudiantes;
        }
    }
}