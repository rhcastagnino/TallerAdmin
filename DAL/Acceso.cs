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
        SqlConnection connection = new SqlConnection();

        private void Conectar()
        {
            connection.ConnectionString = conexion;
            connection.Open();
        }
        private void Desconectar()
        {
            connection.Close();
        }

        public DataTable executeNonQuery(string query)
        {
            SqlDataReader dr;
            DataTable dt = new DataTable();
            Conectar();
            SqlTransaction TR;
            SqlCommand Comando = new SqlCommand(query, connection);
            TR = connection.BeginTransaction();

            try
            {
                Comando.Transaction = TR;
                dr = Comando.ExecuteReader();
                dt.Load(dr);
                TR.Commit();
            }
            catch (Exception)
            {
                TR.Rollback();
            }

            Desconectar();
            return dt;
        }
    }
}
