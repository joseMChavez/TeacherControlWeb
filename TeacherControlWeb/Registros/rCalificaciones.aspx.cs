﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb.Registros
{
    public partial class rCalificaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDropDs();
                CargarGrupos();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Estudiante"), new DataColumn("Matricula"), new DataColumn("Descripcion"), new DataColumn("Puntuacion") });
                ViewState["Calificacion"] = dt;
                FechaLabel.Text = DateTime.Now.ToShortDateString();
            }
        }
        private void Limpiar()
        {
            DataTable dt = new DataTable();
            IdTextBox.Text = string.Empty;
            PuntosTextBox.Text = string.Empty;
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Estudiante"), new DataColumn("Matricula"), new DataColumn("Descripcion"), new DataColumn("Puntuacion") });
            ViewState["Calificacion"] = dt;
            CargarGrid();
        }

        private void CargarDropDs()
        {
            CursoDropDownList.DataSource = Utility.ListadoView("Cursos", "1=1", "");
            CursoDropDownList.DataTextField = "Descripcion";
            CursoDropDownList.DataValueField = "CursoId";
            CursoDropDownList.DataBind();

            MateriaDropDownList.DataSource = Utility.ListadoView("Materias", "1=1", "");
            MateriaDropDownList.DataTextField= "Descripcion";
            MateriaDropDownList.DataValueField = "MateriaId";
            MateriaDropDownList.DataBind();

            DescripcionDropDownList.DataSource = Utility.ListadoView("CategoriaCalificaciones", "1=1", "");
            DescripcionDropDownList.DataTextField = "Descripcion";
            DescripcionDropDownList.DataValueField = "Descripcion";
            DescripcionDropDownList.DataBind();
        }
        private void CargarEstudiantes()
        {
            EstudiantesDropDownList.DataSource = Estudiantes.ListadoDos("EstudianteId, Nombre", "CursoId='" + CursoDropDownList.SelectedValue + "'And Grupo='" + GrupoDropDownList.SelectedValue + "'", "");
            EstudiantesDropDownList.DataTextField = "Nombre";
            EstudiantesDropDownList.DataValueField = "Nombre";
            EstudiantesDropDownList.DataBind();

        }
        private void CargarGrupos()
        {
            GrupoDropDownList.DataSource = Estudiantes.ListadoDos("EstudianteId, Grupo", "CursoId='" + CursoDropDownList.SelectedValue + "'", "CursoId");
            GrupoDropDownList.DataTextField = "Grupo";
            GrupoDropDownList.DataValueField = "Grupo";
            GrupoDropDownList.DataBind();


        }
        private void Cargarmatricula()
        {
            MatDropDownList.DataSource = Estudiantes.ListadoDos("EstudianteId,Matricula", "Nombre = '" + EstudiantesDropDownList.SelectedValue + "'", "");
            MatDropDownList.DataTextField = "Matricula";
            MatDropDownList.DataValueField = "Matricula";
            MatDropDownList.DataBind();
        }
        private void CargarGrid()
        {
            CalificacionesGridView.DataSource = (DataTable)ViewState["Calificacion"];
            CalificacionesGridView.DataBind();
        }

        private void Llenardatos(Calificaciones calificacion)
        {
            calificacion.CalificacionId = Utility.ConvierteEntero(IdTextBox.Text);
            calificacion.CursoId = Utility.ConvierteEntero(CursoDropDownList.SelectedValue);
            calificacion.Grupo = GrupoDropDownList.SelectedValue;
            calificacion.Fecha = FechaLabel.Text;

            foreach (GridViewRow item in CalificacionesGridView.Rows)
            {
                calificacion.AgregarCalificaiones(item.Cells[0].Text, Utility.ConvierteEntero(item.Cells[1].Text), item.Cells[2].Text, Utility.ConvierteFloat(item.Cells[3].Text));
            }
        }
        private void DevolverDatos(Calificaciones calificacion)
        {
            IdTextBox.Text = calificacion.CalificacionId.ToString();
            CursoDropDownList.SelectedValue = calificacion.CursoId.ToString();
            GrupoDropDownList.SelectedValue = calificacion.Grupo;
            MateriaDropDownList.SelectedValue = calificacion.MateriaId.ToString();
            FechaLabel.Text = calificacion.Fecha;

            foreach (var item in calificacion.DetalleC)
            {
                DataTable dt = (DataTable)ViewState["Calificacion"];
                dt.Rows.Add(item.Estudiante, item.Matricula, item.Descripcion, item.Puntuacion);
                ViewState["Calificacion"] = dt;
                CalificacionesGridView.DataSource = ViewState["Calificacion"];
                CalificacionesGridView.DataBind();
            }
        }
        protected void CursoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrupos();
        }

        protected void CargarButton_Click(object sender, EventArgs e)
        {
            CargarEstudiantes();
            Cargarmatricula();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {

        }
    }
}