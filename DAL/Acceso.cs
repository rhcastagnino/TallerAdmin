using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Acceso : Conexion
    {
        private Conexion con;
        private DataTable tabla;

        public Acceso()
        {
            con = new Conexion();
            tabla = new DataTable();
        }


        public void AltaUsuario(BE.Usuario usuario, string sp)
        {
            SqlCommand cmd = new SqlCommand(sp,con.Conectar());
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre",usuario.Nombre);
            cmd.Parameters.AddWithValue("@apellido",usuario.Apellido);
            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.Parameters.AddWithValue("@pass",usuario.Password);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.Desconectar();
        }

        public BE.Usuario GetUsuario(string email,string sp)
        {
            SqlCommand cmd = new SqlCommand(sp, con.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email",email);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);
            BE.Usuario usr = new BE.Usuario();
            foreach (DataRow fila in tabla.Rows)
            {
                usr.Email = fila[5].ToString();
                usr.Password = fila[3].ToString();
                usr.Nombre = fila[1].ToString();
                usr.Apellido = fila[2].ToString();
                usr.Contador = int.Parse(fila[4].ToString());
            }
            cmd.Parameters.Clear();
            return usr;
        }

        public void Contador(BE.Usuario usuario, string sp)
        {
            SqlCommand cmd = new SqlCommand(sp, con.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.Desconectar();
        }

        public DataTable Leer(string consulta)
        {
            SqlCommand cmd = new SqlCommand(consulta, con.Conectar());
            SqlDataReader lector = cmd.ExecuteReader();
            tabla.Load(lector);
            con.Desconectar();
            return tabla;
        }

        public void Ejecutar(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con.Conectar());
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public void AltaIdioma(BE.Idioma idioma, string sp)
        {
            SqlCommand cmd = new SqlCommand(sp, con.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", idioma.Nombre);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.Desconectar();
        }

        public void AltaTraduccion(BE.Idioma idioma,BE.Traduccion traduccion, string sp)
        {
            SqlCommand cmd = new SqlCommand(sp, con.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idIdioma", idioma.Id);
            cmd.Parameters.AddWithValue("@claveEtiqueta", traduccion.Etiqueta.Clave);
            cmd.Parameters.AddWithValue("@valor", traduccion.Valor);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.Desconectar();
        }
        public void GuardarPatente(BE.Componente p, bool esfamilia)
        {
            SqlCommand cmd = new SqlCommand("guardarPatente", con.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", p.Nombre);
            if (esfamilia)
                cmd.Parameters.AddWithValue("@permiso", DBNull.Value);

            else
                cmd.Parameters.AddWithValue("@permiso", p.Permiso.ToString());
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.Desconectar();
        }


            public List<BE.Patente> TraerPatentes()
        {
            SqlCommand cmd = new SqlCommand("TraerPatentes", con.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);
            var lista = new List<BE.Patente>();
            BE.Patente c = new BE.Patente();
            foreach (DataRow fila in tabla.Rows)
            {
                c.Nombre = fila[1].ToString();
                c.Permiso = (BE.TipoPermiso)Enum.Parse(typeof(BE.TipoPermiso), fila[2].ToString());
                c.Id = int.Parse(fila[0].ToString());
                lista.Add(c);
            }
            return lista;
        }

        public List<BE.Familia> TraerFamilias()
        {
            SqlCommand cmd = new SqlCommand("TraerFamilias", con.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);
            var lista = new List<BE.Familia>();
            BE.Familia c = new BE.Familia();
            foreach (DataRow fila in tabla.Rows)
            {
                c.Nombre = fila[1].ToString();
                c.Id = int.Parse(fila[0].ToString());
                lista.Add(c);
            }
            return lista;
        }

        public DataTable TraerTodo(int idFamilia)
        {
            SqlCommand cmd = new SqlCommand("TraerTodo", con.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPermisoP", idFamilia);
            SqlDataReader lector = cmd.ExecuteReader();
            tabla.Load(lector);
            con.Desconectar();
            return tabla;
        }

        public DataTable LlenarComponenteUsuario(int usr)
        {
            SqlCommand cmd = new SqlCommand("LlenarComponenteUsuario", con.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario", usr);
            SqlDataReader lector = cmd.ExecuteReader();
            tabla.Load(lector);
            con.Desconectar();
            return tabla;
        }

    }
}
