using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions;
using BungieNetCoreAPI.Destiny.Definitions.HistoricalStats;
using BungieNetCoreAPI.Logging;
using BungieNetCoreAPI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungieNetCoreAPI.Repositories
{
    /// <summary>
    /// Repository class for storing and accessing all classes with <see cref="Attributes.DestinyDefinitionAttribute"/> attribute
    /// </summary>
    public class DestinyDefinitionsRepository
    {
        private readonly string SELECT_QUERY = "SELECT * FROM {0}";

        private readonly ILogger _logger;
        private readonly IDefinitionAssemblyData _assemblyData;
        private readonly IConfigurationService _config;

        private ConcurrentDictionary<DefinitionsEnum, DestinyDefinitionTypeRepository> _definitionRepositories;
        private ConcurrentDictionary<string, DestinyHistoricalStatsDefinition> _historicalStatsDefinitions;

        private Dictionary<DefinitionsEnum, DefinitionSources> _loadRules;
        /// <summary>
        /// Locale of this repository
        /// </summary>
        public DestinyLocales Locale { get; }
        /// <summary>
        /// Class .ctor
        /// </summary>
        /// <param name="locale">Locale for this repository</param>
        internal DestinyDefinitionsRepository(DestinyLocales locale, IDefinitionAssemblyData assemblyData, IConfigurationService configuration, ILogger logger)
        {
            _assemblyData = assemblyData;
            _config = configuration;
            _logger = logger;
            Locale = locale;

            _loadRules =
                _assemblyData.DefinitionsToTypeMapping
                .Where(x => !_config.Settings.ExcludedDefinitions.Contains(x.Key))
                .Where(x => x.Value.AttributeData.Sources.HasFlag(_config.Settings.PreferredLoadSource))
                .ToDictionary(x => x.Key, x => _config.Settings.PreferredLoadSource);

            if (_config.Settings.SpecifiedLoadSources.Count > 0)
            {
                foreach (var source in _config.Settings.SpecifiedLoadSources)
                {
                    var definitionAssemblyRules = _assemblyData.DefinitionsToTypeMapping[source.Key];
                    if (definitionAssemblyRules.AttributeData.Sources.HasFlag(source.Value))
                    {
                        if (!_loadRules.TryAdd(source.Key, source.Value))
                            _loadRules[source.Key] = source.Value;
                    }
                }
            }

            int definitionsLoaded = _loadRules.Count;
            int concurrencyLevel = _config.Settings.AppConcurrencyLevel;

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

        #region Load methods
        public void LoadDataFromFiles(string localManifestPath, DestinyManifest manifest)
        {
            Stopwatch sw = new Stopwatch();
            _logger.Log($"Started loading data for localization: {Locale}", LogType.Info);
            var sqliteLoadedRepos = _loadRules
                .Where(x => x.Value == DefinitionSources.SQLite)
                .Select(x => x.Key)
                .ToArray();

            var jsonLoadedRepos = _loadRules.Where(x => x.Value == DefinitionSources.JSON).Select(x => x.Key).ToArray();

            if (sqliteLoadedRepos.Length > 0)
            {
                _logger.Log($"Loading {sqliteLoadedRepos.Length} definitions from SQLite source.", LogType.Info);
                sw.Start();
                LoadDefinitionsFromSQLite(sqliteLoadedRepos, localManifestPath, manifest, sqliteLoadedRepos.Contains(DefinitionsEnum.DestinyHistoricalStatsDefinition));
                sw.Stop();
                _logger.Log($"Loaded definitions from SQLite: {sw.ElapsedMilliseconds} ms.", LogType.Info);
            }

            if (jsonLoadedRepos.Length > 0)
            {
                _logger.Log($"Loading {jsonLoadedRepos.Length} definitions from JSON source.", LogType.Info);
                sw.Restart();
                LoadDefinitionFromJSON(jsonLoadedRepos, localManifestPath, manifest); sw.Stop();
                _logger.Log($"Loaded definitions from JSON files: {sw.ElapsedMilliseconds} ms.", LogType.Info);
            }
        }
        private void LoadDefinitionsFromSQLite(DefinitionsEnum[] definitions, string localManifestPath, DestinyManifest manifest, bool loadHistoricalDefinitions)
        {
            var mobileWorldContentPathsLocalePath = Path.GetFileName(manifest.MobileWorldContentPaths[Locale.LocaleToString()]);
            using (SQLiteConnection connection = new SQLiteConnection(
                @$"Data Source={localManifestPath}\\MobileWorldContent\\{Locale}\\{mobileWorldContentPathsLocalePath}; Version=3;"))
            {
                connection.Open();
                foreach (var key in definitions)
                {
                    if (key == DefinitionsEnum.DestinyHistoricalStatsDefinition)
                        continue;
                    var definitionType = _assemblyData.DefinitionsToTypeMapping[key].DefinitionType;
                    _definitionRepositories.TryAdd(key, new DestinyDefinitionTypeRepository(definitionType, _config.Settings.AppConcurrencyLevel));
                    _logger.Log($"Loading definitions from {key} ({Locale})", LogType.Info);
                    SQLiteCommand command = new SQLiteCommand() { Connection = connection, CommandText = GetSQLSelectQuery(key.ToString()) };
                    try
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            AddDefinition(key, ParseJsonFromSQLiteDataReader<IDestinyDefinition>(reader, definitionType));
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.Log(e.Message, LogType.Error);
                    }
                }
                if (loadHistoricalDefinitions)
                {
                    _historicalStatsDefinitions = new ConcurrentDictionary<string, DestinyHistoricalStatsDefinition>(_config.Settings.AppConcurrencyLevel, 31);
                    var definitionType = _assemblyData.DefinitionsToTypeMapping[DefinitionsEnum.DestinyHistoricalStatsDefinition].DefinitionType;
                    _logger.Log($"Loading definitions from DestinyHistoricalStatsDefinition ({Locale})", LogType.Info);
                    SQLiteCommand command = new SQLiteCommand()
                    {
                        Connection = connection,
                        CommandText = GetSQLSelectQuery(DefinitionsEnum.DestinyHistoricalStatsDefinition.ToString())
                    };
                    try
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var definition = ParseJsonFromSQLiteDataReader<DestinyHistoricalStatsDefinition>(reader, definitionType);
                            _historicalStatsDefinitions.TryAdd(definition.StatId, definition);
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.Log(e.Message, LogType.Error);
                    }
                }
                connection.Close();
            }
        }
        private void LoadDefinitionFromJSON(DefinitionsEnum[] definitions, string localManifestPath, DestinyManifest manifest)
        {        
            var jsonWolrdComponentContentLocalePath = manifest.JsonWorldComponentContentPaths[Locale.LocaleToString()];

            var result = Parallel.ForEach(definitions, (definitionName) =>
            {
                _logger.Log($"Loading definitions from {definitionName} ({Locale})", LogType.Info);
                using var fs = File.OpenRead($"{localManifestPath}/JsonWorldComponentContent/{Locale}/{definitionName}/{Path.GetFileName(jsonWolrdComponentContentLocalePath[_assemblyData.EnumToNameMapping[definitionName]])}");
                using var sr = new StreamReader(fs, Encoding.UTF8);
                var definitionJson = sr.ReadToEnd();
                var definitionJObjectDictionary = JObject.Parse(definitionJson);
                foreach (var entry in definitionJObjectDictionary)
                {
                    var definitionType = _assemblyData.DefinitionsToTypeMapping[definitionName].DefinitionType;
                    _definitionRepositories.TryAdd(definitionName, new DestinyDefinitionTypeRepository(definitionType, _config.Settings.AppConcurrencyLevel));
                    var deserializedDestinyDefinition = (IDestinyDefinition)entry.Value.ToObject(definitionType);
                    AddDefinition(definitionName, deserializedDestinyDefinition);
                }
            });
            GC.Collect();
        }
        private T ParseJsonFromSQLiteDataReader<T>(SQLiteDataReader reader, Type parseTo)
        {
            var byteArray = (byte[])reader["json"];
            var jsonString = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            var definition = JObject.Parse(jsonString);
            return (T)definition.ToObject(parseTo);
        }
        private string GetSQLSelectQuery(string tableName) => string.Format(SELECT_QUERY, tableName);
        #endregion
    }
}
