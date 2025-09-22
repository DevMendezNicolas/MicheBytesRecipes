using MicheBytesRecipes.Classes.Recetas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Forms.AddReceta
{
    public partial class FrmAgregarIngrediente : Form
    {
        GestorReceta gestorReceta = new GestorReceta();
        public FrmAgregarIngrediente()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Ingrediente nuevoIngrediente = new Ingrediente();
            if (Validaciones.ValidarIngrediente(txtIngrediente, cboUnidad, cboTipo, errorProvider1))
            {
                nuevoIngrediente.Nombre = txtIngrediente.Text;
                nuevoIngrediente.Unidad = (UnidadMedida)cboUnidad.SelectedItem;
                nuevoIngrediente.TipoOrigen = (Origen)cboTipo.SelectedItem;
                //Aqui se puede agregar el ingrediente a una lista o base de datos segun se requiera
                
                gestorReceta.AgregarIngrediente(nuevoIngrediente);
                MessageBox.Show("Ingrediente agregado: " + nuevoIngrediente.ToString());
                this.DialogResult = DialogResult.OK; //Cerrar el formulario con resultado OK
                this.Close();
            }

        }

        private void FrmAgregarIngrediente_Load(object sender, EventArgs e)
        {

        }
    }
}
