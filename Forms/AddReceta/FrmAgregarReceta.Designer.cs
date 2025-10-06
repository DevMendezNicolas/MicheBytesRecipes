namespace MicheBytesRecipes.Forms.AddReceta
{
    partial class FrmAgregarReceta
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
            this.TXTnombre = new System.Windows.Forms.TextBox();
            this.CBOpais = new System.Windows.Forms.ComboBox();
            this.CBOcategoria = new System.Windows.Forms.ComboBox();
            this.CBOdificultad = new System.Windows.Forms.ComboBox();
            this.DTPtiempo = new System.Windows.Forms.DateTimePicker();
            this.TXTdescripcion = new System.Windows.Forms.TextBox();
            this.TXTinstrucciones = new System.Windows.Forms.TextBox();
            this.PCBimagen = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnImagen = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.CMDcargar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.clbIngredientes = new System.Windows.Forms.CheckedListBox();
            this.btnAgregarIngrediente = new System.Windows.Forms.Button();
            this.btnPais = new System.Windows.Forms.Button();
            this.btbAgregarCategorias = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PCBimagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // TXTnombre
            // 
            this.TXTnombre.Location = new System.Drawing.Point(21, 84);
            this.TXTnombre.Name = "TXTnombre";
            this.TXTnombre.Size = new System.Drawing.Size(335, 20);
            this.TXTnombre.TabIndex = 2;
            // 
            // CBOpais
            // 
            this.CBOpais.FormattingEnabled = true;
            this.CBOpais.Location = new System.Drawing.Point(21, 131);
            this.CBOpais.Name = "CBOpais";
            this.CBOpais.Size = new System.Drawing.Size(335, 21);
            this.CBOpais.TabIndex = 5;
            // 
            // CBOcategoria
            // 
            this.CBOcategoria.FormattingEnabled = true;
            this.CBOcategoria.Location = new System.Drawing.Point(21, 179);
            this.CBOcategoria.Name = "CBOcategoria";
            this.CBOcategoria.Size = new System.Drawing.Size(335, 21);
            this.CBOcategoria.TabIndex = 6;
            // 
            // CBOdificultad
            // 
            this.CBOdificultad.FormattingEnabled = true;
            this.CBOdificultad.Location = new System.Drawing.Point(21, 227);
            this.CBOdificultad.Name = "CBOdificultad";
            this.CBOdificultad.Size = new System.Drawing.Size(335, 21);
            this.CBOdificultad.TabIndex = 8;
            // 
            // DTPtiempo
            // 
            this.DTPtiempo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPtiempo.Location = new System.Drawing.Point(653, 81);
            this.DTPtiempo.Name = "DTPtiempo";
            this.DTPtiempo.Size = new System.Drawing.Size(265, 20);
            this.DTPtiempo.TabIndex = 9;
            // 
            // TXTdescripcion
            // 
            this.TXTdescripcion.Location = new System.Drawing.Point(647, 367);
            this.TXTdescripcion.Multiline = true;
            this.TXTdescripcion.Name = "TXTdescripcion";
            this.TXTdescripcion.Size = new System.Drawing.Size(495, 157);
            this.TXTdescripcion.TabIndex = 12;
            // 
            // TXTinstrucciones
            // 
            this.TXTinstrucciones.Location = new System.Drawing.Point(647, 228);
            this.TXTinstrucciones.Multiline = true;
            this.TXTinstrucciones.Name = "TXTinstrucciones";
            this.TXTinstrucciones.Size = new System.Drawing.Size(494, 107);
            this.TXTinstrucciones.TabIndex = 14;
            // 
            // PCBimagen
            // 
            this.PCBimagen.Location = new System.Drawing.Point(975, 27);
            this.PCBimagen.Name = "PCBimagen";
            this.PCBimagen.Size = new System.Drawing.Size(166, 101);
            this.PCBimagen.TabIndex = 15;
            this.PCBimagen.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnImagen
            // 
            this.btnImagen.Location = new System.Drawing.Point(975, 134);
            this.btnImagen.Name = "btnImagen";
            this.btnImagen.Size = new System.Drawing.Size(129, 33);
            this.btnImagen.TabIndex = 16;
            this.btnImagen.Text = "&Cargar imagen";
            this.btnImagen.UseVisualStyleBackColor = true;
            this.btnImagen.Click += new System.EventHandler(this.btnImagen_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(853, 585);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(113, 48);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CMDcargar
            // 
            this.CMDcargar.Location = new System.Drawing.Point(999, 585);
            this.CMDcargar.Name = "CMDcargar";
            this.CMDcargar.Size = new System.Drawing.Size(121, 48);
            this.CMDcargar.TabIndex = 18;
            this.CMDcargar.Text = "&Cargar";
            this.CMDcargar.UseVisualStyleBackColor = true;
            this.CMDcargar.Click += new System.EventHandler(this.CMDcargar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 292);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 21);
            this.label9.TabIndex = 19;
            this.label9.Text = "Ingredientes:";
            // 
            // clbIngredientes
            // 
            this.clbIngredientes.FormattingEnabled = true;
            this.clbIngredientes.Location = new System.Drawing.Point(21, 325);
            this.clbIngredientes.Name = "clbIngredientes";
            this.clbIngredientes.Size = new System.Drawing.Size(340, 199);
            this.clbIngredientes.TabIndex = 20;
            // 
            // btnAgregarIngrediente
            // 
            this.btnAgregarIngrediente.Location = new System.Drawing.Point(26, 552);
            this.btnAgregarIngrediente.Name = "btnAgregarIngrediente";
            this.btnAgregarIngrediente.Size = new System.Drawing.Size(143, 38);
            this.btnAgregarIngrediente.TabIndex = 21;
            this.btnAgregarIngrediente.Text = "&Agregar nuevo Ingrediente";
            this.btnAgregarIngrediente.UseVisualStyleBackColor = true;
            this.btnAgregarIngrediente.Click += new System.EventHandler(this.btnAgregarIngrediente_Click);
            // 
            // btnPais
            // 
            this.btnPais.Location = new System.Drawing.Point(26, 596);
            this.btnPais.Name = "btnPais";
            this.btnPais.Size = new System.Drawing.Size(143, 38);
            this.btnPais.TabIndex = 22;
            this.btnPais.Text = "&Agregar nuevo pais";
            this.btnPais.UseVisualStyleBackColor = true;
            this.btnPais.Click += new System.EventHandler(this.btnPais_Click);
            // 
            // btbAgregarCategorias
            // 
            this.btbAgregarCategorias.Location = new System.Drawing.Point(188, 596);
            this.btbAgregarCategorias.Name = "btbAgregarCategorias";
            this.btbAgregarCategorias.Size = new System.Drawing.Size(145, 37);
            this.btbAgregarCategorias.TabIndex = 23;
            this.btbAgregarCategorias.Text = "&Agregar nueva categoria";
            this.btbAgregarCategorias.UseVisualStyleBackColor = true;
            this.btbAgregarCategorias.Click += new System.EventHandler(this.btbAgregarCategorias_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(345, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(219, 37);
            this.lblNombre.TabIndex = 24;
            this.lblNombre.Text = "Agregar recetas";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(649, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 21);
            this.label1.TabIndex = 25;
            this.label1.Text = "Instrucciones:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(643, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 21);
            this.label10.TabIndex = 26;
            this.label10.Text = "Descripcion:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(656, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 21);
            this.label7.TabIndex = 27;
            this.label7.Text = "Tiempo de preparacion:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 21);
            this.label6.TabIndex = 28;
            this.label6.Text = "Dificultad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 21);
            this.label5.TabIndex = 29;
            this.label5.Text = "Categoria:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 21);
            this.label8.TabIndex = 30;
            this.label8.Text = "Pais:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(24, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 21);
            this.label11.TabIndex = 31;
            this.label11.Text = "Nombre:";
            // 
            // FrmAgregarReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btbAgregarCategorias);
            this.Controls.Add(this.btnPais);
            this.Controls.Add(this.btnAgregarIngrediente);
            this.Controls.Add(this.clbIngredientes);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CMDcargar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImagen);
            this.Controls.Add(this.PCBimagen);
            this.Controls.Add(this.TXTinstrucciones);
            this.Controls.Add(this.TXTdescripcion);
            this.Controls.Add(this.DTPtiempo);
            this.Controls.Add(this.CBOdificultad);
            this.Controls.Add(this.CBOcategoria);
            this.Controls.Add(this.CBOpais);
            this.Controls.Add(this.TXTnombre);
            this.Name = "FrmAgregarReceta";
            this.Text = "FrmAgregarReceta";
            this.Load += new System.EventHandler(this.FrmAgregarReceta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PCBimagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TXTnombre;
        private System.Windows.Forms.ComboBox CBOpais;
        private System.Windows.Forms.ComboBox CBOcategoria;
        private System.Windows.Forms.ComboBox CBOdificultad;
        private System.Windows.Forms.DateTimePicker DTPtiempo;
        private System.Windows.Forms.TextBox TXTdescripcion;
        private System.Windows.Forms.TextBox TXTinstrucciones;
        private System.Windows.Forms.PictureBox PCBimagen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnImagen;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button CMDcargar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnAgregarIngrediente;
        private System.Windows.Forms.CheckedListBox clbIngredientes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPais;
        private System.Windows.Forms.Button btbAgregarCategorias;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
    }
}