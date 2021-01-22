using BungieNetCoreAPI.Repositories;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Clients
{
    public class BungieClientSettings
    {
        public bool CacheDefinitionsInMemory { get; set; }
        public bool TryDownloadMissingDefinitions { get; set; }
        public DestinyLocales[] Locales { get; set; }     
        public bool EnableLogging { get; set; }
        public bool UsePreloadedCache { get; set; }


        public bool UseExistingConfig { get; set; }
        public string ExistingConfigPath { get; set; }


        public bool KeepOldVerisons { get; set; }
        public bool CheckUpdates { get; set; }
        public string VersionsRepositoryPath { get; set; }

        public Dictionary<string, bool> DefinitionLoadRules { get; set; }
        public LoadSourceMode LoadMode { get; set; }
    }
}
