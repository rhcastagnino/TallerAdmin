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
    public class PermisosDAL
    {
        private Acceso acceso;

        public PermisosDAL()
        {
            acceso = new Acceso();
        }

        public Array TraerPermisos()
        {
            return Enum.GetValues(typeof(TipoPermiso));
        }


        public void GuardarPatente(Componente c, bool esfamilia)
        {
            try
            {
                acceso.GuardarPatente(c, esfamilia);
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
                string query = "delete from Familia_Patente where idPermisoPadre=" + f.Id+";";
                acceso.Ejecutar(query);

                foreach (var item in f.Hijos)
                {
                    string sql = "insert into Familia_Patente (idPermisoPadre,idPermisoHijo) values ("+ f.Id + ","+ item.Id + ") ";
                    acceso.Ejecutar(sql);
                }
            }
            catch 
            {
                throw new Exception("Error al guardar Familias contra la BD");
            }
        }

        public IList<Patente> TraerPatentes()
        {
            var lista = new List<Patente>();
            DataTable tabla = new DataTable();
            tabla = acceso.TraerPatentes();
            foreach (DataRow fila in tabla.Rows)
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
            var lista = new List<Familia>();
            DataTable tabla = new DataTable();
            tabla = acceso.TraerFamilias();
            foreach (DataRow fila in tabla.Rows)
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
            DataTable dt = new DataTable();
            dt = acceso.TraerTodo(idFamilia);

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

            DataTable dt = new DataTable();
            dt = acceso.LlenarComponenteUsuario(usr.Id);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rows in dt.Rows)
                {
                    int id = int.Parse(rows["id"].ToString());
                    string nombre = rows["nombre"].ToString();
                    string permiso = String.Empty;
                    if (rows["permiso"].ToString() != String.Empty) permiso = rows["permiso"].ToString();

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

                        var familia = TraerTodo(id);
                        foreach (var fam in familia)
                        {
                            componente.AgregarHijo(fam);
                        }
                        usr.Permisos.Add(componente);
                    }
                }
            }

        }
        public void LlenarFamiliaComponente(Familia familia)
        {
            familia.VaciarHijos();
            foreach (var item in TraerTodo(familia.Id))
            {
                familia.AgregarHijo(item);
            }
        }

        public Componente TraerHijos(Componente Familia)
        {
            foreach (var item in TraerTodo(Familia.Id))
            {
                Familia.AgregarHijo(item);
            }

            return Familia;
        }
    }
}
