using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdtdServerManager
{
    public class Configuration
    {
        public Configuration() {
            ServerItems = new List<ServerItem>();
        }
        public  List<ServerItem> ServerItems { get; set; }
        public string DiscordChannel { get; set; }
        public string DiscordApi { get; set; }
        public string TwitchApi { get; set; }
        public string TelnetIp { get; set; }
        public decimal RestartEveryHours { get; set; }
    }
}
