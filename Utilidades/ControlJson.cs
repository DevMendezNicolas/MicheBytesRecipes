using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Globalization;
using System.Drawing;
using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Classes.Recetas;

namespace MicheBytesRecipes.Utilities
{
    public class ControlJson
    {
        public static bool ExportarRecetasAJson(string rutaArchivo, List<Receta> recetas, out string mensaje, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;

            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(rutaArchivo))
            {
                mensaje = "Ruta de archivo inválida.";
                return false;
            }

            if (recetas == null || recetas.Count == 0)
            {
                mensaje = "No hay recetas para exportar.";
                return false;
            }

            try
            {
                string directorio = Path.GetDirectoryName(rutaArchivo);
                if (!string.IsNullOrEmpty(directorio) && !Directory.Exists(directorio))
                    Directory.CreateDirectory(directorio);

                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore,
                    Culture = CultureInfo.InvariantCulture,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                string tempFile = rutaArchivo + ".tmp";

                using (var fs = new FileStream(tempFile, FileMode.Create, FileAccess.Write, FileShare.None))
                using (var sw = new StreamWriter(fs, encoding))
                using (var jw = new JsonTextWriter(sw) { Formatting = settings.Formatting })
                {
                    var serializer = JsonSerializer.Create(settings);
                    serializer.Serialize(jw, recetas);
                    jw.Flush();
                }

                if (File.Exists(rutaArchivo))
                    File.Replace(tempFile, rutaArchivo, null);
                else
                    File.Move(tempFile, rutaArchivo);

                mensaje = "Exportación completada correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al exportar las recetas a JSON: {ex.Message}";
                try { if (File.Exists(rutaArchivo + ".tmp")) File.Delete(rutaArchivo + ".tmp"); } catch { }
                return false;
            }
        }
       
        public static List<Receta> ImportarRecetasDesdeJson(string rutaArchivo, out string mensaje, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;

            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(rutaArchivo) || !File.Exists(rutaArchivo))
            {
                mensaje = "Ruta de archivo inválida o archivo no encontrado.";
                return new List<Receta>();
            }

            try
            {
                string json = File.ReadAllText(rutaArchivo, encoding);

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Culture = CultureInfo.InvariantCulture,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                var recetas = JsonConvert.DeserializeObject<List<Receta>>(json, settings);

                if (recetas == null || recetas.Count == 0)
                {
                    mensaje = "No se encontraron recetas en el archivo JSON.";
                    return new List<Receta>();
                }

                // Limpiar las imágenes (para evitar cargar bytes del JSON)
                foreach (var receta in recetas)
                {
                    receta.ImagenReceta = null;
                }

                mensaje = $"Se importaron {recetas.Count} recetas correctamente (sin imágenes).";
                return recetas;
            }
            catch (JsonException jex)
            {
                mensaje = $"Error al deserializar el archivo JSON: {jex.Message}";
                return new List<Receta>();
            }
            catch (Exception ex)
            {
                mensaje = $"Error al importar recetas: {ex.Message}";
                return new List<Receta>();
            }
        }
    }
}
