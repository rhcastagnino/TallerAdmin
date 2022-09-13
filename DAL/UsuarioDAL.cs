using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BE;

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

        public void GuardarPermisos(BE.Usuario usr)
        {

            try
            {
                string query = $"delete from Usuario_Permiso where idUsuario={usr.Id};";
                acceso.Ejecutar(query);

                foreach (var item in usr.Permisos)
                {
                    string sql = $"insert into Usuario_Permiso (idUsuario,idPermiso) values ({usr.Id},{item.Id}) ";
                    acceso.Ejecutar(sql);
                }
            }
            catch
            {
                throw new Exception($"Error en la base al guardar los permisos del usuario {usr.Apellido} {usr.Nombre}");
            }
        }

        public IList<Usuario> TraerUsuarios()
        {
            var lista = new List<Usuario>();
            DataTable tabla = new DataTable();
            tabla = acceso.TraerUsuarios();
            foreach (DataRow fila in tabla.Rows)
            {
                BE.Usuario usr = new BE.Usuario();
                usr.Email = fila[5].ToString();
                usr.Nombre = fila[1].ToString();
                usr.Apellido = fila[2].ToString();
                usr.Id = int.Parse(fila[0].ToString());
                lista.Add(usr);
            }

            return lista;
        }

        //create procedure TraerUsuarios
        //as
        //select* from Usuario
        //go


        //create procedure LlenarComponenteUsuario
        //@idUsr int
        //as
        //select p.* from Usuario_Permiso up
        //inner join Permiso p on p.id = up.idPermiso
        //where p.id = @idUsr
        //go
    }
}
