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
using System.IO;
using MaterialSkin.Controls;

namespace MicheBytesRecipes.Forms.Auth
{
    public partial class FrmRegister : MaterialSkin.Controls.MaterialForm
    {

        GestorUsuarios gestorUsuarios = new GestorUsuarios();
        private bool salida = false;
        public FrmRegister()
        {
            InitializeComponent();
            GestorGrafico.AplicarTema(this);

            var skinManager = MaterialSkin.MaterialSkinManager.Instance;
            LinkIniciar.ForeColor = skinManager.ColorScheme.AccentColor;
            lblLinkTerminos.ForeColor = skinManager.ColorScheme.AccentColor;

            // Las propiedades de contraseña ahora se manejan en el .Designer.cs
        }

        // Evento para el LinkLabel (MaterialLabel)
        private void LinkIniciar_LinkClicked(object sender, EventArgs e)
        {
            var frmLogin = new frmLogin();
            frmLogin.FormClosed += (s, args) => this.Close(); // Cierra registro cuando se cierra login
            frmLogin.Show();
            this.Hide();
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            // 
        }

        private void pbxFotoPerfil_Click(object sender, EventArgs e)
        {
            if (ofdFotoPerfil.ShowDialog() == DialogResult.OK)
            {
                pbxFotoPerfil.Image = Image.FromFile(ofdFotoPerfil.FileName);
            }
        }

        //FUNCIoN PARA VER CONTRASEÑA
        private void txtContra_TrailingIconClick(object sender, EventArgs e)
        {
            // Invierte el estado de visualización
            txtContra.UseSystemPasswordChar = !txtContra.UseSystemPasswordChar;
            txtContra.PasswordChar = txtContra.UseSystemPasswordChar ? '•' : '\0';
        }

        private void txtRepContra_TrailingIconClick(object sender, EventArgs e)
        {
            // Invierte el estado de visualización
            txtRepContra.UseSystemPasswordChar = !txtRepContra.UseSystemPasswordChar;
            txtRepContra.PasswordChar = txtRepContra.UseSystemPasswordChar ? '•' : '\0';
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            eprCampos.Clear();
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                eprCampos.SetError(txtNombre, "El nombre es obligatorio.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                eprCampos.SetError(txtApellido, "El apellido es obligatorio.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                eprCampos.SetError(txtTelefono, "El teléfono es obligatorio.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                eprCampos.SetError(txtEmail, "El correo electrónico es obligatorio.");
                return;
            }

            if (!Usuario.ValidarEmail(txtEmail.Text))
            {
                eprCampos.SetError(txtEmail, "El correo electrónico no es válido.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContra.Text))
            {
                eprCampos.SetError(txtContra, "La contraseña es obligatoria.");
                return;
            }
            if (txtContra.Text.Length < 6)
            {
                eprCampos.SetError(txtContra, "La contraseña debe tener al menos 6 caracteres.");
                return;
            }

            if (txtContra.Text != txtRepContra.Text)
            {
                eprCampos.SetError(txtContra, "Las contraseña no coincinden");
                eprCampos.SetError(txtRepContra, "Las contraseña no coincinden");
                return;
            }

            if (!chkTerminos.Checked)
            {
                eprCampos.SetError(chkTerminos, "Debes aceptar los términos y condiciones.");
                return;
            }

            byte[] fotoBytes = Array.Empty<byte>();
            if (pbxFotoPerfil.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pbxFotoPerfil.Image.Save(ms, pbxFotoPerfil.Image.RawFormat);
                    fotoBytes = ms.ToArray();
                }
            }

            Usuario nuevoUsuario = Usuario.CrearUsuario(txtNombre.Text, txtApellido.Text, txtTelefono.Text.Trim(), txtEmail.Text.Trim(), gestorUsuarios.HashearContraseña(txtContra.Text), fotoBytes);

            gestorUsuarios.AgregarUsuario(nuevoUsuario);

            limpiarCampos();

            this.Close();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }

            if (char.IsLower(e.KeyChar) && (txtNombre.SelectionStart == 0 || txtNombre.Text.Length == 0 || (txtNombre.SelectionStart > 0 && txtNombre.Text[txtNombre.SelectionStart - 1] == ' ')))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }

            if (e.KeyChar == (char)Keys.Enter) // Enter
            {
                txtApellido.Focus();
                e.Handled = true; // Evita el sonido de "ding"
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }

            if (char.IsLower(e.KeyChar) && (txtApellido.SelectionStart == 0 || txtApellido.Text.Length == 0 || (txtApellido.SelectionStart > 0 && txtApellido.Text[txtApellido.SelectionStart - 1] == ' ')))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtTelefono.Focus();
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtEmail.Focus();
                e.Handled = true;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtContra.Focus();
                e.Handled = true;
            }
        }

        private void txtContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtRepContra.Focus();
                e.Handled = true;
            }
        }

        private void txtRepContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                chkTerminos.Focus();
                e.Handled = true;
            }
        }

        private void limpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtContra.Clear();
            txtRepContra.Clear();
            pbxFotoPerfil.Image = null;
            chkTerminos.Checked = false;
        }

        private void FrmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show(); // volver a Inicio al cerrar registro
        }

        private void lblLinkTerminos_LinkClicked(object sender, EventArgs e)
        {
            Terminos frm = new Terminos();
            frm.ShowDialog();
        }

        private void lblTituloLeft_Click(object sender, EventArgs e)
        {

        }
    }
}