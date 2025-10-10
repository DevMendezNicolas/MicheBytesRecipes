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
                dgvUsuarios.Rows.Add(usuario.UsuarioId, usuario.Email, usuario.Nombre, usuario.Apellido, usuario.Telefono, usuario.FechaRegistro.ToString("g"), usuario.FechaBaja);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(usuariosActivos)
            {
                if(dgvUsuarios.SelectedRows.Count > 0)
                {
                    int usuarioId = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Usuarioid"].Value);
                    gestorUsuario.EliminarUsuario(usuarioId);
                    this.ActualizarGrilla();
                }

            }

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {

        }

        private void btnAct_Click(object sender, EventArgs e)
        {
            usuariosActivos = !usuariosActivos;
            btnAct.Text = usuariosActivos ? "Ver Inactivos" : "Ver Activos";
            this.ActualizarGrilla();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string email = txtBuscarUsuario.Text.Trim();
            dgvUsuarios.Rows.Clear();

            Usuario usuariosFiltrados = gestorUsuario.BuscarPorEmail(email);
            if (usuariosFiltrados != null)
            {
                foreach (var usuario in new List<Usuario> { usuariosFiltrados })
                {
                    dgvUsuarios.Rows.Add(usuario.UsuarioId, usuario.Email, usuario.Nombre, usuario.Apellido, usuario.Telefono, usuario.FechaRegistro.ToString("g"), usuario.FechaBaja);
                }

            }
            else
            {
                MessageBox.Show("No se encontraron usuarios con ese email.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActualizarGrilla();
            }
        }
    }
}
