namespace MicheBytesRecipes.Forms.User
{
    partial class MenuUser
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
            this.btnReinicio = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvReceta = new System.Windows.Forms.DataGridView();
            this.Receta_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dificultad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboDificultad = new System.Windows.Forms.ComboBox();
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarReceta = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.pnlNavegacion = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnHistorialRecetas = new System.Windows.Forms.Button();
            this.btnHistorialFav = new System.Windows.Forms.Button();
            this.pbImagenUser = new System.Windows.Forms.PictureBox();
            this.pnlContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceta)).BeginInit();
            this.pnlNavegacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContenido
            // 
            this.pnlContenido.Controls.Add(this.btnReinicio);
            this.pnlContenido.Controls.Add(this.btnBuscar);
            this.pnlContenido.Controls.Add(this.dgvReceta);
            this.pnlContenido.Controls.Add(this.cboDificultad);
            this.pnlContenido.Controls.Add(this.cboPais);
            this.pnlContenido.Controls.Add(this.cboCategoria);
            this.pnlContenido.Controls.Add(this.label3);
            this.pnlContenido.Controls.Add(this.label2);
            this.pnlContenido.Controls.Add(this.label1);
            this.pnlContenido.Controls.Add(this.txtBuscarReceta);
            this.pnlContenido.Controls.Add(this.lblBuscar);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(233, 0);
            this.pnlContenido.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(951, 661);
            this.pnlContenido.TabIndex = 4;
            // 
            // btnReinicio
            // 
            this.btnReinicio.Location = new System.Drawing.Point(772, 142);
            this.btnReinicio.Name = "btnReinicio";
            this.btnReinicio.Size = new System.Drawing.Size(131, 29);
            this.btnReinicio.TabIndex = 5;
            this.btnReinicio.Text = "🔄 Reiniciar filtros";
            this.btnReinicio.UseVisualStyleBackColor = true;
            this.btnReinicio.Click += new System.EventHandler(this.btnReinicio_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(751, 69);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(152, 29);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "🔍 Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvReceta
            // 
            this.dgvReceta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Receta_id,
            this.Nombre,
            this.Categoria,
            this.Pais,
            this.Dificultad,
            this.Tiempo});
            this.dgvReceta.Location = new System.Drawing.Point(45, 210);
            this.dgvReceta.MultiSelect = false;
            this.dgvReceta.Name = "dgvReceta";
            this.dgvReceta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceta.Size = new System.Drawing.Size(858, 382);
            this.dgvReceta.TabIndex = 4;
            this.dgvReceta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceta_CellDoubleClick);
            // 
            // Receta_id
            // 
            this.Receta_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Receta_id.HeaderText = "Receta id";
            this.Receta_id.Name = "Receta_id";
            this.Receta_id.ReadOnly = true;
            this.Receta_id.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Categoria
            // 
            this.Categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // Pais
            // 
            this.Pais.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pais.HeaderText = "Pais";
            this.Pais.Name = "Pais";
            this.Pais.ReadOnly = true;
            // 
            // Dificultad
            // 
            this.Dificultad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Dificultad.HeaderText = "Dificultad";
            this.Dificultad.Name = "Dificultad";
            this.Dificultad.ReadOnly = true;
            // 
            // Tiempo
            // 
            this.Tiempo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tiempo.HeaderText = "Tiempo";
            this.Tiempo.Name = "Tiempo";
            this.Tiempo.ReadOnly = true;
            // 
            // cboDificultad
            // 
            this.cboDificultad.FormattingEnabled = true;
            this.cboDificultad.Location = new System.Drawing.Point(566, 146);
            this.cboDificultad.Name = "cboDificultad";
            this.cboDificultad.Size = new System.Drawing.Size(179, 25);
            this.cboDificultad.TabIndex = 3;
            // 
            // cboPais
            // 
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(332, 146);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(179, 25);
            this.cboPais.TabIndex = 3;
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(75, 146);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(179, 25);
            this.cboCategoria.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(562, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dificultad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(328, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pais";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Categoria";
            // 
            // txtBuscarReceta
            // 
            this.txtBuscarReceta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarReceta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarReceta.Location = new System.Drawing.Point(219, 69);
            this.txtBuscarReceta.Name = "txtBuscarReceta";
            this.txtBuscarReceta.Size = new System.Drawing.Size(488, 29);
            this.txtBuscarReceta.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(342, 24);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(232, 25);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar receta por nombre";
            // 
            // pnlNavegacion
            // 
            this.pnlNavegacion.Controls.Add(this.pbImagenUser);
            this.pnlNavegacion.Controls.Add(this.lblNombre);
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
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(13, 116);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(198, 74);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "Nombre Usuario";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(13, 559);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(198, 42);
            this.btnConfig.TabIndex = 7;
            this.btnConfig.Text = "&Configuracion";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnHistorialRecetas
            // 
            this.btnHistorialRecetas.Location = new System.Drawing.Point(13, 509);
            this.btnHistorialRecetas.Margin = new System.Windows.Forms.Padding(4);
            this.btnHistorialRecetas.Name = "btnHistorialRecetas";
            this.btnHistorialRecetas.Size = new System.Drawing.Size(198, 42);
            this.btnHistorialRecetas.TabIndex = 6;
            this.btnHistorialRecetas.Text = "&Mi Historial";
            this.btnHistorialRecetas.UseVisualStyleBackColor = true;
            this.btnHistorialRecetas.Click += new System.EventHandler(this.btnHistorialRecetas_Click);
            // 
            // btnHistorialFav
            // 
            this.btnHistorialFav.Location = new System.Drawing.Point(13, 459);
            this.btnHistorialFav.Margin = new System.Windows.Forms.Padding(4);
            this.btnHistorialFav.Name = "btnHistorialFav";
            this.btnHistorialFav.Size = new System.Drawing.Size(198, 42);
            this.btnHistorialFav.TabIndex = 3;
            this.btnHistorialFav.Text = "&Ver Favoritas";
            this.btnHistorialFav.UseVisualStyleBackColor = true;
            this.btnHistorialFav.Click += new System.EventHandler(this.btnHistorialFav_Click);
            // 
            // pbImagenUser
            // 
            this.pbImagenUser.Location = new System.Drawing.Point(34, 24);
            this.pbImagenUser.Name = "pbImagenUser";
            this.pbImagenUser.Size = new System.Drawing.Size(154, 85);
            this.pbImagenUser.TabIndex = 12;
            this.pbImagenUser.TabStop = false;
            // 
            // MenuUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlNavegacion);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MenuUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuUser_FormClosed);
            this.Load += new System.EventHandler(this.MenuUser_Load);
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceta)).EndInit();
            this.pnlNavegacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Button btnReinicio;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvReceta;
        private System.Windows.Forms.ComboBox cboDificultad;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscarReceta;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Panel pnlNavegacion;
        private System.Windows.Forms.PictureBox pbImagenUser;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnHistorialRecetas;
        private System.Windows.Forms.Button btnHistorialFav;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receta_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pais;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dificultad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiempo;
    }
}