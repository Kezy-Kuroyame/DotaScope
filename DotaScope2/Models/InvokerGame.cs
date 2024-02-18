using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaScope2.Models
{
    public class InvokerGame
    {
        [JsonProperty("id_game")]
        public int Id_game { get; set; }

        [JsonProperty("id_user")]
        public int Id_user { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }


        public InvokerGame(int id_game, int id_user, int score)
        {
            Id_game = id_game;
            Id_user = id_user;
            Score = score;
        }
    }
}
