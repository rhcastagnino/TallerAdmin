using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IdiomaDAL
    {
        private Acceso acceso;
        private BE.Usuario usuario;

        public IdiomaDAL()
        {
            acceso = new Acceso();
            usuario = new BE.Usuario();
        }

        public void AltaIdioma(BE.Idioma idioma)
        {
            try
            {
                string sp = "altaIdioma"; 
                acceso.AltaIdioma(idioma, sp);
            }
            catch
            {
                throw new Exception($"Error en la base al dar de alta el Idioma");
            }
        }
    }
}
