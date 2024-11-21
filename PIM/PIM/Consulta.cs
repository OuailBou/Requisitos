using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace PIM
{
    class Consulta
    {
        private ConexionMySQL conexionMySQL;

        // Constructor de la clase Consulta
        public Consulta()
        {
            conexionMySQL = new ConexionMySQL();
        }

        // Método para realizar una consulta SELECT
        public List<object[]> Select(string consulta)
        {
            List<object[]> resultList = new List<object[]>();

            try
            {
                // Crear una nueva conexión a la base de datos
                using (MySqlConnection connection = conexionMySQL.GetConnection())
                {
                    if (connection.State != System.Data.ConnectionState.Open) // Verificar si la conexión ya está abierta
                    {
                        connection.Open(); // Abre la conexión si no está abierta
                    }

                    MySqlCommand command = new MySqlCommand(consulta, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object[] row = new object[reader.FieldCount];
                            reader.GetValues(row);
                            resultList.Add(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta SELECT: " + ex.Message);
            }

            return resultList;
        }

        // Método para realizar una consulta UPDATE
        public void Update(string consulta)
        {
            try
            {
                // Crear una nueva conexión a la base de datos
                using (MySqlConnection connection = conexionMySQL.GetConnection())
                {
                    if (connection.State != System.Data.ConnectionState.Open) // Verificar si la conexión ya está abierta
                    {
                        connection.Open(); // Abre la conexión si no está abierta
                    }

                    MySqlCommand command = new MySqlCommand(consulta, connection);
                    int affectedRows = command.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        Console.WriteLine("Actualización exitosa.");
                    }
                    else
                    {
                        Console.WriteLine("No se actualizó ningún registro.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta UPDATE: " + ex.Message);
            }
        }

        // Método para realizar una consulta DELETE
        public void Delete(string consulta)
        {
            try
            {
                // Crear una nueva conexión a la base de datos
                using (MySqlConnection connection = conexionMySQL.GetConnection())
                {
                    if (connection.State != System.Data.ConnectionState.Open) // Verificar si la conexión ya está abierta
                    {
                        connection.Open(); // Abre la conexión si no está abierta
                    }

                    MySqlCommand command = new MySqlCommand(consulta, connection);
                    int affectedRows = command.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        Console.WriteLine("Eliminación exitosa.");
                    }
                    else
                    {
                        Console.WriteLine("No se eliminó ningún registro.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta DELETE: " + ex.Message);
            }
        }

        // Método para realizar una consulta INSERT
        public void Insert(string consulta)
        {
            try
            {
                // Crear una nueva conexión a la base de datos
                using (MySqlConnection connection = conexionMySQL.GetConnection())
                {
                    if (connection.State != System.Data.ConnectionState.Open) // Verificar si la conexión ya está abierta
                    {
                        connection.Open(); // Abre la conexión si no está abierta
                    }

                    MySqlCommand command = new MySqlCommand(consulta, connection);
                    int affectedRows = command.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        Console.WriteLine("Inserción exitosa.");
                    }
                    else
                    {
                        Console.WriteLine("No se insertó ningún registro.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta INSERT: " + ex.Message);
            }
        }
    }
}
