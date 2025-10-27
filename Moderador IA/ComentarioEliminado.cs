using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicheBytesRecipes.Moderador_IA
{
    public class ComentarioEliminado
    {
        public string IdUsuario { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaEliminacion { get; set; }
        public string Razon { get; set; }
        public double PuntuacionToxicidad { get; set; }

        public ComentarioEliminado(string idUsuario, string comentario, string razon, double puntuacion)
        {
            IdUsuario = idUsuario;
            Comentario = comentario;
            FechaEliminacion = DateTime.Now;
            Razon = razon;
            PuntuacionToxicidad = puntuacion;
        }

        public ComentarioEliminado() { }
    }
}
