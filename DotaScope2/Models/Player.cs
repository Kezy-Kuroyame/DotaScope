using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DotaScope2.Models
{
    public class Player
    {
        public string rank {  get; set; }
        public string name { get; set; }
        public Task<Bitmap?> imgAvatar { get; set; }
        public string id { get; set; }
        public string win {  get; set; }
        public string lose { get; set; }   
        public string total {  get; set; }
        public string percent { get; set; }

        public Player(string id, string name, string rank)
        {
            this.id = id;
            this.name = name;
            this.rank = rank;
        }
        public override string ToString()
        {
            return $"Id: {id}, Name: {name}, Rank: {rank}, Win: {win}, Lose: {lose}, Total: {total}, Percent: {percent}";
        }

    }
}
