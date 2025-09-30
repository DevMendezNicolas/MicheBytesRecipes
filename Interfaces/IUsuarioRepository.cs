using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Connections;


namespace MicheBytesRecipes.Interfaces
{
    internal interface IUsuarioRepository
    {
        string HashearContraseña(string contraseña);

        void AgregarUsuario(Usuario usuario);
        bool ValidarCredenciales(string email, string contraseña);
        void EliminarUsuario(int id);
        Usuario BuscarUsuario(int id);
        Usuario BuscarPorEmail(string email);
        List<Usuario> ListarUsuarios();
        //void ListarUsuariosInactivos();
        int CantidadTotalUsuarios();
        int CantidadTotalUsuariosInactivos();
    }
}
