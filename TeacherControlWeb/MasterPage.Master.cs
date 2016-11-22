using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
                user.Text = this.Session["User"].ToString();
                userM.Text = this.Session["User"].ToString();

                if (Usuarios.BuscarAdministrador(this.Session["User"].ToString(), this.Session["Clave"].ToString()))
                {
                    ControlUsuariosUno(true);
                    ControlUsuarioDos(true);
                }
                else
                {
                    ControlUsuariosUno(true);
                    ControlUsuarioDos(false);
                }



            }
        }

        private void ControlUsuariosUno(Boolean ok)
        {
            CursoDe.Visible = ok;
            CursoM.Visible = ok;
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
            AsistenciaDe.Visible = ok;
            AsistenciaM.Visible = ok;
            cAsistenciaD.Visible = ok;
            cAsistenciaM.Visible = ok;

        }

        private void ControlUsuarioDos(Boolean ok)
        {
            EstudianteDe.Visible = ok;
            EstudianteM.Visible = ok;
            cAsistenciaD.Visible = ok;
            cEstudianteM.Visible = ok;
            CalificacionDe.Visible = ok;
            CalificacionesM.Visible = ok;
            cCalificacionesD.Visible = ok;
            cCalificacionM.Visible = ok;
            UsuarioDe.Visible = ok;
            UsuriosDe.Visible = ok;
            cUsuarioD.Visible = ok;

        }
    }
}