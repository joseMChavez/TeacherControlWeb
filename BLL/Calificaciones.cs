using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Calificaciones : ClaseMaestra
    {

        public int CalificacionId { get; set; }
        public int MateriaId { get; set; }
        public int UsuarioId { get; set; }
        public int CursoId { get; set; }
        public string Grupo { get; set; }
        public string Fecha { get; set; }

        public List<CalificacionesDetalle> DetalleC { get; set; }
        public Calificaciones()
        {
            this.CalificacionId = 0;
            this.MateriaId = 0;
            this.CursoId = 0;
            this.UsuarioId = 0;
            this.Grupo = "";
            this.Fecha = "";
            this.DetalleC = new List<CalificacionesDetalle>();
        }


        public void AgregarCalificaiones(string estudiante, int matricula, string Descripcion, float Puntos)
        {
            DetalleC.Add(new CalificacionesDetalle(estudiante, matricula, Descripcion, Puntos));
        }
        public void LimpiarLista()
        {
            DetalleC.Clear();
        }
        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            int retorno = 0;
            object identity;
            try
            {
                identity = conexion.ObtenerValor(string.Format("Insert into Calificaciones(CursoId,Grupo,MateriaId,Fecha,UsuarioId) values({0},'{1}',{2},'{3}',{4}); select SCOPE_IDENTITY()", this.CursoId, this.Grupo, this.MateriaId, this.Fecha, UsuarioId));
                retorno = Utility.ConvierteEntero(identity.ToString());
                //this.CalificacionId = retorno;

                foreach (CalificacionesDetalle detalle in DetalleC)
                {
                    conexion.Ejecutar(string.Format("Insert into CalificacionDetalle(CalificacionId,Estudiante,Matricula,Descripcion,Puntuacion) Values({0},'{1}',{2},'{3}',{4})", retorno, detalle.Estudiante, detalle.Matricula, detalle.Descripcion, detalle.Puntuacion));
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno > 0;
        }
        public override bool Editar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("update Calificaciones set CursoId={0}, Grupo='{1}', MateriaId={2}, Fecha='{3}' where CalificacionId={4} and UsuarioId={5}", this.MateriaId, this.CursoId, this.Grupo, this.Fecha, this.CalificacionId));
                if (retorno)
                {
                    conexion.Ejecutar(string.Format("Delete  from CalificacionDetalle where CalificacionId={0}", this.CalificacionId));
                    foreach (CalificacionesDetalle detalle in DetalleC)
                    {
                        conexion.Ejecutar(string.Format("Insert into CalificacionDetalle(CalificacionId,Estudiante,Matricula,Descripcion,Puntuacion) Values({0},'{1}',{2},'{3}',{4})", retorno, detalle.Estudiante, detalle.Matricula, detalle.Descripcion, detalle.Puntuacion));
                    }

                }
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
                retorno = conexion.Ejecutar(string.Format("Delete  from CalificacionDetalle where CalificacionId={0};" +
                                                 "Delete  from Calificaciones where CalificacionId={0} and UsuarioId={1}", this.CalificacionId, UsuarioId));
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
            DataTable detalle = new DataTable();
            //El estudiante y la matricula seran parte del detalle
            CalificacionesDetalle calificaionDetalle = new CalificacionesDetalle();
            try
            {
                dt = conexion.ObtenerDatos(string.Format("select * from Calificaciones where CalificacionId={0}", IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                    CursoId = (int)dt.Rows[0]["CursoId"];
                    Grupo = dt.Rows[0]["Grupo"].ToString();
                    MateriaId = (int)dt.Rows[0]["MateriaId"];
                    Fecha = dt.Rows[0]["Fecha"].ToString();
                    detalle = conexion.ObtenerDatos(string.Format("select * from CalificacionDetalle where CalificacionId={0}", this.CalificacionId));
                    detalle.Clear();
                    foreach (DataRow row in detalle.Rows)
                    {

                        AgregarCalificaiones(row["Estudiante"].ToString(), (int)row["Matricula"], row["Descripcion"].ToString(), (float)Convert.ToDecimal(row["Puntuacion"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";
            if (!Orden.Equals(""))
            {
                ordenFinal = "order by " + Orden;
            }
            return conexion.ObtenerDatos(string.Format("select C.CalificacionId as Id,C.Estudiante,C.Matricula,C.MateriaId,CD.Descripcion Categoria,CD.Puntuacion,C.CursoId,C.Cursogrupo as Grupo,C.TotalPuntos as Puntos,C.Fecha from Calificaciones as C inner join CalificacionDetalle as CD on C.CalificacionId=CD.CalificacionId  where " + Condicion + ordenFinal));

        }
        public static DataTable ListadoVista(string Condicion,int usuario)
        {
            
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            string sCondicion = "";
            if (Condicion == "1=1")
            {
                dt = conexion.ObtenerDatos(string.Format(" Select * from  Calificaciones_view where Id=" + usuario));
            }
            else
            {
                sCondicion = " and " + Condicion;
                dt = conexion.ObtenerDatos(string.Format(" Select * from  Calificaciones_view where Id=" + usuario + sCondicion));
            }
            return dt;
     
        }
        public static DataTable Promedio(string Condicion,int usuario)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            string sCondicion = "";
            if (Condicion=="1=1")
            {
                dt = conexion.ObtenerDatos(string.Format(" Select * from  CalificacionesPromedioView where Id=" + usuario));
            }
            else
            {
                sCondicion = " and " + Condicion;
                dt= conexion.ObtenerDatos(string.Format(" Select * from  CalificacionesPromedioView where Id="+usuario+ sCondicion));
            }
            return dt;
        }
       
    }
}
