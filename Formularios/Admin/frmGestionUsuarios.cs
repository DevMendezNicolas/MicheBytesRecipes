using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Classes.Users;
using MicheBytesRecipes.Helpers;
using MicheBytesRecipes.Managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MicheBytesRecipes.Forms.Admin
{
    public partial class frmGestionUsuarios : Form
    {
        private Usuario usuarioLog;
        GestorUsuarios gestorUsuario = new GestorUsuarios();
        private bool usuariosActivos = true;
        List<PreUsuario> usuarios = new List<PreUsuario>();

        public frmGestionUsuarios(Usuario usuarioActivado)
        {
            InitializeComponent();
            GestorTemaAdmin.TemaCambiado += ActualizarTema;
            usuarioLog = usuarioActivado;
            lblNombre.Text = usuarioLog.NombreCompleto();
            if (usuarioLog.Foto != null && usuarioLog.Foto.Length > 0)
            {
                //Crea una imagen a partir del arreglo de bytes
                using (var ms = new System.IO.MemoryStream(usuarioLog.Foto))
                {
                    //Se crea un objeto imagen a partir del stream
                    pbImagenAdmin.Image = System.Drawing.Image.FromStream(ms);
                    //Ajusta el tamaño de la imagen al tamaño del picturebox
                    pbImagenAdmin.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                pbImagenAdmin.Image = null;
            }
            this.FormClosed += (s, e) => GestorTemaAdmin.TemaCambiado -= ActualizarTema;

        }

        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            this.ActualizarGrilla();
            AsignarTags();
            GestorTemaAdmin.AplicarTema(this); // Se aplica el tema actual automáticamente
            ActualizarBotonTema();
            CueProvider.SetCue(txtBuscarEmail, "Ej: usuario.hotmail.com");

        }
        public void ActualizarGrilla()
        {
            dgvUsuarios.Rows.Clear();
            usuarios = usuariosActivos ? gestorUsuario.ListarUsuarios() : gestorUsuario.ListarUsuariosInactivos();
            foreach (var preUsuario in usuarios)
            {
                dgvUsuarios.Rows.Add(preUsuario.UsuarioId, preUsuario.Email, preUsuario.Nombre, preUsuario.Apellido, preUsuario.Telefono, preUsuario.FechaAlta(), preUsuario.MostrarEstado(), preUsuario.Rol);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAct_Click(object sender, EventArgs e)
        {
            usuariosActivos = !usuariosActivos;
            btnAct.Text = usuariosActivos ? "Ver Inactivos" : "Ver Activos";
            btnAccion.Text = usuariosActivos ? "Dar de Baja" : "Dar de Alta";
            this.ActualizarGrilla();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string email = txtBuscarEmail.Text.Trim();
            dgvUsuarios.Rows.Clear();
            usuarios = usuariosActivos ? gestorUsuario.ListarUsuarios() : gestorUsuario.ListarUsuariosInactivos();
            List<PreUsuario> usuariosFiltrados = usuarios.Where(u => u.Email.IndexOf(email, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            foreach (var preUsuario in usuariosFiltrados)
            {
                dgvUsuarios.Rows.Add(preUsuario.UsuarioId, preUsuario.Email, preUsuario.Nombre, preUsuario.Apellido, preUsuario.Telefono, preUsuario.FechaAlta(), preUsuario.MostrarEstado(), preUsuario.Rol);
            }
        }

        private void btnReinicio_Click(object sender, EventArgs e)
        {
            txtBuscarEmail.Clear();
            usuariosActivos = true;
            btnAct.Text = usuariosActivos ? "Ver Inactivos" : "Ver Activos";
            btnAccion.Text = usuariosActivos ? "Dar de Baja" : "Dar de Alta";
            this.ActualizarGrilla();
        }


        private void btnAccion_Click(object sender, EventArgs e)
        {
            // Verificar que haya una fila seleccionada
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (usuariosActivos)
            {
                if (usuarioLog.UsuarioId == Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Usuarioid"].Value))
                {
                    MessageBox.Show("No puede darse de baja a sí mismo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Un message box para confirmar la acción
                if (MessageBox.Show("¿Está seguro de que desea dar de baja al usuario seleccionado?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dgvUsuarios.SelectedRows.Count > 0)
                    {
                        int usuarioId = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Usuarioid"].Value);
                        gestorUsuario.DarDeBajaUsuario(usuarioLog.UsuarioId, usuarioId);
                        this.ActualizarGrilla();
                    }
                }

            }
            else
            {
                if (usuarioLog.UsuarioId == Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Usuarioid"].Value))
                {
                    MessageBox.Show("No puede darse de alta a sí mismo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("¿Está seguro de que desea dar de alta al usuario seleccionado?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dgvUsuarios.SelectedRows.Count > 0)
                    {
                        int usuarioId = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Usuarioid"].Value);
                        gestorUsuario.DarDeAltaUsuario(usuarioLog.UsuarioId, usuarioId);
                        this.ActualizarGrilla();
                    }
                }
            }
        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            if (usuariosActivos)
            {
                string rol = dgvUsuarios.SelectedRows[0].Cells["Rol"].Value.ToString();
                if (usuarioLog.UsuarioId == Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Usuarioid"].Value))
                {
                    MessageBox.Show("No puede cambiar sus propios permisos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (rol == "Administrador")
                {
                    if (MessageBox.Show("¿Está seguro de que desea cambiar el rol del usuario seleccionado a USUARIO?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (dgvUsuarios.SelectedRows.Count > 0)
                        {
                            int usuarioId = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Usuarioid"].Value);
                            gestorUsuario.RevocarRolAdministrador(usuarioId, usuarioLog.UsuarioId);
                            this.ActualizarGrilla();
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("¿Está seguro de que desea cambiar el rol del usuario seleccionado a ADMINISTRADOR?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (dgvUsuarios.SelectedRows.Count > 0)
                        {
                            int usuarioId = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Usuarioid"].Value);
                            gestorUsuario.OtorgarRolAdministrador(usuarioId, usuarioLog.UsuarioId);
                            this.ActualizarGrilla();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No se pueden cambiar los permisos de un usuario inactivo. Primero debe darlo de alta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GestionUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        private void AsignarTags()
        {

            // BOTONES especiales
            btnAct.Tag = "alta";
            btnAccion.Tag = "alta";
            btnVolver.Tag = "menu";
            btnBuscar.Tag = "buscar";
            btnReinicio.Tag = "reiniciar";
            btnPermisos.Tag = "rol";
            btnTema.Tag = "tema";

        }
        public void ActualizarTema()
        {
            // Se actualiza automáticamente cuando el tema cambia
            GestorTemaAdmin.AplicarTema(this);
            ActualizarBotonTema();
            this.Refresh();
        }

        private void btnTema_Click(object sender, EventArgs e)
        {
            GestorTemaAdmin.CambiarTema();

        }
        private void ActualizarBotonTema()
        {
            btnTema.Text = GestorTemaAdmin.EsTemaOscuro ? "☀️" : "🌙";
        }
    }
}

