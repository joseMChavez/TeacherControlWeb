using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb.Consultas
{
    public partial class cUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Usuarios user = new Usuarios();
            if (!IsPostBack)
            {
                UsuariosRepeater.DataSource = user.Listado("Nombres,UserName,Imagen,Email,Telefono", "1=1", "");
                UsuariosRepeater.DataBind();
            }
        }
        private void Mostrar(Usuarios user)
        {
            string filtro = "";

            if (string.IsNullOrWhiteSpace(FiltroTextBox.Text))
            {
                filtro = "1=1";
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(FiltroTextBox.Text))
                {
                    
                        filtro = FiltroDropDownList.SelectedValue + " like '%" + FiltroTextBox.Text + "%'";
                }

            }
            UsuariosRepeater.DataSource = user.Listado("Nombres,UserName,Imagen,Email,Telefono", filtro, "");
            UsuariosRepeater.DataBind();
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            Mostrar(user);
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Consultas/reporteUsuarios.aspx");
            Response.Clear();
        }
    }
}