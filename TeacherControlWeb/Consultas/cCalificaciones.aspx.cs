using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Microsoft.Reporting.WebForms;

namespace TeacherControlWeb.Consultas
{
    public partial class cCalificaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Utility.ConfigurarReporte(CalificacionesReport, @"Reportes\CalificacionesReport.rdlc", "Calificaciones", Calificaciones.ListadoVista("1=1"));
        }
    }
}