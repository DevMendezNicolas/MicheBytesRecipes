using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Moderador_IA
{

    public class ModeradorComentarios
    {
        private readonly HttpClient _clienteHttp;
        private readonly string _claveAPI = "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";
        private const string URL_API = "https://api-inference.huggingface.co/models/";
        private readonly string registroComentarios = @"Moderador IA\registroComentarios.json";

        public ModeradorComentarios()
        {
            _clienteHttp = new HttpClient();
            _clienteHttp.DefaultRequestHeaders.Add("Authorization", $"Bearer {_claveAPI}");
            _clienteHttp.Timeout = TimeSpan.FromSeconds(30);

            //Asegurar que la carpeta existe
            AsegurarDirectorio();
        }

        private void AsegurarDirectorio()
        {
            try
            {
                // Usar _archivoRegistro (la variable de clase)
                var directorio = Path.GetDirectoryName(registroComentarios);
                if (!string.IsNullOrEmpty(directorio) && !Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creando directorio: {ex.Message}");
            }
        }

        public async Task<(bool EsToxico, double Puntuacion, string Razon)> AnalizarComentario(string comentario)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(comentario))
                    return (false, 0.0, "Comentario vacío");

                var modelo = "unitary/multilingual-toxic-xlm-roberta";
                var solicitud = new { inputs = comentario };
                var json = JsonConvert.SerializeObject(solicitud);
                var contenido = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var respuesta = await _clienteHttp.PostAsync(URL_API + modelo, contenido);

                if (respuesta.IsSuccessStatusCode)
                {
                    var resultadoJson = await respuesta.Content.ReadAsStringAsync();
                    return AnalizarToxicidadDetallada(resultadoJson);
                }

                return (false, 0.0, "Error en la API");
            }
            catch (Exception ex)
            {
                return (false, 0.0, $"Error: {ex.Message}");
            }
        }

        private (bool, double, string) AnalizarToxicidadDetallada(string respuestaJson)
        {
            try
            {
                var datos = JsonConvert.DeserializeObject<dynamic>(respuestaJson);
                double maxPuntuacion = 0.0;
                string etiquetaPrincipal = "";

                if (datos[0] != null)
                {
                    foreach (var item in datos[0])
                    {
                        string etiqueta = item.label;
                        double puntuacion = item.score;

                        if (puntuacion > maxPuntuacion)
                        {
                            maxPuntuacion = puntuacion;
                            etiquetaPrincipal = etiqueta;
                        }
                    }
                }

                bool esToxico = maxPuntuacion > 0.85;
                string razon = esToxico ? $"Contenido {etiquetaPrincipal} ({(maxPuntuacion * 100):F1}%)" : "Aprobado";

                return (esToxico, maxPuntuacion, razon);
            }
            catch
            {
                return (false, 0.0, "Error analizando respuesta");
            }
        }

        public void RegistrarComentarioEliminado(string idUsuario, string comentario, string razon, double puntuacion)
        {
            try
            {
                var comentarioEliminado = new ComentarioEliminado(idUsuario, comentario, razon, puntuacion);

                // Leer archivo existente
                List<ComentarioEliminado> comentariosExistentes = new List<ComentarioEliminado>();

                if (File.Exists(registroComentarios))
                {
                    var jsonExistente = File.ReadAllText(registroComentarios);
                    comentariosExistentes = JsonConvert.DeserializeObject<List<ComentarioEliminado>>(jsonExistente) ?? new List<ComentarioEliminado>();
                }

                // Agregar nuevo comentario eliminado
                comentariosExistentes.Add(comentarioEliminado);

                // Guardar en JSON
                var nuevoJson = JsonConvert.SerializeObject(comentariosExistentes, Formatting.Indented);
                File.WriteAllText(registroComentarios, nuevoJson);

                Console.WriteLine($"✅ Comentario de {idUsuario} registrado en: {registroComentarios}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error guardando registro: {ex.Message}");
            }
        }

        public List<ComentarioEliminado> ObtenerComentariosEliminados()
        {
            try
            {
                if (File.Exists(registroComentarios))
                {
                    var json = File.ReadAllText(registroComentarios);
                    return JsonConvert.DeserializeObject<List<ComentarioEliminado>>(json) ?? new List<ComentarioEliminado>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error leyendo registro: {ex.Message}");
            }

            return new List<ComentarioEliminado>();
        }
    }
}
