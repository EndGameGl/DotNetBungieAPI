using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.Default.ServiceConfigurations;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services.Default
{
    internal sealed class DefaultDestiny2DefinitionRepository : IDestiny2DefinitionRepository
    {
        private readonly ILogger _logger;
        private readonly ConcurrentDictionary<BungieLocales, DestinyDefinitionsRepository> _localisedRepositories;

        internal DefaultDestiny2DefinitionRepository(
            IDefinitionAssemblyData assemblyData,
            ILogger logger,
            DefaultDestiny2DefinitionRepositoryConfiguration configuration)
        {
            _logger = logger;
            _localisedRepositories =
                new ConcurrentDictionary<BungieLocales, DestinyDefinitionsRepository>(
                    configuration.AppConcurrencyLevel, configuration.UsedLocales.Count);

            foreach (var locale in configuration.UsedLocales)
            {
                _localisedRepositories.TryAdd(
                    locale,
                    new DestinyDefinitionsRepository(
                        locale,
                        assemblyData,
                        logger,
                        configuration));
            }
        }

        public bool TryGetDestinyDefinition<T>(
            uint key,
            BungieLocales locale,
            out T definition)
            where T : IDestinyDefinition
        {
            definition = default;
            return _localisedRepositories.TryGetValue(locale, out var repository) &&
                   repository.TryGetDefinition(DefinitionHashPointer<T>.EnumValue, key, out definition);
        }

        public bool TryGetDestinyHistoricalDefinition(
            BungieLocales locale,
            string key,
            out DestinyHistoricalStatsDefinition statsDefinition)
        {
            statsDefinition = default;
            return _localisedRepositories.TryGetValue(locale, out var repository) &&
                   repository.TryGetHistoricalStatsDefinition(key, out statsDefinition);
        }

        public IEnumerable<DestinyHistoricalStatsDefinition> GetAllHistoricalStatsDefinitions(
            BungieLocales locale)
        {
            return _localisedRepositories.TryGetValue(locale, out var repository)
                ? repository.GetAllHistoricalStats
                : null;
        }

        public bool AddDestinyHistoricalDefinition(BungieLocales locale,
            DestinyHistoricalStatsDefinition statsDefinition)
        {
            return _localisedRepositories.TryGetValue(locale, out var repository) &&
                   repository.AddDestinyHistoricalStatsDefinition(statsDefinition);
        }

        public IEnumerable<T> Search<T>(
            DefinitionsEnum definitionType,
            BungieLocales locale,
            Func<IDestinyDefinition, bool> predicate) where T : IDestinyDefinition
        {
            return _localisedRepositories.TryGetValue(locale, out var repository)
                ? repository.Search<T>(definitionType, predicate)
                : null;
        }

        public IEnumerable<T> GetAll<T>(BungieLocales locale = BungieLocales.EN) where T : IDestinyDefinition
        {
            return _localisedRepositories.TryGetValue(locale, out var repository)
                ? repository.GetAll<T>(DefinitionHashPointer<T>.EnumValue)
                : null;
        }

        public bool AddDefinition<T>(BungieLocales locale, T definition) where T : IDestinyDefinition
        {
            return _localisedRepositories.TryGetValue(locale, out var repository) &&
                   repository.AddDefinition(DefinitionHashPointer<T>.EnumValue, definition);
        }

        public bool AddDefinition(DefinitionsEnum enumValue, BungieLocales locale, IDestinyDefinition definition)
        {
            return _localisedRepositories.TryGetValue(locale, out var repository) &&
                   repository.AddDefinition(enumValue, definition);
        }

        public void Clear()
        {
            foreach (var repository in _localisedRepositories)
            {
                repository.Value.Clear();
            }
        }

        public void PremapPointers()
        {
            foreach (var repository in _localisedRepositories)
            {
                repository.Value.PremapPointers();
            }
        }
    }
}