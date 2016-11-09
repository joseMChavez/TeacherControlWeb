using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace TeacherControlWeb.Registros
{
    public partial class rAsistencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                DataTable dt =new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn ("Estudiante"), new DataColumn("Matricula"), new DataColumn("Estado") });
                ViewState["Asistencia"] = dt;
                CargarDropDs();
                CargarGrupos();
                Cargarmatricula();

                FechaLabel.Text = DateTime.Now.ToString("dd/MM/yyyy"); 
            }
        }
        public void CargarGrid()
        {
            AsistenciaGridView.DataSource = (DataTable)ViewState["Asistencia"];
            AsistenciaGridView.DataBind();
        }
        private void Limpiar()
        {
            DataTable dt = new DataTable();

            CursoDropDownList.SelectedIndex = 0;
            GrupoDropDownList.SelectedIndex = 0;
            EstadoDropDownList.SelectedIndex = 0;
            EstudiantesDropDownList.SelectedIndex = 0;
            MatDropDownList.SelectedIndex = 0;
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Estudiante"), new DataColumn("Matricula"), new DataColumn("Estado") });
            ViewState["Asistencia"] = dt;
            CargarGrid();
        }
        private void CargarDropDs()
        {
            CursoDropDownList.DataSource = Utility.ListadoView("Cursos", "1=1", "");
            CursoDropDownList.DataTextField = "Descripcion"; 
            CursoDropDownList.DataValueField = "CursoId";
            CursoDropDownList.DataBind();
            
        }
        private void CargarEstudiantes(string CursoId) {
            EstudiantesDropDownList.DataSource = Estudiantes.ListadoDos("EstudianteId, Nombre", "CursoId='" + CursoId + "'And Grupo='" + GrupoDropDownList.Text + "'", "");
            EstudiantesDropDownList.DataTextField = "Nombre";
            EstudiantesDropDownList.DataValueField = "EstudianteId";
            EstudiantesDropDownList.DataBind();
           
        }
        private void CargarGrupos()
        {
            GrupoDropDownList.DataSource = Estudiantes.ListadoDos("EstudianteId, Grupo", "CursoId='" + CursoDropDownList.SelectedValue + "'", "CursoId");
            GrupoDropDownList.DataTextField = "Grupo";
            GrupoDropDownList.DataValueField = "EstudianteId";
            GrupoDropDownList.DataBind();
          

        }
        private void Cargarmatricula() {
            MatDropDownList.DataSource = Estudiantes.ListadoDos("EstudianteId,Matricula", "Nombre = '" + EstudiantesDropDownList.Text + "' and CursoId = '" + CursoDropDownList.SelectedValue +"'", "");
            MatDropDownList.DataTextField = "Matricula";
            MatDropDownList.DataValueField = "EstudianteId";
            MatDropDownList.DataBind();
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["Asistencia"];
                dt.Rows.Add(EstudiantesDropDownList.Text, MatDropDownList.Text, EstadoDropDownList.SelectedValue);
                CargarGrid();
                EstadoDropDownList.SelectedIndex = 0;

            }
            catch (Exception ex )
            {

                Response.Write(ex.Message);
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void CursoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrupos();
        }

        protected void GrupoDropDownList_TextChanged(object sender, EventArgs e)
        {
            CargarEstudiantes(GrupoDropDownList.SelectedValue);
        }

        protected void EstudiantesDropDownList_TextChanged(object sender, EventArgs e)
        {
            Cargarmatricula();
        }

    }
}