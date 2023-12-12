using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;

namespace DotaScope2.Models
{
    public class Team
    {

        [JsonProperty("name")] 
        public string Name { get; set; }

        [JsonProperty("wins")]  
        public string Wins { get; set; }

        [JsonProperty("losses")]
        public string Losses { get; set; }

        [JsonProperty("rating")]
        public string Raiting { get; set; }

        [JsonProperty("logo_url")]
        public string Logo_Url { get; set; }

        public string Id { get; set; }
        public string Total { get; set; }
        public Task<Bitmap> Logo { get; set; }

        public Team(string name, string wins, string losses, string raiting,  string id, string logo)
        {
            Name = name;
            Wins = wins;
            Losses = losses;
            Raiting = raiting;
            Id = id;
            Logo_Url = logo;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Wins: {Wins}, Losses: {Losses}, Raiting: {Raiting}, Logo_Url: {Logo_Url}, Id: {Id}, Total: {Total}";
        }
    }
}
