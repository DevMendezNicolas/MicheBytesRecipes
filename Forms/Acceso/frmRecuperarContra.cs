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
                // 🔥 Usar la MISMA instancia de emailService
                await emailService.EnviarCodigoVerificacion(email);

                MessageBox.Show("✅ Te enviamos un correo con el código de verificación.",
                                "Correo enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 🔥 El código ya está guardado en emailService
                txtEmail.Clear();
                btnEnviar.Text = "Verificar Código";
                lblTexto.Text = "Ingresá el código de 6 dígitos";
                txtActual.Visible = false;

                btnEnviar.Click -= btnIngresar_Click;
                btnEnviar.Click += VerificarCodigo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ No se pudo enviar el correo.\nError: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerificarCodigo(object sender, EventArgs e)
        {
            string codigoGenerado = emailService.ObtenerUltimoCodigo(); // ← Mismo código que se envió
            string codigoIngresado = txtEmail.Text.Trim();

            if (codigoIngresado == codigoGenerado)
            {
                MessageBox.Show("✅ Código correcto!");
                NuevaContraseña();
            }
            else
            {
                MessageBox.Show("❌ Código incorrecto");
            }
        }

        private void NuevaContraseña()
        {
            // Configurar interfaz para nueva contraseña
            txtEmail.Clear();
            txtActual.Clear();
            txtActual.Visible = true;

            lblTexto.Text = "Ingresá tu nueva contraseña";
            //txtEmail.PlaceholderText = "Nueva contraseña";
            //txtActual.PlaceholderText = "Confirmar contraseña";

            // Cambiar a evento de cambio de contraseña
            btnEnviar.Click -= VerificarCodigo;
            btnEnviar.Click += CambiarContraseña;
            btnEnviar.Text = "Cambiar Contraseña";
        }

        private void CambiarContraseña(object sender, EventArgs e)
        {
            string nuevaContraseña = txtEmail.Text.Trim();
            string confirmarContraseña = txtActual.Text.Trim();

            // Validar que no estén vacías
            if (string.IsNullOrWhiteSpace(nuevaContraseña) || string.IsNullOrWhiteSpace(confirmarContraseña))
            {
                MessageBox.Show("❌ Ambas contraseñas son obligatorias");
                return;
            }

            // Validar que coincidan
            if (nuevaContraseña != confirmarContraseña)
            {
                MessageBox.Show("❌ Las contraseñas no coinciden");
                return;
            }

            try
            {
                // 🔥 USAR LA VARIABLE DONDE GUARDASTE EL EMAIL
                string contraseñaHasheada = gestorUsuarios.HashearContraseña(nuevaContraseña);

                // Tu método debería recibir email y contraseña nueva
                /*bool exito = gestorUsuarios.CambiarContraseña(emailRecupero, contraseñaHasheada);

                if (exito)
                {
                    MessageBox.Show("✅ Contraseña actualizada correctamente");
                    RestaurarFormularioOriginal();
                }
                else
                {
                    MessageBox.Show("❌ Error al actualizar la contraseña");
                }*/
                MessageBox.Show("Contra cambiada");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error: {ex.Message}");
            }
        }
        private void RestaurarFormularioOriginal()
        {
            // Restaurar todo al estado original
            txtEmail.Clear();
            txtActual.Clear();
            txtActual.Visible = false;

            lblTitulo.Text = "Recuperar Contraseña";
            //txtEmail.PlaceholderText = "Ingrese su email";

            // Restaurar evento original
            btnEnviar.Click -= CambiarContraseña;
            btnEnviar.Click += btnIngresar_Click;
            btnEnviar.Text = "Enviar Código";

            // Limpiar tag
            txtEmail.Tag = null;
        }
    }
}
