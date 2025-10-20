using MicheBytesRecipes.Classes.Recetas;
using MicheBytesRecipes.Connections;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

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


        public bool ModificarReceta(Receta receta, List<int> nuevosIngredientesId, int usuarioModId) 
        {
            bool exito = false;
            try
            {
                conexion.Abrir();

                using (MySqlCommand comando = new MySqlCommand("Modificar_Receta", conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("p_receta_id", receta.RecetaId);
                    comando.Parameters.AddWithValue("p_nombre", receta.Nombre);
                    comando.Parameters.AddWithValue("p_descripcion", receta.Descripcion);
                    comando.Parameters.AddWithValue("p_instrucciones", receta.Instrucciones);
                    comando.Parameters.AddWithValue("p_imagen_receta", receta.ImagenReceta);
                    comando.Parameters.AddWithValue("p_tiempo_preparacion", receta.TiempoPreparacion);
                    comando.Parameters.AddWithValue("p_dificultad", receta.NivelDificultad.ToString());
                    comando.Parameters.AddWithValue("p_pais_id", receta.PaisId);
                    comando.Parameters.AddWithValue("p_categoria_id", receta.CategoriaId);
                    comando.Parameters.AddWithValue("p_usuario_modificador_id", usuarioModId);

                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            string mensaje = reader.GetString(0);
                            if (mensaje.Contains("exitosa"))
                                exito = true;
                        }
                    }
                    foreach (var ingredientesId in nuevosIngredientesId)
                    {
                        using (var cmd = new MySqlCommand("Insertar_ingrediente_por_receta", conexion.GetConexion()))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@p_ingrediente_id", ingredientesId);
                            cmd.Parameters.AddWithValue("@p_receta_id", receta.RecetaId);
                            cmd.ExecuteNonQuery();
                        }
                    }
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
            return exito;
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
        public List<Ingrediente> ObtenerIngredientesPorRecetaId(int recetaId)
        {
            List<Ingrediente> ingredientes = new List<Ingrediente>();
            try
            {
                conexion.Abrir();

                string consulta = "SELECT * FROM Vista_de_todos_los_ingredientes_tipo_y_unidad_x_receta WHERE receta_Id = @RecetaId";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@RecetaId", recetaId);


                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ingrediente ingrediente = new Ingrediente
                            {
                                IngredienteId = reader.GetInt32("ingrediente_id"),
                                Nombre = reader.GetString("nombre"),


                                Unidad = new UnidadMedida
                                {
                                    UnidadMedidaId = reader.GetInt32("unidad_de_medida_id"),
                                    Nombre = reader.GetString("unidad")
                                },

                                Tipo = new TipoIngrediente
                                {
                                    TipoIngredienteId = reader.GetInt32("tipo_ingrediente_id"),
                                    Nombre = reader.GetString("tipo_ingrediente")
                                },
                            };

                            ingredientes.Add(ingrediente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error al obtener ingredientes por receta: " + ex.Message);
                return new List<Ingrediente>();
            }
            finally
            {
                conexion.Cerrar();
            }

            return ingredientes;
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

        //Metodos de mantenimiento
        public bool DarDeBajaReceta(int recetaId, int usuarioId)
        {
            try
            {
                // uso la consulta del store procedure
                conexion.Abrir();
                string consultaBaja = "Dar_de_baja_receta";
                using (MySqlCommand comando = new MySqlCommand(consultaBaja, conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("p_receta_id", recetaId);
                    comando.Parameters.AddWithValue("p_usuario_id", usuarioId);

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

        public bool DarDeAltaReceta(int recetaId, int usuarioId)
        {
            try
            {
                conexion.Abrir();
                string consultaAlta = "Reactivar_receta";
                using (MySqlCommand comando = new MySqlCommand(consultaAlta, conexion.GetConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("p_receta_id", recetaId);
                    comando.Parameters.AddWithValue("p_usuario_id", usuarioId);
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
        // 
        // Obtener lista de recetas para exportar
        public List<Receta> ObtenerTodasRecetasParaExportar(int batchSize = 200)
        {
            var recetas = new Dictionary<int, Receta>();

            try
            {
                conexion.Abrir();

                // 1) Obtener las recetas principales
                string sqlRecetas = "SELECT receta_id, nombre, descripcion, instrucciones,tiempo_preparacion, dificultad, fecha_baja, pais_id, categoria_id, usuario_id FROM Vista_de_receta_completa WHERE fecha_baja IS NULL;";

                using (var cmd = new MySqlCommand(sqlRecetas, conexion.GetConexion()))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("receta_id");

                        var receta = new Receta
                        {
                            RecetaId = id,
                            Nombre = reader["nombre"] as string,
                            Descripcion = reader["descripcion"] as string,
                            Instrucciones = reader["instrucciones"] as string,
                            TiempoPreparacion = reader["tiempo_preparacion"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)reader["tiempo_preparacion"],
                            NivelDificultad = Enum.TryParse(reader["dificultad"] as string, true, out Dificultad dif) ? dif : Dificultad.FÃ¡cil,
                            PaisId = reader["pais_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["pais_id"]),
                            CategoriaId = reader["categoria_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["categoria_id"]),
                            UsuarioId = reader["usuario_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["usuario_id"]),
                            FechaBaja = reader["fecha_baja"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["fecha_baja"]),
                            Ingredientes = new List<Ingrediente>()
                        };
                        recetas[id] = receta;
                    }
                }

                if (recetas.Count == 0)
                {
                    return recetas.Values.ToList();
                }
                // 2) Obtener ingredientes por lotes (batch)
                var allIds = recetas.Keys.ToList();
                for (int i = 0; i < allIds.Count; i += batchSize)
                {
                    var batchIds = allIds.Skip(i).Take(batchSize).ToList();

                    using (var cmdIng = new MySqlCommand())
                    {
                        cmdIng.Connection = conexion.GetConexion();

                        var paramNames = new List<string>();
                        for (int j = 0; j < batchIds.Count; j++)
                        {
                            string pname = "@id" + j;
                            cmdIng.Parameters.AddWithValue(pname, batchIds[j]);
                            paramNames.Add(pname);
                        }

                        cmdIng.CommandText = $@"
            SELECT receta_id, ingrediente_id, nombre,
                   unidad_de_medida_id, unidad,
                   tipo_ingrediente_id, tipo_ingrediente
            FROM Vista_de_todos_los_ingredientes_tipo_y_unidad_x_receta
            WHERE receta_id IN ({string.Join(",", paramNames)});";

                        using (var rdrIng = cmdIng.ExecuteReader())
                        {
                            while (rdrIng.Read())
                            {
                                int recetaId = rdrIng.GetInt32("receta_id");
                                if (!recetas.TryGetValue(recetaId, out var receta)) continue;

                                var ing = new Ingrediente
                                {
                                    IngredienteId = rdrIng["ingrediente_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdrIng["ingrediente_id"]),
                                    Nombre = rdrIng["nombre"] as string,
                                    Unidad = new UnidadMedida
                                    {
                                        UnidadMedidaId = rdrIng["unidad_de_medida_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdrIng["unidad_de_medida_id"]),
                                        Nombre = rdrIng["unidad"] as string
                                    },
                                    Tipo = new TipoIngrediente
                                    {
                                        TipoIngredienteId = rdrIng["tipo_ingrediente_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdrIng["tipo_ingrediente_id"]),
                                        Nombre = rdrIng["tipo_ingrediente"] as string
                                    }
                                };

                                receta.Ingredientes.Add(ing);
                            }
                        }
                    }
                }

                return recetas.Values.ToList();
            }
            catch (Exception ex)
            {

                Console.Error.WriteLine("Error al obtener recetas para exportar: " + ex.Message);
                return new List<Receta>();
            }
            finally
            {
                conexion.Cerrar();
            }
        }
    }
}
