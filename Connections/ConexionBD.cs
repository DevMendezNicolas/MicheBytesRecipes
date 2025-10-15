using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MicheBytesRecipes.Connections 
{
    internal class ConexionBD
    {
        private MySqlConnection conexion;

        public ConexionBD()
        {
            //se arma el string/cadena de conexion (se puede googlear y se adapta)
            string connectionString = "Server=localhost;Port=3306;Database=MicheBytes;Uid=root;Pwd=Root;";
            conexion = new MySqlConnection(connectionString);
        }
        public MySqlConnection GetConexion()
        {
            //cuando se necesite la "conexion", la paso con este metodo (es privada)
            return conexion;
        }
        public void Abrir()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    conexion.Open();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error al abrir la conexión a la base de datos", ex);
            }
        }


        public void Cerrar()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }

    }
}
