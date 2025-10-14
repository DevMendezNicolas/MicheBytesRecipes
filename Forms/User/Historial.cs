using iTextSharp.text;
using iTextSharp.text.pdf;
using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Classes.Recetas;
using MicheBytesRecipes.Helpers;
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
            List<PreReceta> preRecetas = gestorReceta.ObtenerHistorialUsuario(usuarioLog.UsuarioId);
            foreach (var preReceta in preRecetas)
            {
                dgvHistorial.Rows.Add(
                    preReceta.RecetaId,
                    preReceta.Nombre,
                    gestorReceta.ObtenerCategoriaPorId(preReceta.CategoriaId)?.Nombre,
                    gestorReceta.ObtenerPaisPorId(preReceta.PaisId)?.Nombre,
                    preReceta.Dificultad,
                    preReceta.TiempoPreparacion.ToString()
                );
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener valores de los controles
                string nombre = txtBuscarHistorial.Text.Trim();

                int paisId = (cboPais.SelectedIndex > 0) ? Convert.ToInt32(cboPais.SelectedValue) : 0;
                int categoriaId = (cboCategoria.SelectedIndex > 0) ? Convert.ToInt32(cboCategoria.SelectedValue) : 0;

                Dificultad? dificultad = null;
                if (cboDificultad.SelectedIndex > 0)
                {
                    dificultad = (Dificultad)Enum.Parse(typeof(Dificultad), cboDificultad.SelectedItem.ToString());
                }

                // Llamada al método del gestor SOBRA PAIS Y DIFICULTAD
                List<PreReceta> recetasFiltradas = gestorReceta.ObtenerPreRecetasFiltradas(nombre, paisId, categoriaId, dificultad);

                // Mostrar resultados en el DataGridView
                dgvHistorial.Rows.Clear();
                foreach (var preReceta in recetasFiltradas)
                {
                    dgvHistorial.Rows.Add(preReceta.RecetaId, preReceta.Nombre, gestorReceta.ObtenerCategoriaPorId(preReceta.CategoriaId), gestorReceta.ObtenerPaisPorId(preReceta.PaisId), preReceta.Dificultad, preReceta.TiempoPreparacion);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar recetas: " + ex.Message);
            }


        }

        private void btnReinicio_Click(object sender, EventArgs e)
        {
            cboCategoria.SelectedIndex = 0;
            cboDificultad.SelectedIndex = 0;
            cboPais.SelectedIndex = 0;
            txtBuscarHistorial.Text = "";
            this.ActualizarGrilla();
        }

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int recetaId = Convert.ToInt32(dgvHistorial.Rows[e.RowIndex].Cells[0].Value);

                Receta receta = gestorReceta.ObtenerRecetaPorId(recetaId);

                if (receta != null)
                {
                    FrmVerReceta verRecetaForm = new FrmVerReceta(receta, usuarioLog);
                    verRecetaForm.ShowDialog();
                    ActualizarGrilla();
                }
                else
                {
                    MessageBox.Show("No se pudo cargar la receta seleccionada.");
                }
            }


        }

    }
}
