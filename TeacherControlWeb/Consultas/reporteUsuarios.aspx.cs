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
using BLL;

namespace TeacherControlWeb.Consultas
{
    public partial class reporteUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                //Configurar(UsuariosReportViewer);
            
        }

        private void Configurar( ReportViewer rv)
        {
            rv.LocalReport.DataSources.Clear();
            rv.ProcessingMode = ProcessingMode.Local;


            rv.LocalReport.ReportPath = @"Reportes\UsuariosReport.rdlc";
            ReportDataSource sourse = new ReportDataSource("Usuarios",Usuarios.ListadoDt("1=1"));

            rv.LocalReport.DataSources.Add(sourse);
            rv.LocalReport.Refresh();
        }
       

        protected void CargarImgButton_Click(object sender, EventArgs e)
        {
            //Configurar(UsuariosReportViewer);
            Utility.ConfigurarReporte(UsuariosReportViewer, @"Reportes\UsuariosReport.rdlc", "Usuarios", Usuarios.ListadoDt("1=1"));
        }
    }
}