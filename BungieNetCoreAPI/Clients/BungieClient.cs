using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Clients
{
    public class BungieClient
    {
        private BungieCDNClient CDNClient;
        private BungiePlatfromClient PlatfromClient;

        public BungieClient(string apiKey)
        {
            CDNClient = new BungieCDNClient();
            PlatfromClient = new BungiePlatfromClient(apiKey);
        }
    }
}
