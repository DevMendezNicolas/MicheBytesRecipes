using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicheBytesRecipes.Helpers;
using MicheBytesRecipes.Forms.Auth;
using System.Windows.Forms;
using SendGrid;
using SendGrid.Helpers.Mail;
using MicheBytesRecipes.Managers;

namespace MicheBytesRecipes
{
    public partial class frmLogin : Form
    {
        GestorUsuarios gestorUsuarios = new GestorUsuarios();
        public frmLogin()
        {
            InitializeComponent();
            //Setea los cues en los textbox
            CueProvider.SetCue(txtContra, "Ingrese su contraseña");
            CueProvider.SetCue(txtEmail, "Ingrese su usuario");

            //Redondeo de botones, paneles y textbox
            UiHelpers.SetRoundedPanel(PanelMid, 25);
            UiHelpers.SetRoundedTextBox(txtEmail, 10);
            UiHelpers.SetRoundedTextBox(txtContra, 10);
            UiHelpers.SetRoundedButton(btnIngresar, 40);
            UiHelpers.SetRoundedButton(BtnTema, 20);

            //Aplicación del tema y color gradiente al formulario
            ThemeManager.ApplyTheme(this);
            UiHelpers.SetGradient(this, Color.FromArgb(0, 10, 20), Color.FromArgb(10, 30, 50), System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            label1.BackColor = Color.Transparent;
            BtnTema.Text = "\u2600";

        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtEmail.MaxLength = 50;
            txtContra.MaxLength = 20;
        }

        private void BtnTema_Click(object sender, EventArgs e)
        {
            //Cambiar tema de claro a oscuro y viceversa
            ThemeManager.ToggleTheme();
            ThemeManager.ApplyTheme(this);

        }

        private void LbLinkRegistrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Abrir el formulario de registro y cerrar el actual
            FrmRegister register = new FrmRegister();
            register.Show();
            this.Close();
        }

        private void LbLinkContra_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string email = "briankevinbotta@hotmail.com";

            // Verificar que el email sea el correcto para la prueba
            if (email != "briankevinbotta@hotmail.com")
            {
                MessageBox.Show("⚠️ Para esta prueba, usa: briankevinbotta@hotmail.com");
                return;
            }

            // Simular obtención de contraseña de la BD
            string password = "tucontraPrueba";

            // Enviar el email
            EmailService emailService = new EmailService();
            emailService.EnviarRecuperacionPassword(email, password);

        }

        private void btnView_MouseDown(object sender, MouseEventArgs e)
        {
            txtContra.UseSystemPasswordChar = false;
            txtContra.PasswordChar = '\0';
        }

        private void btnView_MouseUp(object sender, MouseEventArgs e)
        {
            txtContra.UseSystemPasswordChar = true;
            txtContra.PasswordChar = '●';
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Metodo para que solo pueda escribir letras en el txtEmail
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txtContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Metodo para que solo pueda escribir letras y numeros en el txtContra y simbolos comunes
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show(); // Vuelve a mostrar el formulario Inicio
            this.Activate(); // Opcional: le da el foco
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            eprIngresar.Clear();
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                eprIngresar.SetError(txtEmail, "El campo usuario es obligatorio.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtContra.Text))
            {
                eprIngresar.SetError(txtContra, "El campo contraseña es obligatorio.");
                return;
            }
            
            if (gestorUsuarios.ValidarCredenciales(txtEmail.Text, gestorUsuarios.HashearContraseña(txtContra.Text)))
            {
                MessageBox.Show("✅ Inicio de sesión exitoso.");
            }
            else
            {
                MessageBox.Show("❌ Usuario o contraseña incorrectos.");

            }
        }
    }
}

    
