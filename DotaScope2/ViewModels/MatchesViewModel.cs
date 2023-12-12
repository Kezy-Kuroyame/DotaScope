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
using System.Security.Cryptography.X509Certificates;
using System.Collections.Specialized;
using System.Xml.Schema;

namespace DotaScope2.ViewModels
{
    public class MatchesViewModel: ViewModelBase
    {
        public MatchesViewModel() { }
        public string DotaScope => "DotaScope";
        public string Matches => "Matches";
        public string Teams => "Teams";
        public string LogIn => "Login In";
        public static DateTime UnixTimeToDateTime(double unixTime)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(unixTime).ToLocalTime();
            return dateTime;
        }
        public string howLongAgo(DateTime dateTime)
        {
            TimeSpan new_date = DateTime.Now.Subtract(dateTime);
            if (new_date.Days > 0)
            {
                return $"{new_date.Days} days ago";
            }
            else if (new_date.Hours > 0)
            {
                return $"{new_date.Hours} hours ago";
            }
            else if (new_date.Minutes > 0)
            {
                return $"{new_date.Minutes} minutes ago";
            }
            else
            {
                return $"{new_date.Seconds} seconds ago";
            }
        }
        public ObservableCollection<Match> MatchesCollection { get; } = new ObservableCollection<Match>();
        public async Task GetDataFromServer()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    int account_id = 291273072;
                    string apiURLforMatch = $"https://api.opendota.com/api/players/{account_id}/matches";
                    string apiURLforHeroes = "https://api.opendota.com/api/heroStats";
                    //string apiURLforPlayer = "https://api.opendota.com/api/players/{account_id}";
                    //string apiURLforWinLose = "https://api.opendota.com/api/players/{account_id}/wl";

                    string jsonResponseMatch = await client.GetStringAsync(apiURLforMatch);
                    string jsonResponseHeroes = await client.GetStringAsync(apiURLforHeroes);
                    //string jsonResponsePlayer = await client.GetStringAsync(apiURLforPlayer);
                    //string jsonResponseWinLose = await client.GetStringAsync(apiURLforPlayer);

                    // Десериализация полученных данных
                    var deserializedDataMatch = JsonConvert.DeserializeObject<Match[]>(jsonResponseMatch);
                    var deserializedDataHeroes = JsonConvert.DeserializeObject<Hero[]>(jsonResponseHeroes);
                   // var deserializedDataPlayer = JsonConvert.DeserializeObject<Player[]>(jsonResponsePlayer);
                   // var deserializedDataWinLose = JsonConvert.DeserializeObject<WinLose[]>(jsonResponseWinLose);

                    // Очистка и добавление данных в коллекцию
                    MatchesCollection.Clear();
                    int k = 0;
                   // foreach (var stat in deserializedDataPlayer)
                    //{
                      //  stat.imgAvatar = ImageHelper.LoadFromWeb(new Uri("https://api.opendota.com" + stat.avatar));
                        //foreach(var item in deserializedDataWinLose)
                        //{
                         //   stat.win = item.win;
                         //   stat.lose = item.lose;
                       // }
                        //stat.total = $"{int.Parse(stat.win) + int.Parse(stat.lose)}";
                        //stat.percent = $"{float.Parse(stat.win) * 100 / float.Parse(stat.total):0.00}%";
                   // }
                    foreach (var item in deserializedDataMatch)
                    {
                        if (k == 15) { break; }
                        System.Diagnostics.Debug.WriteLine(item.ToString());
                        switch (int.Parse(item.player_slot))
                        {
                            case <128: 
                                if (item.radiant_win == "true") 
                                    {
                                        item.win = "Won match";
                                    }
                                else
                                    {
                                        item.win = "Lost match";
                                    }
                                break; 
                            case >127:
                                if (item.radiant_win == "true")
                                {
                                    item.win = "Lost match";
                                }
                                else
                                {
                                    item.win = "Won match";
                                }
                                break;
                        }
                        switch (int.Parse(item.game_mode))
                        {
                            case 2:
                                item.string_game_mode = "Captains Mode";
                                break;
                            case 4:
                                item.string_game_mode = "Single Draft";
                                break;
                            case 22:
                                item.string_game_mode = "All Pick";
                                break;
                            case 23:
                                item.string_game_mode = "Turbo";
                                break;
                            default:
                                item.string_game_mode = "Unknown Mode";
                                break;
                        }
                        switch (int.Parse(item.lobby_type))
                        {
                            case 7:
                                item.string_lobby_type = "Ranked";
                                break;
                            default:
                                item.string_lobby_type = "Normal";
                                break;
                        }

                        DateTime game_date = UnixTimeToDateTime(double.Parse(item.start_time) + double.Parse(item.duration));
                        item.how_long_ago = howLongAgo(game_date);
                        item.normal_duration = $"{int.Parse(item.duration) / 60}:{(int.Parse(item.duration) % 60):00}";

                        foreach (var hero in deserializedDataHeroes)
                        {
                            if (hero.id == item.hero_id)
                            {
                                item.img = ImageHelper.LoadFromWeb(new Uri("https://api.opendota.com" + hero.img)); 
                                break;
                            }
                        }

                        MatchesCollection.Add(item);
                        k++;
                    }
                    System.Diagnostics.Debug.WriteLine(MatchesCollection.ToString());
                    Console.WriteLine(MatchesCollection.ToString());

                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
