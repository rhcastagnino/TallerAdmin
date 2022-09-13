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

        public void AltaUsaurio(BE.Usuario usuario) 
        {
            try
            {

                string sp = "altaUsuario"; //  '"+usuario.nombre+"','"+usuario.apellido+"','"+usuario.email+"', '"+usuario.password+"'";
                //acceso.ejecutar(query);
                acceso.AltaUsuario(usuario, sp);
            }
            catch 
            {
                throw new Exception($"Error en la base al dar de alta el usuario {usuario.Apellido} {usuario.Nombre}");
            }
        }

        public BE.Usuario GetUsaurio(string email)
        {
            try
            {     
                string sp = "getUsuario";
                usuario = acceso.GetUsuario(email, sp);
                return usuario;
            }
            catch 
            {
                throw new Exception($"Error en la base al consultar el usuario {email}");
            }
        }

        public void IncrementarContador(BE.Usuario usuario)
        {
            try
            {
                string sp = "incrementarContador"; 
                acceso.Contador(usuario, sp);
            }
            catch 
            {
                throw new Exception($"Error en la base al incrementar intentos de inicio del usuario {usuario.Apellido} {usuario.Nombre}");
            }
        }

        public void RestablecerContador(BE.Usuario usuario)
        {
            try
            {
                string sp = "restablecerContador";
                acceso.Contador(usuario, sp);
            }
            catch
            {
                throw new Exception($"Error en la base al restablecer intentos de inicio del usuario {usuario.Apellido} {usuario.Nombre}");
            }
        }

        //public void GuardarPermisos(BE.Usuario u)
        //{

        //    try
        //    {


        //        cmd.CommandText = $@"delete from usuarios_permisos where id_usuario=@id;";
        //        cmd.Parameters.Add(new SqlParameter("id", u.Id));
        //        cmd.ExecuteNonQuery();

        //        foreach (var item in u.Permisos)
        //        {
        //            cmd = new SqlCommand();
        //            cmd.Connection = cnn;

        //            cmd.CommandText = $@"insert into usuarios_permisos (id_usuario,id_permiso) values (@id_usuario,@id_permiso) "; ;
        //            cmd.Parameters.Add(new SqlParameter("id_usuario", u.Id));
        //            cmd.Parameters.Add(new SqlParameter("id_permiso", item.Id));

        //            cmd.ExecuteNonQuery();
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
