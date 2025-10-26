namespace MicheBytesRecipes
{
    partial class frmInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicio));
            this.panelTop = new System.Windows.Forms.Panel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnCrearCuenta = new System.Windows.Forms.Button();
            this.panelMid = new System.Windows.Forms.Panel();
            this.lblFinal = new System.Windows.Forms.Label();
            this.lblFooter = new System.Windows.Forms.Label();
            this.lblTituloEsencia = new System.Windows.Forms.Label();
            this.lblBullet1 = new System.Windows.Forms.Label();
            this.lblQueOfrece = new System.Windows.Forms.Label();
            this.lblRelleno = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnTema = new System.Windows.Forms.Button();
            this.lblBullet2 = new System.Windows.Forms.Label();
            this.lblBullet3 = new System.Windows.Forms.Label();
            this.lblTituloBullet1 = new System.Windows.Forms.Label();
            this.lblTituloBullet2 = new System.Windows.Forms.Label();
            this.lblTituloBullet3 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.panelMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Orange;
            this.panelTop.Controls.Add(this.pbxLogo);
            this.panelTop.Controls.Add(this.btnIniciar);
            this.panelTop.Controls.Add(this.btnCrearCuenta);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1184, 105);
            this.panelTop.TabIndex = 0;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Image = global::MicheBytesRecipes.Properties.Resources.logo_editable_con_le;
            this.pbxLogo.Location = new System.Drawing.Point(0, 0);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(184, 104);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 2;
            this.pbxLogo.TabStop = false;
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnIniciar.FlatAppearance.BorderSize = 0;
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.ForeColor = System.Drawing.Color.White;
            this.btnIniciar.Location = new System.Drawing.Point(918, 29);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(111, 30);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "Iniciar sesión";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnCrearCuenta
            // 
            this.btnCrearCuenta.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCrearCuenta.FlatAppearance.BorderSize = 0;
            this.btnCrearCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearCuenta.ForeColor = System.Drawing.Color.White;
            this.btnCrearCuenta.Location = new System.Drawing.Point(1052, 29);
            this.btnCrearCuenta.Name = "btnCrearCuenta";
            this.btnCrearCuenta.Size = new System.Drawing.Size(111, 30);
            this.btnCrearCuenta.TabIndex = 2;
            this.btnCrearCuenta.Text = "Crear cuenta";
            this.btnCrearCuenta.UseVisualStyleBackColor = false;
            this.btnCrearCuenta.Click += new System.EventHandler(this.btnCrearCuenta_Click);
            // 
            // panelMid
            // 
            this.panelMid.BackColor = System.Drawing.Color.Orange;
            this.panelMid.Controls.Add(this.lblTituloBullet3);
            this.panelMid.Controls.Add(this.lblTituloBullet2);
            this.panelMid.Controls.Add(this.lblTituloBullet1);
            this.panelMid.Controls.Add(this.lblBullet3);
            this.panelMid.Controls.Add(this.lblBullet2);
            this.panelMid.Controls.Add(this.btnTema);
            this.panelMid.Controls.Add(this.lblTitulo);
            this.panelMid.Controls.Add(this.lblFinal);
            this.panelMid.Controls.Add(this.lblFooter);
            this.panelMid.Controls.Add(this.lblTituloEsencia);
            this.panelMid.Controls.Add(this.lblBullet1);
            this.panelMid.Controls.Add(this.lblQueOfrece);
            this.panelMid.Controls.Add(this.lblRelleno);
            this.panelMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMid.Location = new System.Drawing.Point(0, 105);
            this.panelMid.Name = "panelMid";
            this.panelMid.Size = new System.Drawing.Size(1184, 556);
            this.panelMid.TabIndex = 1;
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinal.ForeColor = System.Drawing.Color.White;
            this.lblFinal.Location = new System.Drawing.Point(170, 507);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(859, 30);
            this.lblFinal.TabIndex = 6;
            this.lblFinal.Text = "¡Con MicheBytes Recipes, cocinar nunca fue tan divertido, accesible y delicioso! " +
    "🍳✨";
            this.lblFinal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFooter
            // 
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.ForeColor = System.Drawing.Color.White;
            this.lblFooter.Location = new System.Drawing.Point(325, 394);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(519, 90);
            this.lblFooter.TabIndex = 5;
            this.lblFooter.Text = resources.GetString("lblFooter.Text");
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloEsencia
            // 
            this.lblTituloEsencia.AutoSize = true;
            this.lblTituloEsencia.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloEsencia.ForeColor = System.Drawing.Color.White;
            this.lblTituloEsencia.Location = new System.Drawing.Point(435, 345);
            this.lblTituloEsencia.Name = "lblTituloEsencia";
            this.lblTituloEsencia.Size = new System.Drawing.Size(256, 37);
            this.lblTituloEsencia.TabIndex = 4;
            this.lblTituloEsencia.Text = "🌈 Nuestra esencia";
            this.lblTituloEsencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBullet1
            // 
            this.lblBullet1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBullet1.ForeColor = System.Drawing.Color.White;
            this.lblBullet1.Location = new System.Drawing.Point(26, 259);
            this.lblBullet1.Name = "lblBullet1";
            this.lblBullet1.Size = new System.Drawing.Size(313, 51);
            this.lblBullet1.TabIndex = 3;
            this.lblBullet1.Text = "• Una colección variada de recetas explicadas de forma clara y sencilla.\r\n";
            this.lblBullet1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQueOfrece
            // 
            this.lblQueOfrece.AutoSize = true;
            this.lblQueOfrece.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQueOfrece.ForeColor = System.Drawing.Color.White;
            this.lblQueOfrece.Location = new System.Drawing.Point(322, 153);
            this.lblQueOfrece.Name = "lblQueOfrece";
            this.lblQueOfrece.Size = new System.Drawing.Size(503, 40);
            this.lblQueOfrece.TabIndex = 2;
            this.lblQueOfrece.Text = "🍴 ¿Qué ofrece MicheBytes Recipes?";
            this.lblQueOfrece.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRelleno
            // 
            this.lblRelleno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelleno.ForeColor = System.Drawing.Color.White;
            this.lblRelleno.Location = new System.Drawing.Point(214, 41);
            this.lblRelleno.Name = "lblRelleno";
            this.lblRelleno.Size = new System.Drawing.Size(815, 112);
            this.lblRelleno.TabIndex = 1;
            this.lblRelleno.Text = resources.GetString("lblRelleno.Text");
            this.lblRelleno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.lblTitulo.Location = new System.Drawing.Point(179, -6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(860, 59);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "¡Bieeeenvenidos a MicheBytes Recipes! 🎉";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTema
            // 
            this.btnTema.AutoSize = true;
            this.btnTema.Location = new System.Drawing.Point(1138, 520);
            this.btnTema.Name = "btnTema";
            this.btnTema.Size = new System.Drawing.Size(43, 33);
            this.btnTema.TabIndex = 3;
            this.btnTema.Text = "sol";
            this.btnTema.UseVisualStyleBackColor = true;
            this.btnTema.Click += new System.EventHandler(this.btnTema_Click);
            // 
            // lblBullet2
            // 
            this.lblBullet2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBullet2.ForeColor = System.Drawing.Color.White;
            this.lblBullet2.Location = new System.Drawing.Point(360, 239);
            this.lblBullet2.Name = "lblBullet2";
            this.lblBullet2.Size = new System.Drawing.Size(402, 90);
            this.lblBullet2.TabIndex = 7;
            this.lblBullet2.Text = "\r\n• Filtros inteligentes para encontrar la receta perfecta según tus gustos, el t" +
    "iempo o los ingredientes disponibles.\r\n";
            this.lblBullet2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBullet3
            // 
            this.lblBullet3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBullet3.ForeColor = System.Drawing.Color.White;
            this.lblBullet3.Location = new System.Drawing.Point(779, 254);
            this.lblBullet3.Name = "lblBullet3";
            this.lblBullet3.Size = new System.Drawing.Size(386, 77);
            this.lblBullet3.TabIndex = 8;
            this.lblBullet3.Text = "• Consejos prácticos y tips gastronómicos que convierten cada receta en una oport" +
    "unidad de aprender algo nuevo.";
            this.lblBullet3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloBullet1
            // 
            this.lblTituloBullet1.AutoSize = true;
            this.lblTituloBullet1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloBullet1.Location = new System.Drawing.Point(87, 222);
            this.lblTituloBullet1.Name = "lblTituloBullet1";
            this.lblTituloBullet1.Size = new System.Drawing.Size(166, 30);
            this.lblTituloBullet1.TabIndex = 9;
            this.lblTituloBullet1.Text = "Recetas variadas";
            this.lblTituloBullet1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloBullet2
            // 
            this.lblTituloBullet2.AutoSize = true;
            this.lblTituloBullet2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloBullet2.Location = new System.Drawing.Point(453, 222);
            this.lblTituloBullet2.Name = "lblTituloBullet2";
            this.lblTituloBullet2.Size = new System.Drawing.Size(181, 30);
            this.lblTituloBullet2.TabIndex = 10;
            this.lblTituloBullet2.Text = "Filtros inteligentes";
            this.lblTituloBullet2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloBullet3
            // 
            this.lblTituloBullet3.AutoSize = true;
            this.lblTituloBullet3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloBullet3.Location = new System.Drawing.Point(879, 224);
            this.lblTituloBullet3.Name = "lblTituloBullet3";
            this.lblTituloBullet3.Size = new System.Drawing.Size(185, 30);
            this.lblTituloBullet3.TabIndex = 11;
            this.lblTituloBullet3.Text = "Consejos prácticos";
            this.lblTituloBullet3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panelMid);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.frmInicio_Load);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.panelMid.ResumeLayout(false);
            this.panelMid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnCrearCuenta;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblRelleno;
        private System.Windows.Forms.Label lblQueOfrece;
        private System.Windows.Forms.Label lblBullet1;
        private System.Windows.Forms.Label lblTituloEsencia;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.Button btnTema;
        private System.Windows.Forms.Label lblBullet3;
        private System.Windows.Forms.Label lblBullet2;
        private System.Windows.Forms.Label lblTituloBullet3;
        private System.Windows.Forms.Label lblTituloBullet2;
        private System.Windows.Forms.Label lblTituloBullet1;
    }
}

