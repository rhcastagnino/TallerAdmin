using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TraduccionBLL
    {
        private BE.Traduccion traduccion;
        private DAL.TraduccionDAL traduccionDAL;

        public TraduccionBLL()
        {
            traduccion = new BE.Traduccion();
            traduccionDAL = new DAL.TraduccionDAL();
        }

        public void AltaTraduccion(BE.Idioma idioma, BE.Traduccion traduccion)
        {
            traduccionDAL.AltaTraduccion(idioma, traduccion);
        }
    }
}
