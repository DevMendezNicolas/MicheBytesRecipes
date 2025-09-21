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
            this.label2 = new System.Windows.Forms.Label();
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
            this.PanelMid.Controls.Add(this.label2);
            this.PanelMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMid.Location = new System.Drawing.Point(0, 122);
            this.PanelMid.Name = "PanelMid";
            this.PanelMid.Size = new System.Drawing.Size(1184, 539);
            this.PanelMid.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1005, 462);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
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
            this.Load += new System.EventHandler(this.FrmInicio_Load);
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
        private System.Windows.Forms.Panel PanelMid;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Label label2;
    }
}

