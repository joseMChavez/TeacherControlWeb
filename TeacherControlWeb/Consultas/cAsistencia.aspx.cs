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

            if (TipoDropDownL.SelectedValue == "1")
            {
                filtroDDL2.Visible = false;
                fecha.Visible = true;
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


            AsistenciaGridView.DataSource = Asistencia.ListadoAsistencia(filtro, Utility.ConvierteEntero(Session["UsuarioId"].ToString()));
            AsistenciaGridView.DataBind();
            return filtro;
        }
        private string MostrarDos()
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

            AsGridView.DataSource = Utility.ListadoView("Asistencia_view", "Id=" + Session["UsuarioId"].ToString() + " and " + filtro, "");
            AsGridView.DataBind();
            return filtro;
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            if (TipoDropDownL.SelectedValue == "1")
            {
                MostrarDos();
                Utility.ConfigurarReporte(AsistenciaReportViewer, @"Reportes\AsistenciaR.rdlc", "AsistenciaF", Utility.ListadoView("Asistencia_view", "Id=" + Session["UsuarioId"].ToString() + " and " + MostrarDos(), ""));
            }
            else
            {
                Mostrar();
                Utility.ConfigurarReporte(AsistenciaReportViewer, @"Reportes/AsistenciasReport.rdlc", "Asistencias", Asistencia.ListadoAsistencia(Mostrar(), Utility.ConvierteEntero(Session["UsuarioId"].ToString())));
            }

        }
        protected void TipoDropDownL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TipoDropDownL.SelectedValue == "1")
            {
                filtroDDL2.Visible = false;
                filtroDDL1.Visible = true;
                fecha.Visible = true;
                Grid1.Visible = true;
                Grid2.Visible = false;
                MostrarDos();
                Utility.ConfigurarReporte(AsistenciaReportViewer, @"Reportes\AsistenciaR.rdlc", "AsistenciaF", Utility.ListadoView("Asistencia_view", "Id=" + Session["UsuarioId"].ToString() + " and " + MostrarDos(), ""));
            }
            else
            {
                filtroDDL1.Visible = false;
                filtroDDL2.Visible = true;
                Grid1.Visible = false;
                Grid2.Visible = true;
                fecha.Visible = false;
                Mostrar();
                Utility.ConfigurarReporte(AsistenciaReportViewer, @"Reportes/AsistenciasReport.rdlc", "Asistencias", Asistencia.ListadoAsistencia(Mostrar(), Utility.ConvierteEntero(Session["UsuarioId"].ToString())));
            }
        }
    }
}