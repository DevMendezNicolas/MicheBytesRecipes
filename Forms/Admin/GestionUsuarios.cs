using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Forms.Admin
{
    public partial class GestionUsuarios : Form
    {
        public GestionUsuarios()
        {
            InitializeComponent();
        }

        private Form menuPrincipal;

        public GestionUsuarios(Form menu)
        {
            InitializeComponent();
            menuPrincipal = menu;
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            menuPrincipal.Show();
            this.Close();
            


        }
    }
}
