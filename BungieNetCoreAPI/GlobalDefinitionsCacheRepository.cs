using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions;

namespace BungieNetCoreAPI
{
    public static class GlobalDefinitionsCacheRepository
    {
        private static DefinitionCacheRepository cache = new DefinitionCacheRepository("en");
        public static void LoadAllDataFromDisk(string localManifestPath, DestinyManifest manifest)
        {
            cache.LoadDataFromDisk(localManifestPath, manifest);
        }
        public static void AddDefinitionToCache(string definitionName, DestinyDefinition defValue)
        {
            cache.Add(definitionName, defValue);
        }
        public static bool TryGetDestinyDefinition(string definitionName, uint key, out DestinyDefinition definition)
        {
            return cache.TryGetDefinition(definitionName, key, out definition);
        }
    }
}
