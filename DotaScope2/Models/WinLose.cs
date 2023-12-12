using Avalonia.Media.Imaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaScope2.Models
{
    public class WinLose
    {
        [JsonProperty("win")]
        public string win { get; set; }
        [JsonProperty("lose")]
        public string lose { get; set; }

        public WinLose(string win, string lose)
        {
            this.win = win;
            this.lose = lose;
        }

    }
}
