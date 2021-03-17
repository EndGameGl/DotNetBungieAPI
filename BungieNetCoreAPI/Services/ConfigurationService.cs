using NetBungieAPI.Clients.Settings;
using System;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public BungieClientSettings Settings { get; private set; } = new BungieClientSettings();
        public ConfigurationService()
        {

        }

        public void Configure(Action<BungieClientSettings> configure)
        {
            configure(Settings);
            var httpClient = StaticUnityContainer.GetHTTPClient();
            httpClient.AddAcceptHeader("application/json");
            httpClient.AddHeader("X-API-Key", Settings.ApiKey);
        }
    }
}
