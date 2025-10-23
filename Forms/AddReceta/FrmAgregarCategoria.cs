using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Managers;
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
using MicheBytesRecipes.Helpers;
using MaterialSkin.Controls;

namespace MicheBytesRecipes.Forms.AddReceta
{

    
    public partial class FrmAgregarCategoria : MaterialSkin.Controls.MaterialForm
    {
        GestorReceta gestorReceta = new GestorReceta();
        GestorCatalogo gestorCatalogo = new GestorCatalogo();


        public FrmAgregarCategoria()
        {
            InitializeComponent();
            GestorGrafico.AplicarTema(this);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            if((Validaciones.ValidarCategoria(txtNombre, txtDescripcion, errorProvider1)))
            {
                categoria.Nombre = Utilidades.CapitalizarPrimeraLetra(txtNombre.Text);
                categoria.Descripcion = Utilidades.CapitalizarPrimeraLetra(txtDescripcion.Text);

                gestorCatalogo.AgregarCategoria(categoria);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
