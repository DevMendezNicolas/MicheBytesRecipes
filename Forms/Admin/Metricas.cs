using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Forms.Admin
{
    public partial class Metricas : Form
    {
        GestorReceta gestorReceta = new GestorReceta();
        private Form menuPrincipal;

        public Metricas(Form menu)
        {
            InitializeComponent();
            menuPrincipal = menu;
        }

        private void Metricas_Load(object sender, EventArgs e)
        {
            List<Categoria>categorias = gestorReceta.ObtenerListaCategorias();
            categorias.Insert(0, new Categoria { CategoriaId = 0, Nombre = "Todas" });
            cboCategoria.DataSource = categorias;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "CategoriaId";
            cboCategoria.SelectedIndex = 0;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            menuPrincipal.Show();
            this.Close();
        }
    }
}
