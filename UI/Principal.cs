using BE;
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
        public static IIdioma idioma;
        private PermisoBLL permisoBLL;
        public Principal()
        {
            InitializeComponent();
            UpdateLanguage(Session.GetInstance.Usuario.Idioma);
            Session.SuscribirObservador(this);
            //MostrarIdiomasDisponibles();
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
            var tradDefault = Traductor.ObtenerTraducciones(Traductor.ObtenerIdiomaDefault());

            foreach (ToolStripMenuItem mnuitOpcion in this.menuStrip1.Items)
            {
                if (mnuitOpcion.Tag != null && traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    mnuitOpcion.Text = traducciones[mnuitOpcion.Tag.ToString()].Valor;
                else if (mnuitOpcion.Tag != null && !traducciones.ContainsKey(mnuitOpcion.Tag.ToString()))
                    mnuitOpcion.Text = tradDefault[mnuitOpcion.Tag.ToString()].Valor;
                    // mnuitOpcion.Text = $"{mnuitOpcion.Tag}_NT";

                if (mnuitOpcion.DropDownItems.Count > 0)
                {
                    foreach (ToolStripMenuItem miitem in mnuitOpcion.DropDownItems)
                    {
                        if (miitem.Tag != null && traducciones.ContainsKey(miitem.Tag.ToString()))
                            miitem.Text = traducciones[miitem.Tag.ToString()].Valor;
                        else if (miitem.Tag != null && !traducciones.ContainsKey(miitem.Tag.ToString()))
                            if (miitem.Tag.ToString() != "BE.Idioma")
                                miitem.Text = tradDefault[miitem.Tag.ToString()].Valor;
                                //miitem.Text = $"{miitem.Tag}_NT";

                        if (miitem.DropDownItems.Count > 0)
                        {
                            foreach (ToolStripMenuItem otroitem in miitem.DropDownItems)

                                if (otroitem.Tag != null && traducciones.ContainsKey(otroitem.Tag.ToString()))
                                    otroitem.Text = traducciones[otroitem.Tag.ToString()].Valor;
                                else if (otroitem.Tag != null && !traducciones.ContainsKey(otroitem.Tag.ToString()))
                                    otroitem.Text = tradDefault[otroitem.Tag.ToString()].Valor;
                                    //otroitem.Text = $"{otroitem.Tag}_NT";
                        }
                    } 
                }
            }
        }

        private void idioma_Click(object sender, EventArgs e)
        {
            Session.CambiarIdioma((IIdioma)((ToolStripMenuItem)sender).Tag);
            idioma = (IIdioma)((ToolStripMenuItem)sender).Tag;
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

        private void P_miNuevoIdioma_Click(object sender, EventArgs e)
        {
            NuevoIdioma formNuevoIdioma = new NuevoIdioma();
            formNuevoIdioma.Show();
            this.Hide();
        }

        private void miTraduccion_Click(object sender, EventArgs e)
        {
            NuevaTraduccion formNuevaTraduccion = new NuevaTraduccion();
            formNuevaTraduccion.Show();
            this.Hide();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            UpdateLanguage(Session.GetInstance.Usuario.Idioma);
            MostrarIdiomasDisponibles();
            CargarMenuPermisos();
        }

        private void miGestionPermisosUsuario_Click(object sender, EventArgs e)
        {
            PermisosUsuario formPermisosUsuario = new PermisosUsuario();   
            formPermisosUsuario.Show();
            this.Hide();
        }

        private void miGestionPatentesFamilias_Click(object sender, EventArgs e)
        {
            FamiliaPatente formFamiliaPatente = new FamiliaPatente();
            formFamiliaPatente.Show();
            this.Hide();
        }

        private void CargarMenuPermisos()
        {
            IList<BE.Patente> lista = new List<BE.Patente>();
            lista = permisoBLL.CargarMenuPermisos(Session.GetInstance.Usuario.Id);

            foreach (var p in lista)
            {
                foreach (ToolStripMenuItem mnuitOpcion in this.menuStrip1.Items)
                {
                    foreach (ToolStripMenuItem miitem in mnuitOpcion.DropDownItems)
                    {
                        if (p.Permiso.Equals("EmpleadoABM"))
                            if (miitem.Tag.Equals("P_miRegistrarEmple")) miitem.Enabled = true;
                        if (p.Permiso.Equals("EmpleadoConsultar"))
                            if (miitem.Tag.Equals("P_miConsultarEmple")) miitem.Enabled = true;
                        if (p.Permiso.Equals("OmnibusABM"))
                            if (miitem.Tag.Equals("P_miRegistrarOmnibus")) miitem.Enabled = true;
                        if (p.Permiso.Equals("OmnibusConsultar"))
                            if (miitem.Tag.Equals("P_miConsultarOmni")) miitem.Enabled = true;
                        if (p.Permiso.Equals("OmnibusStatus"))
                            if (miitem.Tag.Equals("P_miEstatus")) miitem.Enabled = true;
                        if (p.Permiso.Equals("OmnibusEvaluar"))
                            if (miitem.Tag.Equals("P_miEvaluarOmni")) miitem.Enabled = true;
                        if (p.Permiso.Equals("ReparacionABM"))
                            if (miitem.Tag.Equals("P_miRegistrarRepa")) miitem.Enabled = true;
                        if (p.Permiso.Equals("ReparacionConsultar"))
                            if (miitem.Tag.Equals("P_miConsultarRepa")) miitem.Enabled = true;
                        if (p.Permiso.Equals("ReparacionAsignar"))
                            if (miitem.Tag.Equals("P_miAsignarRepa")) miitem.Enabled = true;
                        if (p.Permiso.Equals("ReparacionSoliRepu"))
                            if (miitem.Tag.Equals("P_miSolicitarRepu")) miitem.Enabled = true;
                        if (p.Permiso.Equals("ReparacionSupervisar"))
                            if (miitem.Tag.Equals("P_miSupervisar")) miitem.Enabled = true;
                        //if (p.Permiso.Equals("RepuestoABM"))
                        //    if (miitem.Tag.Equals("P_miRegistrarRepuesto")) miitem.Enabled = true;
                        if (p.Permiso.Equals("RepuestoConsultar"))
                            if (miitem.Tag.Equals("P_miConsultarRespuesto")) miitem.Enabled = true;
                        if (p.Permiso.Equals("StockIngresos"))
                            if (miitem.Tag.Equals("P_miIngresos")) miitem.Enabled = true;
                        if (p.Permiso.Equals("StockInventario"))
                            if (miitem.Tag.Equals("P_miConsultar")) miitem.Enabled = true;
                        if (p.Permiso.Equals("StockConsultar"))
                            if (miitem.Tag.Equals("P_miInventario")) miitem.Enabled = true;

                    }

                    if (p.Permiso.Equals("Solicitudes"))
                        if (mnuitOpcion.Tag.Equals("P_MenuSolicitudes")) mnuitOpcion.Enabled = true;
                    if (p.Permiso.Equals("CostosOmnibus"))
                        if (mnuitOpcion.Tag.Equals("P_MenuReportes")) mnuitOpcion.Enabled = true;
                    if (p.Permiso.Equals("AsignarFamiliaPatente"))
                        if (mnuitOpcion.Tag.Equals("P_menuPermisos")) mnuitOpcion.Enabled = true;
                    if (p.Permiso.Equals("ManagerIdioma"))
                        if (mnuitOpcion.Tag.Equals("P_menuIdioma")) mnuitOpcion.Enabled = true;

                }

            }
        }
    }
}
