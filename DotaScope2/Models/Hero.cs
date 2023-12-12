using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotaScope2.Models
{
    public class Hero
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("img")]
        public string img { get; set; }
        public Hero(string id, string img) 
        {
            this.id = id;
            this.img = img;
        }

    }
}
