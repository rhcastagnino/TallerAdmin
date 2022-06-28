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

    }
}
