using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Clients
{
    public class BungieClient
    {
        public BungieCDNClient CDNClient;
        public BungiePlatfromClient PlatfromClient;

        public BungieClient(string apiKey)
        {
            CDNClient = new BungieCDNClient();
            PlatfromClient = new BungiePlatfromClient(apiKey);
        }
    }
}
