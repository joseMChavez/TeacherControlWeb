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
            Grupos grupos = new Grupos();
            if (!IsPostBack)
            {
                GrupoGridView.DataSource = grupos.Listado("*","1=1","");
                GrupoGridView.DataBind();
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
        private void LlenarDatos(Grupos grupo)
        {
            grupo.GrupoId= Utility.ConvierteEntero(IdTextBox.Text);
            grupo.Descripcion = DescripcionTextBox.Text;

        }
        private void Devolverdatos(Grupos grupo)
        {
            IdTextBox.Text = grupo.GrupoId.ToString();
            DescripcionTextBox.Text = grupo.Descripcion;
        }
        private bool Validad(Grupos grupo)
        {
            if (!string.IsNullOrWhiteSpace(DescripcionTextBox.Text) && grupo.BuscarDescripcion(DescripcionTextBox.Text).Equals(false))
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
            Grupos grupos = new Grupos();
            try
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (Validad(grupos).Equals(true))
                    {
                        LlenarDatos(grupos);
                        if (grupos.Insertar())
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
                    if (Validad(grupos).Equals(true))
                    {
                        LlenarDatos(grupos);
                        if (grupos.Editar())
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
                Grupos grupos = new Grupos();
                if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (Validad(grupos).Equals(false))
                    {
                        LlenarDatos(grupos);
                        if (grupos.Eliminar())
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
            catch (Exception ex)
            {
                Utility.MensajeToastr(this.Page, ""+ex.Message+"", "TC");

            }
        }
    }
}
