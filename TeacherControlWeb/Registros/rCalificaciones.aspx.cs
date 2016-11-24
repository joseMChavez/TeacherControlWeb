using System;
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
                int id = 0;
                Calificaciones cal = new Calificaciones();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Estudiante"), new DataColumn("Matricula"), new DataColumn("Descripcion"), new DataColumn("Calificacion") });
                ViewState["Calificacion"] = dt;
                FechaTextBox.Text = DateTime.Today.ToString("dd/MM/yyyy");
               
                if (Request.QueryString["ID"] != null)
                {
                    id = Utility.ConvierteEntero(Request.QueryString["ID"].ToString());
                    if (cal.Buscar(id))
                    {
                        if (CalificacionesGridView.Rows.Count == 0)
                        {
                            DevolverDatos(cal);
                            GrupoDropDownList.Focus();
                        }
                    }
                }
            }
        }
        private void Limpiar()
        {
            DataTable dt = new DataTable();
            IdTextBox.Text = string.Empty;
            PuntosTextBox.Text = string.Empty;
            EstudiantesDropDownList.Visible = false;
            MatDropDownList.Visible = false;
            DescripcionDropDownList.Visible = false;
            PuntosLabel.Visible = false;
            PuntosTextBox.Visible = false;
            AddButton.Visible = false;
            FechaTextBox.Text = DateTime.Today.ToString("dd/MM/yyyy");
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Estudiante"), new DataColumn("Matricula"), new DataColumn("Descripcion"), new DataColumn("Puntuacion") });
            ViewState["Calificacion"] = dt;
            CargarGrid();
            EstudiantesDropDownList.Focus();
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
            calificacion.UsuarioId = Utility.ConvierteEntero(Session["UsuarioId"].ToString());
            calificacion.CalificacionId = Utility.ConvierteEntero(IdTextBox.Text);
            calificacion.CursoId = Utility.ConvierteEntero(CursoDropDownList.SelectedValue);
            calificacion.Grupo = GrupoDropDownList.SelectedValue;
            calificacion.Fecha = FechaTextBox.Text;
            calificacion.MateriaId = Utility.ConvierteEntero(MateriaDropDownList.SelectedValue);
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
            FechaTextBox.Text = calificacion.Fecha;

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
            EstudiantesDropDownList.Visible = true;
            MatDropDownList.Visible = true;
            DescripcionDropDownList.Visible = true;
            PuntosLabel.Visible = true;
            PuntosTextBox.Visible = true;
            AddButton.Visible = true;
            CargarEstudiantes();
            Cargarmatricula();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(PuntosTextBox.Text))
                {
                    DataTable dt = (DataTable)ViewState["Calificacion"];
                    dt.Rows.Add(EstudiantesDropDownList.SelectedValue, MatDropDownList.SelectedValue,DescripcionDropDownList.SelectedValue, PuntosTextBox.Text);
                    ViewState["Calificacion"] = dt;
                    CargarGrid();
                    PuntosTextBox.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Calificaciones cal = new Calificaciones();
            bool paso = false;
            Llenardatos(cal);
            try
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text))
                    paso = cal.Insertar();
                else
                    paso = cal.Editar();

                if (paso) {
                    Utility.MensajeToastr(this.Page, "TC", "Exito", "Success");
                    Limpiar();
                }
         
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Calificaciones cal = new Calificaciones();
                if (Request.QueryString["ID"]!=null)
                {
                   cal.CalificacionId = Utility.ConvierteEntero(Request.QueryString["ID"].ToString());
                    if (cal.Eliminar())
                    {
                        Utility.MensajeToastr(this.Page, "TC", "Se Elimino", "Success");
                        Limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}