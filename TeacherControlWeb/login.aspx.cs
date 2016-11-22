using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using BLL;

namespace TeacherControlWeb
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void EntrarButton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            bool paso = false;
            if (!string.IsNullOrWhiteSpace(UserTextBox.Text)&& !string.IsNullOrWhiteSpace(PassTextBox.Text))
            {
                Session["User"] = UserTextBox.Text;
                Session["Clave"] = PassTextBox.Text;
            }
            else
            {
                Session["User"] ="Visita";
                Session["Clave"] = "Visita";
            }
            
                paso = Usuarios.Acceder(UserTextBox.Text, PassTextBox.Text);
           
             

            if (paso)
            {
                FormsAuthentication.RedirectFromLoginPage(user.UserName, RememberMeCheckBox.Checked);
            }
            else
            {
                Response.Write("Usuarios y contraseña incorrectos!");
            }
        }
       
    }
}