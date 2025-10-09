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
    public partial class RecuperarContra : Form
    {
        GestorUsuarios gestorUsuarios = new GestorUsuarios();
        public RecuperarContra()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            eprEmail.Clear();
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                eprEmail.SetError(txtEmail, "El email es obligatorio");
                txtEmail.Focus();
                return;
            }


            string email = txtEmail.Text.Trim();

            // Simular obtención de contraseña de la BD
            string password = gestorUsuarios.ObtenerContraseñaPorEmail(email);
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("No se encontró ninguna cuenta con ese correo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Enviar el email
            EmailService emailService = new EmailService();
            emailService.EnviarRecuperacionPassword(email, password);
            MessageBox.Show("Te enviamos un correo con tu contraseña.", "Recuperación enviada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();

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
    }
}
