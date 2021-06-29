using System;
using NetBungieAPI.Clients.Settings;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public BungieClientSettings Settings { get; } = new();

        public void Configure(Action<BungieClientSettings> configure)
        {
            configure(Settings);
        }
    }
}