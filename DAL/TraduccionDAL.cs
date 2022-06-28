using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TraduccionDAL
    {
        private Acceso acceso;
        private BE.Traduccion traduccion;

        public TraduccionDAL()
        {
            acceso = new Acceso();
            traduccion = new BE.Traduccion();
        }

        public void AltaTraduccion(BE.Idioma idioma,BE.Traduccion traduccion)
        {
            try
            {
                string sp = "altaTraduccion";
                acceso.AltaTraduccion(idioma,traduccion,sp);
            }
            catch
            {
                throw new Exception($"Error en la base al dar de alta la Traduccion");
            }
        }
    }
}
