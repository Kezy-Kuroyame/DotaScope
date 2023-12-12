using Avalonia.Media.Imaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaScope2.Models
{
    public class Match
    {
        [JsonProperty("match_id")]
        public string match_id { get; set; }

        [JsonProperty("radiant_win")]
        public string radiant_win { get; set; }

        [JsonProperty("player_slot")]
        public string player_slot { get; set; }

        [JsonProperty("duration")]
        public string duration { get; set; }

        [JsonProperty("game_mode")]
        public string game_mode { get; set; }

        [JsonProperty("lobby_type")]
        public string lobby_type { get; set; }

        [JsonProperty("hero_id")]
        public string hero_id { get; set; }

        [JsonProperty("start_time")]
        public string start_time { get; set; }

        [JsonProperty("kills")]
        public string kills { get; set; }

        [JsonProperty("deaths")]
        public string deaths { get; set; }

        [JsonProperty("assists")]
        public string assists { get; set; }

        [JsonProperty("party_size")]
        public string party_size { get; set; }

        public string win {  get; set; }
        public string normal_duration { get; set; }
        public string how_long_ago {  get; set; }
        public string string_game_mode {  get; set; }
        public string string_lobby_type { get; set; }
        public Task<Bitmap?> img {  get; set; }

        public Match(string match_id, string player_slot, string radiant_win, string duration, string game_mode, string lobby_type, string hero_id, string start_time, string kills, string deaths, string assists, string party_size)
        {
            this.match_id = match_id;
            this.player_slot = player_slot;
            this.radiant_win = radiant_win;
            this.duration = duration;
            this.game_mode = game_mode;
            this.lobby_type = lobby_type;
            this.hero_id = hero_id;
            this.start_time = start_time;
            this.kills = kills;
            this.deaths = deaths;
            this.assists = assists;
            this.party_size = party_size;
        }

        public override string ToString()
        {
            return $"MatchID: {match_id}, Radiant Win: {radiant_win}, Duration: {duration}, Game mode: {game_mode}, Lobby type: " +
                $"{lobby_type}, HeroID: {hero_id}, Start time: {start_time}, Kills: {kills}, Deaths: {deaths}, Assists:{assists}, " +
                $"Party size: {party_size}";
        }
    }
}
