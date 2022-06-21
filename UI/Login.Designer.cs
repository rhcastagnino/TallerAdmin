namespace UI
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbIngreso = new System.Windows.Forms.GroupBox();
            this.btnAltaUsuario = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuIdioma = new System.Windows.Forms.ToolStripMenuItem();
            this.gbIngreso.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(88, 42);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(296, 23);
            this.txtEmail.TabIndex = 0;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(88, 95);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(296, 23);
            this.txtPass.TabIndex = 1;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(182, 146);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(75, 23);
            this.btnlogin.TabIndex = 2;
            this.btnlogin.Tag = "LGI_btnLogin";
            this.btnlogin.Text = "Ingresar";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(27, 45);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Tag = "LGI_lblEmail";
            this.lblEmail.Text = "Email:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(7, 98);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 15);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Tag = "LGI_lblPass";
            this.lblPassword.Text = "Contraseña:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(183, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 37);
            this.label3.TabIndex = 5;
            this.label3.Tag = "LGI_lbllogin";
            this.label3.Text = "Login";
            // 
            // gbIngreso
            // 
            this.gbIngreso.Controls.Add(this.lblEmail);
            this.gbIngreso.Controls.Add(this.txtEmail);
            this.gbIngreso.Controls.Add(this.lblPassword);
            this.gbIngreso.Controls.Add(this.txtPass);
            this.gbIngreso.Controls.Add(this.btnlogin);
            this.gbIngreso.Location = new System.Drawing.Point(12, 68);
            this.gbIngreso.Name = "gbIngreso";
            this.gbIngreso.Size = new System.Drawing.Size(429, 180);
            this.gbIngreso.TabIndex = 6;
            this.gbIngreso.TabStop = false;
            this.gbIngreso.Tag = "LGI_gbInicio";
            this.gbIngreso.Text = "Ingreso al Sistema";
            // 
            // btnAltaUsuario
            // 
            this.btnAltaUsuario.BackColor = System.Drawing.SystemColors.Control;
            this.btnAltaUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltaUsuario.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnAltaUsuario.Location = new System.Drawing.Point(120, 262);
            this.btnAltaUsuario.Margin = new System.Windows.Forms.Padding(0);
            this.btnAltaUsuario.Name = "btnAltaUsuario";
            this.btnAltaUsuario.Size = new System.Drawing.Size(221, 25);
            this.btnAltaUsuario.TabIndex = 7;
            this.btnAltaUsuario.Tag = "LGI_btnNuevoUsr";
            this.btnAltaUsuario.Text = "No tenes cuenta? Registrate";
            this.btnAltaUsuario.UseVisualStyleBackColor = false;
            this.btnAltaUsuario.Click += new System.EventHandler(this.btnAltaUsuario_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuIdioma});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(453, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuIdioma
            // 
            this.menuIdioma.Name = "menuIdioma";
            this.menuIdioma.Size = new System.Drawing.Size(56, 20);
            this.menuIdioma.Tag = "LGI_msIdioma";
            this.menuIdioma.Text = "Idioma";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 296);
            this.Controls.Add(this.btnAltaUsuario);
            this.Controls.Add(this.gbIngreso);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TallerAdmin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.gbIngreso.ResumeLayout(false);
            this.gbIngreso.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbIngreso;
        private System.Windows.Forms.Button btnAltaUsuario;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuIdioma;
    }
}
