using MicheBytesRecipes;
using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Classes.Recetas;
using MicheBytesRecipes.Forms.AddReceta;
using MicheBytesRecipes.Forms.Admin;
using MicheBytesRecipes.Helpers;
using MicheBytesRecipes.Managers;
using Mysqlx.Session;
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

namespace MicheBytesRecipes
{
    public partial class frmMenuAdmin : Form
    {
        GestorReceta gestorReceta = new GestorReceta();
        private Usuario usuarioLog;
        private bool recetasActivas = true;

        public void ActualizarGrilla()
        {
            dgvReceta.Rows.Clear();
            dgvReceta.Columns["dgvReceta_id"].Visible = false;
            List<PreReceta> preRecetas = recetasActivas ? gestorReceta.ObtenerPreRecetas() : gestorReceta.ObtenerPreRecetasInactivas();
            foreach (var preReceta in preRecetas)
            {
                dgvReceta.Rows.Add(preReceta.RecetaId, preReceta.Nombre, gestorReceta.ObtenerCategoriaPorId(preReceta.CategoriaId), gestorReceta.ObtenerPaisPorId(preReceta.PaisId), preReceta.Dificultad, preReceta.TiempoPreparacion);
            }
        }
        public frmMenuAdmin(Usuario usuarioActivado)
        {
            InitializeComponent();
            UiHelpers.SetRoundedButton(btnBuscar, 15);
            UiHelpers.SetRoundedButton(btnReinicio, 15);
            UiHelpers.SetRoundedButton(btnAct, 15);
            UiHelpers.SetRoundedButton(btnEliminar, 15);
            UiHelpers.SetRoundedButton(txtAgregar, 15);
            ThemeManager.ApplyTheme(this);
            UiHelpers.SetGradient(this, Color.FromArgb(0, 10, 20), Color.FromArgb(10, 30, 50), System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            //Color de la fuente del DGV en negro
            dgvReceta.ForeColor = Color.Black;
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
                dgvReceta.Columns["dgvReceta_id"].Visible = false;
                foreach (var preReceta in recetasFiltradas)
                {
                    dgvReceta.Rows.Add(preReceta.RecetaId, preReceta.Nombre, gestorReceta.ObtenerCategoriaPorId(preReceta.CategoriaId), gestorReceta.ObtenerPaisPorId(preReceta.PaisId), preReceta.Dificultad, preReceta.TiempoPreparacion);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar recetas: " + ex.Message);
            }


        }

        private void txtAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregarReceta frmAgregarReceta = new FrmAgregarReceta(usuarioLog);
            frmAgregarReceta.ShowDialog();
            if (frmAgregarReceta.DialogResult == DialogResult.OK)
            {
                this.ActualizarGrilla();
            }
        }

        private void frmMenuAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnAct_Click(object sender, EventArgs e)
        {
            recetasActivas = !recetasActivas;
            btnAct.Text = recetasActivas ? "Ver Inactivas" : "Ver Activas";
            btnEliminar.Text = recetasActivas ? "Dar baja" : "Dar alta";
            this.ActualizarGrilla();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Eliminar la receta seleccionada en el DGV
            if (recetasActivas)
            {
                if (dgvReceta.SelectedRows.Count > 0)
                {
                    int recetaId = Convert.ToInt32(dgvReceta.SelectedRows[0].Cells["dgvReceta_id"].Value);
                    gestorReceta.DarDeBajaReceta(recetaId);
                    this.ActualizarGrilla();
                }
            }
            else
            {
                if (dgvReceta.SelectedRows.Count > 0)
                {
                    int recetaId = Convert.ToInt32(dgvReceta.SelectedRows[0].Cells["dgvReceta_id"].Value);
                    gestorReceta.DarDeAltaReceta(recetaId);
                    this.ActualizarGrilla();
                }
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            GestionUsuarios gestionUsuarios = new GestionUsuarios(usuarioLog);
            gestionUsuarios.Show();
            this.Hide();
        }

        private void btnMetricas_Click(object sender, EventArgs e)
        {
            Metricas metricas = new Metricas(usuarioLog);
            metricas.Show();
            this.Hide();
        }

        private void dgvReceta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Receta receta = gestorReceta.ObtenerRecetaPorId(Convert.ToInt32(dgvReceta.Rows[e.RowIndex].Cells["dgvReceta_id"].Value));
            if (receta != null)
            {
                FrmVerReceta frmVerReceta = new FrmVerReceta(receta, usuarioLog);
                frmVerReceta.ShowDialog();
            }

            
        }
    }
}
