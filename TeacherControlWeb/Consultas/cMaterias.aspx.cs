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
          
            Materias materias = new Materias();
            string filtro = Mostrar(materias);
            if (filtro.Equals(""))
            {
                filtro = "1=1";
            }
            if (!Page.IsPostBack)
            {
                Utility.ConfigurarReporte(MateriasReportViewer, @"Reportes/MateriaReport.rdlc", "Materias", Materias.ListadoMMat(filtro));
            }
        }
        private string Mostrar( Materias materia)
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

            MateriasGridView.DataSource = materia.Listado("* ", filtro, "");
            MateriasGridView.DataBind();
            return filtro;
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Materias materia = new Materias();
            
            Mostrar(materia);

        }
    }
}