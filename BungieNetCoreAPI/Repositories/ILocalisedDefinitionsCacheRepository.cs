using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions;
using BungieNetCoreAPI.Destiny.Definitions.Activities;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Repositories
{
    public interface ILocalisedDefinitionsCacheRepository
    {
        string CurrentLocaleLoadContext { get; }
        void SetLocaleContext(string locale);
        void ResetLocaleContext();
        void Initialize(DestinyLocales[] locales);
        void LoadAllDataFromDisk(string localManifestPath, DestinyManifest manifest);
        void AddDefinitionToCache(string definitionName, DestinyDefinition defValue, string locale);
        bool TryGetDestinyDefinition(string definitionName, uint key, string locale, out DestinyDefinition definition);
        IEnumerable<T> Search<T>(string locale, Func<DestinyDefinition, bool> predicate) where T : DestinyDefinition;
        IEnumerable<T> GetAll<T>(string locale);
        List<DestinyInventoryItemDefinition> GetItemsWithTrait(string locale, string trait);
        List<DestinyInventoryItemDefinition> GetSacks(string locale);
        List<DestinyActivityDefinition> SearchActivitiesByName(string locale, string name);
    }
}
