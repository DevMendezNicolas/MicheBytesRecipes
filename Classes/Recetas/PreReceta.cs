using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicheBytesRecipes.Classes.Recetas
{
    public class PreReceta
    {
        public int RecetaId { get; set; }
        public string Nombre { get; set; }
        public int PaisId { get; set; }
        public int CategoriaId { get; set; }
        public Dificultad Dificultad { get; set; }
        public TimeSpan TiempoPreparacion { get; set; } = TimeSpan.Zero;

        public PreReceta(int recetaId, string nombre, int paisId, int categoriaId, Dificultad dificultad, TimeSpan tiempoPreparacion)
        {
            RecetaId = recetaId;
            Nombre = nombre;
            PaisId = paisId;
            CategoriaId = categoriaId;
            Dificultad = dificultad;
            TiempoPreparacion = tiempoPreparacion;
        }
        // toString override en orden nombre, categoria, pais, dificultad, tiempo preparacion
        public override string ToString()
        {
            return $"Receta ID: {RecetaId} Nombre: {Nombre} - Categoria ID: {CategoriaId}, Pais ID: {PaisId}, Dificultad: {Dificultad}, Tiempo Preparacion: {TiempoPreparacion}";
        }
    }
}
