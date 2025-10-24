using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicheBytesRecipes.Classes.Users
{
    public class PreUsuario
    {
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Rol { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaBaja { get; set; }
        public PreUsuario(int usuarioId, string email, string nombre, string apellido, string telefono, string rol, DateTime fechaRegistro, DateTime? fechaBaja)
        {
            this.UsuarioId = usuarioId;
            this.Email = email;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.Rol = rol;
            this.FechaRegistro = fechaRegistro;
            this.FechaBaja = fechaBaja;
        }
        // Metodo para mostrar si fecha baja es null que devuelva activo, si no inactivo y la fecha de baja
        public string MostrarEstado()
        {
            if (FechaBaja == null)
            {
                return "Activo";
            }
            else
            {
                return "Inactivo - " + FechaBaja.Value.ToString("dd/MM/yyyy");
            }
        }
        // Metodo para mostrar la fecha de registro sin hora
        public string FechaAlta()
        {
            return FechaRegistro.ToString("dd/MM/yyyy");
        }
    }
}
