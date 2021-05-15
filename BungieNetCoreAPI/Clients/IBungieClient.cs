using NetBungieAPI.Authorization;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.Interfaces;
using System.Threading.Tasks;
using static NetBungieAPI.Logging.LogListener;

namespace NetBungieAPI.Clients
{
    public interface IBungieClient
    {
        void AddListener(NewMessageEvent eventHandler);
        IBungieApiAccess ApiAccess { get; }
        ILocalisedDestinyDefinitionRepositories Repository { get; }
        public IAuthorizationStateHandler Authentification { get; }
        ValueTask<bool> CheckUpdates();
        Task DownloadLatestManifestLocally();
    }
}
