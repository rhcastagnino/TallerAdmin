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
    public partial class AltaUsuario : Form
    {
        public AltaUsuario()
        {
            InitializeComponent();
        }

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {

            try
            {
                BE.Usuario usuario = new BE.Usuario();
                usuario.email = txtEmail.Text;
                usuario.password = txtPass.Text;
                usuario.nombre = txtNombre.Text;
                usuario.apellido = txtApellido.Text;

                BLL.UsuarioBLL usuarioBLL = new BLL.UsuarioBLL();
                usuarioBLL.altaUsario(usuario);
                MessageBox.Show($"Se registró correctamente al usuario {usuario.apellido} {usuario.nombre}, por favor ingresar al sistema");

                this.Hide();
                Login formLogin = new Login();
                formLogin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AltaUsuario_Load(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtEmail.Clear();
            txtPass.Clear();
        }

        private void AltaUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login formLogin = new Login();
            formLogin.Show();
        }
    }
}
