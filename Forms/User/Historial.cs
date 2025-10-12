using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Classes.Recetas;
using MicheBytesRecipes.Utilities;

namespace MicheBytesRecipes.Forms.User
{
    public partial class Historial : Form
    {
        private Usuario usuarioLog;
        private bool recetasActivas = true;
        GestorReceta gestorReceta = new GestorReceta();


        public Historial(Usuario usuarioActivado)
        {
            InitializeComponent();
            usuarioLog = usuarioActivado;
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

            // --- Categorías ---
            List<Categoria> categorias = gestorReceta.ObtenerListaCategorias();
            categorias.Insert(0, new Categoria { CategoriaId = 0, Nombre = "Todas" });
            cboCategoria.DataSource = categorias;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "CategoriaId";
            cboCategoria.SelectedIndex = 0;

            // --- Países ---
            List<Pais> paises = gestorReceta.ObtenerListaPaises();
            paises.Insert(0, new Pais { PaisId = 0, Nombre = "Todos" });
            cboPais.DataSource = paises;
            cboPais.DisplayMember = "Nombre";
            cboPais.ValueMember = "PaisId";
            cboPais.SelectedIndex = 0;

            // --- Dificultad ---
            List<Dificultad> dificultades = Enum.GetValues(typeof(Dificultad))
                .Cast<Dificultad>()
                .ToList();

            // Creamos una lista de objetos (object) y agregamos "Todas" como primera opción
            List<object> dificultadesConOpcion = new List<object>();
            dificultadesConOpcion.Add("Todas");

            // Agregamos las dificultades convertidas a object
            dificultadesConOpcion.AddRange(dificultades.Cast<object>());

            // Asignamos al combo
            cboDificultad.DataSource = dificultadesConOpcion;
            cboDificultad.SelectedIndex = 0;

            // --- Cargar la grilla al inicio ---
            this.ActualizarGrilla();

        }

        public void ActualizarGrilla()
        {
            dgvHistorial.Rows.Clear();
            List<PreReceta> preRecetas = recetasActivas ? gestorReceta.ObtenerPreRecetas() : gestorReceta.ObtenerPreRecetasInactivas();
            foreach (var preReceta in preRecetas)
            {
                dgvHistorial.Rows.Add(preReceta.RecetaId, preReceta.Nombre, gestorReceta.ObtenerCategoriaPorId(preReceta.CategoriaId), "Completada", "Comentario", "7");
            }
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
    }
}
