using MicheBytesRecipes.Helpers;
using MicheBytesRecipes.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Utilities
{
    public class CargarJson
    {
        private const string FUENTE = "Segoe UI";

        public static void CargarLabels(Panel panel, string rutaJson)
        {
            if (!File.Exists(rutaJson))
            {
                MessageBox.Show($"Archivo no encontrado: {rutaJson}", "Error");
                return;
            }

            try
            {
                var json = File.ReadAllText(rutaJson);
                var contenido = JsonConvert.DeserializeObject<ContenidoJson>(json);

                if (contenido?.textoJson == null) return;

                foreach (var item in contenido.textoJson)
                {
                    var label = BuscarLabel(panel, item.Nombre);
                    if (label != null)
                    {
                        AplicarEstilo(label, item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando JSON: {ex.Message}", "Error");
            }
        }

        public static void CargarRichTextBox(RichTextBox richTextBox, string rutaJson)
        {
            if (!File.Exists(rutaJson))
            {
                MessageBox.Show($"Archivo no encontrado: {rutaJson}", "Error");
                return;
            }

            try
            {
                var json = File.ReadAllText(rutaJson);
                var contenido = JsonConvert.DeserializeObject<ContenidoJson>(json);

                if (contenido?.textoJson == null) return;

                richTextBox.Clear();

                foreach (var item in contenido.textoJson)
                {
                    if (!string.IsNullOrEmpty(item.Texto))
                    {
                        AplicarEstiloRichTextBox(richTextBox, item);
                        richTextBox.AppendText(item.Texto + Environment.NewLine + Environment.NewLine);
                    }
                }

                richTextBox.SelectionStart = 0;
                richTextBox.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando JSON en RichTextBox: {ex.Message}", "Error");
            }
        }

        private static void AplicarEstiloRichTextBox(RichTextBox richTextBox, TextoJson item)
        {
            // Aplicar fuente
            var estilo = item.Negrita ? FontStyle.Bold : FontStyle.Regular;
            richTextBox.SelectionFont = new Font(FUENTE, item.Tamaño, estilo);

            // Aplicar color según el tema
            //var colorHex = ThemeManager.EsTemaOscuro ? item.ColorTextoOscuro : item.ColorTextoClaro;
            //richTextBox.SelectionColor = HexAColor(colorHex);
        }

        private static Label BuscarLabel(Panel panel, string nombre)
        {
            return panel.Controls.OfType<Label>()
                .FirstOrDefault(l => l.Name.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        private static void AplicarEstilo(Label label, TextoJson item)
        {
            label.Text = item.Texto;

            // Aplicar color según el tema
            //var colorHex = ThemeManager.EsTemaOscuro ? item.ColorTextoOscuro : item.ColorTextoClaro;
            //if (!string.IsNullOrEmpty(colorHex))
            {
            //    label.ForeColor = HexAColor(colorHex);
            }

            // Aplicar fuente
            var estilo = item.Negrita ? FontStyle.Bold : FontStyle.Regular;
            label.Font = new Font(FUENTE, item.Tamaño, estilo);
        }

        /*private static Color HexAColor(string hex)
        {
            try
            {
                if (string.IsNullOrEmpty(hex))
                    return ThemeManager.EsTemaOscuro ? Color.White : Color.Black;

                if (!hex.StartsWith("#"))
                    hex = "#" + hex;

                return ColorTranslator.FromHtml(hex);
            }
            catch
            {
                return ThemeManager.EsTemaOscuro ? Color.White : Color.Black;
            }
        }

        public static void ActualizarColores(Panel panel, string rutaJson)
        {
            CargarLabels(panel, rutaJson);
        }*/
    }
}
        


