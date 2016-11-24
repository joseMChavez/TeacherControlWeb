using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb.Registros
{
    public partial class rMaterias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //aqui va codigo de boton buscar.
            Materias materia = new Materias();
            int id = 0;

            if (!IsPostBack)
            {
                Cursos2GridView.DataSource = materia.Listado("*", "1=1", "");
                Cursos2GridView.DataBind();
                if (Request.QueryString["ID"] != null)
                {
                    id = Utility.ConvierteEntero(Request.QueryString["ID"].ToString());
                    if (materia.Buscar(id))
                    {
                        Devolverdatos(materia);
                        DescripcionTextBox.Focus();
                    }
                }
            }
        }
        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            Request.QueryString["ID"] = null;
            DescripcionTextBox.Focus();
        }
        private void LlenarDatos(Materias materia)
        {
            materia.MateriaId = Utility.ConvierteEntero(IdTextBox.Text);
            materia.UsuarioId = Utility.ConvierteEntero(Session["UsuarioId"].ToString());
            materia.Descripcion = DescripcionTextBox.Text;

        }
        private void Devolverdatos(Materias materia)
        {
            Session["UsuarioId"] = materia.MateriaId.ToString();
            IdTextBox.Text = materia.MateriaId.ToString();
            DescripcionTextBox.Text = materia.Descripcion;
        }
        private bool Validad(Materias materia)
        {
                return !string.IsNullOrWhiteSpace(DescripcionTextBox.Text) && materia.BuscarDescripcion(DescripcionTextBox.Text).Equals(false);
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Materias materia = new Materias();
            bool exito = false;
            LlenarDatos(materia);
            try
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text))
                    exito = materia.Insertar();
                else
                    exito = materia.Editar();
         
                if (exito)
                {
                    Utility.MensajeToastr(this.Page, "Exito!", "TC", "Success");
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                Utility.MensajeToastr(this.Page, "Comunicase con el administrador \n" + ex.Message + "", "Error", "Warning");
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Materias materia = new Materias();
                if (Request.QueryString["ID"] != null)
                {
                    materia.MateriaId= Utility.ConvierteEntero(IdTextBox.Text);

                    if (materia.Eliminar())
                    {
                        Limpiar();
                        Utility.MensajeToastr(this.Page, "Se Elimino Correctamente!", "TC", "Success");

                    }
                }
            }
            catch (Exception ex)
            {
                Utility.MensajeToastr(this.Page, "" + ex.Message + "", "TC");

            }
        }
    }

}