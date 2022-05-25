using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class UsuarioDAL
    {
        private Acceso acceso;
        private BE.Usuario usuario;

        public UsuarioDAL()
        {
            acceso = new Acceso();
            usuario = new BE.Usuario();
        }

        public void altaUsaurio(BE.Usuario usuario) 
        {
            try
            {

                string sp = "alta_usuario"; //  '"+usuario.nombre+"','"+usuario.apellido+"','"+usuario.email+"', '"+usuario.password+"'";
                //acceso.ejecutar(query);
                acceso.AltaUsuario(usuario, sp);
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error en la base al dar de alta el usuario {usuario.apellido} {usuario.nombre}");
            }
        }

        public BE.Usuario getUsaurio(string email)
        {
            try
            {     
                string sp = "get_usuario";
                usuario = acceso.getUsuario(email, sp);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la base al consultar el usuario {email}");
            }
        }
    }
}
