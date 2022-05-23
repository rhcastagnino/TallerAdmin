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
               
                string query = "exec alta_usuario  '"+usuario.nombre+"','"+usuario.apellido+"','"+usuario.email+"', '"+usuario.password+"'";
                acceso.ejecutar(query);
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error en la base al dar de alta el usuario {usuario.email}");
            }
        }

        public void getUsaurio(string email)
        {
            try
            {
                string query = "exec get_usuario  '" + email + "'";
                acceso.ejecutar(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la base al consultar el usuario {usuario.email}");
            }
        }
    }
}
