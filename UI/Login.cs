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

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string pass = txtPass.Text;
                usuarioBLL.Login(email, pass);                
                MessageBox.Show($"Ingreso correctamente al usuario {email}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            AltaUsuario formAltaUsuario = new AltaUsuario();
            formAltaUsuario.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPass.Clear();
            txtEmail.Clear();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
