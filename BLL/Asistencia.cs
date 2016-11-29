using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Asistencia : ClaseMaestra
    {

        public int AsistenciaId { get; set; }
        public int UsuarioId { get; set; }
        public int CursoId { get; set; }
        public string Estudiante { get; set; }
        public string CursoGrupo { get; set; }
        public int CantidadEst { get; set; }
        public string Activo { get; set; }
        public string Fecha { get; set; }
        public List<AsistenciaDetalle> aDetalle { get; set; }
     
        public Asistencia()
        {
            this.AsistenciaId = 0;
            this.CursoId = 0;
            this.UsuarioId = 0; 
            this.Estudiante = "";
            this.CursoGrupo = "";
            this.Activo = "";
            this.Fecha = "";
            aDetalle = new List<AsistenciaDetalle>();
        }
        public Asistencia(int Id, int CursoId, string EstudianteId, string CursoGrupo, string Activo, string Fecha)
        {
            this.AsistenciaId = Id;
            this.CursoId = CursoId;
            this.Estudiante = EstudianteId;
            this.CursoGrupo = CursoGrupo;
            this.Activo = Activo;
            this.Fecha = Fecha;
        }

        public void AgregarAsistencia(string estudiante, string Activo,int Matricula)
        {
            aDetalle.Add(new AsistenciaDetalle(estudiante, Activo,Matricula));
        }
        public void LimpiarLista() {
            aDetalle.Clear();
        }
        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
           
            int retorno = 0;
            try
            {
                retorno = Utility.ConvierteEntero(conexion.ObtenerValor(string.Format("Insert Into Asistencias(CursoId,Grupo,CantidaEst,Fecha,UsuarioId) values({0},'{1}',{2},'{3}',{4}); select SCOPE_IDENTITY()", this.CursoId, this.CursoGrupo, this.CantidadEst, this.Fecha,this.UsuarioId)).ToString());
                foreach (AsistenciaDetalle asistenciaD in aDetalle)
                {
                    conexion.Ejecutar(string.Format("Insert into AsistenciaDetalle(AsistenciaId,Estudiante,Matricula,Estado) Values({0},'{1}',{2},'{3}')", retorno, asistenciaD.EstudianteId, asistenciaD.Matricula,asistenciaD.Activo));
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
                retorno = conexion.Ejecutar(string.Format("update Asistencias set CursoId='{0}', Grupo='{1}',CantidaEst={2}, Fecha='{3}' where AsistenciaId={4} and UsuarioId={5}", this.CursoId, this.CursoGrupo, this.CantidadEst, this.Fecha, this.AsistenciaId,this.UsuarioId));
                if (retorno)
                {
                    conexion.Ejecutar(string.Format("Delete  from AsistenciaDetalle where AsistenciaId={0}", this.AsistenciaId));
                    foreach (AsistenciaDetalle asistenciaD in aDetalle)
                    {
                        conexion.Ejecutar(string.Format("Insert into AsistenciaDetalle(AsistenciaId,Estudiante,Matricula,Estado) Values({0},'{1}',{2},'{3}')", this.AsistenciaId, asistenciaD.EstudianteId, asistenciaD.Matricula, asistenciaD.Activo));
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
                retorno = conexion.Ejecutar(string.Format("Delete  from AsistenciaDetalle where AsistenciaId={0} and UsuarioId={1};" +
                                                 "Delete  from Asistencias where AsistenciaId={0}", this.AsistenciaId,this.UsuarioId));
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
            try
            {
                dt = conexion.ObtenerDatos(string.Format("Select * from Asistencias where AsistenciaId = {0}", IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    AsistenciaId = (int)dt.Rows[0]["AsistenciaId"];
                    CursoId = (int)dt.Rows[0]["CursoId"];
                    CursoGrupo = dt.Rows[0]["Grupo"].ToString();
                    CantidadEst = (int)dt.Rows[0]["CantidaEst"];
                    Fecha = dt.Rows[0]["Fecha"].ToString();
                    this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                    detalle = conexion.ObtenerDatos(string.Format("Select * from AsistenciaDetalle where AsistenciaId={0}",this.AsistenciaId));

                   
                    foreach (DataRow row in detalle.Rows)
                    {
                        AgregarAsistencia(row["Estudiante"].ToString(), row["Estado"].ToString(),(int)row["Matricula"]);
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
            return conexion.ObtenerDatos(string.Format("select  A.AsistenciaId as Id,A.CursoId, A.Grupo as Grupo,AD.Estudiante,AD.Matricula,AD.Activo as Estado,A.CantidaEst as Cantidad, A.Fecha from Asistencias as  A Inner join AsistenciaDetalle as AD ON A.AsistenciaId=AD.AsistenciaId where " + Condicion + ordenFinal));

        }
        public static DataTable ListadoAsistencia( string Condicion,int usuario)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            string sCondicion = "";
            if (Condicion == "1=1")
            {
                dt = conexion.ObtenerDatos(string.Format(" Select * from  AsistenciaPorEstudiante_View where Id=" + usuario));
            }
            else
            {
                sCondicion = " and " + Condicion;
                dt = conexion.ObtenerDatos(string.Format(" Select * from  AsistenciaPorEstudiante_View where Id=" + usuario + sCondicion));
            }
            return dt;

        }
        
    }
}
