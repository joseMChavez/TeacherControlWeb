﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TeacherControlWeb
{
    public partial class rEstudiantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 0;
                Estudiantes estudiante = new Estudiantes();
                CargarDropD();
                FechaLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
                if (Request.QueryString["ID"] != null)
                {
                    id = Utility.ConvierteEntero(Request.QueryString["Id"].ToString());
                    if (id > 0) {
                        if (estudiante.Buscar(id))
                        {
                            DevolverDatos(estudiante);
                            MatriculaTextBox.Focus();
                        }
                    }  
                }
            }
        }
        private void CargarDropD()
        {
            Cursos curso = new Cursos();
            Grupos grupo = new Grupos();
            CursosDropDownList.DataSource = curso.Listado("*", "1=1", "");
            CursosDropDownList.DataTextField = "Descripcion";
            CursosDropDownList.DataValueField = "CursoId";
            CursosDropDownList.DataBind();

            GruposDropDownList.DataSource = grupo.Listado("*", "1=1", "");
            GruposDropDownList.DataTextField = "Descripcion";
            GruposDropDownList.DataValueField = "Descripcion";
            GruposDropDownList.DataBind();

        }
        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            NombresTextBox.Text = string.Empty;
            MatriculaTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            FNacTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FmRadioButton.Checked = false;
            McRadioButton.Checked = false;
            EmailTextBox.Text = string.Empty;
            CursosDropDownList.SelectedIndex = 0;
            GruposDropDownList.SelectedIndex = 0;
            Imagen.ImageUrl = "/img/images.png";
            MatriculaTextBox.Focus();

        }
        private void LLenarDatos(Estudiantes estudiante)
        {
            estudiante.EstudianteId = Utility.ConvierteEntero(IdTextBox.Text);
            estudiante.Matricula = Utility.ConvierteEntero(MatriculaTextBox.Text);
            estudiante.Nombre = NombresTextBox.Text;
            estudiante.Celular = TelefonoTextBox.Text;
            estudiante.Email = EmailTextBox.Text;
            estudiante.Direccion = DireccionTextBox.Text;
            if (McRadioButton.Checked)
            {
                estudiante.Genero = 1;
            }
            else
            {
                estudiante.Genero = 0;
            }
         
            estudiante.FechaNacimiento = FNacTextBox.Text;
            estudiante.Fecha = FechaLabel.Text;
            estudiante.Curso = Utility.ConvierteEntero(CursosDropDownList.SelectedValue);
            estudiante.Grupo = GruposDropDownList.Text;
            estudiante.Foto = Imagen.ImageUrl;
        }
        private void DevolverDatos(Estudiantes estudiante)
        {
            IdTextBox.Text = estudiante.EstudianteId.ToString();
            NombresTextBox.Text = estudiante.Nombre;
            MatriculaTextBox.Text = estudiante.Matricula.ToString();
            TelefonoTextBox.Text = estudiante.Celular;
            EmailTextBox.Text = estudiante.Email;
            DireccionTextBox.Text = estudiante.Direccion;
            FNacTextBox.Text = estudiante.FechaNacimiento;
            CursosDropDownList.SelectedValue = estudiante.Curso.ToString();
            GruposDropDownList.Text = estudiante.Grupo;
            Imagen.ImageUrl = estudiante.Foto;
            if (estudiante.Genero == 1)
                McRadioButton.Checked = true;
            else
                FmRadioButton.Checked = true;
        }
        private bool Validar()
        {
            return !string.IsNullOrWhiteSpace(MatriculaTextBox.Text) && !string.IsNullOrWhiteSpace(NombresTextBox.Text) && !string.IsNullOrWhiteSpace(TelefonoTextBox.Text) && !string.IsNullOrWhiteSpace(EmailTextBox.Text) && !string.IsNullOrWhiteSpace(DireccionTextBox.Text) && !string.IsNullOrWhiteSpace(FNacTextBox.Text) && (McRadioButton.Checked || FmRadioButton.Checked);
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Estudiantes estudiante = new Estudiantes();
            try
            {
                LLenarDatos(estudiante);
                bool exito = false;
               
                if (IdTextBox.Text.Equals(""))
                {
                    exito = estudiante.Insertar();
                }
                else { exito = estudiante.Editar(); }


                if (exito)
                {
                    Utility.MensajeToastr(this.Page, "Exito!", "TC", "Success");
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                Utility.MensajeToastr(this.Page, "Comunicase con el administrador \n" + ex.Message + "", "Error", "Warning");
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Estudiantes estudiante = new Estudiantes();
            try
            {
                if (Request.QueryString["ID"]!= null)
                {
                    estudiante.EstudianteId = Utility.ConvierteEntero(Request.QueryString["ID"].ToString());
                    if (estudiante.Eliminar())
                    {
                        Utility.MensajeToastr(this.Page, "Se Elimino Correctamente!", "TC", "Success");
                        Limpiar();
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
            Estudiantes est = new Estudiantes();
            est.Foto = "/img/" + CargarArchivoBTN.FileName;
            CargarArchivoBTN.SaveAs(Server.MapPath("/img/" + CargarArchivoBTN.FileName));
            if (CargarArchivoBTN.HasFile)
            {
                Imagen.ImageUrl = "/img/" + CargarArchivoBTN.FileName;
            }
        }
    }
}