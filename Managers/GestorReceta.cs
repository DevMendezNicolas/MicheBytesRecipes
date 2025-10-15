using System;
using System.Collections.Generic;
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

namespace MicheBytesRecipes
{
    internal class GestorReceta
    {
        ConexionBD conexion = new ConexionBD();
        // Lista de recetas
        public List<Receta> recetas;

        public GestorReceta()
        {
            recetas = new List<Receta>();
        }      
        

        public void ModificarReceta(Receta receta) // Cin lo esta terminado
        {
            try
            {
                conexion.Abrir();

                string consultaModificar = "UPDATE Recetas SET Nombre = @Nombre, Descripcion = @Descripcion, Instrucciones = @Instrucciones, " +
                    "ImagenReceta = @ImagenReceta, TiempoPreparacion = @TiempoPreparacion, NivelDificultad = @NivelDificultad WHERE RecetaId = @RecetaId";

                using (MySqlCommand comando = new MySqlCommand(consultaModificar, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@Nombre", receta.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", receta.Descripcion);
                    comando.Parameters.AddWithValue("@Instrucciones", receta.Instrucciones);
                    comando.Parameters.AddWithValue("@ImagenReceta", receta.ImagenReceta);
                    comando.Parameters.AddWithValue("@TiempoPreparacion", receta.TiempoPreparacion);
                    comando.Parameters.AddWithValue("@NivelDificultad", receta.NivelDificultad.ToString());


                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                        MessageBox.Show("Receta modificada exitosamente.");
                    else
                        MessageBox.Show("No se pudo modificar la receta.");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la receta: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public int AgregarReceta(Receta receta, List<int> ingredientesIds)
        {
            int recetaId = -1;
            //Validacion con try catch porque las conexiones externas pueden fallar
            //Ejemplo: la base de datos no esta disponible
            try
            {
                //Abrir la conexion
                conexion.Abrir();

                using (MySqlCommand comando = new MySqlCommand("Insertar_receta", conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    //Asignar los parametros del comando SQL
                    comando.Parameters.AddWithValue("@p_nombre", receta.Nombre);
                    comando.Parameters.AddWithValue("@p_descripcion", receta.Descripcion);
                    comando.Parameters.AddWithValue("@p_instrucciones", receta.Instrucciones);
                    //Imagen BLOB
                    comando.Parameters.Add("@p_imagen_receta", MySqlDbType.Blob).Value = receta.ImagenReceta ?? (object)DBNull.Value;
                    //Tiempo (TimeSpan -> TIME)
                    comando.Parameters.AddWithValue("@p_tiempo_preparacion", receta.TiempoPreparacion);
                    comando.Parameters.AddWithValue("@p_dificultad", receta.NivelDificultad.ToString());
                    //comando.Parameters.AddWithValue("@FechaRegistro", receta.FechaRegistro);
                    //Claves foraneas
                    comando.Parameters.AddWithValue("@p_pais_id", receta.PaisId);
                    comando.Parameters.AddWithValue("@p_categoria_id", receta.CategoriaId);
                    comando.Parameters.AddWithValue("@p_usuario_id", receta.UsuarioId);

                    //Parametro de salida
                    var parametroId = new MySqlParameter("p_receta_id", MySqlDbType.Int32);
                    parametroId.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(parametroId);

                    //Ejecutar
                    comando.ExecuteNonQuery();

                    //Obtener el id
                    recetaId = Convert.ToInt32(comando.Parameters["p_receta_id"].Value);
                }
                foreach (var ingredienteId in ingredientesIds)
                {
                    using (var cmd = new MySqlCommand("Insertar_ingrediente_por_receta", conexion.GetConexion()))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_ingrediente_id", ingredienteId);
                        cmd.Parameters.AddWithValue("@p_receta_id", recetaId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Receta agregada exitosamente.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la receta: " + ex.Message);
            }
            finally
            {
                //Cerrar la conexion
                conexion.Cerrar();
            }

            return recetaId;
        }
        public Receta ObtenerRecetaPorId(int recetaId)
        {
            Receta receta = null;
            try
            {
                conexion.Abrir();
                using (MySqlCommand comando = new MySqlCommand("Devolver_receta", conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // IN
                    comando.Parameters.AddWithValue("p_receta_id", recetaId);

                    // OUT
                    comando.Parameters.Add(new MySqlParameter("p_nombre", MySqlDbType.VarChar, 50) { Direction = ParameterDirection.Output });
                    comando.Parameters.Add(new MySqlParameter("p_descripcion", MySqlDbType.Text) { Direction = ParameterDirection.Output });
                    comando.Parameters.Add(new MySqlParameter("p_instrucciones", MySqlDbType.Text) { Direction = ParameterDirection.Output });
                    comando.Parameters.Add(new MySqlParameter("p_imagen_receta", MySqlDbType.LongBlob) { Direction = ParameterDirection.Output });
                    comando.Parameters.Add(new MySqlParameter("p_tiempo_preparacion", MySqlDbType.Time) { Direction = ParameterDirection.Output });
                    comando.Parameters.Add(new MySqlParameter("p_dificultad", MySqlDbType.VarChar, 50) { Direction = ParameterDirection.Output });
                    comando.Parameters.Add(new MySqlParameter("p_pais_id", MySqlDbType.Int32) { Direction = ParameterDirection.Output });
                    comando.Parameters.Add(new MySqlParameter("p_categoria_id", MySqlDbType.Int32) { Direction = ParameterDirection.Output });
                    comando.Parameters.Add(new MySqlParameter("p_usuario_id", MySqlDbType.Int32) { Direction = ParameterDirection.Output });

                    comando.ExecuteNonQuery();

                    receta = new Receta
                    {
                        RecetaId = recetaId,
                        Nombre = comando.Parameters["p_nombre"].Value?.ToString(),
                        Descripcion = comando.Parameters["p_descripcion"].Value?.ToString(),
                        Instrucciones = comando.Parameters["p_instrucciones"].Value?.ToString(),
                        ImagenReceta = comando.Parameters["p_imagen_receta"].Value == DBNull.Value ? null : (byte[])comando.Parameters["p_imagen_receta"].Value,
                        TiempoPreparacion = comando.Parameters["p_tiempo_preparacion"].Value == DBNull.Value ? TimeSpan.Zero : (TimeSpan)comando.Parameters["p_tiempo_preparacion"].Value,
                        NivelDificultad = Enum.TryParse(comando.Parameters["p_dificultad"].Value?.ToString(), true, out Dificultad d) ? d : Dificultad.Fácil,
                        PaisId = Convert.ToInt32(comando.Parameters["p_pais_id"].Value),
                        CategoriaId = Convert.ToInt32(comando.Parameters["p_categoria_id"].Value),
                        UsuarioId = Convert.ToInt32(comando.Parameters["p_usuario_id"].Value)
                    };
                }


                receta.Ingredientes = ObtenerIngredientesPorRecetaId(recetaId);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la receta: {ex.Message}");
            }
            finally
            {
                conexion.Cerrar();
            }
            return receta;
        }

        public int ContarRecetas()
        {
            int contador = 0;
            try
            {
                conexion.Abrir();
                string consultaContar = "SELECT COUNT(*) FROM Recetas WHERE Fecha_baja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consultaContar, conexion.GetConexion()))
                {
                    contador = Convert.ToInt32(comando.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
                contador = -1; // Indicar un error
            }
            finally
            {
                conexion.Cerrar();
            }
            return contador;
        } // Verificar uso
        public List<Receta> ObtenerRecetasMasNuevas(int cantidad)
        {
            List<Receta> recetas = new List<Receta>();
            try
            {
                conexion.Abrir();
                string consultaNuevas = "SELECT * FROM Recetas WHERE Fecha_baja IS NULL ORDER BY FechaRegistro DESC LIMIT @Cantidad";
                using (MySqlCommand comando = new MySqlCommand(consultaNuevas, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@Cantidad", cantidad);
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Receta receta = new Receta
                            {
                                RecetaId = lector.GetInt32("RecetaId"),
                                Nombre = lector.GetString("Nombre"),
                                PaisId = lector.GetInt32("PaisId"),
                                CategoriaId = lector.GetInt32("CategoriaId"),
                                UsuarioId = lector.GetInt32("UsuarioId"),
                                Descripcion = lector.GetString("Descripcion"),
                                Instrucciones = lector.GetString("Instrucciones"),
                                ImagenReceta = null,
                                TiempoPreparacion = lector.GetTimeSpan("TiempoPreparacion"),
                                NivelDificultad = (Dificultad)Enum.Parse(typeof(Dificultad), lector.GetString("NivelDificultad")),
                                FechaRegistro = lector.GetDateTime("FechaRegistro"),
                                FechaBaja = lector.IsDBNull(lector.GetOrdinal("FechaBaja")) ? (DateTime?)null : lector.GetDateTime("FechaBaja")
                            };
                            recetas.Add(receta);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las recetas más nuevas: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return recetas;

        }
        public List<Receta> ObtenerRecetasMasAntiguas(int cantidad)
        {
            List<Receta> recetas = new List<Receta>();
            try
            {
                conexion.Abrir();
                string consultaAntiguas = "SELECT * FROM Recetas WHERE Fecha_baja IS NULL ORDER BY FechaRegistro ASC LIMIT @Cantidad";
                using (MySqlCommand comando = new MySqlCommand(consultaAntiguas, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@Cantidad", cantidad);
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Receta receta = new Receta
                            {
                                RecetaId = lector.GetInt32("RecetaId"),
                                Nombre = lector.GetString("Nombre"),
                                PaisId = lector.GetInt32("PaisId"),
                                CategoriaId = lector.GetInt32("CategoriaId"),
                                UsuarioId = lector.GetInt32("UsuarioId"),
                                Descripcion = lector.GetString("Descripcion"),
                                Instrucciones = lector.GetString("Instrucciones"),
                                ImagenReceta = null,
                                TiempoPreparacion = lector.GetTimeSpan("TiempoPreparacion"),
                                NivelDificultad = (Dificultad)Enum.Parse(typeof(Dificultad), lector.GetString("NivelDificultad")),
                                FechaRegistro = lector.GetDateTime("FechaRegistro"),
                                FechaBaja = lector.IsDBNull(lector.GetOrdinal("FechaBaja")) ? (DateTime?)null : lector.GetDateTime("FechaBaja")
                            };
                            recetas.Add(receta);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las recetas más antiguas: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return recetas;

        }

        //Metodos de mantenimiento
        public bool DarDeBajaReceta(int recetaId)
        {
            try
            {
                conexion.Abrir();
                string consultaBaja = "CALL Dar_de_baja_receta(@RecetaId)";
                using (MySqlCommand comando = new MySqlCommand(consultaBaja, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@RecetaId", recetaId);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error al dar de baja una receta: " + ex.Message);
                throw new Exception("Error al dar de baja una receta", ex);
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public bool DarDeAltaReceta(int recetaId)
        {
            try
            {
                conexion.Abrir();
                string consultaAlta = "CALL Reactivar_receta(@RecetaId)";
                using (MySqlCommand comando = new MySqlCommand(consultaAlta, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@RecetaId", recetaId);
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error al dar de alta una receta: " + ex.Message);
                throw new Exception("Error al dar de alta una receta", ex);
            }
            finally
            {
                conexion.Cerrar();
            }

        }

        // Metodos de consulta y busqueda
        public List<PreReceta> ObtenerPreRecetas()
        {
            List<PreReceta> recetas = new List<PreReceta>();
            try
            {
                conexion.Abrir();
                string consulta = "SELECT receta_id, nombre, categoria_id, pais_id, dificultad, tiempo_preparacion FROM Vista_resumen_recetas WHERE fecha_baja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion()))
                {
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            PreReceta receta = new PreReceta
                            (
                                lector.GetInt32("Receta_Id"),
                                lector.GetString("Nombre"),
                                lector.GetInt32("Pais_Id"),
                                lector.GetInt32("Categoria_Id"),
                                (Dificultad)Enum.Parse(typeof(Dificultad), lector.GetString("Dificultad")),
                                lector.GetTimeSpan("Tiempo_Preparacion")
                            );
                            recetas.Add(receta);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la previsualización de recetas: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return recetas;
        }
        public List<PreReceta> ObtenerPreRecetasInactivas()
        {
            List<PreReceta> recetas = new List<PreReceta>();
            try
            {
                conexion.Abrir();
                string consulta = "SELECT * FROM Vista_resumen_recetas WHERE fecha_baja IS NOT NULL";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion()))
                {
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            PreReceta receta = new PreReceta
                            (
                                lector.GetInt32("Receta_Id"),
                                lector.GetString("Nombre"),
                                lector.GetInt32("Pais_Id"),
                                lector.GetInt32("Categoria_Id"),
                                (Dificultad)Enum.Parse(typeof(Dificultad), lector.GetString("Dificultad")),
                                lector.GetTimeSpan("Tiempo_Preparacion")
                            );
                            recetas.Add(receta);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la previsualización de recetas: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return recetas;
        }
        public List<PreReceta> ObtenerPreRecetasFiltradas(string nombre, int paisId, int categoriaId, Dificultad? dificultad)
        {
            List<PreReceta> recetas = new List<PreReceta>();

            try
            {
                conexion.Abrir();

                string consulta = "SELECT receta_id, nombre, categoria_id, pais_id, dificultad, tiempo_preparacion FROM Vista_resumen_recetas WHERE 1=1";
                List<MySqlParameter> parametros = new List<MySqlParameter>();

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    consulta += " AND LOWER(nombre) LIKE CONCAT('%', LOWER(@Nombre), '%')";
                    parametros.Add(new MySqlParameter("@Nombre", nombre));
                }

                if (paisId > 0)
                {
                    consulta += " AND pais_id = @PaisId";
                    parametros.Add(new MySqlParameter("@PaisId", paisId));
                }

                if (categoriaId > 0)
                {
                    consulta += " AND categoria_id = @CategoriaId";
                    parametros.Add(new MySqlParameter("@CategoriaId", categoriaId));
                }

                if (dificultad.HasValue)
                {
                    consulta += " AND dificultad = @Dificultad";
                    parametros.Add(new MySqlParameter("@Dificultad", dificultad.Value.ToString()));
                }

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion()))
                {
                    comando.Parameters.AddRange(parametros.ToArray());

                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            string dificultadDb = lector.GetString("dificultad");
                            Dificultad dificultadEnum;

                            if (dificultadDb == "Fácil")
                                dificultadEnum = Dificultad.Fácil;
                            else if (dificultadDb == "Media")
                                dificultadEnum = Dificultad.Media;
                            else if (dificultadDb == "Difícil")
                                dificultadEnum = Dificultad.Difícil;
                            else
                                throw new Exception("Valor de dificultad desconocido en la base de datos.");

                            PreReceta receta = new PreReceta(
                                lector.GetInt32("receta_id"),
                                lector.GetString("nombre"),
                                lector.GetInt32("pais_id"),
                                lector.GetInt32("categoria_id"),
                                dificultadEnum,
                                lector.GetTimeSpan("tiempo_preparacion")
                            );

                            recetas.Add(receta);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las recetas filtradas: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }

            return recetas;
        }
        public List<PreReceta> ObtenerRecetasFavoritasPorUsuario(int usuarioId)
        {
            List<PreReceta> recetas = new List<PreReceta>();
            try
            {
                conexion.Abrir();
                using (MySqlCommand comando = new MySqlCommand("Obtener_recetas_favoritas", conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@p_usuario_id", usuarioId);
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            PreReceta receta = new PreReceta
                            (
                                lector.GetInt32("receta_id"),
                                lector.GetString("nombre"),
                                lector.GetInt32("pais_id"),
                                lector.GetInt32("categoria_id"),
                                (Dificultad)Enum.Parse(typeof(Dificultad), lector.GetString("dificultad")),
                                lector.GetTimeSpan("tiempo_preparacion")
                            );
                            recetas.Add(receta);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las recetas favoritas: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return recetas;

        }
        public List<PreReceta> ObtenerHistorialUsuario(int usuarioId)
        {
            List<PreReceta> recetas = new List<PreReceta>();
            try
            {
                conexion.Abrir();
                string consulta = "SELECT receta_id, nombre, categoria_id, pais_id, dificultad, tiempo_preparacion FROM Vista_resumen_receta_historial WHERE fecha_baja IS NULL AND usuario_Id = @UsuarioId ORDER BY Historial_Id DESC LIMIT 15";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            PreReceta receta = new PreReceta
                            (
                                lector.GetInt32("Receta_Id"),
                                lector.GetString("Nombre"),
                                lector.GetInt32("Pais_Id"),
                                lector.GetInt32("Categoria_Id"),
                                (Dificultad)Enum.Parse(typeof(Dificultad), lector.GetString("Dificultad")),
                                lector.GetTimeSpan("Tiempo_Preparacion")
                            );
                            recetas.Add(receta);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la previsualización de recetas: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return recetas;
        }

        // Metodos auxiliares      
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
