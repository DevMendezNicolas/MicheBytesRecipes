namespace MicheBytesRecipes
{
    partial class frmMenuAdmin
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblMetricas = new System.Windows.Forms.Label();
            this.lblReceta = new System.Windows.Forms.Label();
            this.btnMetricas = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnAct = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtAgregar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.lblMetricas);
            this.panel1.Controls.Add(this.lblReceta);
            this.panel1.Controls.Add(this.btnMetricas);
            this.panel1.Controls.Add(this.btnUsuarios);
            this.panel1.Controls.Add(this.btnAct);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnModificar);
            this.panel1.Controls.Add(this.txtAgregar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 661);
            this.panel1.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(13, 24);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(198, 74);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "Nombre Administrador";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMetricas
            // 
            this.lblMetricas.AutoSize = true;
            this.lblMetricas.Location = new System.Drawing.Point(46, 395);
            this.lblMetricas.Name = "lblMetricas";
            this.lblMetricas.Size = new System.Drawing.Size(123, 17);
            this.lblMetricas.TabIndex = 10;
            this.lblMetricas.Text = "Usuarios y Metricas";
            // 
            // lblReceta
            // 
            this.lblReceta.AutoSize = true;
            this.lblReceta.Location = new System.Drawing.Point(81, 126);
            this.lblReceta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReceta.Name = "lblReceta";
            this.lblReceta.Size = new System.Drawing.Size(53, 17);
            this.lblReceta.TabIndex = 9;
            this.lblReceta.Text = "Recetas";
            // 
            // btnMetricas
            // 
            this.btnMetricas.Location = new System.Drawing.Point(13, 475);
            this.btnMetricas.Margin = new System.Windows.Forms.Padding(4);
            this.btnMetricas.Name = "btnMetricas";
            this.btnMetricas.Size = new System.Drawing.Size(198, 42);
            this.btnMetricas.TabIndex = 7;
            this.btnMetricas.Text = "&Metricas";
            this.btnMetricas.UseVisualStyleBackColor = true;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(13, 425);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(198, 42);
            this.btnUsuarios.TabIndex = 6;
            this.btnUsuarios.Text = "&Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnAct
            // 
            this.btnAct.Location = new System.Drawing.Point(13, 310);
            this.btnAct.Margin = new System.Windows.Forms.Padding(4);
            this.btnAct.Name = "btnAct";
            this.btnAct.Size = new System.Drawing.Size(198, 42);
            this.btnAct.TabIndex = 5;
            this.btnAct.Text = "Activas - Inactivas";
            this.btnAct.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(13, 260);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(198, 42);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(13, 210);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(198, 42);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "&Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // txtAgregar
            // 
            this.txtAgregar.Location = new System.Drawing.Point(13, 160);
            this.txtAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.txtAgregar.Name = "txtAgregar";
            this.txtAgregar.Size = new System.Drawing.Size(198, 42);
            this.txtAgregar.TabIndex = 2;
            this.txtAgregar.Text = "&Agregar";
            this.txtAgregar.UseVisualStyleBackColor = true;
            this.txtAgregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(233, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(951, 661);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 569);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmMenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMenuAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnMetricas;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnAct;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button txtAgregar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblReceta;
        private System.Windows.Forms.Label lblMetricas;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

