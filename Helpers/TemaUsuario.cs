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
            TextoBotonPanel2 = Color.FromArgb(70, 130, 180), 

            // Botones especiales para usuario
            BotonFavoritos = Color.FromArgb(250, 128, 114), //Salmón
            BotonHistorial = Color.FromArgb(255, 215, 0), //Amarillo
            BotonConfiguracion = Color.FromArgb(255, 140, 0), //DarkOrange
            BotonMenu = Color.FromArgb(138, 43, 226),
            BotonBuscar = Color.FromArgb(255,255,255),
            BotonReiniciar = Color.FromArgb(255, 255, 255),
            BotonCerrar = Color.FromArgb(255,0,0),
            BotonTema = Color.FromArgb(41, 128, 185),
            BotonGuardar = Color.FromArgb(50, 205, 50),
            BotonCancelar = Color.FromArgb(255, 99, 71),

            // Labels
            LabelTitulo = Color.FromArgb(64,0,0), 
            LabelSubtitulo = Color.FromArgb(210, 105, 30),
            LabelRelleno = Color.FromArgb(255, 165, 0),
            TextoPrincipal = Color.FromArgb(245, 222, 179) //Beige

        };

        // Tema Oscuro para Usuario
        private static readonly TemaUsuario TemaOscuro = new TemaUsuario
        {
            FondoPrincipal = Color.FromArgb(40, 40, 45),
            PanelPrimario = Color.FromArgb(255, 140, 0),
            PanelSecundario = Color.FromArgb(60, 55, 50),
            PanelOpcional = Color.FromArgb(80, 70, 60),

            TextoPrincipal = Color.FromArgb(240, 240, 240),
            Botones = Color.FromArgb(255, 120, 0),
            TextoBotones = Color.White,
            BackgroundTextBox = Color.FromArgb(50, 50, 55),
            TextoCajaTexto = Color.FromArgb(220, 220, 220),
            TextoBotonPanel2 = Color.FromArgb(255, 180, 80),

            // Botones especiales para usuario
            BotonCerrar = Color.FromArgb(200, 70, 50),
            BotonConfiguracion = Color.FromArgb(60, 179, 113),
            BotonFavoritos = Color.FromArgb(218, 165, 32),
            BotonHistorial = Color.FromArgb(147, 112, 219),
            BotonBuscar = Color.FromArgb(70, 70, 75),
            BotonReiniciar = Color.FromArgb(70, 70, 75),
            BotonMenu = Color.FromArgb(180, 80, 80),
            BotonTema = Color.FromArgb(52, 152, 219),
            BotonGuardar = Color.FromArgb(46, 139, 87),
            BotonCancelar = Color.FromArgb(205, 92, 92),

            // Labels
            LabelTitulo = Color.White,
            LabelSubtitulo = Color.FromArgb(200, 200, 200),
            LabelRelleno = Color.FromArgb(255, 200, 50)
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
            // PANELES CON TAGS ESPECÍFICOS
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