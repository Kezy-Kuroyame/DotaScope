using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaScope2.Models;
using Npgsql;
using static System.Formats.Asn1.AsnWriter;

namespace DotaScope2.Models
{
    internal class DataBase
    {
        public void insertUser(string name, string pas)
        {
            string conString = DBConnection.ConnectionString;
            string insertQuery = $@"
                INSERT INTO users (name, password, games, score_sum)
                VALUES
                    ('{name}', '{pas}', 0, 0);";

            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                try
                {
                    connection.Open();
                    System.Diagnostics.Debug.WriteLine("Соединение успешно установлено!");

                    using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, connection))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            System.Diagnostics.Debug.WriteLine("Запись успешно добавлена!");
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Не удалось добавить запись.");
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Ошибка соединения: " + ex.Message);
                }
            }
        }

        public void insertGame(int id_user, int score)
        {
            string conString = DBConnection.ConnectionString;
            string insertQuery = $@"
                INSERT INTO invoker_game (id_user, score)
                VALUES
                    ({id_user}, {score});";

            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                try
                {
                    connection.Open();
                    System.Diagnostics.Debug.WriteLine("Соединение успешно установлено!");

                    using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, connection))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            System.Diagnostics.Debug.WriteLine("Запись успешно добавлена!");
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Не удалось добавить запись.");
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Ошибка соединения: " + ex.Message);
                }
            }
        }

        public int getUserIdDb(string name)
        {
            string conString = DBConnection.ConnectionString;
            string selectQuery = $@"
                SELECT* FROM users 
                WHERE users.name = '{name}'
                ";
            List<User> users = new List<User>();
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand(selectQuery, connection))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User entity = new User
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Password = reader.GetString(2)
                                };
                                users.Add(entity);
                            }
                            System.Diagnostics.Debug.WriteLine("Соединение закрыто");
                            connection.Close();
                            if (users.Count == 0)
                            {
                                return -1;
                            }
                            else
                            {
                                return users[0].Id;
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Ошибка: " + ex.Message);
                    return -2;
                }
            }
        }

        public User getUserById(int id)
        {
            string conString = DBConnection.ConnectionString;
            string selectQuery = $@"
                SELECT* FROM users 
                WHERE users.id_user = '{id}'
                ";
            List<User> users = new List<User>();
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand(selectQuery, connection))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User entity = new User
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Password = reader.GetString(2)
                                };
                                users.Add(entity);
                            }
                            System.Diagnostics.Debug.WriteLine("Соединение закрыто");
                            connection.Close();
                            if (users.Count == 0)
                            {
                                return null;
                            }
                            else
                            {
                                return users[0];
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Ошибка: " + ex.Message);
                    return null;
                }
            }
        }

        public List<UserScore> getLeaderBoard()
        {
            string conString = DBConnection.ConnectionString;
            string selectQuery = $@"
                SELECT users.name as Name, invoker_game.score as Score FROM invoker_game
                JOIN users ON invoker_game.id_user = users.id_user
                ORDER BY invoker_game.score DESC
                LIMIT 10;";

            List<UserScore> scores = new List<UserScore>();
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand(selectQuery, connection))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserScore entity = new UserScore
                                {
                                    Name = reader.GetString(0),
                                    Score = reader.GetInt32(1), 
                                };
                                scores.Add(entity);
                            }
                            connection.Close();
                            return scores;
                        }
                    }

                }
                catch (Exception ex ){
                    System.Diagnostics.Debug.WriteLine("Ошибка: " + ex.Message);
                    return scores;
                }
            }
        }

        public List<UserScore> getUserIdRecords(int userId)
        {
            string conString = DBConnection.ConnectionString;
            string selectQuery = $@"
                SELECT users.name as Name, invoker_game.score as Score FROM invoker_game 
                JOIN users ON invoker_game.id_user = users.id_user
                WHERE (users.id_user = {userId})
                ORDER BY invoker_game.score DESC
                LIMIT 5;";

            List<UserScore> scores = new List<UserScore>();
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand(selectQuery, connection))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserScore entity = new UserScore
                                {
                                    Name = reader.GetString(0),
                                    Score = reader.GetInt32(1),
                                };
                                scores.Add(entity);
                            }
                            connection.Close();
                            return scores;
                        }
                    }

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Ошибка: " + ex.Message);
                    return scores;
                }
            }
        }
    }

    public class UserScore
    {
        public string Name { get; set; }
        public int Score { get; set; }
        // Добавьте дополнительные свойства, соответствующие вашим столбцам
    }

    public class User
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        // Добавьте дополнительные свойства, соответствующие вашим столбцам
    }
}
