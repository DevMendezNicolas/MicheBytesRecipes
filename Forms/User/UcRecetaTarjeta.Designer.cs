namespace MicheBytesRecipes.Forms.User
{
    partial class UcRecetaTarjeta
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNombreReceta = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblDificultad = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.pbImagenReceta = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenReceta)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombreReceta
            // 
            this.lblNombreReceta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombreReceta.AutoSize = true;
            this.lblNombreReceta.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreReceta.Location = new System.Drawing.Point(27, 12);
            this.lblNombreReceta.Name = "lblNombreReceta";
            this.lblNombreReceta.Size = new System.Drawing.Size(149, 25);
            this.lblNombreReceta.TabIndex = 1;
            this.lblNombreReceta.Text = "Nombre Receta";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(32, 141);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(77, 21);
            this.lblCategoria.TabIndex = 2;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPais.Location = new System.Drawing.Point(32, 168);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(58, 21);
            this.lblPais.TabIndex = 3;
            this.lblPais.Text = "Origen";
            // 
            // lblDificultad
            // 
            this.lblDificultad.AutoSize = true;
            this.lblDificultad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDificultad.Location = new System.Drawing.Point(32, 195);
            this.lblDificultad.Name = "lblDificultad";
            this.lblDificultad.Size = new System.Drawing.Size(76, 21);
            this.lblDificultad.TabIndex = 4;
            this.lblDificultad.Text = "Dificultad";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempo.Location = new System.Drawing.Point(32, 222);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(62, 21);
            this.lblTiempo.TabIndex = 5;
            this.lblTiempo.Text = "Tiempo";
            // 
            // pbImagenReceta
            // 
            this.pbImagenReceta.Location = new System.Drawing.Point(32, 54);
            this.pbImagenReceta.Name = "pbImagenReceta";
            this.pbImagenReceta.Size = new System.Drawing.Size(128, 74);
            this.pbImagenReceta.TabIndex = 0;
            this.pbImagenReceta.TabStop = false;
            // 
            // UcRecetaTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblDificultad);
            this.Controls.Add(this.lblPais);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblNombreReceta);
            this.Controls.Add(this.pbImagenReceta);
            this.Name = "UcRecetaTarjeta";
            this.Size = new System.Drawing.Size(200, 250);
            this.Click += new System.EventHandler(this.UcRecetaTarjeta_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenReceta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImagenReceta;
        private System.Windows.Forms.Label lblNombreReceta;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.Label lblDificultad;
        private System.Windows.Forms.Label lblTiempo;
    }
}
