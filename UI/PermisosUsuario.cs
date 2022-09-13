using BE;
using BLL;
using DAL;
using Interfaces;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class PermisosUsuario : Form, IIdiomaObserver
    {
        PermisoBLL permisoBLL;
        UsuarioBLL usuarioBLL;
        Usuario usuario;
        Usuario usr;

        public static IIdioma idioma;
        public PermisosUsuario()
        {
            InitializeComponent();
        }

        private void PermisosUsuario_Load(object sender, EventArgs e)
        {
            UpdateLanguage(Session.GetInstance.Usuario.Idioma);
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir(idioma);
        }

        private void Traducir(IIdioma idioma)
        {
            var traducciones = Traductor.ObtenerTraducciones(idioma);
            var tradDefault = Traductor.ObtenerTraducciones(Traductor.ObtenerIdiomaDefault());

            foreach (Control mnuitOpcion in this.Controls)
            {
                if (mnuitOpcion.Tag != null && traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    mnuitOpcion.Text = traducciones[mnuitOpcion.Tag.ToString()].Valor;
                else if (mnuitOpcion.Tag != null && !traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    mnuitOpcion.Text = tradDefault[mnuitOpcion.Tag.ToString()].Valor;
                    //mnuitOpcion.Text = $"{mnuitOpcion.Tag}_NT";

            }
        }

        private void PermisosUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Principal formPrincipal = new Principal();
            formPrincipal.Show();
        }

        void LlenarTreeView(TreeNode padre, Componente c)
        {
            TreeNode hijo = new TreeNode(c.Nombre);
            hijo.Tag = c;
            padre.Nodes.Add(hijo);

            foreach (var item in c.Hijos)
            {
                LlenarTreeView(hijo, item);
            }

        }

        void MostrarPermisos(Usuario u)
        {
            this.treeView1.Nodes.Clear();
            TreeNode root = new TreeNode(u.Nombre);

            foreach (var item in u.Permisos)
            {
                LlenarTreeView(root, item);
            }

            this.treeView1.Nodes.Add(root);
            this.treeView1.ExpandAll();
        }

        private void btnUsr_Click(object sender, EventArgs e)
        {
            usuario = (Usuario)this.comboUsr.SelectedItem;
            usr = new Usuario();
            usr.Id = usuario.Id;
            usr.Nombre = usuario.Nombre;
            permisoBLL.LlenarComponenteUsuario(usr);

            MostrarPermisos(usr);
        }

        private void btnPatente_Click(object sender, EventArgs e)
        {
            if (usr != null)
            {
                var patente = (Patente)comboPermisos.SelectedItem;
                if (patente != null)
                {
                    var esta = false;

                    foreach (var item in usr.Permisos)
                    {
                        if (permisoBLL.Existe(item, patente.Id))
                        {
                            esta = true;
                            break;
                        }
                    }
                    if (esta)
                        MessageBox.Show("El usuario ya tiene la patente indicada");
                    else
                    {
                        {
                            usr.Permisos.Add(patente);
                            MostrarPermisos(usr);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Seleccione un usuario");
        }

        private void btnFamilia_Click(object sender, EventArgs e)
        {
            if (usr != null)
            {
                var flia = (Familia)comboFamilia.SelectedItem;
                if (flia != null)
                {
                    var esta = false;
                    //verifico que ya no tenga el permiso. TODO: Esto debe ser parte de otra capa.
                    foreach (var item in usr.Permisos)
                    {
                        if (permisoBLL.Existe(item, flia.Id))
                        {
                            esta = true;
                        }
                    }

                    if (esta)
                        MessageBox.Show("El usuario ya tiene la familia indicada");
                    else
                    {
                        {
                            permisoBLL.LlenarFamiliaComponente(flia);

                            usr.Permisos.Add(flia);
                            MostrarPermisos(usr);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Seleccione un usuario");
        }

        private void PU_btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                usuarioBLL.GuardarPermisos(usr);
                MessageBox.Show("Usuario guardado correctamente");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar el usuario");
            }
        }
    }
}
