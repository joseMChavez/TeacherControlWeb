using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class Grupos : ClaseMaestra
    {

        public int GrupoId { get; set; }
        public int CursoId { get; set; }
        public int UsuarioId { get; set; }
        public string Descripcion { get; set; }
        public Grupos()
        {
            this.GrupoId = 0;
            this.CursoId = 0;
            this.UsuarioId = 0;
            this.Descripcion = "";
        }
       
        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("Insert Into Grupos(CursoId,Descripcion,UsuarioId) values({0},'{1}',{2})", this.CursoId, this.Descripcion,this.UsuarioId));

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

                retorno = conexion.Ejecutar(String.Format(" Update Grupos set CursoId ={0}, Descripcion = '{1}' where GrupoId = {2} and UsuarioId={3}", CursoId , this.Descripcion, this.GrupoId,this.UsuarioId));

            }
            catch (Exception exc)
            {
                throw exc;
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format(" delete from Grupos where GrupoId = {0}  and UsuarioId={1}", this.GrupoId,this.UsuarioId));
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
            DataTable datatable = new DataTable();
            try
            {
                datatable = conexion.ObtenerDatos(string.Format("select * from Grupos where GrupoId={0} and UsuarioId={1}", IdBuscado,this.UsuarioId));
                if (datatable.Rows.Count > 0)
                {
                    this.GrupoId = (int)datatable.Rows[0]["GrupoId"];
                    this.CursoId = (int)datatable.Rows[0]["CursoId"];
                    this.Descripcion = datatable.Rows[0]["Descripcion"].ToString();
                }

            }
            catch (Exception exc)
            {

                throw exc;
            }
            return datatable.Rows.Count > 0;
        }
        public bool BuscarDescripcion(string DescripcionBuscada)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable datatable = new DataTable();
            try
            {
                datatable = conexion.ObtenerDatos(string.Format("select * from Grupos where Descripcion='{0}'", DescripcionBuscada));
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return datatable.Rows.Count > 0;

        }
        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";
            if (!Orden.Equals(""))
                ordenFinal = " Order by  " + Orden;

            return conexion.ObtenerDatos("Select " + Campos + " From Grupos Where " + Condicion + ordenFinal);
        }
        public static DataTable ListadoDos(string Condicion, int usuario)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            string sCondicion = "";
            if (Condicion=="1=1")
            {
                dt= conexion.ObtenerDatos("Select * from Grupos_View Where Id=" +usuario);
            }
            else
            {
                sCondicion = " and " + Condicion;
                dt= conexion.ObtenerDatos("Select * from Grupos_View Where Id="+usuario + sCondicion);
            }
            return dt;
        }
    }
}
