using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb.Consultas
{
    public partial class cGrupos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Grupos grupos = new Grupos();
            string filtro = Mostrar(grupos);
           
            if (!IsPostBack)
            {
                if (filtro.Equals(""))
                {
                    filtro = "1=1";
                }
                GruposGridView.DataSource = grupos.Listado("*",filtro , "");
                GruposGridView.DataBind();
            }
        }
        private string Mostrar(Grupos grupo)
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
                    filtro = "GrupoId = " + FiltroTextBox.Text;
                }
                else
                {
                    filtro = FiltroDropDownList.SelectedValue + " like '%" + FiltroTextBox.Text + "%'";
                }



            }

            GruposGridView.DataSource = grupo.Listado("* ", filtro, "");
            GruposGridView.DataBind();
            return filtro;
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Grupos grupo = new Grupos();
            Mostrar(grupo);
        }
    }
}