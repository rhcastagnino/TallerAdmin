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

                string sp = "altaUsuario"; //  '"+usuario.nombre+"','"+usuario.apellido+"','"+usuario.email+"', '"+usuario.password+"'";
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
                string sp = "getUsuario";
                usuario = acceso.getUsuario(email, sp);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la base al consultar el usuario {email}");
            }
        }

        public void incrementarContador(BE.Usuario usuario)
        {
            try
            {
                string sp = "incrementarContador"; 
                acceso.incrementarContador(usuario, sp);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la base al incrementar intentos de inicio del usuario {usuario.apellido} {usuario.nombre}");
            }
        }

        public void restablecerContador(BE.Usuario usuario)
        {
            try
            {
                string sp = "restablecerContador";
                acceso.restablecerContador(usuario, sp);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la base al restablecer intentos de inicio del usuario {usuario.apellido} {usuario.nombre}");
            }
        }
    }
}
