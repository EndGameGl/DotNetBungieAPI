using System;
using NetBungieAPI.Clients.Settings;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IConfigurationService
    {
        BungieClientSettings Settings { get; }
        void Configure(Action<BungieClientSettings> configure);
    }
}