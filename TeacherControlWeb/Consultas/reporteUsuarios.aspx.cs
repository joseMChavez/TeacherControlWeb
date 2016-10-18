using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Web.UI.HtmlControls;

namespace TeacherControlWeb.Consultas
{
    public partial class reporteUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Configurar(UsuariosReportViewer);
            //RedirecRepor(UsuariosReportViewer,Response);
            Response.Clear();
        }

        private void Configurar( ReportViewer rv)
        {
            rv.LocalReport.DataSources.Clear();
            rv.LocalReport.ReportPath = @"Reportes\UsuariosReport.rdlc";
            rv.LocalReport.Refresh();
        }
        private void RedirecRepor(ReportViewer rv, HttpResponse response)
        {
            Warning[] warning;
            string[] streamind;
            string minitype;
            string encodin;
            string extenciones;
            byte[] Bytes = rv.LocalReport.Render("PDF", null, out minitype, out encodin, out extenciones, out streamind, out warning);

            response.Clear();
            response.ContentType = minitype;
            response.AppendHeader("content-Disposition", "inline: filename= TrainingofficalRecord."+extenciones);
            response.BinaryWrite(Bytes);
            response.End();
        }
    }
}