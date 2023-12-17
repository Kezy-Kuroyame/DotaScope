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
using Avalonia.Data;    
using Avalonia;
using System.ComponentModel;
using ReactiveUI;
using System.Reactive;
using Avalonia.Controls;
using DotaScope2.Views;


namespace DotaScope2.ViewModels
{
    public class TeamsViewModel: ViewModelBase
    {
        public string DotaScope => "DotaScope";
        public string Matches => "Matches";
        public string Teams => "Teams";
        public string LogIn => "Login In";
        private UserControl _contentView;

        private ObservableCollection<Team> _teamsCollection;
        public ObservableCollection<Team> TeamsCollection
        {
            get
            {
                return _teamsCollection ?? (_teamsCollection = new ObservableCollection<Team>());
            }
            set
            {
                _teamsCollection = value;
                OnPropertyChanged(nameof(Teams));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
                    int k = 1;
                    foreach (var item in deserializedData)
                    {
                        if (k == 10) { break; }
                        item.Total = (int.Parse(item.Wins) + int.Parse(item.Losses)).ToString();
                        item.Id = k.ToString();
                        item.Logo = ImageHelper.LoadFromWeb(new Uri(item.Logo_Url));
                        System.Diagnostics.Debug.WriteLine(item.ToString());
                        TeamsCollection.Add(item);
                        k++;
                    }
                    System.Diagnostics.Debug.WriteLine(TeamsCollection.ToString());
                    foreach (var item in TeamsCollection) {
                        System.Diagnostics.Debug.WriteLine(item.ToString());
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
