using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Classes.Recetas
{
    public partial class FrmVerReceta : Form
    {
        private Receta receta;
        public FrmVerReceta(Receta receta)
        {
            InitializeComponent();
            this.receta = receta;
            //Asignar los valores de la receta a los controles del formulario
        }

        private void FrmVerReceta_Load(object sender, EventArgs e)
        {
           if(receta != null)
            {
                lblNombre.Text = receta.Nombre;
                lblDescripcion.Text = receta.Descripcion;
                lblDificultad.Text = receta.NivelDificultad.ToString();
                lblTiempo.Text =receta.TiempoPreparacion.ToString(@"hh\:mm");
                lblInstruccion.Text = receta.Instrucciones;

                if(receta.ImagenReceta != null && receta.ImagenReceta.Length > 0)
                {
                    //Crea una imagen a partir del arreglo de bytes
                    using (MemoryStream ms = new MemoryStream(receta.ImagenReceta))
                    {
                        //Se crea un objeto imagen a partir del stream
                        pbxImagen.Image = Image.FromStream(ms);
                        //Ajusta el tamaño de la imagen al tamaño del picturebox
                        pbxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }else
                {
                    pbxImagen.Image = null;
                }

                //Cargar los ingredientes en el listbox
                lstIngredientes.Items.Clear();
                foreach (var ingrediente in receta.Ingredientes)
                {
                    lstIngredientes.Items.Add(ingrediente.Nombre);
                }


            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblFavoritos_Click(object sender, EventArgs e)
        {
            //Agregar a favoritos
        }

        private void btnMeGusta_Click(object sender, EventArgs e)
        {
            //Agregar me gusta
        }
    }
}
