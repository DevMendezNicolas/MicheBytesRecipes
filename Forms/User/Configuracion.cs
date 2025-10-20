using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Forms.User
{
    public partial class Configuracion : Form
    {
        GestorUsuarios gestorUsuarios = new GestorUsuarios();
        private Usuario usuarioLog;
        public Configuracion(Usuario usuarioActivado)
        {
            InitializeComponent();
            usuarioLog = usuarioActivado;
            CargarDatosUsuario();
            DesactivarCampos();
        }
        

        private void Configuracion_Load(object sender, EventArgs e)
        {

            txtContraActual.UseSystemPasswordChar = true;
            txtContraNueva.UseSystemPasswordChar = true;
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

            if (e.KeyChar == 13)
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
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txtContraActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtContraNueva.Focus();
            }

        }

        private void txtContraNueva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnGuardar.Focus();
            }

        }
        private void DesactivarCampos()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtTelefono.Enabled = false;
            txtEmail.Enabled = false;
            txtContraActual.Enabled = false;
            txtContraNueva.Enabled = false;
            txtContraActual.Clear();
            txtContraNueva.Clear();
            linkCambiarImagen.Enabled = false;
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            pbxEditarImagen.Enabled = false;
            btnViewContra.Enabled = false;
            btnViewContraNueva.Enabled = false;

        }

        private void ActivarCampos()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;
            txtContraActual.Enabled = true;
            txtContraNueva.Enabled = true;
            linkCambiarImagen.Enabled = true;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            pbxEditarImagen.Enabled = true;
            btnViewContra.Enabled = true;
            btnViewContraNueva.Enabled = true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CargarDatosUsuario();
            DesactivarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            // Validaciones de los campos
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


            byte[] fotoBytes = Array.Empty<byte>();
            if (pbxEditarImagen.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pbxEditarImagen.Image.Save(ms, pbxEditarImagen.Image.RawFormat);
                    fotoBytes = ms.ToArray();
                }
            }


            // Validar que la nueva contraseña y la actual no sean iguales

            bool cambioContra = false;

            if (!string.IsNullOrWhiteSpace(txtContraActual.Text) || !string.IsNullOrWhiteSpace(txtContraNueva.Text))
            {
                if (string.IsNullOrWhiteSpace(txtContraActual.Text))
                {
                    eprCampos.SetError(txtContraActual, "La contraseña actual es obligatoria.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtContraNueva.Text))
                {
                    eprCampos.SetError(txtContraNueva, "La nueva contraseña es obligatoria.");
                    return;
                }

                if (txtContraNueva.Text.Length < 6)
                {
                    eprCampos.SetError(txtContraNueva, "La nueva contraseña debe tener al menos 6 caracteres.");
                    return;
                }
                if (txtContraActual.Text == txtContraNueva.Text)
                {
                    eprCampos.SetError(txtContraActual, "Las contraseñas no deben coincidir");
                    eprCampos.SetError(txtContraNueva, "Las contraseñas no deben coincindir");
                    return;
                }

                if (!gestorUsuarios.VerificarContraseñaActual(usuarioLog.UsuarioId, txtContraActual.Text))
                {
                    eprCampos.SetError(txtContraActual, "La contraseña actual no es correcta.");
                    return;
                }

                // Si pasa, actualiza la nueva contraseña

                string nuevaContraHash = gestorUsuarios.HashearContraseña(txtContraNueva.Text);
                gestorUsuarios.ModificarContraseña(usuarioLog.UsuarioId, nuevaContraHash);
                cambioContra = true;
            }

            gestorUsuarios.ActualizarUsuario(
                usuarioLog.UsuarioId,
                txtEmail.Text.Trim(),
                txtNombre.Text.Trim(),
                txtApellido.Text.Trim(),
                txtTelefono.Text.Trim(),
                fotoBytes);
            usuarioLog = gestorUsuarios.BuscarPorEmail(txtEmail.Text.Trim());
            CargarDatosUsuario();
            DesactivarCampos();

            string mensaje = cambioContra ? "Tus datos y contraseña se actualizaron correctamente." : "Datos actualizados correctamente.";

            MessageBox.Show(mensaje, "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnViewContra_MouseUp(object sender, MouseEventArgs e)
        {
            txtContraActual.UseSystemPasswordChar = true;
            txtContraActual.PasswordChar = '●';

        }

        private void btnViewContraNueva_MouseUp(object sender, MouseEventArgs e)
        {
            txtContraNueva.UseSystemPasswordChar = true;
            txtContraNueva.PasswordChar = '●';

        }

        private void btnViewContra_MouseDown(object sender, MouseEventArgs e)
        {
            txtContraActual.UseSystemPasswordChar = false;
            txtContraActual.PasswordChar = '\0';
        }

        private void btnViewContraNueva_MouseDown(object sender, MouseEventArgs e)
        {
            txtContraNueva.UseSystemPasswordChar = false;
            txtContraNueva.PasswordChar = '\0';
        }

        private void lblEditar_Click(object sender, EventArgs e)
        {
            ActivarCampos();
            txtNombre.Focus();

        }

        private void CargarDatosUsuario()
        {
            txtNombre.Text = usuarioLog.Nombre;
            txtApellido.Text = usuarioLog.Apellido;
            txtTelefono.Text = usuarioLog.Telefono;
            txtEmail.Text = usuarioLog.Email;
            lblNombre.Text = usuarioLog.NombreCompleto();
            txtContraActual.Clear();
            txtContraNueva.Clear();

            if (usuarioLog.Foto != null && usuarioLog.Foto.Length > 0)
            {
                //Crea una imagen a partir del arreglo de bytes
                using (var ms = new System.IO.MemoryStream(usuarioLog.Foto))
                {
                    //Se crea un objeto imagen a partir del stream
                    pbImagenUser.Image = System.Drawing.Image.FromStream(ms);
                    //Ajusta el tamaño de la imagen al tamaño del picturebox
                    pbImagenUser.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                pbImagenUser.Image = null;
            }

            if (usuarioLog.Foto != null && usuarioLog.Foto.Length > 0)
            {
                //Crea una imagen a partir del arreglo de bytes
                using (var ms = new System.IO.MemoryStream(usuarioLog.Foto))
                {
                    //Se crea un objeto imagen a partir del stream
                    pbxEditarImagen.Image = System.Drawing.Image.FromStream(ms);
                    //Ajusta el tamaño de la imagen al tamaño del picturebox
                    pbxEditarImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                pbxEditarImagen.Image = null;
            }

        }

        private void pbEditarImagen_Click(object sender, EventArgs e)
        {
            if (ofdImagenNueva.ShowDialog() == DialogResult.OK)
            {
                pbxEditarImagen.Image = Image.FromFile(ofdImagenNueva.FileName);
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void linkCambiarImagen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

                        if (ofdImagenNueva.ShowDialog() == DialogResult.OK)
            {
                pbxEditarImagen.Image = Image.FromFile(ofdImagenNueva.FileName);
            }

        }
    }
}
