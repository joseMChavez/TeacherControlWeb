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

        }

        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
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
    }
}