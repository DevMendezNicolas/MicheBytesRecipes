using MicheBytesRecipes.Classes.Recetas;
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

namespace MicheBytesRecipes.Forms.AddReceta
{
   
    public partial class PruebaImagen : Form
    {
        GestorReceta gestorReceta = new GestorReceta();
        public PruebaImagen()
        {
            InitializeComponent();
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txtId.Text, out int id))
            {
                Receta receta = new Receta();

                if (receta != null)
                {
                    //imagen
                    if(receta.ImagenReceta != null)
                    {
                        using(var ms = new MemoryStream(receta.ImagenReceta))
                        {
                            pcbImagenReceta.Image = Image.FromStream(ms);
                            pcbImagenReceta.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    else
                    {
                        pcbImagenReceta = null;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró la receta.");
                }
            }else
            {
                MessageBox.Show("Ingresá un ID válido.");
            }
        }
    }
}
