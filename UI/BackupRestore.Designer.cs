namespace UI
{
    partial class BackupRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupRestore));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTitulo2 = new System.Windows.Forms.Label();
            this.txtDirBackup = new System.Windows.Forms.TextBox();
            this.btnDirBackup = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnDirRestore = new System.Windows.Forms.Button();
            this.txtDirRestore = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(47, 38);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(127, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Tag = "BR_lblTitulo";
            this.lblTitulo.Text = "BR_lblTitulo";
            // 
            // lblTitulo2
            // 
            this.lblTitulo2.AutoSize = true;
            this.lblTitulo2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblTitulo2.Location = new System.Drawing.Point(47, 195);
            this.lblTitulo2.Name = "lblTitulo2";
            this.lblTitulo2.Size = new System.Drawing.Size(138, 30);
            this.lblTitulo2.TabIndex = 1;
            this.lblTitulo2.Tag = "BR_lblTitulo2";
            this.lblTitulo2.Text = "BR_lblTitulo2";
            // 
            // txtDirBackup
            // 
            this.txtDirBackup.Location = new System.Drawing.Point(47, 95);
            this.txtDirBackup.Name = "txtDirBackup";
            this.txtDirBackup.Size = new System.Drawing.Size(304, 23);
            this.txtDirBackup.TabIndex = 2;
            // 
            // btnDirBackup
            // 
            this.btnDirBackup.Location = new System.Drawing.Point(368, 95);
            this.btnDirBackup.Name = "btnDirBackup";
            this.btnDirBackup.Size = new System.Drawing.Size(111, 23);
            this.btnDirBackup.TabIndex = 3;
            this.btnDirBackup.Tag = "BR_btnDirBackup";
            this.btnDirBackup.Text = "button1";
            this.btnDirBackup.UseVisualStyleBackColor = true;
            this.btnDirBackup.Click += new System.EventHandler(this.btnDirBackup_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Enabled = false;
            this.btnBackup.Location = new System.Drawing.Point(139, 137);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(121, 33);
            this.btnBackup.TabIndex = 4;
            this.btnBackup.Tag = "BR_btnBackup";
            this.btnBackup.Text = "button2";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Enabled = false;
            this.btnRestore.Location = new System.Drawing.Point(139, 295);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(121, 33);
            this.btnRestore.TabIndex = 7;
            this.btnRestore.Tag = "BR_btnRestore";
            this.btnRestore.Text = "button3";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnDirRestore
            // 
            this.btnDirRestore.Location = new System.Drawing.Point(368, 253);
            this.btnDirRestore.Name = "btnDirRestore";
            this.btnDirRestore.Size = new System.Drawing.Size(111, 23);
            this.btnDirRestore.TabIndex = 6;
            this.btnDirRestore.Tag = "BR_btnDirRestore";
            this.btnDirRestore.Text = "button4";
            this.btnDirRestore.UseVisualStyleBackColor = true;
            this.btnDirRestore.Click += new System.EventHandler(this.btnDirRestore_Click);
            // 
            // txtDirRestore
            // 
            this.txtDirRestore.Location = new System.Drawing.Point(47, 253);
            this.txtDirRestore.Name = "txtDirRestore";
            this.txtDirRestore.Size = new System.Drawing.Size(304, 23);
            this.txtDirRestore.TabIndex = 5;
            // 
            // BackupRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 372);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnDirRestore);
            this.Controls.Add(this.txtDirRestore);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnDirBackup);
            this.Controls.Add(this.txtDirBackup);
            this.Controls.Add(this.lblTitulo2);
            this.Controls.Add(this.lblTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BackupRestore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TallerAdmin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BackupRestore_FormClosed);
            this.Load += new System.EventHandler(this.BackupRestore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTitulo2;
        private System.Windows.Forms.TextBox txtDirBackup;
        private System.Windows.Forms.Button btnDirBackup;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnDirRestore;
        private System.Windows.Forms.TextBox txtDirRestore;
    }
}