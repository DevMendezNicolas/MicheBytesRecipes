namespace MicheBytesRecipes.Forms.AddReceta
{
    partial class PruebaImagen
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
            this.pcbImagenReceta = new System.Windows.Forms.PictureBox();
            this.btnImagen = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagenReceta)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbImagenReceta
            // 
            this.pcbImagenReceta.Location = new System.Drawing.Point(134, 47);
            this.pcbImagenReceta.Name = "pcbImagenReceta";
            this.pcbImagenReceta.Size = new System.Drawing.Size(184, 131);
            this.pcbImagenReceta.TabIndex = 0;
            this.pcbImagenReceta.TabStop = false;
            // 
            // btnImagen
            // 
            this.btnImagen.Location = new System.Drawing.Point(151, 193);
            this.btnImagen.Name = "btnImagen";
            this.btnImagen.Size = new System.Drawing.Size(140, 28);
            this.btnImagen.TabIndex = 1;
            this.btnImagen.Text = "button1";
            this.btnImagen.UseVisualStyleBackColor = true;
            this.btnImagen.Click += new System.EventHandler(this.btnImagen_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(363, 60);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(117, 20);
            this.txtId.TabIndex = 2;
            // 
            // PruebaImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnImagen);
            this.Controls.Add(this.pcbImagenReceta);
            this.Name = "PruebaImagen";
            this.Text = "PruebaImagen";
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagenReceta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbImagenReceta;
        private System.Windows.Forms.Button btnImagen;
        private System.Windows.Forms.TextBox txtId;
    }
}