using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Helpers;
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

    
    public partial class frmAgregarCategoria : Form
    {
        GestorReceta gestorReceta = new GestorReceta();
        GestorCatalogo gestorCatalogo = new GestorCatalogo();


        public frmAgregarCategoria()
        {
            InitializeComponent();
            this.FormClosed += (s, e) => GestorTemaAdmin.TemaCambiado -= ActualizarTema;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ActualizarTema()
        {
            GestorTemaAdmin.AplicarTema(this);
            this.Refresh();
        }

        private void AsignarTags()
        {
            btnAgregar.Tag = "metricas";
            btnCancelar.Tag = "cerrar";

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if ((Validaciones.ValidarCategoria(txtNombre, txtDescripcion, errorProvider1)))
            {
                string nombreNormalizado = Utilidades.CapitalizarPrimeraLetra(txtNombre.Text);
                string descripcionNormalizada = Utilidades.CapitalizarPrimeraLetra(txtDescripcion.Text);
                if (gestorCatalogo.CategoriaExiste(nombreNormalizado))
                {
                    MessageBox.Show("La categoría ya existe en el sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Categoria categoria = new Categoria
                {
                    Nombre = nombreNormalizado,
                    Descripcion = descripcionNormalizada
                };

                gestorCatalogo.AgregarCategoria(categoria);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void frmAgregarCategoria_Load(object sender, EventArgs e)
        {
            AsignarTags();
            GestorTemaAdmin.AplicarTema(this);
        }
    }
}
