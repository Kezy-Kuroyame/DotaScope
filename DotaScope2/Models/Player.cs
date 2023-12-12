using Avalonia.Media.Imaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaScope2.Models
{
    public class Player
    {
        [JsonProperty("personaname")]
        public string name { get; set; }
        [JsonProperty("avatarmedium")]
        public string avatar { get; set; }
        [JsonProperty("rank_tier")]
        public string rank { get; set; }

        public Task<Bitmap?> imgAvatar { get; set; }
        public string id { get; set; }
        public string win {  get; set; }
        public string lose { get; set; }   
        public string total {  get; set; }
        public string percent { get; set; }

        public Player(string id, string name, string avatar, string rank)
        {
            this.id = id;
            this.name = name;
            this.avatar = avatar;
            this.rank = rank;
        }

    }
}
