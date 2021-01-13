using BungieNetCoreAPI.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;

namespace BungieNetCoreAPI.Clients
{
    public class BungieClient
    {
        private BungieCDNClient _cdnClient;
        public BungiePlatfromClient PlatfromClient;
        public LogListener LogListener;

        private DestinyLocales[] _locales;
        public BungieClient(string apiKey, BungieClientSettings settings)
        {
            _cdnClient = new BungieCDNClient();
            PlatfromClient = new BungiePlatfromClient(apiKey);
            if (settings.UseCache)
            {

                GlobalDefinitionsCacheRepository.Initialize(settings.Locales);

                var manifest = PlatfromClient.GetDestinyManifest().GetAwaiter().GetResult();

                if (InternalData.UsePreloadedCache)
                {
                    GlobalDefinitionsCacheRepository.LoadAllDataFromDisk(settings.PathToLocalDb, manifest);
                }
            }
            InternalData.CurrentClient = this;
        }

        public BungieClient(string apiKey, DestinyLocales[] locales)
        {
            InternalData.Initialize();
            if (InternalData.LoggingEnabled)
            {
                LogListener = new LogListener();
                Logger.Register(LogListener);
            }

            HttpClientInstance.Initialize();
            _cdnClient = new BungieCDNClient();
            PlatfromClient = new BungiePlatfromClient(apiKey);
            _locales = locales; 
            InternalData.CurrentClient = this;
        }

        public async Task Start()
        {
            Logger.Log("Starting client...", LogType.Info);
            if (InternalData.UseCache)
            { 
                GlobalDefinitionsCacheRepository.Initialize(_locales);

                var manifest = await PlatfromClient.GetDestinyManifest();

                if (InternalData.UsePreloadedCache)
                {
                    Logger.Log($"Using preloaded cache for set locales: {string.Join(", ", _locales)}", LogType.Info);
                    GlobalDefinitionsCacheRepository.LoadAllDataFromDisk(InternalData.LocalCacheBPath, manifest);
                }
            }
            
        }
        public async Task<string> GetJsonFromCDNAsync(string url)
        {
            return await _cdnClient.DownloadJSONDataAsync(url);
        }
        public async Task<Image> GetImageFromCDNAsync(string url)
        {
            return await _cdnClient.DownloadImageAsync(url);
        }
        public async Task SaveImageFromCDNLocallyAsync(string url, string folderPath, string filename, ImageFormat format)
        {
            await _cdnClient.DownloadImageAndSaveAsync(url, folderPath, filename, format);
        }
    }
}
