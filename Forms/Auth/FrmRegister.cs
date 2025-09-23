using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicheBytesRecipes.Helpers;
using System.Windows.Forms;

namespace MicheBytesRecipes.Forms.Auth
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();

            //Setea los cues en los textbox
            CueProvider.SetCue(txtNombre, "Ingresa tu nombre");
            CueProvider.SetCue(txtApellido, "Ingresa tu apellido");
            CueProvider.SetCue(txtTelefono, "Ingresa tu teléfono");
            CueProvider.SetCue(txtEmail, "Ingresa tu correo electrónico");
            CueProvider.SetCue(txtContra, "Ingresa tu contraseña");
            CueProvider.SetCue(txtRepContra, "Repeti tu contraseña");

            //Redondeo de botones, paneles y textbox
            /*UiHelpers.SetRoundedTextBox(txtNombre, 20);
            UiHelpers.SetRoundedTextBox(txtApellido, 20);
            UiHelpers.SetRoundedTextBox(txtTelefono, 20);
            UiHelpers.SetRoundedTextBox(txtEmail, 20);
            UiHelpers.SetRoundedTextBox(txtContra, 20);
            UiHelpers.SetRoundedTextBox(txtRepContra, 20);*/
            UiHelpers.SetRoundedButton(btnRegistrar, 20);

            //Aplicación del tema y color gradiente al formulario y panel derecho
            ThemeManager.ApplyTheme(this);
            UiHelpers.SetGradient(pnlRight, Color.FromArgb(0, 10, 20), Color.FromArgb(10, 30, 50), System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            UiHelpers.SetGradient(pnlRight, Color.FromArgb(0, 10, 20), Color.FromArgb(10, 30, 50), System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            ThemeManager.ApplyTheme(this);
            UiHelpers.SetGradient(pnlLeft, Color.FromArgb(0, 10, 20), Color.FromArgb(10, 30, 50), System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            UiHelpers.SetGradient(pnlLeft, Color.FromArgb(0, 10, 20), Color.FromArgb(10, 30, 50), System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            txtContra.UseSystemPasswordChar = true;
            txtRepContra.UseSystemPasswordChar = true;

        }

        private void pnlRight_Paint(object sender, PaintEventArgs e)
        {

            //Hacer transparentes los labels y checkbox del panel derecho. Pero no afecta el setcue
            foreach (Control control in pnlRight.Controls)
            {
                if (control is Label)
                {
                    control.BackColor = Color.Transparent;
                }
            }

            lblLinkTerminos.BackColor = Color.Transparent;
            LinkIniciar.BackColor = Color.Transparent;

        }
        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {
            foreach (Control control in pnlRight.Controls)
            {
                if (control is Label)
                {
                    control.BackColor = Color.Transparent;
                }
            }
            lblTituloLeft.BackColor = Color.Transparent;
            lblRelleno.BackColor = Color.Transparent;
            lblTexto.BackColor = Color.Transparent;

        }

        private void LinkIniciar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmLogin login = new frmLogin();
            this.Close();
            login.Show();
            
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            //Hacer transparentes los labels formulario
            foreach (Control control in this.Controls )
            {
                if (control is Label)
                {
                    control.BackColor = Color.Transparent;
                }
            }
        }

        private void pbxFotoPerfil_Click(object sender, EventArgs e)
        {
            if (ofdFotoPerfil.ShowDialog() == DialogResult.OK)
            {
                pbxFotoPerfil.Image = Image.FromFile(ofdFotoPerfil.FileName);
            }
        }

        private void btnViewContra_MouseDown(object sender, MouseEventArgs e)
        {
            txtContra.UseSystemPasswordChar = false;
            txtContra.PasswordChar = '\0';

        }

        private void btnViewContra_MouseUp(object sender, MouseEventArgs e)
        {
            txtContra.UseSystemPasswordChar = true;
            txtContra.PasswordChar = '●';
            
        }

        private void btnViewAgain_MouseDown(object sender, MouseEventArgs e)
        {
            txtRepContra.UseSystemPasswordChar = false;
            txtRepContra.PasswordChar = '\0';

        }

        private void btnViewAgain_MouseUp(object sender, MouseEventArgs e)
        {
            txtRepContra.UseSystemPasswordChar = true;
            txtRepContra.PasswordChar = '●';
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = txtContra.Text;
        }


    }
}
