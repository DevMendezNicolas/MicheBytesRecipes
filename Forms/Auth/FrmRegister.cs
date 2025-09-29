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
using MicheBytesRecipes.Managers;
using MicheBytesRecipes.Classes;

namespace MicheBytesRecipes.Forms.Auth
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            GestorUsuarios gestorUsuarios = new GestorUsuarios();

            InitializeComponent();

            //Setea los cues en los textbox
            CueProvider.SetCue(txtNombre, "Ingresa tu nombre");
            CueProvider.SetCue(txtApellido, "Ingresa tu apellido");
            CueProvider.SetCue(txtTelefono, "Ingresa tu teléfono");
            CueProvider.SetCue(txtEmail, "Ingresa tu correo electrónico");
            CueProvider.SetCue(txtContra, "Ingresa tu contraseña");
            CueProvider.SetCue(txtRepContra, "Repeti tu contraseña");

            //Redondeo de botones, paneles y textbox
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


            eprCampos.Clear();
            if(string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                eprCampos.SetError(txtNombre, "El nombre es obligatorio.");
                return;
            }
            if(string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                eprCampos.SetError(txtApellido, "El apellido es obligatorio.");
                return;
            }
            if(string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                eprCampos.SetError(txtTelefono, "El teléfono es obligatorio.");
                return;
            }
            if(string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                eprCampos.SetError(txtEmail, "El correo electrónico es obligatorio.");
                return;
            }
            if(string.IsNullOrWhiteSpace(txtContra.Text))
            {
                eprCampos.SetError(txtContra, "La contraseña es obligatoria.");
                return;
            }
            if(txtContra != txtRepContra)
            {
                eprCampos.SetError(txtContra, "Las contraseña no coincinden");
                eprCampos.SetError(txtRepContra, "Las contraseña no coincinden");
                return;
            }
            if(!chkTerminos.Checked)
            {
                eprCampos.SetError(chkTerminos, "Debes aceptar los términos y condiciones.");
                return;
            }

            /*Usuario usuarioRegistro = new Usuario(

                txtNombre.Text,
                txtApellido.Text,
                txtTelefono.Text,
                txtEmail.Text,
                txtContra.Text,
                pbxFotoPerfil.Image != null ? ImageToByteArray.ConvertImageToByteArray(pbxFotoPerfil.Image) : null);*/


        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }

            // Convertir a mayúscula la primera letra y después de un espacio
            if (char.IsLower(e.KeyChar) && (txtNombre.SelectionStart == 0 || txtNombre.Text[txtNombre.SelectionStart - 1] == ' '))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }

            if(e.KeyChar == 13)
            {
                txtApellido.Focus();
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
            // Convertir a mayúscula la primera letra y después de un espacio
            if (char.IsLower(e.KeyChar) && (txtApellido.SelectionStart == 0 || txtApellido.Text[txtApellido.SelectionStart - 1] == ' '))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            if (e.KeyChar == 13)
            {
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtEmail.Focus();
            }

        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validar que sea un email
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            if (e.KeyChar == 13)
            {
                txtContra.Focus();
            }
        }

        private void txtContra_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                txtRepContra.Focus();
            }

        }

        private void txtRepContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkTerminos.Focus();
            }

        }
    }
}
