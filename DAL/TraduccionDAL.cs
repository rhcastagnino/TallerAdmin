using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TraduccionDAL : Acceso
    {
        //private Acceso acceso;
        private BE.Traduccion traduccion;

        public TraduccionDAL()
        {
            //acceso = new Acceso();
            traduccion = new BE.Traduccion();
        }

        public void AltaTraduccion(BE.Idioma idioma,BE.Traduccion traduccion)
        {
            try
            {
                string sp = "altaTraduccion";
                //acceso.AltaTraduccion(idioma,traduccion,sp);
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@idIdioma", idioma.Id);
                xParameters.Parameters.AddWithValue("@claveEtiqueta", traduccion.Etiqueta.Clave);
                xParameters.Parameters.AddWithValue("@valor", traduccion.Valor);
                StoredProcedureConsulta(sp);
            }
            catch
            {
                throw new Exception($"Error en la base al dar de alta la Traduccion");
            }
        }
    }
}
