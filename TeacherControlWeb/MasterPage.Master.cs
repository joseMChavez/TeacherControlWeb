using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cargar();
            }
        }
        private void Cargar()
        {
            DataTable dt = new DataTable();
            
            dt = Usuarios.ConocerTipoDeUsuario(this.Session["User"].ToString(), this.Session["Clave"].ToString());
            //Session["UsuarioId"] = new DataTable();
            //Session["User"] = new DataTable();
            //Session["Clave"] = new DataTable();
            user.Text = dt.Rows[0]["Nombres"].ToString();
            userM.Text = dt.Rows[0]["Nombres"].ToString();
            EmailLabel.Text = dt.Rows[0]["Email"].ToString();
            Image.ImageUrl = dt.Rows[0]["Imagen"].ToString();
            Session["UsuarioId"] = dt.Rows[0]["UsuarioId"].ToString();
            if (dt.Rows[0]["TipoUsuario"].ToString() == "Administrador")
            {
                ControlUsuariosMaestro(true);
                ControlUsuarioAdmin(true);
                ControlUsuarioAsistente(true);
            }
            else
            if (dt.Rows[0]["TipoUsuario"].ToString() == "Maestro")
            {
                ControlUsuariosMaestro(true);
                ControlUsuarioAdmin(false);
                ControlUsuarioAsistente(true);
            }
            else
            if (dt.Rows[0]["TipoUsuario"].ToString() == "Asistente")
            {
                ControlUsuariosMaestro(false);
                ControlUsuarioAdmin(false);
                ControlUsuarioAsistente(true);
            }
        }
        private void ControlUsuariosMaestro(Boolean ok)
        {
            CursoDe.Visible = ok;
            CursoM.Visible = ok;
            cEstPorCursos.Visible = ok;
            cCursosD.Visible = ok;
            cCusosM.Visible = ok;
            MateriasDe.Visible = ok;
            MateriasM.Visible = ok;
            cMateriaD.Visible = ok;
            cMateriasM.Visible = ok;
            CategoriaDe.Visible = ok;
            CategoriaM.Visible = ok;
            cCategoriaD.Visible = ok;
            cCategoriaM.Visible = ok;
            GrupoDe.Visible = ok;
            GrupoM.Visible = ok;
            cGruposD.Visible = ok;
            cGrupoM.Visible = ok;
            EstudianteDe.Visible = ok;
            EstudianteM.Visible = ok;
            AsistenciaDe.Visible = ok;
            AsistenciaM.Visible = ok;
            cAsistenciaD.Visible = ok;
            cAsistenciaM.Visible = ok;
            cAsistenciaD.Visible = ok;
            cEstudianteM.Visible = ok;
            CalificacionDe.Visible = ok;
            CalificacionesM.Visible = ok;
            cCalificacionesD.Visible = ok;
            cCalificacionM.Visible = ok;

        }
        private void ControlUsuarioAsistente(Boolean ok)
        {
            AsistenciaDe.Visible = ok;
            AsistenciaM.Visible = ok;
        }
        private void ControlUsuarioAdmin(Boolean ok)
        {
            UsuarioDe.Visible = ok;
            UsuriosDe.Visible = ok;
            cUsuarioD.Visible = ok;

        }
    }
}