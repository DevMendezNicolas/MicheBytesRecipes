namespace MicheBytesRecipes.Classes.Recetas
{
    partial class frmVerReceta
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
            this.components = new System.ComponentModel.Container();
            this.pbxImagen = new System.Windows.Forms.PictureBox();
            this.lstIngredientes = new System.Windows.Forms.ListView();
            this.lblIdReceta = new System.Windows.Forms.Label();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rtbInstrucciones = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDificultad = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnMeGusta = new System.Windows.Forms.Button();
            this.btnFavoritos = new System.Windows.Forms.Button();
            this.lblMeGusta = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstComentarios = new System.Windows.Forms.ListBox();
            this.btnComentar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExportarPdf = new System.Windows.Forms.Button();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmsComentarios = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.borrarComentarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.cmsComentarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxImagen
            // 
            this.pbxImagen.Location = new System.Drawing.Point(789, 211);
            this.pbxImagen.Name = "pbxImagen";
            this.pbxImagen.Size = new System.Drawing.Size(383, 250);
            this.pbxImagen.TabIndex = 7;
            this.pbxImagen.TabStop = false;
            // 
            // lstIngredientes
            // 
            this.lstIngredientes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstIngredientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstIngredientes.ForeColor = System.Drawing.Color.Silver;
            this.lstIngredientes.HideSelection = false;
            this.lstIngredientes.Location = new System.Drawing.Point(16, 211);
            this.lstIngredientes.MultiSelect = false;
            this.lstIngredientes.Name = "lstIngredientes";
            this.lstIngredientes.Size = new System.Drawing.Size(103, 250);
            this.lstIngredientes.TabIndex = 10;
            this.lstIngredientes.UseCompatibleStateImageBehavior = false;
            // 
            // lblIdReceta
            // 
            this.lblIdReceta.AutoSize = true;
            this.lblIdReceta.Location = new System.Drawing.Point(11, 635);
            this.lblIdReceta.Name = "lblIdReceta";
            this.lblIdReceta.Size = new System.Drawing.Size(0, 13);
            this.lblIdReceta.TabIndex = 19;
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Location = new System.Drawing.Point(64, 635);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblIdUsuario.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Handwriting", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(11, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 23;
            this.label1.Text = "Ingredientes";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Lucida Handwriting", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(367, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 21);
            this.label6.TabIndex = 24;
            this.label6.Text = "Instrucciones";
            // 
            // rtbInstrucciones
            // 
            this.rtbInstrucciones.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbInstrucciones.ForeColor = System.Drawing.Color.OrangeRed;
            this.rtbInstrucciones.Location = new System.Drawing.Point(145, 211);
            this.rtbInstrucciones.MaximumSize = new System.Drawing.Size(620, 250);
            this.rtbInstrucciones.MinimumSize = new System.Drawing.Size(500, 250);
            this.rtbInstrucciones.Name = "rtbInstrucciones";
            this.rtbInstrucciones.Size = new System.Drawing.Size(620, 250);
            this.rtbInstrucciones.TabIndex = 26;
            this.rtbInstrucciones.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OrangeRed;
            this.panel1.Controls.Add(this.lblCategoria);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblPais);
            this.panel1.Controls.Add(this.lblTiempo);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblDificultad);
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.lblDescripcion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 184);
            this.panel1.TabIndex = 28;
            // 
            // lblCategoria
            // 
            this.lblCategoria.BackColor = System.Drawing.Color.OrangeRed;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.ForeColor = System.Drawing.Color.Black;
            this.lblCategoria.Location = new System.Drawing.Point(357, 48);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(152, 24);
            this.lblCategoria.TabIndex = 34;
            this.lblCategoria.Text = "Categoria";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.OrangeRed;
            this.label4.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(238, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 26);
            this.label4.TabIndex = 33;
            this.label4.Text = "Categoria:";
            // 
            // lblPais
            // 
            this.lblPais.BackColor = System.Drawing.Color.OrangeRed;
            this.lblPais.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPais.ForeColor = System.Drawing.Color.Black;
            this.lblPais.Location = new System.Drawing.Point(80, 48);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(152, 24);
            this.lblPais.TabIndex = 35;
            this.lblPais.Text = "Argentina";
            // 
            // lblTiempo
            // 
            this.lblTiempo.BackColor = System.Drawing.Color.OrangeRed;
            this.lblTiempo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempo.ForeColor = System.Drawing.Color.Black;
            this.lblTiempo.Location = new System.Drawing.Point(1071, 48);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(101, 24);
            this.lblTiempo.TabIndex = 30;
            this.lblTiempo.Text = "--";
            // 
            // lblNombre
            // 
            this.lblNombre.BackColor = System.Drawing.Color.OrangeRed;
            this.lblNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Snow;
            this.lblNombre.Location = new System.Drawing.Point(0, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(1184, 37);
            this.lblNombre.TabIndex = 28;
            this.lblNombre.Text = "Milanesa napolitana";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.OrangeRed;
            this.label8.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(12, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(291, 21);
            this.label8.TabIndex = 41;
            this.label8.Text = "Descripción de la receta:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.OrangeRed;
            this.label2.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(798, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 26);
            this.label2.TabIndex = 29;
            this.label2.Text = "Tiempo de preparacion:";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.OrangeRed;
            this.label7.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 26);
            this.label7.TabIndex = 40;
            this.label7.Text = "País:";
            // 
            // lblDificultad
            // 
            this.lblDificultad.BackColor = System.Drawing.Color.OrangeRed;
            this.lblDificultad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDificultad.ForeColor = System.Drawing.Color.Black;
            this.lblDificultad.Location = new System.Drawing.Point(667, 47);
            this.lblDificultad.Name = "lblDificultad";
            this.lblDificultad.Size = new System.Drawing.Size(125, 24);
            this.lblDificultad.TabIndex = 32;
            this.lblDificultad.Text = "Dificultad";
            // 
            // label
            // 
            this.label.BackColor = System.Drawing.Color.OrangeRed;
            this.label.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(539, 48);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(158, 26);
            this.label.TabIndex = 31;
            this.label.Text = "Dificultad:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.BackColor = System.Drawing.Color.OrangeRed;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.Black;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 113);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(1156, 71);
            this.lblDescripcion.TabIndex = 36;
            this.lblDescripcion.Text = "Clásicas milanesas de carne empanada, gratinadas con salsa de tomate, jamón y que" +
    "so, ideales para una cena reconfortante.";
            // 
            // btnMeGusta
            // 
            this.btnMeGusta.BackColor = System.Drawing.Color.DarkOrange;
            this.btnMeGusta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeGusta.ForeColor = System.Drawing.Color.White;
            this.btnMeGusta.Location = new System.Drawing.Point(1042, 4);
            this.btnMeGusta.Name = "btnMeGusta";
            this.btnMeGusta.Size = new System.Drawing.Size(126, 41);
            this.btnMeGusta.TabIndex = 1;
            this.btnMeGusta.Text = "MeGusta";
            this.btnMeGusta.UseVisualStyleBackColor = false;
            this.btnMeGusta.Click += new System.EventHandler(this.btnMeGusta_Click);
            // 
            // btnFavoritos
            // 
            this.btnFavoritos.BackColor = System.Drawing.Color.Salmon;
            this.btnFavoritos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFavoritos.ForeColor = System.Drawing.Color.White;
            this.btnFavoritos.Location = new System.Drawing.Point(1042, 47);
            this.btnFavoritos.Name = "btnFavoritos";
            this.btnFavoritos.Size = new System.Drawing.Size(126, 41);
            this.btnFavoritos.TabIndex = 2;
            this.btnFavoritos.Text = "Favorito";
            this.btnFavoritos.UseVisualStyleBackColor = false;
            this.btnFavoritos.Click += new System.EventHandler(this.btnFavoritos_Click);
            // 
            // lblMeGusta
            // 
            this.lblMeGusta.AutoSize = true;
            this.lblMeGusta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeGusta.Location = new System.Drawing.Point(1012, 15);
            this.lblMeGusta.Name = "lblMeGusta";
            this.lblMeGusta.Size = new System.Drawing.Size(17, 20);
            this.lblMeGusta.TabIndex = 39;
            this.lblMeGusta.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.OrangeRed;
            this.panel2.Controls.Add(this.lstComentarios);
            this.panel2.Controls.Add(this.btnComentar);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnExportarPdf);
            this.panel2.Controls.Add(this.txtComentario);
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnFavoritos);
            this.panel2.Controls.Add(this.btnMeGusta);
            this.panel2.Controls.Add(this.lblMeGusta);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 467);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1184, 194);
            this.panel2.TabIndex = 29;
            // 
            // lstComentarios
            // 
            this.lstComentarios.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstComentarios.FormattingEnabled = true;
            this.lstComentarios.Location = new System.Drawing.Point(517, 47);
            this.lstComentarios.Name = "lstComentarios";
            this.lstComentarios.Size = new System.Drawing.Size(502, 134);
            this.lstComentarios.TabIndex = 25;
            this.lstComentarios.Click += new System.EventHandler(this.lstComentarios_Click);
            this.lstComentarios.SelectedIndexChanged += new System.EventHandler(this.lstComentarios_SelectedIndexChanged);
            this.lstComentarios.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstComentarios_MouseDown);
            // 
            // btnComentar
            // 
            this.btnComentar.BackColor = System.Drawing.Color.Wheat;
            this.btnComentar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComentar.Location = new System.Drawing.Point(370, 161);
            this.btnComentar.Name = "btnComentar";
            this.btnComentar.Size = new System.Drawing.Size(111, 30);
            this.btnComentar.TabIndex = 3;
            this.btnComentar.Text = "Comentar";
            this.btnComentar.UseVisualStyleBackColor = false;
            this.btnComentar.Click += new System.EventHandler(this.btnComentar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(23, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 21);
            this.label3.TabIndex = 23;
            this.label3.Text = "Deja un comentario:";
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.BackColor = System.Drawing.Color.Gold;
            this.btnExportarPdf.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportarPdf.Location = new System.Drawing.Point(1042, 93);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(126, 41);
            this.btnExportarPdf.TabIndex = 4;
            this.btnExportarPdf.Text = "Exportar PDF";
            this.btnExportarPdf.UseVisualStyleBackColor = false;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            // 
            // txtComentario
            // 
            this.txtComentario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtComentario.Location = new System.Drawing.Point(25, 47);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(456, 108);
            this.txtComentario.TabIndex = 24;
            this.txtComentario.Enter += new System.EventHandler(this.txtComentario_Enter);
            this.txtComentario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComentario_KeyPress);
            this.txtComentario.Leave += new System.EventHandler(this.txtComentario_Leave);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1042, 140);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(126, 41);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "🔙 Menú";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(513, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 21);
            this.label5.TabIndex = 26;
            this.label5.Text = "Nuestros usuarios:";
            // 
            // cmsComentarios
            // 
            this.cmsComentarios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borrarComentarioToolStripMenuItem});
            this.cmsComentarios.Name = "cmsComentarios";
            this.cmsComentarios.Size = new System.Drawing.Size(171, 26);
            // 
            // borrarComentarioToolStripMenuItem
            // 
            this.borrarComentarioToolStripMenuItem.Name = "borrarComentarioToolStripMenuItem";
            this.borrarComentarioToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.borrarComentarioToolStripMenuItem.Text = "Borrar comentario";
            this.borrarComentarioToolStripMenuItem.Click += new System.EventHandler(this.borrarComentarioToolStripMenuItem_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(469, 342);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(194, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 40;
            this.progressBar.Visible = false;
            // 
            // frmVerReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rtbInstrucciones);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblIdUsuario);
            this.Controls.Add(this.lblIdReceta);
            this.Controls.Add(this.lstIngredientes);
            this.Controls.Add(this.pbxImagen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmVerReceta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVerReceta";
            this.Load += new System.EventHandler(this.FrmVerReceta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.cmsComentarios.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbxImagen;
        private System.Windows.Forms.ListView lstIngredientes;
        private System.Windows.Forms.Label lblIdReceta;
        private System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtbInstrucciones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label lblDificultad;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Button btnMeGusta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFavoritos;
        private System.Windows.Forms.Label lblMeGusta;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lstComentarios;
        private System.Windows.Forms.Button btnComentar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExportarPdf;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip cmsComentarios;
        private System.Windows.Forms.ToolStripMenuItem borrarComentarioToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}