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
    public partial class Login : Form
    {
        BE.Usuario usuario = new BE.Usuario();
        BLL.UsuarioBLL usuarioBLL = new BLL.UsuarioBLL();

        public Login()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void Login_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string pass = txtPass.Text;
                usuarioBLL.Login(email, pass);
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
            this.Hide();
            AltaUsuario formAltaUsuario = new AltaUsuario();
            formAltaUsuario.Show();
        }


        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Limpiar()
        {
            txtPass.Clear();
            txtEmail.Clear();
        }
    }
}
