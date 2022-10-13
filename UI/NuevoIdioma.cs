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
    public partial class NuevoIdioma : Form, IIdiomaObserver
    {
        public static IIdioma idioma;
    
        public NuevoIdioma()
        {
            InitializeComponent();
            Session.SuscribirObservador(this);
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir(idioma);
            CargarIdiomas();
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

        private void NuevoIdioma_Load(object sender, EventArgs e)
        {
            UpdateLanguage(Session.GetInstance.Usuario.Idioma);
        }

        private void CargarIdiomas()
        {
            dataIdiomas.Rows.Clear();
            var idiomas = Traductor.ObtenerIdiomas();

            dataIdiomas.Columns.Add("idoma", "Idioma");

            foreach (var idioma in idiomas)
            {
                dataIdiomas.Rows.Add(idioma.Nombre);
            }
            dataIdiomas.ColumnHeadersVisible = false;
            dataIdiomas.ReadOnly = true;
        }

        private void Limpiar()
        {
            txtNombre.Text = null;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string idioma= txtNombre.Text;
            AltaIdioma(idioma);
            CargarIdiomas();
            Limpiar();
        }

        private void AltaIdioma(string idio)
        {
            try
            {
                BE.Idioma idioma = new BE.Idioma();
                idioma.Nombre = idio.ToString();
                var xidiomas = Traductor.ObtenerIdiomas();

                foreach (var xidioma in xidiomas)
                {
                    if (xidioma.Nombre.ToLower() == idioma.Nombre.ToLower())
                    {
                        throw new Exception($"El idioma {idioma.Nombre} a ingresar ya existe");
                    }
                }
                BLL.IdiomaBLL idiomaBLL = new BLL.IdiomaBLL();
                idiomaBLL.AltaIdioma(idioma);
                MessageBox.Show($"Idioma {idioma.Nombre} ingresado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NuevoIdioma_FormClosed(object sender, FormClosedEventArgs e)
        {
            Principal formPrincipal = new Principal();
            formPrincipal.Show();
            Session.DesuscribirObservador(this);
        }

    }
}
