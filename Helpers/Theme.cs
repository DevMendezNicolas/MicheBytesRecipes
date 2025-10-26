using System;
using System.Drawing;
using System.Windows.Forms;

namespace MicheBytesRecipes.Helpers
{
    public static class ThemeManager
    {
        private static bool isDark = false;

        // Tema Claro
        private static readonly Theme LightTheme = new Theme
        {
            PanelPrimario = Color.FromArgb(0, 192, 192),           // Panel por defecto
            PanelSecundario = Color.FromArgb(230, 230, 230), // Panel secundario

            TextoPrincipal = Color.FromArgb(255, 255, 255),
            Botones = Color.FromArgb(255, 165, 0),
            TextoBotones = Color.White,
            BackgroundTextBox = Color.White,
            TextoCajaTexto = Color.Black,

            // Botones especiales
            BotonPeligro = Color.FromArgb(255, 0, 0),
            BotonExportar = Color.FromArgb(255, 215, 0),
            BotonImportar = Color.FromArgb(255, 215, 0),
            BotonInfo = Color.FromArgb(124, 252, 0),
            BotonMetricas = Color.FromArgb(50, 205, 50),
            BotonBuscar = Color.White,
            BotonReiniciar = Color.White,

        };

        // Tema Oscuro
        private static readonly Theme DarkTheme = new Theme
        {
            PanelPrimario = Color.FromArgb(45, 45, 45),              // Panel por defecto
            PanelSecundario = Color.FromArgb(55, 55, 55),    // Panel secundario
            TextoPrincipal = Color.FromArgb(240, 240, 240),
            Botones = Color.FromArgb(65, 130, 210),
            TextoBotones = Color.White,
            BackgroundTextBox = Color.FromArgb(60, 60, 60),
            TextoCajaTexto = Color.White,

            // Botones especiales
            BotonPeligro = Color.FromArgb(200, 70, 50),
            BotonExportar = Color.FromArgb(130, 85, 160),
            BotonImportar = Color.FromArgb(220, 130, 50),
            BotonInfo = Color.FromArgb(20, 140, 160),
            BotonMetricas = Color.FromArgb(70, 175, 120)
        };

        public static Theme CurrentTheme => isDark ? DarkTheme : LightTheme;
        public static bool IsDarkTheme => isDark;

        public static void ToggleTheme()
        {
            isDark = !isDark;
        }

        public static void ApplyTheme(Form form)
        {
            ApplyThemeToControlAndChildren(form);
        }

        private static void ApplyThemeToControlAndChildren(Control parent)
        {
            // Aplicar tema al control padre
            ApplyThemeToControl(parent);

            // Aplicar recursivamente a todos los hijos
            foreach (Control child in parent.Controls)
            {
                ApplyThemeToControlAndChildren(child);
            }
        }

        private static void ApplyThemeToControl(Control control)
        {
            // 🎨 PANELES CON TAGS ESPECÍFICOS
            if (control is Panel || control is GroupBox || control is TabPage)
            {
                ApplyThemeToPanel(control);
            }

            // Form
            else if (control is Form)
            {
                control.BackColor = CurrentTheme.FondoPrincipal;
                control.ForeColor = CurrentTheme.TextoPrincipal;
            }

            // Texto (Label, LinkLabel, etc.)
            else if (control is Label || control is LinkLabel)
            {
                control.ForeColor = CurrentTheme.TextoPrincipal;
                control.BackColor = Color.Transparent;
            }

            // Botones
            else if (control is Button)
            {
                ApplyThemeToButton((Button)control);
            }

            // Cajas de texto
            else if (control is TextBox || control is RichTextBox)
            {
                control.BackColor = CurrentTheme.BackgroundTextBox;
                control.ForeColor = CurrentTheme.TextoCajaTexto;
            }

            // Listas y combos
            else if (control is ComboBox || control is ListBox || control is CheckedListBox)
            {
                control.BackColor = CurrentTheme.BackgroundTextBox;
                control.ForeColor = CurrentTheme.TextoCajaTexto;
            }

            // CheckBox y RadioButton
            else if (control is CheckBox || control is RadioButton)
            {
                control.ForeColor = CurrentTheme.TextoPrincipal;
                control.BackColor = Color.Transparent;
            }

            // DataGridView
            else if (control is DataGridView)
            {
                ApplyThemeToDataGridView((DataGridView)control);
            }
        }

        private static void ApplyThemeToPanel(Control panel)
        {
            var tag = panel.Tag?.ToString()?.ToLower();
            Color backColor = CurrentTheme.PanelPrimario; // Por defecto

            if (!string.IsNullOrEmpty(tag))
            {
                switch (tag)
                {
                    case "secundario":
                        backColor = CurrentTheme.PanelSecundario;
                        break;
                }
            }

            panel.BackColor = backColor;
            panel.ForeColor = CurrentTheme.TextoPrincipal;
        }

        private static void ApplyThemeToButton(Button button)
        {
            // Color según el Tag
            var tag = button.Tag?.ToString()?.ToLower();
            Color backColor = CurrentTheme.Botones; // Por defecto

            if (!string.IsNullOrEmpty(tag))
            {
                switch (tag)
                {
                    case "peligro":
                        backColor = CurrentTheme.BotonPeligro;
                        break;
                    case "exportar":
                        backColor = CurrentTheme.BotonExportar;
                        break;
                    case "importar":
                        backColor = CurrentTheme.BotonImportar;
                        break;
                    case "info":
                        backColor = CurrentTheme.BotonInfo;
                        break;
                    case "metricas":
                        backColor = CurrentTheme.BotonMetricas;
                        break;
                    case "buscar":
                        backColor = CurrentTheme.BotonBuscar;
                        break;
                    case "reiniciar":
                        backColor = CurrentTheme.BotonReiniciar;
                        break;
                }
            }

            button.BackColor = backColor;
            button.ForeColor = CurrentTheme.TextoBotones;
            button.FlatStyle = FlatStyle.Standard;
            button.FlatAppearance.BorderSize = 1;
        }

        private static void ApplyThemeToDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = CurrentTheme.PanelPrimario;
            dgv.DefaultCellStyle.BackColor = CurrentTheme.BackgroundTextBox;
            dgv.DefaultCellStyle.ForeColor = CurrentTheme.TextoCajaTexto;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = CurrentTheme.Botones;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = CurrentTheme.TextoBotones;
            dgv.EnableHeadersVisualStyles = false;
        }
    }

    public class Theme
    {
        public Color FondoPrincipal { get; set; }
        public Color PanelPrimario { get; set; }                    // Panel por defecto
        public Color PanelSecundario { get; set; }          // Panel secundario

        public Color TextoPrincipal { get; set; }
        public Color Botones { get; set; }
        public Color TextoBotones { get; set; }
        public Color BackgroundTextBox { get; set; }
        public Color TextoCajaTexto { get; set; }

        // Botones especiales
        public Color BotonPeligro { get; set; }
        public Color BotonExportar { get; set; }
        public Color BotonImportar { get; set; }
        public Color BotonInfo { get; set; }
        public Color BotonMetricas { get; set; }

        public Color BotonReiniciar { get; set; }

        public Color BotonBuscar { get; set; }
    }
}