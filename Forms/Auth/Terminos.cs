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
        public Terminos()
        {
            InitializeComponent();
        }

        private void FrmTerms_Load(object sender, EventArgs e)
        {
            CargarTerminos();
        }

        private void CargarTerminos()
        {
                       string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "terms.json");

            MessageBox.Show("Buscando JSON en: " + jsonPath);

            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                TerminosData terms = JsonConvert.DeserializeObject<TerminosData>(json);

                lblTitulo.Text = terms.titulo;
                richTextBox1.Text = terms.contenido;
            }
            else
            {
                richTextBox1.Text = "No se encontraron los términos y condiciones.";
            }
        }

    }
}
