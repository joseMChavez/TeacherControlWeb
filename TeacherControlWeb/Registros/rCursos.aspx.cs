using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb.Registros
{
    public partial class rCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cursos curso = new Cursos();
            int id = 0;
           
            if (!IsPostBack)
            {
                Cursos2GridView.DataSource = curso.Listado("*", "1=1", "");
                Cursos2GridView.DataBind();
                if (Request.QueryString["ID"]!= null)
                {
                    id = Utility.ConvierteEntero(Request.QueryString["ID"].ToString());
                    if (curso.Buscar(id))
                    {
                        Devolverdatos(curso);
                        DescripcionTextBox.Focus();
                    }
                }
            }
        }

        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            DescripcionTextBox.Focus();
        }
        private void LlenarDatos(Cursos curso) {
            curso.CursoId = Utility.ConvierteEntero(IdTextBox.Text);
            curso.Descripcion = DescripcionTextBox.Text;

        }
        private void Devolverdatos(Cursos curso)
        {
            IdTextBox.Text = curso.CursoId.ToString();
            DescripcionTextBox.Text = curso.Descripcion;
        }
        private bool Validad(Cursos curso)
        {
            if (!string.IsNullOrWhiteSpace(DescripcionTextBox.Text) && curso.BuscarDescripcion(DescripcionTextBox.Text).Equals(false))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
         
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Cursos curso = new Cursos();
            try
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (Validad(curso).Equals(true))
                    {
                        LlenarDatos(curso);
                        if (curso.Insertar())
                        {
                            Limpiar();
                             Utility.MensajeToastr(this.Page, "Se Guardo Correctamente!", "TC","Success");
                            //Utility.Mensaje(this.Page, "Guardo");
                        }
                        else
                        {
                            Utility.MensajeToastr(this.Page, "No se Guardo!", "TC", "Error");
                            DescripcionTextBox.Focus();
                        }
                    }
                    else
                    {
                        DescripcionTextBox.Focus();
                        Utility.MensajeToastr(this.Page, "Intente Nuevamente!", "TC");
                    }
                }
                else
                {
                    if (Validad(curso).Equals(true))
                    {
                        LlenarDatos(curso);
                        if (curso.Editar())
                        {
                            Limpiar();
                            Utility.MensajeToastr(this.Page, "Se Modifico Correctamente!", "TC", "Success");
                        }
                        else
                        {
                            Utility.MensajeToastr(this.Page, "No se Modifico!", "TC", "Error");
                            DescripcionTextBox.Focus();
                        }
                    }
                    else
                    {
                        DescripcionTextBox.Focus();
                        Utility.MensajeToastr(this.Page, "Intente Nuevamente!", "TC");
                    }
                }
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursos curso = new Cursos();
                if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (Validad(curso).Equals(false))
                    {
                        LlenarDatos(curso);
                        if (curso.Eliminar())
                        {
                            Limpiar();
                            Utility.MensajeToastr(this.Page, "Se Elimino Correctamente!", "TC", "Success");
                        }
                        else
                        {
                            Utility.MensajeToastr(this.Page, "No se Elimino!", "TC", "Error");
                            DescripcionTextBox.Focus();
                        }
                    }
                    else
                    {
                        DescripcionTextBox.Focus();
                        Utility.MensajeToastr(this.Page, "Intente Nuevamente!", "TC");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Consultas/cCursos.aspx");
        }
    }
}