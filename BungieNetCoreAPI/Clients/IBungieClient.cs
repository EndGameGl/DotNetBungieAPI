using NetBungieAPI.Clients.Settings;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static NetBungieAPI.Logging.LogListener;

namespace NetBungieAPI.Clients
{
    public interface IBungieClient
    {
        void AddListener(NewMessageEvent eventHandler);
        Task Run();
        void Configure(Action<BungieClientSettings> configure);
        IBungieApiAccess ApiAccess { get; }
        ILocalisedDestinyDefinitionRepositories Repository { get; }
    }
}
