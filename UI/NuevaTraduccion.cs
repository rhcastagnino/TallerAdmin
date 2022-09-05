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
    public partial class NuevaTraduccion : Form, IIdiomaObserver
    {
        public static IIdioma idioma;
        public NuevaTraduccion()
        {
            InitializeComponent();
            Session.SuscribirObservador(this);
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Traducir(idioma);
        }

        private void CargarIdiomas()
        {
            cbIdioma.Items.Clear();
            var idiomas = Traductor.ObtenerIdiomas();

            foreach (var idioma in idiomas)
            {
                cbIdioma.Items.Add(idioma.Nombre);
            }
        }

        private void CargarEtiquetas()
        {
            cbEtiquetas.Items.Clear();
            var etiquetas = Traductor.ObtenerEtiquetas();

            foreach (var eti in etiquetas)
            {
                cbEtiquetas.Items.Add(eti.Clave);
            }
        }

        private void Traducir(IIdioma idioma)
        {
            try
            {
                var traducciones = Traductor.ObtenerTraducciones(idioma);
                var tradDefault = Traductor.ObtenerTraducciones(Traductor.ObtenerIdiomaDefault());

                foreach (Control mnuitOpcion in this.Controls)
                {
                    if (mnuitOpcion.Tag != null && traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                        //if (traducciones[mnuitOpcion.Tag.ToString()].Valor != null)
                    {
                        mnuitOpcion.Text = traducciones[mnuitOpcion.Tag.ToString()].Valor;
                    }
                    else if (mnuitOpcion.Tag != null && !traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    {
                        mnuitOpcion.Text = tradDefault[mnuitOpcion.Tag.ToString()].Valor;
                        //mnuitOpcion.Text = $"{mnuitOpcion.Tag}_NT";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la traduccion del nuevo idioma");
            }
        }

        private void NuevaTraduccion_Load(object sender, EventArgs e)
        {
            UpdateLanguage(Session.GetInstance.Usuario.Idioma);
            CargarIdiomas();
            CargarEtiquetas();
            CargarReferencia();
            Limpiar();
        }

        private void Limpiar()
        {
            txtValor.Text = null;
        }

        private void CargarReferencia()
        {
            dgwReferencias.DataSource = null;
            dgwReferencias.DataSource = Traductor.ObtenerReferenciasDTO(Traductor.ObtenerIdiomaDefault());
            dgwReferencias.ColumnHeadersVisible = false;
            dgwReferencias.ReadOnly = true;

            if (cbIdioma.SelectedIndex == -1)
            {
                idioma = Session.GetInstance.Usuario.Idioma;
            }
            else
            {
                idioma.Id = cbIdioma.SelectedIndex;
                idioma.Id += 1;
            }
                       
            dgwIdioma.DataSource = null;
            dgwIdioma.DataSource = Traductor.ObtenerReferenciasDTO(idioma);
            dgwIdioma.ColumnHeadersVisible = false;
            dgwIdioma.ReadOnly = true;
        }

        private void cbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReferencia();
        }

        private void btnTraducir_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbIdioma.SelectedIndex == -1)
                {
                    throw new Exception("Elija un idioma en el desplegables de idioma");
                }
                else
                {
                    BE.Idioma idioma = new BE.Idioma();
                    idioma.Id = cbIdioma.SelectedIndex;
                    idioma.Id += 1;

                    BE.Traduccion traduccion = new BE.Traduccion();
                    IEtiqueta etiqueta = new BE.Etiqueta();
                    etiqueta.Clave = cbEtiquetas.SelectedItem.ToString();
                    if (etiqueta.Clave != null)
                    {
                        var etiquetas = Traductor.ObtenerReferenciasDTO(idioma);
                        foreach (var t in etiquetas)
                        {
                            if (t.Clave == etiqueta.Clave)
                            {
                                throw new Exception("Ya existe un valor para la etiqueta seleccionada");
                            }
                        }
                    }

                    traduccion.Etiqueta = (IEtiqueta)etiqueta;
                    traduccion.Valor = txtValor.Text;

                    BLL.TraduccionBLL traduccionBLL = new BLL.TraduccionBLL();
                    traduccionBLL.AltaTraduccion(idioma,traduccion);
                    MessageBox.Show("Se ingreso correctamente la traduccion de la etiqueta");
                    CargarReferencia();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void cbEtiquetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbEtiquetas.SelectedItem.ToString();
        }

        private void NuevaTraduccion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Principal formPrincipal = new Principal();
            formPrincipal.Show();

        }


    }
}
