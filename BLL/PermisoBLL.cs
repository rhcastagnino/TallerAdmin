using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PermisoBLL
    {
        private DAL.PermisosDAL permisosDAL;

        public PermisoBLL()
        {
            permisosDAL = new DAL.PermisosDAL();
        }

        public bool Existe(Componente c, int id)
        {
            bool existe = false;

            if (c.Id.Equals(id))
                existe = true;
            else
                foreach (var item in c.Hijos)
                {
                    existe = Existe(item, id);
                    if (existe) return true;
                }
            return existe;
        }


        public Array TraerPermisos()
        {
            return permisosDAL.TraerPermisos();
        }


        public void GuardarPatente(Componente c, bool esfamilia)
        {
            permisosDAL.GuardarPatente(c, esfamilia);
        }


        public void GuardarFamilia(Familia familia)
        {
            permisosDAL.GuardarFamilia(familia);
        }

        public IList<Patente> TraerPatentes()
        {
            return permisosDAL.TraerPatentes();
        }

        public IList<Familia> TraerFamilias()
        {
            return permisosDAL.TraerFamilias();
        }

        public IList<Componente> TraerTodo(int idFamilia)
        {
            return permisosDAL.TraerTodo(idFamilia);

        }

        public void LlenarComponenteUsuario(Usuario usr)
        {
            permisosDAL.LlenarComponenteUsuario(usr);

        }

        public void LlenarFamiliaComponente(Familia familia)
        {
            permisosDAL.LlenarFamiliaComponente(familia);
        }

        public bool ExisteRecursividad(Componente cPadre, Componente cHijo)
        {
            bool existeRecusividad = false;
            Componente familiaHija = permisosDAL.TraerHijos(cHijo);
            foreach (var item in familiaHija.Hijos)
            {
                bool existe = Existe(item, cPadre.Id);
                if (existe)
                {
                    existeRecusividad = true;
                    return existeRecusividad;
                }
                foreach (var i in item.Hijos)
                {
                    bool existeEnHijo = Existe(i, cPadre.Id);
                    if (existeEnHijo)
                    {
                        existeRecusividad = true;
                        return existeRecusividad;
                    }
                    foreach (var phi in cPadre.Hijos)
                    {
                        bool existeEnHijo2 = Existe(phi, item.Id);
                        if (existeEnHijo2)
                        {
                            existeRecusividad = true;
                            return existeRecusividad;
                        }
                        bool existeEnHijo3 = Existe(phi, i.Id);
                        if (existeEnHijo3)
                        {
                            existeRecusividad = true;
                            return existeRecusividad;
                        }
                    }

                }
            }
            return existeRecusividad;
        }
    }
}
