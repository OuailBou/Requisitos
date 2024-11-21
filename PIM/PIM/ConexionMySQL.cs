using System;
using MySql.Data.MySqlClient;

namespace PIM
{
    class ConexionMySQL : Connection, IDisposable
    {
        private MySqlConnection connection;
        private string cadenaConexion;

        public ConexionMySQL()
        {
            cadenaConexion = "Database=" + database +
                             "; DataSource=" + server +
                             "; User Id=" + user +
                             "; Password=" + password;

            connection = new MySqlConnection(cadenaConexion);
        }

        public MySqlConnection GetConnection()
        {
            // Cerrar la conexión si ya está abierta
            CloseConnection();

            // Conectar con la base de datos
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return connection;
        }

        public void CloseConnection()
        {
            // Cerrar la conexión si está abierta
            if (connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void Dispose()
        {
            // Asegurarse de que la conexión se cierra y se libera correctamente
            CloseConnection();
            if (connection != null)
            {
                connection.Dispose();
                connection = null;
            }
        }
    }
}
