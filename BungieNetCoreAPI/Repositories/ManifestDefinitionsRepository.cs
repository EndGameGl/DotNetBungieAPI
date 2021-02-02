using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions;
using BungieNetCoreAPI.Logging;
using BungieNetCoreAPI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BungieNetCoreAPI.Repositories
{
    /// <summary>
    /// Repository class for storing and accessing all classes with <see cref="Attributes.DestinyDefinitionAttribute"/> attribute
    /// </summary>
    public class ManifestDefinitionsRepository
    {
        private readonly ILogger _logger;
        private readonly IDefinitionAssemblyData _assemblyData;

        private Dictionary<DefinitionsEnum, DestinyDefinitionRepository> _definitions;
        /// <summary>
        /// Locale of this repository
        /// </summary>
        public DestinyLocales Locale { get; }
        /// <summary>
        /// Class .ctor
        /// </summary>
        /// <param name="locale">Locale for this repository</param>
        internal ManifestDefinitionsRepository(DestinyLocales locale, LoadSourceMode loadMode, Dictionary<DefinitionsEnum, bool> loadOverrides)
        {
            _logger = UnityContainerFactory.Container.Resolve<ILogger>();
            _definitions = new Dictionary<DefinitionsEnum, DestinyDefinitionRepository>();
            Locale = locale;
            _assemblyData = UnityContainerFactory.Container.Resolve<IDefinitionAssemblyData>();

            foreach (var mapping in _assemblyData.DefinitionsToTypeMapping)
            {
                if (mapping.Value.IsEnabled)
                {
                    switch (loadMode)
                    {
                        case LoadSourceMode.SQLite:
                            if (mapping.Value.PresentInSQLiteDB == true)
                                _definitions.Add(mapping.Key, new DestinyDefinitionRepository(mapping.Value.DefinitionType));
                            break;
                        case LoadSourceMode.JSON:
                            _definitions.Add(mapping.Key, new DestinyDefinitionRepository(mapping.Value.DefinitionType));
                            break;
                    }
                }
            }

            if (loadOverrides != null && loadOverrides.Count > 0)
            {
                _definitions = _definitions
                    .Where(x =>
                    {
                        if (loadOverrides.TryGetValue(x.Key, out var value))
                        {
                            return value;
                        }
                        else
                            return true;
                    })
                    .ToDictionary(x => x.Key, y => y.Value);
            }
        }

        /// <summary>
        /// Adds definition from repository, if possible
        /// </summary>
        /// <param name="definitionType"></param>
        /// <param name="definition"></param>
        /// <returns></returns>
        public bool Add(DefinitionsEnum definitionType, IDestinyDefinition definition)
        {
            if (_definitions.TryGetValue(definitionType, out var repository))
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
        public bool Remove(DefinitionsEnum definitionType, uint hash)
        {
            if (_definitions.TryGetValue(definitionType, out var repository))
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
            if (_definitions.TryGetValue(enumValue, out var repository))
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
            if (_definitions.TryGetValue(definitionType, out var repository))
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
            if (_definitions.TryGetValue(definitionType, out var repository))
            {
                return repository.Where(predicate).Cast<T>();
            }
            else
                return null;
        }
        public IEnumerable<T> GetAll<T>(DefinitionsEnum definitionType)
        {
            if (_definitions.TryGetValue(definitionType, out var repository))
            {
                return repository.Enumerate().Cast<T>();
            }
            else
                return null;
        }

        #region Load methods
        /// <summary>
        /// Loads all definitions from local files
        /// </summary>
        /// <param name="localManifestPath">Path to downloaded files</param>
        /// <param name="manifest"><see cref="DestinyManifest"/> with data</param>
        private void LoadDataFromJSON(string localManifestPath, DestinyManifest manifest)
        {
            UnityContainerFactory.Container.Resolve<ILocalisedManifestDefinitionRepositories>().SetLocaleContext(Locale);
            _logger.Log($"Started loading data for localization: {Locale}", LogType.Info);
            Stopwatch fullLoadStopwatch = new Stopwatch();
            fullLoadStopwatch.Start();
            var jsonWolrdComponentContentLocalePath = manifest.JsonWorldComponentContentPaths[Locale.LocaleToString()];

            var result = Parallel.ForEach(_definitions.Keys, (definitionName) =>
            {
                _logger.Log($"Reading: {definitionName}... ", LogType.Info);
                using var fs = File.OpenRead($"{localManifestPath}/JsonWorldComponentContent/{Locale}/{definitionName}/{Path.GetFileName(jsonWolrdComponentContentLocalePath[_assemblyData.EnumToNameMapping[definitionName]])}");
                using var sr = new StreamReader(fs, Encoding.UTF8);
                var definitionJson = sr.ReadToEnd();
                var definitionJObjectDictionary = JObject.Parse(definitionJson);
                foreach (var entry in definitionJObjectDictionary)
                {
                    var definitionType = _definitions[definitionName].Type;
                    var deserializedDestinyDefinition = (IDestinyDefinition)entry.Value.ToObject(definitionType);
                    Add(definitionName, deserializedDestinyDefinition);
                }
            });

            fullLoadStopwatch.Stop();
            _logger.Log($"Finished loading data for {Locale}: {fullLoadStopwatch.ElapsedMilliseconds} ms", LogType.Info);
            UnityContainerFactory.Container.Resolve<ILocalisedManifestDefinitionRepositories>().ResetLocaleContext();
            GC.Collect();
        }
        private void LoadDataFromSQLiteDB(string localManifestPath, DestinyManifest manifest)
        {
            UnityContainerFactory.Container.Resolve<ILocalisedManifestDefinitionRepositories>().SetLocaleContext(Locale);
            _logger.Log($"Started loading data for localization: {Locale}", LogType.Info);
            Stopwatch fullLoadStopwatch = new Stopwatch();
            fullLoadStopwatch.Start();
            var mobileWorldContentPathsLocalePath = Path.GetFileName(manifest.MobileWorldContentPaths[Locale.LocaleToString()]);

            using (SQLiteConnection connection = new SQLiteConnection(@$"Data Source={localManifestPath}\\MobileWorldContent\\{Locale}\\{mobileWorldContentPathsLocalePath}; Version=3;"))
            {
                connection.Open();
                foreach (var key in _definitions.Keys)
                {
                    var definitionType = _definitions[key].Type;
                    _logger.Log($"Loading definitions from {key} ({Locale})", LogType.Info);
                    string query = $"SELECT * FROM {key}";
                    //_logger.Log($"Executing query: {query}", LogType.Debug);
                    SQLiteCommand command = new SQLiteCommand
                    {
                        Connection = connection,
                        CommandText = query
                    };
                    try
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var byteArray = (byte[])reader["json"];
                            var jsonString = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
                            var definition = JObject.Parse(jsonString);
                            var deserializedDestinyDefinition = (IDestinyDefinition)definition.ToObject(definitionType);
                            Add(key, deserializedDestinyDefinition);
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.Log(e.Message, LogType.Error);
                    }
                    _definitions[key].SortByIndex();
                }
                connection.Close();
            }

            fullLoadStopwatch.Stop();
            _logger.Log($"Finished loading data for {Locale}: {fullLoadStopwatch.ElapsedMilliseconds} ms", LogType.Info);
            UnityContainerFactory.Container.Resolve<ILocalisedManifestDefinitionRepositories>().ResetLocaleContext();
        }
        public void LoadDataFromFiles(LoadSourceMode loadMode, string localManifestPath, DestinyManifest manifest)
        {
            switch (loadMode)
            {
                case LoadSourceMode.JSON:
                    LoadDataFromJSON(localManifestPath, manifest);
                    break;
                case LoadSourceMode.SQLite:
                    LoadDataFromSQLiteDB(localManifestPath, manifest);
                    break;
            }
        }

        #endregion
    }
}
