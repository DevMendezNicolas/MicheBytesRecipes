using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MicheBytesRecipes.Classes;

namespace MicheBytesRecipes
{
    public class Ingrediente
    {

        //Propiedades de la clase Ingrediente
        public int IngredienteId { get; set; }
        public string Nombre { get; set; }
        public UnidadMedida Unidad { get; set; } //Creo una propiedad de tipo UnidadMedida
        public TipoIngrediente Tipo { get; set; } //Creo una propiedad de tipo TipoIngrediente

        public Ingrediente(){}
        public Ingrediente(string nombre)
        {
            this.Nombre = nombre;

        }

        //Sobrescritura del metodo ToString para mostrar datos del ingrediente
        public override string ToString()
        {
            return $"{Nombre} ({Unidad?.Nombre}, {Tipo?.Nombre})";
            //Esto permite que los combos muestren el nombre y no tengamos que castear
            //El operador ?. se usa para evitar excepciones si Unidad o Tipo son null

        }

        //Sobrescritura del metodo equals y GetHashCode para comparar ingredientes por su id
        public override bool Equals(object obj)
        {
            if (obj is Ingrediente ingrediente)
            {
                return this.IngredienteId == ingrediente.IngredienteId;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.IngredienteId.GetHashCode();
        }

        //Validaciones y metodos adicionales
        public bool ValidarNombre()
        {
            return !string.IsNullOrWhiteSpace(Nombre) && Nombre.Length <= 100;
        }
        public Ingrediente Clonar()
        {
            return new Ingrediente(this.Nombre);
        } //Consultar aca

        //Metodo para normalizar y comparar nombres de ingredientes
        public string NombreNormalizado()
        {
            return Nombre.Trim().ToLowerInvariant();
        }
        public bool EsIgualPorNombre(Ingrediente otro)
        {
            return this.NombreNormalizado() == otro.NombreNormalizado();
        }

    }
}
