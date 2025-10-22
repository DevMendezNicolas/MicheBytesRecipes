using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Classes.Recetas;
using MicheBytesRecipes.Helpers;
using MicheBytesRecipes.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Forms.User
{
    public partial class MenuUser : Form
    {
        GestorUsuarios gestorUsuarios = new GestorUsuarios();
        GestorCatalogo gestorCatalogo = new GestorCatalogo();
        GestorReceta gestorReceta = new GestorReceta();
        GestorTarjetasRecetas gestorTarjetas;

        private Usuario usuarioLog;
        private bool recetasActivas = true;
        private bool mostrarFavoritas = false;
        public MenuUser(Usuario usuarioActivado)
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
        }
        private void MenuUser_Load(object sender, EventArgs e)
        {
            // --- Categorías ---
            List<Categoria> categorias = gestorCatalogo.ObtenerListaCategorias();
            categorias.Insert(0, new Categoria { CategoriaId = 0, Nombre = "Todas" });
            cboCategoria.DataSource = categorias;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "CategoriaId";
            cboCategoria.SelectedIndex = 0;

            // --- Países ---
            List<Pais> paises = gestorCatalogo.ObtenerListaPaises();
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
            recetasActivas = true;
            this.ActualizarGrilla();
            this.CargarRecetas();



        }

        public void ActualizarGrilla()
        {
            dgvReceta.Rows.Clear();

            List<PreReceta> preRecetas;

            if (mostrarFavoritas)
            {
                // Trae solo recetas favoritas del usuario
                preRecetas = gestorReceta.ObtenerRecetasFavoritasPorUsuario(usuarioLog.UsuarioId);
            }
            else
            {
                // Trae todas las recetas activas
                preRecetas = gestorReceta.ObtenerPreRecetas();
            }

            foreach (var preReceta in preRecetas)
            {
                dgvReceta.Rows.Add(
                    preReceta.RecetaId,
                    preReceta.Nombre,
                    gestorCatalogo.ObtenerCategoriaPorId(preReceta.CategoriaId)?.Nombre,
                    gestorCatalogo.ObtenerPaisPorId(preReceta.PaisId)?.Nombre,
                    preReceta.Dificultad,
                    preReceta.TiempoPreparacion.ToString()
                );
            }
        }

        private void CargarRecetas()
        {

            List<PreReceta> preRecetas;
            if (mostrarFavoritas)
            {
                // Trae solo recetas favoritas del usuario
                preRecetas = gestorReceta.ObtenerRecetasFavoritasPorUsuario(usuarioLog.UsuarioId);
            }
            else
            {
                // Trae todas las recetas activas
                preRecetas = gestorReceta.ObtenerPreRecetas();
            }

            // Cargar las tarjetas usando el gestor
            gestorTarjetas.CargarTarjetas(preRecetas, usuarioLog, gestorReceta, gestorCatalogo);

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

        private void btnReinicio_Click(object sender, EventArgs e)
        {
            cboCategoria.SelectedIndex = 0;
            cboDificultad.SelectedIndex = 0;
            cboPais.SelectedIndex = 0;
            txtBuscarReceta.Text = "";
            CueProvider.SetCue(txtBuscarReceta, "Ej: Fideos con tuco, Milanesa a la napolitana...");
            this.ActualizarGrilla();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener valores de los controles
                string nombre = txtBuscarReceta.Text.Trim();

                int paisId = (cboPais.SelectedIndex > 0) ? Convert.ToInt32(cboPais.SelectedValue) : 0;
                int categoriaId = (cboCategoria.SelectedIndex > 0) ? Convert.ToInt32(cboCategoria.SelectedValue) : 0;

                Dificultad? dificultad = null;
                if (cboDificultad.SelectedIndex > 0)
                {
                    dificultad = (Dificultad)Enum.Parse(typeof(Dificultad), cboDificultad.SelectedItem.ToString());
                }

                // Llamada al método del gestor
                List<PreReceta> recetasFiltradas = gestorReceta.ObtenerPreRecetasFiltradas(nombre, paisId, categoriaId, dificultad);

                // Mostrar resultados en el DataGridView
                dgvReceta.Rows.Clear();
                foreach (var preReceta in recetasFiltradas)
                {
                    dgvReceta.Rows.Add(preReceta.RecetaId, preReceta.Nombre, gestorCatalogo.ObtenerCategoriaPorId(preReceta.CategoriaId), gestorCatalogo.ObtenerPaisPorId(preReceta.PaisId), preReceta.Dificultad, preReceta.TiempoPreparacion);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar recetas: " + ex.Message);
            }


        }

        private void dgvReceta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int recetaId = Convert.ToInt32(dgvReceta.Rows[e.RowIndex].Cells[0].Value);
                
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

        private void btnHistorialFav_Click(object sender, EventArgs e)
        {
            mostrarFavoritas = !mostrarFavoritas;
            if (mostrarFavoritas)
            {
                btnHistorialFav.Text = "Ver todas";
            }
            else
            {
                btnHistorialFav.Text = "Ver Favoritas";
            }
            this.ActualizarGrilla();
            this.CargarRecetas();

        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            this.Hide();
            Configuracion configuracion = new Configuracion(usuarioLog);
            configuracion.ShowDialog();
            this.Show();

            usuarioLog = gestorUsuarios.BuscarPorEmail(usuarioLog.Email);
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
    }
}
