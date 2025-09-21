using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Helpers
{
    public static class ThemeManager
    {
        private static readonly Theme DarkTheme = new Theme
        {
            FondoPrincipal = Color.FromArgb(13, 27, 42),
            Panel = Color.FromArgb(27, 38, 59),
            TextoPrincipal = Color.FromArgb(255, 255, 255),
            TextoSecundario = Color.FromArgb(169, 180, 194),
            Botones = Color.FromArgb(0, 120, 215),
            TextoBotones = Color.FromArgb(255, 255, 255),
            Links = Color.FromArgb(77, 168, 218),
            TextoCajaTexto = Color.FromArgb(0, 0, 0),
            BackgroundTextBox = Color.White
        };

        // Tema claro todavía sin definir
        private static readonly Theme LightTheme = new Theme
        {
            FondoPrincipal = Color.White,
            Panel = Color.LightGray,
            TextoPrincipal = Color.Black,
            TextoSecundario = Color.DarkGray,
            Botones = Color.FromArgb(0, 120, 215),
            TextoBotones = Color.White,
            Links = Color.Blue,
            TextoCajaTexto = Color.Black

        };

        private static bool isDark = true;
        public static Theme CurrentTheme { get; private set; } = DarkTheme;

        public static void ToggleTheme()
        {
            isDark = !isDark;
            CurrentTheme = isDark ? DarkTheme : LightTheme;
        }

        public static void ApplyTheme(Form form)
        {
            form.BackColor = CurrentTheme.FondoPrincipal;
            form.ForeColor = CurrentTheme.TextoPrincipal;

            foreach (Control c in form.Controls)
                ApplyControlTheme(c);
        }

        private static void ApplyControlTheme(Control c)
        {
            switch (c)
            {
                case Panel _:
                    c.BackColor = CurrentTheme.Panel;
                    break;
                case Button _:
                    c.BackColor = CurrentTheme.Botones;
                    c.ForeColor = CurrentTheme.TextoBotones;
                    break;
                case TextBox _:
                    c.BackColor = Color.White; // podés usar otro color si querés
                    c.ForeColor = CurrentTheme.TextoCajaTexto;
                    break;
                case Label _:
                    c.ForeColor = CurrentTheme.TextoPrincipal;
                    break;
            }

            foreach (Control child in c.Controls)
                ApplyControlTheme(child);
        }



    }
}
