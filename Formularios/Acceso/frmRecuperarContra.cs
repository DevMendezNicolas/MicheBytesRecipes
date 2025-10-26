using MicheBytesRecipes.Helpers;
using MicheBytesRecipes.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Forms.Auth
{
    // SYSTEM NET MAIL. 
    public partial class frmRecuperarContra : Form
    {
        GestorUsuarios gestorUsuarios = new GestorUsuarios();
        private string emailRecupero;
        private EmailService emailService;

        public frmRecuperarContra()
        {
            InitializeComponent();
            emailService = new EmailService();
            CueProvider.SetCue(txtEmail, "tuCorreo@hotmail.com");
            txtNuevaContra.UseSystemPasswordChar = true;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {

            eprEmail.Clear();

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                eprEmail.SetError(txtEmail, "El email es obligatorio");
                txtEmail.Focus();
                return;
            }

            string email = txtEmail.Text.Trim();

            bool existeUsuario = gestorUsuarios.ExisteUsuarioPorEmail(email);
            if (!existeUsuario)
            {
                MessageBox.Show("No se encontró ninguna cuenta con ese correo.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            emailRecupero = email;

            try
            {
                progressBar.Visible = true;
                btnEnviar.Enabled = false;
                btnCancelar.Enabled = false;
                //Usar la MISMA instancia de emailService
                await emailService.EnviarCodigoVerificacion(email);


                MessageBox.Show("✅ Te enviamos un correo con el código de verificación.",
                                "Correo enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //El código ya está guardado en emailService
                txtEmail.Clear();
                CueProvider.SetCue(txtEmail, "Código de verificación");
                lblEmail.Text = "Ingrese su codigo de verificación";
                btnEnviar.Text = "Verificar Código";
                lblTexto.Text = "Ingresá el código de 6 dígitos que llego a tu correo.";

                btnEnviar.Click -= btnIngresar_Click;
                btnEnviar.Click += VerificarCodigo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ No se pudo enviar el correo.\nError: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;
                btnEnviar.Enabled = true;
                btnCancelar.Enabled = true;
            }

        }


        private void VerificarCodigo(object sender, EventArgs e)
        {
            string codigoGenerado = emailService.ObtenerUltimoCodigo(); // ← Mismo código que se envió
            string codigoIngresado = txtEmail.Text.Trim();

            if (codigoIngresado == codigoGenerado)
            {
                MessageBox.Show("El código de verificación es correcto. Ahora puede crear su nueva contraseña.",
                               "✅ Verificación Exitosa",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                NuevaContraseña();
            }
            else
            {
                MessageBox.Show("El código ingresado no es válido.",
                               "❌ Código Incorrecto",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void NuevaContraseña()
        {
            // Configurar interfaz para nueva contraseña
            txtEmail.Clear();
            CueProvider.SetCue(txtNuevaContra, "Repeti tu nueva contraseña");
            txtNuevaContra.Clear();
            txtNuevaContra.Visible = true;

            lblTexto.Text = "Ingresá tu nueva contraseña";
            lblEmail.Text = "Nueva contraseña";
            CueProvider.SetCue(txtEmail, "Ingresa tu nueva contraseña");


            // Cambiar a evento de cambio de contraseña
            btnEnviar.Click -= VerificarCodigo;
            btnEnviar.Click += CambiarContraseña;
            btnEnviar.Text = "Cambiar Contraseña";
            txtEmail.UseSystemPasswordChar = true;
            btnViewAgain.Visible = true;
            btnViewContra.Visible = true;
        }

        private void CambiarContraseña(object sender, EventArgs e)
        {
            string nuevaContraseña = txtEmail.Text.Trim();
            string confirmarContraseña = txtNuevaContra.Text.Trim();

            // Validar que no estén vacías
            if (string.IsNullOrWhiteSpace(nuevaContraseña) || string.IsNullOrWhiteSpace(confirmarContraseña))
            {
                MessageBox.Show("Ambas contraseñas son obligatorias para continuar.",
                               "⚠️ Campos Requeridos",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            // Validar que coincidan
            if (nuevaContraseña != confirmarContraseña)
            {
                MessageBox.Show("Las contraseñas ingresadas no coinciden. Por favor, verifique e intente nuevamente.",
                               "❌ Contraseñas No Coinciden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string contraseñaHasheada = gestorUsuarios.HashearContraseña(nuevaContraseña);

                bool resultado = gestorUsuarios.OlvideMiContraseña(emailRecupero, contraseñaHasheada);

                if (resultado)
                {
                    MessageBox.Show("Su contraseña ha sido actualizada exitosamente.", "✅ Contraseña Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RestaurarFormularioOriginal();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la contraseña. Por favor, intente nuevamente", "❌ Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "⚠️ Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RestaurarFormularioOriginal()
        {
            // Restaurar todo al estado original
            txtEmail.Clear();
            txtNuevaContra.Clear();
            txtNuevaContra.Visible = false;

            lblTitulo.Text = "Recuperar Contraseña";

            // Restaurar evento original
            btnEnviar.Click -= CambiarContraseña;
            btnEnviar.Click += btnIngresar_Click;
            btnEnviar.Text = "Enviar Código";

            // Limpiar tag
            txtEmail.Tag = null;
        }

        private void btnViewContra_MouseDown(object sender, MouseEventArgs e)
        {
            txtEmail.UseSystemPasswordChar = false;
            txtEmail.PasswordChar = '\0';

        }

        private void btnViewAgain_MouseDown(object sender, MouseEventArgs e)
        {
            txtNuevaContra.UseSystemPasswordChar = false;
            txtNuevaContra.PasswordChar = '\0';

        }

        private void btnViewContra_MouseUp(object sender, MouseEventArgs e)
        {
            txtEmail.UseSystemPasswordChar = true;
            txtEmail.PasswordChar = '●';

        }

        private void btnViewAgain_MouseUp(object sender, MouseEventArgs e)
        {
            txtNuevaContra.UseSystemPasswordChar = true;
            txtNuevaContra.PasswordChar = '●';
        }
    }
}
