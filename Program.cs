using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Classes.Recetas;
using MicheBytesRecipes.Managers;
using System;
using MicheBytesRecipes.Forms.AddReceta;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
            //construit una receta
            Receta receta = new Receta
            {
                RecetaId = 1,
                Nombre = "Tacos al Pastor",
                PaisId = 1, // México
                CategoriaId = 1, // Comida Rápida
                UsuarioId = 1, // ID del usuario que creó la receta
                Descripcion = "Deliciosos tacos al pastor con piña y cilantro.",
                Instrucciones = "1. Marinar la carne...\n2. Asar la carne...\n3. Servir en tortillas...",
                ImagenReceta = null, // Aquí podrías cargar una imagen en formato byte[]
                TiempoPreparacion = new TimeSpan(0, 30, 0), // 30 minutos
                NivelDificultad = Dificultad.Media,
                FechaRegistro = DateTime.Now,
                FechaBaja = null,
                Ingredientes = new List<Ingrediente>
                {
                    new Ingrediente { IngredienteId = 1, Nombre = "Carne de cerdo" },
                    new Ingrediente { IngredienteId = 2, Nombre = "Piña" },
                    new Ingrediente { IngredienteId = 3, Nombre = "Cilantro"},
                    new Ingrediente { IngredienteId = 4, Nombre = "Tortillas"},
                    new Ingrediente { IngredienteId = 5, Nombre = "Salsa al gusto" }
                },

            };
            GestorUsuarios gestorUsuario = new GestorUsuarios();
            Usuario usuario = gestorUsuario.BuscarPorEmail("nehuenrivero@hotmail.com");


           







            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmHome());
            //Application.Run(new Inicio());
            //Application.Run(new frmLogin());
            //Application.Run(new frmMenuAdmin());
            Application.Run(new FrmVerReceta(receta, usuario));
            //Application.Run(new Forms.Auth.FrmRegister());
            //Application.Run(new Forms.Admin.frmBuscarUsuario());
            //Llamar al formulario verReceta
            


        }
    }
}
