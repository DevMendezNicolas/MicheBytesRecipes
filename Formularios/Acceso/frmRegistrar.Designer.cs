namespace MicheBytesRecipes.Forms.Auth
{
    partial class frmRegistrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrar));
            this.pbxFotoPerfil = new System.Windows.Forms.PictureBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.txtRepContra = new System.Windows.Forms.TextBox();
            this.chkTerminos = new System.Windows.Forms.CheckBox();
            this.lblLinkTerminos = new System.Windows.Forms.LinkLabel();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.LblCuenta = new System.Windows.Forms.Label();
            this.LinkIniciar = new System.Windows.Forms.LinkLabel();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblContra = new System.Windows.Forms.Label();
            this.lblRepContra = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lbCambiarImagen = new System.Windows.Forms.LinkLabel();
            this.btnViewAgain = new System.Windows.Forms.Button();
            this.btnViewContra = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblTexto = new System.Windows.Forms.Label();
            this.lblRelleno = new System.Windows.Forms.Label();
            this.lblTituloLeft = new System.Windows.Forms.Label();
            this.ofdFotoPerfil = new System.Windows.Forms.OpenFileDialog();
            this.eprCampos = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTipCajas = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPerfil)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eprCampos)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxFotoPerfil
            // 
            this.pbxFotoPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxFotoPerfil.Image = global::MicheBytesRecipes.Properties.Resources.Create_a_friendly__o1;
            this.pbxFotoPerfil.Location = new System.Drawing.Point(235, 61);
            this.pbxFotoPerfil.Name = "pbxFotoPerfil";
            this.pbxFotoPerfil.Size = new System.Drawing.Size(123, 88);
            this.pbxFotoPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxFotoPerfil.TabIndex = 1;
            this.pbxFotoPerfil.TabStop = false;
            this.pbxFotoPerfil.Click += new System.EventHandler(this.pbxFotoPerfil_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApellido.BackColor = System.Drawing.Color.Beige;
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApellido.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtApellido.Location = new System.Drawing.Point(81, 257);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(431, 22);
            this.txtApellido.TabIndex = 2;
            this.txtApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.BackColor = System.Drawing.Color.Beige;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtEmail.Location = new System.Drawing.Point(81, 380);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(431, 22);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // txtContra
            // 
            this.txtContra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContra.BackColor = System.Drawing.Color.Beige;
            this.txtContra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContra.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtContra.Location = new System.Drawing.Point(81, 441);
            this.txtContra.Name = "txtContra";
            this.txtContra.Size = new System.Drawing.Size(431, 22);
            this.txtContra.TabIndex = 5;
            this.txtContra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContra_KeyPress);
            // 
            // txtRepContra
            // 
            this.txtRepContra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRepContra.BackColor = System.Drawing.Color.Beige;
            this.txtRepContra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepContra.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtRepContra.Location = new System.Drawing.Point(81, 501);
            this.txtRepContra.Name = "txtRepContra";
            this.txtRepContra.Size = new System.Drawing.Size(431, 22);
            this.txtRepContra.TabIndex = 6;
            this.txtRepContra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRepContra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRepContra_KeyPress);
            // 
            // chkTerminos
            // 
            this.chkTerminos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTerminos.AutoSize = true;
            this.chkTerminos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTerminos.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTerminos.ForeColor = System.Drawing.Color.White;
            this.chkTerminos.Location = new System.Drawing.Point(85, 538);
            this.chkTerminos.Name = "chkTerminos";
            this.chkTerminos.Size = new System.Drawing.Size(193, 27);
            this.chkTerminos.TabIndex = 7;
            this.chkTerminos.Text = "He leído y acepto los";
            this.chkTerminos.UseVisualStyleBackColor = true;
            // 
            // lblLinkTerminos
            // 
            this.lblLinkTerminos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLinkTerminos.AutoSize = true;
            this.lblLinkTerminos.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinkTerminos.Location = new System.Drawing.Point(285, 540);
            this.lblLinkTerminos.Name = "lblLinkTerminos";
            this.lblLinkTerminos.Size = new System.Drawing.Size(190, 23);
            this.lblLinkTerminos.TabIndex = 8;
            this.lblLinkTerminos.TabStop = true;
            this.lblLinkTerminos.Text = "términos  y condiciones";
            this.lblLinkTerminos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkTerminos_LinkClicked);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrar.BackColor = System.Drawing.Color.OrangeRed;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.Color.Wheat;
            this.btnRegistrar.Location = new System.Drawing.Point(144, 583);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(290, 37);
            this.btnRegistrar.TabIndex = 9;
            this.btnRegistrar.Text = "&Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // LblCuenta
            // 
            this.LblCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCuenta.AutoSize = true;
            this.LblCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblCuenta.ForeColor = System.Drawing.Color.Wheat;
            this.LblCuenta.Location = new System.Drawing.Point(151, 629);
            this.LblCuenta.Name = "LblCuenta";
            this.LblCuenta.Size = new System.Drawing.Size(161, 21);
            this.LblCuenta.TabIndex = 10;
            this.LblCuenta.Text = "¿Ya tenes una cuenta?";
            // 
            // LinkIniciar
            // 
            this.LinkIniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkIniciar.AutoSize = true;
            this.LinkIniciar.Location = new System.Drawing.Point(332, 629);
            this.LinkIniciar.Name = "LinkIniciar";
            this.LinkIniciar.Size = new System.Drawing.Size(102, 21);
            this.LinkIniciar.TabIndex = 10;
            this.LinkIniciar.TabStop = true;
            this.LinkIniciar.Text = "Iniciar Sesion";
            this.LinkIniciar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkIniciar_LinkClicked);
            // 
            // lblApellido
            // 
            this.lblApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.ForeColor = System.Drawing.Color.White;
            this.lblApellido.Location = new System.Drawing.Point(102, 228);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(75, 21);
            this.lblApellido.TabIndex = 13;
            this.lblApellido.Text = "Apellido";
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(102, 350);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(53, 21);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "Email";
            // 
            // lblContra
            // 
            this.lblContra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContra.AutoSize = true;
            this.lblContra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContra.ForeColor = System.Drawing.Color.White;
            this.lblContra.Location = new System.Drawing.Point(102, 411);
            this.lblContra.Name = "lblContra";
            this.lblContra.Size = new System.Drawing.Size(96, 21);
            this.lblContra.TabIndex = 15;
            this.lblContra.Text = "Contraseña";
            // 
            // lblRepContra
            // 
            this.lblRepContra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRepContra.AutoSize = true;
            this.lblRepContra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepContra.ForeColor = System.Drawing.Color.White;
            this.lblRepContra.Location = new System.Drawing.Point(102, 471);
            this.lblRepContra.Name = "lblRepContra";
            this.lblRepContra.Size = new System.Drawing.Size(153, 21);
            this.lblRepContra.TabIndex = 16;
            this.lblRepContra.Text = "Repetir contraseña";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitulo.Location = new System.Drawing.Point(186, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(202, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Crea tu cuenta";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefono.BackColor = System.Drawing.Color.Beige;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefono.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtTelefono.Location = new System.Drawing.Point(81, 318);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(431, 22);
            this.txtTelefono.TabIndex = 3;
            this.txtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // lblTelefono
            // 
            this.lblTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.ForeColor = System.Drawing.Color.White;
            this.lblTelefono.Location = new System.Drawing.Point(102, 288);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(77, 21);
            this.lblTelefono.TabIndex = 18;
            this.lblTelefono.Text = "Telefono";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Orange;
            this.pnlRight.Controls.Add(this.lbCambiarImagen);
            this.pnlRight.Controls.Add(this.btnViewAgain);
            this.pnlRight.Controls.Add(this.btnViewContra);
            this.pnlRight.Controls.Add(this.lblTelefono);
            this.pnlRight.Controls.Add(this.txtTelefono);
            this.pnlRight.Controls.Add(this.lblTitulo);
            this.pnlRight.Controls.Add(this.lblRepContra);
            this.pnlRight.Controls.Add(this.lblContra);
            this.pnlRight.Controls.Add(this.lblEmail);
            this.pnlRight.Controls.Add(this.lblApellido);
            this.pnlRight.Controls.Add(this.lblNombre);
            this.pnlRight.Controls.Add(this.LinkIniciar);
            this.pnlRight.Controls.Add(this.LblCuenta);
            this.pnlRight.Controls.Add(this.btnRegistrar);
            this.pnlRight.Controls.Add(this.lblLinkTerminos);
            this.pnlRight.Controls.Add(this.chkTerminos);
            this.pnlRight.Controls.Add(this.txtRepContra);
            this.pnlRight.Controls.Add(this.txtContra);
            this.pnlRight.Controls.Add(this.txtEmail);
            this.pnlRight.Controls.Add(this.txtApellido);
            this.pnlRight.Controls.Add(this.txtNombre);
            this.pnlRight.Controls.Add(this.pbxFotoPerfil);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(584, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(600, 661);
            this.pnlRight.TabIndex = 0;
            // 
            // lbCambiarImagen
            // 
            this.lbCambiarImagen.AutoSize = true;
            this.lbCambiarImagen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCambiarImagen.Location = new System.Drawing.Point(233, 152);
            this.lbCambiarImagen.Name = "lbCambiarImagen";
            this.lbCambiarImagen.Size = new System.Drawing.Size(136, 21);
            this.lbCambiarImagen.TabIndex = 23;
            this.lbCambiarImagen.TabStop = true;
            this.lbCambiarImagen.Text = "Cambiar Imagen";
            this.lbCambiarImagen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbCambiarImagen_LinkClicked);
            // 
            // btnViewAgain
            // 
            this.btnViewAgain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewAgain.BackColor = System.Drawing.Color.DarkOrange;
            this.btnViewAgain.FlatAppearance.BorderSize = 0;
            this.btnViewAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAgain.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnViewAgain.ForeColor = System.Drawing.Color.White;
            this.btnViewAgain.Location = new System.Drawing.Point(478, 501);
            this.btnViewAgain.Name = "btnViewAgain";
            this.btnViewAgain.Size = new System.Drawing.Size(34, 22);
            this.btnViewAgain.TabIndex = 22;
            this.btnViewAgain.Text = "N\r\n";
            this.btnViewAgain.UseVisualStyleBackColor = false;
            this.btnViewAgain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnViewAgain_MouseDown);
            this.btnViewAgain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnViewAgain_MouseUp);
            // 
            // btnViewContra
            // 
            this.btnViewContra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewContra.BackColor = System.Drawing.Color.DarkOrange;
            this.btnViewContra.FlatAppearance.BorderSize = 0;
            this.btnViewContra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewContra.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnViewContra.ForeColor = System.Drawing.Color.White;
            this.btnViewContra.Location = new System.Drawing.Point(478, 441);
            this.btnViewContra.Name = "btnViewContra";
            this.btnViewContra.Size = new System.Drawing.Size(34, 22);
            this.btnViewContra.TabIndex = 21;
            this.btnViewContra.Text = "N\r\n";
            this.btnViewContra.UseVisualStyleBackColor = false;
            this.btnViewContra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnViewContra_MouseDown);
            this.btnViewContra.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnViewContra_MouseUp);
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(102, 170);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(73, 21);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.BackColor = System.Drawing.Color.Beige;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtNombre.Location = new System.Drawing.Point(81, 198);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(431, 22);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.Orange;
            this.pnlLeft.Controls.Add(this.lblTexto);
            this.pnlLeft.Controls.Add(this.lblRelleno);
            this.pnlLeft.Controls.Add(this.lblTituloLeft);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(584, 661);
            this.pnlLeft.TabIndex = 1;
            // 
            // lblTexto
            // 
            this.lblTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTexto.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexto.ForeColor = System.Drawing.Color.Beige;
            this.lblTexto.Location = new System.Drawing.Point(37, 276);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(547, 314);
            this.lblTexto.TabIndex = 24;
            this.lblTexto.Text = resources.GetString("lblTexto.Text");
            this.lblTexto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRelleno
            // 
            this.lblRelleno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRelleno.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelleno.ForeColor = System.Drawing.Color.Beige;
            this.lblRelleno.Location = new System.Drawing.Point(0, 170);
            this.lblRelleno.Name = "lblRelleno";
            this.lblRelleno.Size = new System.Drawing.Size(584, 97);
            this.lblRelleno.TabIndex = 23;
            this.lblRelleno.Text = "Unite a nuestra comunidad y llevá tu experiencia en la cocina al siguiente nivel." +
    "";
            this.lblRelleno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloLeft
            // 
            this.lblTituloLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloLeft.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTituloLeft.Location = new System.Drawing.Point(0, 0);
            this.lblTituloLeft.Name = "lblTituloLeft";
            this.lblTituloLeft.Size = new System.Drawing.Size(584, 139);
            this.lblTituloLeft.TabIndex = 22;
            this.lblTituloLeft.Text = "🌟 Descubrí la magia de cocinar con MicheBytes Recipes 🌟";
            this.lblTituloLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ofdFotoPerfil
            // 
            this.ofdFotoPerfil.FileName = "openFileDialog1";
            // 
            // eprCampos
            // 
            this.eprCampos.ContainerControl = this;
            // 
            // toolTipCajas
            // 
            this.toolTipCajas.IsBalloon = true;
            // 
            // frmRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmRegistrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmRegister_FormClosed);
            this.Load += new System.EventHandler(this.FrmRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPerfil)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eprCampos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbxFotoPerfil;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.TextBox txtRepContra;
        private System.Windows.Forms.CheckBox chkTerminos;
        private System.Windows.Forms.LinkLabel lblLinkTerminos;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label LblCuenta;
        private System.Windows.Forms.LinkLabel LinkIniciar;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblContra;
        private System.Windows.Forms.Label lblRepContra;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblTituloLeft;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Label lblRelleno;
        private System.Windows.Forms.OpenFileDialog ofdFotoPerfil;
        private System.Windows.Forms.ErrorProvider eprCampos;
        private System.Windows.Forms.Button btnViewContra;
        private System.Windows.Forms.Button btnViewAgain;
        private System.Windows.Forms.LinkLabel lbCambiarImagen;
        private System.Windows.Forms.ToolTip toolTipCajas;
    }
}