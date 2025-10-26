using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Classes.Recetas;
using MicheBytesRecipes.Forms.AddReceta;
using MicheBytesRecipes.Forms.Admin;
using MicheBytesRecipes.Helpers;
using MicheBytesRecipes.Managers;
using MicheBytesRecipes.Utilities;

namespace MicheBytesRecipes
{
    public partial class frmMenuAdmin : Form
    {
        GestorReceta gestorReceta = new GestorReceta();
        GestorCatalogo gestorCatalogo = new GestorCatalogo();
        private Usuario usuarioLog;
        private bool cierrePorSesion = false;
        private bool recetasActivas = true;

        public void ActualizarGrilla()
        {
            dgvReceta.Rows.Clear();
            dgvReceta.Columns["dgvReceta_id"].Visible = false;
            List<PreReceta> preRecetas = recetasActivas ? gestorReceta.ObtenerPreRecetas() : gestorReceta.ObtenerPreRecetasInactivas();
            foreach (var preReceta in preRecetas)
            {
                dgvReceta.Rows.Add(preReceta.RecetaId, preReceta.Nombre, gestorCatalogo.ObtenerCategoriaPorId(preReceta.CategoriaId), gestorCatalogo.ObtenerPaisPorId(preReceta.PaisId), preReceta.Dificultad, preReceta.TiempoPreparacion);
            }
        }
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
            ThemeManager.ThemeChanged += OnThemeChanged;


        }

        private void frmMenuAdmin_Load(object sender, EventArgs e)
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
            this.ActualizarGrilla();
            AsignarTagsBotones();
            ThemeManager.ApplyTheme(this);


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
                    dgvReceta.Rows.Add(preReceta.RecetaId, preReceta.Nombre, gestorCatalogo.ObtenerCategoriaPorId(preReceta.CategoriaId), gestorCatalogo.ObtenerPaisPorId(preReceta.PaisId), preReceta.Dificultad, preReceta.TiempoPreparacion);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar recetas: " + ex.Message);
            }


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarReceta frmAgregarReceta = new frmAgregarReceta(usuarioLog);
            frmAgregarReceta.ShowDialog();
            if (frmAgregarReceta.DialogResult == DialogResult.OK)
            {
                this.ActualizarGrilla();
            }
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
                    gestorReceta.DarDeBajaReceta(recetaId, usuarioLog.UsuarioId);
                    this.ActualizarGrilla();
                }
            }
            else
            {
                if (dgvReceta.SelectedRows.Count > 0)
                {
                    int recetaId = Convert.ToInt32(dgvReceta.SelectedRows[0].Cells["dgvReceta_id"].Value);
                    gestorReceta.DarDeAltaReceta(recetaId, usuarioLog.UsuarioId);
                    this.ActualizarGrilla();
                }
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGestionUsuarios gestionUsuarios = new frmGestionUsuarios(usuarioLog);
            gestionUsuarios.ShowDialog();
            this.Show();

        }

        private void btnMetricas_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMetricas metricas = new frmMetricas(usuarioLog);
            metricas.ShowDialog();
            this.Show();

        }

        private void dgvReceta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Receta receta = gestorReceta.ObtenerRecetaPorId(Convert.ToInt32(dgvReceta.Rows[e.RowIndex].Cells["dgvReceta_id"].Value));
            if (receta != null)
            {
                frmVerReceta frmVerReceta = new frmVerReceta(receta, usuarioLog);
                frmVerReceta.ShowDialog();
            }


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvReceta.SelectedRows.Count > 0)
            {
                int recetaId = Convert.ToInt32(dgvReceta.SelectedRows[0].Cells["dgvReceta_id"].Value);
                Receta receta = gestorReceta.ObtenerRecetaPorId(recetaId);
                if (receta != null)
                {
                    frmModificarReceta frmModificarReceta = new frmModificarReceta(receta, usuarioLog);
                    frmModificarReceta.ShowDialog();
                    if (frmModificarReceta.DialogResult == DialogResult.OK)
                    {
                        this.ActualizarGrilla();
                    }
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Receta> recetasExportar = gestorReceta.ObtenerTodasRecetasParaExportar();

                if (recetasExportar == null || recetasExportar.Count == 0)
                {
                    MessageBox.Show("No hay recetas para exportar.",
                                    "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                sfdExpotar.Title = "Seleccione la ubicación y el nombre del archivo JSON para exportar las recetas";
                sfdExpotar.Filter = "Archivos JSON|*.json";
                sfdExpotar.FileName = "recetas_exportadas.json";
                if (sfdExpotar.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string Destino = sfdExpotar.FileName;
                string mensaje;

                if (ControlJson.ExportarRecetasAJson(Destino, recetasExportar, out mensaje))
                {
                    MessageBox.Show($"Exportación completada.\n\n{mensaje}",
                                    "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Error al exportar.\n\n{mensaje}",
                                    "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                opfImportar.Title = "Seleccionar archivo de recetas JSON";
                opfImportar.Filter = "Archivos JSON (*.json)|*.json";
                opfImportar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (opfImportar.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string mensaje;
                List<Receta> recetasImportadas = ControlJson.ImportarRecetasDesdeJson(opfImportar.FileName, out mensaje);

                // Mostrar mensaje de resultado
                MessageBox.Show(mensaje, "Importación de Recetas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Guardar las recetas importadas en la base de datos
                if (recetasImportadas != null && recetasImportadas.Count > 0)
                {
                    List<Receta> recetas = new List<Receta>(recetasImportadas);
                    foreach (var receta in recetas)
                    {
                        List<int> ingredientesReceta = receta.Ingredientes.Select(i => i.IngredienteId).ToList();
                        gestorReceta.AgregarReceta(receta, ingredientesReceta);
                    }
                    MessageBox.Show($"Se importaron {recetas.Count} recetas correctamente.", "Importación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActualizarGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al importar recetas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }// Probar este evento cuando funcione todo



        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Seguro que querés cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                cierrePorSesion = true;

                // mostramos frmInicio
                frmInicio inicio = Application.OpenForms.OfType<frmInicio>().FirstOrDefault();
                if (inicio != null)
                {
                    Owner = inicio;
                    inicio.Show();
                }
                this.Close();

            }

        }

        private void frmMenuAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cierrePorSesion)
            {
                var resultado = MessageBox.Show("¿Seguro que querés salir?", "Salir", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {

                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true; // Cancela el cierre del formulario
                }
            }


        }

        // En tu formulario de administrador, asigna los tags:
        private void AsignarTagsBotones()
        {
            // Botones principales - color azul por defecto
            btnAgregar.Tag = "";
            btnModificar.Tag = "";
            btnEliminar.Tag = "";
            btnAct.Tag = "";

            // Botones especiales
            btnImportar.Tag = "importar";
            btnExportar.Tag = "exportar";
            btnUsuarios.Tag = "info"; // O el que prefieras
            btnMetricas.Tag = "metricas";
            btnCerrarSesion.Tag = "peligro";

            btnTema.Tag = "secundario";
        }

        private void btnTema_Click(object sender, EventArgs e)
        {
            ThemeManager.ToggleTheme();
            ThemeManager.ApplyTheme(this);

        }
        private void OnThemeChanged()
        {
            // Aplicar el nuevo tema a todos los controles
            ThemeManager.ApplyTheme(this);

            // Actualizar el texto del botón
            ActualizarBotonTema();

            // Opcional: Forzar redibujado para asegurar que todos los cambios se apliquen
            this.Refresh();

        }
        private void ActualizarBotonTema()
        {
            if (ThemeManager.IsDarkTheme)
            {
                btnTema.Text = "☀️ Cambiar a Claro";
                btnTema.Tag = "info"; // Puedes cambiar el tag si quieres otro color
            }
            else
            {
                btnTema.Text = "🌙 Cambiar a Oscuro";
                btnTema.Tag = "secundario";
            }

        }

        // Limpiar el evento cuando se cierre el formulario
        private void FormAdministrador_FormClosed(object sender, FormClosedEventArgs e)
        {
            ThemeManager.ThemeChanged -= OnThemeChanged;
        }
    }
}

