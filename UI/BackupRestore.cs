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
    public partial class BackupRestore : Form, IIdiomaObserver
    {
        public static IIdioma idioma;
        public BackupRestore()
        {
            InitializeComponent();
            Session.SuscribirObservador(this);  
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir(idioma);
        }

        private void BackupRestore_Load(object sender, EventArgs e)
        {
            UpdateLanguage(Session.GetInstance.Usuario.Idioma);
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

            }
        }

        private void Limpiar()
        {
            txtDirBackup.Clear();
            txtDirRestore.Clear();
        }

        private void btnDirBackup_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog();
                dlg.Description = "Backup Database";
                dlg.UseDescriptionForTitle = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtDirBackup.Text = dlg.SelectedPath;
                    btnBackup.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDirBackup.Text == string.Empty)
                {
                    MessageBox.Show("Por favor ingrese la ubicación del archivo de respaldo");
                }
                else
                {
                    Servicios.ServiceBackupRestore.BackupBD(txtDirBackup.Text);
                    btnBackup.Enabled = false;
                    Limpiar();
                    MessageBox.Show("Backup Realizado Correctamente :P");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDirRestore_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "SQL SERVER database backup files|*.bak";
                dlg.Title = "Database restore";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtDirRestore.Text = dlg.FileName;
                    btnRestore.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDirRestore.Text == string.Empty)
                {
                    MessageBox.Show("Por favor ingrese la ubicación del archivo de respaldo");
                }
                else
                {
                    Servicios.ServiceBackupRestore.RestoreBD(txtDirRestore.Text);
                    btnRestore.Enabled = false;
                    Limpiar();
                    MessageBox.Show("Restore realizado Correctamente");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackupRestore_FormClosed(object sender, FormClosedEventArgs e)
        {
            Principal formPrincipal = new Principal();
            formPrincipal.Show();
            Session.DesuscribirObservador(this);
        }
    }
}
