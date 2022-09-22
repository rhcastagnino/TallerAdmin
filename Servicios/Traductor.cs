using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Data;
using DAL;
using BE;

namespace Servicios
{
    public class Traductor
    {
        public static IIdioma ObtenerIdiomaDefault()
        {
            return ObtenerIdiomas().Where(i => i.Default).FirstOrDefault();
        }

        public static IList<IIdioma> ObtenerIdiomas() 
        {
            Acceso acceso = new Acceso();
            IList<IIdioma> _idiomas = new List<IIdioma>();
            DataTable dt = new DataTable();
            string Consulta = "select * from Idioma";
            dt = acceso.Leer(Consulta);

            foreach (DataRow fila in dt.Rows)
            {
                _idiomas.Add(
                   new Idioma()
                   {
                       Id = int.Parse(fila[0].ToString()),
                       Nombre = fila[1].ToString(),
                       Default = bool.Parse(fila[2].ToString())
                   });
            }
            return _idiomas;
        }

        public static IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma idioma)
        {
            //si no hay idioma definido, traigo el idioma por default (que es el español)
            if (idioma == null)
            {
                idioma = ObtenerIdiomaDefault();
            }
            Acceso acceso = new Acceso();
            DataTable dt = new DataTable();
            
            IDictionary<string, ITraduccion> _traducciones = new Dictionary<string, ITraduccion>(); // Traigo las traducciones del idioma seleccionado.
            try
            {
                //Obtengo las traducciones del idioma que tengo seleccionado
                string Consulta = "SELECT t.fk_idioma, t.valor as traduccion_traduccion, e.id, e.clave as nombre_etiqueta FROM Traducciones t" +
                                    " INNER JOIN Etiqueta e on t.fk_etiqueta = e.id WHERE t.fk_idioma = " + idioma.Id;
                dt = acceso.Leer(Consulta);

                foreach (DataRow fila in dt.Rows)
                {
                    var etiqueta = fila[3].ToString();
                    _traducciones.Add(etiqueta,
                     new Traduccion()
                     {
                         Valor = fila[1].ToString(),
                         Etiqueta = new Etiqueta()
                         {
                             Id = int.Parse(fila[2].ToString()),
                             Clave = etiqueta
                         }
                     });
                }
                return _traducciones;
            }
            catch (Exception ex)
            {
                throw new Exception("Error contra la base de datos de Traducciones");
            }
        }

        public static IList<IEtiqueta> ObtenerEtiquetas()
        {
            IList<IEtiqueta> _etiqueta = new List<IEtiqueta>();

            Acceso acceso = new Acceso();
            DataTable dt = new DataTable();
            string Consulta = "select * from Etiqueta";
            dt = acceso.Leer(Consulta);

            foreach (DataRow fila in dt.Rows)
            {
                _etiqueta.Add(
                new Etiqueta()
                {
                    Id = int.Parse(fila[0].ToString()),
                    Clave = fila[1].ToString()
                });
            }
            return _etiqueta;
        }

        public static List<TraduccionDTO> ObtenerReferenciasDTO(IIdioma idioma)
        {
            List<TraduccionDTO> _traduccion = new List<TraduccionDTO>();
            Acceso acceso = new Acceso();
            DataTable dt = new DataTable();
            string Consulta = "select e.clave, t.valor from Etiqueta e join Traducciones t on e.id = t.fk_etiqueta where t.fk_idioma = " + idioma.Id;
            dt = acceso.Leer(Consulta);

            foreach (DataRow fila in dt.Rows)
            {
                _traduccion.Add(
                new TraduccionDTO()
                {
                    Valor = fila[1].ToString(),
                    Clave = fila[0].ToString()
                });
            }
            return _traduccion;
        }
    }
}
