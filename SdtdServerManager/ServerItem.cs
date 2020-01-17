using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdtdServerManager
{
    public class ServerItem
    {
        public string ServerNamePath { get; set; }
        public DateTime LastRestart { get; set; }
        public DateTime NextRestart { get; set; }
        public bool IsItRunning { get; set; }
        public TelnetConnection TelnetConnection { get;set;}

    }
}
