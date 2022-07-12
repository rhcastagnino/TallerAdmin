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
    public partial class AltaUsuario : Form, IIdiomaObserver
    {
        public AltaUsuario(IIdioma idioma)
        {
            InitializeComponent();
            UpdateLanguage(idioma);
        }

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {

            try
            {
                BE.Usuario usuario = new BE.Usuario();
                usuario.Email = txtEmail.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;

                BLL.UsuarioBLL usuarioBLL = new BLL.UsuarioBLL();
                usuarioBLL.AltaUsario(usuario);
                MessageBox.Show($"Se registró correctamente al usuario {usuario.Apellido} {usuario.Nombre}, por favor ingresar al sistema");

                this.Hide();
                Login formLogin = new Login();
                formLogin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Limpiar();
            }
        }

        private void AltaUsuario_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void AltaUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login formLogin = new Login();
            formLogin.Show();
        }

        private void Limpiar()
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtEmail.Clear();
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir(idioma);
        }
        private void Traducir(IIdioma idioma)
        {
            var traducciones = Traductor.ObtenerTraducciones(idioma);

            //if (lblTitulo.Tag != null && traducciones.ContainsKey(lblTitulo.Tag.ToString()))
            //    lblTitulo.Text = traducciones[lblTitulo.Tag.ToString()].Valor;

            //if (gb.Tag != null && traducciones.ContainsKey(gb.Tag.ToString()))
            //    gb.Text = traducciones[gb.Tag.ToString()].Valor;

            //if (lblNombre.Tag != null && traducciones.ContainsKey(lblNombre.Tag.ToString()))
            //    lblNombre.Text = traducciones[lblNombre.Tag.ToString()].Valor;

            //if (lblApellido.Tag != null && traducciones.ContainsKey(lblApellido.Tag.ToString()))
            //    lblApellido.Text = traducciones[lblApellido.Tag.ToString()].Valor;

            //if (lblEmail.Tag != null && traducciones.ContainsKey(lblEmail.Tag.ToString()))
            //    lblEmail.Text = traducciones[lblEmail.Tag.ToString()].Valor;

            //if (btnAltaUsuario.Tag != null && traducciones.ContainsKey(btnAltaUsuario.Tag.ToString()))
            //    btnAltaUsuario.Text = traducciones[btnAltaUsuario.Tag.ToString()].Valor;

            foreach (Control mnuitOpcion in this.gb.Controls)

            {

                if (mnuitOpcion.Tag != null && traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    mnuitOpcion.Text = traducciones[mnuitOpcion.Tag.ToString()].Valor;
                else if (mnuitOpcion.Tag != null && !traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    mnuitOpcion.Text = $"{mnuitOpcion.Tag}_NT";

            }

            foreach (Control mnuitOpcion in this.Controls)

            {

                if (mnuitOpcion.Tag != null && traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    mnuitOpcion.Text = traducciones[mnuitOpcion.Tag.ToString()].Valor;
                else if (mnuitOpcion.Tag != null && !traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    mnuitOpcion.Text = $"{mnuitOpcion.Tag}_NT";

            }

        }
    }
}
