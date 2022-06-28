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
    public partial class Principal : Form, IIdiomaObserver
    {
        public static IIdioma idioma;
        public Principal()
        {
            InitializeComponent();
            UpdateLanguage(Session.GetInstance.Usuario.Idioma);
            Session.SuscribirObservador(this);
            MostrarIdiomasDisponibles();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CerrarPrincipal();
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarPrincipal();
        }

        private void CerrarPrincipal()
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            usuarioBLL.Logout();
            Login formLogin = new Login();
            formLogin.Show();
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir(idioma);
        }
        private void Traducir(IIdioma idioma)
        {
            var traducciones = Traductor.ObtenerTraducciones(idioma);

            foreach (ToolStripMenuItem mnuitOpcion in this.menuStrip1.Items)
            {
                if (mnuitOpcion.Tag != null && traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    mnuitOpcion.Text = traducciones[mnuitOpcion.Tag.ToString()].Valor;
                else if (mnuitOpcion.Tag != null && !traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    mnuitOpcion.Text = $"{mnuitOpcion.Tag}NO_TRADUCCION";

                if (mnuitOpcion.DropDownItems.Count > 0)
                {
                    foreach (ToolStripMenuItem miitem in mnuitOpcion.DropDownItems)
                    {
                        if (miitem.Tag != null && traducciones.ContainsKey(miitem.Tag.ToString()))
                            miitem.Text = traducciones[miitem.Tag.ToString()].Valor;
                        else if (miitem.Tag != null && !traducciones.ContainsKey(miitem.Tag.ToString()))
                            miitem.Text = $"{miitem.Tag}NO_TRADUCCION";

                        if (miitem.DropDownItems.Count > 0)
                        {
                            foreach (ToolStripMenuItem otroitem in miitem.DropDownItems)

                                if (otroitem.Tag != null && traducciones.ContainsKey(otroitem.Tag.ToString()))
                                    otroitem.Text = traducciones[otroitem.Tag.ToString()].Valor;
                                else if (otroitem.Tag != null && !traducciones.ContainsKey(otroitem.Tag.ToString()))
                                    otroitem.Text = $"{otroitem.Tag}NO_TRADUCCION";
                        }
                    } 
                }
            }
        }

        private void idioma_Click(object sender, EventArgs e)
        {
            Session.CambiarIdioma((IIdioma)((ToolStripMenuItem)sender).Tag);
            idioma = (IIdioma)((ToolStripMenuItem)sender).Tag;
        }


        private void MostrarIdiomasDisponibles()
        {
            var idiomas = Traductor.ObtenerIdiomas();

            foreach (var item in idiomas)
            {
                var t = new ToolStripMenuItem();
                t.Text = item.Nombre;
                t.Tag = item;
                this.menuIdioma.DropDownItems.Add(t);

                t.Click += idioma_Click;
            }
            idioma = Traductor.ObtenerIdiomaDefault();
        }

        private void P_miNuevoIdioma_Click(object sender, EventArgs e)
        {
            NuevoIdioma formNuevoIdioma = new NuevoIdioma();
            formNuevoIdioma.Show();
        }

        private void miTraduccion_Click(object sender, EventArgs e)
        {
            NuevaTraduccion formNuevaTraduccion = new NuevaTraduccion();
            formNuevaTraduccion.Show();
        }
    }
}
