using System;
using System.Collections.Generic;
using MicheBytesRecipes.Classes.Interacciones;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MicheBytesRecipes.Classes.Recetas;
using MicheBytesRecipes.Connections;
using MicheBytesRecipes.Helpers;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Session;
using Org.BouncyCastle.Utilities.Zlib;
namespace MicheBytesRecipes.Managers
{
    internal class GestorInteracciones
    {
        ConexionBD conexion = new ConexionBD();
        Receta receta = new Receta();

        public bool AgregarComentario(Comentarios comentarios)
        {
            try
            {
                conexion.Abrir();
                // Usar un comando para llamar al procedimiento almacenado
                using (MySqlCommand comando = new MySqlCommand("Insertar_comentario", conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@p_descripcion", comentarios.Descripcion);
                    comando.Parameters.AddWithValue("@p_receta_id", comentarios.RecetaId);
                    comando.Parameters.AddWithValue("@p_usuario_id", comentarios.UsuarioId);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0; // Retorna true si se insertó al menos una fila
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar comentario: {ex.Message}");
                return false;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public bool EliminarComentario(int usuarioId, int recetaId, string comentario)
        {
            try
            {
                conexion.Abrir();
                // Usar un comando para llamar al procedimiento almacenado
                using (MySqlCommand comando = new MySqlCommand("Eliminar_comentario", conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@p_usuario_id", usuarioId);
                    comando.Parameters.AddWithValue("@p_receta_id", recetaId);
                    comando.Parameters.AddWithValue("@p_descripcion", comentario);
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0; // Retorna true si se eliminó al menos una fila
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar comentario: {ex.Message}");
                return false;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public List<Comentarios> CargarComentarios(int recetaId)
        {
            List<Comentarios> listaComentarios = new List<Comentarios>();
            try
            {
                conexion.Abrir();
                // Consulta SQL para obtener los comentarios de una receta específica
                string consultaComentarios = @"SELECT 
                         c.comentario_id, 
                         c.descripcion, 
                         c.fecha_comentario, 
                         u.nombre AS nombre_usuario
                     FROM Comentarios c
                     INNER JOIN Usuarios u ON c.usuario_id = u.usuario_id
                     WHERE c.receta_id = @recetaId
                     ORDER BY c.fecha_comentario DESC;";
                ;

                // Usar un comando para ejecutar la consulta
                using (MySqlCommand comando = new MySqlCommand(consultaComentarios, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@recetaId", recetaId);
                    // Ejecutar el comando y leer los resultados
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        // Leer cada fila y crear objetos Comentarios
                        //Console.WriteLine("No se encontraron comentarios para la receta ID: " + recetaId);
                        while (lector.Read())
                        {
                            Comentarios comentarios = new Comentarios
                            {
                                ComentarioId = Convert.ToInt32(lector["comentario_id"]),
                                Descripcion = lector["descripcion"].ToString(),
                                FechaComentario = Convert.ToDateTime(lector["fecha_comentario"]),
                                NombreUsuario = lector["nombre_usuario"].ToString()
                            };

                            listaComentarios.Add(comentarios);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar comentarios: {ex.Message}");
            }
            finally
            {
                conexion.Cerrar();
            }
            return listaComentarios;
        }


        //Metodos para gestionar los me gustas
        public bool GestionarMeGusta(int recetaId, int usuarioId)
        {
            try
            {
                conexion.Abrir();
                string consultaMeGusta = "SELECT COUNT(*) FROM me_gustas WHERE receta_id = @recetaId AND usuario_id = @usuarioId";

                using (MySqlCommand comando = new MySqlCommand(consultaMeGusta, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@recetaId", recetaId);
                    comando.Parameters.AddWithValue("@usuarioId", usuarioId);
                    int count = Convert.ToInt32(comando.ExecuteScalar());

                    if (count > 0)
                    {
                        //Si existe el me gusta, se elimina
                        using (MySqlCommand comando2 = new MySqlCommand("Eliminar_MeGusta", conexion.GetConexion()))
                        {
                            comando2.CommandType = CommandType.StoredProcedure;
                            comando2.Parameters.AddWithValue("@p_receta_id", recetaId);
                            comando2.Parameters.AddWithValue("@p_usuario_id", usuarioId);
                            comando2.ExecuteNonQuery();
                        }
                        return false; //Me guasta eliminado
                    }
                    else
                    {
                        //Si no existe, llamamos al procedimiento para insertar el me gusta
                        using (MySqlCommand comando3 = new MySqlCommand("insertar_me_gusta", conexion.GetConexion()))
                        {
                            comando3.CommandType = CommandType.StoredProcedure;
                            comando3.Parameters.AddWithValue("@p_receta_id", recetaId);
                            comando3.Parameters.AddWithValue("@p_usuario_id", usuarioId);
                            comando3.ExecuteNonQuery();
                        }
                        return true; //Me gusta agregado
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al dar me gusta: {ex.Message}");
                return false;
            }
            finally
            {
                conexion.Cerrar();
            }

        }
        public bool TieneMeGusta(int recetaId, int usuarioId)
        {
            try
            {
                conexion.Abrir();
                string consultaMeGusta = " SELECT COUNT(*) FROM vista_me_gustas WHERE receta_id = @recetaId AND usuario_id = @usuarioId";
                
                using (MySqlCommand comando = new MySqlCommand(consultaMeGusta, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@recetaId", recetaId);
                    comando.Parameters.AddWithValue("@usuarioId", usuarioId);
                    int count = Convert.ToInt32(comando.ExecuteScalar());
                    return count > 0; //Retorna true si tiene me gusta
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al verificar me gusta: {ex.Message}");
                return false;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public int ContarMeGusta(int recetaId)
        {
            try
            {
                conexion.Abrir();
                string consultaCantidad = "SELECT funcion_cantidad_me_gustas(@recetaId)";
                using (MySqlCommand comando = new MySqlCommand(consultaCantidad, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@recetaId", recetaId);
                    return Convert.ToInt32(comando.ExecuteScalar());
                }

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al ver los me gustas: {ex.Message}");
                return -1;
            }
            finally
            {
                conexion.Cerrar();
            }
        }

        //Metodos para gestionar los favoritos
        public bool GestionarFavoritos(int recetaId, int usuarioId)
        {
            try
            {
                conexion.Abrir();
                string consultaFavoritos = "SELECT COUNT(*) FROM favoritas WHERE receta_id = @recetaId and usuario_Id = @usuarioId";
                using (MySqlCommand comando = new MySqlCommand(consultaFavoritos, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@recetaId", recetaId);
                    comando.Parameters.AddWithValue("@usuarioId", usuarioId);
                    int existe = Convert.ToInt32(comando.ExecuteScalar());

                    if (existe > 0)
                    {
                        //Si ya esta en favoritos, se elimina
                        using (MySqlCommand comando2 = new MySqlCommand("Eliminar_favorita", conexion.GetConexion()))
                        {
                            comando2.CommandType = CommandType.StoredProcedure;
                            comando2.Parameters.AddWithValue("@p_receta_Id", recetaId);
                            comando2.Parameters.AddWithValue("@p_usuario_Id", usuarioId);
                            comando2.ExecuteNonQuery();
                        }
                        return false;
                    }
                    else
                    {
                        //Si no esta, se inserta
                        using (MySqlCommand comando3 = new MySqlCommand("Insertar_favorita", conexion.GetConexion()))
                        {
                            comando3.CommandType = CommandType.StoredProcedure;
                            comando3.Parameters.AddWithValue("@p_usuario_Id", usuarioId);
                            comando3.Parameters.AddWithValue("@p_receta_Id", recetaId);
                            comando3.ExecuteNonQuery();
                        }
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al guardar favorita: {ex.Message}");
                return false;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public bool EstaFavorito(int recetaId, int usuarioId)
        {
            try
            {
                conexion.Abrir();
                string consultaFavoritos = "SELECT COUNT(*) FROM vista_favoritas WHERE receta_id = @recetaId and usuario_Id = @usuarioId";

                using (MySqlCommand comando = new MySqlCommand(consultaFavoritos, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@recetaId", recetaId);
                    comando.Parameters.AddWithValue("@usuarioId", usuarioId);

                    int count = Convert.ToInt16(comando.ExecuteScalar());
                    return count > 0; //Retorna true si esta en favoritos
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al verificar favorita: {ex.Message}");
                return false;
            }
            finally
            {
                conexion.Cerrar();
            }
        }

        public void AgregarVisitaAlHistorial(int recetaId, int usuarioId)
        {
            try
            {
                conexion.Abrir();
                using (MySqlCommand comando = new MySqlCommand("Insertar_historial", conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@p_receta_id", recetaId);
                    comando.Parameters.AddWithValue("@p_usuario_id", usuarioId);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la visita al historial: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        } // Usar cuando nehuen termine el formulario

    }
}
