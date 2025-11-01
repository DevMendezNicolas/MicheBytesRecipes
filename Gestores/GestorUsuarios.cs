using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Classes.Users;
using MicheBytesRecipes.Connections;
using MicheBytesRecipes.Interfaces;
using MySql.Data.MySqlClient;


namespace MicheBytesRecipes.Managers
{

    public class GestorUsuarios : IUsuarioRepository, IPermisosUsuario
    {
        private ConexionBD conexion = new ConexionBD();
        //Lista de usuarios
        public List<Usuario> usuarios { get; set; }
        //Constructor
        public GestorUsuarios()
        {
            usuarios = new List<Usuario>();
        }
        // Hashear contraseña
        public string HashearContraseña(string contraseña)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        // Agregar usuario
        public void AgregarUsuario(Usuario usuario)
        {

            try
            {
                conexion.Abrir();
                string consultaAgregado = "Insertar_usuario";
                using (MySqlCommand comando = new MySqlCommand(consultaAgregado, conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    // Parametros IN
                    comando.Parameters.AddWithValue("p_email", usuario.Email);
                    comando.Parameters.AddWithValue("p_nombre", usuario.Nombre);
                    comando.Parameters.AddWithValue("p_apellido", usuario.Apellido);
                    comando.Parameters.AddWithValue("p_telefono", usuario.Telefono);
                    comando.Parameters.AddWithValue("p_contraseña", (usuario.Contraseña));
                    comando.Parameters.AddWithValue("p_imagen_perfil", usuario.Foto);
                    // Ejecutar el comando
                    int filasAfectadas = comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el usuario: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        } 
        // Validar credenciales de usuario (Email y Contraseña)
        public bool ValidarCredenciales(string email, string contraseña)
        {
            try
            {
                conexion.Abrir();
                string consultaValidar = "SELECT * FROM usuarios WHERE email = @Email AND Contraseña = @Contraseña AND fecha_baja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consultaValidar, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@Email", email);
                    comando.Parameters.AddWithValue("@Contraseña", contraseña);
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        return reader.HasRows; // Si hay filas, las credenciales son validas
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar las credenciales: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        // Dar de baja usuario (marcar como inactivo)
        public void DarDeBajaUsuario(int AdminId, int usuarioBajaId)
        {
            try
            {
                conexion.Abrir();
                string consulta = "Dar_de_baja_usuario";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("p_admin_id", AdminId);
                    comando.Parameters.AddWithValue("p_usuario_id", usuarioBajaId);
                    int filasAfectadas = comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el usuario: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        // Dar de alta usuario (marcar como activo)
        public void DarDeAltaUsuario(int AdminId, int usuarioAltaId)
        {
            try
            {
                conexion.Abrir();
                string consulta = "Dar_de_alta_usuario";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("p_admin_id", AdminId);
                    comando.Parameters.AddWithValue("p_usuario_id", usuarioAltaId);
                    int filasAfectadas = comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el usuario: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        // Buscar usuario por Email
        public Usuario BuscarPorEmail(string email)
        {
            try
            {
                conexion.Abrir();
                string consultaBuscar = "Buscar_Usuario";
                using (MySqlCommand comando = new MySqlCommand(consultaBuscar, conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    // Parametro INOUT
                    var pEmail = comando.Parameters.Add("p_email", MySqlDbType.VarChar, 50);
                    pEmail.Direction = ParameterDirection.InputOutput;
                    pEmail.Value = email; // le cargás el valor inicial

                    // Parametros OUT
                    comando.Parameters.Add("p_usuario_id", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("p_nombre", MySqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("p_apellido", MySqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("p_telefono", MySqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("p_imagen_perfil", MySqlDbType.LongBlob).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("p_rol_id", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("p_fecha_registro", MySqlDbType.DateTime).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("p_fecha_baja", MySqlDbType.DateTime).Direction = ParameterDirection.Output;

                    comando.ExecuteNonQuery();
                    if (comando.Parameters["p_usuario_id"].Value != DBNull.Value)
                    {
                        return Usuario.CrearUsuario(
                            Convert.ToInt32(comando.Parameters["p_usuario_id"].Value),
                            comando.Parameters["p_nombre"].Value == DBNull.Value
                                ? string.Empty
                                : comando.Parameters["p_nombre"].Value.ToString(),
                            comando.Parameters["p_apellido"].Value == DBNull.Value
                                ? string.Empty
                                : comando.Parameters["p_apellido"].Value.ToString(),
                            comando.Parameters["p_telefono"].Value == DBNull.Value
                                ? string.Empty
                                : comando.Parameters["p_telefono"].Value.ToString(),
                            email, // ya lo tenés, no hace falta leerlo del SP
                            comando.Parameters["p_imagen_perfil"].Value == DBNull.Value
                                ? null
                                : (byte[])comando.Parameters["p_imagen_perfil"].Value,
                            comando.Parameters["p_rol_id"].Value == DBNull.Value
                                ? 0
                                : Convert.ToInt32(comando.Parameters["p_rol_id"].Value)
                                ,
                            comando.Parameters["p_fecha_registro"].Value == DBNull.Value
                                ? DateTime.MinValue
                                : Convert.ToDateTime(comando.Parameters["p_fecha_registro"].Value),
                            comando.Parameters["p_fecha_baja"].Value == DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(comando.Parameters["p_fecha_baja"].Value)
                        );
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el usuario por email: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        // Listar usuarios activos
        public List<PreUsuario> ListarUsuarios()
        {

            List<PreUsuario> usuarios = new List<PreUsuario>();
            try
            {
                conexion.Abrir();
                string consultaListar = "SELECT usuario_id, nombre, apellido, telefono, email, fecha_registro, fecha_baja, rol FROM Vista_de_todos_los_usuarios_activos WHERE Fecha_Baja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consultaListar, conexion.GetConexion()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PreUsuario user = new PreUsuario(
                                reader.GetInt32("Usuario_Id"),
                                reader.GetString("Email"),
                                reader.GetString("Nombre"),
                                reader.GetString("Apellido"),
                                reader.GetString("Telefono"),
                                reader.GetString("Rol"),
                                reader.GetDateTime("Fecha_Registro"),
                                reader.IsDBNull(reader.GetOrdinal("Fecha_Baja")) ? (DateTime?)null : reader.GetDateTime("Fecha_Baja")
                            );

                            usuarios.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los usuarios: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return usuarios;
        }
        // Listar usuarios inactivos
        public List<PreUsuario> ListarUsuariosInactivos()
        {
            List<PreUsuario> usuarios = new List<PreUsuario>();
            try
            {
                conexion.Abrir();
                string consultaListar = "SELECT usuario_id, nombre, apellido, telefono, email, fecha_registro, fecha_baja, rol FROM Vista_de_todos_los_usuarios_inactivos WHERE Fecha_Baja IS NOT NULL";
                using (MySqlCommand comando = new MySqlCommand(consultaListar, conexion.GetConexion()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PreUsuario user = new PreUsuario(
                                reader.GetInt32("Usuario_Id"),
                                reader.GetString("Email"),
                                reader.GetString("Nombre"),
                                reader.GetString("Apellido"),
                                reader.GetString("Telefono"),
                                reader.GetString("Rol"),
                                reader.GetDateTime("Fecha_Registro"),
                                reader.IsDBNull(reader.GetOrdinal("Fecha_Baja")) ? (DateTime?)null : reader.GetDateTime("Fecha_Baja")
                            );

                            usuarios.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los usuarios inactivos: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return usuarios;
        }

        //Verificar si existe mail
        public bool ExisteUsuarioPorEmail(string email)// MODIFICAR CONTRA LA BASE DE DATOS
        {
            try
            {
                conexion.Abrir();
                string consulta = "SELECT Encontrar_usuario_por_email(@Email);";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@Email", email);
                    // ExecuteScalar devuelve el valor retornado por la función
                    int resultado = Convert.ToInt32(comando.ExecuteScalar());
                    return resultado == 1; // 1 si existe, 0 si no existe
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la existencia del usuario con función: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        // Otorgar rol administrador a un usuario
        public void OtorgarRolAdministrador(int usuarioId, int adminId)
        {
            try
            {
                conexion.Abrir();
                string consulta = "Asignar_rol_administrador";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("p_usuario_id", usuarioId);
                    comando.Parameters.AddWithValue("p_admin_id", adminId);
                    int filasAfectadas = comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al otorgar el rol de administrador: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        }

        // Revocar rol administrador a un usuario
        public void RevocarRolAdministrador(int usuarioId, int adminId)
        {
            try
            {
                conexion.Abrir();
                string consulta = "Asignar_rol_usuario";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("p_usuario_id", usuarioId);
                    comando.Parameters.AddWithValue("p_admin_id", adminId);
                    int filasAfectadas = comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al revocar el rol de administrador: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        }

        // Actualizar datos del usuario.
        public void ActualizarUsuario(int usuario_id, string email, string nombre, string apellido, string telefono, byte[] foto)
        {
            try
            {
                conexion.Abrir();
                using (MySqlCommand comando = new MySqlCommand("Actualizar_Usuario", conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("p_usuario_id", usuario_id);
                    comando.Parameters.AddWithValue("p_email", email);
                    comando.Parameters.AddWithValue("p_nombre", nombre);
                    comando.Parameters.AddWithValue("p_apellido", apellido);
                    comando.Parameters.AddWithValue("p_telefono", telefono);
                    comando.Parameters.AddWithValue("p_imagen_perfil", foto ?? (object)DBNull.Value);

                    // Solo ejecuta el comando, no necesitas leer resultados
                    comando.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex) when (ex.Number == 1644)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Cerrar();
            }
        }


        //Buscar usuario por email y contra

        public string CambiarContraseña(int usuarioId, string contraseñaActual, string nuevaContraseña)
        {
            try
            {
                conexion.Abrir();

                using (MySqlCommand comando = new MySqlCommand("Cambiar_contraseña", conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    comando.Parameters.AddWithValue("p_usuario_id", usuarioId);
                    comando.Parameters.AddWithValue("p_contraseña_actual", contraseñaActual);
                    comando.Parameters.AddWithValue("p_nueva_contraseña", nuevaContraseña);

                    // Ejecutar y leer resultado (el SELECT final del procedimiento)
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetString(0); // Devuelve el mensaje del procedimiento
                        }
                        else
                        {
                            return "No se recibió respuesta del servidor.";
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Si el procedimiento hace SIGNAL, cae acá
                return $"Error SQL: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Error general: {ex.Message}";
            }
            finally
            {
                conexion.Cerrar();
            }
        }

        //Metodo cambiar contra
        public bool OlvideMiContraseña(string email, string nuevaContraseña)
        {
            try
            {
                conexion.Abrir();

                using (MySqlCommand comando = new MySqlCommand("Olvide_mi_contraseña", conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("p_email", email);
                    comando.Parameters.AddWithValue("p_nueva_contraseña", nuevaContraseña);

                    // Solo ejecutás el procedimiento. No leés el SELECT del final.
                    comando.ExecuteNonQuery();
                }

                return true;
            }
            catch (MySqlException ex)
            {
                // Si el SP lanza SIGNAL (por ejemplo, misma contraseña), cae acá
                MessageBox.Show($"⚠️ Error SQL: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error general: {ex.Message}");
                return false;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
    }
}
