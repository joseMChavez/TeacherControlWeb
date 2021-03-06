﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Materias : ClaseMaestra
    {

        public int MateriaId { get; set; }
        public int UsuarioId { get; set; }
        public string Descripcion { get; set; }
        public Materias()
        {
            this.MateriaId = 0;
            this.UsuarioId = 0;
            this.Descripcion = "";
        }
        public Materias(int MateriaId, string Descripcion)
        {
            this.MateriaId = this.MateriaId;
            this.Descripcion = Descripcion;
        }
        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("Insert Into Materias(Descripcion,UsuarioId) values('{0}',{1})", this.Descripcion, UsuarioId));

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

                retorno = conexion.Ejecutar(String.Format(" Update Materias set Descripcion = '{0}' where MateriaId = {1} and UsuarioId={2}", this.Descripcion, this.MateriaId, this.UsuarioId));

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

                retorno = conexion.Ejecutar(String.Format(" delete from Materias where MateriaId = {0} and UsuarioId={1} ", this.MateriaId, this.UsuarioId));

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
                datatable = conexion.ObtenerDatos(string.Format("select * from Materias where MateriaId=" + IdBuscado ));
                if (datatable.Rows.Count > 0)
                {
                    this.UsuarioId = (int)datatable.Rows[0]["UsuarioId"];
                    this.MateriaId = (int)datatable.Rows[0]["MateriaId"];
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
                datatable = conexion.ObtenerDatos(string.Format("select * from Materias where Descripcion='{0}' and UsuarioId={1}", DescripcionBuscada, UsuarioId));
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

            return conexion.ObtenerDatos("Select " + Campos + " From Materias Where " + Condicion + ordenFinal);
        }
        public static DataTable ListadoMat(string Condicion, int Usurio)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            string scondicion = "";
            if (Condicion == "1=1")
            {
                dt = conexion.ObtenerDatos(string.Format("Select MateriaId, Descripcion as Materia From Materias where UsuarioId=" + Usurio));
            }
            else
            {
                scondicion = " and " + Condicion;
                dt = conexion.ObtenerDatos(string.Format("Select MateriaId, Descripcion as Materia From Materias where UsuarioId=" + Usurio + scondicion));
            }
            return dt;
        }
    }
}
