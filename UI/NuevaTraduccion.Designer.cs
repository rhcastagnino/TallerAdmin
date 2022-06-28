namespace UI
{
    partial class NuevaTraduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaTraduccion));
            this.NT_lblTitulo = new System.Windows.Forms.Label();
            this.dgwReferencias = new System.Windows.Forms.DataGridView();
            this.dgwIdioma = new System.Windows.Forms.DataGridView();
            this.lblRef = new System.Windows.Forms.Label();
            this.lblRefIdioma = new System.Windows.Forms.Label();
            this.lblIdioma = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.cbEtiquetas = new System.Windows.Forms.ComboBox();
            this.cbIdioma = new System.Windows.Forms.ComboBox();
            this.lblEtiqueta = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.btnTraducir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwReferencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwIdioma)).BeginInit();
            this.SuspendLayout();
            // 
            // NT_lblTitulo
            // 
            this.NT_lblTitulo.AutoSize = true;
            this.NT_lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NT_lblTitulo.Location = new System.Drawing.Point(265, 22);
            this.NT_lblTitulo.Name = "NT_lblTitulo";
            this.NT_lblTitulo.Size = new System.Drawing.Size(93, 37);
            this.NT_lblTitulo.TabIndex = 0;
            this.NT_lblTitulo.Tag = "NT_lblTitulo";
            this.NT_lblTitulo.Text = "Titulo";
            // 
            // dgwReferencias
            // 
            this.dgwReferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwReferencias.Location = new System.Drawing.Point(12, 113);
            this.dgwReferencias.Name = "dgwReferencias";
            this.dgwReferencias.RowTemplate.Height = 25;
            this.dgwReferencias.Size = new System.Drawing.Size(211, 325);
            this.dgwReferencias.TabIndex = 1;
            // 
            // dgwIdioma
            // 
            this.dgwIdioma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwIdioma.Location = new System.Drawing.Point(577, 113);
            this.dgwIdioma.Name = "dgwIdioma";
            this.dgwIdioma.RowTemplate.Height = 25;
            this.dgwIdioma.Size = new System.Drawing.Size(211, 325);
            this.dgwIdioma.TabIndex = 2;
            // 
            // lblRef
            // 
            this.lblRef.AutoSize = true;
            this.lblRef.Location = new System.Drawing.Point(12, 82);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(24, 15);
            this.lblRef.TabIndex = 3;
            this.lblRef.Tag = "NT_lblRef";
            this.lblRef.Text = "Ref";
            // 
            // lblRefIdioma
            // 
            this.lblRefIdioma.AutoSize = true;
            this.lblRefIdioma.Location = new System.Drawing.Point(577, 82);
            this.lblRefIdioma.Name = "lblRefIdioma";
            this.lblRefIdioma.Size = new System.Drawing.Size(24, 15);
            this.lblRefIdioma.TabIndex = 4;
            this.lblRefIdioma.Tag = "NT_lblRefIdioma";
            this.lblRefIdioma.Text = "Ref";
            // 
            // lblIdioma
            // 
            this.lblIdioma.AutoSize = true;
            this.lblIdioma.Location = new System.Drawing.Point(265, 131);
            this.lblIdioma.Name = "lblIdioma";
            this.lblIdioma.Size = new System.Drawing.Size(27, 15);
            this.lblIdioma.TabIndex = 5;
            this.lblIdioma.Tag = "NT_lblIdioma";
            this.lblIdioma.Text = "Idio";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(265, 313);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(277, 23);
            this.txtValor.TabIndex = 6;
            // 
            // cbEtiquetas
            // 
            this.cbEtiquetas.FormattingEnabled = true;
            this.cbEtiquetas.Location = new System.Drawing.Point(265, 231);
            this.cbEtiquetas.Name = "cbEtiquetas";
            this.cbEtiquetas.Size = new System.Drawing.Size(277, 23);
            this.cbEtiquetas.TabIndex = 7;
            this.cbEtiquetas.SelectedIndexChanged += new System.EventHandler(this.cbEtiquetas_SelectedIndexChanged);
            // 
            // cbIdioma
            // 
            this.cbIdioma.FormattingEnabled = true;
            this.cbIdioma.Location = new System.Drawing.Point(265, 149);
            this.cbIdioma.Name = "cbIdioma";
            this.cbIdioma.Size = new System.Drawing.Size(277, 23);
            this.cbIdioma.TabIndex = 8;
            this.cbIdioma.SelectedIndexChanged += new System.EventHandler(this.cbIdioma_SelectedIndexChanged);
            // 
            // lblEtiqueta
            // 
            this.lblEtiqueta.AutoSize = true;
            this.lblEtiqueta.Location = new System.Drawing.Point(265, 213);
            this.lblEtiqueta.Name = "lblEtiqueta";
            this.lblEtiqueta.Size = new System.Drawing.Size(20, 15);
            this.lblEtiqueta.TabIndex = 9;
            this.lblEtiqueta.Tag = "NT_lblEtiqueta";
            this.lblEtiqueta.Text = "Eti";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(265, 295);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(33, 15);
            this.lblValor.TabIndex = 10;
            this.lblValor.Tag = "NT_lblValor";
            this.lblValor.Text = "Valor";
            // 
            // btnTraducir
            // 
            this.btnTraducir.Location = new System.Drawing.Point(340, 381);
            this.btnTraducir.Name = "btnTraducir";
            this.btnTraducir.Size = new System.Drawing.Size(131, 38);
            this.btnTraducir.TabIndex = 11;
            this.btnTraducir.Tag = "NT_btnTraducir";
            this.btnTraducir.UseVisualStyleBackColor = true;
            this.btnTraducir.Click += new System.EventHandler(this.btnTraducir_Click);
            // 
            // NuevaTraduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTraducir);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblEtiqueta);
            this.Controls.Add(this.cbIdioma);
            this.Controls.Add(this.cbEtiquetas);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.lblIdioma);
            this.Controls.Add(this.lblRefIdioma);
            this.Controls.Add(this.lblRef);
            this.Controls.Add(this.dgwIdioma);
            this.Controls.Add(this.dgwReferencias);
            this.Controls.Add(this.NT_lblTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NuevaTraduccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TallerAdmin";
            this.Load += new System.EventHandler(this.NuevaTraduccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwReferencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwIdioma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NT_lblTitulo;
        private System.Windows.Forms.DataGridView dgwReferencias;
        private System.Windows.Forms.DataGridView dgwIdioma;
        private System.Windows.Forms.Label lblRef;
        private System.Windows.Forms.Label lblRefIdioma;
        private System.Windows.Forms.Label lblIdioma;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.ComboBox cbEtiquetas;
        private System.Windows.Forms.ComboBox cbIdioma;
        private System.Windows.Forms.Label lblEtiqueta;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Button btnTraducir;
    }
}