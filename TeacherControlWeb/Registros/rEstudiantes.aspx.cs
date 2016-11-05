using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb
{
    public partial class rEstudiantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            NombresTextBox.Text = string.Empty;
            MatriculaTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            FNacTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FmRadioButton.Checked = false;
            McRadioButton.Checked = false;
            CursosDropDownList.SelectedIndex = 0;
            GruposDropDownList.SelectedIndex = 0;
            Imagen.ImageUrl = "/img/images.png";
            MatriculaTextBox.Focus();
           
        }
        private void LLenarDatos(Estudiantes estudiante)
        {
            estudiante.EstudianteId = Utility.ConvierteEntero(IdTextBox.Text);
            estudiante.Matricula = Utility.ConvierteEntero(MatriculaTextBox.Text);
            estudiante.Nombre = NombresTextBox.Text;
            estudiante.Celular = TelefonoTextBox.Text;
            estudiante.Email = EmailTextBox.Text;
            estudiante.Direccion = DireccionTextBox.Text;
            estudiante.Genero = McRadioButton.Checked;
            estudiante.FechaNacimiento = FNacTextBox.Text;
            estudiante.Fecha = DateTime.Now.ToString("dd/MM/yyyy");
            estudiante.Curso = Utility.ConvierteEntero(CursosDropDownList.SelectedValue);
            estudiante.Grupo = GruposDropDownList.Text;
            estudiante.Foto = Imagen.ImageUrl;
        }
        private void DevolverDatos(Estudiantes estudiante)
        {
            IdTextBox.Text = estudiante.EstudianteId.ToString();
            NombresTextBox.Text = estudiante.Nombre;
            MatriculaTextBox.Text = estudiante.Matricula.ToString();
            TelefonoTextBox.Text = estudiante.Celular;
            EmailTextBox.Text = estudiante.Email;
            DireccionTextBox.Text = estudiante.Direccion;
            FNacTextBox.Text = estudiante.FechaNacimiento;
            CursosDropDownList.SelectedValue = estudiante.Curso.ToString();
            GruposDropDownList.Text = estudiante.Grupo;
            Imagen.ImageUrl = estudiante.Foto;
            if (estudiante.Genero == true)
            {
                McRadioButton.Checked = true;
            }
            else
                FmRadioButton.Checked = true;
        }
        private bool Validar()
        {
            if (!string.IsNullOrWhiteSpace(MatriculaTextBox.Text) && !string.IsNullOrWhiteSpace(NombresTextBox.Text) && !string.IsNullOrWhiteSpace(TelefonoTextBox.Text) && !string.IsNullOrWhiteSpace(EmailTextBox.Text) && !string.IsNullOrWhiteSpace(DireccionTextBox.Text) && !string.IsNullOrWhiteSpace(FNacTextBox.Text) && (McRadioButton.Checked || FmRadioButton.Checked))
            {
                return true;
            } else
                return false;
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Estudiantes estudiante = new Estudiantes();
            try
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (Validar())
                    {
                        if (estudiante.Insertar())
                        {
                            Limpiar();
                            Utility.MensajeToastr(this.Page, "Se Guardo Correctamente!", "TC", "Success");
                        }
                        else
                        {
                            Utility.MensajeToastr(this.Page, "No se Guardo!", "Error", "Error");
                        }
                    }
                }
                else
                {
                    if (Validar())
                    {
                        if (estudiante.Editar())
                        {
                            Limpiar();
                            Utility.MensajeToastr(this.Page, "Se Modifico Correctamente!", "TC", "Success");
                        }
                        else
                        {
                            Utility.MensajeToastr(this.Page, "No se Modifico!", "Error", "Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Utility.MensajeToastr(this.Page, "Comunicase con el administrador \n" + ex.Message + "", "Error", "Warning");
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Estudiantes estudiante = new Estudiantes();
            try
            {
                if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (Validar())
                    {
                        if (estudiante.Eliminar())
                        {
                            Limpiar();
                            Utility.MensajeToastr(this.Page, "Se Elimino Correctamente!", "TC", "Success");
                        }
                        else
                        {
                            Utility.MensajeToastr(this.Page, "No se elimino!", "Error", "Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.MensajeToastr(this.Page, "Comunicase con el administrador \n" + ex.Message + "", "Error", "Warning");
            }
        }
    }
}