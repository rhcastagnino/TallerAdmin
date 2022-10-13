using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Criticidad { get; set; }
        public DateTime Movimento { get; set; }
        public Usuario Usuario { get; set; }

        public Bitacora()
        {
            Usuario = new Usuario();
        }
    }
}
