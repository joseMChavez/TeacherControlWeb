﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BLL
{
    public class Estudiantes : ClaseMaestra
    {

        public int EstudianteId { get; set; }
        public int UsuarioId { get; set; }
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public int Genero { get; set; }
        public string FechaNacimiento { get; set; }
        public string Foto { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int Curso { get; set; }
        public string Grupo { get; set; }
        public string Fecha { get; set; }



        public Estudiantes()
        {
            this.EstudianteId = 0;
            this.Matricula = 0;
            this.Nombre = "";
            this.Foto = "";
            this.Genero = 0;
            this.UsuarioId = 0;
            this.FechaNacimiento = "";
            this.Celular = "";
            this.Email = "";
            this.Direccion = "";
            this.Curso = 0;
            this.Grupo = "";
            this.Fecha = "";


        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("insert into Estudiantes(Matricula,Nombre,Genero,FechaNacimiento,Celular,Email, Direccion,CursoId,Grupo,Fecha,Foto,UsuarioId) values({0},'{1}',{2},'{3}','{4}','{5}','{6}',{7},'{8}','{9}','{10}',{11})", this.Matricula, this.Nombre, this.Genero, this.FechaNacimiento, this.Celular, this.Email, this.Direccion, this.Curso, this.Grupo, this.Fecha, this.Foto, this.UsuarioId));

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
                retorno = conexion.Ejecutar(string.Format("update Estudiantes set Matricula= {0}, Nombre= '{1}', Genero= {2} , FechaNacimiento='{3}', Celular='{4}',Email='{5}',Direccion='{6}', CursoId={7}, Grupo='{8}', Fecha='{9}', Foto='{10}' where Estudiante= {11} and UsuarioId={12}", this.Matricula, this.Nombre, this.Genero, this.FechaNacimiento, this.Celular, this.Email, this.Direccion, this.Curso, this.Grupo, Fecha, this.Foto, this.EstudianteId, this.UsuarioId));
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
                retorno = conexion.Ejecutar(string.Format("delete from Estudiantes where Estudiante= {0} and UsuarioId={1}", this.EstudianteId, this.UsuarioId));

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
            //try
            //{
                dt = conexion.ObtenerDatos(string.Format("select * From Estudiantes where EstudianteId={0}", IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.EstudianteId = (int)dt.Rows[0]["EstudianteId"];
                    this.Matricula = (int)dt.Rows[0]["Matricula"];
                    this.Nombre = dt.Rows[0]["Nombre"].ToString();
                    this.Foto = dt.Rows[0]["Foto"].ToString();
                    this.Genero = (int)dt.Rows[0]["Genero"];
                    this.FechaNacimiento = dt.Rows[0]["FechaNacimiento"].ToString();
                    this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                    this.Celular = dt.Rows[0]["Celular"].ToString();
                    this.Email = dt.Rows[0]["Email"].ToString();
                    this.Direccion = dt.Rows[0]["Direccion"].ToString();
                    this.Curso = (int)dt.Rows[0]["CursoId"];
                    this.Grupo = dt.Rows[0]["Grupo"].ToString();
                    this.Fecha = dt.Rows[0]["Fecha"].ToString();


                }
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            return dt.Rows.Count > 0;
        }
        public static bool BuscarMatricula(int IdBuscado, int curso, string grupo)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            try
            {
                dt = conexion.ObtenerDatos(string.Format("select * From Estudiantes where Matricula={0} and CursoId={1} and Grupo='{2}'", IdBuscado, curso, grupo));

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
                ordenFinal = " Order by  " + Orden;

            return conexion.ObtenerDatos("Select " + Campos + " From Estudiantes Where " + Condicion + ordenFinal);
        }
        public static DataTable ListadoDos(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";
            if (!Orden.Equals(""))
                ordenFinal = " Order by  " + Orden;

            return conexion.ObtenerDatos("Select " + Campos + " From Estudiantes Where " + Condicion + ordenFinal);
        }
        public static DataTable ListadoEstudianteCurso(string Condicion, string Orden,int Usuario)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "",sCondicion="";
            DataTable dt = new DataTable();
            if (!Orden.Equals(""))
                ordenFinal = " Order BY  " + Orden;
            if (Condicion=="1=1")
            {
                dt= conexion.ObtenerDatos("Select * From EstudiantePorCursos Where Id=" +Usuario + ordenFinal);
            }
            else
            {
                sCondicion = " and " + Condicion;
                dt= conexion.ObtenerDatos("Select * From EstudiantePorCursos Where Id="+Usuario + sCondicion + ordenFinal);
            }
            return dt;
        }
        public static DataTable ListadoEstudiante(string Condicion, int Usuario)
        {
            ConexionDb conexion = new ConexionDb();
            string sCondicion = "";
            DataTable dt = new DataTable();
           
            if (Condicion == "1=1")
            {
                dt = conexion.ObtenerDatos("Select * From View_Estudiantes Where Id=" + Usuario );
            }
            else
            {
                sCondicion = " and " + Condicion;
                dt = conexion.ObtenerDatos("Select * From View_Estudiantes Where Id=" + Usuario + sCondicion );
            }
            return dt;
        }
    }
}
