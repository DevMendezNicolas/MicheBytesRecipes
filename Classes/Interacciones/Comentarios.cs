using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicheBytesRecipes.Classes.Interacciones
{
    public class Comentarios
    {
        public int ComentarioId { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaComentario { get; set; }
        public DateTime? FechaBorrado { get; set; } // Nullable para permitir comentarios no borrados
        public int RecetaId { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }

        public Comentarios() { }
        public Comentarios(string descripcion, DateTime fechaComentario, DateTime fechaBorrado, int recetaId, int usuarioId)
        {
            this.Descripcion = descripcion;
            this.FechaComentario = fechaComentario;
            this.FechaBorrado = null; // Inicialmente no está borrado
            this.RecetaId = recetaId;
            this.UsuarioId = usuarioId;
        }
        public override bool Equals(object obj)
        {
            if(obj is Comentarios comentarios)
            {
                return this.ComentarioId == comentarios.ComentarioId;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.ComentarioId.GetHashCode();
        }
        public override string ToString()
        {
            return $"{Descripcion} (Usuario ID: {UsuarioId}, Receta ID: {RecetaId}, Fecha: {FechaComentario})";
        }

    }
}
