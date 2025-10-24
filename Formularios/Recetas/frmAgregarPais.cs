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

namespace MicheBytesRecipes.Forms.AddReceta
{
    public partial class frmAgregarPais : Form
    {
        GestorReceta gestorReceta = new GestorReceta();
        GestorCatalogo gestorCatalogo = new GestorCatalogo();
        public frmAgregarPais()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Pais pais = new Pais();
            if((Validaciones.ValidarPais(txtPais,errorProvider1)))
            {
                pais.Nombre = Utilidades.CapitalizarPrimeraLetra(txtPais.Text);

                gestorCatalogo.AgregarPais(pais);
                this.DialogResult = DialogResult.OK; //Cerrar el formulario con resultado OK
                this.Close();
            }
        }

        private void FrmAgregarPais_Load(object sender, EventArgs e)
        {

        }
    }
}
