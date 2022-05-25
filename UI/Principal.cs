using BLL;
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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
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
    }
}
