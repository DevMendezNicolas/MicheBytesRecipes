using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MicheBytesRecipes.Classes.Interacciones
{
    public class Metricas
    {
        public int recetaId { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int CantidadFavoritos { get; set; }
        public int CantidadComentarios { get; set; }
        public int CantidadLikes { get; set; }
        public int CantidadVisualizaciones { get; set; }
        public DateTime? fechaBaja { get; set; }

        public Metricas(int recetaId, string nombre, string categoria, int cantidadFavoritos, int cantidadComentarios, int cantidadLikes, int cantidadVisualizaciones, DateTime? fechaBaja)
        {
            this.recetaId = recetaId;
            Nombre = nombre;
            Categoria = categoria;
            CantidadFavoritos = cantidadFavoritos;
            CantidadComentarios = cantidadComentarios;
            CantidadLikes = cantidadLikes;
            CantidadVisualizaciones = cantidadVisualizaciones;
            this.fechaBaja = fechaBaja;
        }

        public string EstadoReceta()
        {
            if (fechaBaja == null)
            {
                return "Activa";
            }
            else
            {
                // Devuelve "Inactiva (Salto de linea) dd/MM/yyyy"
                return "Inactiva\n" + fechaBaja?.ToString("dd/MM/yyyy");
            }
        }
    }
}
