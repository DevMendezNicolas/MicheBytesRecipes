using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Forms.Admin
{
    public partial class Metricas : Form
    {
        private Usuario usuarioLog;
        GestorReceta gestorReceta = new GestorReceta();
        GestorCatalogo gestorCatalogo = new GestorCatalogo();


        public Metricas(Usuario usuarioActivado)
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
                    pbImagenAdmin.Image = System.Drawing.Image.FromStream(ms);
                    //Ajusta el tamaño de la imagen al tamaño del picturebox
                    pbImagenAdmin.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                pbImagenAdmin.Image = null;
            }
        }

        private void Metricas_Load(object sender, EventArgs e)
        {
            List<Categoria>categorias = gestorCatalogo.ObtenerListaCategorias();
            categorias.Insert(0, new Categoria { CategoriaId = 0, Nombre = "Todas" });
            cboCategoria.DataSource = categorias;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "CategoriaId";
            cboCategoria.SelectedIndex = 0;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            //Mostrar el menú admin
            frmMenuAdmin menuAdmin = new frmMenuAdmin(usuarioLog);
            menuAdmin.Show();
        }
    }
}
