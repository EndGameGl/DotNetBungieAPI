using NetBungieAPI.Authrorization;
using NetBungieAPI.Clients.Settings;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess;
using NetBungieAPI.Services.Interfaces;
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
        void Configure();
        IBungieApiAccess ApiAccess { get; }
        ILocalisedDestinyDefinitionRepositories Repository { get; }
        string GetAuthorizationLink();
        void ReceiveCode(string state, string code);
        Task<AuthorizationTokenData> GetAuthorizationToken(string code);
        Task<AuthorizationTokenData> RenewAuthorizationToken(AuthorizationTokenData oldToken);
    }
}
