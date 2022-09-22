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
                //if (menuStrip1.Items[ToolStripDropDownItem.Equals(p)] ) 
                //if (p.Permiso == "EmpleadoConsultar")
                //if (p.Permiso == "OmnibusABM")
                //if (p.Permiso == "OmnibusConsultar")
                //if (p.Permiso == "OmnibusStatus")
                //if (p.Permiso == "OmnibusEvaluar")
                //if (p.Permiso == "ReparacionABM")
                //if (p.Permiso == "ReparacionConsultar")
                //if (p.Permiso == "ReparacionAsignar")
                //if (p.Permiso == "ReparacionSoliRepu")
                //if (p.Permiso == "ReparacionSupervisar")
                //if (p.Permiso == "RepuestoABM")
                //if (p.Permiso == "RepuestoConsultar")
                //if (p.Permiso == "StockIngresos")
                //if (p.Permiso == "StockInventario")
                //if (p.Permiso == "StockConsultar")
                //if (p.Permiso == "Solicitudes")
                //if (p.Permiso == "CostosOmnibus")
                //if (p.Permiso == "AsignarFamiliaPatente")
                //if (p.Permiso == "ManagerIdioma")

//create procedure TraerPermisosUsuario
//@idUsuario int
//as
//begin
//WITH RECURSIVO AS(SELECT fp.idPermisoPadre, fp.idPermisoHijo FROM Familia_Patente fp WHERE fp.idPermisoPadre = (select idPermiso from Usuario_Permiso where idUsuario = @idUsuario )
//UNION ALL SELECT fp2.idPermisoPadre, fp2.idPermisoHijo FROM Familia_Patente fp2 INNER JOIN RECURSIVO r on r.idPermisoHijo = fp2.idPermisoPadre)
//SELECT p.Permiso FROM RECURSIVO r INNER JOIN Permiso p on r.idPermisoHijo = p.id where p.permiso is not null;
//end
            }

        }
    }
}
