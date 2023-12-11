using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DotaScope2.Models
{
    public class Test
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("wins")]
        public string Wins { get; set; }

        [JsonProperty("losses")]
        public string Losses { get; set; }

        [JsonProperty("rating")]
        public string Raiting { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Wins: {Wins}, Losses: {Losses}, Raiting: {Raiting}";
        }
    }
}
