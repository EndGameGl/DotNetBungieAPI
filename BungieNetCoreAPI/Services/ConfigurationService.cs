using BungieNetCoreAPI.Clients;
using BungieNetCoreAPI.Clients.Settings;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            Settings = JsonConvert.DeserializeObject<BungieClientSettings>(File.ReadAllText(filePath));
        }
    }
}
