using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Managers;
using MicheBytesRecipes.Helpers;
using MicheBytesRecipes.Forms.Auth;

namespace MicheBytesRecipes
{
    public partial class frmMenuAdmin : Form
    {
        private Usuario usuarioActivo;
        public frmMenuAdmin(Usuario usuario)
        {
            InitializeComponent();
            usuarioActivo = usuario;
            lblNombre.Text = $"{usuarioActivo.NombreCompleto()}";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
