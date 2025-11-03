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

namespace MicheBytesRecipes.Forms.User
{
    public partial class ucRecetaTarjeta : UserControl
    {
        public event EventHandler VerDetallesClick;
        private bool _clickEnProceso = false;
        private readonly int _delayClick = 400;
        public ucRecetaTarjeta()
        {
            InitializeComponent();
            this.Size = new Size(170, 240);
            this.Margin = new Padding(8);

            this.Click += UcRecetaTarjeta_Click;
            foreach (Control ctrl in this.Controls)
                ctrl.Click += UcRecetaTarjeta_Click;
        }

        public int RecetaId { get; set; }

        public string NombreReceta
        {
            get => lblNombreReceta.Text;
            set => lblNombreReceta.Text = value;
        }

        public string CategoriaReceta
        {
            get => lblCategoria.Text;
            set => lblCategoria.Text = value;
        }

        public string PaisReceta
        {
            get => lblPais.Text;
            set => lblPais.Text = value;
        }

        public string TiempoReceta
        {
            get => lblTiempo.Text;
            set => lblTiempo.Text = value;
        }

        public string DificultadReceta
        {
            get => lblDificultad.Text;
            set => lblDificultad.Text = value;
        }

        public byte[] ImagenReceta
        {
            get
            {
                if (pbImagenReceta.Image != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        pbImagenReceta.Image.Save(ms, pbImagenReceta.Image.RawFormat);
                        return ms.ToArray();
                    }
                }
                return null;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    using (var ms = new MemoryStream(value))
                    {
                        pbImagenReceta.Image = Image.FromStream(ms);
                        pbImagenReceta.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    // Cargar imagen por defecto cuando value es null o vacío
                    CargarImagenDefaultEnPictureBox();
                }
            }
        }

        private void CargarImagenDefaultEnPictureBox()
        {
            string[] imagenesDefault = { "recetaDefault.png", "recetaDefault2.png", "recetaDefault3.png" };
            int indiceImagen = (RecetaId % imagenesDefault.Length);

            string imagenElegida = imagenesDefault[indiceImagen];
            string rutaImagen = Path.Combine(Application.StartupPath, "Imagenes", imagenElegida);

            if (File.Exists(rutaImagen))
            {
                pbImagenReceta.Image = Image.FromFile(rutaImagen);
            }
            else
            {
                // Buscar cualquier imagen disponible
                foreach (string imagen in imagenesDefault)
                {
                    rutaImagen = Path.Combine(Application.StartupPath, "Imagenes", imagen);
                    if (File.Exists(rutaImagen))
                    {
                        pbImagenReceta.Image = Image.FromFile(rutaImagen);
                        break;
                    }
                }

                if (pbImagenReceta.Image == null)
                {
                    pbImagenReceta.BackColor = Color.LightGray;
                }
            }

            pbImagenReceta.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private async void UcRecetaTarjeta_Click(object sender, EventArgs e)
        {
            if (_clickEnProceso) return;

            _clickEnProceso = true;

            try
            {
                VerDetallesClick?.Invoke(this, EventArgs.Empty);

                // Esperar antes de permitir otro click
                await Task.Delay(_delayClick);
            }
            finally
            {
                _clickEnProceso = false;
            }
        }
    }
}
