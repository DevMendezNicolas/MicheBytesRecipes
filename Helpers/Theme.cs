using System;
using System.Drawing;
using System.Windows.Forms;

namespace MicheBytesRecipes.Helpers
{
    public static class ThemeManager
    {
        private static bool isDark = false;

        // Evento para notificar a TODOS los formularios cuando cambia el tema
        public static event Action ThemeChanged;

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
            TextoBotonPanel2 = Color.FromArgb(32, 178, 170),

            // Botones especiales
            BotonCerrar = Color.FromArgb(255, 0, 0),
            BotonExportar = Color.FromArgb(255, 215, 0),
            BotonImportar = Color.FromArgb(255, 215, 0),
            BotonUsuario = Color.FromArgb(124, 252, 0),
            BotonMetricas = Color.FromArgb(50, 205, 50),
            BotonBuscar = Color.White,
            BotonReiniciar = Color.White,
            BotonAltas = Color.FromArgb(255, 128, 0),
            BotonMenu = Color.FromArgb(255, 128, 128),
            BotonRol = Color.FromArgb(128, 128, 255),
            BotonTema = Color.FromArgb(41, 128, 185),

            //Colores grid
            // NUEVOS: Colores específicos para DataGridView
            GridFondo = Color.FromArgb(240, 240, 240),
            GridCeldasFondo = Color.White,
            GridCeldasTexto = Color.Black,
            GridEncabezadosFondo = Color.FromArgb(255, 165, 0),
            GridEncabezadosTexto = Color.White,
            GridLineas = Color.FromArgb(200, 200, 200),
            GridSeleccionFondo = Color.FromArgb(65, 130, 210),   // AZUL para selección
            GridSeleccionTexto = Color.White,


        };

        // Tema Oscuro
        private static readonly Theme DarkTheme = new Theme
        {
            PanelPrimario = Color.FromArgb(45, 45, 45),              // Panel por defecto
            PanelSecundario = Color.FromArgb(55, 55, 55),
            TextoPrincipal = Color.FromArgb(240, 240, 240),
            Botones = Color.FromArgb(65, 130, 210),
            TextoBotones = Color.White,
            BackgroundTextBox = Color.White,
            TextoCajaTexto = Color.White,
            TextoBotonPanel2 = Color.White,

            // Botones especiales
            BotonCerrar = Color.FromArgb(200, 70, 50),
            BotonExportar = Color.FromArgb(220, 130, 50),
            BotonImportar = Color.FromArgb(220, 130, 50),
            BotonUsuario = Color.FromArgb(20, 140, 160),
            BotonMetricas = Color.FromArgb(70, 175, 120),
            BotonBuscar = Color.FromArgb(70, 70, 70),
            BotonReiniciar = Color.FromArgb(70, 70, 70),
            BotonAltas = Color.FromArgb(180, 90, 0),
            BotonMenu = Color.FromArgb(180, 80, 80),
            BotonRol = Color.FromArgb(130, 85, 160),
            BotonTema = Color.FromArgb(52, 152, 219),

            //Colores grid
            GridFondo = Color.FromArgb(45, 45, 45),
            GridCeldasFondo = Color.FromArgb(60, 60, 60),
            GridCeldasTexto = Color.FromArgb(240, 240, 240),
            GridEncabezadosFondo = Color.FromArgb(65, 130, 210),
            GridEncabezadosTexto = Color.White,
            GridLineas = Color.FromArgb(80, 80, 80),
            GridSeleccionFondo = Color.FromArgb(255, 165, 0),
            GridSeleccionTexto = Color.Black,

        };

        public static Theme CurrentTheme => isDark ? DarkTheme : LightTheme;
        public static bool IsDarkTheme => isDark;

        public static void ToggleTheme()
        {
            isDark = !isDark;
            //Notificar a TODOS los formularios que el tema cambió
            ThemeChanged?.Invoke();
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
                        backColor = CurrentTheme.BotonCerrar;
                        button.ForeColor = CurrentTheme.TextoBotones;
                        break;
                    case "exportar":
                        backColor = CurrentTheme.BotonExportar;
                        button.ForeColor = CurrentTheme.TextoBotones;
                        break;
                    case "importar":
                        backColor = CurrentTheme.BotonImportar;
                        button.ForeColor = CurrentTheme.TextoBotones;
                        break;
                    case "info":
                        backColor = CurrentTheme.BotonUsuario;
                        button.ForeColor = CurrentTheme.TextoBotones;
                        break;
                    case "metricas":
                        backColor = CurrentTheme.BotonMetricas;
                        button.ForeColor = CurrentTheme.TextoBotones;
                        break;
                    case "buscar":
                        backColor = CurrentTheme.BotonBuscar;
                        button.ForeColor = CurrentTheme.TextoBotonPanel2;
                        break;
                    case "reiniciar":
                        backColor = CurrentTheme.BotonReiniciar;
                        button.ForeColor = CurrentTheme.TextoBotonPanel2;
                        break;
                    case "alta":
                        backColor = CurrentTheme.BotonAltas;
                        button.ForeColor = CurrentTheme.TextoBotones;
                        break;
                    case "menu":
                        backColor = CurrentTheme.BotonMenu;
                        button.ForeColor = CurrentTheme.TextoBotones;
                        break;
                    case "rol":
                        backColor = CurrentTheme.BotonRol;
                        button.ForeColor = CurrentTheme.TextoBotones;
                        break;
                    case "tema":
                        backColor = CurrentTheme.BotonTema;
                        break;
                }
            }

            button.BackColor = backColor;
            button.FlatStyle = FlatStyle.Standard;
            button.FlatAppearance.BorderSize = 1;
        }

        private static void ApplyThemeToDataGridView(DataGridView dgv)
        {
            // Configuración completa del DataGridView
            dgv.BackgroundColor = CurrentTheme.GridFondo;
            dgv.GridColor = CurrentTheme.GridLineas;

            // Estilo de las celdas normales
            dgv.DefaultCellStyle.BackColor = CurrentTheme.GridCeldasFondo;
            dgv.DefaultCellStyle.ForeColor = CurrentTheme.GridCeldasTexto;
            dgv.DefaultCellStyle.SelectionBackColor = CurrentTheme.GridSeleccionFondo;
            dgv.DefaultCellStyle.SelectionForeColor = CurrentTheme.GridSeleccionTexto;

            // Estilo de los encabezados de columnas
            dgv.ColumnHeadersDefaultCellStyle.BackColor = CurrentTheme.GridEncabezadosFondo;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = CurrentTheme.GridEncabezadosTexto;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = CurrentTheme.GridEncabezadosFondo;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = CurrentTheme.GridEncabezadosTexto;

            // Estilo de los encabezados de filas
            dgv.RowHeadersDefaultCellStyle.BackColor = CurrentTheme.GridEncabezadosFondo;
            dgv.RowHeadersDefaultCellStyle.ForeColor = CurrentTheme.GridEncabezadosTexto;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = CurrentTheme.GridEncabezadosFondo;
            dgv.RowHeadersDefaultCellStyle.SelectionForeColor = CurrentTheme.GridEncabezadosTexto;

            dgv.EnableHeadersVisualStyles = false;
        }
    }

    public class Theme
    {
        public Color FondoPrincipal { get; set; }
        public Color PanelPrimario { get; set; }                    // Panel por defecto
        public Color PanelSecundario { get; set; }          // Panel secundario
        public Color TextoBotonPanel2 { get; set; }
        public Color TextoPrincipal { get; set; }
        public Color Botones { get; set; }
        public Color TextoBotones { get; set; }
        public Color BackgroundTextBox { get; set; }
        public Color TextoCajaTexto { get; set; }

        // Botones especiales
        public Color BotonCerrar { get; set; }
        public Color BotonExportar { get; set; }
        public Color BotonImportar { get; set; }
        public Color BotonUsuario { get; set; }
        public Color BotonMetricas { get; set; }
        public Color BotonAltas { get; set; }
        public Color BotonRol { get; set; }
        public Color BotonMenu { get; set; }

        public Color BotonReiniciar { get; set; }

        public Color BotonBuscar { get; set; }
        public Color BotonTema { get; set; }

        //Propiedades para el DataGrid
        public Color GridFondo { get; set; }
        public Color GridCeldasFondo { get; set; }
        public Color GridCeldasTexto { get; set; }
        public Color GridEncabezadosFondo { get; set; }
        public Color GridEncabezadosTexto { get; set; }
        public Color GridLineas { get; set; }
        public Color GridSeleccionFondo { get; set; } 
        public Color GridSeleccionTexto { get; set; }
    }
}