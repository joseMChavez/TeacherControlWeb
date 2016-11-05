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
        
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            CategoriaCalificaciones categoria = new CategoriaCalificaciones();
            LlenarDatos(categoria);
            bool exito = false;
            try
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    exito = categoria.Insertar();
                }
                else
                {
                    exito = categoria.Editar();
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
                CategoriaCalificaciones categoria = new CategoriaCalificaciones();

                if (Request.QueryString["ID"] != null)
                {
                    categoria.CategoriaCalificacionesId = Utility.ConvierteEntero(IdTextBox.Text);

                    if (categoria.Eliminar())
                    {
                        Limpiar();
                        Utility.MensajeToastr(this.Page, "Se Elimino Correctamente!", "TC", "Success");
                        
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