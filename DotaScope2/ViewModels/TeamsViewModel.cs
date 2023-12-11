using DotaScope2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using Avalonia.Media.Imaging;


namespace DotaScope2.ViewModels
{
    public class TeamsViewModel : ViewModelBase
    {
        public string DotaScope => "DotaScope";
        public string Matches => "Matches";
        public string Teams => "Teams";
        public string LogIn => "Login In";
        public TeamsViewModel() { }
        public ObservableCollection<Team> TeamsCollection { get; } = new ObservableCollection<Team>();

        public async Task GetDataFromServer()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = "https://api.opendota.com/api/teams";
                    string jsonResponse = await client.GetStringAsync(apiUrl);
                    System.Diagnostics.Debug.WriteLine(jsonResponse);

                    // Десериализация полученных данных
                    var deserializedData = JsonConvert.DeserializeObject<Team[]>(jsonResponse);

                    // Очистка и добавление данных в коллекцию
                    TeamsCollection.Clear();
                    int k = 1;
                    foreach (var item in deserializedData)
                    {
                        if (k == 10) { break; }
                        item.Total = (int.Parse(item.Wins) + int.Parse(item.Losses)).ToString();
                        item.Id = k.ToString();
                        item.Logo = ImageHelper.LoadFromWeb(new Uri("https://upload.wikimedia.org/wikipedia/commons/4/41/NewtonsPrincipia.jpg"));
                        System.Diagnostics.Debug.WriteLine(item.ToString());
                        TeamsCollection.Add(item);
                        k++;
                    }
                    System.Diagnostics.Debug.WriteLine(TeamsCollection.ToString());
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
