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
            return ConfirmarTextBox.Text.Equals(ClaveTextBox.Text);
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            bool exito = false, paso = false;
            try
            {
                if (Utility.BuscarDuplicado("Usuarios", "UserName", UserTextBox.Text))
                {
                    Utility.MensajeToastr(this.Page, "Ya Existe un usuario con este Nombre!", "TC", "info");
                    UserTextBox.Text = string.Empty;
                    UserTextBox.Focus();
                }
                else { paso = true; }
                Llenardatos(user);
                if (Validar())
                {
                    if (string.IsNullOrWhiteSpace(IdTextBox.Text) && paso)
                    {
                        exito = user.Insertar();
                    }
                    else
                    {
                        if (paso)
                        {
                            exito = user.Editar();
                        }
                    }
                }
                else
                {
                    Utility.MensajeToastr(this.Page, "Debe de confirmar la contraseña!", "TC", "info");
                    ConfirmarTextBox.Text = string.Empty;
                    ConfirmarTextBox.Focus();
                }
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
            Usuarios user = new Usuarios();
            try
            {
                if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    user.usuarioId = Utility.ConvierteEntero(IdTextBox.Text);
                    if (user.Eliminar())
                    {
                        Utility.MensajeToastr(this.Page, "Se Elimino con exito", "Exito", "success");
                        NombresTextBox.Focus();
                        Limpiar();
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