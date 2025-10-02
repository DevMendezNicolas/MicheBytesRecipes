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
using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Helpers;
using Mysqlx.Session;

namespace MicheBytesRecipes
{
    public partial class frmMenuAdmin : Form
    {
        GestorReceta gestorReceta = new GestorReceta();
        private Usuario usuarioLog;
        public frmMenuAdmin(Usuario usuarioActivado)
        {
            InitializeComponent();
            CueProvider.SetCue(txtBuscarReceta, "Ej: Fideos con tuco, Milanesa a la napolitana...");
            usuarioLog = usuarioActivado;
            lblNombre.Text = usuarioLog.NombreCompleto();
            if (usuarioLog.Foto != null && usuarioLog.Foto.Length > 0)
            {
                //Crea una imagen a partir del arreglo de bytes
                using (MemoryStream ms = new MemoryStream(usuarioLog.Foto))
                {
                    //Se crea un objeto imagen a partir del stream
                    pictureBox1.Image = Image.FromStream(ms);
                    //Ajusta el tamaño de la imagen al tamaño del picturebox
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void frmMenuAdmin_Load(object sender, EventArgs e)
        {
            List<Categoria> categorias = gestorReceta.ObtenerListaCategorias();
            cboCategoria.DataSource = categorias;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.SelectedIndex = -1;
            cboCategoria.ValueMember = "CategoriaId";

        }

        private void btnReinicio_Click(object sender, EventArgs e)
        {
            cboCategoria.SelectedIndex = 0;
            cboDificultad.SelectedIndex = 0;
            cboPais.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {



        }

    }
}
