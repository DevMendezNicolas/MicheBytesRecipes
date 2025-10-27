namespace MicheBytesRecipes.Forms.User
{
    partial class frmHistorial
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
            this.pnlTarjetas = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTituloHistorial = new System.Windows.Forms.Label();
            this.pnlNavegacion = new System.Windows.Forms.Panel();
            this.pbImagenUser = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnInicio = new System.Windows.Forms.Button();
            this.pnlContenido.SuspendLayout();
            this.pnlNavegacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContenido
            // 
            this.pnlContenido.Controls.Add(this.pnlTarjetas);
            this.pnlContenido.Controls.Add(this.lblTituloHistorial);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(233, 0);
            this.pnlContenido.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(951, 661);
            this.pnlContenido.TabIndex = 6;
            // 
            // pnlTarjetas
            // 
            this.pnlTarjetas.AutoScroll = true;
            this.pnlTarjetas.Location = new System.Drawing.Point(16, 79);
            this.pnlTarjetas.Name = "pnlTarjetas";
            this.pnlTarjetas.Size = new System.Drawing.Size(923, 570);
            this.pnlTarjetas.TabIndex = 5;
            // 
            // lblTituloHistorial
            // 
            this.lblTituloHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloHistorial.AutoSize = true;
            this.lblTituloHistorial.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHistorial.ForeColor = System.Drawing.Color.Orange;
            this.lblTituloHistorial.Location = new System.Drawing.Point(342, 24);
            this.lblTituloHistorial.Name = "lblTituloHistorial";
            this.lblTituloHistorial.Size = new System.Drawing.Size(267, 32);
            this.lblTituloHistorial.TabIndex = 0;
            this.lblTituloHistorial.Text = "Mi historial de recetas";
            // 
            // pnlNavegacion
            // 
            this.pnlNavegacion.BackColor = System.Drawing.Color.Orange;
            this.pnlNavegacion.Controls.Add(this.pbImagenUser);
            this.pnlNavegacion.Controls.Add(this.lblNombre);
            this.pnlNavegacion.Controls.Add(this.btnInicio);
            this.pnlNavegacion.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavegacion.Location = new System.Drawing.Point(0, 0);
            this.pnlNavegacion.Margin = new System.Windows.Forms.Padding(4);
            this.pnlNavegacion.Name = "pnlNavegacion";
            this.pnlNavegacion.Size = new System.Drawing.Size(233, 661);
            this.pnlNavegacion.TabIndex = 5;
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
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(13, 116);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(198, 74);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "Nombre Usuario";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.DarkOrange;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Location = new System.Drawing.Point(13, 550);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(4);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(198, 42);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "🔙 &Inicio ";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // frmHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlNavegacion);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmHistorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial";
            this.Load += new System.EventHandler(this.Historial_Load);
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            this.pnlNavegacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Label lblTituloHistorial;
        private System.Windows.Forms.Panel pnlNavegacion;
        private System.Windows.Forms.PictureBox pbImagenUser;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.FlowLayoutPanel pnlTarjetas;
    }
}