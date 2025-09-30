using MicheBytesRecipes.Connections;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MicheBytesRecipes.Classes.Recetas
{
    internal class GestorReceta
    {
        ConexionBD conexion = new ConexionBD();
        // Lista de recetas
        public List<Receta> recetas;

        //Metodo para eliminar receta
        public void EliminarReceta(int recetaId)
        {
            try
            {
                conexion.Abrir();

                string consultaEliminar = "DELETE FROM Recetas WHERE RecetaId = @RecetaId";
                using (MySqlCommand comando = new MySqlCommand(consultaEliminar, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@RecetaId", recetaId);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                        MessageBox.Show("Receta eliminada exitosamente.");
                    else
                        MessageBox.Show("No se pudo eliminar la receta.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la receta: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }

        }

        //Metodo para obtener ingredientes
        public List<Ingrediente> ObtenerIgredientes()
        {
            List<Ingrediente> ingredientes = new List<Ingrediente>();
            try
            {
                conexion.Abrir();
                string consultaListar = "SELECT * FROM Vista_de_ingredientes_con_detalles";
                using (MySqlCommand comando = new MySqlCommand(consultaListar, conexion.GetConexion()))
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        ingredientes.Add(new Ingrediente
                        {
                            IngredienteId = lector.GetInt32("ID_Ingrediente"),
                            Nombre = lector.GetString("Nombre"),
                            Unidad = new UnidadMedida
                            {
                                UnidadMedidaId = lector.GetInt32("ID_Unidad_de_medida"),
                                Nombre = lector.GetString("Unidad_de_medida")
                            },
                            Tipo = new TipoIngrediente
                            {
                                TipoIngredienteId = lector.GetInt32("ID_Tipo_de_ingrediente"),
                                Nombre = lector.GetString("Tipo_de_ingrediente")
                            }
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los ingredientes: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return ingredientes;
        }
        public void ModificarReceta(Receta receta)
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
        public List<Receta> listarRecetas()
        {
            List<Receta> recetas = new List<Receta>();

            try
            {
                conexion.Abrir();
                string consultaListar = "SELECT * FROM Recetas WHERE Fecha_baja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consultaListar, conexion.GetConexion()))
                {
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

                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                        MessageBox.Show("Receta listada exitosamente.");
                    else
                        MessageBox.Show("No se pudo listar la receta.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar las recetas: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return recetas;
        }

        public int AgregarReceta(Receta receta, List<int> ingredientesIds)
        {
            //inicializo el id de la receta en -1 (valor que indica que no se ha insertado)
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
                    comando.Parameters.Add("@p_imagen_receta", MySqlDbType.Blob).Value = receta.ImagenReceta ??(object)DBNull.Value;
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
                foreach(var ingredienteId in ingredientesIds)
                {
                    using (var cmd = new MySqlCommand("INSERT INTO ingredientes_x_receta (receta_id, ingrediente_id, cantidad) VALUES (@recetaId, @ingredienteId, @cantidad)", conexion.GetConexion()))
                    {
                        cmd.Parameters.AddWithValue("@recetaId", recetaId);
                        cmd.Parameters.AddWithValue("@ingredienteId", ingredienteId);
                        cmd.Parameters.AddWithValue("@cantidad", 1);
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
        public void AgregarIngrediente(Ingrediente ingrediente)
        {
            try
            {
                conexion.Abrir();

                using (MySqlCommand comando = new MySqlCommand("Insertar_ingrediente", conexion.GetConexion()))
                //Usar procedimiento almacenado
                {
                    comando.CommandType = CommandType.StoredProcedure;// IMPORTANTE: Esto indica que es un procedimiento almacenado

                    comando.Parameters.AddWithValue("@p_nombre", ingrediente.Nombre);
                    comando.Parameters.AddWithValue("@p_unidad_de_medida_id", ingrediente.Unidad.UnidadMedidaId);
                    comando.Parameters.AddWithValue("@p_tipo_ingrediente_id", ingrediente.Tipo.TipoIngredienteId);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                        MessageBox.Show("Ingrediente agregado exitosamente.");
                    else
                        MessageBox.Show("No se pudo agregar el ingrediente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el ingrediente: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public void AgregarIngredienteReceta(Receta receta)
        {
            try
            {
                conexion.Abrir();
                foreach (var ing in receta.Ingredientes)
                {
                    string consulta = "INSERT INTO RecetaIngredientes (RecetaId, IngredienteId) VALUES (@RecetaId, @IngredienteId)";
                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion()))
                    {
                        comando.Parameters.AddWithValue("@RecetaId", receta.RecetaId);
                        comando.Parameters.AddWithValue("@IngredienteId", ing.IngredienteId);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el ingrediente a la receta: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public void AgregarPais(Pais pais)
        {
            try
            {
                conexion.Abrir();
                using (MySqlCommand comando = new MySqlCommand("insertar_paises", conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@nombre_pais", pais.Nombre);
                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                        MessageBox.Show("País agregado exitosamente.");
                    else
                        MessageBox.Show("No se pudo agregar el país.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el país: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public void AgregarCategoria(Categoria categoria)
        {
            try
            {
                conexion.Abrir();
                using (MySqlCommand comando = new MySqlCommand("Insertar_categoria", conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("p_nombre", categoria.Nombre);
                    comando.Parameters.AddWithValue("p_descripcion", categoria.Descripcion);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Categoria agregada exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar la categoria.");
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar categoria: " + ex.Message);
            }
            finally { conexion.Cerrar(); }
        }
        //Metodos de busqueda
        public Receta ObtenerRecetaPorId(int recetaId)
        {
            Receta receta = null;
            try
            {
                conexion.Abrir();
                string consultaObtener = ("SELECT * FROM Vista_todas_las_recetas WHERE receta_id = @recetaId");

                using (MySqlCommand comando = new MySqlCommand(consultaObtener, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@recetaId", recetaId);

                    using(MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            receta = new Receta
                            {
                                RecetaId = reader.GetInt32("receta_id"),
                                Nombre = reader.GetString("nombre"),
                                Descripcion = reader.GetString("descripcion"),
                                Instrucciones = reader.GetString("instrucciones"),
                                ImagenReceta = reader["imagen_receta"] as byte[],
                                TiempoPreparacion = reader.GetTimeSpan("tiempo_preparacion"),
                                NivelDificultad = (Dificultad)Enum.Parse(typeof(Dificultad), reader.GetString("NivelDificultad")),
                                PaisId = -1,
                                CategoriaId = -1,
                                UsuarioId = -1,
                            };

                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error al obtener la receta: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }return receta;
        }
        public List<Receta> BuscarRecetaPorNombre(string nombre)
        {
            List<Receta> recetas = new List<Receta>();
            try
            {
                conexion.Abrir();
                string consultaBuscar = "SELECT * FROM Recetas WHERE Nombre = @Nombre AND Fecha_baja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consultaBuscar, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@Nombre", nombre);
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
                        return recetas;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la receta: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return null;
        }
        public List<Receta> BuscarRecetaPorIngrediente(string ingrediente)
        {
            List<Receta> recetas = new List<Receta>();
            try
            {
                conexion.Abrir();
                string consultarBuscar = "SELECT * FROM recetas WHERE Ingrediente = @Ingrediente and Fecha_baja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consultarBuscar, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@Ingrediente", ingrediente);
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
                        return recetas;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la receta: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return null;
        }
        public List<Receta> BuscarRecetaPorPais(string pais)
        {
            List<Receta> recetas = new List<Receta>();
            try
            {
                conexion.Abrir();
                string consultarBuscar = "SELECT * FROM recetas WHERE Pais = @Pais and Fecha_baja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consultarBuscar, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@Pais", pais);
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
                        return recetas;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la receta: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return null;
        }
        public List<Receta> BuscarRecetaPorCategoria(string categoria)
        {
            List<Receta> recetas = new List<Receta>();
            try
            {
                conexion.Abrir();
                string consultarBuscar = "SELECT * FROM recetas WHERE Categoria = @Categoria and Fecha_baja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consultarBuscar, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@Categoria", categoria);
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
                        return recetas;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la receta: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return null;
        }
        public List<Receta> BuscarRecetaPorDificultad(Dificultad dificultad)
        {
            List<Receta> recetas = new List<Receta>();

            try
            {
                conexion.Abrir();
                string consultarBuscar = "SELECT * FROM recetas WHERE NivelDificultad = @NivelDificultad and Fecha_baja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consultarBuscar, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@NivelDificultad", dificultad.ToString());
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
                        return recetas;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la receta: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return null;
        }
        public List<Receta> BuscarRecetaActiva()
        {
            List<Receta> recetas = new List<Receta>();
            try
            {
                conexion.Abrir();
                string consultarBuscar = "SELECT * FROM recetas WHERE Fecha_baja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consultarBuscar, conexion.GetConexion()))
                {
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
                        return recetas;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return null;
        }

        //Metodos obtener
        public List<UnidadMedida> ObtenerListaUnidades()
        {
            List<UnidadMedida> unidades = new List<UnidadMedida>();
            try
            {
                conexion.Abrir();
                // Consulta SQL para obtener todas las unidades de medida
                string consultaUnidades = "SELECT * FROM vista_de_todas_las_unidades_de_medida";
                // Ejecutar el comando SQL
                using (MySqlCommand cmd = new MySqlCommand(consultaUnidades, conexion.GetConexion()))
                {

                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        // Leer cada fila y crear un objeto UnidadMedida
                        {
                            unidades.Add(new UnidadMedida
                            // Crear y agregar cada unidad de medida a la lista
                            {
                                UnidadMedidaId = lector.GetInt32("ID"),//Asegurarse de que el nombre de la columna coincida con el de la base de datos
                                Nombre = lector.GetString("Nombre")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
                conexion.Cerrar();
            }
            return unidades;
        }
        public List<TipoIngrediente> ObtenerListaTipos()
        {
            // Crear una lista para almacenar los tipos de ingredientes
            List<TipoIngrediente> tipos = new List<TipoIngrediente>();
            try
            {
                conexion.Abrir();
                // Consulta SQL para obtener todos los tipos de ingredientes
                string consultaTipos = "SELECT * FROM Vista_de_todos_los_tipos_de_ingredientes";
                // Ejecutar el comando SQL
                using (MySqlCommand comando = new MySqlCommand(consultaTipos, conexion.GetConexion()))
                {
                    // Leer los resultados
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            // Leer cada fila y crear un objeto TipoIngrediente
                            TipoIngrediente tipo = new TipoIngrediente
                            // Crear y agregar cada tipo de ingrediente a la lista
                            {
                                TipoIngredienteId = lector.GetInt32("ID"), //Asegurarse de que el nombre de la columna sea correcto
                                Nombre = lector.GetString("Nombre")
                            };
                            tipos.Add(tipo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
                conexion.Cerrar();
            }
            return tipos;
        }
        public List<Pais> ObtenerListaPaises()
        {
            List<Pais> paises = new List<Pais>();
            try
            {
                conexion.Abrir();
                string consultaPaises = ("SELECT * FROM Vista_de_todos_los_paises");
                using (MySqlCommand comando = new MySqlCommand(consultaPaises, conexion.GetConexion()))
                {
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while ((lector.Read()))
                        {
                            Pais pais = new Pais
                            {
                                PaisId = lector.GetInt32("ID"),
                                Nombre = lector.GetString("Nombre")
                            };
                            paises.Add(pais);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
                conexion.Cerrar();
            }
            return paises;
        }
        public List<Categoria> ObtenerListaCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            try
            {
                conexion.Abrir();
                string consultaCategorias = "SELECT * FROM Vista_de_categorias";
                using (MySqlCommand comando = new MySqlCommand(consultaCategorias, conexion.GetConexion()))
                {
                    using (MySqlDataReader lector = comando.ExecuteReader())

                        while (lector.Read())
                        {
                            Categoria categoria = new Categoria
                            {
                                CategoriaId = lector.GetInt32("ID_Categoria"),
                                Nombre = lector.GetString("Nombre"),
                                Descripcion = lector.GetString("Descripcion")

                            };
                            categorias.Add(categoria);
                        }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
                conexion.Cerrar();
            }
            return categorias;
        }



        //Metodos de estadisticas o utilidades
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
        }
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
                string consultaBaja = "UPDATE Recetas SET FechaBaja = @FechaBaja WHERE RecetaId = @RecetaId";
                using (MySqlCommand comando = new MySqlCommand(consultaBaja, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@FechaBaja", DateTime.Now);
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
                string consultaAlta = "UPDATE Recetas SET FechaBaja = NULL WHERE RecetaId = @RecetaId";
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
    }
}
