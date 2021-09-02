using System;
using NetBungieAPI.Clients.Settings;
using NetBungieAPI.Models.Applications;
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

        public bool HasSufficientRights(ApplicationScopes applicationScopes)
        {
            return Settings.IdentificationSettings.ApplicationScopes.HasFlag(applicationScopes);
        }
    }
}