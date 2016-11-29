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

            
            if (!IsPostBack)
            {
                if (TipoDropDownL.SelectedValue == "1")
                {
                    repeater.Visible = false;
                    grid.Visible = true;
                    fecha.Visible = true;
                }
                Usuarios user = new Usuarios();
                UsuariosRepeater.DataSource = user.Listado("Nombres,UserName,Imagen,Email,Telefono", "1=1", "");
                UsuariosRepeater.DataBind();
                
            }
        }
        private string Mostrar()
        {
            string filtro = "";
            if (ONCheckBox.Checked.Equals(false))
            {
                if (string.IsNullOrWhiteSpace(FiltroTextBox.Text))
                    filtro = "1=1";
                else
                    filtro = FiltroDropDownList.SelectedValue + " like '%" + FiltroTextBox.Text + "%'";
            }
            else
                filtro = " Fecha  BETWEEN '" + DesdeTextBox.Text + "' AND '" + HastaTextBox.Text + "' ";

            UGridView.DataSource = Utility.ListadoView("Usuarios", filtro, "");
            UGridView.DataBind();
            return filtro;
        }
        private string Mostrar(Usuarios user)
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
            return filtro;
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            if (TipoDropDownL.SelectedValue == "1")
            {
                Mostrar();
                Utility.ConfigurarReporte(UsuariosReportViewer, @"Reportes\UsuariosReport.rdlc", "Usuarios", Usuarios.ListadoDt(Mostrar()));
            }
            else {
                Mostrar(user);
                Utility.ConfigurarReporte(UsuariosReportViewer, @"Reportes\UsuariosReport.rdlc", "Usuarios", Usuarios.ListadoDt(Mostrar(user)));
            }
            
        }
        protected void TipoDropDownL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TipoDropDownL.SelectedValue=="1")
            {
                repeater.Visible = false;
                grid.Visible = true;
                fecha.Visible = true;
            }
            else
            {
                repeater.Visible = true;
                grid.Visible = false;
                fecha.Visible = false;
            }
        }
        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            //Response.Redirect("~/Consultas/reporteUsuarios.aspx");
            //Response.Clear();
            Utility.ConfigurarReporte(UsuariosReportViewer, @"Reportes\UsuariosReport.rdlc", "Usuarios", Usuarios.ListadoDt(Mostrar(user)));
        }
    }
}