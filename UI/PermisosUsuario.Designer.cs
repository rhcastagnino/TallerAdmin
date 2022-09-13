namespace UI
{
    partial class PermisosUsuario
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lblUsr = new System.Windows.Forms.Label();
            this.comboUsr = new System.Windows.Forms.ComboBox();
            this.btnUsr = new System.Windows.Forms.Button();
            this.btnFamilia = new System.Windows.Forms.Button();
            this.comboFamilia = new System.Windows.Forms.ComboBox();
            this.lblFamilia = new System.Windows.Forms.Label();
            this.btnPatente = new System.Windows.Forms.Button();
            this.comboPermisos = new System.Windows.Forms.ComboBox();
            this.lblPatente = new System.Windows.Forms.Label();
            this.PU_btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(135, 37);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(93, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Tag = "PU_lblTitulo";
            this.lblTitulo.Text = "Titulo";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(352, 102);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(265, 230);
            this.treeView1.TabIndex = 1;
            // 
            // lblUsr
            // 
            this.lblUsr.AutoSize = true;
            this.lblUsr.Location = new System.Drawing.Point(30, 113);
            this.lblUsr.Name = "lblUsr";
            this.lblUsr.Size = new System.Drawing.Size(38, 15);
            this.lblUsr.TabIndex = 2;
            this.lblUsr.Tag = "PU_lblUsr";
            this.lblUsr.Text = "label1";
            // 
            // comboUsr
            // 
            this.comboUsr.FormattingEnabled = true;
            this.comboUsr.Location = new System.Drawing.Point(30, 131);
            this.comboUsr.Name = "comboUsr";
            this.comboUsr.Size = new System.Drawing.Size(177, 23);
            this.comboUsr.TabIndex = 3;
            // 
            // btnUsr
            // 
            this.btnUsr.Location = new System.Drawing.Point(233, 131);
            this.btnUsr.Name = "btnUsr";
            this.btnUsr.Size = new System.Drawing.Size(75, 23);
            this.btnUsr.TabIndex = 4;
            this.btnUsr.Tag = "PU_btnUsr";
            this.btnUsr.Text = "button1";
            this.btnUsr.UseVisualStyleBackColor = true;
            this.btnUsr.Click += new System.EventHandler(this.btnUsr_Click);
            // 
            // btnFamilia
            // 
            this.btnFamilia.Location = new System.Drawing.Point(233, 203);
            this.btnFamilia.Name = "btnFamilia";
            this.btnFamilia.Size = new System.Drawing.Size(75, 23);
            this.btnFamilia.TabIndex = 7;
            this.btnFamilia.Tag = "PU_btnFamilia";
            this.btnFamilia.Text = "button2";
            this.btnFamilia.UseVisualStyleBackColor = true;
            this.btnFamilia.Click += new System.EventHandler(this.btnFamilia_Click);
            // 
            // comboFamilia
            // 
            this.comboFamilia.FormattingEnabled = true;
            this.comboFamilia.Location = new System.Drawing.Point(30, 203);
            this.comboFamilia.Name = "comboFamilia";
            this.comboFamilia.Size = new System.Drawing.Size(177, 23);
            this.comboFamilia.TabIndex = 6;
            // 
            // lblFamilia
            // 
            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Location = new System.Drawing.Point(30, 185);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(38, 15);
            this.lblFamilia.TabIndex = 5;
            this.lblFamilia.Tag = "PU_lblFamilia";
            this.lblFamilia.Text = "label2";
            // 
            // btnPatente
            // 
            this.btnPatente.Location = new System.Drawing.Point(233, 272);
            this.btnPatente.Name = "btnPatente";
            this.btnPatente.Size = new System.Drawing.Size(75, 23);
            this.btnPatente.TabIndex = 10;
            this.btnPatente.Tag = "PU_btnFamilia";
            this.btnPatente.Text = "button3";
            this.btnPatente.UseVisualStyleBackColor = true;
            this.btnPatente.Click += new System.EventHandler(this.btnPatente_Click);
            // 
            // comboPermisos
            // 
            this.comboPermisos.FormattingEnabled = true;
            this.comboPermisos.Location = new System.Drawing.Point(30, 272);
            this.comboPermisos.Name = "comboPermisos";
            this.comboPermisos.Size = new System.Drawing.Size(177, 23);
            this.comboPermisos.TabIndex = 9;
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.Location = new System.Drawing.Point(30, 254);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(38, 15);
            this.lblPatente.TabIndex = 8;
            this.lblPatente.Tag = "PU_lblPatente";
            this.lblPatente.Text = "label3";
            // 
            // PU_btnGuardar
            // 
            this.PU_btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PU_btnGuardar.Location = new System.Drawing.Point(352, 346);
            this.PU_btnGuardar.Name = "PU_btnGuardar";
            this.PU_btnGuardar.Size = new System.Drawing.Size(265, 23);
            this.PU_btnGuardar.TabIndex = 11;
            this.PU_btnGuardar.Tag = "PU_btnGuardar";
            this.PU_btnGuardar.Text = "button4";
            this.PU_btnGuardar.UseVisualStyleBackColor = true;
            this.PU_btnGuardar.Click += new System.EventHandler(this.PU_btnGuardar_Click);
            // 
            // PermisosUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 391);
            this.Controls.Add(this.PU_btnGuardar);
            this.Controls.Add(this.btnPatente);
            this.Controls.Add(this.comboPermisos);
            this.Controls.Add(this.lblPatente);
            this.Controls.Add(this.btnFamilia);
            this.Controls.Add(this.comboFamilia);
            this.Controls.Add(this.lblFamilia);
            this.Controls.Add(this.btnUsr);
            this.Controls.Add(this.comboUsr);
            this.Controls.Add(this.lblUsr);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.lblTitulo);
            this.Name = "PermisosUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TallerAdmin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PermisosUsuario_FormClosed);
            this.Load += new System.EventHandler(this.PermisosUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label lblUsr;
        private System.Windows.Forms.ComboBox comboUsr;
        private System.Windows.Forms.Button btnUsr;
        private System.Windows.Forms.Button btnFamilia;
        private System.Windows.Forms.ComboBox comboFamilia;
        private System.Windows.Forms.Label lblFamilia;
        private System.Windows.Forms.Button btnPatente;
        private System.Windows.Forms.ComboBox comboPermisos;
        private System.Windows.Forms.Label lblPatente;
        private System.Windows.Forms.Button PU_btnGuardar;
    }
}