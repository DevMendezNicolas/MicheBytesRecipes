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
        public static void CargarLabelsDesdeJson(Panel panel, string rutaJson)
        {
            try
            {
                string jsonContent = File.ReadAllText(rutaJson);
                JsonData datos = JsonConvert.DeserializeObject<JsonData>(jsonContent);

                if (datos?.textoJson == null) return;

                foreach (var config in datos.textoJson)
                {
                    Label label = panel.Controls.OfType<Label>()
                        .FirstOrDefault(l => l.Name == config.Nombre);

                    if (label != null)
                    {
                        label.Text = config.Texto;
                        // Usar Segoe UI como fuente
                        FontStyle estilo = config.Negrita ? FontStyle.Bold : FontStyle.Regular;
                        label.Font = new Font("Segoe UI", config.Tamaño, estilo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar texto desde JSON: {ex.Message}");
            }
        }

        // Método para RichTextBox
        public static void CargarRichTextBoxDesdeJson(RichTextBox richTextBox, string rutaJson)
        {
            try
            {
                string jsonContent = File.ReadAllText(rutaJson);
                JsonData datos = JsonConvert.DeserializeObject<JsonData>(jsonContent);

                if (datos?.textoJson == null) return;

                richTextBox.Clear();

                foreach (var config in datos.textoJson)
                {
                    FontStyle estilo = config.Negrita ? FontStyle.Bold : FontStyle.Regular;
                    float tamaño = config.Tamaño > 0 ? config.Tamaño : 9; // Tamaño por defecto

                    Font fuente = new Font("Segoe UI", tamaño, estilo);

                    richTextBox.SelectionStart = richTextBox.TextLength;
                    richTextBox.SelectionLength = 0;
                    richTextBox.SelectionFont = fuente;
                    richTextBox.AppendText(config.Texto + "\n\n");
                }

                richTextBox.SelectionStart = 0;
                richTextBox.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar texto en RichTextBox: {ex.Message}");
            }
        }
    }
}
        


