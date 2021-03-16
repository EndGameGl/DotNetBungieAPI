using NetBungieAPI.Clients;
using NetBungieAPI.Clients.Settings;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public BungieClientSettings Settings { get; private set; } = new BungieClientSettings();
        public ConfigurationService()
        {

        }

        public void Configure(Action<BungieClientSettings> configure)
        {
            configure(Settings);
        }
    }
}
