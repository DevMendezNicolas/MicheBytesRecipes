using MicheBytesRecipes.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Forms.AddReceta
{
    public partial class FrmModificarReceta : Form
    {
        private Receta receta;
        GestorReceta gestorReceta = new GestorReceta();
        GestorCatalogo gestorCatalogo = new GestorCatalogo();
        public FrmModificarReceta(Receta receta)
        {
            InitializeComponent();
            this.receta = receta;
            CargarDatosReceta();
        }

        private void CargarDatosReceta()
        {
            if (receta != null)
            {
                txtNombre.Text = receta.Nombre;
                txtDescripcion.Text = receta.Descripcion;
                cboDificultad.SelectedItem = receta.NivelDificultad.ToString();
                dtpTiempo.Value = DateTime.Today.Add(receta.TiempoPreparacion);
                txtInstrucciones.Text = receta.Instrucciones;

                if (receta.ImagenReceta != null && receta.ImagenReceta.Length > 0)
                {
                    using (var ms = new System.IO.MemoryStream(receta.ImagenReceta))
                    {
                        pcbImagen.Image = Image.FromStream(ms);
                        pcbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    pcbImagen.Image = null;
                }
                clbIngredientes.Items.Clear();
                if (receta.Ingredientes != null && receta.Ingredientes.Count > 0)
                {
                    foreach (var ingrediente in receta.Ingredientes)
                    {
                        clbIngredientes.Items.Add(ingrediente.Nombre, true);

                    }
                }else 
                    clbIngredientes.Items.Add("No hay ingredientes asignados", false);
                cboCategoria.SelectedItem = gestorCatalogo.ObtenerCategoriaPorId(receta.CategoriaId)?.Nombre ?? "Desconocida";
                cboPais.SelectedItem = gestorCatalogo.ObtenerPaisPorId(receta.PaisId)?.Nombre ?? "Desconocido";


            }
        }




    }
}
