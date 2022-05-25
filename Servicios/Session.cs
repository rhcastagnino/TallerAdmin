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

        public BE.Usuario Usuario { get; set; }

        public static Session GetInstance
        {
            get
            {
                try
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
                catch (Exception ex)
                {
                    throw new Exception("Sesión no iniciada");
                }
            }
        }

        public static void IniciarSession(BE.Usuario usuario)
        {

            lock (_lock)
            {
                if (_session == null)
                {
                    _session = new Session();
                    _session.Usuario = usuario;
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
                }
                else
                {
                    throw new Exception("Sesión no iniciada");
                }
            }
        }

        private Session()
        {

        }
    }
}
