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
                FechaTextBox.Text = DateTime.Today.ToString("dd/MM/yyyy");
                Asistencia asistencia = new Asistencia();
                int id = 0;
                if (Request.QueryString["ID"] != null)
                {
                    id = Utility.ConvierteEntero(Request.QueryString["ID"].ToString());
                    if (asistencia.Buscar(id))
                    {
                        if (AsistenciaGridView.Rows.Count == 0)
                        {
                            DevolverDatos(asistencia);
                            GrupoDropDownList.Focus();
                        }
                    }
                }
              
            }
        }
        public void CargarGrid()
        {
            AsistenciaGridView.DataSource = (DataTable)ViewState["Asistencia"];
            AsistenciaGridView.DataBind();
        }
        private void LlenarDatos(Asistencia asistencia)
        {
            asistencia.UsuarioId = Utility.ConvierteEntero(Session["UsuarioId"].ToString());
            asistencia.AsistenciaId = Utility.ConvierteEntero(IdTextBox.Text);
            asistencia.CursoId = Utility.ConvierteEntero(CursoDropDownList.SelectedValue);
            asistencia.CursoGrupo = GrupoDropDownList.SelectedValue;
            asistencia.Fecha = FechaTextBox.Text;
            asistencia.CantidadEst = Utility.ConvierteEntero(CantidadLabel.Text);
            foreach (GridViewRow item in AsistenciaGridView.Rows)
            {
                asistencia.AgregarAsistencia(item.Cells[0].Text, item.Cells[2].Text, Utility.ConvierteEntero(item.Cells[1].Text));
            }
        }
        private void DevolverDatos(Asistencia asistencia)
        {
            IdTextBox.Text = asistencia.AsistenciaId.ToString();
            CursoDropDownList.SelectedValue = asistencia.CursoId.ToString();
            GrupoDropDownList.SelectedValue = asistencia.CursoGrupo;
            FechaTextBox.Text = asistencia.Fecha;
            CantidadLabel.Text = asistencia.CantidadEst.ToString();
            foreach (var item in asistencia.aDetalle)
            {
                DataTable dt = (DataTable)ViewState["Asistencia"];
                dt.Rows.Add(item.EstudianteId, item.Matricula, item.Activo);
                ViewState["Asistencia"] = dt;
                AsistenciaGridView.DataSource = ViewState["Asistencia"];
                AsistenciaGridView.DataBind();
            }
        }
        private void Limpiar()
        {
            DataTable dt = new DataTable();
            EstudiantesDropDownList.Visible = false;
            MatDropDownList.Visible = false;
            EstadoDropDownList.Visible = false;
            AddButton.Visible = false;
            letraLabel.Visible = false;
            CantidadLabel.Visible = false;
            CantidadLabel.Text = "0";
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
        private void CargarEstudiantes() {
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
        private void Cargarmatricula() {
            MatDropDownList.DataSource = Estudiantes.ListadoDos("EstudianteId,Matricula", "Nombre = '" + EstudiantesDropDownList.SelectedValue + "'", "");
            MatDropDownList.DataTextField = "Matricula";
            MatDropDownList.DataValueField = "Matricula";
            MatDropDownList.DataBind();
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                int cantidad = AsistenciaGridView.Rows.Count+1;
                if (!string.IsNullOrWhiteSpace(MatDropDownList.Text))
                {
                    DataTable dt = (DataTable)ViewState["Asistencia"];
                    dt.Rows.Add(EstudiantesDropDownList.Text, MatDropDownList.Text, EstadoDropDownList.SelectedValue);
                    ViewState["Asistencia"] = dt;
                    CargarGrid();
                    EstadoDropDownList.SelectedIndex = 0;

                    CantidadLabel.Text = cantidad.ToString();
                }
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
        protected void EstudiantesDropDownList_TextChanged(object sender, EventArgs e)
        {
            Cargarmatricula();
        }

        protected void CargarButton_Click(object sender, EventArgs e)
        {
            EstudiantesDropDownList.Visible = true;
            MatDropDownList.Visible = true;
            EstadoDropDownList.Visible = true;
            AddButton.Visible = true;
            letraLabel.Visible = true;
            CantidadLabel.Visible = true;
            CargarEstudiantes();
            Cargarmatricula();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Asistencia asitencia = new Asistencia();
            LlenarDatos(asitencia);
            bool paso = false;
            try
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    paso = asitencia.Insertar();
                }
                else
                {
                    paso = asitencia.Editar();
                }

                if (paso)
                {
                    Utility.MensajeToastr(this.Page, "TC", "Exito", "success");
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                //throw ex;
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Asistencia asitencia = new Asistencia();
            bool paso = false;
            try
            {
                if (Request.QueryString["ID"]!=null)
                {
                    asitencia.AsistenciaId = Utility.ConvierteEntero(Request.QueryString["ID"].ToString());
                    paso = asitencia.Eliminar();
                }
                if (paso)
                {
                    Utility.MensajeToastr(this.Page, "TC", "Elimino", "success");
                    Limpiar();
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}