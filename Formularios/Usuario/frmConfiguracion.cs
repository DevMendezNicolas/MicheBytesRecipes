using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Helpers;
using MicheBytesRecipes.Managers;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Forms.User
{
    public partial class frmConfiguracion : Form
    {
        GestorUsuarios gestorUsuarios = new GestorUsuarios();
        private Usuario usuarioLog;
        public string nuevoLog;
        private byte[] fotoOriginalBytes = Array.Empty<byte>();
        public frmConfiguracion(Usuario usuarioActivado)
        {
            InitializeComponent();
            usuarioLog = usuarioActivado;
            CargarDatosUsuario();
            DesactivarCampos();
            if (usuarioActivado.Rol == 1)
            {
                this.FormClosed += (s, e) => GestorTemaAdmin.TemaCambiado -= ActualizarTema;
            }
            else
            {
                this.FormClosed += (s, e) => GestorTemaUsuario.TemaCambiado -= ActualizarTema;

            }

        }


        private void Configuracion_Load(object sender, EventArgs e)
        {

            txtContraActual.UseSystemPasswordChar = true;
            txtContraNueva.UseSystemPasswordChar = true;
            if (usuarioLog.Rol == 1)
            {
                AsignarTagsAdmin();
                GestorTemaAdmin.TemaCambiado += ActualizarTema;
            }
            else
            {

                AsignarTagsUsuario();
                GestorTemaUsuario.TemaCambiado += ActualizarTema; 
            }
            ActualizarTema();
            

        }
        public void ActualizarTema()
        {
            if (usuarioLog.Rol == 1)
            {
                AsignarTagsAdmin();
                GestorTemaAdmin.AplicarTema(this);
            }
            else
            {

                AsignarTagsUsuario();
                GestorTemaUsuario.AplicarTema(this);
            }
            this.Refresh();
        }

        private void AsignarTagsUsuario()
        {
            lblTitulo.Tag = "titulo";
            lblNombreNuevo.Tag = "relleno";
            lblApellido.Tag = "relleno";
            lblTelefono.Tag = "relleno";
            lblEmail.Tag = "relleno";
            lblCambiarContra.Tag = "titulo";
            lblContraActual.Tag = "relleno";
            lblContraNueva.Tag = "relleno";
            pnlContenido.Tag = "opcional";
            btnEditar.Tag = "favoritos";
            btnGuardar.Tag = "guardar";
            btnCancelar.Tag = "cancelar";
            btnInicio.Tag = "menu";
        }

        private void AsignarTagsAdmin()
        {
            lblTitulo.Tag = "titulo";
            lblNombreNuevo.Tag = "relleno";
            lblApellido.Tag = "relleno";
            lblTelefono.Tag = "relleno";
            lblEmail.Tag = "relleno";
            lblCambiarContra.Tag = "titulo";
            lblContraActual.Tag = "relleno";
            lblContraNueva.Tag = "relleno";
            pnlContenido.Tag = "opcional";
            btnGuardar.Tag = "guardar";
            btnCancelar.Tag = "cancelar";
            btnInicio.Tag = "menu";
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
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnGuardar.PerformClick();
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
                toolTipCajas.Active = true;
                toolTipCajas.Show("Ingrese su nombre", txtNombre, txtNombre.Width, txtNombre.Height - 60, 5000);
                ShakeControl(txtNombre);
                eprCampos.SetError(txtNombre, "El nombre es obligatorio.");
                txtNombre.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                toolTipCajas.Active = true;
                toolTipCajas.Show("Ingrese su apellido", txtApellido, txtApellido.Width, txtApellido.Height - 60, 5000);
                ShakeControl(txtApellido);
                eprCampos.SetError(txtApellido, "El apellido es obligatorio.");
                txtApellido.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                toolTipCajas.Active = true;
                toolTipCajas.Show("Ingrese un numero de teléfono", txtTelefono, txtTelefono.Width, txtTelefono.Height - 60, 5000);
                ShakeControl(txtTelefono);
                eprCampos.SetError(txtTelefono, "El teléfono es obligatorio.");
                txtTelefono.Focus();
                return;
            }
            if (txtTelefono.Text.Length < 6)
            {
                toolTipCajas.Active = true;
                toolTipCajas.Show("Ingrese un numero de \nteléfono mayor a 6 dígitos", txtTelefono, txtTelefono.Width, txtTelefono.Height - 60, 5000);
                ShakeControl(txtTelefono);
                eprCampos.SetError(txtTelefono, "Ingrese un numero de teléfono mayor a 6 dígitos");


                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                toolTipCajas.Active = true;
                toolTipCajas.Show("Ingrese su correo electrónico", txtEmail, txtEmail.Width, txtEmail.Height - 60, 5000);
                ShakeControl(txtEmail);
                eprCampos.SetError(txtEmail, "El correo electrónico es obligatorio.");
                txtEmail.Focus();
                return;
            }

            if (!Usuario.ValidarEmail(txtEmail.Text))
            {
                toolTipCajas.Active = true;
                toolTipCajas.Show("Ingrese un correo electrónico\n válido\nEj: 'michebytes@hotmail.com' ", txtEmail, txtEmail.Width, txtEmail.Height - 60, 5000);
                ShakeControl(txtEmail);
                eprCampos.SetError(txtEmail, "El correo electrónico no es válido.");
                txtEmail.Focus();
                txtEmail.SelectAll();
                return;
            }

            GuardarUsuario();

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ActivarCampos();
            txtNombre.Focus();

        }

        private Image CrearImagenDesdeBytes(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return null;

            try
            {
                using (var ms = new System.IO.MemoryStream(bytes))
                {
                    // Se crea la imagen desde los bytes y se clona. Evita el gdi
                    using (var imgTemp = System.Drawing.Image.FromStream(ms))
                    {
                        return new System.Drawing.Bitmap(imgTemp);
                    }
                }
            }
            catch
            {
                // Si falla, devolvemos null para que cargue la de respaldo
                return null;
            }
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

            // Ruta de imagen de respaldo (por ejemplo dentro de /Resources)
            string rutaRespaldo = Path.Combine(Application.StartupPath, "Imagenes", "default_user.png");

            Image imagenPerfil = CrearImagenDesdeBytes(usuarioLog.Foto);

            // Si falló la carga o la imagen no existe, usamos la de respaldo
            if (imagenPerfil == null)
            {
                if (File.Exists(rutaRespaldo))
                {
                    imagenPerfil = new Bitmap(rutaRespaldo);
                }
                else
                {
                    // Si ni siquiera existe el respaldo, dejamos null para no romper
                    imagenPerfil = null;
                }
            }

            // Asignamos la imagen (ya sea original, o de respaldo)
            pbImagenUser.Image = imagenPerfil != null ? new Bitmap(imagenPerfil) : null;
            pbImagenUser.SizeMode = PictureBoxSizeMode.StretchImage;

            pbxEditarImagen.Image = imagenPerfil != null ? new Bitmap(imagenPerfil) : null;
            pbxEditarImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            // Guardamos los bytes originales (si hay)
            fotoOriginalBytes = usuarioLog.Foto != null && usuarioLog.Foto.Length > 0 ? usuarioLog.Foto.ToArray() : Array.Empty<byte>();
        }

        private void pbEditarImagen_Click(object sender, EventArgs e)
        {
            CambiarImagen(pbxEditarImagen);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            nuevoLog = usuarioLog.Email;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void linkCambiarImagen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CambiarImagen(pbxEditarImagen);
        }

        private void CambiarImagen(PictureBox pictureBox)
        {
            ofdImagenNueva.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofdImagenNueva.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox.Image?.Dispose();
                    pictureBox.Image = Image.FromFile(ofdImagenNueva.FileName);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen seleccionada.\n\n" + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async void ShakeControl(TextBox textBox)
        {
            btnGuardar.Enabled = false;
            // Guarda los valores originales
            var originalPos = textBox.Location;
            var originalBackColor = textBox.BackColor;
            var originalColor = textBox.ForeColor;

            textBox.BackColor = Color.FromArgb(255, 200, 200); // fondo rojo muy suave
            textBox.ForeColor = Color.Red;

            textBox.Focus();

            //Efecto shake (movimiento lateral)
            for (int i = 0; i < 3; i++) // cantidad de idas y vueltas
            {
                textBox.Location = new Point(originalPos.X + 3, originalPos.Y);
                await Task.Delay(30); // velocidad
                textBox.Location = new Point(originalPos.X - 3, originalPos.Y);
                await Task.Delay(30);
            }

            //Vuelve a la posición original
            textBox.Location = originalPos;

            //Espera un momento y restaura estilos
            await Task.Delay(3000);
            textBox.BackColor = originalBackColor;
            textBox.ForeColor = originalColor;
            btnGuardar.Enabled = true;

        }

        private void GuardarUsuario()
        {
            try
            {
                // Convertir imagen actual a bytes
                byte[] fotoBytes = fotoOriginalBytes;
                if (pbxEditarImagen.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pbxEditarImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        fotoBytes = ms.ToArray();
                    }
                }

                // Manejo de contraseña
                bool cambioContra = false;

                if (!string.IsNullOrWhiteSpace(txtContraActual.Text) || !string.IsNullOrWhiteSpace(txtContraNueva.Text))
                {
                    if (string.IsNullOrWhiteSpace(txtContraActual.Text))
                    {
                        eprCampos.SetError(txtContraActual, "La contraseña actual es obligatoria.");
                        toolTipCajas.Active = true;
                        toolTipCajas.Show("Ingrese su contraseña actual", txtContraActual, txtContraActual.Width, txtContraActual.Height - 60, 5000);
                        ShakeControl(txtContraActual);
                        txtContraActual.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtContraNueva.Text))
                    {
                        eprCampos.SetError(txtContraNueva, "La nueva contraseña es obligatoria.");
                        toolTipCajas.Active = true;
                        toolTipCajas.Show("Ingrese su contraseña nueva", txtContraNueva, txtContraNueva.Width, txtContraNueva.Height - 60, 5000);
                        ShakeControl(txtContraNueva);
                        txtContraNueva.Focus();
                        return;
                    }

                    if (txtContraNueva.Text.Length < 6)
                    {
                        eprCampos.SetError(txtContraNueva, "La nueva contraseña debe tener al menos 6 caracteres.");
                        toolTipCajas.Active = true;
                        toolTipCajas.Show("Ingrese una contraseña más larga", txtContraNueva, txtContraNueva.Width, txtContraNueva.Height - 60, 5000);
                        ShakeControl(txtContraNueva);
                        txtContraNueva.Focus();
                        txtContraNueva.SelectAll();
                        return;
                    }

                    if (txtContraActual.Text == txtContraNueva.Text)
                    {
                        eprCampos.SetError(txtContraActual, "Las contraseñas no deben coincidir");
                        eprCampos.SetError(txtContraNueva, "Las contraseñas no deben coincidir");
                        toolTipCajas.Active = true;
                        toolTipCajas.Show("Ingrese contraseñas distintas", txtContraNueva, txtContraNueva.Width, txtContraNueva.Height - 60, 5000);
                        ShakeControl(txtContraActual);
                        ShakeControl(txtContraNueva);
                        txtContraNueva.Focus();
                        txtContraNueva.SelectAll();
                        return;
                    }

                    // Actualizar contraseña
                    string nuevaContraHash = gestorUsuarios.HashearContraseña(txtContraNueva.Text);
                    gestorUsuarios.CambiarContraseña(
                        usuarioLog.UsuarioId,
                        gestorUsuarios.HashearContraseña(txtContraActual.Text),
                        nuevaContraHash
                    );
                    cambioContra = true;
                }

                // Confirmación
                DialogResult confirmacion = MessageBox.Show("¿Desea guardar los cambios realizados?", "actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                // Actualización de datos del usuario
                gestorUsuarios.ActualizarUsuario(
                    usuarioLog.UsuarioId,
                    txtEmail.Text.Trim(),
                    txtNombre.Text.Trim(),
                    txtApellido.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    fotoBytes
                );


                usuarioLog = gestorUsuarios.BuscarPorEmail(txtEmail.Text.Trim());
                CargarDatosUsuario();
                DesactivarCampos();

                string mensajeFinal = cambioContra ? "Tus datos y contraseña se actualizaron correctamente." : "Datos actualizados correctamente.";

                MessageBox.Show(mensajeFinal, "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) when (ex.Message.Contains("ya pertenece"))
            {
                // Captura SOLO el error de email duplicado
                MessageBox.Show(ex.Message, "Email duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                eprCampos.SetError(txtEmail, "Correo ya registrado");
                toolTipCajas.Active = true;
                toolTipCajas.Show("Correo ya registrado. Ingrese uno nuevo", txtEmail, txtEmail.Width, txtEmail.Height - 60, 5000);
                ShakeControl(txtEmail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
