using MicheBytesRecipes.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace MicheBytesRecipes.Classes.TarjetasRecetas
{
    public class TarjetaReceta
    {
        public int RecetaId { get; set; }
        public string NombreReceta { get; set; }
        public string CategoriaReceta { get; set; }
        public string PaisReceta { get; set; }
        public string TiempoReceta { get; set; }
        public string DificultadReceta { get; set; }
        public byte[] ImagenReceta { get; set; }

        public TarjetaReceta() { }

        // Constructor desde tu entidad Receta
        public TarjetaReceta(Receta receta, GestorCatalogo catalogo)
        {
            RecetaId = receta.RecetaId;
            NombreReceta = receta.Nombre;
            CategoriaReceta = catalogo.ObtenerCategoriaPorId(receta.CategoriaId)?.Nombre ?? "Desconocida";
            PaisReceta = catalogo.ObtenerPaisPorId(receta.PaisId)?.Nombre ?? "Desconocido";
            TiempoReceta = receta.TiempoPreparacion.ToString(@"hh\:mm");
            DificultadReceta = receta.NivelDificultad.ToString();

            // Asignar directamente la imagen de la receta (puede ser null)
            ImagenReceta = receta.ImagenReceta;
        }

    }
}
