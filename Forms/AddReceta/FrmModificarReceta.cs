using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
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
        GestorIngredientes gestorIngredientes = new GestorIngredientes();


        public FrmModificarReceta(Receta receta, Usuario usuarioLog)
        {
            InitializeComponent();
            this.receta = receta;
            
        }
        private void FrmModificarReceta_Load(object sender, EventArgs e)
        {
            CargarControles();
            if (receta != null)
            {
                CargarDatosReceta();
            }
        }
        private void CargarDatosReceta()
        {
            if (receta != null)
            {
                txtNombre.Text = receta.Nombre;
                txtDescripcion.Text = receta.Descripcion;
                txtInstrucciones.Text = receta.Instrucciones;
                dtpTiempo.Value = DateTime.Today.Add(receta.TiempoPreparacion);

                cboPais.SelectedValue = receta.PaisId;
                cboCategoria.SelectedValue = receta.CategoriaId;
                cboDificultad.SelectedItem = receta.NivelDificultad;

                if (receta.ImagenReceta != null && receta.ImagenReceta.Length > 0)
                {
                    using (var ms = new MemoryStream(receta.ImagenReceta))
                    {
                        pcbImagen.Image = Image.FromStream(ms);
                        pcbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    pcbImagen.Image = null;
                }               
            }
            MarcarIngredientesSeleccionados(); // Marcar los ingredientes seleccionados en el CheckedListBox
        }
        private void MarcarIngredientesSeleccionados() //Para la documentacion este metodo fue creado con la ayuda de ChatGPT
        {
            if (receta.Ingredientes == null) return;

            //Obtenemos los ID de los ingredientes de la receta
            var ingredientesRecetaIds = new HashSet<int>(receta.Ingredientes.Select(i => i.IngredienteId)); // HashSet para busquedas rapidas

            //Recorremos los items del CheckedListBox y marcamos los que estan en la receta
            for (int i = 0; i < clbIngredientes.Items.Count; i++)
            {
                // Obtenemos el ingrediente del item actual
                var ingrediente = (Ingrediente)clbIngredientes.Items[i];
                // Si el ID del ingrediente esta en la lista de la receta, lo marcamos
                if (ingredientesRecetaIds.Contains(ingrediente.IngredienteId))
                {
                    clbIngredientes.SetItemChecked(i, true);
                }
            }
        }
        public void CargarControles()
        {
            //Cargar ComboBox Paises
            cboPais.DataSource = gestorCatalogo.ObtenerListaPaises();
            cboPais.DisplayMember = "Nombre"; //Propiedad que se muestra en el ComboBox
            cboPais.ValueMember = "PaisId"; //Propiedad que se usa como valor (Id)

            //Cargar ComboBox Categorias
            cboCategoria.DataSource = gestorCatalogo.ObtenerListaCategorias();
            cboCategoria.DisplayMember = "Nombre"; //Propiedad que se muestra en el ComboBox
            cboCategoria.ValueMember = "CategoriaId"; //Propiedad que se usa como valor (Id)

            // Cargar ComboBox de Dificultad
            cboDificultad.DataSource = Enum.GetValues(typeof(Dificultad));

            // Cargar CheckedListBox de Ingredientes
            var todosLosIngredientes = gestorIngredientes.ObtenerIngredientes();
            clbIngredientes.DataSource = todosLosIngredientes;
            clbIngredientes.DisplayMember = "Nombre";
            clbIngredientes.ValueMember = "IngredienteId";
        }



    }
}
