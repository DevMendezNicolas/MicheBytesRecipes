using MicheBytesRecipes.Classes.Recetas;
using MicheBytesRecipes.Forms.AddReceta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Receta receta = new Receta
            {
                RecetaId = 1,
                Nombre = "Tacos al Pastor",
                PaisId = 2, // México
                CategoriaId = 1, // Comida Rápida
                UsuarioId = 1, // ID del usuario que creó la receta
                Descripcion = "Deliciosos tacos al pastor con piña y cilantro.",
                Instrucciones = "1. Marinar la carne...\n2. Asar la carne...\n3. Servir en tortillas...",
                ImagenReceta = null, // Aquí iría el arreglo de bytes de la imagen
                TiempoPreparacion = new TimeSpan(0, 30, 0), // 30 minutos
                NivelDificultad = Dificultad.Media,
                FechaRegistro = DateTime.Now,
                FechaBaja = null,
                Ingredientes = new List<Ingrediente>()
            };
            receta.Ingredientes.Add(new Ingrediente { Nombre = "Carne de cerdo", IngredienteId = 1 });
            receta.Ingredientes.Add(new Ingrediente { Nombre = "Tortillas de maíz", IngredienteId = 2 });
            receta.Ingredientes.Add(new Ingrediente { Nombre = "Piña", IngredienteId = 3 });
            receta.Ingredientes.Add(new Ingrediente { Nombre = "Cilantro", IngredienteId = 4 });
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //Application.Run(new frmHome());
            //Application.Run(new Inicio());
            //Application.Run(new frmLogin());
            //Application.Run(new FrmAgregarReceta());
            //Application.Run(new FrmAgregarPais());
            //Application.Run(new FrmAgregarIngrediente());
            //Application.Run(new PruebaImagen());
            Application.Run(new FrmVerReceta(receta));
        }
    }
}
