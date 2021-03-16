using NetBungieAPI.Clients;
using NetBungieAPI.Clients.Settings;
using System;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IConfigurationService
    {
        BungieClientSettings Settings { get; }
        void Configure(Action<BungieClientSettings> configure);
    }
}
