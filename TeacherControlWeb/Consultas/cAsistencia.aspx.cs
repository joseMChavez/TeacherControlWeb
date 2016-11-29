using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb.Consultas
{
    public partial class cAsistencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        private string Mostrar()
        {

            string filtro = "";
            if (ONCheckBox.Checked.Equals(false))
            {
                if (string.IsNullOrWhiteSpace(FiltroTextBox.Text))
                {
                    filtro = "1=1";
                }
                else
                {
                    filtro = FiltroDropDownList.SelectedValue + " like '%" + FiltroTextBox.Text + "%'";
                }
            }
            else
            {
                filtro = "Fecha  BETWEEN '" + DesdeTextBox.Text + "' AND '" + HastaTextBox.Text + "' ";

            }

            AsGridView.DataSource = Asistencia.ListadoAsistencia(filtro, Utility.ConvierteEntero(Session["UsuarioId"].ToString()));
            AsGridView.DataBind();
            return filtro;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Mostrar();
            string filtro = Mostrar();
            if (filtro=="")
            {
                filtro = "1=1";
            }
            Utility.ConfigurarReporte(AsistenciaReportViewer, @"Reportes/AsistenciasReport.rdlc", "Asistencias", Asistencia.ListadoAsistencia(filtro, Utility.ConvierteEntero(Session["UsuarioId"].ToString())));
        }
    }
}