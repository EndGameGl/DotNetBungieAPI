namespace BungieNetCoreAPI.Clients
{
    public class BungieClientSettings
    {
        public bool CacheDefinitionsInMemory { get; set; }
        public bool TryDownloadMissingDefinitions { get; set; }
        public DestinyLocales[] Locales { get; set; }
        public string PathToLocalDb { get; set; }
        public bool EnableLogging { get; set; }
        public bool UsePreloadedCache { get; set; }


        public bool UseExistingConfig { get; set; }
        public string ExistingConfigPath { get; set; }
    }
}
