using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicheBytesRecipes.Classes.Recetas
{
    internal class Pais
    {
        public int PaisId { get; set; }
        public string Nombre { get; set; }
        public Pais() { }
        public Pais(string nombre)
        {
            this.Nombre = nombre;
        }
        public override string ToString()
        {
            return Nombre;
        }
        public override bool Equals(object obj)
        {
            if(obj is Pais pais)
            {
                return this.PaisId == pais.PaisId;
            }return false;
        }
        public override int GetHashCode()
        {
            return this.PaisId.GetHashCode();
        }


    }
}
