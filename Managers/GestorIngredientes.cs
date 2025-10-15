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

namespace MicheBytesRecipes.Managers
{
    public class GestorIngredientes
    {
        ConexionBD conexion = new ConexionBD();

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
                Console.Error.WriteLine("Error al obtener los ingredientes: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return ingredientes;
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

    }
}
