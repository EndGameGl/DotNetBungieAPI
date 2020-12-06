using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Clients
{
    public class BungieClient
    {
        public BungieCDNClient CDNClient;
        public BungiePlatfromClient PlatfromClient;

        public BungieClient(string apiKey, BungieClientSettings settings)
        {
            CDNClient = new BungieCDNClient();
            PlatfromClient = new BungiePlatfromClient(apiKey);
            if (settings.UseGlobalCache)
            {
                GlobalDefinitionsCacheRepository.Initialize(settings.Locales);
                var manifest = PlatfromClient.GetDestinyManifest().GetAwaiter().GetResult();
                GlobalDefinitionsCacheRepository.LoadAllDataFromDisk(settings.PathToLocalDb, manifest);
            }
        }
    }
}
