using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicheBytesRecipes.Utilities;
using System.Windows.Forms;

namespace MicheBytesRecipes.Forms.Auth
{
    public partial class Terminos : Form
    {
        private const string jsonpath = @"Data/terms.json";

        public Terminos()
        {
            InitializeComponent();
            CargarTerminos();
            btnAceptar.Enabled = false; // Deshabilitar el botón inicialmente
        }

        private void CargarTerminos()
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "terms.json");
            CargarJson.CargarRichTextBoxDesdeJson(rtbTerminos, jsonPath);
        }


        private bool ScrollFinalTexto()
        {
            try
            {
                // Obtener la posición del último carácter visible en la parte inferior
                int indiceDelCaracterEnElFondo = rtbTerminos.GetCharIndexFromPosition(
                    new Point(10, rtbTerminos.ClientSize.Height - 10));

                // Obtener el índice del último carácter del texto
                int indiceDelUltimoCaracter = rtbTerminos.TextLength - 1;

                // Si el carácter en el fondo está cerca del final (último 2%)
                return indiceDelCaracterEnElFondo >= indiceDelUltimoCaracter * 0.95;
            }
            catch
            {
                return false;
            }
        }
        private void VerificarFinalScroll()
        {
            // Método más preciso para verificar si llegó al final
            if (ScrollFinalTexto())
            {
                btnAceptar.Enabled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void rtbTerminos_VScroll(object sender, EventArgs e)
        {
            VerificarFinalScroll();

        }

        private void Terminos_Load(object sender, EventArgs e)
        {

        }
    }
}
