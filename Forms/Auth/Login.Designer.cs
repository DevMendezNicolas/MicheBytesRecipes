namespace MicheBytesRecipes
{
    partial class frmLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.PanelMid = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.LbLinkContra = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.lbLinkRegistrar = new System.Windows.Forms.LinkLabel();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnTema = new System.Windows.Forms.Button();
            this.lblLinkResetContra = new System.Windows.Forms.LinkLabel();
            this.PanelMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(76, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estrellas Michebyte";
            // 
            // PanelMid
            // 
            this.PanelMid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.PanelMid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PanelMid.Controls.Add(this.lblLinkResetContra);
            this.PanelMid.Controls.Add(this.btnView);
            this.PanelMid.Controls.Add(this.LbLinkContra);
            this.PanelMid.Controls.Add(this.label6);
            this.PanelMid.Controls.Add(this.lbLinkRegistrar);
            this.PanelMid.Controls.Add(this.btnIngresar);
            this.PanelMid.Controls.Add(this.txtContra);
            this.PanelMid.Controls.Add(this.label4);
            this.PanelMid.Controls.Add(this.txtEmail);
            this.PanelMid.Controls.Add(this.lblEmail);
            this.PanelMid.Controls.Add(this.label2);
            this.PanelMid.Location = new System.Drawing.Point(46, 102);
            this.PanelMid.Name = "PanelMid";
            this.PanelMid.Size = new System.Drawing.Size(376, 382);
            this.PanelMid.TabIndex = 1;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Webdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(304, 190);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(39, 26);
            this.btnView.TabIndex = 10;
            this.btnView.Text = "N";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnView_MouseDown);
            this.btnView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnView_MouseUp);
            // 
            // LbLinkContra
            // 
            this.LbLinkContra.AutoSize = true;
            this.LbLinkContra.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LbLinkContra.Location = new System.Drawing.Point(38, 240);
            this.LbLinkContra.Name = "LbLinkContra";
            this.LbLinkContra.Size = new System.Drawing.Size(0, 21);
            this.LbLinkContra.TabIndex = 9;
            this.LbLinkContra.TabStop = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(35, 336);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 21);
            this.label6.TabIndex = 8;
            this.label6.Text = "¿Nuevo en Michebyte?";
            // 
            // lbLinkRegistrar
            // 
            this.lbLinkRegistrar.AutoSize = true;
            this.lbLinkRegistrar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLinkRegistrar.Location = new System.Drawing.Point(211, 336);
            this.lbLinkRegistrar.Name = "lbLinkRegistrar";
            this.lbLinkRegistrar.Size = new System.Drawing.Size(132, 21);
            this.lbLinkRegistrar.TabIndex = 4;
            this.lbLinkRegistrar.TabStop = true;
            this.lbLinkRegistrar.Text = "Crear una cuenta";
            this.lbLinkRegistrar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LbLinkRegistrar_LinkClicked);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(36, 278);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(307, 40);
            this.btnIngresar.TabIndex = 3;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.BtnLog_Click);
            // 
            // txtContra
            // 
            this.txtContra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContra.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContra.ForeColor = System.Drawing.Color.Black;
            this.txtContra.Location = new System.Drawing.Point(36, 190);
            this.txtContra.Name = "txtContra";
            this.txtContra.PasswordChar = '●';
            this.txtContra.Size = new System.Drawing.Size(307, 26);
            this.txtContra.TabIndex = 2;
            this.txtContra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContra.UseSystemPasswordChar = true;
            this.txtContra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContra_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.label4.Location = new System.Drawing.Point(31, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contraseña";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(36, 100);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(306, 26);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.lblEmail.Location = new System.Drawing.Point(31, 59);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(59, 25);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(93, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "Iniciar Sesión";
            // 
            // BtnTema
            // 
            this.BtnTema.FlatAppearance.BorderSize = 0;
            this.BtnTema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTema.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTema.ForeColor = System.Drawing.Color.Yellow;
            this.BtnTema.Location = new System.Drawing.Point(394, 490);
            this.BtnTema.Name = "BtnTema";
            this.BtnTema.Size = new System.Drawing.Size(75, 34);
            this.BtnTema.TabIndex = 5;
            this.BtnTema.Text = "☀️";
            this.BtnTema.UseVisualStyleBackColor = true;
            this.BtnTema.Click += new System.EventHandler(this.BtnTema_Click);
            // 
            // lblLinkResetContra
            // 
            this.lblLinkResetContra.AutoSize = true;
            this.lblLinkResetContra.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinkResetContra.Location = new System.Drawing.Point(34, 229);
            this.lblLinkResetContra.Name = "lblLinkResetContra";
            this.lblLinkResetContra.Size = new System.Drawing.Size(195, 21);
            this.lblLinkResetContra.TabIndex = 11;
            this.lblLinkResetContra.TabStop = true;
            this.lblLinkResetContra.Text = "¿Olvidaste tu contraseña?";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(481, 536);
            this.Controls.Add(this.BtnTema);
            this.Controls.Add(this.PanelMid);
            this.Controls.Add(this.label1);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogin_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.PanelMid.ResumeLayout(false);
            this.PanelMid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanelMid;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnTema;
        private System.Windows.Forms.LinkLabel lbLinkRegistrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel LbLinkContra;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.LinkLabel lblLinkResetContra;
    }
}