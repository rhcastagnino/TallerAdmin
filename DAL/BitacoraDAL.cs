using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BitacoraDAL : Acceso
    {
        Bitacora bitacora;
        private DataTable dt;

        public BitacoraDAL()
        {
            bitacora = new Bitacora();
        }

        public void RegistrarBitacora(Bitacora bitacora)
        {
            try
            {

                string sp = "RegistrarBitacora";
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@descripcion", bitacora.Descripcion);
                xParameters.Parameters.AddWithValue("@criticidad", bitacora.Criticidad);
                xParameters.Parameters.AddWithValue("@movimiento", DateTime.Now);
                xParameters.Parameters.AddWithValue("@idusuario", bitacora.Usuario.Id);
                StoredProcedureConsulta(sp);
            }
            catch
            {
                throw new Exception("Error en la base al registrar el bitocara");
            }
        }

        public List<Bitacora> GetBitacora()
        {
            try
            {
                string sp = "getBitacora";
                dt = new DataTable();
                xParameters.Parameters.Clear();
                dt = StoredProcedure(sp);
                List<Bitacora> bitacoras = new List<Bitacora>();
                foreach (DataRow fila in dt.Rows)
                {
                    bitacora.Movimento = DateTime.Parse(fila[4].ToString());
                    bitacora.Criticidad = fila[3].ToString();
                    bitacora.Usuario.Id = int.Parse(fila[1].ToString());
                    bitacora.Descripcion = fila[2].ToString();
                    bitacora.Id = int.Parse(fila[0].ToString());
                    bitacoras.Add(bitacora);
                }
                return bitacoras;
            }
            catch
            {
                throw new Exception("Error en la base al consultar la bitacora");
            }
        }
    }
}
