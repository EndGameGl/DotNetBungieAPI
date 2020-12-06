using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Clients
{
    public class BungieClientSettings
    {
        public bool UseGlobalCache { get; set; }
        public string[] Locales { get; set; }
        public string PathToLocalDb { get; set; }
    }
}
