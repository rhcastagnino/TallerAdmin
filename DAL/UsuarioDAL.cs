using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BE;

namespace DAL
{
    public class UsuarioDAL : Acceso
    {
        //private Acceso acceso;
        private BE.Usuario usuario;
        private DataTable dt;

        public UsuarioDAL()
        {
            //acceso = new Acceso();
            usuario = new BE.Usuario();
        }

        public void AltaUsaurio(BE.Usuario usuario) 
        {
            try
            {

                string sp = "altaUsuario";
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@nombre", usuario.Nombre);
                xParameters.Parameters.AddWithValue("@apellido", usuario.Apellido);
                xParameters.Parameters.AddWithValue("@email", usuario.Email);
                xParameters.Parameters.AddWithValue("@pass", usuario.Password);
                StoredProcedureConsulta(sp);
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
                dt = new DataTable();
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@email", email);
                dt = StoredProcedure(sp);
                foreach (DataRow fila in dt.Rows)
                {
                    usuario.Email = fila[5].ToString();
                    usuario.Password = fila[3].ToString();
                    usuario.Nombre = fila[1].ToString();
                    usuario.Apellido = fila[2].ToString();
                    usuario.Contador = int.Parse(fila[4].ToString());
                    usuario.Id = int.Parse(fila[0].ToString());
                }
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
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@email", usuario.Email);
                StoredProcedureConsulta(sp);
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
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@email", usuario.Email);
                StoredProcedureConsulta(sp);
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
                xCommandText = "delete from Usuario_Permiso where idUsuario=@idUsuario;";
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@idUsuario", usr.Id);
                executeNonQuery();

                foreach (var item in usr.Permisos)
                {
                    xCommandText = "insert into Usuario_Permiso (idUsuario,idPermiso) values (@idUsuario,@idItem); ";
                    xParameters.Parameters.Clear();
                    xParameters.Parameters.AddWithValue("@idUsuario", usr.Id);
                    xParameters.Parameters.AddWithValue("@idItem", item.Id);
                    executeNonQuery();
                }
            }
            catch
            {
                throw new Exception($"Error en la base al guardar los permisos del usuario {usr.Apellido} {usr.Nombre}");
            }
        }

        public IList<Usuario> TraerUsuarios()
        {
            string sp = "TraerUsuarios";
            dt = new DataTable();
            var lista = new List<Usuario>();
            dt.Clear();
            dt = StoredProcedure(sp);
            foreach (DataRow fila in dt.Rows)
            {
                usuario = new Usuario();
                usuario.Email = fila[5].ToString();
                usuario.Nombre = fila[1].ToString();
                usuario.Apellido = fila[2].ToString();
                usuario.Id = int.Parse(fila[0].ToString());
                lista.Add(usuario);
            }

            return lista;
        }


    }
}
