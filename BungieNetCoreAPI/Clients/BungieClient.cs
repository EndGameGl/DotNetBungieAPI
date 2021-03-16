using NetBungieAPI.Clients.Settings;
using NetBungieAPI.Logging;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess;
using System;
using System.Threading.Tasks;
using Unity;
using static NetBungieAPI.Logging.LogListener;

namespace NetBungieAPI.Clients
{
    public class BungieClient : IBungieClient
    {
        internal static IConfigurationService Configuration;

        private readonly IManifestUpdateHandler _versionControl;
        private readonly ILogger _logger;
        public static BungiePlatfromClient Platform;
        private LogListener _logListener;

        internal BungieClient(IConfigurationService config, IManifestUpdateHandler manifestUpdateHandler, ILogger logger,
            IBungieApiAccess apiAccess)
        {
            Configuration = config;
            _logger = logger;
            _versionControl = manifestUpdateHandler;
            ApiAccess = apiAccess;
        }

        public ILocalisedDestinyDefinitionRepositories Repository { get; private set; }

        public IBungieApiAccess ApiAccess { get; }

        public void Configure(Action<BungieClientSettings> configure)
        {
            BungieClientSettings settings = new BungieClientSettings();
            configure(settings);

            Configuration = StaticUnityContainer.GetConfiguration();

            if (settings.UseExistingConfig)
                Configuration.ApplySettingsFromConfig(settings.ExistingConfigPath);
            else
                Configuration.ApplySettings(settings);

            if (Configuration.Settings.IsLoggingEnabled)
            {
                _logListener = new LogListener();
                _logger.Register(_logListener);
            }
            Platform = new BungiePlatfromClient(Configuration.Settings.ApiKey, Configuration);
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
    }
}
