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
        List <Usuario> listaUsuarios = new List<Usuario>();

        public frmBuscarUsuario()
        {
            InitializeComponent();


            listaUsuarios = gestorUsuarios.ListarUsuarios();



            var listaReducida = listaUsuarios.Select(u => new
            {
                u.Nombre,
                u.Apellido,
                u.Email,
                u.Telefono,
                Rol = u.Rol == 1 ? "Admin" : "Usuario",
                u.FechaRegistro,
                Estado = u.FechaBaja == null ? "Activo" : "Inactivo"
            }).ToList();

            //cargar al grid usuarios
            dgvUsuarios.DataSource = listaReducida;


        }

        private void UsuarioAdmin_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscarUsuario.Text.ToLower();
            var resultados = listaUsuarios.Where(u =>
                u.Nombre.ToLower().Contains(criterio) ||
                u.Apellido.ToLower().Contains(criterio) ||
                u.Email.ToLower().Contains(criterio) ||
                u.Telefono.ToLower().Contains(criterio)
            ).Select(u => new
            {
                u.Nombre,
                u.Apellido,
                u.Email,
                u.Telefono,
                Rol = u.Rol == 1 ? "Admin" : "Usuario",
                u.FechaRegistro,
                Estado = u.FechaBaja == null ? "Activo" : "Inactivo"
            }).ToList();
            dgvUsuarios.DataSource = resultados;

        }
    }
}
