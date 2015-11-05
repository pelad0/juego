namespace juego1._0
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlBase = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.pnlInicio = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlJugar = new System.Windows.Forms.Panel();
            this.lblTituloTpo = new System.Windows.Forms.Label();
            this.pbSonido = new System.Windows.Forms.PictureBox();
            this.pbReferencias = new System.Windows.Forms.PictureBox();
            this.pbMusica = new System.Windows.Forms.PictureBox();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblTpo = new System.Windows.Forms.Label();
            this.lblPuntos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trReloj = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.juegoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDif = new System.Windows.Forms.ToolStripMenuItem();
            this.msFacil = new System.Windows.Forms.ToolStripMenuItem();
            this.msMedio = new System.Windows.Forms.ToolStripMenuItem();
            this.msDificil = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlJugar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSonido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReferencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMusica)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBase.BackColor = System.Drawing.Color.White;
            this.pnlBase.Enabled = false;
            this.pnlBase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlBase.Location = new System.Drawing.Point(263, 31);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(588, 588);
            this.pnlBase.TabIndex = 0;
            this.pnlBase.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBase_Paint);
            this.pnlBase.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlBase_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnInicio.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnInicio.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnInicio.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnInicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Cooper Std Black", 14.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.Location = new System.Drawing.Point(0, 0);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(90, 97);
            this.btnInicio.TabIndex = 2;
            this.btnInicio.Text = "Iniciar";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNuevo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNuevo.FlatAppearance.BorderSize = 2;
            this.btnNuevo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Consolas", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(152, 0);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(104, 97);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "Finalizar Partida";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // pnlInicio
            // 
            this.pnlInicio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlInicio.BackColor = System.Drawing.Color.Silver;
            this.pnlInicio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlInicio.Controls.Add(this.pictureBox1);
            this.pnlInicio.Controls.Add(this.btnInicio);
            this.pnlInicio.Controls.Add(this.btnNuevo);
            this.pnlInicio.Location = new System.Drawing.Point(4, 518);
            this.pnlInicio.Name = "pnlInicio";
            this.pnlInicio.Size = new System.Drawing.Size(260, 101);
            this.pnlInicio.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::juego1._0.Properties.Resources.Agnes_Happy_icon;
            this.pictureBox1.Location = new System.Drawing.Point(96, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pnlJugar
            // 
            this.pnlJugar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlJugar.BackColor = System.Drawing.Color.Gold;
            this.pnlJugar.Controls.Add(this.lblTituloTpo);
            this.pnlJugar.Controls.Add(this.pbSonido);
            this.pnlJugar.Controls.Add(this.pbReferencias);
            this.pnlJugar.Controls.Add(this.pbMusica);
            this.pnlJugar.Controls.Add(this.lblTurno);
            this.pnlJugar.Controls.Add(this.lblTpo);
            this.pnlJugar.Controls.Add(this.lblPuntos);
            this.pnlJugar.Controls.Add(this.label3);
            this.pnlJugar.Location = new System.Drawing.Point(4, 31);
            this.pnlJugar.Name = "pnlJugar";
            this.pnlJugar.Size = new System.Drawing.Size(260, 490);
            this.pnlJugar.TabIndex = 5;
            // 
            // lblTituloTpo
            // 
            this.lblTituloTpo.AutoSize = true;
            this.lblTituloTpo.Font = new System.Drawing.Font("Cooper Std Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTpo.Location = new System.Drawing.Point(53, 99);
            this.lblTituloTpo.Name = "lblTituloTpo";
            this.lblTituloTpo.Size = new System.Drawing.Size(124, 19);
            this.lblTituloTpo.TabIndex = 10;
            this.lblTituloTpo.Text = "Tiempo Total";
            // 
            // pbSonido
            // 
            this.pbSonido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbSonido.BackColor = System.Drawing.Color.Transparent;
            this.pbSonido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbSonido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSonido.Image = global::juego1._0.Properties.Resources.sonido;
            this.pbSonido.Location = new System.Drawing.Point(3, 249);
            this.pbSonido.Name = "pbSonido";
            this.pbSonido.Size = new System.Drawing.Size(48, 50);
            this.pbSonido.TabIndex = 7;
            this.pbSonido.TabStop = false;
            this.pbSonido.Click += new System.EventHandler(this.pbSonido_Click);
            // 
            // pbReferencias
            // 
            this.pbReferencias.BackgroundImage = global::juego1._0.Properties.Resources.referencia1;
            this.pbReferencias.Location = new System.Drawing.Point(62, 193);
            this.pbReferencias.Name = "pbReferencias";
            this.pbReferencias.Size = new System.Drawing.Size(191, 288);
            this.pbReferencias.TabIndex = 9;
            this.pbReferencias.TabStop = false;
            // 
            // pbMusica
            // 
            this.pbMusica.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbMusica.BackColor = System.Drawing.Color.Transparent;
            this.pbMusica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbMusica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMusica.Image = global::juego1._0.Properties.Resources.music;
            this.pbMusica.Location = new System.Drawing.Point(3, 193);
            this.pbMusica.Name = "pbMusica";
            this.pbMusica.Size = new System.Drawing.Size(48, 50);
            this.pbMusica.TabIndex = 6;
            this.pbMusica.TabStop = false;
            this.pbMusica.Click += new System.EventHandler(this.pbMusica_Click);
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Cooper Std Black", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurno.Location = new System.Drawing.Point(26, 152);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(0, 26);
            this.lblTurno.TabIndex = 8;
            this.lblTurno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTpo
            // 
            this.lblTpo.AutoSize = true;
            this.lblTpo.Font = new System.Drawing.Font("Cooper Std Black", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTpo.Location = new System.Drawing.Point(114, 128);
            this.lblTpo.Name = "lblTpo";
            this.lblTpo.Size = new System.Drawing.Size(24, 26);
            this.lblTpo.TabIndex = 7;
            this.lblTpo.Text = "0";
            this.lblTpo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPuntos
            // 
            this.lblPuntos.AutoSize = true;
            this.lblPuntos.Font = new System.Drawing.Font("Cooper Std Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntos.Location = new System.Drawing.Point(112, 40);
            this.lblPuntos.Name = "lblPuntos";
            this.lblPuntos.Size = new System.Drawing.Size(37, 38);
            this.lblPuntos.TabIndex = 6;
            this.lblPuntos.Text = "0";
            this.lblPuntos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cooper Std Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Puntuación";
            // 
            // trReloj
            // 
            this.trReloj.Interval = 1000;
            this.trReloj.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.juegoToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(854, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // juegoToolStripMenuItem
            // 
            this.juegoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDif,
            this.salirToolStripMenuItem});
            this.juegoToolStripMenuItem.Name = "juegoToolStripMenuItem";
            this.juegoToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.juegoToolStripMenuItem.Text = "Juego";
            // 
            // tsmiDif
            // 
            this.tsmiDif.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msFacil,
            this.msMedio,
            this.msDificil});
            this.tsmiDif.Name = "tsmiDif";
            this.tsmiDif.Size = new System.Drawing.Size(125, 22);
            this.tsmiDif.Text = "Dificultad";
            // 
            // msFacil
            // 
            this.msFacil.Name = "msFacil";
            this.msFacil.Size = new System.Drawing.Size(108, 22);
            this.msFacil.Tag = "1";
            this.msFacil.Text = "-Facil-";
            this.msFacil.Click += new System.EventHandler(this.msDificil_Click);
            // 
            // msMedio
            // 
            this.msMedio.Name = "msMedio";
            this.msMedio.Size = new System.Drawing.Size(108, 22);
            this.msMedio.Tag = "2";
            this.msMedio.Text = "Medio";
            this.msMedio.Click += new System.EventHandler(this.msDificil_Click);
            // 
            // msDificil
            // 
            this.msDificil.Name = "msDificil";
            this.msDificil.Size = new System.Drawing.Size(108, 22);
            this.msDificil.Tag = "3";
            this.msDificil.Text = "Dificil";
            this.msDificil.Click += new System.EventHandler(this.msDificil_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(854, 631);
            this.Controls.Add(this.pnlJugar);
            this.Controls.Add(this.pnlInicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlBase);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.pnlInicio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlJugar.ResumeLayout(false);
            this.pnlJugar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSonido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReferencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMusica)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Panel pnlInicio;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlJugar;
        private System.Windows.Forms.Label lblPuntos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer trReloj;
        private System.Windows.Forms.Label lblTpo;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.PictureBox pbReferencias;
        private System.Windows.Forms.PictureBox pbMusica;
        private System.Windows.Forms.PictureBox pbSonido;
        private System.Windows.Forms.Label lblTituloTpo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem juegoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiDif;
        private System.Windows.Forms.ToolStripMenuItem msFacil;
        private System.Windows.Forms.ToolStripMenuItem msMedio;
        private System.Windows.Forms.ToolStripMenuItem msDificil;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}

