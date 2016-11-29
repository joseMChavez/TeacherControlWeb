using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class Cursos : ClaseMaestra
    {

        public int CursoId { get; set; }
        public int UsuarioId { get; set; }
        public string Descripcion { get; set; }

        public Cursos(int Id, string DescripcionCategoria)
        {
            this.CursoId = Id;
            this.Descripcion = DescripcionCategoria;
        }

        public Cursos()
        {
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
                retorno = conexion.Ejecutar(string.Format("Insert Into Cursos(Descripcion,UsuarioId) values('{0}',{1})", this.Descripcion, this.UsuarioId));
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

                retorno = conexion.Ejecutar(String.Format(" Update Cursos set Descripcion = '{0}' where UsuarioId = {1} and CursoId={2} ", this.Descripcion, this.UsuarioId, this.CursoId));

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

                retorno = conexion.Ejecutar(String.Format(" delete from Cursos where CursoId = {0} and UsuarioId={1}", this.CursoId, this.UsuarioId));

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
                datatable = conexion.ObtenerDatos(string.Format("select * from Cursos where CursoId= {0}", IdBuscado));
                if (datatable.Rows.Count > 0)
                {
                    this.UsuarioId = (int)datatable.Rows[0]["UsuarioId"];
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
        public static bool BuscarDescripcion(string DescripcionBuscada)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable datatable = new DataTable();
            try
            {
                datatable = conexion.ObtenerDatos(string.Format("select * from Cursos where Descripcion= '" + DescripcionBuscada + "'"));
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

            return conexion.ObtenerDatos("Select " + Campos + " From Cursos Where " + Condicion + Orden);
        }
        public static DataTable ListadoDos(string Condicion,int Usuario)
        {
            ConexionDb conexion = new ConexionDb();
            string sCondicion = "";
            DataTable dt = new DataTable();

            if (Condicion == "1=1")
            {
                dt = conexion.ObtenerDatos("Select C.CursoId as Id, C.Descripcion From Cursos as C inner join Usuarios as U on C.UsuarioId=U.UsuarioId Where C.UsuarioId= " + Usuario);
            }
            else
            {
                sCondicion = " and " + Condicion;
                dt = conexion.ObtenerDatos("Select C.CursoId as Id, C.Descripcion From Cursos as C inner join Usuarios as U on C.UsuarioId=U.UsuarioId Where C.UsuarioId= " + Usuario + sCondicion);
            }
            return dt;

        }       }
}
