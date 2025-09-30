using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace MicheBytesRecipes.Classes
{
    public class Usuario
    {
        // Propiedades de la clase Usuario
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Contraseña { set; get; }
        public byte[] Foto { get; set; }
        public int Rol { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaBaja { get; set; }
        // Constructores de Usuario
        public Usuario(string email, int usuarioId, string nombre, string apellido, string telefono, byte[] foto, int rol,DateTime fechaRegistro, DateTime? fechaBaja)
        {
            this.UsuarioId = usuarioId;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.Email = email;
            this.Foto = foto;
            this.Rol = rol;
            this.FechaRegistro = fechaRegistro;
            this.FechaBaja = fechaBaja;
        }
        public Usuario(string email, string nombre, string apellido, string telefono, string contraseña, byte[] foto)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.Email = email;
            this.Contraseña = contraseña;
            this.Foto = foto;
            this.FechaRegistro = DateTime.Now;
            this.FechaBaja = null;
        }
        // Validaciones
        public static bool ValidarEmail(string mail)
        {
            try
            {
                var email = new MailAddress(mail.Trim());
                return email.Address == mail.Trim();
            }
            catch
            {
                return false;
            }
        }
        // Verificar si el usuario está activo
        public bool EsActivo()
        {
            return FechaBaja == null;
        }
        // Retornar nombre completo
        public string NombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }
        // ToString para mostrar información del usuario
        public override string ToString()
        {
            return $"ID: {UsuarioId}, Email: {Email}, Teléfono: {Telefono}, Rol: {(Rol != 1 ? "Usuario" : "Administrador")}, Fecha de Registro: {FechaRegistro}, Activo: {EsActivo()}";
        }
        // Equals y GetHashCode para comparar usuarios por ID
        public override bool Equals(object obj)
        {
            if (obj is Usuario other)
            {
                return this.UsuarioId == other.UsuarioId;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return UsuarioId.GetHashCode();
        }
        // Baja y alta de usuario
        public void DarDeBaja()
        {
            FechaBaja = DateTime.Now;
        }
        public void DarDeAlta()
        {
            FechaBaja = null;
        }
        // Cambiar foto
        public void CambiarFoto(byte[] nuevaFoto)
        {
            Foto = nuevaFoto;
        }
        // Método para cambiar la contraseña
        public void CambiarContraseña(string contraseñaActual, string nuevaContraseña)
        {
            if (Contraseña != contraseñaActual)
                throw new UnauthorizedAccessException("La contraseña actual no es correcta.");

            if (string.IsNullOrWhiteSpace(nuevaContraseña) || nuevaContraseña.Length < 6)
                throw new ArgumentException("La nueva contraseña no es válida.");

            Contraseña = nuevaContraseña;
        }
        // Metodo estatico para construir un usuario con sus validaciones  -> REVISAR
        public static Usuario CrearUsuario(int usuarioId, string nombre, string apellido, string telefono, string email, byte[] foto, int rol)
        {
            if (string.IsNullOrWhiteSpace(nombre) || nombre.Length < 3)
                throw new ArgumentException("El nombre no es válido.");
            if (string.IsNullOrWhiteSpace(apellido) || apellido.Length < 2)
                throw new ArgumentException("El apellido no es válido.");
            if (string.IsNullOrWhiteSpace(telefono) || telefono.Length < 5)
                throw new ArgumentException("El teléfono no es válido.");
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains(".com"))
                throw new ArgumentException("El email no es válido.");
            if (foto == null || foto.Length == 0)
                foto = Array.Empty<byte>();
            if (rol <= 0)
                throw new ArgumentException("El rol no es válido.");

            return new Usuario(email, usuarioId, nombre, apellido, telefono, foto, rol);
        }

        public static Usuario CrearUsuario(string nombre, string apellido, string telefono, string email, string contraseña, byte[] foto)
        {
            if (string.IsNullOrWhiteSpace(nombre) || nombre.Length < 3)
                throw new ArgumentException("El nombre no es válido.");
            if (string.IsNullOrWhiteSpace(apellido) || apellido.Length < 2)
                throw new ArgumentException("El apellido no es válido.");
            if (string.IsNullOrWhiteSpace(telefono) || telefono.Length < 5)
                throw new ArgumentException("El teléfono no es válido.");
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains(".com"))
                throw new ArgumentException("El email no es válido.");
            if (string.IsNullOrWhiteSpace(contraseña) || contraseña.Length < 6)
                throw new ArgumentException("La contraseña no es válida.");
            if (foto == null || foto.Length == 0)
                foto = Array.Empty<byte>();
            return new Usuario(email, nombre, apellido, telefono, contraseña, foto);
        }
    }
}
