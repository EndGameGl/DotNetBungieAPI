using System;
using System.Collections.Generic;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IDestiny2DefinitionRepository
    {
        bool TryGetDestinyDefinition<T>(
            uint key, 
            BungieLocales locale, 
            out T definition) where T : IDestinyDefinition;

        bool TryGetDestinyHistoricalDefinition(
            BungieLocales locale, 
            string key,
            out DestinyHistoricalStatsDefinition statsDefinition);

        IEnumerable<DestinyHistoricalStatsDefinition> GetAllHistoricalStatsDefinitions(
            BungieLocales locale);
        bool AddDestinyHistoricalDefinition(
            BungieLocales locale, 
            DestinyHistoricalStatsDefinition statsDefinition);

        IEnumerable<T> Search<T>(
            DefinitionsEnum definitionType, 
            BungieLocales locale,
            Func<IDestinyDefinition, bool> predicate) where T : IDestinyDefinition;
        
        public IEnumerable<T> GetAll<T>(
            BungieLocales locale = BungieLocales.EN) where T : IDestinyDefinition;
        
        bool AddDefinition<T>(
            BungieLocales locale, 
            T definition) where T : IDestinyDefinition;
        
        bool AddDefinition(
            DefinitionsEnum enumValue,
            BungieLocales locale, 
            IDestinyDefinition definition);

        IEnumerable<BungieLocales> AvailableLocales { get; }
        IEnumerable<DefinitionsEnum> AllowedDefinitions { get; }

        void Clear();

        void PremapPointers();
    }
}