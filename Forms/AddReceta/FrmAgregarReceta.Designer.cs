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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TXTnombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CBOpais = new System.Windows.Forms.ComboBox();
            this.CBOcategoria = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CBOdificultad = new System.Windows.Forms.ComboBox();
            this.DTPtiempo = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TXTdescripcion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TXTinstrucciones = new System.Windows.Forms.TextBox();
            this.PCBimagen = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CMDcargarimagen = new System.Windows.Forms.Button();
            this.CMDcancelar = new System.Windows.Forms.Button();
            this.CMDcargar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.clbIngredientes = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PCBimagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(249, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar recetas nuevas";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre: ";
            // 
            // TXTnombre
            // 
            this.TXTnombre.Location = new System.Drawing.Point(12, 78);
            this.TXTnombre.Name = "TXTnombre";
            this.TXTnombre.Size = new System.Drawing.Size(335, 20);
            this.TXTnombre.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Pais:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Categoria:";
            // 
            // CBOpais
            // 
            this.CBOpais.FormattingEnabled = true;
            this.CBOpais.Location = new System.Drawing.Point(12, 131);
            this.CBOpais.Name = "CBOpais";
            this.CBOpais.Size = new System.Drawing.Size(335, 21);
            this.CBOpais.TabIndex = 5;
            // 
            // CBOcategoria
            // 
            this.CBOcategoria.FormattingEnabled = true;
            this.CBOcategoria.Location = new System.Drawing.Point(12, 187);
            this.CBOcategoria.Name = "CBOcategoria";
            this.CBOcategoria.Size = new System.Drawing.Size(335, 21);
            this.CBOcategoria.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Dificultad";
            // 
            // CBOdificultad
            // 
            this.CBOdificultad.FormattingEnabled = true;
            this.CBOdificultad.Location = new System.Drawing.Point(12, 241);
            this.CBOdificultad.Name = "CBOdificultad";
            this.CBOdificultad.Size = new System.Drawing.Size(335, 21);
            this.CBOdificultad.TabIndex = 8;
            // 
            // DTPtiempo
            // 
            this.DTPtiempo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPtiempo.Location = new System.Drawing.Point(12, 294);
            this.DTPtiempo.Name = "DTPtiempo";
            this.DTPtiempo.Size = new System.Drawing.Size(210, 20);
            this.DTPtiempo.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tiempo de preparacion:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(372, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Descripcion:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // TXTdescripcion
            // 
            this.TXTdescripcion.Location = new System.Drawing.Point(366, 78);
            this.TXTdescripcion.Multiline = true;
            this.TXTdescripcion.Name = "TXTdescripcion";
            this.TXTdescripcion.Size = new System.Drawing.Size(335, 106);
            this.TXTdescripcion.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(372, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Instrucciones:";
            // 
            // TXTinstrucciones
            // 
            this.TXTinstrucciones.Location = new System.Drawing.Point(366, 211);
            this.TXTinstrucciones.Multiline = true;
            this.TXTinstrucciones.Name = "TXTinstrucciones";
            this.TXTinstrucciones.Size = new System.Drawing.Size(335, 140);
            this.TXTinstrucciones.TabIndex = 14;
            // 
            // PCBimagen
            // 
            this.PCBimagen.Location = new System.Drawing.Point(15, 335);
            this.PCBimagen.Name = "PCBimagen";
            this.PCBimagen.Size = new System.Drawing.Size(135, 91);
            this.PCBimagen.TabIndex = 15;
            this.PCBimagen.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CMDcargarimagen
            // 
            this.CMDcargarimagen.Location = new System.Drawing.Point(15, 432);
            this.CMDcargarimagen.Name = "CMDcargarimagen";
            this.CMDcargarimagen.Size = new System.Drawing.Size(98, 23);
            this.CMDcargarimagen.TabIndex = 16;
            this.CMDcargarimagen.Text = "&Cargar imagen";
            this.CMDcargarimagen.UseVisualStyleBackColor = true;
            this.CMDcargarimagen.Click += new System.EventHandler(this.button1_Click);
            // 
            // CMDcancelar
            // 
            this.CMDcancelar.Location = new System.Drawing.Point(366, 520);
            this.CMDcancelar.Name = "CMDcancelar";
            this.CMDcancelar.Size = new System.Drawing.Size(98, 33);
            this.CMDcancelar.TabIndex = 17;
            this.CMDcancelar.Text = "&Cancelar";
            this.CMDcancelar.UseVisualStyleBackColor = true;
            // 
            // CMDcargar
            // 
            this.CMDcargar.Location = new System.Drawing.Point(603, 520);
            this.CMDcargar.Name = "CMDcargar";
            this.CMDcargar.Size = new System.Drawing.Size(98, 33);
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
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(372, 354);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "Ingredientes:";
            // 
            // clbIngredientes
            // 
            this.clbIngredientes.FormattingEnabled = true;
            this.clbIngredientes.Location = new System.Drawing.Point(370, 380);
            this.clbIngredientes.Name = "clbIngredientes";
            this.clbIngredientes.Size = new System.Drawing.Size(330, 109);
            this.clbIngredientes.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 510);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 33);
            this.button1.TabIndex = 21;
            this.button1.Text = "&Agregar nuevo Ingrediente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FrmAgregarReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 565);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clbIngredientes);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CMDcargar);
            this.Controls.Add(this.CMDcancelar);
            this.Controls.Add(this.CMDcargarimagen);
            this.Controls.Add(this.PCBimagen);
            this.Controls.Add(this.TXTinstrucciones);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TXTdescripcion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DTPtiempo);
            this.Controls.Add(this.CBOdificultad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CBOcategoria);
            this.Controls.Add(this.CBOpais);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TXTnombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmAgregarReceta";
            this.Text = "FrmAgregarReceta";
            this.Load += new System.EventHandler(this.FrmAgregarReceta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PCBimagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXTnombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBOpais;
        private System.Windows.Forms.ComboBox CBOcategoria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBOdificultad;
        private System.Windows.Forms.DateTimePicker DTPtiempo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TXTdescripcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TXTinstrucciones;
        private System.Windows.Forms.PictureBox PCBimagen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button CMDcargarimagen;
        private System.Windows.Forms.Button CMDcancelar;
        private System.Windows.Forms.Button CMDcargar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox clbIngredientes;
        private System.Windows.Forms.Label label9;
    }
}