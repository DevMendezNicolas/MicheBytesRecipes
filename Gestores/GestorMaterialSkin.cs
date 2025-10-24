using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Gestores
{
    public static class GestorMaterialSkin
    {
        /// <summary>
        /// Aplica un tema Claro con tonos Tierra/Pastel.
        /// Ideal para formularios de bienvenida o contenido principal brillante.
        /// </summary>
        /// <param name="form">El formulario MaterialForm a gestionar.</param>
        public static void TemaClaro(MaterialForm form)
        {
            var materialSkinManager = MaterialSkinManager.Instance;

            // Añadir el formulario al manager
            materialSkinManager.AddFormToManage(form);

            // Definir el Tema
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Esquema de Tonos Tierra Claros:
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Brown400,         // Barra principal de la ventana
                Primary.Brown500,         // Barra de notificaciones (más oscura)
                Primary.Brown100,         // Color de fondo del formulario (si no se sobreescribe)
                Accent.DeepOrange200,     // Color de acento para botones, checks, etc.
                TextShade.BLACK           // Texto en la barra superior
            );
        }


        /// <summary>
        /// Aplica un tema Oscuro con tonos Grisáceos y un acento Azul.
        /// Ideal para una interfaz de usuario moderna y de gestión de datos.
        /// </summary>
        /// <param name="form">El formulario MaterialForm a gestionar.</param>
        public static void TemaOscuro(MaterialForm form)
        {
            var materialSkinManager = MaterialSkinManager.Instance;

            // Añadir el formulario al manager
            materialSkinManager.AddFormToManage(form);

            // Definir el Tema
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK; // ⬅️ Tema Oscuro

            // Esquema de Grises y Azules:
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800,        // Fondo principal oscuro
                Primary.BlueGrey900,        // Barra de notificaciones (aún más oscura)
                Primary.BlueGrey500,        // Color de elementos claros
                Accent.LightBlue200,        // Color de acento brillante (azul claro)
                TextShade.WHITE             // Texto principal en la barra superior
            );
        }
    }
}
