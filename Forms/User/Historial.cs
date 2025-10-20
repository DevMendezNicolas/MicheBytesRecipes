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
    public partial class Historial : Form
    {
        private Usuario usuarioLog;
        private bool recetasActivas = true;
        GestorReceta gestorReceta = new GestorReceta();
        GestorCatalogo recetasCatalogo = new GestorCatalogo();
        private UcRecetaTarjeta receta;



        public Historial(Usuario usuarioActivado)
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

        private void Historial_Load(object sender, EventArgs e)
        {
           
            CargarRecetas();
        }

    

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuUser menuUser = new MenuUser(usuarioLog);
            menuUser.Show();
        }

        private void btnHistorialPdf_Click(object sender, EventArgs e)
        {
            GeneradorPdf.ExportarPDF(dgvHistorial);
        }

      
       
        private void CargarRecetas()
        {
            flowLayoutPanel1.Controls.Clear();

            // Obtener el historial del usuario
            List<PreReceta> listaRecetas = gestorReceta.ObtenerHistorialUsuario(usuarioLog.UsuarioId);

            if (listaRecetas == null || listaRecetas.Count == 0)
            {
                Label lblVacio = new Label
                {
                    Text = "No se encontraron recetas en tu historial.",
                    AutoSize = true,
                    ForeColor = Color.Gray
                };
                flowLayoutPanel1.Controls.Add(lblVacio);
                return;
            }

            foreach (var preReceta in listaRecetas)
            {
                // Obtener la receta completa (con imagen y demás datos)
                Receta recetaCompleta = gestorReceta.ObtenerRecetaPorId(preReceta.RecetaId);
                if (recetaCompleta == null) continue;

                // Crear la tarjeta y asignar todos los datos
                UcRecetaTarjeta tarjeta = new UcRecetaTarjeta
                {
                    RecetaId = recetaCompleta.RecetaId,
                    NombreReceta = recetaCompleta.Nombre,
                    CategoriaReceta = recetasCatalogo.ObtenerCategoriaPorId(recetaCompleta.CategoriaId)?.Nombre ?? "Desconocida",
                    PaisReceta = recetasCatalogo.ObtenerPaisPorId(recetaCompleta.PaisId)?.Nombre ?? "Desconocido",
                    TiempoReceta = recetaCompleta.TiempoPreparacion.ToString(@"hh\:mm"),
                    DificultadReceta = recetaCompleta.NivelDificultad.ToString(),
                    ImagenReceta = recetaCompleta.ImagenReceta // directamente el byte[] sin conversiones
                };

                tarjeta.Tag = recetaCompleta;

                // Evento para abrir el formulario de detalles
                tarjeta.VerDetallesClick += (s, e) =>
                {
                    FrmVerReceta verRecetaForm = new FrmVerReceta(recetaCompleta, usuarioLog);
                    verRecetaForm.ShowDialog();
                };

                flowLayoutPanel1.Controls.Add(tarjeta);
            }
        }

    }
}
