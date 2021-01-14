using BungieNetCoreAPI.Clients;
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
    }
}
