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

        }
        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
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

    }
}