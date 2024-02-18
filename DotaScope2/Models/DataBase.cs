using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaScope2.Models;
using Npgsql;
using SQLitePCL;
using Microsoft.Data.Sqlite;

using static System.Formats.Asn1.AsnWriter;
using System.Reflection;
using Avalonia;
using Avalonia.Platform;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Reflection.Metadata;

namespace DotaScope2.Models
{
    public class DataBase
    {

        private bool _isMobile = false;
        public bool IsMobile {
            get { return _isMobile; }
            set
            {
                _isMobile = value;
            }
        }

        public async Task insertUser(string name, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                if (IsMobile) 
                {
                    try
                    {
                        string apiUrl = $"http://10.0.2.2:5000/users";
                        var request = new User(0, name, password);
                        var jsonContent = JsonConvert.SerializeObject(request);
                        var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                        System.Diagnostics.Debug.WriteLine(response);

                        if (response.IsSuccessStatusCode)
                        {
                            // Read the response content as string
                            string responseBody = await response.Content.ReadAsStringAsync();
                            Console.WriteLine("Response: " + responseBody);
                        }
                        else
                        {
                            // Print the HTTP status code if the request was not successful
                            Console.WriteLine("HTTP Status Code: " + response.StatusCode);
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else 
                {
                    try
                    {
                        string apiUrl = $"http://127.0.0.1:5000/users";
                        var request = new User(0, name, password);
                        var jsonContent = JsonConvert.SerializeObject(request);
                        var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                        System.Diagnostics.Debug.WriteLine(response);

                        if (response.IsSuccessStatusCode)
                        {
                            // Read the response content as string
                            string responseBody = await response.Content.ReadAsStringAsync();
                            Console.WriteLine("Response: " + responseBody);
                        }
                        else
                        {
                            // Print the HTTP status code if the request was not successful
                            Console.WriteLine("HTTP Status Code: " + response.StatusCode);
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }


        public async Task insertGame(int id_user, int score)
        {
            using (HttpClient client = new HttpClient())
            {
                if (IsMobile)
                {
                    try
                    {
                        string apiUrl = $"http://10.0.2.2:5000/invokergame";
                        var request = new InvokerGame(0, id_user, score);
                        var jsonContent = JsonConvert.SerializeObject(request);
                        var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                        System.Diagnostics.Debug.WriteLine(response);

                        if (response.IsSuccessStatusCode)
                        {
                            // Read the response content as string
                            string responseBody = await response.Content.ReadAsStringAsync();
                            Console.WriteLine("Response: " + responseBody);
                        }
                        else
                        {
                            // Print the HTTP status code if the request was not successful
                            Console.WriteLine("HTTP Status Code: " + response.StatusCode);
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        string apiUrl = $"http://127.0.0.1:5000/invokergame";
                        var request = new InvokerGame(0, id_user, score);
                        var jsonContent = JsonConvert.SerializeObject(request);
                        var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                        System.Diagnostics.Debug.WriteLine(response);

                        if (response.IsSuccessStatusCode)
                        {
                            // Read the response content as string
                            string responseBody = await response.Content.ReadAsStringAsync();
                            Console.WriteLine("Response: " + responseBody);
                        }
                        else
                        {
                            // Print the HTTP status code if the request was not successful
                            Console.WriteLine("HTTP Status Code: " + response.StatusCode);
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public async Task<User> getUserIdByName(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                if (IsMobile)
                {
                    try
                    {
                        string apiUrl = $"http://10.0.2.2:5000/users";
                        string jsonResponse = await client.GetStringAsync(apiUrl);
                        System.Diagnostics.Debug.WriteLine(jsonResponse);

                        // Десериализация полученных данных
                        User[] deserializedData = JsonConvert.DeserializeObject<User[]>(jsonResponse);

                        foreach (var item in deserializedData)
                        {
                            if (item.Name == name)
                            {
                                return item;
                            }
                        }
                        return null;
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
                else
                {
                    try
                    {
                        string apiUrl = $"http://127.0.0.1:5000/users";
                        string jsonResponse = await client.GetStringAsync(apiUrl);
                        System.Diagnostics.Debug.WriteLine(jsonResponse);

                        // Десериализация полученных данных
                        User[] deserializedData = JsonConvert.DeserializeObject<User[]>(jsonResponse);

                        foreach (var item in deserializedData)
                        {
                            if (item.Name == name)
                            {
                                return item;
                            }
                        }
                        return null;
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
            }
        }


        public async Task<User> getUserById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                if (IsMobile)
                {
                    try
                    {
                        string apiUrl = $"http://10.0.2.2:5000/users/{id}";
                        string jsonResponse = await client.GetStringAsync(apiUrl);
                        System.Diagnostics.Debug.WriteLine(jsonResponse);

                        // Десериализация полученных данных
                        User deserializedData = JsonConvert.DeserializeObject<User>(jsonResponse);

                        // Очистка и добавление данных в коллекцию
                        if (deserializedData != null)
                        {
                            return deserializedData;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
                else
                {
                    try
                    {
                        string apiUrl = $"http://127.0.0.1:5000/users/{id}";
                        string jsonResponse = await client.GetStringAsync(apiUrl);
                        System.Diagnostics.Debug.WriteLine(jsonResponse);

                        // Десериализация полученных данных
                        User deserializedData = JsonConvert.DeserializeObject<User>(jsonResponse);

                        // Очистка и добавление данных в коллекцию
                        if (deserializedData != null)
                        {
                            return deserializedData;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
            }
        }


        public async Task<List<UserScore>> getLeaderBoard()
        {
            using (HttpClient client = new HttpClient())
            {
               
                if (IsMobile)
                {
                    try
                    {
                        string apiUrl = $"http://10.0.2.2:5000/leaderboard";
                        string jsonResponse = await client.GetStringAsync(apiUrl);
                        System.Diagnostics.Debug.WriteLine(jsonResponse);

                        // Десериализация полученных данных
                        UserScore[] deserializedData = JsonConvert.DeserializeObject<UserScore[]>(jsonResponse);

                        // Очистка и добавление данных в коллекцию
                        if (deserializedData != null)
                        {
                            return deserializedData.ToList();
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
                else
                {
                    try
                    {
                        string apiUrl = $"http://127.0.0.1:5000/leaderboard";
                        string jsonResponse = await client.GetStringAsync(apiUrl);
                        System.Diagnostics.Debug.WriteLine(jsonResponse);

                        // Десериализация полученных данных
                        UserScore[] deserializedData = JsonConvert.DeserializeObject<UserScore[]>(jsonResponse);

                        // Очистка и добавление данных в коллекцию
                        if (deserializedData != null)
                        {
                            return deserializedData.ToList();
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
            }
        }
    

        public async Task<List<UserScore>> getUserIdRecords(int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                if (IsMobile)
                {
                    try
                    {
                        string apiUrl = $"http://10.0.2.2:5000/leaderboard/{userId}";
                        string jsonResponse = await client.GetStringAsync(apiUrl);
                        System.Diagnostics.Debug.WriteLine(jsonResponse);

                        // Десериализация полученных данных
                        UserScore[] deserializedData = JsonConvert.DeserializeObject<UserScore[]>(jsonResponse);

                        // Очистка и добавление данных в коллекцию
                        if (deserializedData != null)
                        {
                            return deserializedData.ToList();
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
                else
                {
                    try
                    {
                        string apiUrl = $"http://127.0.0.1:5000/leaderboard/{userId}";
                        string jsonResponse = await client.GetStringAsync(apiUrl);
                        System.Diagnostics.Debug.WriteLine(jsonResponse);

                        // Десериализация полученных данных
                        UserScore[] deserializedData = JsonConvert.DeserializeObject<UserScore[]>(jsonResponse);

                        // Очистка и добавление данных в коллекцию
                        if (deserializedData != null)
                        {
                            return deserializedData.ToList();
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
            }
        }
     }

    
}
  

