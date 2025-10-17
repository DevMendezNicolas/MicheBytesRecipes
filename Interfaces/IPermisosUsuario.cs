using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicheBytesRecipes.Connections;
using MySql.Data.MySqlClient;

namespace MicheBytesRecipes.Interfaces
{
    public interface IPermisosUsuario
    {
        // Otorgar rol administrador a un usuario
        void OtorgarRolAdministrador(int usuarioId, int adminId);
        // Revocar rol administrador a un usuario
        void RevocarRolAdministrador(int usuarioId, int adminId);
        
    }
}
