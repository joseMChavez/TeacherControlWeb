using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb.Consultas
{
    public partial class cMaterias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroTextBox.MaxLength = 20;
          
           
            string filtro = Mostrar();
            if (filtro.Equals(""))
            {
                filtro = "1=1";
            }
            if (!Page.IsPostBack)
            {
                Utility.ConfigurarReporte(MateriasReportViewer, @"Reportes/MateriaReport.rdlc", "Materias", Materias.ListadoMat(filtro, Utility.ConvierteEntero(Session["UsuarioId"].ToString())));
            }
        }
        private string Mostrar()
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
                    filtro = "MateriaId = " + FiltroTextBox.Text;
                }
                else
                {
                    filtro = FiltroDropDownList.SelectedValue + " like '%" + FiltroTextBox.Text + "%'";
                }



            }

            MateriasGridView.DataSource = Materias.ListadoMat(filtro, Utility.ConvierteEntero(Session["UsuarioId"].ToString()));
            MateriasGridView.DataBind();
            return filtro;
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            Mostrar();

        }
    }
}