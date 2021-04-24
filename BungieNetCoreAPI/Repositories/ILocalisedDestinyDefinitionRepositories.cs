using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System;
using System.Collections.Generic;
using System.Text;
using NetBungieAPI.Models.Destiny.Config;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using NetBungieAPI.Providers;

namespace NetBungieAPI.Repositories
{
    public interface ILocalisedDestinyDefinitionRepositories
    {
        DefinitionProvider Provider { get; set; }
        BungieLocales CurrentLocaleLoadContext { get; }
        void SetLocaleContext(BungieLocales locale);
        void ResetLocaleContext();
        void Initialize(BungieLocales[] locales);
        void LoadAllDataFromDisk(string localManifestPath, DestinyManifest manifest);
        void AddDefinitionToCache(DefinitionsEnum definitionType, IDestinyDefinition defValue, BungieLocales locale);
        bool TryGetDestinyDefinition(DefinitionsEnum definitionType, uint key, BungieLocales locale, out IDestinyDefinition definition);
        bool TryGetDestinyDefinition<T>(DefinitionsEnum definitionType, uint key, BungieLocales locale, out T definition) where T : IDestinyDefinition;
        bool TryGetDestinyHistoricalDefinition(BungieLocales locale, string key,
            out DestinyHistoricalStatsDefinition statsDefinition);

        bool AddDestinyHistoricalDefinition(BungieLocales locale, DestinyHistoricalStatsDefinition statsDefinition);
        IEnumerable<T> Search<T>(DefinitionsEnum definitionType, BungieLocales locale, Func<IDestinyDefinition, bool> predicate) where T : IDestinyDefinition;
        IEnumerable<T> GetAll<T>(DefinitionsEnum definitionType, BungieLocales locale) where T : IDestinyDefinition;
        public IEnumerable<T> GetAll<T>(BungieLocales locale = BungieLocales.EN) where T : IDestinyDefinition;
        List<DestinyInventoryItemDefinition> GetItemsWithTrait(BungieLocales locale, string trait);
        List<DestinyInventoryItemDefinition> GetSacks(BungieLocales locale);
        List<DestinyActivityDefinition> SearchActivitiesByName(BungieLocales locale, string name);
        string FetchJSONFromDB(BungieLocales locale, DefinitionsEnum definitionType, uint hash);

        bool AddDefinition(DefinitionsEnum definitionType, BungieLocales locale,
            IDestinyDefinition definition);
    }
}
