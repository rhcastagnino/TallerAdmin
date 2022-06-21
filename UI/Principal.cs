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
        public Principal()
        {
            InitializeComponent();
            UpdateLanguage(Session.GetInstance.Usuario.Idioma);
            Session.SuscribirObservador(this);
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

            if (menuEmpleado.Tag != null && traducciones.ContainsKey(menuEmpleado.Tag.ToString()))
                menuEmpleado.Text = traducciones[menuEmpleado.Tag.ToString()].Valor;

            if (menuOmnibus.Tag != null && traducciones.ContainsKey(menuOmnibus.Tag.ToString()))
                menuOmnibus.Text = traducciones[menuOmnibus.Tag.ToString()].Valor;

            if (menuReparacion.Tag != null && traducciones.ContainsKey(menuReparacion.Tag.ToString()))
                menuReparacion.Text = traducciones[menuReparacion.Tag.ToString()].Valor;

            if (menuReportes.Tag != null && traducciones.ContainsKey(menuReportes.Tag.ToString()))
                menuReportes.Text = traducciones[menuReportes.Tag.ToString()].Valor;

            if (menuRepuesto.Tag != null && traducciones.ContainsKey(menuRepuesto.Tag.ToString()))
                menuRepuesto.Text = traducciones[menuRepuesto.Tag.ToString()].Valor;

            if (menuSolicitudes.Tag != null && traducciones.ContainsKey(menuSolicitudes.Tag.ToString()))
                menuSolicitudes.Text = traducciones[menuSolicitudes.Tag.ToString()].Valor;

            if (menuStock.Tag != null && traducciones.ContainsKey(menuStock.Tag.ToString()))
                menuStock.Text = traducciones[menuStock.Tag.ToString()].Valor;

            if (menuSession.Tag != null && traducciones.ContainsKey(menuSession.Tag.ToString()))
                menuSession.Text = traducciones[menuSession.Tag.ToString()].Valor;

            if (menuItemCerrarSession.Tag != null && traducciones.ContainsKey(menuItemCerrarSession.Tag.ToString()))
                menuItemCerrarSession.Text = traducciones[menuItemCerrarSession.Tag.ToString()].Valor;

        }
    }
}
