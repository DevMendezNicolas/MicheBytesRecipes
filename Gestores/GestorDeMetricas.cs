using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicheBytesRecipes.Classes.Interacciones;
using MicheBytesRecipes.Connections;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace MicheBytesRecipes.Managers
{
    internal class GestorDeMetricas
    {
        private ConexionBD conexion;
        public GestorDeMetricas()
        {
            conexion = new ConexionBD();
        }
        // Obtiene las métricas de las recetas activas (fechaBaja IS NULL)
        public List<Metricas> ObtenerMetricasActivas()
        {
           List <Metricas> metricas = new List<Metricas>();
            try
            {
                conexion.Abrir();
                string consulta = "Select * FROM vista_metricas_recetas where fechaBaja IS NULL";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Metricas metrica = new Metricas
                                (
                                    reader.GetInt32("receta_id"),
                                    reader.GetString("nombre"),
                                    reader.GetString("categoria"),
                                    reader.GetInt32("CantidadFavoritos"),
                                    reader.GetInt32("CantidadComentarios"),
                                    reader.GetInt32("CantidadLikes"),
                                    reader.GetInt32("CantidadVisualizaciones"),
                                    reader.IsDBNull(reader.GetOrdinal("fechaBaja")) ? (DateTime?)null : reader.GetDateTime("fechaBaja")
                                );
                            metricas.Add(metrica);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las métricas: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
                
            }
            return metricas;
        }
        // Obtiene las métricas de las recetas inactivas (fechaBaja IS NOT NULL)
        public List<Metricas> ObtenerMetricasInactivas()
        {
            List<Metricas> metricas = new List<Metricas>();
            try
            {
                conexion.Abrir();
                string consulta = "Select * FROM vista_metricas_recetas where fechaBaja IS NOT NULL";
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConexion()))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Metricas metrica = new Metricas
                                (
                                    reader.GetInt32("receta_id"),
                                    reader.GetString("nombre"),
                                    reader.GetString("categoria"),
                                    reader.GetInt32("CantidadFavoritos"),
                                    reader.GetInt32("CantidadComentarios"),
                                    reader.GetInt32("CantidadLikes"),
                                    reader.GetInt32("CantidadVisualizaciones"),
                                    reader.IsDBNull(reader.GetOrdinal("fechaBaja")) ? (DateTime?)null : reader.GetDateTime("fechaBaja")
                                );
                            metricas.Add(metrica);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las métricas: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
            return metricas;
        }
    }
}
