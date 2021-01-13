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

        public BungieClient(string apiKey, BungieClientSettings settings)
        {
            _cdnClient = new BungieCDNClient();
            PlatfromClient = new BungiePlatfromClient(apiKey);
            if (settings.UseCache)
            {
                GlobalDefinitionsCacheRepository.ShouldTryDownloadMissingDefinitions = settings.TryDownloadMissingDefinitions;

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
            _cdnClient = new BungieCDNClient();
            PlatfromClient = new BungiePlatfromClient(apiKey);
            if (InternalData.UseCache)
            {
                GlobalDefinitionsCacheRepository.ShouldTryDownloadMissingDefinitions = InternalData.ShouldTryDownloadMissingDefinitions;

                GlobalDefinitionsCacheRepository.Initialize(locales);

                var manifest = PlatfromClient.GetDestinyManifest().GetAwaiter().GetResult();

                if (InternalData.UsePreloadedCache)
                {
                    GlobalDefinitionsCacheRepository.LoadAllDataFromDisk(InternalData.LocalCacheBPath, manifest);
                }
            }
            InternalData.CurrentClient = this;
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
