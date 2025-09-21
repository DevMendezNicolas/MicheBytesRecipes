using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicheBytesRecipes.Helpers
{
    public class Theme
    {
        /*Paleta de colores
         Fondo principal: Rgb(13,27,42) Azul oscuro
         Paneles: Rgb(27,38,59) Azul grisaceo
         Texto principal: Rgb(255,255,255) Blanco
         Texto secundario: Rgb(169,180,194) Gris claro
         Botones: Rgb(0,120,215) Azul claro
         Links: Rgb(77,168,218) Azul brillante
         Texto de botones: Rgb(255,255,255) Blanco
         Texto caja de texto : Rgb (0,0,0) Negro

         */

        //Colores de tema

        public Color FondoPrincipal { get; set; }
        public Color Panel { get; set; }
        public Color TextoPrincipal { get; set; }
        public Color TextoSecundario { get; set; }
        public Color Botones { get; set; }
        public Color Links { get; set; }
        public Color TextoBotones { get; set; }
        public Color TextoCajaTexto { get; set; }

        public Color BackgroundTextBox { get; set; }

        }
}
