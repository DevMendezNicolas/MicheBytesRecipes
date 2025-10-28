using iTextSharp.text;
using iTextSharp.text.pdf;
using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Classes.Recetas;
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

namespace MicheBytesRecipes.Forms.User
{
    public partial class frmHistorial : Form
    {
        private Usuario usuarioLog;
        private bool recetasActivas = true;
        GestorReceta gestorReceta = new GestorReceta();
        GestorCatalogo gestorCatalogo = new GestorCatalogo();
        GestorTarjetasRecetas gestorTarjetas;



        public frmHistorial(Usuario usuarioActivado)
        {
            InitializeComponent();
            usuarioLog = usuarioActivado;
            lblNombre.Text = usuarioLog.NombreCompleto();
            gestorTarjetas = new GestorTarjetasRecetas(pnlTarjetas);

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
            this.FormClosed += (s, e) => GestorTemaUsuario.TemaCambiado -= ActualizarTema;

        }

        private void Historial_Load(object sender, EventArgs e)
        {
           
            CargarRecetas();
            AsignarTags();
            ActualizarTema();
        }
        public void ActualizarTema()
        {
            GestorTemaUsuario.AplicarTema(this);
            this.Refresh();
        }

        private void AsignarTags()
        {
            lblTituloHistorial.Tag = "titulo";
            pnlContenido.Tag = "opcional";
            pnlTarjetas.Tag = "opcional";
            btnInicio.Tag = "menu";
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
        private void CargarRecetas()
        {

            List<PreReceta> listaPreRecetas = gestorReceta.ObtenerHistorialUsuario(usuarioLog.UsuarioId);

            // Cargar las tarjetas usando el gestor
            gestorTarjetas.CargarTarjetas(listaPreRecetas, usuarioLog, gestorReceta, gestorCatalogo);

        }

    }
}
