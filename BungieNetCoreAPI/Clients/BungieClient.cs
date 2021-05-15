using NetBungieAPI.Authorization;
using NetBungieAPI.Logging;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Text;
using System.Threading.Tasks;
using static NetBungieAPI.Logging.LogListener;

namespace NetBungieAPI.Clients
{
    public class BungieClient : IBungieClient
    {
        private readonly IConfigurationService _configuration;
        private readonly IHttpClientInstance _httpClient;
        private readonly ILogger _logger;
        private LogListener _logListener;

        public IAuthorizationStateHandler Authentification { get; }
        public ILocalisedDestinyDefinitionRepositories Repository { get; }
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

        public async ValueTask<bool> CheckUpdates()
        {
            return await Repository.Provider.CheckForUpdates();
        }

        public async Task DownloadLatestManifestLocally()
        {
            await Repository.Provider.DownloadNewManifestData(await Repository.Provider.GetCurrentManifest());
        }

        public void AddListener(NewMessageEvent eventHandler)
        {
            if (_logListener != null)
                _logListener.OnNewMessage += eventHandler;
        }
    }
}