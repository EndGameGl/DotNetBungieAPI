using NetBungieAPI.Destiny;
using NetBungieAPI.Destiny.Definitions;
using NetBungieAPI.Destiny.Definitions.Activities;
using NetBungieAPI.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI.Repositories
{
    public interface ILocalisedDestinyDefinitionRepositories
    {
        BungieLocales CurrentLocaleLoadContext { get; }
        void SetLocaleContext(BungieLocales locale);
        void ResetLocaleContext();
        void Initialize(BungieLocales[] locales);
        void LoadAllDataFromDisk(string localManifestPath, DestinyManifest manifest);
        void AddDefinitionToCache(DefinitionsEnum definitionType, IDestinyDefinition defValue, BungieLocales locale);
        bool TryGetDestinyDefinition(DefinitionsEnum definitionType, uint key, BungieLocales locale, out IDestinyDefinition definition);
        bool TryGetDestinyDefinition<T>(DefinitionsEnum definitionType, uint key, BungieLocales locale, out T definition) where T : IDestinyDefinition;
        IEnumerable<T> Search<T>(DefinitionsEnum definitionType, BungieLocales locale, Func<IDestinyDefinition, bool> predicate) where T : IDestinyDefinition;
        IEnumerable<T> GetAll<T>(DefinitionsEnum definitionType, BungieLocales locale) where T : IDestinyDefinition;
        public IEnumerable<T> GetAll<T>(BungieLocales locale = BungieLocales.EN) where T : IDestinyDefinition;
        List<DestinyInventoryItemDefinition> GetItemsWithTrait(BungieLocales locale, string trait);
        List<DestinyInventoryItemDefinition> GetSacks(BungieLocales locale);
        List<DestinyActivityDefinition> SearchActivitiesByName(BungieLocales locale, string name);
        string FetchJSONFromDB(BungieLocales locale, DefinitionsEnum definitionType, uint hash);
    }
}
