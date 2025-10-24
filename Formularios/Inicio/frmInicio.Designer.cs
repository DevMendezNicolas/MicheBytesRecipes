namespace MicheBytesRecipes
{
    partial class frmInicio : MaterialSkin.Controls.MaterialForm
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
            this.PanelTop = new System.Windows.Forms.Panel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.BtnIniciar = new MaterialSkin.Controls.MaterialButton();
            this.BtnCrearCuenta = new MaterialSkin.Controls.MaterialButton();
            this.PanelMid = new System.Windows.Forms.Panel();
            this.lblFinal = new MaterialSkin.Controls.MaterialLabel();
            this.lblFooter = new MaterialSkin.Controls.MaterialLabel();
            this.lblTituloEsencia = new MaterialSkin.Controls.MaterialLabel();
            this.lblBullet = new MaterialSkin.Controls.MaterialLabel();
            this.lblTituloBullet = new MaterialSkin.Controls.MaterialLabel();
            this.lblRelleno = new MaterialSkin.Controls.MaterialLabel();
            this.lblTitulo = new MaterialSkin.Controls.MaterialLabel();
            this.PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.PanelMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTop
            // 
            this.PanelTop.Controls.Add(this.pbxLogo);
            this.PanelTop.Controls.Add(this.BtnIniciar);
            this.PanelTop.Controls.Add(this.BtnCrearCuenta);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.Location = new System.Drawing.Point(3, 64);
            this.PanelTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(1186, 122);
            this.PanelTop.TabIndex = 0;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Image = global::MicheBytesRecipes.Properties.Resources.logo_editable_con_le;
            this.pbxLogo.Location = new System.Drawing.Point(12, 12);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(184, 104);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 2;
            this.pbxLogo.TabStop = false;
            // 
            // BtnIniciar
            // 
            this.BtnIniciar.AutoSize = false;
            this.BtnIniciar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnIniciar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnIniciar.Depth = 0;
            this.BtnIniciar.HighEmphasis = true;
            this.BtnIniciar.Icon = null;
            this.BtnIniciar.Location = new System.Drawing.Point(902, 24);
            this.BtnIniciar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnIniciar.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnIniciar.Name = "BtnIniciar";
            this.BtnIniciar.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.BtnIniciar.Size = new System.Drawing.Size(121, 42);
            this.BtnIniciar.TabIndex = 1;
            this.BtnIniciar.Text = "INICIAR SESIÓN";
            this.BtnIniciar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnIniciar.UseAccentColor = true;
            this.BtnIniciar.UseVisualStyleBackColor = true;
            this.BtnIniciar.Click += new System.EventHandler(this.BtnIniciar_Click);
            // 
            // BtnCrearCuenta
            // 
            this.BtnCrearCuenta.AutoSize = false;
            this.BtnCrearCuenta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnCrearCuenta.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnCrearCuenta.Depth = 0;
            this.BtnCrearCuenta.HighEmphasis = true;
            this.BtnCrearCuenta.Icon = null;
            this.BtnCrearCuenta.Location = new System.Drawing.Point(1054, 24);
            this.BtnCrearCuenta.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnCrearCuenta.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnCrearCuenta.Name = "BtnCrearCuenta";
            this.BtnCrearCuenta.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.BtnCrearCuenta.Size = new System.Drawing.Size(118, 42);
            this.BtnCrearCuenta.TabIndex = 0;
            this.BtnCrearCuenta.Text = "CREAR CUENTA";
            this.BtnCrearCuenta.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnCrearCuenta.UseAccentColor = false;
            this.BtnCrearCuenta.UseVisualStyleBackColor = true;
            this.BtnCrearCuenta.Click += new System.EventHandler(this.BtnCrearCuenta_Click);
            // 
            // PanelMid
            // 
            this.PanelMid.Controls.Add(this.lblFinal);
            this.PanelMid.Controls.Add(this.lblFooter);
            this.PanelMid.Controls.Add(this.lblTituloEsencia);
            this.PanelMid.Controls.Add(this.lblBullet);
            this.PanelMid.Controls.Add(this.lblTituloBullet);
            this.PanelMid.Controls.Add(this.lblRelleno);
            this.PanelMid.Controls.Add(this.lblTitulo);
            this.PanelMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMid.Location = new System.Drawing.Point(3, 186);
            this.PanelMid.Name = "PanelMid";
            this.PanelMid.Size = new System.Drawing.Size(1186, 472);
            this.PanelMid.TabIndex = 1;
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.Depth = 0;
            this.lblFinal.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFinal.Location = new System.Drawing.Point(241, 470);
            this.lblFinal.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(596, 19);
            this.lblFinal.TabIndex = 6;
            this.lblFinal.Text = "¡Con MicheBytes Recipes, cocinar nunca fue tan divertido, accesible y delicioso! " +
    "🍳✨";
            // 
            // lblFooter
            // 
            this.lblFooter.Depth = 0;
            this.lblFooter.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFooter.Location = new System.Drawing.Point(130, 330);
            this.lblFooter.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(960, 77);
            this.lblFooter.TabIndex = 5;
            this.lblFooter.Text = resources.GetString("lblFooter.Text");
            // 
            // lblTituloEsencia
            // 
            this.lblTituloEsencia.AutoSize = true;
            this.lblTituloEsencia.Depth = 0;
            this.lblTituloEsencia.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTituloEsencia.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.lblTituloEsencia.Location = new System.Drawing.Point(129, 292);
            this.lblTituloEsencia.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTituloEsencia.Name = "lblTituloEsencia";
            this.lblTituloEsencia.Size = new System.Drawing.Size(172, 24);
            this.lblTituloEsencia.TabIndex = 4;
            this.lblTituloEsencia.Text = "🌈 Nuestra esencia";
            // 
            // lblBullet
            // 
            this.lblBullet.Depth = 0;
            this.lblBullet.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBullet.Location = new System.Drawing.Point(130, 193);
            this.lblBullet.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBullet.Name = "lblBullet";
            this.lblBullet.Size = new System.Drawing.Size(3027, 82);
            this.lblBullet.TabIndex = 3;
            this.lblBullet.Text = resources.GetString("lblBullet.Text");
            this.lblBullet.Click += new System.EventHandler(this.lblBullet_Click);
            // 
            // lblTituloBullet
            // 
            this.lblTituloBullet.AutoSize = true;
            this.lblTituloBullet.Depth = 0;
            this.lblTituloBullet.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTituloBullet.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblTituloBullet.Location = new System.Drawing.Point(128, 155);
            this.lblTituloBullet.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTituloBullet.Name = "lblTituloBullet";
            this.lblTituloBullet.Size = new System.Drawing.Size(395, 29);
            this.lblTituloBullet.TabIndex = 2;
            this.lblTituloBullet.Text = "🍴 ¿Qué ofrece MicheBytes Recipes?";
            // 
            // lblRelleno
            // 
            this.lblRelleno.Depth = 0;
            this.lblRelleno.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRelleno.Location = new System.Drawing.Point(130, 61);
            this.lblRelleno.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRelleno.Name = "lblRelleno";
            this.lblRelleno.Size = new System.Drawing.Size(955, 85);
            this.lblRelleno.TabIndex = 1;
            this.lblRelleno.Text = resources.GetString("lblRelleno.Text");
            this.lblRelleno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Depth = 0;
            this.lblTitulo.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitulo.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.lblTitulo.Location = new System.Drawing.Point(292, 20);
            this.lblTitulo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(644, 41);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "¡Bieeeenvenidos a MicheBytes Recipes! 🎉";
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 661);
            this.Controls.Add(this.PanelMid);
            this.Controls.Add(this.PanelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.PanelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.PanelMid.ResumeLayout(false);
            this.PanelMid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        //  CAMBIAR LAS DECLARACIONES DE VARIABLES
        private System.Windows.Forms.Panel PanelTop;
        private MaterialSkin.Controls.MaterialButton BtnIniciar; 
        private MaterialSkin.Controls.MaterialButton BtnCrearCuenta; 
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Panel PanelMid;
        private MaterialSkin.Controls.MaterialLabel lblTitulo; 
        private MaterialSkin.Controls.MaterialLabel lblRelleno; 
        private MaterialSkin.Controls.MaterialLabel lblTituloBullet;
        private MaterialSkin.Controls.MaterialLabel lblBullet; 
        private MaterialSkin.Controls.MaterialLabel lblTituloEsencia; 
        private MaterialSkin.Controls.MaterialLabel lblFooter; 
        private MaterialSkin.Controls.MaterialLabel lblFinal; 
    }
}