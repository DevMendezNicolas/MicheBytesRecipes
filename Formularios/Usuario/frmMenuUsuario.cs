using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Classes.Recetas;
using MicheBytesRecipes.Forms.Admin;
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
    public partial class frmMenuUsuario : Form
    {
        GestorUsuarios gestorUsuarios = new GestorUsuarios();
        GestorCatalogo gestorCatalogo = new GestorCatalogo();
        GestorReceta gestorReceta = new GestorReceta();
        GestorTarjetasRecetas gestorTarjetas;
        private bool cierrePorSesion = false;
        private Usuario usuarioLog;
        private bool recetasActivas = true;
        private bool mostrarFavoritas = false;
        public frmMenuUsuario(Usuario usuarioActivado)
        {
            InitializeComponent();
            usuarioLog = usuarioActivado;
            CargarUsuario();
            gestorTarjetas = new GestorTarjetasRecetas(pnlTarjetas);
            GestorTemaUsuario.TemaCambiado += ActualizarTema;
            this.FormClosed += (s, e) => GestorTemaUsuario.TemaCambiado -= ActualizarTema;

        }

        private void CargarUsuario()
        {
            lblNombre.Text = $"Bienvenido, {usuarioLog.Nombre}";
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
            AsignarTags();
            GestorTemaUsuario.AplicarTema(this);
            ActualizarBotonTema();

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

            // --- Cargar las tarjetas al inicio ---
            recetasActivas = true;
            this.CargarRecetas();

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

        private void btnHistorialRecetas_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHistorial historial = new frmHistorial(usuarioLog);
            GestorTemaUsuario.AplicarTema(historial);
            GestorTemaUsuario.TemaCambiado += historial.ActualizarTema;
            historial.FormClosed += (s, args) => GestorTemaUsuario.TemaCambiado -= historial.ActualizarTema;
            historial.ShowDialog();
            this.Show();

        }

        private void btnReinicio_Click(object sender, EventArgs e)
        {
            cboCategoria.SelectedIndex = 0;
            cboDificultad.SelectedIndex = 0;
            cboPais.SelectedIndex = 0;
            txtBuscarReceta.Text = "";
            CueProvider.SetCue(txtBuscarReceta, "Ej: Fideos con tuco, Milanesa a la napolitana...");
            this.CargarRecetas();

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
                List<PreReceta> recetasFiltradas = gestorReceta.ObtenerPreRecetasFiltradas(nombre, paisId, categoriaId, dificultad, true);

                // Mostrar resultados en tarjetas
                gestorTarjetas.LimpiarTarjetas();

                gestorTarjetas.CargarTarjetas(recetasFiltradas, usuarioLog, gestorReceta, gestorCatalogo);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar recetas: " + ex.Message);
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
            this.CargarRecetas();

        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmConfiguracion configuracion = new frmConfiguracion(usuarioLog);
            GestorTemaUsuario.AplicarTema(configuracion);
            GestorTemaUsuario.TemaCambiado += configuracion.ActualizarTema;
            configuracion.FormClosed += (s, args) => GestorTemaUsuario.TemaCambiado -= configuracion.ActualizarTema;
            configuracion.ShowDialog();
            usuarioLog = gestorUsuarios.BuscarPorEmail(configuracion.nuevoLog);
            CargarUsuario();
            this.Show();


        }

        private void txtBuscarReceta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Seguro que querés cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                cierrePorSesion = true;

                frmInicio inicio = Application.OpenForms.OfType<frmInicio>().FirstOrDefault();
                if (inicio != null)
                {
                    Owner = inicio;
                    inicio.Show();
                }
                this.Close();

            }

        }

        private void MenuUser_FormClosing(object sender, FormClosingEventArgs e)
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
        private void AsignarTags()
        {

            lblTituloMichebyte.Tag = "titulo";
            pnlContenido.Tag = "opcional";
            pnlTarjetas.Tag = "opcional";
            lblBuscar.Tag = "relleno";
            lblCategoria.Tag = "relleno";
            lblPais.Tag = "relleno";
            lblDificultad.Tag = "relleno";

            btnCerrarSesion.Tag = "cerrar";
            btnConfig.Tag = "configuracion";
            btnReinicio.Tag = "reiniciar";
            btnBuscar.Tag = "buscar";
            btnHistorialFav.Tag = "favoritos";
            btnHistorialRecetas.Tag = "historial";

        }
        private void ActualizarBotonTema()
        {
            btnTema.Text = GestorTemaAdmin.EsTemaOscuro ? "☀️" : "🌙";
        }
        public void ActualizarTema()
        {
            // Cuando el tema cambia en cualquier parte, actualizar este formulario
            GestorTemaUsuario.AplicarTema(this);
            ActualizarBotonTema();
            this.Refresh();
        }

        private void btnTema_Click(object sender, EventArgs e)
        {
            GestorTemaUsuario.AlternarTema();
        }
    }
}
