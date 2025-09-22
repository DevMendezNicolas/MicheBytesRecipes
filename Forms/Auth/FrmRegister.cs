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

namespace MicheBytesRecipes.Forms.Auth
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();

            //Setea los cues en los textbox
            CueProvider.SetCue(TxtNombre, "Ingresa tu nombre");
            CueProvider.SetCue(TxtApellido, "Ingresa tu apellido");
            CueProvider.SetCue(TxtTelefono, "Ingresa tu teléfono");
            CueProvider.SetCue(TxtEmail, "Ingresa tu correo electrónico");
            CueProvider.SetCue(TxtContra, "Ingresa tu contraseña");
            CueProvider.SetCue(TxtRepContra, "Repeti tu contraseña");
            CueProvider.SetCue(TxtRecupero, "Ingresa una palabra de recuperacion");

            //Redondeo de botones, paneles y textbox
            UiHelpers.SetRoundedTextBox(TxtNombre, 20);
            UiHelpers.SetRoundedTextBox(TxtApellido, 20);
            UiHelpers.SetRoundedTextBox(TxtTelefono, 20);
            UiHelpers.SetRoundedTextBox(TxtEmail, 20);
            UiHelpers.SetRoundedTextBox(TxtContra, 20);
            UiHelpers.SetRoundedTextBox(TxtRepContra, 20);
            UiHelpers.SetRoundedTextBox(TxtRecupero, 20);
            UiHelpers.SetRoundedButton(BtnRegistrar, 20);

            //Aplicación del tema y color gradiente al formulario y panel derecho
            ThemeManager.ApplyTheme(this);
            UiHelpers.SetGradient(this, Color.FromArgb(0, 10, 20), Color.FromArgb(10, 30, 50), System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            UiHelpers.SetGradient(PanelRight, Color.FromArgb(0, 10, 20), Color.FromArgb(10, 30, 50), System.Drawing.Drawing2D.LinearGradientMode.Vertical);

        }

        private void PanelRight_Paint(object sender, PaintEventArgs e)
        {

            //Hacer transparentes los labels y checkbox del panel derecho. Pero no afecta el setcue
            foreach (Control control in PanelRight.Controls)
            {
                if (control is Label)
                {
                    control.BackColor = Color.Transparent;
                }
            }

            LinkTerminos.BackColor = Color.Transparent;
            LinkIniciar.BackColor = Color.Transparent;

        }

        private void LinkIniciar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmLogin login = new frmLogin();
            this.Close();
            login.Show();
            
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            //Hacer transparentes los labels formulario
            foreach (Control control in this.Controls )
            {
                if (control is Label)
                {
                    control.BackColor = Color.Transparent;
                }
            }
        }

        private void pbxFotoPerfil_Click(object sender, EventArgs e)
        {
            if (ofdFotoPerfil.ShowDialog() == DialogResult.OK)
            {
                pbxFotoPerfil.Image = Image.FromFile(ofdFotoPerfil.FileName);
            }
        }
    }
}
