using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicheBytesRecipes.Classes.Recetas
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public String Descripcion { get; set; }
        public Categoria() { }
        public Categoria(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }
        public override string ToString()
        {
            return $"{Nombre}, {Descripcion}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Categoria categoria)
            {
                return this.CategoriaId == categoria.CategoriaId;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.CategoriaId.GetHashCode();
        }
    }
}
