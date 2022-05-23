using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL
{
    public class UsuarioBLL
    {
        public BE.Usuario Usuario;
        public DAL.UsuarioDAL UsuarioDAL;

        public UsuarioBLL()
        {
            Usuario = new BE.Usuario();
            UsuarioDAL = new DAL.UsuarioDAL();
        }

        public void altaUsario(BE.Usuario usuario)
        {
            UsuarioDAL.altaUsaurio(usuario);
        }

        public void getUsuario(string email)
        {
            UsuarioDAL.getUsaurio(email);
        }
    }
}
