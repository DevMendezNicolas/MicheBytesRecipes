using MicheBytesRecipes.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicheBytesRecipes.Forms.User.UserControls;
using System.Windows.Forms;

namespace MicheBytesRecipes.Forms.User
{
    public partial class MenuUser : Form
    {
        private Usuario usuarioLog;
        public MenuUser(Usuario usuarioActivado)
        {
            InitializeComponent();
            usuarioLog = usuarioActivado;
            lblNombre.Text = usuarioLog.NombreCompleto();
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
        }
        private void CargarUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(uc);
            uc.BringToFront();
        }

        private void MenuUser_Load(object sender, EventArgs e)
        {


        }

        private void MenuUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnHistorialRecetas_Click(object sender, EventArgs e)
        {
            Historial historial = new Historial(usuarioLog);
            historial.Show();
            this.Hide();

        }
    }
}
