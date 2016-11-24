using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb.Consultas
{
    public partial class cCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroTextBox.MaxLength = 20;
            if (!IsPostBack)
            {
                
                Utility.ConfigurarReporte(CursosReportViewer, @"Reportes\CursosReport.rdlc", "Cursos",Cursos.ListadoDos(Mostrar()));
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
                        filtro = "CursoId = " + FiltroTextBox.Text;
                    }
                    else
                    {
                        filtro = FiltroDropDownList.SelectedValue + " like '%" + FiltroTextBox.Text + "%'";
                    }

                

            }
            CursosGridView.DataSource = Cursos.ListadoDos(filtro);
            CursosGridView.DataBind();
            return filtro;
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
           
            Mostrar();
        }
     

    }
}