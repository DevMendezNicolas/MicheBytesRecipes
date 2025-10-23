namespace MicheBytesRecipes
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.PanelTop = new System.Windows.Forms.Panel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.BtnIniciar = new System.Windows.Forms.Button();
            this.BtnCrearCuenta = new System.Windows.Forms.Button();
            this.PanelMid = new System.Windows.Forms.Panel();
            this.lblFinal = new System.Windows.Forms.Label();
            this.lblFooter = new System.Windows.Forms.Label();
            this.lblTituloEsencia = new System.Windows.Forms.Label();
            this.lblBullet = new System.Windows.Forms.Label();
            this.lblTituloBullet = new System.Windows.Forms.Label();
            this.lblRelleno = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.PanelMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTop
            // 
            this.PanelTop.BackColor = System.Drawing.Color.White;
            this.PanelTop.Controls.Add(this.pbxLogo);
            this.PanelTop.Controls.Add(this.BtnIniciar);
            this.PanelTop.Controls.Add(this.BtnCrearCuenta);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.Location = new System.Drawing.Point(0, 0);
            this.PanelTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(1184, 122);
            this.PanelTop.TabIndex = 0;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Image = global::MicheBytesRecipes.Properties.Resources.Cute_and_animated_lo;
            this.pbxLogo.Location = new System.Drawing.Point(12, 12);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(184, 104);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 2;
            this.pbxLogo.TabStop = false;
            // 
            // BtnIniciar
            // 
            this.BtnIniciar.FlatAppearance.BorderSize = 0;
            this.BtnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIniciar.Location = new System.Drawing.Point(912, 24);
            this.BtnIniciar.Name = "BtnIniciar";
            this.BtnIniciar.Size = new System.Drawing.Size(111, 30);
            this.BtnIniciar.TabIndex = 1;
            this.BtnIniciar.Text = "Iniciar sesión";
            this.BtnIniciar.UseVisualStyleBackColor = true;
            this.BtnIniciar.Click += new System.EventHandler(this.BtnIniciar_Click);
            // 
            // BtnCrearCuenta
            // 
            this.BtnCrearCuenta.FlatAppearance.BorderSize = 0;
            this.BtnCrearCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearCuenta.Location = new System.Drawing.Point(1061, 24);
            this.BtnCrearCuenta.Name = "BtnCrearCuenta";
            this.BtnCrearCuenta.Size = new System.Drawing.Size(111, 30);
            this.BtnCrearCuenta.TabIndex = 0;
            this.BtnCrearCuenta.Text = "Crear cuenta";
            this.BtnCrearCuenta.UseVisualStyleBackColor = true;
            this.BtnCrearCuenta.Click += new System.EventHandler(this.BtnCrearCuenta_Click);
            // 
            // PanelMid
            // 
            this.PanelMid.BackColor = System.Drawing.Color.White;
            this.PanelMid.Controls.Add(this.lblFinal);
            this.PanelMid.Controls.Add(this.lblFooter);
            this.PanelMid.Controls.Add(this.lblTituloEsencia);
            this.PanelMid.Controls.Add(this.lblBullet);
            this.PanelMid.Controls.Add(this.lblTituloBullet);
            this.PanelMid.Controls.Add(this.lblRelleno);
            this.PanelMid.Controls.Add(this.lblTitulo);
            this.PanelMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMid.Location = new System.Drawing.Point(0, 122);
            this.PanelMid.Name = "PanelMid";
            this.PanelMid.Size = new System.Drawing.Size(1184, 539);
            this.PanelMid.TabIndex = 1;
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinal.Location = new System.Drawing.Point(241, 470);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(724, 25);
            this.lblFinal.TabIndex = 6;
            this.lblFinal.Text = "¡Con MicheBytes Recipes, cocinar nunca fue tan divertido, accesible y delicioso! " +
    "🍳✨";
            // 
            // lblFooter
            // 
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.lblFooter.Location = new System.Drawing.Point(130, 375);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(960, 77);
            this.lblFooter.TabIndex = 5;
            this.lblFooter.Text = resources.GetString("lblFooter.Text");
            // 
            // lblTituloEsencia
            // 
            this.lblTituloEsencia.AutoSize = true;
            this.lblTituloEsencia.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloEsencia.Location = new System.Drawing.Point(129, 333);
            this.lblTituloEsencia.Name = "lblTituloEsencia";
            this.lblTituloEsencia.Size = new System.Drawing.Size(196, 30);
            this.lblTituloEsencia.TabIndex = 4;
            this.lblTituloEsencia.Text = "🌈 Nuestra esencia";
            // 
            // lblBullet
            // 
            this.lblBullet.AutoSize = true;
            this.lblBullet.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBullet.Location = new System.Drawing.Point(130, 221);
            this.lblBullet.Name = "lblBullet";
            this.lblBullet.Size = new System.Drawing.Size(960, 92);
            this.lblBullet.TabIndex = 3;
            this.lblBullet.Text = resources.GetString("lblBullet.Text");
            // 
            // lblTituloBullet
            // 
            this.lblTituloBullet.AutoSize = true;
            this.lblTituloBullet.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloBullet.Location = new System.Drawing.Point(129, 177);
            this.lblTituloBullet.Name = "lblTituloBullet";
            this.lblTituloBullet.Size = new System.Drawing.Size(357, 30);
            this.lblTituloBullet.TabIndex = 2;
            this.lblTituloBullet.Text = "🍴 ¿Qué ofrece MicheBytes Recipes?";
            // 
            // lblRelleno
            // 
            this.lblRelleno.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelleno.Location = new System.Drawing.Point(130, 65);
            this.lblRelleno.Name = "lblRelleno";
            this.lblRelleno.Size = new System.Drawing.Size(955, 112);
            this.lblRelleno.TabIndex = 1;
            this.lblRelleno.Text = resources.GetString("lblRelleno.Text");
            this.lblRelleno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(311, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(626, 45);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "¡Bieeeenvenidos a MicheBytes Recipes! 🎉";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.PanelMid);
            this.Controls.Add(this.PanelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.PanelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.PanelMid.ResumeLayout(false);
            this.PanelMid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTop;
        private System.Windows.Forms.Button BtnIniciar;
        private System.Windows.Forms.Button BtnCrearCuenta;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Panel PanelMid;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblRelleno;
        private System.Windows.Forms.Label lblTituloBullet;
        private System.Windows.Forms.Label lblBullet;
        private System.Windows.Forms.Label lblTituloEsencia;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Label lblFinal;
    }
}

