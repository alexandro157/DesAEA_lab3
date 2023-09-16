﻿//Librerias del ADO .NET
using System.Data.SqlClient;
using System.Data;
using ConsoleApp1;

//using ConsoleApp3;

class Program
{
    // Cadena de conexión a la base de datos
    public static string connectionString = "Data Source=LAB1504-17\\SQLEXPRESS;Initial Catalog=Tecsup2023DB;User ID=usertecsup;Password=123456";


    static void Main()
    {

    }

    //De forma desconectada
    private static DataTable ListarTrabajadoresDataTable()
    {
        // Crear un DataTable para almacenar los resultados
        DataTable dataTable = new DataTable();
        // Crear una conexión a la base de datos
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Abrir la conexión
            connection.Open();

            // Consulta SQL para seleccionar datos
            string query = "SELECT * FROM Trabajadores";

            // Crear un adaptador de datos
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


            // Llenar el DataTable con los datos de la consulta
            adapter.Fill(dataTable);

            // Cerrar la conexión
            connection.Close();

        }
        return dataTable;
    }

    //De forma conectada
    private static List<Trabajador> ListarTrabajadoresListaObjetos()
    {
        List<Trabajador> trabajadores = new List<Trabajador>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Abrir la conexión
            connection.Open();

            // Consulta SQL para seleccionar datos
            string query = "SELECT IdTrabajador,Nombre,Apellido,Sueldo,FechaNacimiento FROM Trabajadores1";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Verificar si hay filas
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Leer los datos de cada fila

                            trabajadores.Add(new Trabajador
                            {
                                Id = (int)reader["IdEmpleado"],
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Sueldo = reader["Sueldo"].ToString(),
                                FechaNacimiento = reader["FechaNacimiento"].ToString()
                            });

                        }
                    }
                }
            }

            // Cerrar la conexión
            connection.Close();


        }
        return trabajadores;

    }


}