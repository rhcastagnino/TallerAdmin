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
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

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
    }
}
