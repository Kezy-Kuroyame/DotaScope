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
using System.Reactive.Linq;
using ReactiveUI;
using System.Windows.Input;

namespace DotaScope2.ViewModels
{
    public class MatchesViewModel : NavigationViewModel
    {
        public MatchesViewModel() 
        {
            NewPlayerComand = ReactiveCommand.Create(NewPlayer);
        }

        public ICommand NewPlayerComand{ get; }
        private async void NewPlayer()
        {
            await GetDataFromServer();
        }
        public string DotaScope => "DotaScope";
        public string Matches => "Matches";
        public string Teams => "Teams";
        public string LogIn => "Login In";

        private string _PlayerID = "138040334";
        public string GivePlayerId
        {
            get { return _PlayerID; }
            private set
            {
                this.RaiseAndSetIfChanged(ref _PlayerID, value);
            }
        }

        private Task<Bitmap?> _Avatar;
        public Task<Bitmap?> GiveAvatar
        {
            get { return _Avatar; }
            private set { this.RaiseAndSetIfChanged(ref _Avatar, value);
                System.Diagnostics.Debug.WriteLine(_Avatar.ToString());
            }
        }

        private Task<Bitmap?> _Rank;
        public Task<Bitmap?> GiveRank
        {
            get { return _Rank; }
            private set
            {
                this.RaiseAndSetIfChanged(ref _Rank, value);
            }
        }

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
        public ObservableCollection<Player> players { get; } = new ObservableCollection<Player>();
        public async Task GetDataFromServer()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiURLforMatch = $"https://api.opendota.com/api/players/{_PlayerID}/matches";
                    string apiURLforHeroes = "https://api.opendota.com/api/heroStats";
                    string apiURLforPlayer = $"https://api.opendota.com/api/players/{_PlayerID}";
                    string apiURLforWinLose = $"https://api.opendota.com/api/players/{_PlayerID}/wl";

                    string jsonResponseMatch = await client.GetStringAsync(apiURLforMatch);
                    string jsonResponseHeroes = await client.GetStringAsync(apiURLforHeroes);
                    string jsonResponsePlayer = await client.GetStringAsync(apiURLforPlayer);
                    string jsonResponseWinLose = await client.GetStringAsync(apiURLforWinLose);

                    // Десериализация полученных данных
                    var deserializedDataMatch = JsonConvert.DeserializeObject<Match[]>(jsonResponseMatch);
                    var deserializedDataHeroes = JsonConvert.DeserializeObject<Hero[]>(jsonResponseHeroes);
                    dynamic profile = JsonConvert.DeserializeObject(jsonResponsePlayer);
                    dynamic WinLose = JsonConvert.DeserializeObject(jsonResponseWinLose);

                    // Очистка и добавление данных в коллекцию
                    MatchesCollection.Clear();
                    int k = 0;
                    string name = profile.profile.personaname;
                    string rank = profile.rank_tier;
                    string ava = profile.profile.avatarmedium;
                    string win = WinLose.win;
                    string lose = WinLose.lose;

                    if (players.Count == 1)
                    {
                        players.Remove(players[0]);
                    }
                    players.Add(new Player(_PlayerID.ToString(), name, rank));

                    if (int.Parse(rank) > 9 && int.Parse(rank) < 16)
                    {
                        GiveRank = ImageHelper.LoadFromWeb(new Uri("https://static.wikia.nocookie.net/dota2_gamepedia/images/2/2b/SeasonalRank1-5.png"));
                    }
                    else if (int.Parse(rank) > 19 && int.Parse(rank) < 26)
                    {
                        GiveRank = ImageHelper.LoadFromWeb(new Uri("https://static.wikia.nocookie.net/dota2_gamepedia/images/3/32/SeasonalRank2-5.png"));
                    }
                    else if (int.Parse(rank) > 29 && int.Parse(rank) < 36)
                    {
                        GiveRank = ImageHelper.LoadFromWeb(new Uri("https://static.wikia.nocookie.net/dota2_gamepedia/images/b/b1/SeasonalRank3-5.png"));
                    }
                    else if (int.Parse(rank) > 39 && int.Parse(rank) < 46)
                    {
                        GiveRank = ImageHelper.LoadFromWeb(new Uri("https://static.wikia.nocookie.net/dota2_gamepedia/images/a/a3/SeasonalRank4-5.png"));
                    }
                    else if (int.Parse(rank) > 49 && int.Parse(rank) < 56)
                    {
                        GiveRank = ImageHelper.LoadFromWeb(new Uri("https://static.wikia.nocookie.net/dota2_gamepedia/images/8/8e/SeasonalRank5-5.png"));
                    }
                    else if (int.Parse(rank) > 59 && int.Parse(rank) < 66)
                    {
                        GiveRank = ImageHelper.LoadFromWeb(new Uri("https://static.wikia.nocookie.net/dota2_gamepedia/images/4/47/SeasonalRank6-5.png"));
                    }
                    else if (int.Parse(rank) > 69 && int.Parse(rank) < 76)
                    {
                        GiveRank = ImageHelper.LoadFromWeb(new Uri("https://static.wikia.nocookie.net/dota2_gamepedia/images/3/33/SeasonalRank7-5.png"));
                    }
                    else if (int.Parse(rank) > 79)
                    {
                        GiveRank = ImageHelper.LoadFromWeb(new Uri("https://static.wikia.nocookie.net/dota2_gamepedia/images/f/f2/SeasonalRankTop0.png"));
                    }
                    else
                    {
                        GiveRank = ImageHelper.LoadFromWeb(new Uri("https://static.wikia.nocookie.net/dota2_gamepedia/images/e/e7/SeasonalRank0-0.png"));
                    }

                    GiveAvatar = ImageHelper.LoadFromWeb(new Uri(ava));
                    System.Diagnostics.Debug.WriteLine(ava);
                    players[0].win = win;
                    players[0].lose = lose;
                    players[0].total = $"{int.Parse(players[0].win) + int.Parse(players[0].lose)}";
                    players[0].percent = $"{float.Parse(players[0].win) * 100 / float.Parse(players[0].total):0.00}%";

                    System.Diagnostics.Debug.WriteLine("-------------------------------------------------------");
                    System.Diagnostics.Debug.WriteLine(players[0].ToString());

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
