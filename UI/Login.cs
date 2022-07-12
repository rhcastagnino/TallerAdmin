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
    public partial class Login : Form, IIdiomaObserver
    {
        public static IIdioma idioma;

        BE.Usuario usuario = new BE.Usuario();
        Interfaces.IUsuario usuarioBLL = new BLL.UsuarioBLL();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Limpiar();
            MostrarIdiomasDisponibles();
            Session.SuscribirObservador(this);
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string pass = txtPass.Text;
                usuarioBLL.Login(email, pass, idioma);
                this.Hide();
                Principal formPrincipal = new Principal();
                formPrincipal.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Limpiar();
            }
        }

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();;
            AltaUsuario formAltaUsuario = new AltaUsuario(idioma);
            formAltaUsuario.Show();
        }


        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
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
        private void idioma_Click(object sender, EventArgs e)
        {
            Session.CambiarIdioma((IIdioma)((ToolStripMenuItem)sender).Tag);
            idioma = (IIdioma)((ToolStripMenuItem)sender).Tag;
        }
        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir(idioma);
        }
        private void Traducir(IIdioma idioma)
        {
            var traducciones = Traductor.ObtenerTraducciones(idioma);

            //if (menuIdioma.Tag != null && traducciones.ContainsKey(menuIdioma.Tag.ToString()))
            //    menuIdioma.Text = traducciones[menuIdioma.Tag.ToString()].Valor;

            //if (label3.Tag != null && traducciones.ContainsKey(label3.Tag.ToString()))
            //    label3.Text = traducciones[label3.Tag.ToString()].Valor;

            //if (gbIngreso.Tag != null && traducciones.ContainsKey(gbIngreso.Tag.ToString()))
            //    gbIngreso.Text = traducciones[gbIngreso.Tag.ToString()].Valor;

            //if (lblEmail.Tag != null && traducciones.ContainsKey(lblEmail.Tag.ToString()))
            //    lblEmail.Text = traducciones[lblEmail.Tag.ToString()].Valor;

            //if (lblPassword.Tag != null && traducciones.ContainsKey(lblPassword.Tag.ToString()))
            //    lblPassword.Text = traducciones[lblPassword.Tag.ToString()].Valor;

            //if (btnlogin.Tag != null && traducciones.ContainsKey(btnlogin.Tag.ToString()))
            //    btnlogin.Text = traducciones[btnlogin.Tag.ToString()].Valor;

            //if (btnAltaUsuario.Tag != null && traducciones.ContainsKey(btnAltaUsuario.Tag.ToString()))
            //    btnAltaUsuario.Text = traducciones[btnAltaUsuario.Tag.ToString()].Valor;

            foreach (Control mnuitOpcion in this.Controls)
            {
                if (mnuitOpcion.Tag != null && traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    mnuitOpcion.Text = traducciones[mnuitOpcion.Tag.ToString()].Valor;
                else if (mnuitOpcion.Tag != null && !traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    mnuitOpcion.Text = $"{mnuitOpcion.Tag}_NT";
            }

            foreach (ToolStripMenuItem mnuitOpcion in this.menuStrip1.Items)
            {
                if (mnuitOpcion.Tag != null && traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    mnuitOpcion.Text = traducciones[mnuitOpcion.Tag.ToString()].Valor;
                else if (mnuitOpcion.Tag != null && !traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    mnuitOpcion.Text = $"{mnuitOpcion.Tag}_NT";
            }

            foreach (Control mnuitOpcion in this.gbIngreso.Controls)
            {
                if (mnuitOpcion.Tag != null && traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    mnuitOpcion.Text = traducciones[mnuitOpcion.Tag.ToString()].Valor;
                else if (mnuitOpcion.Tag != null && !traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    mnuitOpcion.Text = $"{mnuitOpcion.Tag}_NT";
            }
        }

            private void Limpiar()
        {
            txtPass.Clear();
            txtEmail.Clear();
        }
    }
}
