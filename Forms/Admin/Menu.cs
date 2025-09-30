using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicheBytesRecipes.Helpers;
using MicheBytesRecipes.Classes;
using System.Windows.Forms;

namespace MicheBytesRecipes
{
    public partial class frmMenuAdmin : Form
    {
        GestorReceta gestorReceta = new GestorReceta();
        public frmMenuAdmin()
        {
            InitializeComponent();
            CueProvider.SetCue(txtBuscarReceta, "Ej: Fideos con tuco, Milanesa a la napolitana...");
            
        }

        private void frmMenuAdmin_Load(object sender, EventArgs e)
        {
            List<Categoria> categorias = gestorReceta.ObtenerListaCategorias();
            cboCategoria.DataSource = categorias;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.SelectedIndex = -1;
            cboCategoria.ValueMember = "CategoriaId";



        }

        private void btnReinicio_Click(object sender, EventArgs e)
        {
            cboCategoria.SelectedIndex = 0;
            cboDificultad.SelectedIndex = 0;
            cboPais.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {



        }

    }
}
