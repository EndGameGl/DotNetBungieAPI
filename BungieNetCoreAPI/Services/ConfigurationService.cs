using BungieNetCoreAPI.Clients;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public BungieClientSettings Settings { get; private set; }
        public ConfigurationService()
        {

        }

        public void ApplySettings(BungieClientSettings settings)
        {
            Settings = settings;
        }

        public void ApplySettingsFromConfig(string filePath)
        {
            var configuration =
                new ConfigurationBuilder()
                .AddJsonFile(filePath)
                .Build();

            Settings = new BungieClientSettings();
            Settings.CacheDefinitionsInMemory = Convert.ToBoolean(configuration.GetSection("CacheDefinitionsInMemory").Value);
            Settings.TryDownloadMissingDefinitions = Convert.ToBoolean(configuration.GetSection("TryDownloadMissingDefinitions").Value);
            Settings.VersionsRepositoryPath = configuration.GetSection("PathToLocalDb").Value;
            Settings.EnableLogging = Convert.ToBoolean(configuration.GetSection("EnableLogging").Value);
            Settings.UsePreloadedCache = Convert.ToBoolean(configuration.GetSection("UsePreloadedCache").Value);
        }
    }
}
