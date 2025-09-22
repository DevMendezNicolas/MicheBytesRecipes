using MicheBytesRecipes.Classes.Recetas;
using MicheBytesRecipes.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace MicheBytesRecipes.Classes.Recetas
{
    internal class GestorReceta
    {
        ConexionBD conexion = new ConexionBD();
        // Lista de recetas
        public List<Receta> recetas;

        // ---- CRUD ----
        public void AgregarReceta(Receta receta)
        {
            //Validacion con try catch porque las conexiones externas pueden fallar
            //Ejemplo: la base de datos no esta disponible
            try
            {
                //Abrir la conexion
                conexion.Abrir();
                // Comando SQL para insertar una nueva receta
                string consultaAgregar = "INSERT INTO Recetas (Nombre, Descripcion, Instrucciones, ImagenReceta, TiempoPreparacion, NivelDificultad, FechaRegistro) " +
                    "VALUES (@Nombre, @Descripcion, @Instrucciones, @ImagenReceta, @TiempoPreparacion, @NivelDificultad, @FechaRegistro);";

                using (MySqlCommand comando = new MySqlCommand(consultaAgregar, conexion.GetConexion()))
                {
                    //Asignar los parametros del comando SQL
                    comando.Parameters.AddWithValue("@Nombre", receta.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", receta.Descripcion);
                    comando.Parameters.AddWithValue("@Instrucciones", receta.Instrucciones);
                    comando.Parameters.AddWithValue("@ImagenReceta", receta.ImagenReceta);
                    comando.Parameters.AddWithValue("@TiempoPreparacion", receta.TiempoPreparacion);
                    comando.Parameters.AddWithValue("@NivelDificultad", receta.NivelDificultad.ToString());
                    comando.Parameters.AddWithValue("@FechaRegistro", receta.FechaRegistro);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                        MessageBox.Show("Receta agregada exitosamente.");
                    else
                        MessageBox.Show("No se pudo agregar la receta.");
                }

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
        }
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

        //Metodo para agregar un ingrediente
        public void AgregarIngrediente(Ingrediente ingrediente)
        {
            try
            {
                conexion.Abrir();
                string consultaAgregarIngrediente = "INSERT INTO Ingredientes (Nombre, UnidadMedida, Origen) VALUES (@Nombre, @UnidadMedida, @Origen)";
                using (MySqlCommand comando = new MySqlCommand(consultaAgregarIngrediente, conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@Nombre", ingrediente.Nombre);
                    comando.Parameters.AddWithValue("@UnidadMedida", ingrediente.Unidad.ToString());
                    comando.Parameters.AddWithValue("@Origen", ingrediente.TipoOrigen.ToString());

                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                        MessageBox.Show("Ingrediente agregado exitosamente.");
                    else
                        MessageBox.Show("No se pudo agregar el ingrediente.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al agregar el ingrediente: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
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

        //Metodos de busqueda
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
