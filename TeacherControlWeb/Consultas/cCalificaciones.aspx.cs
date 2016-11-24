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
            
            if (!IsPostBack)
            {
                //string filtro = Mostrar();
                //if (filtro=="")
                //{
                //    filtro = "1=1";
                //}
                //Utility.ConfigurarReporte(CalificacionesReport, @"Reportes\CalificacionesReport.rdlc", "Calificaciones", Calificaciones.ListadoVista(filtro));

                //CalificacionesGridView.DataSource = Calificaciones.ListadoVista("1=1");
                //CalificacionesGridView.DataBind(); 

                if (TipoDropDownL.SelectedValue=="1")
                {
                    FiltroDDL.Visible = false;
                }
        }
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
                filtro = "Fecha  BETWEEN '"+DesdeTextBox.Text+"' AND '"+HastaTextBox.Text+"' ";
                
            }

            CalificacionesGridView.DataSource = Calificaciones.ListadoVista(filtro);
            CalificacionesGridView.DataBind();
            return filtro;
        }
        private string MostrarDos()
        {

            string filtro = "";
             if (string.IsNullOrWhiteSpace(FiltroTextBox.Text))
                {
                    filtro = "1=1";
                }
                else
                {
                    filtro = FiltroDropDownList2.SelectedValue + " like '%" + FiltroTextBox.Text + "%'";
                }
            

            CalificacionesGridView.DataSource = Calificaciones.Promedio(filtro);
            CalificacionesGridView.DataBind();
            return filtro;
        }
        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Utility.ConfigurarReporte(CalificacionesReport, @"Reportes\CalificacionesReport.rdlc", "Calificaciones", Calificaciones.ListadoVista("1=1"));
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            
            if (TipoDropDownL.SelectedValue == "1")
            {
                Mostrar();
            }
            else
            {
                MostrarDos();
            }
        }

        protected void TipoDropDownL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TipoDropDownL.SelectedValue == "1")
            {
                FiltroDDL.Visible = false;
                Desde.Visible = true;
                DesdeDos.Visible = true;
                Hasta.Visible = true;
                Hasta2.Visible = true;
                Activador1.Visible = true;
                Activador2.Visible = true;
            }
            else
            {
                FiltroDDL.Visible = true;
                ListaFiltro.Visible = false;
                Desde.Visible = false;
                DesdeDos.Visible = false;
                Hasta.Visible = false;
                Hasta2.Visible = false;
                Activador1.Visible = false;
                Activador2.Visible = false;

            }
        }
    }
}