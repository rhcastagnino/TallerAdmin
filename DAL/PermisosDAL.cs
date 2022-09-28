using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL 
{
    public class PermisosDAL : Acceso
    {
        //private Acceso acceso;
        private DataTable dt;

        public PermisosDAL()
        {
            //acceso = new Acceso();
            dt = new DataTable();
        }

        public Array TraerPermisos()
        {
            return Enum.GetValues(typeof(TipoPermiso));
        }


        public void GuardarPatente(Componente c, bool esfamilia)
        {
            try
            {
                string sp = "guardarPatente";
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@nombre", c.Nombre);
                if (esfamilia)
                    xParameters.Parameters.AddWithValue("@permiso", DBNull.Value);

                else
                    xParameters.Parameters.AddWithValue("@permiso", c.Permiso.ToString());
                StoredProcedure(sp);
            }
            catch 
            {
                throw new Exception("Error al guardar Componente contra la BD");
            }
        }


        public void GuardarFamilia(Familia f)
        {
            try
            {
                xCommandText = "delete from Familia_Patente where idPermisoPadre=@idPermisoPadre;";
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@idPermisoPadre", f.Id);
                executeNonQuery();

                foreach (var item in f.Hijos)
                {
                    xCommandText = "insert into Familia_Patente (idPermisoPadre,idPermisoHijo) values (@idPermisoPadre,@idItem);";
                    xParameters.Parameters.Clear();
                    xParameters.Parameters.AddWithValue("@idPermisoPadre", f.Id);
                    xParameters.Parameters.AddWithValue("@idItem", item.Id);
                    executeNonQuery();
                }
            }
            catch 
            {
                throw new Exception("Error al guardar Familias contra la BD");
            }
        }

        public IList<Patente> TraerPatentes()
        {
            dt = new DataTable();
            var lista = new List<Patente>();
            dt.Clear();
            string sp = "TraerPatentes";
            dt = StoredProcedure(sp);
            foreach (DataRow fila in dt.Rows)
            {
                BE.Patente p = new BE.Patente();
                p.Id = int.Parse(fila[0].ToString());
                p.Nombre = fila[1].ToString();
                p.Permiso = (BE.TipoPermiso)Enum.Parse(typeof(BE.TipoPermiso), fila[2].ToString());

                lista.Add(p);
            }
            return lista;
        }


        public IList<Familia> TraerFamilias()
        {
            dt = new DataTable();
            var lista = new List<Familia>();
            dt.Clear();
            string sp = "TraerFamilias";
            dt = StoredProcedure(sp);
            foreach (DataRow fila in dt.Rows)
            {
                BE.Familia f = new BE.Familia();
                f.Nombre = fila[1].ToString();
                f.Id = int.Parse(fila[0].ToString());
                lista.Add(f);
            }

            return lista;
        }
        public IList<Componente> TraerTodo(int idFamilia)
        {
            dt = new DataTable();
            dt.Clear();
            string sp = "TraerTodo";
            xParameters.Parameters.Clear();
            xParameters.Parameters.AddWithValue("@idPermisoP", idFamilia);
            dt = StoredProcedure(sp);

            var lista = new List<Componente>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rows in dt.Rows)
                {
                    int idpadre = 0;
                    if (rows["idPermisoPadre"] != DBNull.Value)
                    {
                        idpadre = int.Parse(rows["idPermisoPadre"].ToString());
                    }

                    var id = int.Parse(rows["id"].ToString());
                    var nombre = (rows["Nombre"].ToString());
                    var permiso = string.Empty;
                    if (rows["Permiso"] != DBNull.Value) permiso = rows["Permiso"].ToString();

                    Componente componente; 
                    if (string.IsNullOrEmpty(permiso)) componente = new Familia();
                    else componente = new Patente();

                    componente.Id = id;
                    componente.Nombre = nombre;
                    if (!string.IsNullOrEmpty(permiso)) componente.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permiso);

                    var padre = ObtenerComponente(idpadre, lista);
                    if (padre == null) lista.Add(componente);
                    else padre.AgregarHijo(componente);
                }
            }

            return lista;
        }

        private Componente ObtenerComponente(int id, IList<Componente> lista) 
        {
            Componente componente = lista != null ? lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;

            if (componente == null && lista != null)
            {
                foreach (var item in lista)
                {
                    var _lista = ObtenerComponente(id, item.Hijos);
                    if (_lista != null && _lista.Id == id) return _lista;
                    else if (_lista != null) return ObtenerComponente(id, _lista.Hijos);
                }
            }
            return componente;
        }


        public void LlenarComponenteUsuario(Usuario usr)
        {
            try
            {
                dt = new DataTable();
                dt.Clear();
                string sp = "LlenarComponenteUsuario";
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@idUsr", usr.Id);
                dt = StoredProcedure(sp);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int id = 0;
                        id = int.Parse(row["id"].ToString());
                        string nombre = row["nombre"].ToString();
                        string permiso = String.Empty;
                        if (row["permiso"].ToString() != String.Empty) permiso = row["permiso"].ToString();

                        Componente componente;
                        if (!String.IsNullOrEmpty(permiso))
                        {
                            componente = new Patente();
                            componente.Id = id;
                            componente.Nombre = nombre;
                            componente.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permiso);
                            usr.Permisos.Add(componente);
                        }
                        else
                        {
                            componente = new Familia();
                            componente.Id = id;
                            componente.Nombre = nombre;

                            var familia = TraerTodo(componente.Id);
                            foreach (var fam in familia)
                            {
                                componente.AgregarHijo(fam);
                            }
                            usr.Permisos.Add(componente);
                        }
                    }
                }
            }
            catch
            {
                throw new Exception($"Error al llenar el componente del usuario {usr.Email}");
            }

        }
        public void LlenarFamiliaComponente(Familia familia)
        {
            try
            {
                familia.VaciarHijos();
                foreach (var item in TraerTodo(familia.Id))
                {
                    familia.AgregarHijo(item);
                }
            }
            catch 
            {
                throw new Exception($"Error al llenar componentes de la familia {familia.Nombre}");
            }
        }

        public Componente TraerHijos(Componente Familia)
        {
            try
            {
                foreach (var item in TraerTodo(Familia.Id))
                {
                    Familia.AgregarHijo(item);
                }

                return Familia;
            }
            catch
            {
                throw new Exception($"Error al traer los hijos de la familia {Familia.Nombre}");
            }
        }

        public IList<Patente> CargarMenuPermisos(int idUsuario)
        {
            try
            {
                dt = new DataTable();
                IList<Patente> lista = new List<Patente>();
                dt.Clear();
                string sp = "TraerPermisosUsuario";
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@idUsuario", idUsuario);
                dt = StoredProcedure(sp);
                foreach (DataRow fila in dt.Rows)
                {
                    BE.Patente p = new BE.Patente();
                    p.Permiso = (BE.TipoPermiso)Enum.Parse(typeof(BE.TipoPermiso), fila[0].ToString());
                    lista.Add(p);
                }
                return lista;
            }
            catch
            {
                throw new Exception("Error validar los permisos para el menu");
            }

        }
    }
}
