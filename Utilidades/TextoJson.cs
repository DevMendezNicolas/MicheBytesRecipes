using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicheBytesRecipes.Utilities
{
    public class TextoJson
    {
        public string Nombre { get; set; }
        public string Texto { get; set; }
        public int Tamaño { get; set; }
        public bool Negrita { get; set; }
    }
    public class JsonData
    {
        public List<TextoJson> textoJson { get; set; }
    }
}

