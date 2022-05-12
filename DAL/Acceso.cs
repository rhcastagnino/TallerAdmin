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

        public DataTable leer(string consulta)
        {
            SqlCommand cmd = new SqlCommand(consulta, con.conectar());
            SqlDataReader lector = cmd.ExecuteReader();
            tabla.Load(lector);
            con.desconectar();
            return tabla;
        }

        public void ejecutar(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con.conectar());
            cmd.ExecuteNonQuery();
            con.desconectar();
        }
    }
}
