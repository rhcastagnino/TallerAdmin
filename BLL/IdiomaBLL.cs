using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class IdiomaBLL
    {
        private BE.Idioma Idioma;
        private DAL.IdiomaDAL IdiomaDAL;

        public IdiomaBLL()
        {
            Idioma = new BE.Idioma();
            IdiomaDAL = new DAL.IdiomaDAL();
        }

        public void AltaIdioma(BE.Idioma idioma)
        {
            try
            {
                IdiomaDAL.AltaIdioma(idioma);
            }
            catch
            {
                throw new Exception($"Error en el Alta de Idioma {idioma.Nombre}");
            }
        }

    }
}
