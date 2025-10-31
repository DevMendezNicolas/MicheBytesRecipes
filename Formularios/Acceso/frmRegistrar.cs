using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Helpers;
using MicheBytesRecipes.Managers;
using MicheBytesRecipes.Utilities;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MicheBytesRecipes.Forms.Auth
{
    public partial class frmRegistrar : Form
    {

        GestorUsuarios gestorUsuarios = new GestorUsuarios();
        private bool salida = false;
        private const string json_path = @"DatosJson/registroContenido.json";
        public frmRegistrar()
        {


            InitializeComponent();

            //Setea los cues en los textbox
            CueProvider.SetCue(txtNombre, "Ingresa tu nombre");
            CueProvider.SetCue(txtApellido, "Ingresa tu apellido");
            CueProvider.SetCue(txtTelefono, "Ingresa tu teléfono");
            CueProvider.SetCue(txtEmail, "Ingresa tu correo electrónico");
            CueProvider.SetCue(txtContra, "Ingresa tu contraseña");
            CueProvider.SetCue(txtRepContra, "Repeti tu contraseña");

            CargarJson.CargarLabelsDesdeJson(pnlLeft, json_path);
            txtContra.UseSystemPasswordChar = true;
            txtRepContra.UseSystemPasswordChar = true;

        }

 

        private void LinkIniciar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            var login = new frmLogin();
            login.Owner = this;
            this.Hide();
            login.Show();

        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {

            AsignarTags();
            GestorTemaUsuario.AplicarTema(this);
            GestorTemaUsuario.TemaCambiado += () => GestorTemaUsuario.AplicarTema(this);
        }
        private void AsignarTags()
        {

            lblTitulo.Tag = "titulo";
            lblTituloLeft.Tag = "titulo";

        }

        private void pbxFotoPerfil_Click(object sender, EventArgs e)
        {
            lbCambiarImagen_LinkClicked(sender, null);

        }

        private void btnViewContra_MouseDown(object sender, MouseEventArgs e)
        {
            txtContra.UseSystemPasswordChar = false;
            txtContra.PasswordChar = '\0';

        }

        private void btnViewContra_MouseUp(object sender, MouseEventArgs e)
        {
            txtContra.UseSystemPasswordChar = true;
            txtContra.PasswordChar = '●';

        }

        private void btnViewAgain_MouseDown(object sender, MouseEventArgs e)
        {
            txtRepContra.UseSystemPasswordChar = false;
            txtRepContra.PasswordChar = '\0';

        }

        private void btnViewAgain_MouseUp(object sender, MouseEventArgs e)
        {
            txtRepContra.UseSystemPasswordChar = true;
            txtRepContra.PasswordChar = '●';
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool existeUsuario = gestorUsuarios.ExisteUsuarioPorEmail(txtEmail.Text.Trim());
            if (existeUsuario)
            {
                toolTipCajas.Active = true;
                toolTipCajas.Show("El correo electrónico ya está registrado.", txtEmail, txtEmail.Width, txtEmail.Height - 60, 5000);
                ShakeControl(txtEmail);
                eprCampos.SetError(txtEmail, "El correo electrónico ya está registrado.");
                txtEmail.Focus();
                txtEmail.SelectAll();
                return;
            }

            eprCampos.Clear();
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                toolTipCajas.Active = true;
                toolTipCajas.Show("Ingrese su nombre", txtNombre, txtNombre.Width, txtNombre.Height -60, 5000);
                ShakeControl(txtNombre);
                eprCampos.SetError(txtNombre, "El nombre es obligatorio.");
                txtNombre.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                toolTipCajas.Active = true;
                toolTipCajas.Show("Ingrese su apellido", txtApellido, txtApellido.Width, txtApellido.Height -60, 5000);
                ShakeControl(txtApellido);
                eprCampos.SetError(txtApellido, "El apellido es obligatorio.");
                txtApellido.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                toolTipCajas.Active = true;
                toolTipCajas.Show("Ingrese un numero de teléfono", txtTelefono, txtTelefono.Width, txtTelefono.Height -60, 5000); 
                ShakeControl(txtTelefono);
                eprCampos.SetError(txtTelefono, "El teléfono es obligatorio.");
                txtTelefono.Focus();
                return;
            }
            if (txtTelefono.Text.Length < 6)
            {
                toolTipCajas.Active = true;
                toolTipCajas.Show("Ingrese un numero de \nteléfono mayor a 6 dígitos", txtTelefono, txtTelefono.Width, txtTelefono.Height -60,5000);
                ShakeControl(txtTelefono);
                eprCampos.SetError(txtTelefono, "Ingrese un numero de teléfono mayor a 6 dígitos");

                 
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                toolTipCajas.Active = true;
                toolTipCajas.Show("Ingrese su correo electrónico", txtEmail, txtEmail.Width, txtEmail.Height -60, 5000);
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

            if (string.IsNullOrWhiteSpace(txtContra.Text))
            {
                toolTipCajas.Active = true;
                toolTipCajas.Show("Ingrese su contraseña", txtContra, txtEmail.Width, txtContra.Height - 60, 5000);
                ShakeControl(txtContra);
                eprCampos.SetError(txtContra, "La contraseña es obligatoria.");
                txtContra.Focus();
                return;
            }
            if (txtContra.Text.Length < 6)
            {
                toolTipCajas.Active = true;
                toolTipCajas.Show("Ingrese una contraseña con mas de 6 caracteres.", txtContra, txtEmail.Width, txtContra.Height - 60, 5000);
                ShakeControl(txtContra);
                eprCampos.SetError(txtContra, "La contraseña debe tener al menos 6 caracteres.");
                txtContra.Focus();
                txtContra.SelectAll();
                return;
            }

            if (txtContra.Text != txtRepContra.Text)
            {
                toolTipCajas.Active = true;
                toolTipCajas.Show("Las contraseña deben coincidir", txtContra, txtEmail.Width, txtContra.Height - 60, 5000);
                ShakeControl(txtRepContra);
                ShakeControl(txtContra);
                eprCampos.SetError(txtContra, "Las contraseña no coincinden");
                eprCampos.SetError(txtRepContra, "Las contraseña no coincinden");
                txtContra.Focus();
                return;
            }

            if (!chkTerminos.Checked)
            {
                toolTipCajas.Active = true;
                toolTipCajas.Show("Acepte los términos y condiciones para continuar",chkTerminos,chkTerminos.Width,chkTerminos.Height -60,5000);
                eprCampos.SetError(chkTerminos, "Debes aceptar los términos y condiciones.");
                return;
            }

            byte[] fotoBytes = Array.Empty<byte>();
            if (pbxFotoPerfil.Image != null)
            {
                using (var ms = new MemoryStream())
                {

                    pbxFotoPerfil.Image.Save(ms, pbxFotoPerfil.Image.RawFormat);
                    fotoBytes = ms.ToArray();
                }
            }
            else
            {
                using (var ms = new MemoryStream())
                {
                    // Si no hay imagen, establecer un array vacío
                    fotoBytes = ms.ToArray();
                }
                fotoBytes = null; // Si no hay imagen, establecer como null
            }

            Usuario nuevoUsuario = Usuario.CrearUsuario(txtNombre.Text, txtApellido.Text, txtTelefono.Text.Trim(), txtEmail.Text.Trim(), gestorUsuarios.HashearContraseña(txtContra.Text), fotoBytes);

            gestorUsuarios.AgregarUsuario(nuevoUsuario);

            limpiarCampos();
            MessageBox.Show("✅ Usuario registrado correctamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();

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
            // Permitir solo números y teclas de control
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

            if (e.KeyChar == 13)
            {
                txtContra.Focus();
            }
        }

        private void txtContra_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                txtRepContra.Focus();
            }

        }

        private void txtRepContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkTerminos.Focus();
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

        private void lblLinkTerminos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTerminos frm = new frmTerminos();
            frm.ShowDialog();

        }

        private void lbCambiarImagen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdFotoPerfil.Title = "Seleccionar Imagen de Perfil";
            ofdFotoPerfil.Filter = "Archivos de imagen|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
            if (ofdFotoPerfil.ShowDialog() == DialogResult.OK)
            {

                pbxFotoPerfil.Image = Image.FromFile(ofdFotoPerfil.FileName);
                pbxFotoPerfil.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            
        }
        private async void ShakeControl(TextBox textBox)
        {
            btnRegistrar.Enabled = false;
            // Guarda los valores originales
            var originalPos = textBox.Location;
            var originalBackColor = textBox.BackColor;
            var originalColor = textBox.ForeColor;

            // 🔹 Estilo de error (fondo y borde rojo)
            textBox.BackColor = Color.FromArgb(255, 200, 200); // fondo rojo muy suave
            textBox.ForeColor = Color.Red;

            // 🔹 Pone foco
            textBox.Focus();

            // 🔹 Efecto shake (movimiento lateral)
            for (int i = 0; i < 3; i++) // cantidad de idas y vueltas
            {
                textBox.Location = new Point(originalPos.X + 3, originalPos.Y);
                await Task.Delay(30); // velocidad
                textBox.Location = new Point(originalPos.X - 3, originalPos.Y);
                await Task.Delay(30);
            }

            // 🔹 Vuelve a la posición original
            textBox.Location = originalPos;

            // 🔹 Espera un momento y restaura estilos
            await Task.Delay(3000);
            textBox.BackColor = originalBackColor;
            textBox.ForeColor = originalColor;
            btnRegistrar.Enabled = true;

        }

    }
}
