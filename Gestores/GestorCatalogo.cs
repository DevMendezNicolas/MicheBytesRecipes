using MicheBytesRecipes.Classes.Recetas;
using MicheBytesRecipes.Connections;
using MicheBytesRecipes.Helpers;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Session;
using Org.BouncyCastle.Utilities.Zlib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MicheBytesRecipes.Managers
{
    public class GestorCatalogo
    {
        ConexionBD conexion = new ConexionBD();

        //Metodos para obtener paises y categorias por ID
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

        //Metodos para agregar paises y categorias
        public bool AgregarPais(Pais pais)
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
                        Console.WriteLine("País agregado exitosamente.");
                    else
                    {
                        Console.Error.WriteLine("No se pudo agregar el país.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error al agregar el país: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return true;
        }
        public bool AgregarCategoria(Categoria categoria)
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
                        Console.WriteLine("Categoria agregada exitosamente.");
                    }
                    else
                    {
                        Console.Error.WriteLine("No se pudo agregar la categoria.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error al agregar categoria: " + ex.Message);
            }
            finally { conexion.Cerrar(); }
            return true;
        }

        //Metodos para obtener listas de paises, categorias, tipos de ingredientes y unidades de medida
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

        //Metodos para verificar si existen paises o categorias por nombre
        public bool CategoriaExiste(string nombre)
        {
            var categorias = ObtenerListaCategorias();
            return categorias
                .Any(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }
        public bool PaisExiste(string nombre)
        {
            var paises = ObtenerListaPaises();
            return paises.Any(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }
    }
}
