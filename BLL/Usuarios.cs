using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class Usuarios : ClaseMaestra
    {
       public int usuarioId { get; set; }
        public String Nombres{ get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Telefonos { get; set; }
        public string Clave { get; set; }
        public string ConfirmaClave { get; set; }
        public string TipoUsuario { get; set; }
        public string Imagen { get; set; }
        public string Fecha { get; set; }
        public Usuarios() {
            this.usuarioId = 0;
            this.UserName = "";
            this.Email = "";
            this.Telefonos = "";
            this.Clave = "";
            this.Imagen = "";
            this.TipoUsuario = "";
            this.Fecha = "";

        }
        public Usuarios(int id, string nombre, string pass) {
            this.usuarioId = id;
            this.Nombres = nombre;
            this.Clave = pass;
        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("insert into Usuarios(Nombres,UserName,Email,Telefono,Clave,ConfirmarClave,TipoUsuario,Imagen,Fecha) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", this.Nombres,this.UserName,this.Email, this.Telefonos,this.Clave,this.ConfirmaClave,this.TipoUsuario, this.Imagen,this.Fecha));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }
      
        public override bool Editar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("update Usuarios set Nombres= '{0}',UserName='{1}',Telefono='{2}',Email='{3}',clave='{4}', ConfirmarClave='{5}', TipoUsuario='{6}', Imagen='{7}', Fecha='{8}' where UsuarioId= {9}",this.Nombres,this.UserName, this.Telefonos ,this.Email, this.Clave, this.ConfirmaClave,this.TipoUsuario ,this.Imagen,Fecha,this.usuarioId));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }
       
        public override bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("delete from Usuarios where UsuarioId= {0} ", this.usuarioId));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }
        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();

            try
            {
                dt = conexion.ObtenerDatos(string.Format("select * from Usuarios where  usuarioId= {0}", IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.usuarioId = (int)dt.Rows[0]["UsuarioId"];
                    this.Nombres = dt.Rows[0]["Nombres"].ToString();
                    this.UserName = dt.Rows[0]["UserName"].ToString();
                    this.Telefonos = dt.Rows[0]["Telefono"].ToString();
                    this.Email = dt.Rows[0]["Email"].ToString();
                    this.Clave = dt.Rows[0]["clave"].ToString();
                    this.ConfirmaClave = dt.Rows[0]["ConfirmarClave"].ToString();
                    this.TipoUsuario = dt.Rows[0]["TipoUsuario"].ToString();
                    this.Imagen = dt.Rows[0]["Imagen"].ToString();
                    this.Fecha = dt.Rows[0]["Fecha"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt.Rows.Count > 0;

        }
        public bool BuscarNombre(string nombre)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();

            try
            {
                dt = conexion.ObtenerDatos(string.Format("select * from Usuarios where UserName= '{0}'", nombre));
                if (dt.Rows.Count>0)
                {
                    this.TipoUsuario = dt.Rows[0]["TipoUsuario"].ToString();
                    this.UserName = dt.Rows[0]["UserName"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt.Rows.Count > 0;

        }
        public static bool BuscarAdministrador(string nombre, string clave)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();

            try
            {
                dt = conexion.ObtenerDatos(string.Format("select * from Usuarios where UserName= '{0}' AND Clave='{1}' AND TipoUsuario='Administrador'", nombre, clave));
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt.Rows.Count > 0;

        }
        public static bool Acceder(string nombre, string clave)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();

            try
            {
                dt = conexion.ObtenerDatos(string.Format("select * from Usuarios where UserName= '{0}' AND Clave='{1}' ", nombre, clave));

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt.Rows.Count > 0;

        }
        public static DataTable ConocerTipoDeUsuario(string nombre, string clave)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();

            try
            {
                dt = conexion.ObtenerDatos(string.Format("select UsuarioId,TipoUsuario,Nombres,Email,Imagen from Usuarios where UserName= '{0}' AND Clave='{1}' ", nombre, clave));

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;

        }
        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";
            if (!Orden.Equals(""))
                ordenFinal = " order by  " + Orden;
            return conexion.ObtenerDatos(string.Format("select " + Campos + " from Usuarios where " + Condicion + ordenFinal));
        }
        public static DataTable ListadoDt(string Condicion)
        {
            ConexionDb conexion = new ConexionDb();
           
            return conexion.ObtenerDatos(string.Format("select * from Usuarios where " + Condicion));
        }
    }
}
