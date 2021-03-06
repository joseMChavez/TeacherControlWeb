﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb.Consultas
{
    public partial class cEstudiantes : System.Web.UI.Page
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
                    filtro = "1=1";
                else
                    filtro = FiltroDropDownList.SelectedValue + " like '%" + FiltroTextBox.Text + "%'";
            }
            else
                filtro = " Fecha  BETWEEN '" + DesdeTextBox.Text + "' AND '" + HastaTextBox.Text + "' ";

            EstudianteGridView.DataSource = Estudiantes.ListadoEstudiante(filtro, Utility.ConvierteEntero(Session["UsuarioId"].ToString()));
            EstudianteGridView.DataBind();
            return filtro;
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Mostrar();
            Utility.ConfigurarReporte(EstudianteReportViewer, @"Reportes/EstudiantesReport.rdlc", "Estudiantes", Asistencia.ListadoAsistencia(Mostrar(), Utility.ConvierteEntero(Session["UsuarioId"].ToString())));
        }
    }
}