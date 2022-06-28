using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Session
    {
        private static object _lock = new Object();
        private static Session _session;
        static IList<IIdiomaObserver> _observers = new List<IIdiomaObserver>();

        public BE.Usuario Usuario { get; set; }

        public static Session GetInstance
        {
            get
            {
                if (_session != null)
                {
                    return _session;
                }
                else
                {
                    return null;
                }

            }
        }

        public static void IniciarSession(BE.Usuario usuario, IIdioma idioma)
        {

            lock (_lock)
            {
                if (_session == null)
                {
                    _session = new Session();
                    _session.Usuario = usuario;
                    _session.Usuario.Idioma = idioma;
                }
                else
                {
                    throw new Exception("Sesión ya iniciada");
                }
            }
        }

        public static void CerrarSession()
        {
            lock (_lock)
            {
                if (_session != null)
                {
                    _session = null;
                    Notificar(Traductor.ObtenerIdiomaDefault());
                }
                else
                {
                    throw new Exception("Sesión no iniciada");
                }
            }
        }

        public static void SuscribirObservador(IIdiomaObserver o) // Para suscribirse a un idioma.
        {
            _observers.Add(o);
        }
        public static void DesuscribirObservador(IIdiomaObserver o) // Para desuscribirse de un idioma.
        {
            _observers.Remove(o);
        }
        private static void Notificar(IIdioma idioma) // Actualizo el idioma del usuario.
        {
            foreach (var o in _observers)
            {
                o.UpdateLanguage(idioma);
            }
        }
        public static void CambiarIdioma(IIdioma idioma) // Cambio de idioma.
        {
            Notificar(idioma);
            if ( _session != null)
            {
                _session.Usuario.Idioma = idioma;   
            }
        }

        private Session()
        {

        }
    }
}
