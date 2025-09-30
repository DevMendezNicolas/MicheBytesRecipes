using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MicheBytesRecipes.Classes;
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
        } //OK
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
                    if (filasAfectadas > 0)
                        MessageBox.Show("Usuario agregado correctamente.");
                    else
                        MessageBox.Show("No se pudo agregar el usuario.");
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
        // Eliminar usuario (marcar como inactivo)
        public void EliminarUsuario(int id) // Necesito el SP
        {
            try
            {
                conexion.Abrir();
                string consultaEliminar = "Procedimiento_que_elimina_usuario";
                using (MySqlCommand comando = new MySqlCommand(consultaEliminar, conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("p_usuario_id", id);
                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                        MessageBox.Show("Usuario eliminado correctamente.");
                    else
                        MessageBox.Show("No se encontro el usuario con el ID proporcionado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        }
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
                            return new Usuario(
                                reader.GetString("Email"),
                                reader.GetInt32("UsuarioId"),
                                reader.GetString("Nombre"),
                                reader.GetString("Apellido"),
                                reader.GetString("Telefono"),
                                (byte[])reader["ImagenPerfil"],
                                (int)reader["ID_Rol"]
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
                string consultaBuscar = "Procedimiento_que_busca_usuario";
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
                    comando.Parameters.Add("p_imagen_perfil", MySqlDbType.Blob).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("p_rol_id", MySqlDbType.Int32).Direction = ParameterDirection.Output;

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
        }// OK
        // Listar usuarios activos
        public List<Usuario> ListarUsuarios()
        {
            
            try
            {
                conexion.Abrir();
                List<Usuario> allUsers = new List<Usuario>();
                string consultaListar = "SELECT * FROM usuarios";
                using (MySqlCommand comando = new MySqlCommand(consultaListar, conexion.GetConexion()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader() || )
                    {
                        while (reader.Read())
                        {
                            allUsers.Add(new Usuario(
                                reader.GetString("Email"),
                                reader.GetInt32("Usuario_Id"),
                                reader.GetString("Nombre"),
                                reader.GetString("Apellido"),
                                reader.GetString("Telefono"),
                                (byte[])reader["Imagen_Perfil"],
                                reader.GetInt32("rol_id")

                            ));
                        }
                        return allUsers;
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
        } // Revisar Uso
        // Listar usuarios inactivos
        public void ListarUsuariosInactivos()
        {
            try
            {
                conexion.Abrir();
                string consultaListar = "SELECT * FROM usuarios WHERE FechaBaja IS NOT NULL";
                using (MySqlCommand comando = new MySqlCommand(consultaListar, conexion.GetConexion()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new Usuario(
                                reader.GetString("Email"),
                                reader.GetInt32("UsuarioId"),
                                reader.GetString("Nombre"),
                                reader.GetString("Apellido"),
                                reader.GetString("Telefono"),
                                (byte[])reader["ImagenPerfil"],
                                (int)reader["ID_Rol"]
                            ));
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
        } // Revisar Uso
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
    }
}
