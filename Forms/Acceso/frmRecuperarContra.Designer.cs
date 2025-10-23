namespace MicheBytesRecipes.Forms.Auth
{
    partial class frmRecuperarContra
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
            this.PanelMid = new System.Windows.Forms.Panel();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTexto = new System.Windows.Forms.Label();
            this.LbLinkContra = new System.Windows.Forms.LinkLabel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.eprEmail = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtActual = new System.Windows.Forms.TextBox();
            this.PanelMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eprEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelMid
            // 
            this.PanelMid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.PanelMid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PanelMid.Controls.Add(this.lblEmail);
            this.PanelMid.Controls.Add(this.lblTexto);
            this.PanelMid.Controls.Add(this.LbLinkContra);
            this.PanelMid.Controls.Add(this.btnCancelar);
            this.PanelMid.Controls.Add(this.btnEnviar);
            this.PanelMid.Controls.Add(this.txtActual);
            this.PanelMid.Controls.Add(this.txtEmail);
            this.PanelMid.Controls.Add(this.lblTitulo);
            this.PanelMid.Location = new System.Drawing.Point(12, 12);
            this.PanelMid.Name = "PanelMid";
            this.PanelMid.Size = new System.Drawing.Size(376, 339);
            this.PanelMid.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.lblEmail.Location = new System.Drawing.Point(37, 58);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(59, 25);
            this.lblEmail.TabIndex = 11;
            this.lblEmail.Text = "Email";
            // 
            // lblTexto
            // 
            this.lblTexto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.lblTexto.Location = new System.Drawing.Point(37, 177);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(311, 51);
            this.lblTexto.TabIndex = 10;
            this.lblTexto.Text = "Si tienes una cuenta registrada, recibirás un correo con su clave.";
            // 
            // LbLinkContra
            // 
            this.LbLinkContra.AutoSize = true;
            this.LbLinkContra.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LbLinkContra.Location = new System.Drawing.Point(38, 240);
            this.LbLinkContra.Name = "LbLinkContra";
            this.LbLinkContra.Size = new System.Drawing.Size(0, 21);
            this.LbLinkContra.TabIndex = 9;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(60, 289);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(257, 43);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(60, 231);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(257, 43);
            this.btnEnviar.TabIndex = 3;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(37, 95);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(306, 26);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(53, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(264, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Recupere su cuenta";
            // 
            // eprEmail
            // 
            this.eprEmail.ContainerControl = this;
            // 
            // txtActual
            // 
            this.txtActual.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtActual.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActual.ForeColor = System.Drawing.Color.Black;
            this.txtActual.Location = new System.Drawing.Point(37, 139);
            this.txtActual.Name = "txtActual";
            this.txtActual.Size = new System.Drawing.Size(306, 26);
            this.txtActual.TabIndex = 1;
            this.txtActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtActual.Visible = false;
            // 
            // frmRecuperarContra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 363);
            this.Controls.Add(this.PanelMid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmRecuperarContra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecuperarContra";
            this.PanelMid.ResumeLayout(false);
            this.PanelMid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eprEmail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelMid;
        private System.Windows.Forms.LinkLabel LbLinkContra;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider eprEmail;
        private System.Windows.Forms.TextBox txtActual;
    }
}