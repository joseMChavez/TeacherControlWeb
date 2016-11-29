using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb.Registros
{
    public partial class rGrupos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                Grupos grupos = new Grupos();
                GrupoGridView.DataSource = Grupos.ListadoDos("1=1", Utility.ConvierteEntero(Session["UsuarioId"].ToString()));
                GrupoGridView.DataBind();
                CargarDropDL();
                if (Request.QueryString["ID"] != null)
                {
                   int id = Utility.ConvierteEntero(Request.QueryString["ID"].ToString());
                    if (grupos.Buscar(id))
                    {
                        Devolverdatos(grupos);
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
        private void CargarDropDL()
        {
            Cursos curso = new Cursos();
            CursosDropDownList.DataSource = curso.Listado("*", "UsuarioId="+Session["UsuarioId"].ToString(), "");
            CursosDropDownList.DataTextField = "Descripcion";
            CursosDropDownList.DataValueField = "CursoId";
            CursosDropDownList.DataBind();
        }
        private void LlenarDatos(Grupos grupo)
        {
            grupo.GrupoId= Utility.ConvierteEntero(IdTextBox.Text);
            grupo.UsuarioId = Utility.ConvierteEntero(Session["UsiarioId"].ToString());
            grupo.CursoId = Utility.ConvierteEntero(CursosDropDownList.SelectedValue);
            grupo.Descripcion = DescripcionTextBox.Text;

        }
        private void Devolverdatos(Grupos grupo)
        {
            //Session["UsuarioId"] = grupo.UsuarioId.ToString();
            IdTextBox.Text = grupo.GrupoId.ToString();
            CursosDropDownList.Text = grupo.CursoId.ToString();
            DescripcionTextBox.Text = grupo.Descripcion;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Grupos grupos = new Grupos();
            bool exito = false;
            LlenarDatos(grupos);
            try
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    exito = grupos.Insertar();
                }
                else
                {
                    exito = grupos.Editar();
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
                Grupos grupos = new Grupos();
                if (IdTextBox.Text != "")
                {
                    grupos.GrupoId = Utility.ConvierteEntero(IdTextBox.Text);
                    grupos.UsuarioId = Utility.ConvierteEntero(Session["UsuarioId"].ToString());
                    if (grupos.Eliminar())
                    {
                        Limpiar();
                        Response.Write("Se Elimino Correctamente!");
                        Utility.MensajeToastr(this.Page, "Se Elimino Correctamente!", "TC", "Success");
                        
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
