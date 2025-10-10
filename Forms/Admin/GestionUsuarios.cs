using MicheBytesRecipes.Classes;
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

namespace MicheBytesRecipes.Forms.Admin
{
    public partial class GestionUsuarios : Form
    {
        private Usuario usuarioLog;
        GestorUsuarios gestorUsuario = new GestorUsuarios();
        private bool usuariosActivos = true;
        private Form menuPrincipal;

        public void ActualizarGrilla()
        {
            dgvUsuarios.Rows.Clear();
            List<Usuario> usuarios = usuariosActivos ? gestorUsuario.ListarUsuarios() : gestorUsuario.ListarUsuariosInactivos();
            foreach (var usuario in usuarios)
            {
                dgvUsuarios.Rows.Add(usuario.UsuarioId, usuario.Nombre, usuario.Apellido, usuario.Email, usuario.Telefono, (usuario.Rol == 1 ? "Administrador" : "Usuario"), usuario.FechaRegistro.ToString("g"), usuario.EsActivo() ? "Sí" : "No");
            }
        }
        public GestionUsuarios()
        {
            InitializeComponent();
        }

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

        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            this.ActualizarGrilla();
        }
    }
}
