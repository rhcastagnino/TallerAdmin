﻿using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Etiqueta : IEtiqueta

    {
        public int Id { get; set; }
        public string Clave { get; set; }
    }
}
