using System;
using System.Drawing;
using System.Windows.Forms;

namespace MicheBytesRecipes.Helpers
{
    public class TemaAdmin
    {
        public Color FondoPrincipal { get; set; }
        public Color PanelPrimario { get; set; }
        public Color PanelSecundario { get; set; }
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
    public static class GestorTemaAdmin
    {
        private static bool esOscuro = false;

        // Evento para notificar a TODOS los formularios cuando cambia el tema
        public static event Action TemaCambiado;

        // Tema Claro
        private static readonly TemaAdmin TemaClaro = new TemaAdmin
        {
            PanelPrimario = Color.FromArgb(0, 192, 192),           // Panel por defecto
            PanelSecundario = Color.FromArgb(230, 230, 230), // Panel secundario
            FondoPrincipal = Color.FromArgb(0, 192, 192),
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
        private static readonly TemaAdmin TemaOscuro = new TemaAdmin
        {
            PanelPrimario = Color.FromArgb(45, 45, 45),
            PanelSecundario = Color.FromArgb(55, 55, 55),
            FondoPrincipal = Color.FromArgb(45, 45, 45),

            TextoPrincipal = Color.FromArgb(240, 240, 240),
            Botones = Color.FromArgb(65, 130, 210),
            TextoBotones = Color.White,
            BackgroundTextBox = Color.White,
            TextoCajaTexto = Color.Black,
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

        public static TemaAdmin TemaActual => esOscuro ? TemaOscuro : TemaClaro;
        public static bool EsTemaOscuro => esOscuro;

        public static void CambiarTema()
        {
            esOscuro = !esOscuro;
            TemaCambiado?.Invoke();
        }

        public static void AplicarTema(Form form)
        {
            AplicarTemaEnCascada(form);
        }

        private static void AplicarTemaEnCascada(Control parent)
        {
            // Aplicar tema al control padre
            AplicarTemaAControl(parent);

            // Aplicar recursivamente a todos los hijos
            foreach (Control child in parent.Controls)
            {
                AplicarTemaEnCascada(child);
            }
        }

        private static void AplicarTemaAControl(Control control)
        {
            if (control is Panel || control is GroupBox || control is TabPage)
            {
                AplicarTemaAPanel(control);
            }

            // Form
            else if (control is Form)
            {
                control.BackColor = TemaActual.FondoPrincipal;
                control.ForeColor = TemaActual.TextoPrincipal;
            }

            // Texto (Label, LinkLabel, etc.)
            else if (control is Label || control is LinkLabel)
            {
                control.ForeColor = TemaActual.TextoPrincipal;
                control.BackColor = Color.Transparent;
            }

            // Botones
            else if (control is Button)
            {
                AplicarTemaABoton((Button)control);
            }

            // Cajas de texto
            else if (control is TextBox || control is RichTextBox)
            {
                control.BackColor = TemaActual.BackgroundTextBox;
                control.ForeColor = TemaActual.TextoCajaTexto;
            }

            // Listas y combos
            else if (control is ComboBox || control is ListBox || control is CheckedListBox)
            {
                control.BackColor = TemaActual.BackgroundTextBox;
                control.ForeColor = TemaActual.TextoCajaTexto;
            }

            // CheckBox y RadioButton
            else if (control is CheckBox || control is RadioButton)
            {
                control.ForeColor = TemaActual.TextoPrincipal;
                control.BackColor = Color.Transparent;
            }

            // DataGridView
            else if (control is DataGridView)
            {
                AplicarTemaADataGrid((DataGridView)control);
            }
        }

        private static void AplicarTemaAPanel(Control panel)
        {
            var tag = panel.Tag?.ToString()?.ToLower();
            Color backColor = TemaActual.PanelPrimario; // Por defecto

            if (!string.IsNullOrEmpty(tag))
            {
                switch (tag)
                {
                    case "secundario":
                        backColor = TemaActual.PanelSecundario;
                        break;
                }
            }

            panel.BackColor = backColor;
            panel.ForeColor = TemaActual.TextoPrincipal;
        }

        private static void AplicarTemaABoton(Button button)
        {
            // Color según el Tag
            var tag = button.Tag?.ToString()?.ToLower();
            Color backColor = TemaActual.Botones; // Por defecto

            if (!string.IsNullOrEmpty(tag))
            {
                switch (tag)
                {
                    case "cerrar":
                        backColor = TemaActual.BotonCerrar;
                        button.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "exportar":
                        backColor = TemaActual.BotonExportar;
                        button.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "importar":
                        backColor = TemaActual.BotonImportar;
                        button.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "usuario":
                        backColor = TemaActual.BotonUsuario;
                        button.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "metricas":
                        backColor = TemaActual.BotonMetricas;
                        button.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "buscar":
                        backColor = TemaActual.BotonBuscar;
                        button.ForeColor = TemaActual.TextoBotonPanel2;
                        break;
                    case "reiniciar":
                        backColor = TemaActual.BotonReiniciar;
                        button.ForeColor = TemaActual.TextoBotonPanel2;
                        break;
                    case "alta":
                        backColor = TemaActual.BotonAltas;
                        button.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "menu":
                        backColor = TemaActual.BotonMenu;
                        button.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "rol":
                        backColor = TemaActual.BotonRol;
                        button.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "tema":
                        backColor = TemaActual.BotonTema;
                        break;
                }
            }

            button.BackColor = backColor;
            button.FlatStyle = FlatStyle.Standard;
            button.FlatAppearance.BorderSize = 1;
        }

        private static void AplicarTemaADataGrid(DataGridView dgv)
        {
            // Configuración completa del DataGridView
            dgv.BackgroundColor = TemaActual.GridFondo;
            dgv.GridColor = TemaActual.GridLineas;

            // Estilo de las celdas normales
            dgv.DefaultCellStyle.BackColor = TemaActual.GridCeldasFondo;
            dgv.DefaultCellStyle.ForeColor = TemaActual.GridCeldasTexto;
            dgv.DefaultCellStyle.SelectionBackColor = TemaActual.GridSeleccionFondo;
            dgv.DefaultCellStyle.SelectionForeColor = TemaActual.GridSeleccionTexto;

            // Estilo de los encabezados de columnas
            dgv.ColumnHeadersDefaultCellStyle.BackColor = TemaActual.GridEncabezadosFondo;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TemaActual.GridEncabezadosTexto;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = TemaActual.GridEncabezadosFondo;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = TemaActual.GridEncabezadosTexto;

            // Estilo de los encabezados de filas
            dgv.RowHeadersDefaultCellStyle.BackColor = TemaActual.GridEncabezadosFondo;
            dgv.RowHeadersDefaultCellStyle.ForeColor = TemaActual.GridEncabezadosTexto;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = TemaActual.GridEncabezadosFondo;
            dgv.RowHeadersDefaultCellStyle.SelectionForeColor = TemaActual.GridEncabezadosTexto;

            dgv.EnableHeadersVisualStyles = false;
        }
    }
}