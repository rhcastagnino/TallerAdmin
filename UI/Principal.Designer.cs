namespace UI
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuEmpleado = new System.Windows.Forms.ToolStripMenuItem();
            this.miRegistrarEmple = new System.Windows.Forms.ToolStripMenuItem();
            this.miAltaEmple = new System.Windows.Forms.ToolStripMenuItem();
            this.miBajaEmple = new System.Windows.Forms.ToolStripMenuItem();
            this.miModiEmple = new System.Windows.Forms.ToolStripMenuItem();
            this.miConsultarEmple = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOmnibus = new System.Windows.Forms.ToolStripMenuItem();
            this.miRegistrarOmnibus = new System.Windows.Forms.ToolStripMenuItem();
            this.miAltaOmni = new System.Windows.Forms.ToolStripMenuItem();
            this.miBajaOmni = new System.Windows.Forms.ToolStripMenuItem();
            this.miModiOmni = new System.Windows.Forms.ToolStripMenuItem();
            this.miConsultarOmni = new System.Windows.Forms.ToolStripMenuItem();
            this.miEstatus = new System.Windows.Forms.ToolStripMenuItem();
            this.miEvaluarOmni = new System.Windows.Forms.ToolStripMenuItem();
            this.causaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.altaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReparacion = new System.Windows.Forms.ToolStripMenuItem();
            this.miRegistrarRepa = new System.Windows.Forms.ToolStripMenuItem();
            this.miAltaRepa = new System.Windows.Forms.ToolStripMenuItem();
            this.miBajaRepa = new System.Windows.Forms.ToolStripMenuItem();
            this.miModiRepa = new System.Windows.Forms.ToolStripMenuItem();
            this.miConsultarRepa = new System.Windows.Forms.ToolStripMenuItem();
            this.miAsignarRepa = new System.Windows.Forms.ToolStripMenuItem();
            this.miSolicitarRepu = new System.Windows.Forms.ToolStripMenuItem();
            this.miSupervisar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRepuesto = new System.Windows.Forms.ToolStripMenuItem();
            this.miRegistrarRepuesto = new System.Windows.Forms.ToolStripMenuItem();
            this.altaToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.miConsultarRespuesto = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStock = new System.Windows.Forms.ToolStripMenuItem();
            this.miIngresos = new System.Windows.Forms.ToolStripMenuItem();
            this.miConsultar = new System.Windows.Forms.ToolStripMenuItem();
            this.miInventario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSolicitudes = new System.Windows.Forms.ToolStripMenuItem();
            this.miSolicitudes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.miRepoCostoxO = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIdioma = new System.Windows.Forms.ToolStripMenuItem();
            this.imIdiomaNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.P_miNuevoIdioma = new System.Windows.Forms.ToolStripMenuItem();
            this.miTraduccion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPermisos = new System.Windows.Forms.ToolStripMenuItem();
            this.miGestionPatentesFamilias = new System.Windows.Forms.ToolStripMenuItem();
            this.miGestionPermisosUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSession = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCerrarSession = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEmpleado,
            this.menuOmnibus,
            this.causaToolStripMenuItem,
            this.menuReparacion,
            this.menuRepuesto,
            this.menuStock,
            this.menuSolicitudes,
            this.menuReportes,
            this.menuIdioma,
            this.menuPermisos,
            this.menuSession});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuEmpleado
            // 
            this.menuEmpleado.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRegistrarEmple,
            this.miConsultarEmple});
            this.menuEmpleado.Name = "menuEmpleado";
            this.menuEmpleado.Size = new System.Drawing.Size(72, 20);
            this.menuEmpleado.Tag = "P_MenuEmpleado";
            this.menuEmpleado.Text = "Empleado";
            // 
            // miRegistrarEmple
            // 
            this.miRegistrarEmple.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAltaEmple,
            this.miBajaEmple,
            this.miModiEmple});
            this.miRegistrarEmple.Enabled = false;
            this.miRegistrarEmple.Name = "miRegistrarEmple";
            this.miRegistrarEmple.Size = new System.Drawing.Size(125, 22);
            this.miRegistrarEmple.Tag = "P_miRegistrarEmple";
            this.miRegistrarEmple.Text = "Registrar";
            // 
            // miAltaEmple
            // 
            this.miAltaEmple.Name = "miAltaEmple";
            this.miAltaEmple.Size = new System.Drawing.Size(125, 22);
            this.miAltaEmple.Tag = "P_miAltaEmple";
            this.miAltaEmple.Text = "Alta";
            // 
            // miBajaEmple
            // 
            this.miBajaEmple.Name = "miBajaEmple";
            this.miBajaEmple.Size = new System.Drawing.Size(125, 22);
            this.miBajaEmple.Tag = "P_miBajaEmple";
            this.miBajaEmple.Text = "Baja";
            // 
            // miModiEmple
            // 
            this.miModiEmple.Name = "miModiEmple";
            this.miModiEmple.Size = new System.Drawing.Size(125, 22);
            this.miModiEmple.Tag = "P_miModiEmple";
            this.miModiEmple.Text = "Modificar";
            // 
            // miConsultarEmple
            // 
            this.miConsultarEmple.Enabled = false;
            this.miConsultarEmple.Name = "miConsultarEmple";
            this.miConsultarEmple.Size = new System.Drawing.Size(125, 22);
            this.miConsultarEmple.Tag = "P_miConsultarEmple";
            this.miConsultarEmple.Text = "Consultar";
            // 
            // menuOmnibus
            // 
            this.menuOmnibus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRegistrarOmnibus,
            this.miConsultarOmni,
            this.miEstatus,
            this.miEvaluarOmni});
            this.menuOmnibus.Name = "menuOmnibus";
            this.menuOmnibus.Size = new System.Drawing.Size(68, 20);
            this.menuOmnibus.Tag = "P_MenuOmnibus";
            this.menuOmnibus.Text = "Omnibus";
            // 
            // miRegistrarOmnibus
            // 
            this.miRegistrarOmnibus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAltaOmni,
            this.miBajaOmni,
            this.miModiOmni});
            this.miRegistrarOmnibus.Enabled = false;
            this.miRegistrarOmnibus.Name = "miRegistrarOmnibus";
            this.miRegistrarOmnibus.Size = new System.Drawing.Size(125, 22);
            this.miRegistrarOmnibus.Tag = "P_miRegistrarOmnibus";
            this.miRegistrarOmnibus.Text = "Registrar";
            // 
            // miAltaOmni
            // 
            this.miAltaOmni.Name = "miAltaOmni";
            this.miAltaOmni.Size = new System.Drawing.Size(125, 22);
            this.miAltaOmni.Tag = "P_miAltaOmni";
            this.miAltaOmni.Text = "Alta";
            // 
            // miBajaOmni
            // 
            this.miBajaOmni.Name = "miBajaOmni";
            this.miBajaOmni.Size = new System.Drawing.Size(125, 22);
            this.miBajaOmni.Tag = "P_miBajaOmni";
            this.miBajaOmni.Text = "Baja";
            // 
            // miModiOmni
            // 
            this.miModiOmni.Name = "miModiOmni";
            this.miModiOmni.Size = new System.Drawing.Size(125, 22);
            this.miModiOmni.Tag = "P_miModiOmni";
            this.miModiOmni.Text = "Modificar";
            // 
            // miConsultarOmni
            // 
            this.miConsultarOmni.Enabled = false;
            this.miConsultarOmni.Name = "miConsultarOmni";
            this.miConsultarOmni.Size = new System.Drawing.Size(125, 22);
            this.miConsultarOmni.Tag = "P_miConsultarOmni";
            this.miConsultarOmni.Text = "Consultar";
            // 
            // miEstatus
            // 
            this.miEstatus.Enabled = false;
            this.miEstatus.Name = "miEstatus";
            this.miEstatus.Size = new System.Drawing.Size(125, 22);
            this.miEstatus.Tag = "P_miEstatus";
            this.miEstatus.Text = "Status";
            // 
            // miEvaluarOmni
            // 
            this.miEvaluarOmni.Enabled = false;
            this.miEvaluarOmni.Name = "miEvaluarOmni";
            this.miEvaluarOmni.Size = new System.Drawing.Size(125, 22);
            this.miEvaluarOmni.Tag = "P_miEvaluarOmni";
            this.miEvaluarOmni.Text = "Evaluar";
            // 
            // causaToolStripMenuItem
            // 
            this.causaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarToolStripMenuItem2,
            this.consultarToolStripMenuItem2});
            this.causaToolStripMenuItem.Enabled = false;
            this.causaToolStripMenuItem.Name = "causaToolStripMenuItem";
            this.causaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.causaToolStripMenuItem.Text = "Causa";
            this.causaToolStripMenuItem.Visible = false;
            // 
            // registrarToolStripMenuItem2
            // 
            this.registrarToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaToolStripMenuItem2,
            this.bajaToolStripMenuItem2,
            this.modificarToolStripMenuItem2});
            this.registrarToolStripMenuItem2.Enabled = false;
            this.registrarToolStripMenuItem2.Name = "registrarToolStripMenuItem2";
            this.registrarToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.registrarToolStripMenuItem2.Text = "Registrar";
            // 
            // altaToolStripMenuItem2
            // 
            this.altaToolStripMenuItem2.Name = "altaToolStripMenuItem2";
            this.altaToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.altaToolStripMenuItem2.Text = "Alta";
            // 
            // bajaToolStripMenuItem2
            // 
            this.bajaToolStripMenuItem2.Name = "bajaToolStripMenuItem2";
            this.bajaToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.bajaToolStripMenuItem2.Text = "Baja";
            // 
            // modificarToolStripMenuItem2
            // 
            this.modificarToolStripMenuItem2.Name = "modificarToolStripMenuItem2";
            this.modificarToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.modificarToolStripMenuItem2.Text = "Modificar";
            // 
            // consultarToolStripMenuItem2
            // 
            this.consultarToolStripMenuItem2.Enabled = false;
            this.consultarToolStripMenuItem2.Name = "consultarToolStripMenuItem2";
            this.consultarToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.consultarToolStripMenuItem2.Text = "Consultar";
            // 
            // menuReparacion
            // 
            this.menuReparacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRegistrarRepa,
            this.miConsultarRepa,
            this.miAsignarRepa,
            this.miSolicitarRepu,
            this.miSupervisar});
            this.menuReparacion.Name = "menuReparacion";
            this.menuReparacion.Size = new System.Drawing.Size(78, 20);
            this.menuReparacion.Tag = "P_MenuReparacion";
            this.menuReparacion.Text = "Reparacion";
            // 
            // miRegistrarRepa
            // 
            this.miRegistrarRepa.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAltaRepa,
            this.miBajaRepa,
            this.miModiRepa});
            this.miRegistrarRepa.Enabled = false;
            this.miRegistrarRepa.Name = "miRegistrarRepa";
            this.miRegistrarRepa.Size = new System.Drawing.Size(173, 22);
            this.miRegistrarRepa.Tag = "P_miRegistrarRepa";
            this.miRegistrarRepa.Text = "Registrar";
            // 
            // miAltaRepa
            // 
            this.miAltaRepa.Name = "miAltaRepa";
            this.miAltaRepa.Size = new System.Drawing.Size(187, 22);
            this.miAltaRepa.Tag = "P_miAltaRepa";
            this.miAltaRepa.Text = "Nueva Reparacion";
            // 
            // miBajaRepa
            // 
            this.miBajaRepa.Name = "miBajaRepa";
            this.miBajaRepa.Size = new System.Drawing.Size(187, 22);
            this.miBajaRepa.Tag = "P_miBajaRepa";
            this.miBajaRepa.Text = "Eliminar Reparacion";
            // 
            // miModiRepa
            // 
            this.miModiRepa.Name = "miModiRepa";
            this.miModiRepa.Size = new System.Drawing.Size(187, 22);
            this.miModiRepa.Tag = "P_miModiRepa";
            this.miModiRepa.Text = "Modificar Reparacion";
            // 
            // miConsultarRepa
            // 
            this.miConsultarRepa.Enabled = false;
            this.miConsultarRepa.Name = "miConsultarRepa";
            this.miConsultarRepa.Size = new System.Drawing.Size(173, 22);
            this.miConsultarRepa.Tag = "P_miConsultarRepa";
            this.miConsultarRepa.Text = "Consultar";
            // 
            // miAsignarRepa
            // 
            this.miAsignarRepa.Enabled = false;
            this.miAsignarRepa.Name = "miAsignarRepa";
            this.miAsignarRepa.Size = new System.Drawing.Size(173, 22);
            this.miAsignarRepa.Tag = "P_miAsignarRepa";
            this.miAsignarRepa.Text = "Asignar";
            // 
            // miSolicitarRepu
            // 
            this.miSolicitarRepu.Enabled = false;
            this.miSolicitarRepu.Name = "miSolicitarRepu";
            this.miSolicitarRepu.Size = new System.Drawing.Size(173, 22);
            this.miSolicitarRepu.Tag = "P_miSolicitarRepu";
            this.miSolicitarRepu.Text = "Solicitar Respuesto";
            // 
            // miSupervisar
            // 
            this.miSupervisar.Enabled = false;
            this.miSupervisar.Name = "miSupervisar";
            this.miSupervisar.Size = new System.Drawing.Size(173, 22);
            this.miSupervisar.Tag = "P_miSupervisar";
            this.miSupervisar.Text = "Supervisar";
            // 
            // menuRepuesto
            // 
            this.menuRepuesto.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRegistrarRepuesto,
            this.miConsultarRespuesto});
            this.menuRepuesto.Name = "menuRepuesto";
            this.menuRepuesto.Size = new System.Drawing.Size(68, 20);
            this.menuRepuesto.Tag = "P_MenuRepuesto";
            this.menuRepuesto.Text = "Repuesto";
            // 
            // miRegistrarRepuesto
            // 
            this.miRegistrarRepuesto.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaToolStripMenuItem4,
            this.bajaToolStripMenuItem4,
            this.modificarToolStripMenuItem4});
            this.miRegistrarRepuesto.Enabled = false;
            this.miRegistrarRepuesto.Name = "miRegistrarRepuesto";
            this.miRegistrarRepuesto.Size = new System.Drawing.Size(180, 22);
            this.miRegistrarRepuesto.Tag = "P_miRegistrarRepuesto";
            this.miRegistrarRepuesto.Text = "Registrar";
            this.miRegistrarRepuesto.Visible = false;
            // 
            // altaToolStripMenuItem4
            // 
            this.altaToolStripMenuItem4.Name = "altaToolStripMenuItem4";
            this.altaToolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.altaToolStripMenuItem4.Text = "Alta";
            // 
            // bajaToolStripMenuItem4
            // 
            this.bajaToolStripMenuItem4.Name = "bajaToolStripMenuItem4";
            this.bajaToolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.bajaToolStripMenuItem4.Text = "Baja";
            // 
            // modificarToolStripMenuItem4
            // 
            this.modificarToolStripMenuItem4.Name = "modificarToolStripMenuItem4";
            this.modificarToolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.modificarToolStripMenuItem4.Text = "Modificar";
            // 
            // miConsultarRespuesto
            // 
            this.miConsultarRespuesto.Enabled = false;
            this.miConsultarRespuesto.Name = "miConsultarRespuesto";
            this.miConsultarRespuesto.Size = new System.Drawing.Size(180, 22);
            this.miConsultarRespuesto.Tag = "P_miConsultarRespuesto";
            this.miConsultarRespuesto.Text = "Consultar";
            // 
            // menuStock
            // 
            this.menuStock.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miIngresos,
            this.miConsultar,
            this.miInventario});
            this.menuStock.Name = "menuStock";
            this.menuStock.Size = new System.Drawing.Size(48, 20);
            this.menuStock.Tag = "P_MenuStock";
            this.menuStock.Text = "Stock";
            // 
            // miIngresos
            // 
            this.miIngresos.Enabled = false;
            this.miIngresos.Name = "miIngresos";
            this.miIngresos.Size = new System.Drawing.Size(127, 22);
            this.miIngresos.Tag = "P_miIngresos";
            this.miIngresos.Text = "Ingresos";
            // 
            // miConsultar
            // 
            this.miConsultar.Enabled = false;
            this.miConsultar.Name = "miConsultar";
            this.miConsultar.Size = new System.Drawing.Size(127, 22);
            this.miConsultar.Tag = "P_miConsultar";
            this.miConsultar.Text = "Consultar";
            // 
            // miInventario
            // 
            this.miInventario.Enabled = false;
            this.miInventario.Name = "miInventario";
            this.miInventario.Size = new System.Drawing.Size(127, 22);
            this.miInventario.Tag = "P_miInventario";
            this.miInventario.Text = "Inventario";
            // 
            // menuSolicitudes
            // 
            this.menuSolicitudes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSolicitudes});
            this.menuSolicitudes.Enabled = false;
            this.menuSolicitudes.Name = "menuSolicitudes";
            this.menuSolicitudes.Size = new System.Drawing.Size(133, 20);
            this.menuSolicitudes.Tag = "P_MenuSolicitudes";
            this.menuSolicitudes.Text = "Solicitudes Repuestos";
            // 
            // miSolicitudes
            // 
            this.miSolicitudes.Name = "miSolicitudes";
            this.miSolicitudes.Size = new System.Drawing.Size(131, 22);
            this.miSolicitudes.Tag = "P_miSolicitudes";
            this.miSolicitudes.Text = "Solicitudes";
            // 
            // menuReportes
            // 
            this.menuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRepoCostoxO});
            this.menuReportes.Enabled = false;
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(65, 20);
            this.menuReportes.Tag = "P_MenuReportes";
            this.menuReportes.Text = "Reportes";
            // 
            // miRepoCostoxO
            // 
            this.miRepoCostoxO.Name = "miRepoCostoxO";
            this.miRepoCostoxO.Size = new System.Drawing.Size(178, 22);
            this.miRepoCostoxO.Tag = "P_miRepoCostoxO";
            this.miRepoCostoxO.Text = "Costo por Omnibus";
            // 
            // menuIdioma
            // 
            this.menuIdioma.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imIdiomaNuevo});
            this.menuIdioma.Enabled = false;
            this.menuIdioma.Name = "menuIdioma";
            this.menuIdioma.Size = new System.Drawing.Size(56, 20);
            this.menuIdioma.Tag = "P_menuIdioma";
            this.menuIdioma.Text = "Idioma";
            // 
            // imIdiomaNuevo
            // 
            this.imIdiomaNuevo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.P_miNuevoIdioma,
            this.miTraduccion});
            this.imIdiomaNuevo.Name = "imIdiomaNuevo";
            this.imIdiomaNuevo.Size = new System.Drawing.Size(116, 22);
            this.imIdiomaNuevo.Tag = "P_imIdiomaNuevo";
            this.imIdiomaNuevo.Text = "Agregar";
            // 
            // P_miNuevoIdioma
            // 
            this.P_miNuevoIdioma.Name = "P_miNuevoIdioma";
            this.P_miNuevoIdioma.Size = new System.Drawing.Size(149, 22);
            this.P_miNuevoIdioma.Tag = "P_miNuevoIdioma";
            this.P_miNuevoIdioma.Text = "Nuevo Idioma";
            this.P_miNuevoIdioma.Click += new System.EventHandler(this.P_miNuevoIdioma_Click);
            // 
            // miTraduccion
            // 
            this.miTraduccion.Name = "miTraduccion";
            this.miTraduccion.Size = new System.Drawing.Size(149, 22);
            this.miTraduccion.Tag = "P_miTraduccion";
            this.miTraduccion.Text = "Traducciones";
            this.miTraduccion.Click += new System.EventHandler(this.miTraduccion_Click);
            // 
            // menuPermisos
            // 
            this.menuPermisos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miGestionPatentesFamilias,
            this.miGestionPermisosUsuario});
            this.menuPermisos.Enabled = false;
            this.menuPermisos.Name = "menuPermisos";
            this.menuPermisos.Size = new System.Drawing.Size(67, 20);
            this.menuPermisos.Tag = "P_menuPermisos";
            this.menuPermisos.Text = "Permisos";
            // 
            // miGestionPatentesFamilias
            // 
            this.miGestionPatentesFamilias.Name = "miGestionPatentesFamilias";
            this.miGestionPatentesFamilias.Size = new System.Drawing.Size(210, 22);
            this.miGestionPatentesFamilias.Tag = "P_miGestionPatentesFamilias";
            this.miGestionPatentesFamilias.Text = "Gestion Patentes-Familias";
            this.miGestionPatentesFamilias.Click += new System.EventHandler(this.miGestionPatentesFamilias_Click);
            // 
            // miGestionPermisosUsuario
            // 
            this.miGestionPermisosUsuario.Name = "miGestionPermisosUsuario";
            this.miGestionPermisosUsuario.Size = new System.Drawing.Size(210, 22);
            this.miGestionPermisosUsuario.Tag = "P_miGestionPermisosUsuario";
            this.miGestionPermisosUsuario.Text = "Gestion Permisos-Usuario";
            this.miGestionPermisosUsuario.Click += new System.EventHandler(this.miGestionPermisosUsuario_Click);
            // 
            // menuSession
            // 
            this.menuSession.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCerrarSession});
            this.menuSession.Name = "menuSession";
            this.menuSession.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuSession.Size = new System.Drawing.Size(53, 20);
            this.menuSession.Tag = "P_MenuSession";
            this.menuSession.Text = "Sesion";
            // 
            // menuItemCerrarSession
            // 
            this.menuItemCerrarSession.Name = "menuItemCerrarSession";
            this.menuItemCerrarSession.Size = new System.Drawing.Size(143, 22);
            this.menuItemCerrarSession.Tag = "P_menuItemCerrarSession";
            this.menuItemCerrarSession.Text = "Cerrar Sesion";
            this.menuItemCerrarSession.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(472, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 65);
            this.label1.TabIndex = 1;
            this.label1.Text = "TallerAdmin";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TallerAdmin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Principal_FormClosed);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemCerrarSession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem menuEmpleado;
        private System.Windows.Forms.ToolStripMenuItem miRegistrarEmple;
        private System.Windows.Forms.ToolStripMenuItem miAltaEmple;
        private System.Windows.Forms.ToolStripMenuItem miBajaEmple;
        private System.Windows.Forms.ToolStripMenuItem miModiEmple;
        private System.Windows.Forms.ToolStripMenuItem miConsultarEmple;
        private System.Windows.Forms.ToolStripMenuItem menuOmnibus;
        private System.Windows.Forms.ToolStripMenuItem miRegistrarOmnibus;
        private System.Windows.Forms.ToolStripMenuItem miAltaOmni;
        private System.Windows.Forms.ToolStripMenuItem miBajaOmni;
        private System.Windows.Forms.ToolStripMenuItem miModiOmni;
        private System.Windows.Forms.ToolStripMenuItem miConsultarOmni;
        private System.Windows.Forms.ToolStripMenuItem miEstatus;
        private System.Windows.Forms.ToolStripMenuItem miEvaluarOmni;
        private System.Windows.Forms.ToolStripMenuItem causaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem altaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bajaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuReparacion;
        private System.Windows.Forms.ToolStripMenuItem miRegistrarRepa;
        private System.Windows.Forms.ToolStripMenuItem miAltaRepa;
        private System.Windows.Forms.ToolStripMenuItem miBajaRepa;
        private System.Windows.Forms.ToolStripMenuItem miModiRepa;
        private System.Windows.Forms.ToolStripMenuItem miConsultarRepa;
        private System.Windows.Forms.ToolStripMenuItem miAsignarRepa;
        private System.Windows.Forms.ToolStripMenuItem miSolicitarRepu;
        private System.Windows.Forms.ToolStripMenuItem miSupervisar;
        private System.Windows.Forms.ToolStripMenuItem menuRepuesto;
        private System.Windows.Forms.ToolStripMenuItem miRegistrarRepuesto;
        private System.Windows.Forms.ToolStripMenuItem altaToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem bajaToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem miConsultarRespuesto;
        private System.Windows.Forms.ToolStripMenuItem menuStock;
        private System.Windows.Forms.ToolStripMenuItem miIngresos;
        private System.Windows.Forms.ToolStripMenuItem miConsultar;
        private System.Windows.Forms.ToolStripMenuItem miInventario;
        private System.Windows.Forms.ToolStripMenuItem menuSolicitudes;
        private System.Windows.Forms.ToolStripMenuItem miSolicitudes;
        private System.Windows.Forms.ToolStripMenuItem menuReportes;
        private System.Windows.Forms.ToolStripMenuItem miRepoCostoxO;
        private System.Windows.Forms.ToolStripMenuItem menuIdioma;
        private System.Windows.Forms.ToolStripMenuItem imIdiomaNuevo;
        private System.Windows.Forms.ToolStripMenuItem P_miNuevoIdioma;
        private System.Windows.Forms.ToolStripMenuItem miTraduccion;
        private System.Windows.Forms.ToolStripMenuItem menuPermisos;
        private System.Windows.Forms.ToolStripMenuItem miGestionPatentesFamilias;
        private System.Windows.Forms.ToolStripMenuItem miGestionPermisosUsuario;
    }
}