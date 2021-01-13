using BungieNetCoreAPI.Clients;
using BungieNetCoreAPI.Destiny;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI
{
    internal static class InternalData
    {
        internal static BungieClient CurrentClient;

        internal static bool ShouldTryDownloadMissingDefinitions;
        internal static bool UseCache;
        internal static bool UsePreloadedCache;
        internal static string LocalCacheBPath;

        internal static DestinyManifest LoadedManifest;
        internal static DestinyLocales[] CurrentLoadedLocales;

        static InternalData()
        {
            var configuration =
                new ConfigurationBuilder()
                .AddJsonFile("configs.json")
                .Build();
            ShouldTryDownloadMissingDefinitions = Convert.ToBoolean(configuration.GetSection("ShouldTryDownloadMissingDefinitions").Value);
            UseCache = Convert.ToBoolean(configuration.GetSection("UseCache").Value);
            UsePreloadedCache = Convert.ToBoolean(configuration.GetSection("UsePreloadedCache").Value);
            LocalCacheBPath = configuration.GetSection("LocalCacheBPath").Value;
        }
    }
}
