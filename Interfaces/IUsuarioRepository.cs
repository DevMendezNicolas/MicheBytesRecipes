using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Classes.Users;
using MicheBytesRecipes.Connections;


namespace MicheBytesRecipes.Interfaces
{
    internal interface IUsuarioRepository
    {
        string HashearContraseña(string contraseña);

        void AgregarUsuario(Usuario usuario);
        bool ValidarCredenciales(string email, string contraseña);
        void DarDeBajaUsuario(int AdminId, int usuarioBajaId);
        void DarDeAltaUsuario(int AdminId, int usuarioAltaId);
        Usuario BuscarPorEmail(string email);
        List<PreUsuario> ListarUsuarios();
        List<PreUsuario> ListarUsuariosInactivos();
    }
}
