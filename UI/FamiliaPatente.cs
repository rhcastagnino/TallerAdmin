using BE;
using BLL;
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
    public partial class FamiliaPatente : Form, IIdiomaObserver
    {
        public static IIdioma idioma;
        PermisoBLL permisoBLL = new PermisoBLL();
        Familia fam;

        public FamiliaPatente()
        {
            InitializeComponent();
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

        private void FamiliaPatente_Load(object sender, EventArgs e)
        {
            UpdateLanguage(Session.GetInstance.Usuario.Idioma);
            CargarCombos();
        }

        private void CargarCombos()
        {
            comboFamilias.DataSource = permisoBLL.TraerFamilias();
            comboPatentes.DataSource = permisoBLL.TraerPatentes();
            comboPermisos.DataSource = permisoBLL.TraerPermisos();
        }

        private void CargarTree(bool familia)
        {
            if (fam == null) return;

            IList<Componente> _familia;
            if (familia)
            {
                _familia = permisoBLL.TraerTodo(fam.Id);
                foreach (var i in _familia) fam.AgregarHijo(i);
            }
            else
            {
                _familia = fam.Hijos;
            }
            tree.Nodes.Clear();
            TreeNode root = new TreeNode(fam.Nombre);
            root.Tag = fam;
            tree.Nodes.Add(root);

            foreach (var item in _familia)
            {
                MostrarEnTree(root, item);
            }
            tree.ExpandAll();
        }

        private void MostrarEnTree(TreeNode tn, Componente comp)
        {
            TreeNode nodo = new TreeNode(comp.Nombre);
            tn.Tag = comp;
            tn.Nodes.Add(nodo);
            if (comp.Hijos != null)
            {
                foreach (var item in comp.Hijos)
                {
                    MostrarEnTree(nodo, item);
                }
            }
        }

        private void FamiliaPatente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Principal formPrincipal = new Principal();
            formPrincipal.Show();
        }

        private void btnGuardarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                Familia familia = new Familia();
                familia.Nombre = txtFamilia.Text;
                permisoBLL.GuardarPatente(familia,true);
                MessageBox.Show($"Se guardo la familia {familia.Nombre}");
                Limpiar();
                CargarCombos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Limpiar()
        {
            txtFamilia.Clear();
            txtPermiso.Clear();
        }

        private void btnGuardaPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                Patente patente = new Patente();
                patente.Nombre = txtPermiso.Text;
                patente.Permiso = (TipoPermiso)this.comboPermisos.SelectedItem;
                permisoBLL.GuardarPatente(patente, false);
                MessageBox.Show($"Se guardo la Patente {patente.Nombre}");
                Limpiar();
                CargarCombos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConfFam_Click(object sender, EventArgs e)
        {
            var tmp = (Familia)comboFamilias.SelectedItem;
            fam = new Familia();
            fam.Id = tmp.Id;
            fam.Nombre = tmp.Nombre;
            CargarTree(true);
        }

        private void btnAgregarPatente_Click(object sender, EventArgs e)
        {
            if (fam != null)
            {
                var patente = (Patente)comboPatentes.SelectedItem;
                if (patente != null)
                {
                    var existeComp = permisoBLL.Existe(fam, patente.Id);
                    if (existeComp)
                    {
                        MessageBox.Show($"Patente Agregada {patente.Nombre}");
                        CargarTree(true);
                    }
                    else
                    {
                        fam.AgregarHijo(patente);
                        CargarTree(false);
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                permisoBLL.GuardarFamilia(fam);
                tree.Nodes.Clear();
                MessageBox.Show("Guardado correctamente");
            }
            catch
            {
                MessageBox.Show("Error al guardar");
            }
        }

        private void btnAgregarFamilia_Click(object sender, EventArgs e)
        {
            if (fam != null)
            {
                var familia = (Familia)comboFamilias.SelectedItem;
                if (familia != null)
                {
                    var recusividad = permisoBLL.ExisteRecursividad(fam, familia);
                    if (recusividad)
                    {
                        MessageBox.Show($"Existe conflicto de familias, no puede agregar la familia {familia.ToString()} en la familia {fam.ToString()} ya que la contiene previamente una familia dentro del mismo");
                    }
                    else
                    {
                        var esta = permisoBLL.Existe(fam, familia.Id);
                        if (esta)
                            MessageBox.Show("Existe la familia indicada");
                        else
                        {
                            permisoBLL.LlenarFamiliaComponente(familia);
                            fam.AgregarHijo(familia);
                            CargarTree(false);
                        }
                    }
                }
            }
        }
    }
}
