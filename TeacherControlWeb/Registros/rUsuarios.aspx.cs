using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Permissions;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // Session["usiario"] = null;
            if (!IsPostBack)
            {
                FechaLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
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
            int id = Utility.ConvierteEntero(IdTextBox.Text);
            user.usuarioId = id;
            user.Nombres = NombresTextBox.Text;
            user.Email = EmailTextBox.Text;
            user.Telefonos = TelefonoTextBox.Text;
            user.UserName = UserTextBox.Text;
            user.Clave = ClaveTextBox.Text;
            user.ConfirmaClave = ConfirmarTextBox.Text;
            user.TipoUsuario = TipoDropDownList.SelectedValue;
            user.Imagen = Imagen.ImageUrl;// le agrega la ruta de la imagen a la BLL
                                          // Response.Write("<script>alert('"+user.Imagen+"')</script>");

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
            Imagen.ImageUrl = user.Imagen;
        }
        private bool Validar()
        {
            if (!String.IsNullOrWhiteSpace(NombresTextBox.Text) && !string.IsNullOrWhiteSpace(UserTextBox.Text) && !string.IsNullOrWhiteSpace(EmailTextBox.Text) && !string.IsNullOrWhiteSpace(TelefonoTextBox.Text) && !string.IsNullOrWhiteSpace(ClaveTextBox.Text) && !string.IsNullOrWhiteSpace(ConfirmarTextBox.Text) && ConfirmarTextBox.Text.Equals(ClaveTextBox.Text))
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
                            Utility.MensajeToastr(this.Page, "Se Guardo con exito", "Exito", "success");
                           
                            Limpiar();
                            NombresTextBox.Focus();
                        }
                        else
                        {
                            Utility.MensajeToastr(this.Page, "No Se Guardo", "Exito", "Error");
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
                            Utility.MensajeToastr(this.Page, "Se Modifico con exito", "Error", "success");
                            Limpiar();
                            NombresTextBox.Focus();
                        }
                        else
                        {
                            Utility.MensajeToastr(this.Page, "No se Modifico", "Error", "Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Utility.MensajeToastr(this.Page, "Comunicase con el administrador \n" + ex.Message + "", "Error", "Warning");
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            try
            {
                if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (user.Eliminar())
                    {

                        Limpiar();
                        Utility.MensajeToastr(this.Page, "Se Elimino con exito", "Exito", "success");
                        NombresTextBox.Focus();
                    }
                    else
                    {
                        Utility.MensajeToastr(this.Page, "No se Elimino", "Error", "Error");
                    }
                }
            }
            catch (Exception ex)
            {

                Utility.MensajeToastr(this.Page, "Comunicase con el administrador \n" + ex.Message + "", "Error", "Warning");
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

                Utility.MensajeToastr(this.Page, "Comunicase con el administrador \n" + ex.Message + "", "Error", "Warning");
            }
        }

        protected void CargarImgButton_Click(object sender, EventArgs e)
        {

            Usuarios user = new Usuarios();
            user.Imagen = "/img/" + CargarArchivoBTN.FileName;
            CargarArchivoBTN.SaveAs(Server.MapPath("/img/" + CargarArchivoBTN.FileName));
            if (CargarArchivoBTN.HasFile)
            {

                Imagen.ImageUrl = "/img/" + CargarArchivoBTN.FileName;
            }
        }
    }
}