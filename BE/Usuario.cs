using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string password { get; set; }
        public int contador { get; set; }
        public string email { get; set; }

        private static Usuario _instance = null;
        private static object _protect = new object();

        private Usuario()
        {
        }

        public static Usuario GetInstance()
        {
            // Utilizo el lock para proteger el hilo de mi instancia.
            lock (_protect)
            {
                if (_instance == null)
                {
                    _instance = new Usuario();
                }
            }

            return _instance;
        }

    }
}
