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
        public Color TextoBotonPanel2 { get; set; }
        public Color TextoPrincipal { get; set; }
        public Color Botones { get; set; }
        public Color TextoBotones { get; set; }
        public Color BackgroundTextBox { get; set; }
        public Color TextoCajaTexto { get; set; }

        // Botones especiales para usuario
        public Color BotonCerrar { get; set; }
        public Color BotonRecetas { get; set; }
        public Color BotonFavoritos { get; set; }
        public Color BotonPerfil { get; set; }
        public Color BotonBuscar { get; set; }
        public Color BotonReiniciar { get; set; }
        public Color BotonMenu { get; set; }
        public Color BotonTema { get; set; }
        public Color BotonGuardar { get; set; }
        public Color BotonCancelar { get; set; }
    }

    public static class GestorTemaUsuario
    {
        private static bool _esOscuro = false;

        // Evento para notificar cuando cambia el tema
        public static event Action TemaCambiado;

        // Tema Claro para Usuario
        private static readonly TemaUsuario TemaClaro = new TemaUsuario
        {
            // MODIFICA ESTOS COLORES SEGÚN LA PALETA QUE QUIERAS PARA USUARIO
            PanelPrimario = Color.FromArgb(255, 165, 0),
            PanelSecundario = Color.FromArgb(240, 248, 255),

            TextoPrincipal = Color.FromArgb(25, 25, 112),
            Botones = Color.FromArgb(255, 140, 0),
            TextoBotones = Color.White,
            BackgroundTextBox = Color.White,
            TextoCajaTexto = Color.Black,
            TextoBotonPanel2 = Color.FromArgb(70, 130, 180),

            // Botones especiales para usuario
            BotonCerrar = Color.FromArgb(220, 20, 60),              // Rojo carmesí
            BotonRecetas = Color.FromArgb(34, 139, 34),             // Verde forest
            BotonFavoritos = Color.FromArgb(255, 215, 0),           // Dorado
            BotonPerfil = Color.FromArgb(138, 43, 226),             // Violeta
            BotonBuscar = Color.White,
            BotonReiniciar = Color.White,
            BotonMenu = Color.FromArgb(70, 130, 180),
            BotonTema = Color.FromArgb(41, 128, 185),
            BotonGuardar = Color.FromArgb(50, 205, 50),             // Verde lima
            BotonCancelar = Color.FromArgb(255, 99, 71)             // Rojo tomate
        };

        // Tema Oscuro para Usuario (puedes mantenerlo similar al admin o modificar)
        private static readonly TemaUsuario TemaOscuro = new TemaUsuario
        {
            PanelPrimario = Color.FromArgb(45, 45, 45),
            PanelSecundario = Color.FromArgb(55, 55, 55),
            TextoPrincipal = Color.FromArgb(240, 240, 240),
            Botones = Color.FromArgb(65, 130, 210),
            TextoBotones = Color.White,
            BackgroundTextBox = Color.White,
            TextoCajaTexto = Color.White,
            TextoBotonPanel2 = Color.White,

            // Botones especiales para usuario
            BotonCerrar = Color.FromArgb(200, 70, 50),
            BotonRecetas = Color.FromArgb(60, 179, 113),            // Verde mar medio
            BotonFavoritos = Color.FromArgb(218, 165, 32),          // Dorado oscuro
            BotonPerfil = Color.FromArgb(147, 112, 219),            // Violeta medio
            BotonBuscar = Color.FromArgb(70, 70, 70),
            BotonReiniciar = Color.FromArgb(70, 70, 70),
            BotonMenu = Color.FromArgb(180, 80, 80),
            BotonTema = Color.FromArgb(52, 152, 219),
            BotonGuardar = Color.FromArgb(46, 139, 87),             // Verde mar oscuro
            BotonCancelar = Color.FromArgb(205, 92, 92)             // Rojo indio
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
            AplicarTemaAControlYHijos(formulario);
        }

        public static void AplicarTemaAUserControl(UserControl userControl)
        {
            AplicarTemaAControlYHijos(userControl);
        }

        private static void AplicarTemaAControlYHijos(Control padre)
        {
            AplicarTemaAControl(padre);

            foreach (Control hijo in padre.Controls)
            {
                AplicarTemaAControlYHijos(hijo);
            }
        }

        private static void AplicarTemaAControl(Control control)
        {
            //  PANELES CON TAGS ESPECÍFICOS
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
                }
            }

            panel.BackColor = colorFondo;
            panel.ForeColor = TemaActual.TextoPrincipal;
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
                    case "peligro":
                        colorFondo = TemaActual.BotonCerrar;
                        boton.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "recetas":
                        colorFondo = TemaActual.BotonRecetas;
                        boton.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "favoritos":
                        colorFondo = TemaActual.BotonFavoritos;
                        boton.ForeColor = TemaActual.TextoBotones;
                        break;
                    case "perfil":
                        colorFondo = TemaActual.BotonPerfil;
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
            boton.FlatAppearance.BorderSize = 1;
        }
    }
}