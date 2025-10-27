namespace MicheBytesRecipes.Forms.AddReceta
{
    partial class frmAgregarReceta
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.TXTnombre = new System.Windows.Forms.TextBox();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.CBOpais = new System.Windows.Forms.ComboBox();
            this.CBOcategoria = new System.Windows.Forms.ComboBox();
            this.lblDificultad = new System.Windows.Forms.Label();
            this.CBOdificultad = new System.Windows.Forms.ComboBox();
            this.DTPtiempo = new System.Windows.Forms.DateTimePicker();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.TXTdescripcion = new System.Windows.Forms.TextBox();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.TXTinstrucciones = new System.Windows.Forms.TextBox();
            this.pcbImagen = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnImagen = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblIngredientes = new System.Windows.Forms.Label();
            this.clbIngredientes = new System.Windows.Forms.CheckedListBox();
            this.btnAgregarIngrediente = new System.Windows.Forms.Button();
            this.btnAgregarPais = new System.Windows.Forms.Button();
            this.btbAgregarCategorias = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(286, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(222, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Agregar receta nueva";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(12, 53);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(75, 21);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre: ";
            // 
            // TXTnombre
            // 
            this.TXTnombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTnombre.Location = new System.Drawing.Point(12, 77);
            this.TXTnombre.Name = "TXTnombre";
            this.TXTnombre.Size = new System.Drawing.Size(335, 29);
            this.TXTnombre.TabIndex = 2;
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPais.Location = new System.Drawing.Point(12, 108);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(40, 21);
            this.lblPais.TabIndex = 3;
            this.lblPais.Text = "Pais:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(12, 162);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(80, 21);
            this.lblCategoria.TabIndex = 4;
            this.lblCategoria.Text = "Categoria:";
            // 
            // CBOpais
            // 
            this.CBOpais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBOpais.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBOpais.FormattingEnabled = true;
            this.CBOpais.Location = new System.Drawing.Point(12, 131);
            this.CBOpais.Name = "CBOpais";
            this.CBOpais.Size = new System.Drawing.Size(335, 29);
            this.CBOpais.TabIndex = 5;
            // 
            // CBOcategoria
            // 
            this.CBOcategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBOcategoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBOcategoria.FormattingEnabled = true;
            this.CBOcategoria.Location = new System.Drawing.Point(12, 187);
            this.CBOcategoria.Name = "CBOcategoria";
            this.CBOcategoria.Size = new System.Drawing.Size(335, 29);
            this.CBOcategoria.TabIndex = 6;
            // 
            // lblDificultad
            // 
            this.lblDificultad.AutoSize = true;
            this.lblDificultad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDificultad.Location = new System.Drawing.Point(12, 216);
            this.lblDificultad.Name = "lblDificultad";
            this.lblDificultad.Size = new System.Drawing.Size(76, 21);
            this.lblDificultad.TabIndex = 7;
            this.lblDificultad.Text = "Dificultad";
            // 
            // CBOdificultad
            // 
            this.CBOdificultad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBOdificultad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBOdificultad.FormattingEnabled = true;
            this.CBOdificultad.Location = new System.Drawing.Point(12, 240);
            this.CBOdificultad.Name = "CBOdificultad";
            this.CBOdificultad.Size = new System.Drawing.Size(335, 29);
            this.CBOdificultad.TabIndex = 8;
            // 
            // DTPtiempo
            // 
            this.DTPtiempo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPtiempo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPtiempo.Location = new System.Drawing.Point(12, 294);
            this.DTPtiempo.Name = "DTPtiempo";
            this.DTPtiempo.Size = new System.Drawing.Size(210, 29);
            this.DTPtiempo.TabIndex = 9;
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempo.Location = new System.Drawing.Point(12, 269);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(173, 21);
            this.lblTiempo.TabIndex = 10;
            this.lblTiempo.Text = "Tiempo de preparacion:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(372, 53);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(94, 21);
            this.lblDescripcion.TabIndex = 11;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // TXTdescripcion
            // 
            this.TXTdescripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTdescripcion.Location = new System.Drawing.Point(366, 78);
            this.TXTdescripcion.MaxLength = 450;
            this.TXTdescripcion.Multiline = true;
            this.TXTdescripcion.Name = "TXTdescripcion";
            this.TXTdescripcion.Size = new System.Drawing.Size(443, 106);
            this.TXTdescripcion.TabIndex = 12;
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruccion.Location = new System.Drawing.Point(372, 186);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(104, 21);
            this.lblInstruccion.TabIndex = 13;
            this.lblInstruccion.Text = "Instrucciones:";
            // 
            // TXTinstrucciones
            // 
            this.TXTinstrucciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTinstrucciones.Location = new System.Drawing.Point(366, 211);
            this.TXTinstrucciones.Multiline = true;
            this.TXTinstrucciones.Name = "TXTinstrucciones";
            this.TXTinstrucciones.Size = new System.Drawing.Size(443, 140);
            this.TXTinstrucciones.TabIndex = 14;
            // 
            // pcbImagen
            // 
            this.pcbImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pcbImagen.Location = new System.Drawing.Point(15, 335);
            this.pcbImagen.Name = "pcbImagen";
            this.pcbImagen.Size = new System.Drawing.Size(135, 91);
            this.pcbImagen.TabIndex = 15;
            this.pcbImagen.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnImagen
            // 
            this.btnImagen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImagen.Location = new System.Drawing.Point(12, 432);
            this.btnImagen.Name = "btnImagen";
            this.btnImagen.Size = new System.Drawing.Size(135, 31);
            this.btnImagen.TabIndex = 16;
            this.btnImagen.Text = "&Cargar imagen";
            this.btnImagen.UseVisualStyleBackColor = true;
            this.btnImagen.Click += new System.EventHandler(this.btnImagen_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(370, 520);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 33);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.Location = new System.Drawing.Point(711, 520);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(98, 33);
            this.btnCargar.TabIndex = 18;
            this.btnCargar.Text = "&Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblIngredientes
            // 
            this.lblIngredientes.AutoSize = true;
            this.lblIngredientes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngredientes.Location = new System.Drawing.Point(372, 354);
            this.lblIngredientes.Name = "lblIngredientes";
            this.lblIngredientes.Size = new System.Drawing.Size(99, 21);
            this.lblIngredientes.TabIndex = 19;
            this.lblIngredientes.Text = "Ingredientes:";
            // 
            // clbIngredientes
            // 
            this.clbIngredientes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbIngredientes.FormattingEnabled = true;
            this.clbIngredientes.Location = new System.Drawing.Point(370, 380);
            this.clbIngredientes.Name = "clbIngredientes";
            this.clbIngredientes.Size = new System.Drawing.Size(439, 100);
            this.clbIngredientes.TabIndex = 20;
            // 
            // btnAgregarIngrediente
            // 
            this.btnAgregarIngrediente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarIngrediente.Location = new System.Drawing.Point(12, 485);
            this.btnAgregarIngrediente.Name = "btnAgregarIngrediente";
            this.btnAgregarIngrediente.Size = new System.Drawing.Size(149, 33);
            this.btnAgregarIngrediente.TabIndex = 21;
            this.btnAgregarIngrediente.Text = "&Agregar ingrediente";
            this.btnAgregarIngrediente.UseVisualStyleBackColor = true;
            this.btnAgregarIngrediente.Click += new System.EventHandler(this.btnAgregarIngrediente_Click);
            // 
            // btnAgregarPais
            // 
            this.btnAgregarPais.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPais.Location = new System.Drawing.Point(12, 524);
            this.btnAgregarPais.Name = "btnAgregarPais";
            this.btnAgregarPais.Size = new System.Drawing.Size(149, 33);
            this.btnAgregarPais.TabIndex = 22;
            this.btnAgregarPais.Text = "&Agregar pais";
            this.btnAgregarPais.UseVisualStyleBackColor = true;
            this.btnAgregarPais.Click += new System.EventHandler(this.btnPais_Click);
            // 
            // btbAgregarCategorias
            // 
            this.btbAgregarCategorias.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbAgregarCategorias.Location = new System.Drawing.Point(170, 524);
            this.btbAgregarCategorias.Name = "btbAgregarCategorias";
            this.btbAgregarCategorias.Size = new System.Drawing.Size(149, 33);
            this.btbAgregarCategorias.TabIndex = 23;
            this.btbAgregarCategorias.Text = "&Agregar categoria";
            this.btbAgregarCategorias.UseVisualStyleBackColor = true;
            this.btbAgregarCategorias.Click += new System.EventHandler(this.btbAgregarCategorias_Click);
            // 
            // frmAgregarReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 565);
            this.Controls.Add(this.btbAgregarCategorias);
            this.Controls.Add(this.btnAgregarPais);
            this.Controls.Add(this.btnAgregarIngrediente);
            this.Controls.Add(this.clbIngredientes);
            this.Controls.Add(this.lblIngredientes);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImagen);
            this.Controls.Add(this.pcbImagen);
            this.Controls.Add(this.TXTinstrucciones);
            this.Controls.Add(this.lblInstruccion);
            this.Controls.Add(this.TXTdescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.DTPtiempo);
            this.Controls.Add(this.CBOdificultad);
            this.Controls.Add(this.lblDificultad);
            this.Controls.Add(this.CBOcategoria);
            this.Controls.Add(this.CBOpais);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblPais);
            this.Controls.Add(this.TXTnombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmAgregarReceta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAgregarReceta";
            this.Load += new System.EventHandler(this.FrmAgregarReceta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox TXTnombre;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox CBOpais;
        private System.Windows.Forms.ComboBox CBOcategoria;
        private System.Windows.Forms.Label lblDificultad;
        private System.Windows.Forms.ComboBox CBOdificultad;
        private System.Windows.Forms.DateTimePicker DTPtiempo;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox TXTdescripcion;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.TextBox TXTinstrucciones;
        private System.Windows.Forms.PictureBox pcbImagen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnImagen;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnAgregarIngrediente;
        private System.Windows.Forms.CheckedListBox clbIngredientes;
        private System.Windows.Forms.Label lblIngredientes;
        private System.Windows.Forms.Button btnAgregarPais;
        private System.Windows.Forms.Button btbAgregarCategorias;
    }
}