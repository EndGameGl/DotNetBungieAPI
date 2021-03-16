using NetBungieAPI.Clients;
using NetBungieAPI.Clients.Settings;
using NetBungieAPI.Services;
using System;

namespace NetBungieAPI
{
    public class BungieApiBuilder
    {
        public static IBungieClient GetApiClient(Action<BungieClientSettings> configure)
        {
            var client = StaticUnityContainer.GetService<IBungieClient>();
            client.Configure(configure);
            return client;
        }
    }
}
