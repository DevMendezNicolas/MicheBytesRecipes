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
        //Metodo para obtener ingredientes
        public List<Ingrediente> ObtenerIngredientes()
        {
            List<Ingrediente> ingredientes = new List<Ingrediente>();
            try
            {
                conexion.Abrir();
                string consultaListar = "SELECT * FROM Vista_de_todos_los_ingredientes";
                using (MySqlCommand comando = new MySqlCommand(consultaListar, conexion.GetConexion()))
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        ingredientes.Add(new Ingrediente
                        {
                            IngredienteId = lector.GetInt32("ingrediente_id"),
                            Nombre = lector.GetString("nombre")
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
        public void AgregarPais(Pais pais)
        {
            try
            {
                conexion.Abrir();
                using (MySqlCommand comando = new MySqlCommand("insertar_paises", conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@p_nombre_pais", pais.Nombre);
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
                                PaisId = lector.GetInt32("pais_id"),
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
                string consultaCategorias = "SELECT * FROM Vista_de_las_categorias";
                using (MySqlCommand comando = new MySqlCommand(consultaCategorias, conexion.GetConexion()))
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Categoria categoria = new Categoria
                        {
                            CategoriaId = lector.GetInt32("categoria_id"), // <- nombre real en la vista
                            Nombre = lector.GetString("nombre")            // <- nombre real en la vista
                        };
                        categorias.Add(categoria);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
                return new List<Categoria>(); // mejor devolver lista vacía en vez de null
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

        // Obtener la previsualización de las recetas
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
        // Obtener la previsualizacion de las recetas inactivas
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
        // obtener previsualizacion de recetas por nombre, categoria, pais, dificultad
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
        // Obtener pais
        /*public string ObtenerPais(int paisId)
        {
            string nombrePais = string.Empty;
            try
            {
                conexion.Abrir();
                string consultaPais = "SELECT Devolver_nombre_pais(@PaisId)";

                using (MySqlCommand comando = new MySqlCommand(consultaPais, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@PaisId", paisId);
                    object resultado = comando.ExecuteScalar();
                    if (resultado != null)
                    {
                        nombrePais = resultado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el país: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return nombrePais;
        }*/

        public Pais ObtenerPaisPorId(int paisId)
        {
            try
            {
                conexion.Abrir();
                string consultaPais = "SELECT * FROM Vista_de_todos_los_paises WHERE pais_id = @PaisId";
                using (MySqlCommand comando = new MySqlCommand(consultaPais, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@PaisId", paisId);
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return new Pais
                            {
                                PaisId = lector.GetInt32("pais_id"),
                                Nombre = lector.GetString("nombre")
                            };
                        }
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
            return null; // Retorna null si no se encuentra el país
        }

        // Obtener categoria
        /*public string ObtenerCategoria(int categoriaId)
        {
            string nombreCategoria = string.Empty;
            try
            {
                conexion.Abrir();
                string consultaCategoria = "SELECT Devolver_nombre_categoria(@CategoriaId)";
                using (MySqlCommand comando = new MySqlCommand(consultaCategoria, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@CategoriaId", categoriaId);
                    object resultado = comando.ExecuteScalar();
                    if (resultado != null)
                    {
                        nombreCategoria = resultado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la categoría: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return nombreCategoria;
        }*/

        public Categoria ObtenerCategoriaPorId(int categoriaId)
        {
            try
            {
                conexion.Abrir();
                string consultaCategoria = "SELECT * FROM Vista_de_las_categorias WHERE categoria_id = @CategoriaId";
                using (MySqlCommand comando = new MySqlCommand(consultaCategoria, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@CategoriaId", categoriaId);
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return new Categoria
                            {
                                CategoriaId = lector.GetInt32("categoria_id"),
                                Nombre = lector.GetString("nombre"),
                            };
                        }
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
            return null; // Retorna null si no se encuentra la categoría
        }
        // Obtener receta por ID
        public Receta ObtenerRecetaPorId(int recetaId)
        {
            Receta receta = null;

            try
            {
                conexion.Abrir();

                using (MySqlCommand comando = new MySqlCommand("Devolver_receta", conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Parámetro de entrada
                    comando.Parameters.AddWithValue("p_receta_id", recetaId);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            receta = new Receta
                            {
                                RecetaId = recetaId,
                                Nombre = reader["nombre"] == DBNull.Value ? "" : reader["nombre"].ToString(),
                                Descripcion = reader["descripcion"] == DBNull.Value ? "" : reader["descripcion"].ToString(),
                                Instrucciones = reader["instrucciones"] == DBNull.Value ? "" : reader["instrucciones"].ToString(),
                                ImagenReceta = reader["imagen_receta"] == DBNull.Value ? null : (byte[])reader["imagen_receta"],
                                TiempoPreparacion = reader["tiempo_preparacion"] == DBNull.Value
                                    ? TimeSpan.Zero
                                    : (TimeSpan)reader["tiempo_preparacion"],
                                NivelDificultad = reader["dificultad"] == DBNull.Value
                                    ? Dificultad.Fácil
                                    : Enum.TryParse(reader["dificultad"].ToString(), true, out Dificultad d) ? d : Dificultad.Fácil,
                                PaisId = reader["pais_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["pais_id"]),
                                CategoriaId = reader["categoria_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["categoria_id"]),
                                UsuarioId = reader["usuario_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["usuario_id"])
                            };
                        }
                    }
                }
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
        // Agregar receta a favoritos por store procedure Insertar_favorita
        public bool AgregarRecetaAFavoritos(int usuarioId, int recetaId)
        {
            bool exito = false;
            try
            {
                conexion.Abrir();
                using (MySqlCommand comando = new MySqlCommand("Insertar_favorita", conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@p_usuario_id", usuarioId);
                    comando.Parameters.AddWithValue("@p_receta_id", recetaId);
                    int filasAfectadas = comando.ExecuteNonQuery();
                    exito = filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la receta a favoritos: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return exito;
        }

    }

}
