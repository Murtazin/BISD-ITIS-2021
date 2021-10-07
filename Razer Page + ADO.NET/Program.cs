using System;
using System.Threading.Tasks;
using Npgsql;
using System.Configuration;

namespace AnimeProject
{
    class MainClass
    {
        public static async Task Main(string[] args)
        {
            //var connectionString = @"username=renatmurtazin;host=localhost;port=5432;database=postgres;password=p@ssw0rd;";

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Console.WriteLine(connectionString);
            //string npgsqlExpression = "UPDATE Users SET id_user=200 WHERE login_user='renatmurtazin'";
            //string npgsqlExpression = "DELETE FROM Users WHERE login_user='renatmurtazin'";
            //string npgsqlExpression = "INSERT INTO Users(id_user, password_user, login_user, email_user) VALUES (100, 'p@ssw0rd', 'renatmurtazin', 'renatmurtazin@yahoo.com')";
            string npgsqlExpression = "SELECT * FROM Users";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(npgsqlExpression, connection);
                NpgsqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}", reader.GetName(0), reader.GetName(1));

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string password = reader.GetString(1);

                        Console.WriteLine("{0}\t{1}", id, password);
                    }
                }
                reader.Close();
            }

            Console.Read();


            //string sqlExpression = "SELECT COUNT(*) FROM Users";

            //using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            //{
            //    connection.Open();
            //    NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection);
            //    object count = command.ExecuteScalar();

            //    command.CommandText = "SELECT MIN(Age) FROM Users";
            //    object minAge = command.ExecuteScalar();

            //    Console.WriteLine("В таблице {0} объектов", count);
            //    Console.WriteLine("Минимальный возраст: {0}", minAge);
            //}

            //using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            //{
            //    connection.Open();
            //    NpgsqlCommand command = new NpgsqlCommand(npgsqlExpression, connection);
            //    command.ExecuteNonQuery();
            //}

            //using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            //{
            //    connection.Open();
            //    NpgsqlCommand command = new NpgsqlCommand(npgsqlExpression, connection);
            //    command.ExecuteNonQuery();
            //}


            //NpgsqlConnection connection = new NpgsqlConnection(connectionString);

            //try
            //{
            //    // Открываем подключение
            //    connection.Open();
            //    Console.WriteLine("Подключение открыто");
            //}
            //catch (NpgsqlException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    // закрываем подключение
            //    connection.Close();
            //    Console.WriteLine("Подключение закрыто...");
            //}





            //Console.Read();

            //var connection = new NpgsqlConnection(connectionString);
            //await connection.OpenAsync();

            //var command = new NpgsqlCommand("INSERT INTO Note(name, lastName) VALUES ('anyName', 'anyLastName')", connection);
            //command.Parameters.AddWithValue("", "");
            //await command.ExecuteNonQueryAsync();
        }
    }
}
