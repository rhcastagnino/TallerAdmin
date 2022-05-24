using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Servicios;

namespace BLL
{
    public class UsuarioBLL
    {
        private BE.Usuario Usuario;
        private DAL.UsuarioDAL UsuarioDAL;
        private Encriptador encriptador;

        public UsuarioBLL()
        {
            Usuario = new BE.Usuario();
            UsuarioDAL = new DAL.UsuarioDAL();
            encriptador = new Encriptador();
        }

        public void altaUsario(BE.Usuario usuario)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(usuario.email) == true)
                {
                    throw new Exception("El email no puede estar vacío");
                }
                if (usuario.password.Length < 8 || usuario.password.Length > 15)
                {
                    throw new Exception("Password de usuario tiene que tener mas de 8 y 15 caracteres");
                }
                if (usuario.nombre.Length <= 2 || usuario.apellido.Length <= 2)
                {
                    throw new Exception("Nombre y/o Apellido del usuario no pueden tener menos de 2 caracteres");
                }
                usuario.email = usuario.email.ToLower();
                usuario.email = encriptador.Encriptar(usuario.email);
                usuario.password = encriptador.Hash(usuario.password);
                UsuarioDAL.altaUsaurio(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void getUsuario(string email)
        {
            email = encriptador.Desencriptar(email.ToLower());
            UsuarioDAL.getUsaurio(email);
        }
    }
}
