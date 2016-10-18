using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // NombresTextBox.Text = CargarArchivoBTN.PostedFile.ToString();
        }
        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            NombresTextBox.Text = string.Empty;
            UserTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            ClaveTextBox.Text = string.Empty;
            ConfirmarTextBox.Text = string.Empty;
            TipoDropDownList.SelectedIndex = 0;
            Imagen.ImageUrl = "/img/images.png";
        }
        private void Llenardatos(Usuarios user)
        {
           int id= Utility.ConvierteEntero(IdTextBox.Text);
            user.usuarioId = id;
            user.Nombres = NombresTextBox.Text;
            user.Email = EmailTextBox.Text;
            user.Telefonos = TelefonoTextBox.Text;
            user.UserName = UserTextBox.Text;
            user.Clave = ClaveTextBox.Text;
            user.ConfirmaClave = ConfirmarTextBox.Text;
            user.TipoUsuario = TipoDropDownList.SelectedValue;
            user.Imagen = CargarArchivoBTN.FileBytes;

        }
        private void DevolverDatos(Usuarios user)
        {
            IdTextBox.Text = user.usuarioId.ToString();
            NombresTextBox.Text = user.Nombres;
            UserTextBox.Text = user.UserName;
            EmailTextBox.Text = user.Email;
            TelefonoTextBox.Text = user.Telefonos;
            ClaveTextBox.Text = user.Clave;
            ConfirmarTextBox.Text = user.ConfirmaClave;
            TipoDropDownList.Text = user.TipoUsuario;
           // Imagen.ImageUrl=ResolveUrl(user.Imagen.ToString());
        }
        private bool Validar()
        {
            if (!String.IsNullOrWhiteSpace(NombresTextBox.Text) && !string.IsNullOrWhiteSpace(UserTextBox.Text) && !string.IsNullOrWhiteSpace(EmailTextBox.Text) && !string.IsNullOrWhiteSpace(TelefonoTextBox.Text) && !string.IsNullOrWhiteSpace(ClaveTextBox.Text) && !string.IsNullOrWhiteSpace(ConfirmarTextBox.Text) && ConfirmarTextBox.Text.Equals(ClaveTextBox.Text) && CargarArchivoBTN.HasFile)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            try
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (Validar())
                    {
                        Llenardatos(user);
                        if (user.Insertar())
                        {
                            Response.Write("<script>alert('Guardo!')</script>");
                            Limpiar();
                            NombresTextBox.Focus();
                        }
                        else
                        {
                            Response.Write("<script>alert('NO Guardo!')</script>");
                        }
                }
            }
                else
                {
                    if (Validar())
                    {
                        Llenardatos(user);
                        if (user.Editar())
                        {
                            Response.Write("<script>alert('Modifico!')</script>");
                            Limpiar();
                            NombresTextBox.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            try
            {
                if (!string.IsNullOrWhiteSpace(IdTextBox.Text) && Validar())
                {
                    if (user.Eliminar())
                    {
                        Limpiar();
                        Response.Write("<script>alert('Eliminado!')</script>");
                        NombresTextBox.Focus();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            int id = Utility.ConvierteEntero(IdTextBox.Text);
            try
            {
                if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                {

                    if (user.Buscar(id))
                    {
                        DevolverDatos(user);
                        NombresTextBox.Focus();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}