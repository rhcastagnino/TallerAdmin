namespace UI
{
    partial class FamiliaPatente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FamiliaPatente));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNuevaFamilia = new System.Windows.Forms.Label();
            this.lblNombreNuevaFamilia = new System.Windows.Forms.Label();
            this.lblFamilias = new System.Windows.Forms.Label();
            this.tree = new System.Windows.Forms.TreeView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblNuevoPermiso = new System.Windows.Forms.Label();
            this.lblNombreNuevoPermiso = new System.Windows.Forms.Label();
            this.lblPatentes = new System.Windows.Forms.Label();
            this.comboFamilias = new System.Windows.Forms.ComboBox();
            this.comboPatentes = new System.Windows.Forms.ComboBox();
            this.comboPermisos = new System.Windows.Forms.ComboBox();
            this.txtFamilia = new System.Windows.Forms.TextBox();
            this.txtPermiso = new System.Windows.Forms.TextBox();
            this.btnGuardarFamilia = new System.Windows.Forms.Button();
            this.btnConfFam = new System.Windows.Forms.Button();
            this.btnAgregarPatente = new System.Windows.Forms.Button();
            this.btnGuardaPermiso = new System.Windows.Forms.Button();
            this.btnAgregarFamilia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(239, 36);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(83, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Tag = "FP_lblTitulo";
            this.lblTitulo.Text = "label1";
            // 
            // lblNuevaFamilia
            // 
            this.lblNuevaFamilia.AutoSize = true;
            this.lblNuevaFamilia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNuevaFamilia.Location = new System.Drawing.Point(72, 126);
            this.lblNuevaFamilia.Name = "lblNuevaFamilia";
            this.lblNuevaFamilia.Size = new System.Drawing.Size(40, 15);
            this.lblNuevaFamilia.TabIndex = 1;
            this.lblNuevaFamilia.Tag = "FP_lblNuevaFamilia";
            this.lblNuevaFamilia.Text = "label1";
            // 
            // lblNombreNuevaFamilia
            // 
            this.lblNombreNuevaFamilia.AutoSize = true;
            this.lblNombreNuevaFamilia.Location = new System.Drawing.Point(72, 150);
            this.lblNombreNuevaFamilia.Name = "lblNombreNuevaFamilia";
            this.lblNombreNuevaFamilia.Size = new System.Drawing.Size(38, 15);
            this.lblNombreNuevaFamilia.TabIndex = 2;
            this.lblNombreNuevaFamilia.Tag = "FP_lblNombreNuevaFamilia";
            this.lblNombreNuevaFamilia.Text = "label2";
            // 
            // lblFamilias
            // 
            this.lblFamilias.AutoSize = true;
            this.lblFamilias.Location = new System.Drawing.Point(274, 150);
            this.lblFamilias.Name = "lblFamilias";
            this.lblFamilias.Size = new System.Drawing.Size(38, 15);
            this.lblFamilias.TabIndex = 3;
            this.lblFamilias.Tag = "FP_lblFamilias";
            this.lblFamilias.Text = "label3";
            // 
            // tree
            // 
            this.tree.Location = new System.Drawing.Point(449, 111);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(321, 284);
            this.tree.TabIndex = 4;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(565, 401);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(88, 37);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Tag = "FP_btnGuardar";
            this.btnGuardar.Text = "button1";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblNuevoPermiso
            // 
            this.lblNuevoPermiso.AutoSize = true;
            this.lblNuevoPermiso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNuevoPermiso.Location = new System.Drawing.Point(72, 275);
            this.lblNuevoPermiso.Name = "lblNuevoPermiso";
            this.lblNuevoPermiso.Size = new System.Drawing.Size(40, 15);
            this.lblNuevoPermiso.TabIndex = 6;
            this.lblNuevoPermiso.Tag = "FP_lblNuevoPermiso";
            this.lblNuevoPermiso.Text = "label4";
            // 
            // lblNombreNuevoPermiso
            // 
            this.lblNombreNuevoPermiso.AutoSize = true;
            this.lblNombreNuevoPermiso.Location = new System.Drawing.Point(72, 327);
            this.lblNombreNuevoPermiso.Name = "lblNombreNuevoPermiso";
            this.lblNombreNuevoPermiso.Size = new System.Drawing.Size(38, 15);
            this.lblNombreNuevoPermiso.TabIndex = 7;
            this.lblNombreNuevoPermiso.Tag = "FP_lblNombreNuevoPermiso";
            this.lblNombreNuevoPermiso.Text = "label5";
            // 
            // lblPatentes
            // 
            this.lblPatentes.AutoSize = true;
            this.lblPatentes.Location = new System.Drawing.Point(274, 275);
            this.lblPatentes.Name = "lblPatentes";
            this.lblPatentes.Size = new System.Drawing.Size(38, 15);
            this.lblPatentes.TabIndex = 8;
            this.lblPatentes.Tag = "FP_lblPatentes";
            this.lblPatentes.Text = "label6";
            // 
            // comboFamilias
            // 
            this.comboFamilias.FormattingEnabled = true;
            this.comboFamilias.Location = new System.Drawing.Point(239, 174);
            this.comboFamilias.Name = "comboFamilias";
            this.comboFamilias.Size = new System.Drawing.Size(168, 23);
            this.comboFamilias.TabIndex = 9;
            // 
            // comboPatentes
            // 
            this.comboPatentes.FormattingEnabled = true;
            this.comboPatentes.Location = new System.Drawing.Point(239, 298);
            this.comboPatentes.Name = "comboPatentes";
            this.comboPatentes.Size = new System.Drawing.Size(168, 23);
            this.comboPatentes.TabIndex = 10;
            // 
            // comboPermisos
            // 
            this.comboPermisos.FormattingEnabled = true;
            this.comboPermisos.Location = new System.Drawing.Point(29, 298);
            this.comboPermisos.Name = "comboPermisos";
            this.comboPermisos.Size = new System.Drawing.Size(168, 23);
            this.comboPermisos.TabIndex = 11;
            // 
            // txtFamilia
            // 
            this.txtFamilia.Location = new System.Drawing.Point(29, 174);
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.Size = new System.Drawing.Size(168, 23);
            this.txtFamilia.TabIndex = 12;
            // 
            // txtPermiso
            // 
            this.txtPermiso.Location = new System.Drawing.Point(29, 348);
            this.txtPermiso.Name = "txtPermiso";
            this.txtPermiso.Size = new System.Drawing.Size(168, 23);
            this.txtPermiso.TabIndex = 13;
            // 
            // btnGuardarFamilia
            // 
            this.btnGuardarFamilia.Location = new System.Drawing.Point(76, 203);
            this.btnGuardarFamilia.Name = "btnGuardarFamilia";
            this.btnGuardarFamilia.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarFamilia.TabIndex = 14;
            this.btnGuardarFamilia.Tag = "FP_btnGuardarFamilia";
            this.btnGuardarFamilia.Text = "button2";
            this.btnGuardarFamilia.UseVisualStyleBackColor = true;
            this.btnGuardarFamilia.Click += new System.EventHandler(this.btnGuardarFamilia_Click);
            // 
            // btnConfFam
            // 
            this.btnConfFam.Location = new System.Drawing.Point(239, 203);
            this.btnConfFam.Name = "btnConfFam";
            this.btnConfFam.Size = new System.Drawing.Size(75, 23);
            this.btnConfFam.TabIndex = 15;
            this.btnConfFam.Tag = "FP_btnConfFam";
            this.btnConfFam.Text = "button3";
            this.btnConfFam.UseVisualStyleBackColor = true;
            this.btnConfFam.Click += new System.EventHandler(this.btnConfFam_Click);
            // 
            // btnAgregarPatente
            // 
            this.btnAgregarPatente.Location = new System.Drawing.Point(286, 327);
            this.btnAgregarPatente.Name = "btnAgregarPatente";
            this.btnAgregarPatente.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarPatente.TabIndex = 16;
            this.btnAgregarPatente.Tag = "FP_btnAgregarPatente";
            this.btnAgregarPatente.Text = "button4";
            this.btnAgregarPatente.UseVisualStyleBackColor = true;
            this.btnAgregarPatente.Click += new System.EventHandler(this.btnAgregarPatente_Click);
            // 
            // btnGuardaPermiso
            // 
            this.btnGuardaPermiso.Location = new System.Drawing.Point(76, 377);
            this.btnGuardaPermiso.Name = "btnGuardaPermiso";
            this.btnGuardaPermiso.Size = new System.Drawing.Size(75, 23);
            this.btnGuardaPermiso.TabIndex = 17;
            this.btnGuardaPermiso.Tag = "FP_btnGuardaPermiso";
            this.btnGuardaPermiso.Text = "button5";
            this.btnGuardaPermiso.UseVisualStyleBackColor = true;
            this.btnGuardaPermiso.Click += new System.EventHandler(this.btnGuardaPermiso_Click);
            // 
            // btnAgregarFamilia
            // 
            this.btnAgregarFamilia.Location = new System.Drawing.Point(332, 203);
            this.btnAgregarFamilia.Name = "btnAgregarFamilia";
            this.btnAgregarFamilia.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarFamilia.TabIndex = 18;
            this.btnAgregarFamilia.Tag = "FP_btnAgregarFamilia";
            this.btnAgregarFamilia.Text = "button6";
            this.btnAgregarFamilia.UseVisualStyleBackColor = true;
            this.btnAgregarFamilia.Click += new System.EventHandler(this.btnAgregarFamilia_Click);
            // 
            // FamiliaPatente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAgregarFamilia);
            this.Controls.Add(this.btnGuardaPermiso);
            this.Controls.Add(this.btnAgregarPatente);
            this.Controls.Add(this.btnConfFam);
            this.Controls.Add(this.btnGuardarFamilia);
            this.Controls.Add(this.txtPermiso);
            this.Controls.Add(this.txtFamilia);
            this.Controls.Add(this.comboPermisos);
            this.Controls.Add(this.comboPatentes);
            this.Controls.Add(this.comboFamilias);
            this.Controls.Add(this.lblPatentes);
            this.Controls.Add(this.lblNombreNuevoPermiso);
            this.Controls.Add(this.lblNuevoPermiso);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tree);
            this.Controls.Add(this.lblFamilias);
            this.Controls.Add(this.lblNombreNuevaFamilia);
            this.Controls.Add(this.lblNuevaFamilia);
            this.Controls.Add(this.lblTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FamiliaPatente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TallerAdmin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FamiliaPatente_FormClosed);
            this.Load += new System.EventHandler(this.FamiliaPatente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNuevaFamilia;
        private System.Windows.Forms.Label lblNombreNuevaFamilia;
        private System.Windows.Forms.Label lblFamilias;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblNuevoPermiso;
        private System.Windows.Forms.Label lblNombreNuevoPermiso;
        private System.Windows.Forms.Label lblPatentes;
        private System.Windows.Forms.ComboBox comboFamilias;
        private System.Windows.Forms.ComboBox comboPatentes;
        private System.Windows.Forms.ComboBox comboPermisos;
        private System.Windows.Forms.TextBox txtFamilia;
        private System.Windows.Forms.TextBox txtPermiso;
        private System.Windows.Forms.Button btnGuardarFamilia;
        private System.Windows.Forms.Button btnConfFam;
        private System.Windows.Forms.Button btnAgregarPatente;
        private System.Windows.Forms.Button btnGuardaPermiso;
        private System.Windows.Forms.Button btnAgregarFamilia;
    }
}