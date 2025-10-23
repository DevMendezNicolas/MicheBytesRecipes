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
    public partial class RecuperarContra : Form
    {
        GestorUsuarios gestorUsuarios = new GestorUsuarios();
        public RecuperarContra()
        {
            InitializeComponent();
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
            // 🔹 Validación básica
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                eprEmail.SetError(txtEmail, "El email es obligatorio");
                txtEmail.Focus();
                return;
            }

            string email = txtEmail.Text.Trim();

            // 🔹 Verificar existencia en la BD
            bool existeUsuario = gestorUsuarios.ExisteUsuarioPorEmail(email);
            if (!existeUsuario)
            {
                MessageBox.Show("No se encontró ninguna cuenta con ese correo.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔹 Crear instancia del servicio de email
            EmailService emailService = new EmailService();

            try
            {
                // 🔹 Enviar código de verificación (se genera internamente)
                await Task.Run(() => emailService.EnviarCodigoVerificacion(email));

                MessageBox.Show("✅ Te enviamos un correo con el código de verificación.",
                                "Correo enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 🔹 Guardar el código generado temporalmente en variable
                string codigoGenerado = emailService.ObtenerUltimoCodigo();

                // 🔹 Podés abrir el formulario siguiente para ingresar el código
                /*Form frmCodigo = new FrmVerificarCodigo(email);
                frmCodigo.Show();
                this.Hide();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ No se pudo enviar el correo.\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
