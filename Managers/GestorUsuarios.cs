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
    
    public class GestorUsuarios: IUsuarioRepository
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
                //Console.WriteLine(builder.ToString());
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
        } //OK
        // Validar credenciales de usuario (Email y Contraseña) // MEJORAR
        public bool ValidarCredenciales(string email, string contraseña)
        {
            try
            {
                conexion.Abrir();
                string consultaValidar = "SELECT * FROM usuarios WHERE email = @Email AND Contraseña = @Contraseña AND fecha_baja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consultaValidar, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@Email", email);
                    comando.Parameters.AddWithValue("@Contraseña",contraseña /*HashearContraseña(contraseña)*/);
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
        public void DarDeBajaUsuario(int AdminId,int usuarioBajaId)
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
        } // OK
        // Buscar usuario por ID
        public Usuario BuscarUsuario(int id)
        {
            try
            {
                conexion.Abrir();
                string consultaBuscar = "SELECT * FROM usuarios WHERE UsuarioId = @UsuarioId AND FechaBaja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consultaBuscar, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@UsuarioId", id);
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] fotoPerfil = null;
                            if (!reader.IsDBNull(reader.GetOrdinal("ImagenPerfil")))
                            {
                                long tamañoImagen = reader.GetBytes(reader.GetOrdinal("ImagenPerfil"), 0, null, 0, 0);
                                fotoPerfil = new byte[tamañoImagen];
                                reader.GetBytes(reader.GetOrdinal("ImagenPerfil"), 0, fotoPerfil, 0, (int)tamañoImagen);
                            }
                            return new Usuario(
                                reader.GetString("Email"),
                                reader.GetInt32("UsuarioId"),
                                reader.GetString("Nombre"),
                                reader.GetString("Apellido"),
                                reader.GetString("Telefono"),
                                fotoPerfil,
                                (int)reader["ID_Rol"],
                                reader.GetDateTime("Fecha_Registro"),
                                reader.IsDBNull(reader.GetOrdinal("Fecha_Baja")) ? (DateTime?)null : reader.GetDateTime("FechaBaja")
                            );
                        }
                        else
                        {
                            return null; // No se encontro el usuario
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el usuario: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        } // Revisar Uso
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
            catch(Exception ex)
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
        // Cantidad Total de usuario dados de alta
        
        public int CantidadTotalUsuarios()
        {
            try
            {
                conexion.Abrir();
                string consultaContar = "SELECT COUNT(*) FROM usuarios WHERE FechaBaja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consultaContar, conexion.GetConexion()))
                {
                    int count = Convert.ToInt32(comando.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al contar los usuarios: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        } // Revisar Uso
        // Cantidad Total de usuario dados de baja
        public int CantidadTotalUsuariosInactivos()
        {
            try
            {
                conexion.Abrir();
                string consultaContar = "SELECT COUNT(*) FROM usuarios WHERE FechaBaja IS NOT NULL";
                using (MySqlCommand comando = new MySqlCommand(consultaContar, conexion.GetConexion()))
                {
                    int count = Convert.ToInt32(comando.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al contar los usuarios inactivos: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        } // Revisar Uso

        public string ObtenerContraseñaPorEmail(string email)
        {
            try
            {
                conexion.Abrir();
                string consulta = "SELECT Contraseña FROM usuarios WHERE email = @Email AND fecha_baja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@Email", email);
                    object resultado = comando.ExecuteScalar(); // Devuelve la primera columna de la primera fila

                    if (resultado != null)
                        return resultado.ToString();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la contraseña: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        }

        //Verificar si existe mail
        public bool ExisteUsuarioPorEmail(string email)
        {
            try
            {
                conexion.Abrir();
                string consulta = "SELECT COUNT(*) FROM usuarios WHERE email = @Email AND fecha_baja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@Email", email);
                    int count = Convert.ToInt32(comando.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la existencia del usuario: " + ex.Message);
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

    }
}
