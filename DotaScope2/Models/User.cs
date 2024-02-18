using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaScope2.Models
{
    public class User
    {
        [JsonProperty("id_user")]
        public int Id_user { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }


        public User(int id_user, string name, string password)
        {
            Id_user = id_user;
            Name = name;
            Password = password;
        }
    }
}

