using System;
using NetBungieAPI.Clients.Settings;
using NetBungieAPI.Models.Applications;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IConfigurationService
    {
        BungieClientSettings Settings { get; }
        void Configure(Action<BungieClientSettings> configure);

        bool HasSufficientRights(ApplicationScopes applicationScopes);
    }
}