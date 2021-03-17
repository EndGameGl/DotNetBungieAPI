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
            var settings = StaticUnityContainer.GetConfiguration();
            settings.Configure(configure);
            var client = StaticUnityContainer.GetService<IBungieClient>();
            return client;
        }
    }
}
