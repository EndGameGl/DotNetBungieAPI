﻿using NetBungieAPI.Logging;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.Interfaces;
using System.Threading.Tasks;
using static NetBungieAPI.Logging.LogListener;

namespace NetBungieAPI.Clients
{
    /// <summary>
    /// <see cref="IBungieClient"/> implementation
    /// </summary>
    public class BungieClient : IBungieClient
    {
        private readonly IConfigurationService _configuration;
        private readonly IHttpClientInstance _httpClient;
        private readonly ILogger _logger;
        private readonly LogListener _logListener;

        /// <summary>
        /// <inheritdoc cref="IBungieClient.Authentification"/>
        /// </summary>
        public IAuthorizationStateHandler Authentification { get; }

        /// <summary>
        /// <inheritdoc cref="IBungieClient.Repository"/>
        /// </summary>
        public ILocalisedDestinyDefinitionRepositories Repository { get; }

        /// <summary>
        /// <inheritdoc cref="IBungieClient.ApiAccess"/>
        /// </summary>
        public IBungieApiAccess ApiAccess { get; }

        internal BungieClient(IConfigurationService config, ILogger logger, IBungieApiAccess apiAccess,
            IHttpClientInstance httpClient, IAuthorizationStateHandler authorizationHandler,
            ILocalisedDestinyDefinitionRepositories repository)
        {
            _configuration = config;
            _httpClient = httpClient;
            _logger = logger;
            Authentification = authorizationHandler;
            Repository = repository;
            ApiAccess = apiAccess;
            _logListener = new LogListener();
            _logger.Register(_logListener);
        }

        /// <summary>
        /// <inheritdoc cref="IBungieClient.CheckUpdates"/>
        /// </summary>
        /// <returns></returns>
        public async ValueTask<bool> CheckUpdates()
        {
            return await Repository.Provider.CheckForUpdates();
        }
        
        /// <summary>
        /// <inheritdoc cref="IBungieClient.DownloadLatestManifestLocally"/>
        /// </summary>
        public async Task DownloadLatestManifestLocally()
        {
            await Repository.Provider.DownloadNewManifestData(await Repository.Provider.GetCurrentManifest());
        }

        /// <summary>
        /// <inheritdoc cref="IBungieClient.AddListener"/>
        /// </summary>
        /// <param name="eventHandler"></param>
        public void AddListener(NewMessageEvent eventHandler)
        {
            if (_logListener is not null)
                _logListener.OnNewMessage += eventHandler;
        }
    }
}