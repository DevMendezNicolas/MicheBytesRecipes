using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicheBytesRecipes
{
 
    
        //Enum para definir la dificultad de la receta
        public enum Dificultad
        {
            Fácil,
            Media,
            Difícil
        }
        internal class Receta
        {
            //Propiedades de la clase receta
            public int RecetaId { get; set; }
            public string Nombre { get; set; }
            public int PaisId { get; set; }
            public int CategoriaId { get; set; }
            public int UsuarioId { get; set; }
            public string Descripcion { get; set; }
            public string Instrucciones { get; set; }
            public byte[] ImagenReceta { get; set; } //blob
            public TimeSpan TiempoPreparacion { get; set; }
            public Dificultad NivelDificultad { get; set; }
            public DateTime FechaRegistro { get; set; }
            public DateTime? FechaBaja { get; set; }

            public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();


            public Receta()
            {
                Ingredientes = new List<Ingrediente>();
            }
            //Constructor de la clase receta
            public Receta(string nombre, int regionId, int categoriaId, int usuarioId, string descripcion, string instrucciones, byte[] imagenReceta, TimeSpan tiempoPreparacion, Dificultad nivelDifultads)
            {

                this.Nombre = nombre;
                this.PaisId = regionId;
                this.CategoriaId = categoriaId;
                this.UsuarioId = usuarioId;
                this.Descripcion = descripcion;
                this.Instrucciones = instrucciones;
                this.ImagenReceta = imagenReceta;
                this.TiempoPreparacion = tiempoPreparacion;
                this.NivelDificultad = nivelDifultads;
                this.FechaRegistro = DateTime.Now;
                this.FechaBaja = null;
                this.Ingredientes = new List<Ingrediente>();
            }
            //Sobrescritura del metodo ToString para mostrar la informacion de la receta
            public override string ToString()
            {
                return $"{Nombre} - {Descripcion} - {NivelDificultad} - {TiempoPreparacion}";
            }
            //Sobrescritura del metodo equals y GetHashCode para comparar recetas por su id
            public override bool Equals(object obj)
            {
                if (obj is Receta receta)
                {
                    return this.RecetaId == receta.RecetaId;
                }
                return false;
            }
            public override int GetHashCode()
            {
                return this.RecetaId.GetHashCode();
            }

            //Mostrar la informacion completa de la receta
            public string InfoReceta()
            {
                return $"Receta: {Nombre}\nDescripción: {Descripcion}\nDificultad: {NivelDificultad}\nTiempo de Preparación: {TiempoPreparacion}\nInstrucciones: {Instrucciones}\nIngredientes: {string.Join(", ", Ingredientes.Select(i => i.Nombre))}";
            }

            //Metodos para dar alta y baja una receta
            public void DarDeBaja()
            {
                this.FechaBaja = DateTime.Now;
            }
            public void DarDeAlta()
            {
                this.FechaBaja = null;
            }

            //Validaciones y metodos adicionales    
            public void AgregarIngrediente(Ingrediente ingrediente)
            {
                if (!Ingredientes.Contains(ingrediente))
                {
                    Ingredientes.Add(ingrediente);
                }
            }
            public void EliminarIngrediente(Ingrediente ingrediente)
            {
                if (Ingredientes.Contains(ingrediente))
                {
                    Ingredientes.Remove(ingrediente);
                }
            }
            public bool EstaActivo()
            {
                return FechaBaja == null;

            }
            public bool ValidarDescripcion()
            {
                return !string.IsNullOrWhiteSpace(this.Descripcion) && this.Descripcion.Length <= 500;
            }

            //metodo para normalizar y comparar nombres de recetas
            public string NombreNormalizado()
            {
                return Nombre.Trim().ToLowerInvariant();
            }
            public bool EsIgualPorNombre(Receta otro)
            {
                return this.NombreNormalizado() == otro.NombreNormalizado();
            }
            //Metodo para calcular el tiempo que lleva registrada la receta
            public TimeSpan TiempoDeRegistro()
            {
                return DateTime.Now - FechaRegistro;
            }

            public Receta Clonar()
            {
                return new Receta(this.Nombre, this.PaisId, this.CategoriaId, this.UsuarioId, this.Descripcion, this.Instrucciones, this.ImagenReceta, this.TiempoPreparacion, this.NivelDificultad)
                {
                    Ingredientes = new List<Ingrediente>(Ingredientes.Select(i => i.Clonar()))
                };
            }

            //Metodo para exportar la receta como JSON (VER)
            /*public string ExportarComoJson()
            {
                return System.Text.Json.JsonSerializer.Serialize(this);
            }*/

        }
    }

