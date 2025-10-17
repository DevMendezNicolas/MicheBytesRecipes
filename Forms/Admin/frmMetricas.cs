using MicheBytesRecipes.Classes;
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
using MicheBytesRecipes.Forms.Admin;
using MicheBytesRecipes.Managers;
using MicheBytesRecipes.Classes.Interacciones;
using MicheBytesRecipes.Utilities;

namespace MicheBytesRecipes.Forms.Admin
{
    public partial class frmMetricas : Form
    {
        private Usuario usuarioLog;
        GestorReceta gestorReceta = new GestorReceta();
        GestorDeMetricas gestorMetricas = new GestorDeMetricas();
        List<Metricas> listaMetricas = new List<Metricas>();
        bool activas = true;


        public frmMetricas(Usuario usuarioActivado)
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

        public void ActualizarGrilla()
        {
            dgvMetricas.Rows.Clear();
            listaMetricas = activas ? gestorMetricas.ObtenerMetricasActivas() : gestorMetricas.ObtenerMetricasInactivas();
            foreach (var metrica in listaMetricas)
            {
                if (cboCategoria.SelectedIndex == 0 || metrica.Categoria == cboCategoria.Text) // Si está seleccionada "Todas" o coincide con la categoría seleccionada
                {
                    dgvMetricas.Rows.Add(metrica.recetaId, metrica.Nombre, metrica.Categoria, metrica.CantidadFavoritos, metrica.CantidadComentarios, metrica.CantidadLikes, metrica.CantidadVisualizaciones, metrica.EstadoReceta());
                }
            }

        }
        private void Metricas_Load(object sender, EventArgs e)
        {
            List<Categoria>categorias = gestorReceta.ObtenerListaCategorias();
            categorias.Insert(0, new Categoria { CategoriaId = 0, Nombre = "Todas" });
            cboCategoria.DataSource = categorias;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "CategoriaId";
            cboCategoria.SelectedIndex = 0;

            ActualizarGrilla();
            btnAct.Text = activas ? "Ver Inactivas" : "Ver Activas";
            activas = false;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAct_Click(object sender, EventArgs e)
        {
            dgvMetricas.Rows.Clear();
            listaMetricas = activas ? gestorMetricas.ObtenerMetricasActivas() : gestorMetricas.ObtenerMetricasInactivas();
            foreach (var metrica in listaMetricas)
            {
                if (cboCategoria.SelectedIndex == 0 || metrica.Categoria == cboCategoria.Text) // Si está seleccionada "Todas" o coincide con la categoría seleccionada
                {
                    dgvMetricas.Rows.Add(metrica.recetaId, metrica.Nombre, metrica.Categoria, metrica.CantidadFavoritos, metrica.CantidadComentarios, metrica.CantidadLikes, metrica.CantidadVisualizaciones, metrica.EstadoReceta());
                }
            }
            activas = !activas;
            btnAct.Text = activas ? "Ver Activas" : "Ver Inactivas";

        }

        private void btnReinicio_Click(object sender, EventArgs e)
        {
            activas = true;
            cboCategoria.SelectedIndex = 0;
            ActualizarGrilla();
            btnAct.Text = "Ver Inactivas";
        }

        private void frmMetricas_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Metricas> listaFiltrada = new List<Metricas>();
            // filtar por cboCategoria
            if (cboCategoria.SelectedIndex == 0)
            {
                if(!string.IsNullOrWhiteSpace(txtBuscarReceta.Text.Trim()))
                {
                    dgvMetricas.Rows.Clear();
                    listaFiltrada = activas ? gestorMetricas.ObtenerMetricasActivas().FindAll(m => m.Nombre.IndexOf(txtBuscarReceta.Text.Trim(), StringComparison.OrdinalIgnoreCase) >= 0) : gestorMetricas.ObtenerMetricasInactivas().FindAll(m => m.Nombre.IndexOf(txtBuscarReceta.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                    foreach (var metrica in listaFiltrada)
                    {
                        dgvMetricas.Rows.Add(metrica.recetaId, metrica.Nombre, metrica.Categoria, metrica.CantidadFavoritos, metrica.CantidadComentarios, metrica.CantidadLikes, metrica.CantidadVisualizaciones, metrica.EstadoReceta());
                    }
                }
                else
                {
                    this.ActualizarGrilla();
                }
                    
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtBuscarReceta.Text.Trim()))
                {
                    dgvMetricas.Rows.Clear();
                    listaFiltrada = activas ? gestorMetricas.ObtenerMetricasActivas().FindAll(m => m.Nombre.IndexOf(txtBuscarReceta.Text.Trim(), StringComparison.OrdinalIgnoreCase) >= 0 && m.Categoria == cboCategoria.Text) : gestorMetricas.ObtenerMetricasInactivas().FindAll(m => m.Nombre.IndexOf(txtBuscarReceta.Text.Trim(), StringComparison.OrdinalIgnoreCase) >= 0 && m.Categoria == cboCategoria.Text);
                    foreach (var metrica in listaFiltrada)
                    {
                        dgvMetricas.Rows.Add(metrica.recetaId, metrica.Nombre, metrica.Categoria, metrica.CantidadFavoritos, metrica.CantidadComentarios, metrica.CantidadLikes, metrica.CantidadVisualizaciones, metrica.EstadoReceta());
                    }
                }
                else
                {
                    dgvMetricas.Rows.Clear();
                    listaFiltrada = activas ? gestorMetricas.ObtenerMetricasActivas().FindAll(m => m.Categoria == cboCategoria.Text) : gestorMetricas.ObtenerMetricasInactivas().FindAll(m => m.Categoria == cboCategoria.Text);
                    foreach (var metrica in listaFiltrada)
                    {
                        dgvMetricas.Rows.Add(metrica.recetaId, metrica.Nombre, metrica.Categoria, metrica.CantidadFavoritos, metrica.CantidadComentarios, metrica.CantidadLikes, metrica.CantidadVisualizaciones, metrica.EstadoReceta());
                    }
                }
                    
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            GeneradorPdf.ExportarPDF(dgvMetricas, "Métricas de Recetas");
        }
    }
}
