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
            

            if (!IsPostBack)
            {
                Cursos curso = new Cursos();
                int id = 0;
                Cursos2GridView.DataSource = Cursos.ListadoDos("1=1", Utility.ConvierteEntero(Session["UsuarioId"].ToString()));
                Cursos2GridView.DataBind();
                if (Request.QueryString["ID"] != null)
                {
                    
                    id = Utility.ConvierteEntero(Request.QueryString["ID"].ToString());
                    curso.CursoId = id;
                    curso.UsuarioId = Utility.ConvierteEntero(Session["UsuarioId"].ToString());
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
        private void LlenarDatos(Cursos curso)
        {
            curso.CursoId = Utility.ConvierteEntero(IdTextBox.Text);
            curso.UsuarioId = Utility.ConvierteEntero(Session["UsuarioId"].ToString());
            curso.Descripcion = DescripcionTextBox.Text;

        }
        private void Devolverdatos(Cursos curso)
        {
            Session["UsuarioId"] = curso.UsuarioId.ToString();
            IdTextBox.Text = curso.CursoId.ToString();
            DescripcionTextBox.Text = curso.Descripcion;
        }
        
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Cursos curso = new Cursos();
            LlenarDatos(curso);
            bool exito = false;
            try
            {
                    if (string.IsNullOrWhiteSpace(IdTextBox.Text))
                    {
                        exito = curso.Insertar();
                    }
                    else
                    {
                        exito = curso.Editar();
                    }
           
            
            if (exito)
                {
                    Utility.MensajeToastr(this.Page, "Exito!", "TC", "Success");
                    Limpiar();
                }
            }
            catch (Exception ex)
            {

                Utility.MensajeToastr(this.Page, "Comunicase con el administrador \n" + ex.Message + "", "Error", "Warning");
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursos curso = new Cursos();
                if (Request.QueryString["ID"] != null)
                {
                    curso.CursoId = Utility.ConvierteEntero(IdTextBox.Text);

                    if (curso.Eliminar())
                    {
                        Limpiar();
                        Utility.MensajeToastr(this.Page, "Se Elimino Correctamente!", "TC", "Success");
                        Request.QueryString["ID"] = null;
                    }
                }
            }
            catch (Exception ex)
            {

                Utility.MensajeToastr(this.Page, "Comunicase con el administrador \n" + ex.Message + "", "Error", "Warning");
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e) 
        {
            Cursos curso = new Cursos();
            Cursos2GridView.DataSource = curso.Listado("*", "1=1", "");
            Cursos2GridView.DataBind();
        }
    }
}