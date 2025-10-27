namespace MicheBytesRecipes.Forms.User
{
    partial class frmMenuUsuario
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
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.lblTituloMichebyte = new System.Windows.Forms.Label();
            this.pnlTarjetas = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReinicio = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboDificultad = new System.Windows.Forms.ComboBox();
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.lblDificultad = new System.Windows.Forms.Label();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtBuscarReceta = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.pnlNavegacion = new System.Windows.Forms.Panel();
            this.pbImagenUser = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnHistorialRecetas = new System.Windows.Forms.Button();
            this.btnHistorialFav = new System.Windows.Forms.Button();
            this.pnlContenido.SuspendLayout();
            this.pnlNavegacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.Wheat;
            this.pnlContenido.Controls.Add(this.lblTituloMichebyte);
            this.pnlContenido.Controls.Add(this.pnlTarjetas);
            this.pnlContenido.Controls.Add(this.btnReinicio);
            this.pnlContenido.Controls.Add(this.btnBuscar);
            this.pnlContenido.Controls.Add(this.cboDificultad);
            this.pnlContenido.Controls.Add(this.cboPais);
            this.pnlContenido.Controls.Add(this.cboCategoria);
            this.pnlContenido.Controls.Add(this.lblDificultad);
            this.pnlContenido.Controls.Add(this.lblPais);
            this.pnlContenido.Controls.Add(this.lblCategoria);
            this.pnlContenido.Controls.Add(this.txtBuscarReceta);
            this.pnlContenido.Controls.Add(this.lblBuscar);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(233, 0);
            this.pnlContenido.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(951, 661);
            this.pnlContenido.TabIndex = 4;
            // 
            // lblTituloMichebyte
            // 
            this.lblTituloMichebyte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloMichebyte.AutoSize = true;
            this.lblTituloMichebyte.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloMichebyte.ForeColor = System.Drawing.Color.Orange;
            this.lblTituloMichebyte.Location = new System.Drawing.Point(326, 24);
            this.lblTituloMichebyte.Name = "lblTituloMichebyte";
            this.lblTituloMichebyte.Size = new System.Drawing.Size(245, 32);
            this.lblTituloMichebyte.TabIndex = 13;
            this.lblTituloMichebyte.Text = "Michebytes Recetas!";
            // 
            // pnlTarjetas
            // 
            this.pnlTarjetas.AutoScroll = true;
            this.pnlTarjetas.Location = new System.Drawing.Point(16, 210);
            this.pnlTarjetas.Name = "pnlTarjetas";
            this.pnlTarjetas.Size = new System.Drawing.Size(923, 439);
            this.pnlTarjetas.TabIndex = 12;
            // 
            // btnReinicio
            // 
            this.btnReinicio.AutoSize = true;
            this.btnReinicio.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReinicio.ForeColor = System.Drawing.Color.Orange;
            this.btnReinicio.Location = new System.Drawing.Point(772, 160);
            this.btnReinicio.Name = "btnReinicio";
            this.btnReinicio.Size = new System.Drawing.Size(147, 30);
            this.btnReinicio.TabIndex = 7;
            this.btnReinicio.Text = "🔄 Reiniciar filtros";
            this.btnReinicio.UseVisualStyleBackColor = true;
            this.btnReinicio.Click += new System.EventHandler(this.btnReinicio_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Orange;
            this.btnBuscar.Location = new System.Drawing.Point(772, 87);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(131, 29);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "🔍 Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboDificultad
            // 
            this.cboDificultad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDificultad.ForeColor = System.Drawing.Color.Orange;
            this.cboDificultad.FormattingEnabled = true;
            this.cboDificultad.Location = new System.Drawing.Point(566, 164);
            this.cboDificultad.Name = "cboDificultad";
            this.cboDificultad.Size = new System.Drawing.Size(179, 25);
            this.cboDificultad.TabIndex = 5;
            // 
            // cboPais
            // 
            this.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPais.ForeColor = System.Drawing.Color.Orange;
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(332, 164);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(179, 25);
            this.cboPais.TabIndex = 4;
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.ForeColor = System.Drawing.Color.Orange;
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(75, 164);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(179, 25);
            this.cboCategoria.TabIndex = 3;
            // 
            // lblDificultad
            // 
            this.lblDificultad.AutoSize = true;
            this.lblDificultad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDificultad.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDificultad.ForeColor = System.Drawing.Color.Orange;
            this.lblDificultad.Location = new System.Drawing.Point(562, 135);
            this.lblDificultad.Name = "lblDificultad";
            this.lblDificultad.Size = new System.Drawing.Size(81, 20);
            this.lblDificultad.TabIndex = 2;
            this.lblDificultad.Text = "Dificultad:";
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPais.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPais.ForeColor = System.Drawing.Color.Orange;
            this.lblPais.Location = new System.Drawing.Point(328, 136);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(41, 20);
            this.lblPais.TabIndex = 2;
            this.lblPais.Text = "País:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.ForeColor = System.Drawing.Color.Orange;
            this.lblCategoria.Location = new System.Drawing.Point(71, 134);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(80, 20);
            this.lblCategoria.TabIndex = 2;
            this.lblCategoria.Text = "Categoría:";
            // 
            // txtBuscarReceta
            // 
            this.txtBuscarReceta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarReceta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarReceta.ForeColor = System.Drawing.Color.Orange;
            this.txtBuscarReceta.Location = new System.Drawing.Point(257, 87);
            this.txtBuscarReceta.Name = "txtBuscarReceta";
            this.txtBuscarReceta.Size = new System.Drawing.Size(488, 29);
            this.txtBuscarReceta.TabIndex = 1;
            this.txtBuscarReceta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarReceta_KeyPress);
            // 
            // lblBuscar
            // 
            this.lblBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color.Orange;
            this.lblBuscar.Location = new System.Drawing.Point(49, 90);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(194, 20);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar receta por nombre:";
            // 
            // pnlNavegacion
            // 
            this.pnlNavegacion.BackColor = System.Drawing.Color.Orange;
            this.pnlNavegacion.Controls.Add(this.pbImagenUser);
            this.pnlNavegacion.Controls.Add(this.lblNombre);
            this.pnlNavegacion.Controls.Add(this.btnCerrarSesion);
            this.pnlNavegacion.Controls.Add(this.btnConfig);
            this.pnlNavegacion.Controls.Add(this.btnHistorialRecetas);
            this.pnlNavegacion.Controls.Add(this.btnHistorialFav);
            this.pnlNavegacion.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavegacion.Location = new System.Drawing.Point(0, 0);
            this.pnlNavegacion.Margin = new System.Windows.Forms.Padding(4);
            this.pnlNavegacion.Name = "pnlNavegacion";
            this.pnlNavegacion.Size = new System.Drawing.Size(233, 661);
            this.pnlNavegacion.TabIndex = 3;
            // 
            // pbImagenUser
            // 
            this.pbImagenUser.Location = new System.Drawing.Point(34, 24);
            this.pbImagenUser.Name = "pbImagenUser";
            this.pbImagenUser.Size = new System.Drawing.Size(154, 85);
            this.pbImagenUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagenUser.TabIndex = 12;
            this.pbImagenUser.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(13, 116);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(198, 74);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "Nombre Usuario";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Red;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(13, 572);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(198, 42);
            this.btnCerrarSesion.TabIndex = 10;
            this.btnCerrarSesion.Text = "&Cerrar sesión ";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.BackColor = System.Drawing.Color.DarkOrange;
            this.btnConfig.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfig.ForeColor = System.Drawing.Color.White;
            this.btnConfig.Location = new System.Drawing.Point(13, 525);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(198, 42);
            this.btnConfig.TabIndex = 10;
            this.btnConfig.Text = "&Configuración";
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnHistorialRecetas
            // 
            this.btnHistorialRecetas.BackColor = System.Drawing.Color.Gold;
            this.btnHistorialRecetas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorialRecetas.ForeColor = System.Drawing.Color.White;
            this.btnHistorialRecetas.Location = new System.Drawing.Point(13, 475);
            this.btnHistorialRecetas.Margin = new System.Windows.Forms.Padding(4);
            this.btnHistorialRecetas.Name = "btnHistorialRecetas";
            this.btnHistorialRecetas.Size = new System.Drawing.Size(198, 42);
            this.btnHistorialRecetas.TabIndex = 9;
            this.btnHistorialRecetas.Text = "&Mi Historial";
            this.btnHistorialRecetas.UseVisualStyleBackColor = false;
            this.btnHistorialRecetas.Click += new System.EventHandler(this.btnHistorialRecetas_Click);
            // 
            // btnHistorialFav
            // 
            this.btnHistorialFav.BackColor = System.Drawing.Color.Salmon;
            this.btnHistorialFav.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorialFav.ForeColor = System.Drawing.Color.White;
            this.btnHistorialFav.Location = new System.Drawing.Point(13, 210);
            this.btnHistorialFav.Margin = new System.Windows.Forms.Padding(4);
            this.btnHistorialFav.Name = "btnHistorialFav";
            this.btnHistorialFav.Size = new System.Drawing.Size(198, 42);
            this.btnHistorialFav.TabIndex = 8;
            this.btnHistorialFav.Text = "&Ver Favoritas";
            this.btnHistorialFav.UseVisualStyleBackColor = false;
            this.btnHistorialFav.Click += new System.EventHandler(this.btnHistorialFav_Click);
            // 
            // frmMenuUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlNavegacion);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmMenuUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuUser_FormClosing);
            this.Load += new System.EventHandler(this.MenuUser_Load);
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            this.pnlNavegacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Button btnReinicio;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboDificultad;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label lblDificultad;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtBuscarReceta;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Panel pnlNavegacion;
        private System.Windows.Forms.PictureBox pbImagenUser;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnHistorialRecetas;
        private System.Windows.Forms.Button btnHistorialFav;
        private System.Windows.Forms.FlowLayoutPanel pnlTarjetas;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lblTituloMichebyte;
    }
}