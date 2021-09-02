using System;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Logging;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.Interfaces;
using static NetBungieAPI.Logging.LogListener;

namespace NetBungieAPI.Clients
{
    /// <summary>
    ///     <see cref="IBungieClient" /> implementation
    /// </summary>
    public class BungieClient : IBungieClient
    {
        private readonly IConfigurationService _configuration;
        private readonly IHttpClientInstance _httpClient;
        private readonly ILogger _logger;
        private readonly LogListener _logListener;

        internal BungieClient(
            IConfigurationService config,
            ILogger logger,
            IBungieApiAccess apiAccess,
            IHttpClientInstance httpClient,
            IAuthorizationStateHandler authorizationHandler,
            ILocalisedDestinyDefinitionRepositories repository)
        {
            _configuration = config;
            _httpClient = httpClient;
            _logger = logger;
            Authentication = authorizationHandler;
            Repository = repository;
            ApiAccess = apiAccess;
            _logListener = new LogListener();
            _logger.Register(_logListener);
        }

        /// <summary>
        ///     <inheritdoc cref="IBungieClient.Authentication" />
        /// </summary>
        public IAuthorizationStateHandler Authentication { get; }

        /// <summary>
        ///     <inheritdoc cref="IBungieClient.Repository" />
        /// </summary>
        public ILocalisedDestinyDefinitionRepositories Repository { get; }

        /// <summary>
        ///     <inheritdoc cref="IBungieClient.ApiAccess" />
        /// </summary>
        public IBungieApiAccess ApiAccess { get; }

        /// <summary>
        ///     <inheritdoc cref="IBungieClient.CheckUpdates" />
        /// </summary>
        /// <returns></returns>
        public async ValueTask<bool> CheckUpdates()
        {
            return await Repository.Provider.CheckForUpdates();
        }

        /// <summary>
        ///     <inheritdoc cref="IBungieClient.DownloadLatestManifestLocally" />
        /// </summary>
        public async Task DownloadLatestManifestLocally()
        {
            await Repository.Provider.DownloadNewManifestData(await Repository.Provider.GetCurrentManifest());
        }

        /// <summary>
        /// <inheritdoc cref="IBungieClient.ScopeToUser" />
        /// </summary>
        /// <param name="token">Auth token</param>
        /// <returns></returns>
        public IUserContextBungieClient ScopeToUser(AuthorizationTokenData token)
        {
            return new UserContextBungieClient(Repository, token, Authentication, ApiAccess);
        }

        /// <summary>
        /// <inheritdoc cref="IBungieClient.DefinitionsLoaded" />
        /// </summary>
        public event Action DefinitionsLoaded;

        /// <summary>
        ///     <inheritdoc cref="IBungieClient.AddListener" />
        /// </summary>
        /// <param name="eventHandler"></param>
        public void AddListener(NewMessageEvent eventHandler)
        {
            if (_logListener is not null)
                _logListener.OnNewMessage += eventHandler;
        }

        internal void SignalDefinitionsLoadedInternal()
        {
            DefinitionsLoaded?.Invoke();
        }

        /// <summary>
        /// <inheritdoc cref="IBungieClient.TryGetDefinitionAsync{T}"/>
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="locale"></param>
        /// <param name="success"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async ValueTask<bool> TryGetDefinitionAsync<T>(uint hash, BungieLocales locale, Action<T> success)
            where T : IDestinyDefinition
        {
            if (Repository.TryGetDestinyDefinition<T>(hash, locale, out var definition))
            {
                success(definition);
                return true;
            }

            definition = await Repository.Provider.LoadDefinition<T>(hash, locale);
            if (definition is null)
                return false;
            Repository.AddDefinition(DefinitionHashPointer<T>.EnumValue, locale, definition);
            success(definition);
            return true;
        }
    }
}