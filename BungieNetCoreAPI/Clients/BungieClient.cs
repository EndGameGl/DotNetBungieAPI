using NetBungieAPI.Authrorization;
using NetBungieAPI.Clients.Settings;
using NetBungieAPI.Logging;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Text;
using System.Threading.Tasks;
using Unity;
using static NetBungieAPI.Logging.LogListener;

namespace NetBungieAPI.Clients
{
    public class BungieClient : IBungieClient
    {
        internal static IConfigurationService Configuration;

        private readonly IAuthorizationStateHandler _authHandler;
        private readonly IHttpClientInstance _httpClient;
        private readonly IManifestVersionHandler _versionControl;
        private readonly ILogger _logger;
        private readonly string _apiKey;

        private LogListener _logListener;

        public ILocalisedDestinyDefinitionRepositories Repository { get; private set; }
        public IBungieApiAccess ApiAccess { get; }

        internal BungieClient(IConfigurationService config, IManifestVersionHandler manifestUpdateHandler, ILogger logger, IBungieApiAccess apiAccess,
            IHttpClientInstance httpClient, IAuthorizationStateHandler authorizationHandler)
        {
            Configuration = config;
            _httpClient = httpClient;
            _logger = logger;
            _versionControl = manifestUpdateHandler;
            _authHandler = authorizationHandler;
            ApiAccess = apiAccess; 
            _logListener = new LogListener();
            _logger.Register(_logListener);
        }
      
        public void Configure()
        {
            _httpClient.AddAcceptHeader("application/json");
            _httpClient.AddHeader("X-API-Key", _apiKey);
        }
        public async Task Run()
        {
            _logger.Log("Starting client...", LogType.Info);

            await _versionControl.InitiateManifestHandler();

            if (Configuration.Settings.CheckUpdates)
                await _versionControl.UpdateManifestData();

            if (Configuration.Settings.CacheDefinitionsInMemory)
            {
                Repository = StaticUnityContainer.GetDestinyDefinitionRepositories();
                Repository.Initialize(Configuration.Settings.Locales);

                if (Configuration.Settings.IsUsingPreloadedData)
                {
                    _logger.Log($"Using preloaded cache for set locales: {string.Join(", ", Configuration.Settings.Locales)}", LogType.Info);
                    await _versionControl.LoadData();
                }
            }
        }
        public void AddListener(NewMessageEvent eventHandler)
        {
            if (_logListener != null)
                _logListener.OnNewMessage += eventHandler; ;
        }
        private bool TryGetAuthorizationValue(out string value)
        {
            value = default;
            if (Configuration.Settings.ClientID.HasValue && !string.IsNullOrEmpty(Configuration.Settings.ClientSecret))
            {
                value = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Configuration.Settings.ClientID}:{Configuration.Settings.ClientSecret}"));
                return true;
            }
            return false;
        }
        public string GetAuthorizationLink()
        {
            var awaiter = _authHandler.CreateNewAuthAwaiter();
            return _httpClient.GetAuthLink(Configuration.Settings.ClientID.Value, awaiter.State);
        }
        public void ReceiveCode(string state, string code)
        {
            _authHandler.InputCode(state, code);
        }
        public async Task<AuthorizationTokenData> GetAuthorizationToken(string code)
        {
            if (TryGetAuthorizationValue(out var value))
            {
                var token = await _httpClient.GetAuthorizationToken(code, value);
                _authHandler.AddAuthToken(token);
                return token;
            }
            else
                throw new Exception("Couldn't form authorization value.");
        }
        public async Task<AuthorizationTokenData> RenewAuthorizationToken(AuthorizationTokenData oldToken)
        {
            return await _httpClient.RenewAuthorizationToken(oldToken);
        }
    }
}
