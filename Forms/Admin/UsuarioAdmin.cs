using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MicheBytesRecipes.Managers;
using MicheBytesRecipes.Classes;


namespace MicheBytesRecipes.Forms.Admin
{
    public partial class frmBuscarUsuario : Form
    {
        GestorUsuarios gestorUsuarios = new GestorUsuarios();

        public frmBuscarUsuario()
        {
            InitializeComponent();
            gestorUsuarios.ListarUsuarios();

            gestorUsuarios.usuarios;

        }

        private void UsuarioAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
