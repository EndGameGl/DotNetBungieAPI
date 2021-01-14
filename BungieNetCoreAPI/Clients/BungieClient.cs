using BungieNetCoreAPI.Logging;
using BungieNetCoreAPI.Repositories;
using BungieNetCoreAPI.Services;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using Unity;

namespace BungieNetCoreAPI.Clients
{
    public class BungieClient
    {
        internal static Uri BungieCDNUri = new Uri("https://www.bungie.net");
        internal static Uri BungiePlatformUri = new Uri("https://www.bungie.net/Platform/");
        internal static IConfigurationService Configuration;

        private readonly ILogger _logger;
        public static BungieCDNClient CDN;
        public static BungiePlatfromClient Platform;


        public ILocalisedDefinitionsCacheRepository Repository;
        public LogListener LogListener;

        public BungieClient(string apiKey, BungieClientSettings settings)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new Exception("API key is empty.");

            SetUpUnityDependencies();

            Configuration = UnityContainerFactory.Container.Resolve<IConfigurationService>();
            Configuration.ApplySettings(settings);
            _logger = UnityContainerFactory.Container.Resolve<ILogger>();

            if (Configuration.Settings.EnableLogging)
            {
                LogListener = new LogListener();
                _logger.Register(LogListener);
            }

            CDN = new BungieCDNClient();
            Platform = new BungiePlatfromClient(apiKey);     
        }
        public async Task Run()
        {
            _logger.Log("Starting client...", LogType.Info);
            if (Configuration.Settings.CacheDefinitionsInMemory)
            {
                Repository = UnityContainerFactory.Container.Resolve<ILocalisedDefinitionsCacheRepository>();
                Repository.Initialize(Configuration.Settings.Locales);

                var manifest = Platform.GetDestinyManifest().GetAwaiter().GetResult();

                if (Configuration.Settings.UsePreloadedCache)
                {
                    _logger.Log($"Using preloaded cache for set locales: {string.Join(", ", Configuration.Settings.Locales)}", LogType.Info);
                    Repository.LoadAllDataFromDisk(Configuration.Settings.PathToLocalDb, manifest);
                }
            }
        }
        public async Task<string> GetJsonFromCDNAsync(string url)
        {
            return await CDN.DownloadJSONDataAsync(url);
        }
        public async Task<Image> GetImageFromCDNAsync(string url)
        {
            return await CDN.DownloadImageAsync(url);
        }
        public async Task SaveImageFromCDNLocallyAsync(string url, string folderPath, string filename, ImageFormat format)
        {
            await CDN.DownloadImageAndSaveAsync(url, folderPath, filename, format);
        }
        private void SetUpUnityDependencies()
        {
            UnityContainerFactory.Container.RegisterType<ILogger, Logger>(TypeLifetime.Singleton);
            UnityContainerFactory.Container.RegisterType<IConfigurationService, ConfigurationService>(TypeLifetime.Singleton);
            UnityContainerFactory.Container.RegisterType<IHttpClientInstance, HttpClientInstance>(TypeLifetime.Singleton);
            UnityContainerFactory.Container.RegisterType<ILocalisedDefinitionsCacheRepository, LocalisedDefinitionsCacheRepository>(TypeLifetime.Singleton);
        }
    }
}
