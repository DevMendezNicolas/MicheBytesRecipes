using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MicheBytesRecipes.Helpers
{
    public static class ThemeManager
    {
        private static Theme currentTheme;
        private static bool isDarkMode = false;

        public static event Action ThemeChanged;

        public static void ToggleTheme()
        {
            isDarkMode = !isDarkMode;
            currentTheme = isDarkMode ? Themes.Dark : Themes.Light;
            ThemeChanged?.Invoke();
        }

        public static void ApplyTheme(Form form)
        {
            currentTheme = isDarkMode ? Themes.Dark : Themes.Light;

            form.BackColor = currentTheme.FondoPrincipal;
            form.ForeColor = currentTheme.TextoPrincipal;

            ApplyThemeToControls(form.Controls);
        }

        private static void ApplyThemeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // 🟦 Paneles
                if (control is Panel panel)
                {
                    panel.BackColor = currentTheme.Panel;
                    ApplyThemeToControls(panel.Controls);
                }

                // 🟧 Botones
                else if (control is Button boton)
                {
                    ApplyButtonTheme(boton);
                }

                // 🟩 Labels
                else if (control is Label label)
                {
                    label.ForeColor = currentTheme.TextoPrincipal;
                    label.BackColor = Color.Transparent;
                }

                // 🟨 ComboBox
                else if (control is ComboBox combo)
                {
                    combo.BackColor = currentTheme.BackgroundTextBox;
                    combo.ForeColor = currentTheme.TextoCajaTexto;
                    combo.FlatStyle = FlatStyle.Flat;
                }

                // 🟦 TextBox
                else if (control is TextBox txt)
                {
                    txt.BackColor = currentTheme.BackgroundTextBox;
                    txt.ForeColor = currentTheme.TextoCajaTexto;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }

                // 🟪 DataGridView
                else if (control is DataGridView dgv)
                {
                    ApplyDataGridViewTheme(dgv);
                }

                // Recursión para contenedores anidados
                if (control.HasChildren)
                    ApplyThemeToControls(control.Controls);
            }
        }

        private static void ApplyButtonTheme(Button boton)
        {
            boton.BackColor = currentTheme.BotonColorPorTag(boton.Tag?.ToString());

            // Contraste de texto automático
            if (ShouldUseDarkText(boton.BackColor))
            {
                boton.ForeColor = Color.Black;
            }
            else
            {
                boton.ForeColor = Color.White;
            }

            // Estilo de borde con color del tema
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 1;
            boton.FlatAppearance.BorderColor = currentTheme.TextoSecundario;
        }

        private static void ApplyDataGridViewTheme(DataGridView dgv)
        {
            dgv.BackgroundColor = currentTheme.Panel;
            dgv.GridColor = currentTheme.TextoSecundario;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = currentTheme.Botones;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = currentTheme.TextoBotones;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            dgv.DefaultCellStyle.BackColor = currentTheme.BackgroundTextBox;
            dgv.DefaultCellStyle.ForeColor = currentTheme.TextoCajaTexto;
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            if (isDarkMode)
            {
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            }
        }

        private static bool ShouldUseDarkText(Color backgroundColor)
        {
            // Calcular luminosidad para determinar contraste
            double luminance = (0.299 * backgroundColor.R + 0.587 * backgroundColor.G + 0.114 * backgroundColor.B) / 255;
            return luminance > 0.5; // Usar texto negro en fondos claros
        }

        public static Theme GetCurrentTheme() => currentTheme;
        public static bool IsDarkTheme => isDarkMode;
    }

    public class Theme
    {
        public Color FondoPrincipal { get; set; }
        public Color Panel { get; set; }
        public Color TextoPrincipal { get; set; }
        public Color TextoSecundario { get; set; }

        public Color Botones { get; set; }
        public Color TextoBotones { get; set; }
        public Color BotonPeligro { get; set; }
        public Color BotonExito { get; set; }
        public Color BotonAdvertencia { get; set; }
        public Color BotonSecundario { get; set; }
        public Color BotonInfo { get; set; }
        public Color BotonExportar { get; set; }
        public Color BotonImportar { get; set; }
        public Color BotonMetricas { get; set; }

        public Color BackgroundTextBox { get; set; }
        public Color TextoCajaTexto { get; set; }

        public Color BotonColorPorTag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
                return Botones;

            switch (tag.ToLowerInvariant())
            {
                case "peligro":
                case "danger":
                    return BotonPeligro;
                case "exito":
                case "success":
                    return BotonExito;
                case "advertencia":
                case "warning":
                    return BotonAdvertencia;
                case "secundario":
                case "secondary":
                    return BotonSecundario;
                case "info":
                    return BotonInfo;
                case "exportar":
                case "export":
                    return BotonExportar;
                case "importar":
                case "import":
                    return BotonImportar;
                case "metricas":
                case "metrics":
                    return BotonMetricas;
                default:
                    return Botones;
            }
        }
    }

    public static class Themes
    {
        public static readonly Theme Light = new Theme
        {
            FondoPrincipal = Color.FromArgb(0, 188, 212),  // Cyan
            Panel = Color.FromArgb(0, 171, 197),           // Cyan oscuro
            TextoPrincipal = Color.White,
            TextoSecundario = Color.FromArgb(240, 240, 240),

            Botones = Color.FromArgb(255, 160, 0),         // Naranja
            TextoBotones = Color.Black,

            BotonPeligro = Color.FromArgb(230, 57, 70),    // Rojo
            BotonExito = Color.FromArgb(46, 204, 113),     // Verde
            BotonAdvertencia = Color.FromArgb(255, 214, 10), // Amarillo
            BotonSecundario = Color.FromArgb(41, 128, 185), // Azul
            BotonInfo = Color.FromArgb(30, 144, 255),      // Azul info
            BotonExportar = Color.FromArgb(255, 214, 10),  // Amarillo
            BotonImportar = Color.FromArgb(255, 214, 10),  // Amarillo
            BotonMetricas = Color.FromArgb(46, 204, 113),  // Verde

            BackgroundTextBox = Color.White,
            TextoCajaTexto = Color.Black,
        };

        public static readonly Theme Dark = new Theme
        {
            FondoPrincipal = Color.FromArgb(30, 30, 45),   // Azul oscuro
            Panel = Color.FromArgb(45, 45, 60),
            TextoPrincipal = Color.White,
            TextoSecundario = Color.FromArgb(100, 100, 120),

            Botones = Color.FromArgb(255, 180, 0),         // Naranja más claro
            TextoBotones = Color.Black,

            BotonPeligro = Color.FromArgb(220, 80, 70),    // Rojo más vibrante
            BotonExito = Color.FromArgb(60, 220, 130),     // Verde más brillante
            BotonAdvertencia = Color.FromArgb(255, 230, 50), // Amarillo más brillante
            BotonSecundario = Color.FromArgb(70, 150, 210), // Azul más claro
            BotonInfo = Color.FromArgb(50, 170, 255),      // Azul info más brillante
            BotonExportar = Color.FromArgb(255, 230, 50),  // Amarillo
            BotonImportar = Color.FromArgb(255, 230, 50),  // Amarillo
            BotonMetricas = Color.FromArgb(60, 220, 130),  // Verde

            BackgroundTextBox = Color.FromArgb(50, 50, 65),
            TextoCajaTexto = Color.White,
        };
    }
}