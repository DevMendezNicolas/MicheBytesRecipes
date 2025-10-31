using MicheBytesRecipes.Helpers;
using MicheBytesRecipes.Utilities;
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
using System.Windows.Forms;

namespace MicheBytesRecipes.Forms.Auth
{
    public partial class frmTerminos : Form
    {
        private const string jsonpath = @"DatosJson/terminosContenido.json";

        public frmTerminos()
        {
            InitializeComponent();
            CargarTerminos();
            btnAceptar.Enabled = false;
        }

        private void CargarTerminos()
        {
            CargarJson.CargarRichTextBoxDesdeJson(rtbTerminos, jsonpath);
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

        private void frmTerminos_Load(object sender, EventArgs e)
        {
            AsignarTags();
            GestorTemaUsuario.AplicarTema(this);
            GestorTemaUsuario.TemaCambiado += () => GestorTemaUsuario.AplicarTema(this);
        }
        private void AsignarTags()
        {
            lblTitulo.Tag = "titulo";

        }
    }
}
