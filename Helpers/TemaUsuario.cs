using System;
using System.Drawing;
using System.Windows.Forms;

namespace MicheBytesRecipes.Helpers
{
    public class TemaUsuario
    {
        public Color FondoPrincipal { get; set; }
        public Color PanelPrimario { get; set; }
        public Color PanelSecundario { get; set; }
        public Color PanelOpcional { get; set; }
        public Color TextoBotonPanel2 { get; set; }
        public Color Botones { get; set; }
        public Color TextoBotones { get; set; }
        public Color BackgroundTextBox { get; set; }
        public Color TextoCajaTexto { get; set; }

        // Botones especiales para usuario
        public Color BotonCerrar { get; set; }
        public Color BotonConfiguracion { get; set; }
        public Color BotonFavoritos { get; set; }
        public Color BotonHistorial { get; set; }
        public Color BotonBuscar { get; set; }
        public Color BotonReiniciar { get; set; }
        public Color BotonMenu { get; set; }
        public Color BotonTema { get; set; }
        public Color BotonGuardar { get; set; }
        public Color BotonCancelar { get; set; }

        //Labels
        public Color TextoPrincipal { get; set; }
        public Color LabelTitulo { get; set; }
        public Color LabelSubtitulo { get; set; }
        public Color LabelRelleno { get; set; }
    }

    public static class GestorTemaUsuario
    {
        private static bool _esOscuro = false;

        // Evento para notificar cuando cambia el tema
        public static event Action TemaCambiado;

        // Tema Claro para Usuario
        private static readonly TemaUsuario TemaClaro = new TemaUsuario
        {
            FondoPrincipal = Color.FromArgb(255, 165, 0), //Orange comun de Michebyte
            PanelPrimario = Color.FromArgb(255, 165, 0), //Orange comun de Michebyte
            PanelSecundario = Color.FromArgb(255, 140, 0), //DarkOrange
            PanelOpcional = Color.FromArgb(245, 222, 179), //Beige

            Botones = Color.FromArgb(254, 93, 70), //Rojo michebytes imagen
            TextoBotones = Color.FromArgb(245, 222, 179), //Beige
            BackgroundTextBox = Color.White,
            TextoCajaTexto = Color.Black,
            TextoBotonPanel2 = Color.FromArgb(255, 165, 0), //SteelBlue

            // Botones especiales para usuario
            BotonFavoritos = Color.FromArgb(250, 128, 114), //Salmón
            BotonHistorial = Color.FromArgb(255, 215, 0), //Amarillo
            BotonConfiguracion = Color.FromArgb(255, 140, 0), //DarkOrange
            BotonMenu = Color.FromArgb(255, 140, 0),
            BotonBuscar = Color.FromArgb(255,255,255),
            BotonReiniciar = Color.FromArgb(255, 255, 255),
            BotonCerrar = Color.FromArgb(255,0,0),
            BotonTema = Color.FromArgb(41, 128, 185),
            BotonGuardar = Color.FromArgb(255, 140, 0),
            BotonCancelar = Color.FromArgb(255, 140, 0),

            // Labels
            LabelTitulo = Color.FromArgb(64,0,0), 
            LabelSubtitulo = Color.FromArgb(210, 105, 30),
            LabelRelleno = Color.FromArgb(255, 165, 0),
            TextoPrincipal = Color.FromArgb(245, 222, 179) //Beige

        };

        // Tema Oscuro para Usuario - Elegante con azules/verdes
        private static readonly TemaUsuario TemaOscuro = new TemaUsuario
        {
            FondoPrincipal = Color.FromArgb(25, 35, 45),        // Azul noche oscuro
            PanelPrimario = Color.FromArgb(35, 45, 55),         // Azul grafito
            PanelSecundario = Color.FromArgb(45, 55, 65),       // Azul acero
            PanelOpcional = Color.FromArgb(55, 65, 75),         // Azul pizarra

            TextoPrincipal = Color.FromArgb(220, 230, 240),     // Azul claro suave
            Botones = Color.FromArgb(70, 130, 180),             // Azul acero medio
            TextoBotones = Color.White,
            BackgroundTextBox = Color.White, 
            TextoCajaTexto = Color.Black,     // Azul claro
            TextoBotonPanel2 = Color.FromArgb(160, 200, 220),   // Azul cielo

            // Botones especiales para usuario - Tonos azules/verdes armónicos
            BotonFavoritos = Color.FromArgb(80, 160, 120),      // Verde esmeralda
            BotonHistorial = Color.FromArgb(200, 190, 230),     // Azul suave
            BotonConfiguracion = Color.FromArgb(90, 140, 180),  // Azul medio
            BotonMenu = Color.FromArgb(255, 140, 0),            // Naranja acento (tu color)
            BotonBuscar = Color.FromArgb(60, 70, 80),           // Azul grafito
            BotonReiniciar = Color.FromArgb(60, 70, 80),        // Azul grafito
            BotonCerrar = Color.FromArgb(200, 80, 80),          // Rojo suave
            BotonTema = Color.FromArgb(120, 180, 220),          // Azul cielo
            BotonGuardar = Color.FromArgb(70, 160, 110),        // Verde éxito
            BotonCancelar = Color.FromArgb(180, 100, 100),      // Rojo terracota

            // Labels
            LabelTitulo = Color.FromArgb(255, 180, 80),         // Naranja dorado
            LabelSubtitulo = Color.FromArgb(160, 200, 220),     // Azul cielo
            LabelRelleno = Color.FromArgb(120, 180, 220),       // Azul claro
        };

        public static TemaUsuario TemaActual => _esOscuro ? TemaOscuro : TemaClaro;
        public static bool EsTemaOscuro => _esOscuro;

        public static void AlternarTema()
        {
            _esOscuro = !_esOscuro;
            TemaCambiado?.Invoke();
        }

        public static void AplicarTema(Form formulario)
        {
            AplicarTemaRecursivamente(formulario);
        }

        public static void AplicarTemaAUserControl(UserControl userControl)
        {
            AplicarTemaRecursivamente(userControl);
        }

        private static void AplicarTemaRecursivamente(Control padre)
        {
            AplicarTemaAControl(padre);

            foreach (Control hijo in padre.Controls)
            {
                AplicarTemaRecursivamente(hijo);
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
            else if (control is Label label)
            {
                AplicarTemaALabel(label);
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

            // PictureBox (común en interfaces de usuario)
            else if (control is PictureBox)
            {
                control.BackColor = Color.Transparent;
            }
        }

        private static void AplicarTemaAPanel(Control panel)
        {
            var etiqueta = panel.Tag?.ToString()?.ToLower();
            Color colorFondo = TemaActual.PanelPrimario; // Por defecto

            if (!string.IsNullOrEmpty(etiqueta))
            {
                switch (etiqueta)
                {
                    case "secundario":
                        colorFondo = TemaActual.PanelSecundario;
                        break;
                    case "opcional":
                        colorFondo = TemaActual.PanelOpcional;
                        break;
                }
            }

            panel.BackColor = colorFondo;
            panel.ForeColor = TemaActual.TextoPrincipal;
        }

        private static void AplicarTemaALabel(Label label)
        {
            var etiqueta = label.Tag?.ToString()?.ToLower();

            if (!string.IsNullOrEmpty(etiqueta))
            {
                switch (etiqueta)
                {
                    case "titulo":
                        label.ForeColor = TemaActual.LabelTitulo;
                        break;
                    case "subtitulo":
                        label.ForeColor = TemaActual.LabelSubtitulo;
                        break;
                    case "relleno":
                        label.ForeColor = TemaActual.LabelRelleno;
                        break;
                    default:
                        label.ForeColor = TemaActual.TextoPrincipal;
                        break;
                }
            }
            else
            {
                label.ForeColor = TemaActual.TextoPrincipal;
            }

            label.BackColor = Color.Transparent;
        }

        private static void AplicarTemaABoton(Button boton)
        {
            // Color según el Tag
            var etiqueta = boton.Tag?.ToString()?.ToLower();
            Color colorFondo = TemaActual.Botones; // Por defecto

            if (!string.IsNullOrEmpty(etiqueta))
            {
                switch (etiqueta)
                {
                    case "cerrar":
                        colorFondo = TemaActual.BotonCerrar;
                        boton.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "configuracion":
                        colorFondo = TemaActual.BotonConfiguracion;
                        boton.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "favoritos":
                        colorFondo = TemaActual.BotonFavoritos;
                        boton.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "historial":
                        colorFondo = TemaActual.BotonHistorial;
                        boton.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "buscar":
                        colorFondo = TemaActual.BotonBuscar;
                        boton.ForeColor = TemaActual.TextoBotonPanel2;
                        break;
                    case "reiniciar":
                        colorFondo = TemaActual.BotonReiniciar;
                        boton.ForeColor = TemaActual.TextoBotonPanel2;
                        break;
                    case "menu":
                        colorFondo = TemaActual.BotonMenu;
                        boton.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "tema":
                        colorFondo = TemaActual.BotonTema;
                        break;
                    case "guardar":
                        colorFondo = TemaActual.BotonGuardar;
                        boton.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "cancelar":
                        colorFondo = TemaActual.BotonCancelar;
                        boton.ForeColor = TemaActual.TextoBotones;
                        break;
                }
            }

            boton.BackColor = colorFondo;
            boton.FlatStyle = FlatStyle.Standard;
        }
    }
}