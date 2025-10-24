namespace MicheBytesRecipes.Forms.Auth
{
    // 1. HERENCIA: CAMBIADA A MaterialForm
    partial class frmRegistrar : MaterialSkin.Controls.MaterialForm
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
            this.txtApellido = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtEmail = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtContra = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtRepContra = new MaterialSkin.Controls.MaterialTextBox2();
            this.chkTerminos = new MaterialSkin.Controls.MaterialCheckbox();
            this.lblLinkTerminos = new System.Windows.Forms.LinkLabel();
            this.btnRegistrar = new MaterialSkin.Controls.MaterialButton();
            this.LblCuenta = new MaterialSkin.Controls.MaterialLabel();
            this.LinkIniciar = new System.Windows.Forms.LinkLabel();
            this.lblTitulo = new MaterialSkin.Controls.MaterialLabel();
            this.txtTelefono = new MaterialSkin.Controls.MaterialTextBox2();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lbCambiarImagen = new System.Windows.Forms.LinkLabel();
            this.txtNombre = new MaterialSkin.Controls.MaterialTextBox2();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblTexto = new MaterialSkin.Controls.MaterialLabel();
            this.lblRelleno = new MaterialSkin.Controls.MaterialLabel();
            this.lblTituloLeft = new MaterialSkin.Controls.MaterialLabel();
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
            this.pbxFotoPerfil.Location = new System.Drawing.Point(236, 30);
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
            this.txtApellido.AnimateReadOnly = false;
            this.txtApellido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtApellido.Depth = 0;
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtApellido.HideSelection = true;
            this.txtApellido.Hint = "Ingresa tu apellido";
            this.txtApellido.LeadingIcon = null;
            this.txtApellido.Location = new System.Drawing.Point(85, 210);
            this.txtApellido.MaxLength = 32767;
            this.txtApellido.MouseState = MaterialSkin.MouseState.OUT;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.PasswordChar = '\0';
            this.txtApellido.PrefixSuffixText = null;
            this.txtApellido.ReadOnly = false;
            this.txtApellido.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtApellido.SelectedText = "";
            this.txtApellido.SelectionLength = 0;
            this.txtApellido.SelectionStart = 0;
            this.txtApellido.ShortcutsEnabled = true;
            this.txtApellido.Size = new System.Drawing.Size(431, 48);
            this.txtApellido.TabIndex = 2;
            this.txtApellido.TabStop = false;
            this.txtApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtApellido.TrailingIcon = null;
            this.txtApellido.UseSystemPasswordChar = false;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.AnimateReadOnly = false;
            this.txtEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEmail.Depth = 0;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtEmail.HideSelection = true;
            this.txtEmail.Hint = "Ingresa tu correo electrónico";
            this.txtEmail.LeadingIcon = null;
            this.txtEmail.Location = new System.Drawing.Point(85, 336);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PrefixSuffixText = null;
            this.txtEmail.ReadOnly = false;
            this.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.ShortcutsEnabled = true;
            this.txtEmail.Size = new System.Drawing.Size(431, 48);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.TabStop = false;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmail.TrailingIcon = null;
            this.txtEmail.UseSystemPasswordChar = false;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // txtContra
            // 
            this.txtContra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContra.AnimateReadOnly = false;
            this.txtContra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtContra.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtContra.Depth = 0;
            this.txtContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtContra.HideSelection = true;
            this.txtContra.Hint = "Ingresa tu contraseña";
            this.txtContra.LeadingIcon = null;
            this.txtContra.Location = new System.Drawing.Point(85, 397);
            this.txtContra.MaxLength = 32767;
            this.txtContra.MouseState = MaterialSkin.MouseState.OUT;
            this.txtContra.Name = "txtContra";
            this.txtContra.PasswordChar = '\0';
            this.txtContra.PrefixSuffixText = null;
            this.txtContra.ReadOnly = false;
            this.txtContra.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtContra.SelectedText = "";
            this.txtContra.SelectionLength = 0;
            this.txtContra.SelectionStart = 0;
            this.txtContra.ShortcutsEnabled = true;
            this.txtContra.Size = new System.Drawing.Size(431, 48);
            this.txtContra.TabIndex = 5;
            this.txtContra.TabStop = false;
            this.txtContra.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtContra.TrailingIcon = null;
            this.txtContra.UseSystemPasswordChar = false;
            this.txtContra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContra_KeyPress);
            // 
            // txtRepContra
            // 
            this.txtRepContra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRepContra.AnimateReadOnly = false;
            this.txtRepContra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtRepContra.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRepContra.Depth = 0;
            this.txtRepContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtRepContra.HideSelection = true;
            this.txtRepContra.Hint = "Repite tu contraseña";
            this.txtRepContra.LeadingIcon = null;
            this.txtRepContra.Location = new System.Drawing.Point(85, 458);
            this.txtRepContra.MaxLength = 32767;
            this.txtRepContra.MouseState = MaterialSkin.MouseState.OUT;
            this.txtRepContra.Name = "txtRepContra";
            this.txtRepContra.PasswordChar = '\0';
            this.txtRepContra.PrefixSuffixText = null;
            this.txtRepContra.ReadOnly = false;
            this.txtRepContra.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRepContra.SelectedText = "";
            this.txtRepContra.SelectionLength = 0;
            this.txtRepContra.SelectionStart = 0;
            this.txtRepContra.ShortcutsEnabled = true;
            this.txtRepContra.Size = new System.Drawing.Size(431, 48);
            this.txtRepContra.TabIndex = 6;
            this.txtRepContra.TabStop = false;
            this.txtRepContra.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRepContra.TrailingIcon = null;
            this.txtRepContra.UseSystemPasswordChar = false;
            this.txtRepContra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRepContra_KeyPress);
            // 
            // chkTerminos
            // 
            this.chkTerminos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTerminos.AutoSize = true;
            this.chkTerminos.Depth = 0;
            this.chkTerminos.Location = new System.Drawing.Point(100, 503);
            this.chkTerminos.Margin = new System.Windows.Forms.Padding(0);
            this.chkTerminos.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkTerminos.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkTerminos.Name = "chkTerminos";
            this.chkTerminos.ReadOnly = false;
            this.chkTerminos.Ripple = true;
            this.chkTerminos.Size = new System.Drawing.Size(181, 37);
            this.chkTerminos.TabIndex = 7;
            this.chkTerminos.Text = "He leído y acepto los";
            this.chkTerminos.UseVisualStyleBackColor = true;
            // 
            // lblLinkTerminos
            // 
            this.lblLinkTerminos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLinkTerminos.AutoSize = true;
            this.lblLinkTerminos.Location = new System.Drawing.Point(284, 510);
            this.lblLinkTerminos.Name = "lblLinkTerminos";
            this.lblLinkTerminos.Size = new System.Drawing.Size(174, 21);
            this.lblLinkTerminos.TabIndex = 8;
            this.lblLinkTerminos.TabStop = true;
            this.lblLinkTerminos.Text = "términos  y condiciones";
            this.lblLinkTerminos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkTerminos_LinkClicked);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRegistrar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRegistrar.Depth = 0;
            this.btnRegistrar.HighEmphasis = true;
            this.btnRegistrar.Icon = null;
            this.btnRegistrar.Location = new System.Drawing.Point(236, 537);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRegistrar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRegistrar.Size = new System.Drawing.Size(99, 36);
            this.btnRegistrar.TabIndex = 9;
            this.btnRegistrar.Text = "REGISTRAR";
            this.btnRegistrar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRegistrar.UseAccentColor = true;
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // LblCuenta
            // 
            this.LblCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCuenta.AutoSize = true;
            this.LblCuenta.Depth = 0;
            this.LblCuenta.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LblCuenta.Location = new System.Drawing.Point(45, 554);
            this.LblCuenta.MouseState = MaterialSkin.MouseState.HOVER;
            this.LblCuenta.Name = "LblCuenta";
            this.LblCuenta.Size = new System.Drawing.Size(161, 19);
            this.LblCuenta.TabIndex = 10;
            this.LblCuenta.Text = "¿Ya tenes una cuenta?";
            // 
            // LinkIniciar
            // 
            this.LinkIniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkIniciar.AutoSize = true;
            this.LinkIniciar.Location = new System.Drawing.Point(372, 552);
            this.LinkIniciar.Name = "LinkIniciar";
            this.LinkIniciar.Size = new System.Drawing.Size(102, 21);
            this.LinkIniciar.TabIndex = 10;
            this.LinkIniciar.TabStop = true;
            this.LinkIniciar.Text = "Iniciar Sesion";
            this.LinkIniciar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkIniciar_LinkClicked);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Depth = 0;
            this.lblTitulo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitulo.Location = new System.Drawing.Point(246, 8);
            this.lblTitulo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(103, 19);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Crea tu cuenta";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefono.AnimateReadOnly = false;
            this.txtTelefono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTelefono.Depth = 0;
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTelefono.HideSelection = true;
            this.txtTelefono.Hint = "Ingresa tu teléfono";
            this.txtTelefono.LeadingIcon = null;
            this.txtTelefono.Location = new System.Drawing.Point(85, 273);
            this.txtTelefono.MaxLength = 32767;
            this.txtTelefono.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.PasswordChar = '\0';
            this.txtTelefono.PrefixSuffixText = null;
            this.txtTelefono.ReadOnly = false;
            this.txtTelefono.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTelefono.SelectedText = "";
            this.txtTelefono.SelectionLength = 0;
            this.txtTelefono.SelectionStart = 0;
            this.txtTelefono.ShortcutsEnabled = true;
            this.txtTelefono.Size = new System.Drawing.Size(431, 48);
            this.txtTelefono.TabIndex = 3;
            this.txtTelefono.TabStop = false;
            this.txtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTelefono.TrailingIcon = null;
            this.txtTelefono.UseSystemPasswordChar = false;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.lbCambiarImagen);
            this.pnlRight.Controls.Add(this.txtTelefono);
            this.pnlRight.Controls.Add(this.lblTitulo);
            this.pnlRight.Controls.Add(this.LinkIniciar);
            this.pnlRight.Controls.Add(this.txtRepContra);
            this.pnlRight.Controls.Add(this.LblCuenta);
            this.pnlRight.Controls.Add(this.lblLinkTerminos);
            this.pnlRight.Controls.Add(this.btnRegistrar);
            this.pnlRight.Controls.Add(this.txtContra);
            this.pnlRight.Controls.Add(this.chkTerminos);
            this.pnlRight.Controls.Add(this.txtEmail);
            this.pnlRight.Controls.Add(this.txtApellido);
            this.pnlRight.Controls.Add(this.txtNombre);
            this.pnlRight.Controls.Add(this.pbxFotoPerfil);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(589, 64);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(600, 594);
            this.pnlRight.TabIndex = 0;
            // 
            // lbCambiarImagen
            // 
            this.lbCambiarImagen.AutoSize = true;
            this.lbCambiarImagen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCambiarImagen.Location = new System.Drawing.Point(234, 122);
            this.lbCambiarImagen.Name = "lbCambiarImagen";
            this.lbCambiarImagen.Size = new System.Drawing.Size(136, 21);
            this.lbCambiarImagen.TabIndex = 23;
            this.lbCambiarImagen.TabStop = true;
            this.lbCambiarImagen.Text = "Cambiar Imagen";
            this.lbCambiarImagen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbCambiarImagen_LinkClicked);
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.AnimateReadOnly = false;
            this.txtNombre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNombre.Depth = 0;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtNombre.HideSelection = true;
            this.txtNombre.Hint = "Ingresa tu nombre";
            this.txtNombre.LeadingIcon = null;
            this.txtNombre.Location = new System.Drawing.Point(85, 148);
            this.txtNombre.MaxLength = 32767;
            this.txtNombre.MouseState = MaterialSkin.MouseState.OUT;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PasswordChar = '\0';
            this.txtNombre.PrefixSuffixText = null;
            this.txtNombre.ReadOnly = false;
            this.txtNombre.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNombre.SelectedText = "";
            this.txtNombre.SelectionLength = 0;
            this.txtNombre.SelectionStart = 0;
            this.txtNombre.ShortcutsEnabled = true;
            this.txtNombre.Size = new System.Drawing.Size(431, 48);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TabStop = false;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNombre.TrailingIcon = null;
            this.txtNombre.UseSystemPasswordChar = false;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblTexto);
            this.pnlLeft.Controls.Add(this.lblRelleno);
            this.pnlLeft.Controls.Add(this.lblTituloLeft);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(3, 64);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(586, 594);
            this.pnlLeft.TabIndex = 1;
            // 
            // lblTexto
            // 
            this.lblTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTexto.Depth = 0;
            this.lblTexto.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTexto.Location = new System.Drawing.Point(0, 280);
            this.lblTexto.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(586, 314);
            this.lblTexto.TabIndex = 24;
            this.lblTexto.Text = resources.GetString("lblTexto.Text");
            this.lblTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRelleno
            // 
            this.lblRelleno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRelleno.Depth = 0;
            this.lblRelleno.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRelleno.Location = new System.Drawing.Point(0, 99);
            this.lblRelleno.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRelleno.Name = "lblRelleno";
            this.lblRelleno.Size = new System.Drawing.Size(586, 97);
            this.lblRelleno.TabIndex = 23;
            this.lblRelleno.Text = "Unite a nuestra comunidad y llevá tu experiencia en la cocina al siguiente nivel." +
    "";
            this.lblRelleno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloLeft
            // 
            this.lblTituloLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloLeft.Depth = 0;
            this.lblTituloLeft.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTituloLeft.Location = new System.Drawing.Point(3, 8);
            this.lblTituloLeft.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTituloLeft.Name = "lblTituloLeft";
            this.lblTituloLeft.Size = new System.Drawing.Size(586, 139);
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
            this.ClientSize = new System.Drawing.Size(1192, 661);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmRegistrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmRegister_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoPerfil)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eprCampos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        // 11. RE-DECLARACIÓN FINAL DE VARIABLES
        private System.Windows.Forms.PictureBox pbxFotoPerfil;
        private MaterialSkin.Controls.MaterialTextBox2 txtApellido;
        private MaterialSkin.Controls.MaterialTextBox2 txtEmail;
        private MaterialSkin.Controls.MaterialTextBox2 txtContra;
        private MaterialSkin.Controls.MaterialTextBox2 txtRepContra;
        private MaterialSkin.Controls.MaterialCheckbox chkTerminos;
        private System.Windows.Forms.LinkLabel lblLinkTerminos;
        private MaterialSkin.Controls.MaterialButton btnRegistrar;
        private MaterialSkin.Controls.MaterialLabel LblCuenta;
        private System.Windows.Forms.LinkLabel LinkIniciar;
        private MaterialSkin.Controls.MaterialLabel lblTitulo;
        private MaterialSkin.Controls.MaterialTextBox2 txtTelefono;
        private System.Windows.Forms.Panel pnlRight;
        private MaterialSkin.Controls.MaterialTextBox2 txtNombre;
        private System.Windows.Forms.Panel pnlLeft;
        private MaterialSkin.Controls.MaterialLabel lblTituloLeft;
        private MaterialSkin.Controls.MaterialLabel lblTexto;
        private MaterialSkin.Controls.MaterialLabel lblRelleno;
        private System.Windows.Forms.OpenFileDialog ofdFotoPerfil;
        private System.Windows.Forms.ErrorProvider eprCampos;
        private System.Windows.Forms.LinkLabel lbCambiarImagen;
        private System.Windows.Forms.ToolTip toolTipCajas;
    }
}