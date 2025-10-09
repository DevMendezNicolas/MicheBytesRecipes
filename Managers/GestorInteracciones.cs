using MicheBytesRecipes.Classes.Interacciones;
using MicheBytesRecipes.Connections;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace MicheBytesRecipes.Managers
{
    internal class GestorInteracciones
    {
        ConexionBD conexion = new ConexionBD();

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
        public List<Comentarios> CargarComentarios(int recetaId)
        {
            List<Comentarios> listaComentarios = new List<Comentarios>();
            try
            {
                conexion.Abrir();
                // Consulta SQL para obtener los comentarios de una receta específica
                string consultaComentarios =@"SELECT 
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


    }
}
