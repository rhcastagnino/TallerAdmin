using BE;
using DAL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BitacoraBLL
    {
        private Bitacora bitacora;
        private BitacoraDAL bitacoraDAL;

        public BitacoraBLL()
        {
            bitacora = new Bitacora();
            bitacoraDAL = new BitacoraDAL();
        }

        public void RegistrarBitacora(string descripcion, string criticidad, Usuario usuario)
        {
            bitacora.Criticidad = criticidad;
            bitacora.Descripcion = descripcion;
            bitacora.Usuario.Id = usuario.Id;
            bitacoraDAL.RegistrarBitacora(bitacora);
        }
    }
}
