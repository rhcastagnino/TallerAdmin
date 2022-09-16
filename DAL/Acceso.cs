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
        private Conexion conexion;// = new Conexion();
        //private SqlConnection con;// = new SqlConnection();
        private DataTable tabla;// = new DataTable();
        private string xTextCommand;
        private SqlCommand parameters;// = new SqlCommand();

        public Acceso()
        {
            //con = new SqlConnection();
            conexion = new Conexion();
            tabla = new DataTable();
            parameters = new SqlCommand();
        }

        protected string xCommandText
        {
            get { return xTextCommand; }
            set { xTextCommand = value; }
        }

        protected SqlCommand xParameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        public void executeNonQuery()
        {

            conexion.Conectar();

            SqlTransaction TR = con.BeginTransaction();
            SqlCommand command = new SqlCommand(xCommandText, con, TR);
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();

            foreach (SqlParameter p in xParameters.Parameters)
            {
                command.Parameters.AddWithValue(p.ParameterName, p.SqlValue);
            }

            try
            {
                command.ExecuteNonQuery();
                TR.Commit();
            }

            catch (SqlException exc)
            {
                TR.Rollback();
                throw new Exception("ocurrio un Error ENQ en BD:" + exc.Message);
            }
            catch (Exception exc2)
            {
                TR.Rollback();
                throw new Exception("ocurrio un Error ENQ:" + exc2.Message);
            }
            finally
            {
                conexion.Desconectar();
            }
        }


        public DataTable ExecuteReader()
        {

            conexion.Conectar();
            SqlDataReader dr;
            DataTable dt = new DataTable();
            SqlTransaction TR = con.BeginTransaction();
            SqlCommand comando = new SqlCommand(xCommandText, con, TR);
            comando.CommandType = CommandType.Text;
            comando.Parameters.Clear();

            foreach (SqlParameter p in xParameters.Parameters)
            {
                comando.Parameters.AddWithValue(p.ParameterName, p.SqlValue);
            }

            try
            {
                dr = comando.ExecuteReader();
                dt.Load(dr);
                TR.Commit();
                return dt;
            }

            catch (SqlException exc)
            {
                TR.Rollback();
                throw new Exception("ocurrio un Error ER en BD:" + exc.Message);
            }

            catch (Exception exc2)
            {
                TR.Rollback();
                throw new Exception("ocurrio un Error ER:" + exc2.Message);
            }
            finally
            {
                conexion.Desconectar();
            }

        }

        public virtual int ExecuteNonEscalar()
        {
            conexion.Conectar();
            SqlTransaction transaction = con.BeginTransaction();
            SqlCommand command = new SqlCommand(xCommandText, con, transaction);
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();

            foreach (SqlParameter p in xParameters.Parameters)
            {
                command.Parameters.AddWithValue(p.ParameterName, p.SqlValue);
            }

            SqlParameter sp_return = new SqlParameter();
            sp_return.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(sp_return);

            int outputId = 0;

            try
            {
                outputId = (int)command.ExecuteScalar();
                transaction.Commit();
            }
            catch (SqlException exc)
            {
                transaction.Rollback();
                throw new Exception("Ocurrió un error ENE en BD: " + exc.Message);
            }
            catch (Exception exc2)
            {
                transaction.Rollback();
                throw new Exception("Ocurrió un error ENE: " + exc2.Message);
            }
            finally
            {
                conexion.Desconectar();
            }

            return outputId;
        }

        public void StoredProcedureConsulta(string sp)
        {
            //conexion.Conectar();
            SqlTransaction TR = conexion.Conectar().BeginTransaction();
            SqlCommand comando = new SqlCommand(sp, conexion.Conectar(), TR);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();

            foreach (SqlParameter p in xParameters.Parameters)
            {
                comando.Parameters.AddWithValue(p.ParameterName, p.SqlValue);
            }

            try
            {
                comando.ExecuteNonQuery();
                TR.Commit();
            }

            catch (SqlException exc)
            {
                TR.Rollback();
                throw new Exception("Ocurrio un Error SPC en BD:" + exc.Message);
            }
            catch (Exception exc2)
            {
                TR.Rollback();
                throw new Exception("Ocurrio un Error SPC:" + exc2.Message);
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        public DataTable StoredProcedure(string sp)
        {
            //conexion.Conectar();
            SqlDataReader dr;
            DataTable dt = new DataTable();
            SqlTransaction TR = con.BeginTransaction();
            SqlCommand comando = new SqlCommand(sp, conexion.Conectar(), TR);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();

            foreach (SqlParameter p in xParameters.Parameters)
            {
                comando.Parameters.AddWithValue(p.ParameterName, p.SqlValue);
            }

            try
            {
                dr = comando.ExecuteReader();
                dt.Load(dr);
                TR.Commit();
                return dt;
            }

            catch (SqlException exc)
            {
                TR.Rollback();
                throw new Exception("Ocurrio un Error SP en BD:" + exc.Message);
            }
            catch (Exception exc2)
            {

                TR.Rollback();
                throw new Exception("Ocurrio un Error SP:" + exc2.Message);
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        public void AltaUsuario(BE.Usuario usuario, string sp)
        {
            SqlCommand cmd = new SqlCommand(sp, conexion.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
            cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.Parameters.AddWithValue("@pass", usuario.Password);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conexion.Desconectar();
        }

        public BE.Usuario GetUsuario(string email, string sp)
        {
            tabla = new DataTable();
            SqlCommand cmd = new SqlCommand(sp, conexion.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
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
            conexion.Desconectar();
            return usr;
        }

        public void Contador(BE.Usuario usuario, string sp)
        {
            SqlCommand cmd = new SqlCommand(sp, conexion.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conexion.Desconectar();
        }


        public DataTable Leer(string query)
        {
            tabla = new DataTable();
            tabla.Clear();
            SqlCommand cmd = new SqlCommand(query, conexion.Conectar());
            SqlDataReader lector = cmd.ExecuteReader();
            tabla.Load(lector);
            conexion.Desconectar();
            return tabla;
        }

        public void Ejecutar(string query)
        {
            SqlCommand cmd = new SqlCommand(query, conexion.Conectar());
            cmd.ExecuteNonQuery();
            conexion.Desconectar();
        }

        //public void AltaIdioma(BE.Idioma idioma, string sp)
        //{
        //    SqlCommand cmd = new SqlCommand(sp, con.Conectar());
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@nombre", idioma.Nombre);
        //    cmd.ExecuteNonQuery();
        //    cmd.Parameters.Clear();
        //    con.Desconectar();
        //}

        //public void AltaTraduccion(BE.Idioma idioma, BE.Traduccion traduccion, string sp)
        //{
        //    SqlCommand cmd = new SqlCommand(sp, con.Conectar());
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@idIdioma", idioma.Id);
        //    cmd.Parameters.AddWithValue("@claveEtiqueta", traduccion.Etiqueta.Clave);
        //    cmd.Parameters.AddWithValue("@valor", traduccion.Valor);
        //    cmd.ExecuteNonQuery();
        //    cmd.Parameters.Clear();
        //    con.Desconectar();
        //}
        public void GuardarPatente(BE.Componente p, bool esfamilia)
        {
            SqlCommand cmd = new SqlCommand("guardarPatente", conexion.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", p.Nombre);
            if (esfamilia)
                cmd.Parameters.AddWithValue("@permiso", DBNull.Value);

            else
                cmd.Parameters.AddWithValue("@permiso", p.Permiso.ToString());
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conexion.Desconectar();
        }


        public DataTable TraerPatentes()
        {
            tabla = new DataTable();
            tabla.Clear();
            SqlCommand cmd = new SqlCommand("TraerPatentes", conexion.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader lector = cmd.ExecuteReader();
            tabla.Load(lector);
            conexion.Desconectar();
            return tabla;
        }

        public DataTable TraerFamilias()
        {
            tabla = new DataTable();
            tabla.Clear();
            SqlCommand cmd = new SqlCommand("TraerFamilias", conexion.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader lector = cmd.ExecuteReader();
            tabla.Load(lector);
            conexion.Desconectar();
            return tabla;
        }

        public DataTable TraerTodo(int idFamilia)
        {
            tabla = new DataTable();
            tabla.Clear();
            SqlCommand cmd = new SqlCommand("TraerTodo", conexion.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPermisoP", idFamilia);
            SqlDataReader lector = cmd.ExecuteReader();
            tabla.Load(lector);
            conexion.Desconectar();
            return tabla;
        }

        public DataTable LlenarComponenteUsuario(int usr)
        {
            tabla = new DataTable();
            tabla.Clear();
            SqlCommand cmd = new SqlCommand("LlenarComponenteUsuario", conexion.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsr", usr);
            SqlDataReader lector = cmd.ExecuteReader();
            tabla.Load(lector);
            conexion.Desconectar();
            return tabla;
        }

        public DataTable TraerUsuarios()
        {
            tabla = new DataTable();
            tabla.Clear();
            SqlCommand cmd = new SqlCommand("TraerUsuarios", conexion.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader lector = cmd.ExecuteReader();
            tabla.Load(lector);
            conexion.Desconectar();
            return tabla;
        }

    }
}
