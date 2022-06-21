using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Traduccion : ITraduccion
    {
        public IEtiqueta Etiqueta { get; set; }
        public string Valor { get; set; }
    }
}
