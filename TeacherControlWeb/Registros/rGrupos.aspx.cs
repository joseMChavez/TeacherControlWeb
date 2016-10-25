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

        }
        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
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
    }
}