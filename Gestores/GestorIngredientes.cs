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
        public bool AgregarIngrediente(Ingrediente ingrediente)
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
                        Console.WriteLine("Ingrediente agregado exitosamente.");
                    else
                    {
                        Console.Error.WriteLine("No se pudo agregar el ingrediente.");
                        return false;
                    }
                        
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
            return true;
        }

        //Metodo para saber si un ingrediente ya existe 
        public bool IngredienteExiste(string nombre)
        {
            var ingredientes = ObtenerIngredientes();
            return ingredientes.Exists(i => i.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }
    }
}
