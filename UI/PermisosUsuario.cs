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
        private PermisoBLL permisoBLL = new PermisoBLL();
        private UsuarioBLL usuarioBLL = new UsuarioBLL();
        private Usuario usr = new Usuario();

        public static IIdioma idioma;
        public PermisosUsuario()
        {
            InitializeComponent();
        }

        private void PermisosUsuario_Load(object sender, EventArgs e)
        {
            UpdateLanguage(Session.GetInstance.Usuario.Idioma);
            CargarCombos();
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

        private void CargarCombos()
        {
            comboFamilia.DataSource = permisoBLL.TraerFamilias();
            comboUsr.DataSource = usuarioBLL.TraerUsuarios();
            comboUsr.DisplayMember = "Email";
            comboPermisos.DataSource = permisoBLL.TraerPatentes();
        }

        private void PermisosUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Principal formPrincipal = new Principal();
            formPrincipal.Show();
        }

        private void btnUsr_Click(object sender, EventArgs e)
        {
            usr = new Usuario();
            try
            {
                usr = (Usuario)this.comboUsr.SelectedItem;
                permisoBLL.LlenarComponenteUsuario(usr);
                MostrarPermisos(usr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPatente_Click(object sender, EventArgs e)
        {
            try
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
                            throw new Exception("El usuario ya tiene la patente indicada");
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
                    throw new Exception("Seleccione un usuario");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFamilia_Click(object sender, EventArgs e)
        {
            try 
            {
                if (usr != null)
                {
                    var flia = (Familia)comboFamilia.SelectedItem;
                    if (flia != null)
                    {
                        var esta = false;
                        foreach (var item in usr.Permisos)
                        {
                            if (permisoBLL.Existe(item, flia.Id))
                            {
                                esta = true;
                                break;
                            }
                        }

                        if (esta)
                            throw new Exception("El usuario ya tiene la familia indicada");
                        else
                        {
                            {
                                usr.Permisos.Add(flia);
                                permisoBLL.LlenarFamiliaComponente(flia);
                                MostrarPermisos(usr);
                            }
                        }
                    }
                }
                else
                    throw new Exception("Seleccione un usuario");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void LlenarTreeView(TreeNode padre, Componente componente)
        {
            TreeNode hijo = new TreeNode(componente.Nombre);
            hijo.Tag = componente;
            padre.Nodes.Add(hijo);

            foreach (var item in componente.Hijos)
            {
                LlenarTreeView(hijo, item);
            }
        }

        private void MostrarPermisos(Usuario usr)
        {
            this.treeView1.Nodes.Clear();
            TreeNode root = new TreeNode(usr.Email);

            foreach (var item in usr.Permisos)
            {
                LlenarTreeView(root, item);
            }

            this.treeView1.Nodes.Add(root);
            this.treeView1.ExpandAll();
        }
    }
}
