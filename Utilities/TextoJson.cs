using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicheBytesRecipes.Utilities
{
    public class ContenidoJson
    {
        [JsonProperty("textoJson")]
        public List<TextoJson> textoJson { get; set; } = new List<TextoJson>();
    }

    public class TextoJson
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonProperty("texto")]
        public string Texto { get; set; } = string.Empty;

        [JsonProperty("color")]
        public string Color { get; set; } = string.Empty; // Para compatibilidad

        [JsonProperty("colorTextoClaro")]
        public string ColorTextoClaro { get; set; } = string.Empty;

        [JsonProperty("colorTextoOscuro")]
        public string ColorTextoOscuro { get; set; } = string.Empty;

        [JsonProperty("tamaño")]
        public int Tamaño { get; set; } = 12;

        [JsonProperty("negrita")]
        public bool Negrita { get; set; } = false;
    }
}

