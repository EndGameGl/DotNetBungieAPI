using System;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.Interfaces;
using static NetBungieAPI.Logging.LogListener;

namespace NetBungieAPI.Clients
{
    /// <summary>
    ///     Interface for bungie.net API client
    /// </summary>
    public interface IBungieClient
    {
        /// <summary>
        ///     Access to all API methods
        /// </summary>
        IBungieApiAccess ApiAccess { get; }

        /// <summary>
        ///     Access to in-memory definition repository
        /// </summary>
        ILocalisedDestinyDefinitionRepositories Repository { get; }

        /// <summary>
        ///     Access to OAuth2 methods
        /// </summary>
        IAuthorizationStateHandler Authentication { get; }

        /// <summary>
        ///     Adds log listener
        /// </summary>
        /// <param name="eventHandler">Log event handler</param>
        void AddListener(NewMessageEvent eventHandler);

        /// <summary>
        ///     Checks whether manifest should be updated
        /// </summary>
        /// <returns></returns>
        ValueTask<bool> CheckUpdates();

        /// <summary>
        ///     Downloads latest manifest data
        /// </summary>
        /// <returns></returns>
        Task DownloadLatestManifestLocally();

        /// <summary>
        ///     Creates a scoped user client, that doesn't need user to pass token manually
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        IUserContextBungieClient ScopeToUser(AuthorizationTokenData token);

        /// <summary>
        ///     Signals that definitions finished loading.
        /// </summary>
        event Action DefinitionsLoaded;

        /// <summary>
        /// Tries to get definition async from all available sources
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="locale"></param>
        /// <param name="success"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ValueTask<bool> TryGetDefinitionAsync<T>(uint hash, BungieLocales locale, Action<T> success)
            where T : IDestinyDefinition;
    }
}