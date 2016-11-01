using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb.Consultas
{
    public partial class cCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriaCalificaciones categoria = new CategoriaCalificaciones();
                CategoriaGridView.DataSource = categoria.Listado("* ", "1=1", "");
                CategoriaGridView.DataBind();
            }
        }
        private string Mostrar(CategoriaCalificaciones categoria)
        {


            string filtro = "";

            if (string.IsNullOrWhiteSpace(FiltroTextBox.Text))
            {
                filtro = "1=1";
            }
            else
            {

                if (FiltroDropDownList.SelectedIndex == 0)
                {
                    filtro = "CategoriaCalificacionesId = " + FiltroTextBox.Text;
                }
                else
                {
                    filtro = FiltroDropDownList.SelectedValue + " like '%" + FiltroTextBox.Text + "%'";
                }



            }

            CategoriaGridView.DataSource = categoria.Listado("* ", filtro, "");
            CategoriaGridView.DataBind();
            return filtro;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            CategoriaCalificaciones categoria = new CategoriaCalificaciones();
            Mostrar(categoria);
        }
    }
}