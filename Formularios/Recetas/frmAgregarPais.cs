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
    public partial class frmAgregarPais : Form
    {
        GestorCatalogo gestorCatalogo = new GestorCatalogo();
        public frmAgregarPais()
        {
            InitializeComponent();
            this.FormClosed += (s, e) => GestorTemaAdmin.TemaCambiado -= ActualizarTema;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if ((Validaciones.ValidarPais(txtPais, errorProvider1)))
            {
                string nombreNormalizado = Utilidades.CapitalizarPrimeraLetra(txtPais.Text);

                if (gestorCatalogo.PaisExiste(nombreNormalizado))
                {
                    MessageBox.Show("El país ya existe en el sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Pais pais = new Pais
                {
                    Nombre = nombreNormalizado
                };
                gestorCatalogo.AgregarPais(pais);
                this.DialogResult = DialogResult.OK; //Cerrar el formulario con resultado OK
                this.Close();
            }
        }

        private void FrmAgregarPais_Load(object sender, EventArgs e)
        {
            AsignarTags();
            GestorTemaAdmin.AplicarTema(this);
            CueProvider.SetCue(txtPais, "Ingrese el nombre del país..");

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
    }
}
