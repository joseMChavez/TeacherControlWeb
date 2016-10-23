using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;



namespace BLL
{
    public static class Utility
    {

        public static void MensajeToastr(Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }
        public static void ConfigurarReporte(ReportViewer rv, string ruta,string DataSets, DataTable listado)
        {
            rv.LocalReport.DataSources.Clear();
            rv.ProcessingMode = ProcessingMode.Local;


            rv.LocalReport.ReportPath = @ruta;
            ReportDataSource sourse = new ReportDataSource(DataSets, listado);

            rv.LocalReport.DataSources.Add(sourse);
            rv.LocalReport.Refresh();
        }

        public static int ConvierteEntero(string s)
        {
            int id = 0;
            int.TryParse(s, out id);
            return id;
        }
        public static float ConvierteFloat(string s)
        {
            float id = 0;
            float.TryParse(s, out id);
            return id;
        }
        // Estos metodos reciven un evento cuando se presiona una tecla en el textbox para Validarlos
    }
}
