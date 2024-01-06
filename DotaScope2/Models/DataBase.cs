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
                INSER INTO users (name, password, games, score_sum)
                VALUES
                    ('{name}', '{pas}', 0, 0);";

            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Соединение успешно установлено!");

                    using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, connection))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Запись успешно добавлена!");
                        }
                        else
                        {
                            Console.WriteLine("Не удалось добавить запись.");
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка соединения: " + ex.Message);
                }
            }
        }

        public void insertGame(string id_user, int score)
        {
            string conString = DBConnection.ConnectionString;
            string insertQuery = $@"
                INSER INTO invoker_game (id_user, score)
                VALUES
                    ('{id_user}', {score});";

            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Соединение успешно установлено!");

                    using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, connection))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Запись успешно добавлена!");
                        }
                        else
                        {
                            Console.WriteLine("Не удалось добавить запись.");
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка соединения: " + ex.Message);
                }
            }
        }

        public List<UserScore> getLeaderBoard()
        {
            string conString = DBConnection.ConnectionString;
            string selectQuery = $@"
                SELECT (users.name, invoker_game.score) FROM invoker_game (id_user, score)
                JOIN users ON invoker_game.user_id = users.user_id
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

        public List<UserScore> getUserRecords(int userId)
        {
            string conString = DBConnection.ConnectionString;
            string selectQuery = $@"
                SELECT (users.name, invoker_game.score) FROM invoker_game (id_user, score)
                JOIN users ON invoker_game.user_id = users.user_id
                WHERE (users.id == {userId})
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
}
