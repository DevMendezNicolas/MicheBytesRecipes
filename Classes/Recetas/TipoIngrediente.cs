using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicheBytesRecipes
{
    internal class TipoIngrediente
    {
        public int TipoIngredienteId { get; set; }
        public string Nombre { get; set; }
        public TipoIngrediente() { }
        public TipoIngrediente(string nombre)
        {
            this.Nombre = nombre;
        }
        public override string ToString()
        {
            return Nombre;
        }
        public override bool Equals(object obj)
        {
            if (obj is TipoIngrediente tipoIngrediente)
            {
                return this.TipoIngredienteId == tipoIngrediente.TipoIngredienteId;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.TipoIngredienteId.GetHashCode();
        }
    }
}
