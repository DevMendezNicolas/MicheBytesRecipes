namespace MicheBytesRecipes.Forms.User
{
    partial class Historial
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
            this.lblHistorial = new System.Windows.Forms.Label();
            this.pnlNavegacion = new System.Windows.Forms.Panel();
            this.pbImagenUser = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblReceta = new System.Windows.Forms.Label();
            this.btnHistorialPdf = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.pnlContenido.SuspendLayout();
            this.pnlNavegacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContenido
            // 
            this.pnlContenido.Controls.Add(this.pnlTarjetas);
            this.pnlContenido.Controls.Add(this.lblHistorial);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(236, 64);
            this.pnlContenido.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(945, 594);
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
            // lblHistorial
            // 
            this.lblHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorial.Location = new System.Drawing.Point(342, -9);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(201, 25);
            this.lblHistorial.TabIndex = 0;
            this.lblHistorial.Text = "Mi historial de recetas";
            // 
            // pnlNavegacion
            // 
            this.pnlNavegacion.Controls.Add(this.pbImagenUser);
            this.pnlNavegacion.Controls.Add(this.lblNombre);
            this.pnlNavegacion.Controls.Add(this.lblReceta);
            this.pnlNavegacion.Controls.Add(this.btnHistorialPdf);
            this.pnlNavegacion.Controls.Add(this.btnInicio);
            this.pnlNavegacion.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavegacion.Location = new System.Drawing.Point(3, 64);
            this.pnlNavegacion.Margin = new System.Windows.Forms.Padding(4);
            this.pnlNavegacion.Name = "pnlNavegacion";
            this.pnlNavegacion.Size = new System.Drawing.Size(233, 594);
            this.pnlNavegacion.TabIndex = 5;
            // 
            // pbImagenUser
            // 
            this.pbImagenUser.Location = new System.Drawing.Point(34, 24);
            this.pbImagenUser.Name = "pbImagenUser";
            this.pbImagenUser.Size = new System.Drawing.Size(154, 85);
            this.pbImagenUser.TabIndex = 12;
            this.pbImagenUser.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(13, 83);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(198, 74);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "Nombre Usuario";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReceta
            // 
            this.lblReceta.AutoSize = true;
            this.lblReceta.Location = new System.Drawing.Point(81, 210);
            this.lblReceta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReceta.Name = "lblReceta";
            this.lblReceta.Size = new System.Drawing.Size(59, 17);
            this.lblReceta.TabIndex = 9;
            this.lblReceta.Text = "Acciones";
            // 
            // btnHistorialPdf
            // 
            this.btnHistorialPdf.Location = new System.Drawing.Point(13, 231);
            this.btnHistorialPdf.Margin = new System.Windows.Forms.Padding(4);
            this.btnHistorialPdf.Name = "btnHistorialPdf";
            this.btnHistorialPdf.Size = new System.Drawing.Size(198, 42);
            this.btnHistorialPdf.TabIndex = 3;
            this.btnHistorialPdf.Text = "&Exportar Historial";
            this.btnHistorialPdf.UseVisualStyleBackColor = true;
            this.btnHistorialPdf.Click += new System.EventHandler(this.btnHistorialPdf_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.Location = new System.Drawing.Point(13, 550);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(4);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(198, 42);
            this.btnInicio.TabIndex = 2;
            this.btnInicio.Text = "&Inicio";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // Historial
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
            this.Name = "Historial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial";
            this.Load += new System.EventHandler(this.Historial_Load);
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            this.pnlNavegacion.ResumeLayout(false);
            this.pnlNavegacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.Panel pnlNavegacion;
        private System.Windows.Forms.PictureBox pbImagenUser;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblReceta;
        private System.Windows.Forms.Button btnHistorialPdf;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.FlowLayoutPanel pnlTarjetas;
    }
}