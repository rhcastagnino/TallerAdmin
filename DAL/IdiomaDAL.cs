using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IdiomaDAL : Acceso
    {

        public void AltaIdioma(BE.Idioma idioma)
        {
            try
            {
                string sp = "altaIdioma";
                //acceso.AltaIdioma(idioma, sp);
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@nombre", idioma.Nombre);
                StoredProcedureConsulta(sp);
            }
            catch
            {
                throw new Exception($"Error en la base al dar de alta el Idioma");
            }
        }
    }
}
