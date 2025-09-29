using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicheBytesRecipes.Utilities
{
    internal class Utilidades
    {
        public static string CapitalizarPrimeraLetra(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))               
                return texto;//Si el texto es null o vacio, lo devuelvo tal cual

            texto = texto.Trim();//Elimino espacios en blanco al inicio y al final
            return char.ToUpper(texto[0]) + texto.Substring(1).ToLower();
            //Convierto la primera letra a mayuscula y el resto a minuscula
        } 




    }
}
