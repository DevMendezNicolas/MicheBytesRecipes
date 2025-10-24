using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Classes.Recetas;
using MicheBytesRecipes.Classes.TarjetasRecetas;
using MicheBytesRecipes.Forms.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Managers
{
    public class GestorTarjetasRecetas
    {
        FlowLayoutPanel panelContenedor;
        List<ucRecetaTarjeta> tarjetas;

        public GestorTarjetasRecetas(FlowLayoutPanel panelContenedor)
        {
            this.panelContenedor = panelContenedor;
            this.tarjetas = new List<ucRecetaTarjeta>();
        }

        // Metodo para cargar tarjetas desde PreRecetas
        public void CargarTarjetas(List<PreReceta> preRecetas, Usuario usuarioLog,
                                  GestorReceta gestorReceta, GestorCatalogo catalogo)
        {
            LimpiarTarjetas();

            if (preRecetas == null || !preRecetas.Any())
            {
                MostrarMensajeVacio("No se encontraron recetas.");
                return;
            }

            foreach (var preReceta in preRecetas)
            {
                var recetaCompleta = gestorReceta.ObtenerRecetaPorId(preReceta.RecetaId);
                if (recetaCompleta != null)
                {
                    CrearYAgregarTarjeta(recetaCompleta, usuarioLog, gestorReceta, catalogo);
                }
            }
        }

        private void CrearYAgregarTarjeta(Receta receta, Usuario usuarioLog,
                                        GestorReceta gestorReceta, GestorCatalogo catalogo)
        {
            var tarjeta = new ucRecetaTarjeta
            {
                RecetaId = receta.RecetaId,
                NombreReceta = receta.Nombre,
                CategoriaReceta = catalogo.ObtenerCategoriaPorId(receta.CategoriaId)?.Nombre ?? "Desconocida",
                PaisReceta = catalogo.ObtenerPaisPorId(receta.PaisId)?.Nombre ?? "Desconocido",
                TiempoReceta = receta.TiempoPreparacion.ToString(@"hh\:mm"),
                DificultadReceta = receta.NivelDificultad.ToString(),
                ImagenReceta = receta.ImagenReceta,
                Visible = true
            };

            // Configurar el evento de clic
            tarjeta.VerDetallesClick += (s, e) =>
            {
                var recetaCompleta = gestorReceta.ObtenerRecetaPorId(receta.RecetaId);
                if (recetaCompleta != null)
                {
                    var verRecetaForm = new frmVerReceta(recetaCompleta, usuarioLog);
                    verRecetaForm.ShowDialog();
                }
            };

            tarjetas.Add(tarjeta);
            panelContenedor.Controls.Add(tarjeta);
        }

        // Ordenar por nombre
        public void OrdenarPorNombre(bool ascendente = true)
        {
            var tarjetasOrdenadas = ascendente
                ? tarjetas.OrderBy(t => t.NombreReceta).ToList()
                : tarjetas.OrderByDescending(t => t.NombreReceta).ToList();

            ReorganizarTarjetasEnPanel(tarjetasOrdenadas);
        }

        private void ReorganizarTarjetasEnPanel(List<ucRecetaTarjeta> tarjetasOrdenadas)
        {
            panelContenedor.SuspendLayout();
            panelContenedor.Controls.Clear();
            panelContenedor.Controls.AddRange(tarjetasOrdenadas.ToArray());
            panelContenedor.ResumeLayout();
        }

        private void MostrarMensajeVacio(string mensaje)
        {
            var lblVacio = new Label
            {
                Text = mensaje,
                AutoSize = true,
                ForeColor = System.Drawing.Color.Gray,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Italic),
                Margin = new Padding(10)
            };
            panelContenedor.Controls.Add(lblVacio);
        }

        public void MostrarTodasLasTarjetas()
        {
            foreach (var tarjeta in tarjetas)
            {
                tarjeta.Visible = true;
            }
        }

        public void LimpiarTarjetas()
        {
            foreach (var tarjeta in tarjetas)
            {
                tarjeta.Dispose();
            }

            tarjetas.Clear();
            panelContenedor.Controls.Clear();
        }
    }
}
