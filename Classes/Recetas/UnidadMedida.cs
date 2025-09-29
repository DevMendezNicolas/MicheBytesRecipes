using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicheBytesRecipes.Classes.Recetas
{
    internal class UnidadMedida
    {
        public int UnidadMedidaId { get; set; } // <- Esto es lo que va en el ValueMember del ComboBox
        public string Nombre { get; set; } // <- Esto es lo que va en el DisplayMember del ComboBox

        public UnidadMedida() { }
        public UnidadMedida(string nombre)
        {
            this.Nombre = nombre;
        }
        public override string ToString()
        {
            return Nombre;
        }
        public override bool Equals(object obj)
        {
            if (obj is UnidadMedida unidadMedida)
            {
                return this.UnidadMedidaId == unidadMedida.UnidadMedidaId;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.UnidadMedidaId.GetHashCode();
        }
    }
}
