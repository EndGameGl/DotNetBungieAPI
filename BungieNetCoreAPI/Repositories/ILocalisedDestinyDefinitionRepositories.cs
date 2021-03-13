﻿using NetBungieApi.Destiny;
using NetBungieApi.Destiny.Definitions;
using NetBungieApi.Destiny.Definitions.Activities;
using NetBungieApi.Destiny.Definitions.InventoryItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieApi.Repositories
{
    public interface ILocalisedDestinyDefinitionRepositories
    {
        DestinyLocales CurrentLocaleLoadContext { get; }
        void SetLocaleContext(DestinyLocales locale);
        void ResetLocaleContext();
        void Initialize(DestinyLocales[] locales);
        void LoadAllDataFromDisk(string localManifestPath, DestinyManifest manifest);
        void AddDefinitionToCache(DefinitionsEnum definitionType, IDestinyDefinition defValue, DestinyLocales locale);
        bool TryGetDestinyDefinition(DefinitionsEnum definitionType, uint key, DestinyLocales locale, out IDestinyDefinition definition);
        bool TryGetDestinyDefinition<T>(DefinitionsEnum definitionType, uint key, DestinyLocales locale, out T definition) where T : IDestinyDefinition;
        IEnumerable<T> Search<T>(DefinitionsEnum definitionType, DestinyLocales locale, Func<IDestinyDefinition, bool> predicate) where T : IDestinyDefinition;
        IEnumerable<T> GetAll<T>(DefinitionsEnum definitionType, DestinyLocales locale) where T : IDestinyDefinition;
        public IEnumerable<T> GetAll<T>(DestinyLocales locale = DestinyLocales.EN) where T : IDestinyDefinition;
        List<DestinyInventoryItemDefinition> GetItemsWithTrait(DestinyLocales locale, string trait);
        List<DestinyInventoryItemDefinition> GetSacks(DestinyLocales locale);
        List<DestinyActivityDefinition> SearchActivitiesByName(DestinyLocales locale, string name);
        string FetchJSONFromDB(DestinyLocales locale, DefinitionsEnum definitionType, uint hash);
    }
}
