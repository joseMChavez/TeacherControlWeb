using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb.Consultas
{
    public partial class cEstudiantesCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string filtro = Mostrar();
                if (filtro == "")
                {
                    filtro = "1=1";
                }
                CursosEstGridView.DataSource = Estudiantes.ListadoEstudianteCurso("1=1", "CursoId, Seccion");
                CursosEstGridView.DataBind();
                Utility.ConfigurarReporte(CursosEstReportViewer, @"Reportes\CursoEstReport.rdlc", "CursoEst", Estudiantes.ListadoEstudianteCurso(filtro, "CursoId, Seccion"));
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

                filtro = FiltroDropDownList.SelectedValue + " like '%" + FiltroTextBox.Text + "%'";

            }

            CursosEstGridView.DataSource = Estudiantes.ListadoEstudianteCurso(filtro, "Curso, Seccion");
            CursosEstGridView.DataBind();
            return filtro;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Mostrar();
        }
    }
}