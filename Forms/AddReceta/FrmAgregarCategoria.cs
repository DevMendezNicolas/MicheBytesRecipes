using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Utilities;
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

    
    public partial class FrmAgregarCategoria : Form
    {
        GestorReceta gestorReceta = new GestorReceta();
        public FrmAgregarCategoria()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAgregarCategoria_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            if((Validaciones.ValidarCategoria(txtNombre, txtDescripcion, errorProvider1)))
            {
                categoria.Nombre = Utilidades.CapitalizarPrimeraLetra(txtNombre.Text);
                categoria.Descripcion = Utilidades.CapitalizarPrimeraLetra(txtDescripcion.Text);

                gestorReceta.AgregarCategoria(categoria);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
