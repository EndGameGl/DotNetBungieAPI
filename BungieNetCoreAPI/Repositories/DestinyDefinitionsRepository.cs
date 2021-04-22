using NetBungieAPI.Attributes;
using NetBungieAPI.Logging;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using NetBungieAPI.Pipes;
using NetBungieAPI.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Models.Destiny.Config;

namespace NetBungieAPI.Repositories
{
    /// <summary>
    /// Repository class for storing and accessing all classes with <see cref="Attributes.DestinyDefinitionAttribute"/> attribute
    /// </summary>
    public class DestinyDefinitionsRepository
    {
        private readonly JsonSerializer jsonSerializer = new JsonSerializer();

        private readonly string SELECT_QUERY = "SELECT * FROM {0}";

        private readonly ILogger _logger;
        private readonly IDefinitionAssemblyData _assemblyData;
        private readonly IConfigurationService _config;

        private ConcurrentDictionary<DefinitionsEnum, DestinyDefinitionTypeRepository> _definitionRepositories;
        private ConcurrentDictionary<string, DestinyHistoricalStatsDefinition> _historicalStatsDefinitions;
        /// <summary>
        /// Locale of this repository
        /// </summary>
        public BungieLocales Locale { get; init; }
        /// <summary>
        /// Class .ctor
        /// </summary>
        /// <param name="locale">Locale for this repository</param>
        internal DestinyDefinitionsRepository(BungieLocales locale, IDefinitionAssemblyData assemblyData, IConfigurationService configuration, 
            ILogger logger)
        {
            _assemblyData = assemblyData;
            _config = configuration;
            _logger = logger;
            Locale = locale;

            int definitionsLoaded = _config.Settings.DefinitionLoadingSettings.AllowedDefinitions.Length;
            int concurrencyLevel = _config.Settings.DefinitionLoadingSettings.AppConcurrencyLevel;

            _logger.Log($"Initializing definitions repository with settings: Locale: {Locale}, Concurrency level: {concurrencyLevel}, Capacity: {definitionsLoaded}", LogType.Debug);

            _definitionRepositories = new ConcurrentDictionary<DefinitionsEnum, DestinyDefinitionTypeRepository>(
                concurrencyLevel: concurrencyLevel,
                capacity: definitionsLoaded);

        }

        /// <summary>
        /// Adds definition from repository, if possible
        /// </summary>
        /// <param name="definitionType"></param>
        /// <param name="definition"></param>
        /// <returns></returns>
        public bool AddDefinition(DefinitionsEnum definitionType, IDestinyDefinition definition)
        {
            if (_definitionRepositories.TryGetValue(definitionType, out var repository))
            {
                return repository.Add(definition);
            }
            else
                return false;
        }
        /// <summary>
        /// Removes definition from repository, if possible
        /// </summary>
        /// <param name="definitionType"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool RemoveDefinition(DefinitionsEnum definitionType, uint hash)
        {
            if (_definitionRepositories.TryGetValue(definitionType, out var repository))
            {
                return repository.Remove(hash);
            }
            return false;
        }
        public bool TryGetHistoricalStatsDefinition(string name, out DestinyHistoricalStatsDefinition val) => _historicalStatsDefinitions.TryGetValue(name, out val);
        /// <summary>
        /// Gets definition from repository, if possible
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hash"></param>
        /// <param name="definition"></param>
        /// <returns></returns>
        public bool TryGetDefinition<T>(DefinitionsEnum enumValue, uint hash, out T definition) where T : IDestinyDefinition
        {
            definition = default;
            if (_definitionRepositories.TryGetValue(enumValue, out var repository))
            {
                if (repository.TryGetDefinition<T>(hash, out var value))
                {
                    definition = value;
                    return definition != null;
                }
                else
                    return false;
            }
            else
                return false;
        }
        /// <summary>
        /// Gets definition from repository, if possible
        /// </summary>
        /// <param name="definitionType"></param>
        /// <param name="hash"></param>
        /// <param name="definition"></param>
        /// <returns></returns>
        public bool TryGetDefinition(DefinitionsEnum definitionType, uint hash, out IDestinyDefinition definition)
        {
            definition = default;
            if (_definitionRepositories.TryGetValue(definitionType, out var repository))
            {
                if (repository.TryGetDefinition(hash, out definition))
                {
                    return definition != null;
                }
                else
                    return false;
            }
            else
                return false;
        }
        /// <summary>
        /// Searches through repository with given predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> Search<T>(DefinitionsEnum definitionType, Func<IDestinyDefinition, bool> predicate) where T : IDestinyDefinition
        {
            if (_definitionRepositories.TryGetValue(definitionType, out var repository))
            {
                return repository.Where(predicate).Cast<T>();
            }
            else
                return null;
        }
        public IEnumerable<T> GetAll<T>(DefinitionsEnum definitionType)
        {
            if (_definitionRepositories.TryGetValue(definitionType, out var repository))
            {
                return repository.EnumerateValues().Cast<T>();
            }
            else
                return null;
        }
        
        internal void PremapPointers()
        {
            foreach (var repository in _definitionRepositories.Select(x => x.Value))
            {
                repository.MapValues();
            }
        }
    }
}
