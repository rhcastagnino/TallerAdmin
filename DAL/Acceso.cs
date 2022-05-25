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

        public DataTable leer(string sp)
        {
            SqlCommand cmd = new SqlCommand(sp, con.conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);
            return tabla;

        }

        public void ejecutar(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con.conectar());
            cmd.ExecuteNonQuery();
            con.desconectar();
        }

        public void AltaUsuario(BE.Usuario usuario, string sp)
        {
            SqlCommand cmd = new SqlCommand(sp,con.conectar());
            //cmd.Connection = con.conectar();
            //cmd.CommandText = sp;
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre",usuario.nombre);
            cmd.Parameters.AddWithValue("@apellido",usuario.apellido);
            cmd.Parameters.AddWithValue("@email", usuario.email);
            cmd.Parameters.AddWithValue("@pass",usuario.password);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.desconectar();
        }

        public BE.Usuario getUsuario(string email,string sp)
        {
            SqlCommand cmd = new SqlCommand(sp, con.conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email",email);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);
            BE.Usuario usr = new BE.Usuario();
            foreach (DataRow fila in tabla.Rows)
            {
                usr.email = fila[5].ToString();
                usr.password = fila[3].ToString();
                usr.nombre = fila[1].ToString();
                usr.apellido = fila[2].ToString();
                usr.contador = int.Parse(fila[4].ToString());
            }
            cmd.Parameters.Clear();
            return usr;
        }

        public void incrementarContador(BE.Usuario usuario, string sp)
        {
            SqlCommand cmd = new SqlCommand(sp, con.conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", usuario.email);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.desconectar();
        }

        public void restablecerContador(BE.Usuario usuario, string sp)
        {
            SqlCommand cmd = new SqlCommand(sp, con.conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", usuario.email);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.desconectar();
        }
    }
}
