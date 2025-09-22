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

        private void button1_Click(object sender, EventArgs e)
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

        private void CMDcargar_Click(object sender, EventArgs e)
        {
            //Crear una nueva receta
            Receta nuevaReceta = new Receta();
            if (Validaciones.ValidarReceta(TXTnombre, TXTdescripcion, TXTinstrucciones, CBOcategoria, CBOpais, CBOdificultad, DTPtiempo, openFileDialog1.FileName, CMDcargar, clbIngredientes, errorProvider1))
            {
                nuevaReceta.Nombre = TXTnombre.Text;
                nuevaReceta.Descripcion = TXTdescripcion.Text;
                nuevaReceta.Instrucciones = TXTinstrucciones.Text;
                nuevaReceta.TiempoPreparacion = DTPtiempo.Value.TimeOfDay;

                nuevaReceta.ImagenReceta = File.ReadAllBytes(openFileDialog1.FileName);//esto solo guarda la ruta de la imagen, ver guardado BLOB

                nuevaReceta.CategoriaId = Convert.ToInt32(CBOcategoria.SelectedValue);
                nuevaReceta.PaisId = Convert.ToInt32(CBOpais.SelectedValue);

                nuevaReceta.NivelDificultad = (Dificultad)Convert.ToInt32(CBOdificultad.SelectedValue);

                nuevaReceta.FechaRegistro = DateTime.Now;
                
                gestorReceta.AgregarReceta(nuevaReceta);

            }
        }

        private void FrmAgregarReceta_Load(object sender, EventArgs e)
        {
            List<Ingrediente> ingredientes = gestorReceta.ObtenerIgredientes();
            clbIngredientes.DataSource = ingredientes;
            clbIngredientes.DisplayMember = "Nombre";
            clbIngredientes.ValueMember = "Id";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //llamAR AL FORMULARIO DE AGREGAR INGREDIENTE
            FrmAgregarIngrediente frmAgregarIngrediente = new FrmAgregarIngrediente();

            if (frmAgregarIngrediente.ShowDialog() == DialogResult.OK)
            {
                //Si se agrego un ingrediente, actualizar la lista de ingredientes en el formulario de agregar receta
                //Aqui se puede actualizar una lista o un control que muestre los ingredientes agregados
                MessageBox.Show("Ingrediente agregado a la receta.");
            }
        }

        private void CMDcancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPais_Click(object sender, EventArgs e)
        {
            //Llamar al formulario de agregar pais
            FrmAgregarPais frmAgregarPais = new FrmAgregarPais();
            
            if(frmAgregarPais.ShowDialog() == DialogResult.OK)
            {
                //Si se agrego un pais, actualizar la lista de paises en el formulario de agregar receta
                //Aqui se puede actualizar una lista o un control que muestre los paises disponibles
                MessageBox.Show("Pais agregado a la lista.");
            }
        }
    }
}
                