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
    }
}
