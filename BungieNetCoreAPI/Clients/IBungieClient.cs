using NetBungieAPI.Authrorization;
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
        string GetAuthorizationLink();
        void ReceiveCode(string state, string code);
        Task<AuthorizationTokenData> GetAuthorizationToken(string code);
        Task<AuthorizationTokenData> RenewAuthorizationToken(AuthorizationTokenData oldToken);
        ValueTask<bool> CheckUpdates();
        Task DownloadLatestManifestLocally();
        void LoadDefinitions();
    }
}
