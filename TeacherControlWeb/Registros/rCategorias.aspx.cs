using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb.Registros
{
    public partial class rCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaCalificaciones categoria = new CategoriaCalificaciones();
            int id = 0;
            if (!IsPostBack)
            {
                CategoriasGridView.DataSource = categoria.Listado("*", "1=1", "");
                CategoriasGridView.DataBind();
                if (Request.QueryString["ID"] != null)
                {
                    id = Utility.ConvierteEntero(Request.QueryString["ID"].ToString());
                    if (categoria.Buscar(id))
                    {
                        Devolverdatos(categoria);
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
        private void LlenarDatos(CategoriaCalificaciones categoria)
        {
            categoria.CategoriaCalificacionesId= Utility.ConvierteEntero(IdTextBox.Text);
            categoria.Descripcion = DescripcionTextBox.Text;

        }
        private void Devolverdatos(CategoriaCalificaciones categoria)
        {
            IdTextBox.Text = categoria.CategoriaCalificacionesId.ToString();
            DescripcionTextBox.Text = categoria.Descripcion;
        }
        private bool Validad(CategoriaCalificaciones categoria)
        {
            if (!string.IsNullOrWhiteSpace(DescripcionTextBox.Text) && categoria.BuscarDescripcion(DescripcionTextBox.Text).Equals(false))
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
            CategoriaCalificaciones categoria = new CategoriaCalificaciones();

            try
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (Validad(categoria).Equals(true))
                    {
                        LlenarDatos(categoria);
                        if (categoria.Insertar())
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
                    if (Validad(categoria).Equals(true))
                    {
                        LlenarDatos(categoria);
                        if (categoria.Editar())
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

                CategoriaCalificaciones categoria = new CategoriaCalificaciones();

                if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (Validad(categoria).Equals(false))
                    {
                        LlenarDatos(categoria);
                        if (categoria.Eliminar())
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