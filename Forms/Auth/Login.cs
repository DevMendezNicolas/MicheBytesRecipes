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
using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Forms.User;

namespace MicheBytesRecipes
{
    public partial class frmLogin : Form
    {
        GestorUsuarios gestorUsuarios = new GestorUsuarios();
        private bool salida = false;
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
            var frmRegistro = new FrmRegister();
            frmRegistro.FormClosed += (s, args) => this.Close(); // Cierra login cuando se cierra registro
            frmRegistro.Show();
            this.Hide();
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
            if (salida) return; // login correcto → no mostrar nada
            if (this.Owner != null) this.Owner.Show(); // volver a Inicio solo si se cerró sin loguear
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
                Usuario usuarioActivo = gestorUsuarios.BuscarPorEmail(txtEmail.Text.Trim());

                if (usuarioActivo.Rol == 1)
                {
                    //Abrir el formulario de menú de administrador y pasar el usuario
                    frmMenuAdmin menuAdmin = new frmMenuAdmin(usuarioActivo);
                    menuAdmin.Show();
                    salida = true;
                    this.Close();

                }
                else
                {
                    // Abrir el formulario de menú de usuario
                    MenuUser menuUser = new MenuUser(usuarioActivo);
                    menuUser.FormClosed += (s, args) => this.Show();
                    menuUser.Show();
                    this.Hide();
                    
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
                return;
            }
        }

        private void lblLinkResetContra_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //abrir Formulario en modal

            RecuperarContra frmRecu = new RecuperarContra();
            frmRecu.ShowDialog();
        }
    }
}

    
