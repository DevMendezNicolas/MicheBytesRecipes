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
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtEmail.MaxLength = 50;
            txtContra.MaxLength = 20;
            AsignarTags();
            GestorTemaUsuario.AplicarTema(this);
            GestorTemaUsuario.TemaCambiado += () => GestorTemaUsuario.AplicarTema(this);
        }
        private void AsignarTags()
        {
            lblTitulo.Tag = "titulo";
            lblTitulo2.Tag = "titulo";
            PanelMid.Tag = "secundario";

        }


        private void LbLinkRegistrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmRegistro = new frmRegistrar();
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
            // Metodo para que solo pueda escribir letras y numeros en el txtContra y simbolos comunes y si presiona enter, haga click en btnIngresar
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && !char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnIngresar.PerformClick();
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

            Usuario usuarioActivo = gestorUsuarios.BuscarPorEmail(txtEmail.Text.Trim());
            if (usuarioActivo == null)
            {
                eprIngresar.SetError(txtEmail, "El usuario no existe.");
                return;
            }

            if (usuarioActivo.EsActivo() == false)
            {
                MessageBox.Show("La cuenta está desactivada. Por favor, contacte al administrador.");
                return;
            }

            if (gestorUsuarios.ValidarCredenciales(txtEmail.Text, gestorUsuarios.HashearContraseña(txtContra.Text)))
            {


                if (usuarioActivo.Rol == 1)
                {
                    //Abrir el formulario de menú de administrador y pasar el usuario
                    frmMenuAdmin menuAdmin = new frmMenuAdmin(usuarioActivo)
                    {
                        Owner = this.Owner

                    };
                    menuAdmin.Show();
                    salida = true;
                    //cerrar el padre

                    this.Close();

                }
                else
                {
                    // Abrir el formulario de menú de usuario
                    frmMenuUsuario menuUser = new frmMenuUsuario(usuarioActivo)
                    { 
                        Owner = this.Owner 
                    };
                    menuUser.Show();
                    salida = true;
                    this.Close();
                    
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

            frmRecuperarContra frmRecu = new frmRecuperarContra();
            frmRecu.ShowDialog();
        }
    }
}

    
