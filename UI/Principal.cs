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
            //CargarMenuPermisos();
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
            Session.DesuscribirObservador(this);
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
            try
            {
                var lista = new List<Patente>();
                permisoBLL = new PermisoBLL();
                int idUsr = Session.GetInstance.Usuario.Id;
                lista = (List<Patente>)permisoBLL.CargarMenuPermisos(idUsr);

                foreach (var p in lista)
                {
                    foreach (ToolStripMenuItem mnuitOpcion in this.menuStrip1.Items)
                    {
                        foreach (ToolStripMenuItem miitem in mnuitOpcion.DropDownItems)
                        {
                            if (miitem.Tag != null)
                            {
                                if (p.Permiso.ToString() == "EmpleadoABM" && miitem.Tag.Equals("P_miRegistrarEmple")) miitem.Visible = true;
                                if (p.Permiso.ToString() == "EmpleadoConsultar" && miitem.Tag.Equals("P_miConsultarEmple")) miitem.Visible = true;
                                if (p.Permiso.ToString() == "OmnibusABM" && miitem.Tag.Equals("P_miRegistrarOmnibus")) miitem.Visible = true;
                                if (p.Permiso.ToString() == "OmnibusConsultar" && miitem.Tag.Equals("P_miConsultarOmni")) miitem.Visible = true;
                                if (p.Permiso.ToString() == "OmnibusStatus" && miitem.Tag.Equals("P_miEstatus")) miitem.Visible = true;
                                if (p.Permiso.ToString() == "OmnibusEvaluar" && miitem.Tag.Equals("P_miEvaluarOmni")) miitem.Visible = true;
                                if (p.Permiso.ToString() == "ReparacionABM" && miitem.Tag.Equals("P_miRegistrarRepa")) miitem.Visible = true;
                                if (p.Permiso.ToString() == "ReparacionConsultar" && miitem.Tag.Equals("P_miConsultarRepa")) miitem.Visible = true;
                                if (p.Permiso.ToString() == "ReparacionAsignar" && miitem.Tag.Equals("P_miAsignarRepa")) miitem.Visible = true;
                                if (p.Permiso.ToString() == "ReparacionSoliRepu" && miitem.Tag.Equals("P_miSolicitarRepu")) miitem.Visible = true;
                                if (p.Permiso.ToString() == "ReparacionSupervisar" && miitem.Tag.Equals("P_miSupervisar")) miitem.Visible = true;
                                //if (p.Permiso.ToString() =="RepuestoABM" && miitem.Tag.Equals("P_miRegistrarRepuesto")) miitem.Visible = true;
                                if (p.Permiso.ToString() == "RepuestoConsultar" && miitem.Tag.Equals("P_miConsultarRespuesto")) miitem.Visible = true;
                                if (p.Permiso.ToString() == "StockIngresos" && miitem.Tag.Equals("P_miIngresos")) miitem.Visible = true;
                                if (p.Permiso.ToString() == "StockInventario" && miitem.Tag.Equals("P_miConsultar")) miitem.Visible = true;
                                if (p.Permiso.ToString() == "StockConsultar" && miitem.Tag.Equals("P_miInventario")) miitem.Visible = true;
                                if (p.Permiso.ToString() == "ManagerIdioma" && miitem.Tag.Equals("P_imIdiomaNuevo")) miitem.Visible = true;
                            }
                        }

                        if (mnuitOpcion.Tag != null)
                        {
                            if (p.Permiso.ToString() == "Solicitudes" && mnuitOpcion.Tag.Equals("P_MenuSolicitudes")) mnuitOpcion.Visible = true;
                            if (p.Permiso.ToString() == "CostosOmnibus" && mnuitOpcion.Tag.Equals("P_MenuReportes")) mnuitOpcion.Visible = true;
                            if (p.Permiso.ToString() == "AsignarFamiliaPatente" && mnuitOpcion.Tag.Equals("P_menuPermisos")) mnuitOpcion.Visible = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupRestore form_BR = new BackupRestore();
            form_BR.Show();
            this.Hide();
        }


    }
}
