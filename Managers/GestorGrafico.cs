using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; //Para usar colores

namespace MicheBytesRecipes.Helpers
{
    public static class GestorGrafico
    {
        private static readonly MaterialSkinManager materialSkinInstance = MaterialSkinManager.Instance;

        public static void AplicarTema(MaterialForm form)
        {
            materialSkinInstance.AddFormToManage(form);
            materialSkinInstance.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinInstance.ColorScheme = new ColorScheme(
                Primary.Brown400,
                Primary.Brown500,
                Primary.Brown200,

                Accent.LightGreen700,

                TextShade.WHITE
                );
        }

    }
}
