using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Clients;
using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions;
using BungieNetCoreAPI.Logging;
using BungieNetCoreAPI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Unity;

namespace BungieNetCoreAPI.Repositories
{
    /// <summary>
    /// Repository class for storing and accessing all classes with <see cref="Attributes.DestinyDefinitionAttribute"/> attribute
    /// </summary>
    public class DefinitionCacheRepository
    {
        private readonly ILogger _logger;
        private Dictionary<string, IDestinyCacheRepository> _definitions;
        /// <summary>
        /// Locale of this repository
        /// </summary>
        public string Locale { get; }
        /// <summary>
        /// Class .ctor
        /// </summary>
        /// <param name="locale">Locale for this repository</param>
        public DefinitionCacheRepository(string locale)
        {
            _logger = UnityContainerFactory.Container.Resolve<ILogger>();
            _definitions = new Dictionary<string, IDestinyCacheRepository>();
            Locale = locale;
            var definitionNameToTypeMapping = Assembly
                .GetAssembly(typeof(DefinitionCacheRepository))
                .GetTypes()
                .Where(x =>
                {
                    var attrs = x.GetCustomAttributes(typeof(DestinyDefinitionAttribute), true);
                    return attrs != null && attrs.Length > 0 && (attrs.First() as DestinyDefinitionAttribute).IgnoreLoad == false;
                })
                .ToDictionary(
                x => (x.GetCustomAttribute(
                    attributeType: typeof(DestinyDefinitionAttribute),
                    inherit: true) as DestinyDefinitionAttribute).DefinitionName,
                x => x);

            foreach (var mapping in definitionNameToTypeMapping)
            {
                var type = typeof(DestinyDefinitionRepository<>).MakeGenericType(mapping.Value);
                var repository = (IDestinyCacheRepository)Activator.CreateInstance(type);
                _definitions.Add(mapping.Key, repository);
            }
        }

        /// <summary>
        /// Adds definition from repository, if possible
        /// </summary>
        /// <param name="definitionName"></param>
        /// <param name="definition"></param>
        /// <returns></returns>
        public bool Add(string definitionName, DestinyDefinition definition)
        {
            if (_definitions.TryGetValue(definitionName, out var repository))
            {
                return repository.Add(definition);
            }
            else
                return false;
        }
        /// <summary>
        /// Adds definition from repository, if possible
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        public bool Add(DestinyDefinition definition)
        {
            if (_definitions.TryGetValue(definition.GetType().Name, out var repository))
            {
                return repository.Add(definition);
            }
            else
                return false;
        }
        /// <summary>
        /// Removes definition from repository, if possible
        /// </summary>
        /// <param name="definitionName"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool Remove(string definitionName, uint hash)
        {
            if (_definitions.TryGetValue(definitionName, out var repository))
            {
                return repository.Remove(hash);
            }
            return false;
        }
        /// <summary>
        /// Removes definition from repository, if possible
        /// </summary>
        /// <param name="type"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool Remove(Type type, uint hash)
        {
            if (_definitions.TryGetValue(type.Name, out var repository))
            {
                return repository.Remove(hash);
            }
            return false;
        }
        /// <summary>
        /// Removes definition from repository, if possible
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool Remove<T>(uint hash) where T : DestinyDefinition
        {
            if (_definitions.TryGetValue(typeof(T).Name, out var repository))
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
        public bool TryGetDefinition<T>(uint hash, out T definition) where T : DestinyDefinition
        {
            definition = default;
            if (_definitions.TryGetValue(typeof(T).Name, out var repository))
            {
                if (repository.TryGetDefinition(hash, out var value))
                {
                    definition = (T)value;
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
        /// <param name="definitionName"></param>
        /// <param name="hash"></param>
        /// <param name="definition"></param>
        /// <returns></returns>
        public bool TryGetDefinition(string definitionName, uint hash, out DestinyDefinition definition)
        {
            definition = default;
            if (_definitions.TryGetValue(definitionName, out var repository))
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
        public IEnumerable<T> Search<T>(Func<DestinyDefinition, bool> predicate) where T : DestinyDefinition
        {
            if (_definitions.TryGetValue(typeof(T).Name, out var repository))
            {
                return repository.Where(predicate).Cast<T>();
            }
            else
                return null;
        }

        public IEnumerable<T> GetAll<T>()
        {
            if (_definitions.TryGetValue(typeof(T).Name, out var repository))
            {
                return repository.GetAll().Cast<T>();
            }
            else
                return null;
        }
        /// <summary>
        /// Loads all definitions from local files
        /// </summary>
        /// <param name="localManifestPath">Path to downloaded files</param>
        /// <param name="manifest"><see cref="DestinyManifest"/> with data</param>
        public void LoadDataFromDisk(string localManifestPath, DestinyManifest manifest)
        {
            UnityContainerFactory.Container.Resolve<ILocalisedDefinitionsCacheRepository>().SetLocaleContext(Locale);
            _logger.Log($"Started loading data for localization: {Locale}", LogType.Info);
            Stopwatch fullLoadStopwatch = new Stopwatch();
            fullLoadStopwatch.Start();
            var jsonWolrdComponentContentLocalePath = manifest.JsonWorldComponentContentPaths[Locale];

            var result = Parallel.ForEach(_definitions.Keys, (definitionName) => 
            {
                _logger.Log($"Reading: {definitionName}... ", LogType.Info);
                var definitionJson =
                    File.ReadAllText($"{localManifestPath}/JsonWorldComponentContent/{Locale}/{definitionName}/{Path.GetFileName(jsonWolrdComponentContentLocalePath[definitionName])}");
                var definitionJObjectDictionary = JObject.Parse(definitionJson);
                foreach (var entry in definitionJObjectDictionary)
                {
                    var definitionType = _definitions[definitionName].DefinitionType;
                    var deserializedDestinyDefinition = (DestinyDefinition)entry.Value.ToObject(definitionType);
                    Add(definitionName, deserializedDestinyDefinition);
                }
            });

            fullLoadStopwatch.Stop();
            _logger.Log($"Finished loading data for {Locale}: {fullLoadStopwatch.ElapsedMilliseconds} ms", LogType.Info);
            UnityContainerFactory.Container.Resolve<ILocalisedDefinitionsCacheRepository>().ResetLocaleContext();
        }
    }
}
