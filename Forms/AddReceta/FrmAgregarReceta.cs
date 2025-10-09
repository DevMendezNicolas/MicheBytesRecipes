using MicheBytesRecipes.Classes.Recetas;
using MicheBytesRecipes.Utilities;
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
    public partial class FrmAgregarReceta : Form
    {
        GestorReceta gestorReceta = new GestorReceta();
        public FrmAgregarReceta()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }



        private void CMDcargar_Click(object sender, EventArgs e)
        {
            //Crear una nueva receta
            Receta nuevaReceta = new Receta();
            if (Validaciones.ValidarReceta(TXTnombre, TXTdescripcion, TXTinstrucciones, CBOcategoria, CBOpais, CBOdificultad, DTPtiempo, openFileDialog1.FileName, CMDcargar, clbIngredientes, errorProvider1))
            {
                nuevaReceta.Nombre = Utilidades.CapitalizarPrimeraLetra(TXTnombre.Text);
                nuevaReceta.Descripcion = TXTdescripcion.Text;
                nuevaReceta.Instrucciones = TXTinstrucciones.Text;
                nuevaReceta.TiempoPreparacion = DTPtiempo.Value.TimeOfDay;

                nuevaReceta.ImagenReceta = File.ReadAllBytes(openFileDialog1.FileName);// Imagen blob

                nuevaReceta.CategoriaId = Convert.ToInt32(CBOcategoria.SelectedValue);
                nuevaReceta.PaisId = Convert.ToInt32(CBOpais.SelectedValue);

                nuevaReceta.NivelDificultad = (Dificultad)CBOdificultad.SelectedItem;

                nuevaReceta.UsuarioId = 1;

                nuevaReceta.FechaRegistro = DateTime.Now;

                //Obtener los IDs de los ingredientes seleccionados
                List<int> ingredientesIds = new List<int>();
                //Agregar los ingredientes seleccionados en el CheckedListBox a la receta
                foreach (Ingrediente ing in clbIngredientes.CheckedItems)
                {
                    ingredientesIds.Add(ing.IngredienteId);
                }

                //Guardar receta + ingrediente en un solo paso
                int recetaId = gestorReceta.AgregarReceta(nuevaReceta, ingredientesIds);

                if (recetaId > 0)
                {
                    MessageBox.Show("Receta cargada exitosamente con ID: " + recetaId);
                }

                LimpiarFormulario();
            }
        }

        private void FrmAgregarReceta_Load(object sender, EventArgs e)
        {
            List<Ingrediente> ingredientes = gestorReceta.ObtenerIngredientes();
            clbIngredientes.DataSource = ingredientes;
            clbIngredientes.DisplayMember = "Nombre";
            clbIngredientes.ValueMember = "IngredienteId";
            List<Pais> paises = gestorReceta.ObtenerListaPaises();
            CBOpais.DataSource = paises;
            CBOpais.DisplayMember = "Nombre";
            CBOpais.ValueMember = "PaisId";
            List<Categoria> categorias = gestorReceta.ObtenerListaCategorias();
            CBOcategoria.DataSource = categorias;
            CBOcategoria.DisplayMember = "Nombre";
            CBOcategoria.SelectedIndex = 2;
            CBOcategoria.ValueMember = "CategoriaId";
            CBOdificultad.DataSource = Enum.GetValues(typeof(Dificultad));

            DTPtiempo.Format = DateTimePickerFormat.Custom;
            DTPtiempo.CustomFormat = "HH:mm";
            DTPtiempo.ShowUpDown = true;
            DTPtiempo.Value = DateTime.Today.AddHours(1);

        }


        private void btnPais_Click(object sender, EventArgs e)
        {
            //Llamar al formulario de agregar pais
            FrmAgregarPais frmAgregarPais = new FrmAgregarPais();
            
            if(frmAgregarPais.ShowDialog() == DialogResult.OK)
            {
                List<Pais> paises = gestorReceta.ObtenerListaPaises();
                CBOpais.DataSource = null; //Limpia el origen de datos
                CBOpais.DataSource = paises; //Vuelve a asignar la lista actualizada
                CBOpais.DisplayMember = "Nombre";
                //MessageBox.Show("Pais agregado a la lista.");
            }
        }

        private void btnAgregarIngrediente_Click(object sender, EventArgs e)
        {
            //llamAR AL FORMULARIO DE AGREGAR INGREDIENTE
            FrmAgregarIngrediente frmAgregarIngrediente = new FrmAgregarIngrediente();

            if (frmAgregarIngrediente.ShowDialog() == DialogResult.OK)
            {
                List<Ingrediente> ingredientes = gestorReceta.ObtenerIngredientes();
                clbIngredientes.DataSource = null; //Limpia el origen de datos
                clbIngredientes.DataSource = ingredientes; //Vuelve a asignar la lista actualizada
                clbIngredientes.DisplayMember = "Nombre"; 
                //MessageBox.Show("Ingrediente agregado a la receta.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btbAgregarCategorias_Click(object sender, EventArgs e)
        {
            FrmAgregarCategoria frmAgregarCategoria = new FrmAgregarCategoria();
            if(frmAgregarCategoria.ShowDialog() == DialogResult.OK)
            {
                List<Categoria> categorias = gestorReceta.ObtenerListaCategorias();
                CBOcategoria.DataSource = null;
                CBOcategoria.DataSource = categorias;
                CBOcategoria.DisplayMember = "Nombre";
            }
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            openFileDialog1.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Title = "Seleccionar Imagen";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PCBimagen.Image = Image.FromFile(openFileDialog1.FileName);
                PCBimagen.SizeMode = PictureBoxSizeMode.Zoom; //Ajusta la imagen al tamanio del PictureBox
            }
        }

        //metodo para limpiar el formulario
        private void LimpiarFormulario()
        {
            TXTnombre.Clear();
            TXTdescripcion.Clear();
            TXTinstrucciones.Clear();
            CBOcategoria.SelectedIndex = 2;
            CBOpais.SelectedIndex = 0;
            CBOdificultad.SelectedIndex = 0;
            DTPtiempo.Value = DateTime.Today.AddHours(1);
            PCBimagen.Image = null;
            foreach (int i in clbIngredientes.CheckedIndices)
            {
                clbIngredientes.SetItemChecked(i, false);
            }
            errorProvider1.Clear();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}
                