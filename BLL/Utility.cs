using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;


namespace BLL
{
    public static class Utility
    {

        // Regex esta función permite mediante un patrón verificar si una cadena cumple con ese patrón 
        public static bool ComprobarFormatoEmail(string sEmailAComprobar)
        {
            if (!Regex.Match(sEmailAComprobar, @"\A(\w+\.?\w*\@\w+.)(com)\z").Success)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //Este metodo es para Validar los Textbox
        //1 Informacion...2 Error....3 Cuidado.

        public static int ConvierteEntero(string s)
        {
            int id = 0;
            int.TryParse(s, out id);
            return id;
        }
        public static float ConvierteFloat(string s)
        {
            float id = 0;
            float.TryParse(s, out id);
            return id;
        }
        // Estos metodos reciven un evento cuando se presiona una tecla en el textbox para Validarlos
    }
}
