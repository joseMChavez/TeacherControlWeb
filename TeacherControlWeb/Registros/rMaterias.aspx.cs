using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb.Registros
{
    public partial class rMaterias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //aqui va codigo de boton buscar.
            Materias materia = new Materias();
            int id = 0;

            if (!IsPostBack)
            {
                Cursos2GridView.DataSource = materia.Listado("*", "1=1", "");
                Cursos2GridView.DataBind();
                if (Request.QueryString["ID"] != null)
                {
                    id = Utility.ConvierteEntero(Request.QueryString["ID"].ToString());
                    if (materia.Buscar(id))
                    {
                        Devolverdatos(materia);
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
        private void LlenarDatos(Materias materia)
        {
            materia.MateriaId = Utility.ConvierteEntero(IdTextBox.Text);
            materia.Descripcion = DescripcionTextBox.Text;

        }
        private void Devolverdatos(Materias materia)
        {
            IdTextBox.Text = materia.MateriaId.ToString();
            DescripcionTextBox.Text = materia.Descripcion;
        }
        private bool Validad(Materias materia)
        {
            if (!string.IsNullOrWhiteSpace(DescripcionTextBox.Text) && materia.BuscarDescripcion(DescripcionTextBox.Text).Equals(false))
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
            Materias materia = new Materias();
            try
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (Validad(materia).Equals(true))
                    {
                        LlenarDatos(materia);
                        if (materia.Insertar())
                        {
                            Limpiar();
                            Utility.MensajeToastr(this.Page, "Se Guardo Correctamente!", "TC", "Success");
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
                    if (Validad(materia).Equals(true))
                    {
                        LlenarDatos(materia);
                        if (materia.Editar())
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

                Utility.MensajeToastr(this.Page, "" + ex.Message + "", "TC");
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Materias materia = new Materias();
                if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (Validad(materia).Equals(false))
                    {
                        LlenarDatos(materia);
                        if (materia.Eliminar())
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
                Utility.MensajeToastr(this.Page, "" + ex.Message + "", "TC");

            }
        }
    }

}