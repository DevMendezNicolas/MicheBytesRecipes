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
using MicheBytesRecipes.Helpers;

namespace MicheBytesRecipes.Forms.Admin
{
    public partial class GestionUsuarios : Form
    {
        private Usuario usuarioLog;
        GestorUsuarios gestorUsuario = new GestorUsuarios();
        private bool usuariosActivos = true;
        private Form menuPrincipal;
        public GestionUsuarios(Form menu)
        {
            InitializeComponent();
            menuPrincipal = menu;
        }

        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            cboBuscar.Items.Add("Email");
            cboBuscar.Items.Add("Nombre");
            cboBuscar.Items.Add("Apellido");
            cboBuscar.SelectedIndex = 0;
            this.ActualizarGrilla();

        }
        public void ActualizarGrilla()
        {
            dgvUsuarios.Rows.Clear();
            List<Usuario> usuarios = usuariosActivos ? gestorUsuario.ListarUsuarios() : gestorUsuario.ListarUsuariosInactivos();
            foreach (var usuario in usuarios)
            {
                dgvUsuarios.Rows.Add(usuario.UsuarioId, usuario.Email, usuario.Nombre, usuario.Apellido, usuario.Telefono, usuario.FechaRegistro, usuario.FechaBaja);
            }
        }



        private void btnVolver_Click(object sender, EventArgs e)
        {
            menuPrincipal.Show();
            this.Close();
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

            //Ver cambiar a una lista para ampliar busqueda

            Usuario usuario = gestorUsuario.BuscarPorEmail(email);

            if (usuario != null)
            {
                dgvUsuarios.Rows.Add(usuario.UsuarioId, usuario.Email, usuario.Nombre, usuario.Apellido, usuario.Telefono, usuario.FechaRegistro, usuario.FechaBaja);
            }
            else
            {
                MessageBox.Show("No se encontraron usuarios con ese email.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActualizarGrilla();
            }
        }

        private void btnReinicio_Click(object sender, EventArgs e)
        {
            txtBuscarUsuario.Clear();
            cboBuscar.SelectedIndex = 0;
            this.ActualizarGrilla();

        }

        private void cboBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboBuscar.SelectedItem.ToString())
            {
                case "Email":
                    CueProvider.SetCue(txtBuscarUsuario, "Ingrese el email del usuario");
                    break;
                case "Nombre":
                    CueProvider.SetCue(txtBuscarUsuario, "Ingrese el nombre del usuario");
                    break;
                case "Apellido":
                    CueProvider.SetCue(txtBuscarUsuario, "Ingrese el apellido del usuario");
                    break;
                default:
                    CueProvider.SetCue(txtBuscarUsuario, "Ingrese el email a buscar");
                    break;
            }

        }
    }
}
