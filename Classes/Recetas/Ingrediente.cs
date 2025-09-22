using System;

namespace MicheBytesRecipes.Classes.Recetas
{
    public enum UnidadMedida
    {
        Gramos = 0,
        Mililitros = 1,
        Tazas = 2,
        Cucharadas = 3,
        Cucharaditas = 4,
        Unidades = 5
    }
    //Enum para definir el origen del ingrediente
    public enum Origen
    {
        Animal,
        Vegetal
    }
    internal class Ingrediente
    {

        //Propiedades de la clase Ingrediente
        public int IngredienteId { get; set; }
        public string Nombre { get; set; }
        //public decimal Cantidad { get; set; }
        public UnidadMedida Unidad { get; set; }
        public Origen TipoOrigen { get; set; }

        //Constructor de la clase Ingrediente
        public Ingrediente(){}
        public Ingrediente(string nombre, UnidadMedida unidad, Origen tipoOrigen)
        {
            this.Nombre = nombre;
            //this.Cantidad = cantidad;
            this.Unidad = unidad;
            this.TipoOrigen = tipoOrigen;
        }

        //Sobrescritura del metodo ToString para mostrar datos del ingrediente
        public override string ToString()
        {
            return $"{Nombre} ({Unidad}, {TipoOrigen})";
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
        /*public bool ValidarCantidad()
        {
            return Cantidad > 0 && Cantidad <= 10000;
        }*/
        public bool ValidarUnidad()
        {
            return Enum.IsDefined(typeof(UnidadMedida), Unidad);
        }
        public bool ValidarOrigen()
        {
            return Enum.IsDefined(typeof(Origen), TipoOrigen);
        }
        // Metodo para validar que el ingrediente es valido
        public bool EsValido()
        {
            return ValidarNombre() && ValidarUnidad() && ValidarOrigen();
        }

        // Metodo para obtener el detalle del ingrediente
        public string Detalle()
        {
            return $"{Unidad} de {Nombre} ({TipoOrigen})";
        }
        public Ingrediente Clonar()
        {
            return new Ingrediente(this.Nombre, this.Unidad, this.TipoOrigen);
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
