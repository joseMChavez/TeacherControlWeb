using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CalificacionesDetalle
    {
        public int CalificacionIdD { get; set; }
        public int CalificacionesId { get; set; }
        public string Estudiante { get; set; }
        public int Matricula { get; set; }
        public string Descripcion { get; set; }
        public float Puntuacion { get; set; }

        public CalificacionesDetalle()
        {
            this.CalificacionIdD = 0;
            this.CalificacionesId = 0;
            this.Estudiante = "";
            this.Matricula = 0;
            this.Descripcion = "";
            this.Puntuacion = 0;
        }
        public CalificacionesDetalle(string estudiante,int matricula,string Descripcion, float Puntuacion)
        {
            this.Estudiante = estudiante;
            this.Matricula = matricula;
            this.Descripcion = Descripcion;
            this.Puntuacion = Puntuacion;
        }
    }
}
