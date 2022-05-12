using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace DAL
{
    public class Conexion
    {
        private static Conexion instacia = null;
        private SqlConnection conexion = new SqlConnection("Data Source=(local);Initial Catalog=TallerAdminDB;Integrated Security=True");

        public static Conexion getInstancia()
        {
            if (instacia == null)
            {
                instacia = new Conexion();
            }
            return instacia;
        }

        public SqlConnection conectar()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        public void desconectar()
        {
            conexion.Close();
        }

    }
}
