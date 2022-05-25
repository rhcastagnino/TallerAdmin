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
        private readonly SqlConnection conexion = new SqlConnection("Data Source=(local);Initial Catalog=TallerAdminDB;Integrated Security=True");

        public static Conexion GetInstancia()
        {
            if (instacia == null)
            {
                instacia = new Conexion();
            }
            return instacia;
        }

        public SqlConnection Conectar()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        public void Desconectar()
        {
            conexion.Close();
        }

    }
}
