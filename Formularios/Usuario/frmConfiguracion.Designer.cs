namespace MicheBytesRecipes.Forms.User
{
    partial class frmConfiguracion
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
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.btnViewContraNueva = new System.Windows.Forms.Button();
            this.btnViewContra = new System.Windows.Forms.Button();
            this.txtContraActual = new System.Windows.Forms.TextBox();
            this.txtContraNueva = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblContraActual = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblContraNueva = new System.Windows.Forms.Label();
            this.lblCambiarContra = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linkCambiarImagen = new System.Windows.Forms.LinkLabel();
            this.pbxEditarImagen = new System.Windows.Forms.PictureBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombreNuevo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlNavegacion = new System.Windows.Forms.Panel();
            this.pbImagenUser = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.ofdImagenNueva = new System.Windows.Forms.OpenFileDialog();
            this.eprCampos = new System.Windows.Forms.ErrorProvider(this.components);
            this.eprContra = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTipCajas = new System.Windows.Forms.ToolTip(this.components);
            this.pnlContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEditarImagen)).BeginInit();
            this.pnlNavegacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eprCampos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eprContra)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.SystemColors.Control;
            this.pnlContenido.Controls.Add(this.btnViewContraNueva);
            this.pnlContenido.Controls.Add(this.btnViewContra);
            this.pnlContenido.Controls.Add(this.txtContraActual);
            this.pnlContenido.Controls.Add(this.txtContraNueva);
            this.pnlContenido.Controls.Add(this.btnCancelar);
            this.pnlContenido.Controls.Add(this.lblContraActual);
            this.pnlContenido.Controls.Add(this.btnGuardar);
            this.pnlContenido.Controls.Add(this.lblContraNueva);
            this.pnlContenido.Controls.Add(this.lblCambiarContra);
            this.pnlContenido.Controls.Add(this.label5);
            this.pnlContenido.Controls.Add(this.linkCambiarImagen);
            this.pnlContenido.Controls.Add(this.pbxEditarImagen);
            this.pnlContenido.Controls.Add(this.txtEmail);
            this.pnlContenido.Controls.Add(this.lblEmail);
            this.pnlContenido.Controls.Add(this.txtApellido);
            this.pnlContenido.Controls.Add(this.txtTelefono);
            this.pnlContenido.Controls.Add(this.lblApellido);
            this.pnlContenido.Controls.Add(this.lblTelefono);
            this.pnlContenido.Controls.Add(this.txtNombre);
            this.pnlContenido.Controls.Add(this.lblNombreNuevo);
            this.pnlContenido.Controls.Add(this.lblTitulo);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(233, 0);
            this.pnlContenido.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(951, 661);
            this.pnlContenido.TabIndex = 6;
            // 
            // btnViewContraNueva
            // 
            this.btnViewContraNueva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewContraNueva.BackColor = System.Drawing.Color.Orange;
            this.btnViewContraNueva.FlatAppearance.BorderSize = 0;
            this.btnViewContraNueva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewContraNueva.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnViewContraNueva.ForeColor = System.Drawing.Color.White;
            this.btnViewContraNueva.Location = new System.Drawing.Point(715, 498);
            this.btnViewContraNueva.Name = "btnViewContraNueva";
            this.btnViewContraNueva.Size = new System.Drawing.Size(39, 29);
            this.btnViewContraNueva.TabIndex = 24;
            this.btnViewContraNueva.Text = "N\r\n";
            this.btnViewContraNueva.UseVisualStyleBackColor = false;
            this.btnViewContraNueva.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnViewContraNueva_MouseDown);
            this.btnViewContraNueva.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnViewContraNueva_MouseUp);
            // 
            // btnViewContra
            // 
            this.btnViewContra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewContra.BackColor = System.Drawing.Color.Orange;
            this.btnViewContra.FlatAppearance.BorderSize = 0;
            this.btnViewContra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewContra.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnViewContra.ForeColor = System.Drawing.Color.White;
            this.btnViewContra.Location = new System.Drawing.Point(715, 449);
            this.btnViewContra.Name = "btnViewContra";
            this.btnViewContra.Size = new System.Drawing.Size(39, 29);
            this.btnViewContra.TabIndex = 23;
            this.btnViewContra.Text = "N\r\n";
            this.btnViewContra.UseVisualStyleBackColor = false;
            this.btnViewContra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnViewContra_MouseDown);
            this.btnViewContra.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnViewContra_MouseUp);
            // 
            // txtContraActual
            // 
            this.txtContraActual.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraActual.Location = new System.Drawing.Point(222, 449);
            this.txtContraActual.Name = "txtContraActual";
            this.txtContraActual.Size = new System.Drawing.Size(532, 29);
            this.txtContraActual.TabIndex = 7;
            this.txtContraActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContraActual_KeyPress);
            // 
            // txtContraNueva
            // 
            this.txtContraNueva.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraNueva.Location = new System.Drawing.Point(222, 498);
            this.txtContraNueva.Name = "txtContraNueva";
            this.txtContraNueva.Size = new System.Drawing.Size(532, 29);
            this.txtContraNueva.TabIndex = 8;
            this.txtContraNueva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContraNueva_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(81, 584);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(198, 42);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblContraActual
            // 
            this.lblContraActual.AutoSize = true;
            this.lblContraActual.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraActual.ForeColor = System.Drawing.Color.Orange;
            this.lblContraActual.Location = new System.Drawing.Point(71, 452);
            this.lblContraActual.Name = "lblContraActual";
            this.lblContraActual.Size = new System.Drawing.Size(151, 21);
            this.lblContraActual.TabIndex = 18;
            this.lblContraActual.Text = "Contraseña actual:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(625, 584);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(198, 42);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "💾 &Guardar Cambios ";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblContraNueva
            // 
            this.lblContraNueva.AutoSize = true;
            this.lblContraNueva.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraNueva.ForeColor = System.Drawing.Color.Orange;
            this.lblContraNueva.Location = new System.Drawing.Point(71, 501);
            this.lblContraNueva.Name = "lblContraNueva";
            this.lblContraNueva.Size = new System.Drawing.Size(152, 21);
            this.lblContraNueva.TabIndex = 19;
            this.lblContraNueva.Text = "Nueva contraseña:";
            // 
            // lblCambiarContra
            // 
            this.lblCambiarContra.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambiarContra.ForeColor = System.Drawing.Color.Orange;
            this.lblCambiarContra.Location = new System.Drawing.Point(77, 399);
            this.lblCambiarContra.Name = "lblCambiarContra";
            this.lblCambiarContra.Size = new System.Drawing.Size(397, 25);
            this.lblCambiarContra.TabIndex = 16;
            this.lblCambiarContra.Text = "🔒 Cambiar contraseña";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(78, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(745, 31);
            this.label5.TabIndex = 15;
            this.label5.Text = "_________________________________________________________________________________" +
    "________________________________________________________________________________" +
    "__";
            // 
            // linkCambiarImagen
            // 
            this.linkCambiarImagen.AutoSize = true;
            this.linkCambiarImagen.Location = new System.Drawing.Point(162, 152);
            this.linkCambiarImagen.Name = "linkCambiarImagen";
            this.linkCambiarImagen.Size = new System.Drawing.Size(104, 17);
            this.linkCambiarImagen.TabIndex = 6;
            this.linkCambiarImagen.TabStop = true;
            this.linkCambiarImagen.Text = "Cambiar Imagen";
            this.linkCambiarImagen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCambiarImagen_LinkClicked);
            // 
            // pbxEditarImagen
            // 
            this.pbxEditarImagen.Location = new System.Drawing.Point(135, 55);
            this.pbxEditarImagen.Name = "pbxEditarImagen";
            this.pbxEditarImagen.Size = new System.Drawing.Size(154, 85);
            this.pbxEditarImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxEditarImagen.TabIndex = 13;
            this.pbxEditarImagen.TabStop = false;
            this.pbxEditarImagen.Click += new System.EventHandler(this.pbEditarImagen_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(209, 336);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(545, 29);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.Orange;
            this.lblEmail.Location = new System.Drawing.Point(131, 340);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(57, 21);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email:";
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(209, 240);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(545, 29);
            this.txtApellido.TabIndex = 3;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(209, 289);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(545, 29);
            this.txtTelefono.TabIndex = 4;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.ForeColor = System.Drawing.Color.Orange;
            this.lblApellido.Location = new System.Drawing.Point(132, 244);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(79, 21);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.ForeColor = System.Drawing.Color.Orange;
            this.lblTelefono.Location = new System.Drawing.Point(131, 293);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(81, 21);
            this.lblTelefono.TabIndex = 2;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(209, 193);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(545, 29);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // lblNombreNuevo
            // 
            this.lblNombreNuevo.AutoSize = true;
            this.lblNombreNuevo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreNuevo.ForeColor = System.Drawing.Color.Orange;
            this.lblNombreNuevo.Location = new System.Drawing.Point(131, 197);
            this.lblNombreNuevo.Name = "lblNombreNuevo";
            this.lblNombreNuevo.Size = new System.Drawing.Size(77, 21);
            this.lblNombreNuevo.TabIndex = 2;
            this.lblNombreNuevo.Text = "Nombre:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Orange;
            this.lblTitulo.Location = new System.Drawing.Point(305, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(312, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Configuración del usuario";
            // 
            // pnlNavegacion
            // 
            this.pnlNavegacion.BackColor = System.Drawing.Color.Orange;
            this.pnlNavegacion.Controls.Add(this.pbImagenUser);
            this.pnlNavegacion.Controls.Add(this.lblNombre);
            this.pnlNavegacion.Controls.Add(this.btnEditar);
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
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Salmon;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(18, 194);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(198, 42);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.DarkOrange;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Location = new System.Drawing.Point(18, 584);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(4);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(198, 42);
            this.btnInicio.TabIndex = 11;
            this.btnInicio.Text = "🔙 &Inicio ";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // ofdImagenNueva
            // 
            this.ofdImagenNueva.FileName = "openFileDialog1";
            // 
            // eprCampos
            // 
            this.eprCampos.ContainerControl = this;
            // 
            // eprContra
            // 
            this.eprContra.ContainerControl = this;
            // 
            // frmConfiguracion
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
            this.Name = "frmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion";
            this.Load += new System.EventHandler(this.Configuracion_Load);
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEditarImagen)).EndInit();
            this.pnlNavegacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eprCampos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eprContra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Panel pnlNavegacion;
        private System.Windows.Forms.PictureBox pbImagenUser;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblNombreNuevo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.LinkLabel linkCambiarImagen;
        private System.Windows.Forms.PictureBox pbxEditarImagen;
        private System.Windows.Forms.TextBox txtContraActual;
        private System.Windows.Forms.TextBox txtContraNueva;
        private System.Windows.Forms.Label lblContraActual;
        private System.Windows.Forms.Label lblContraNueva;
        private System.Windows.Forms.Label lblCambiarContra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnViewContraNueva;
        private System.Windows.Forms.Button btnViewContra;
        private System.Windows.Forms.OpenFileDialog ofdImagenNueva;
        private System.Windows.Forms.ErrorProvider eprCampos;
        private System.Windows.Forms.ErrorProvider eprContra;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.ToolTip toolTipCajas;
    }
}