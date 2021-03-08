using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BungieNetCoreAPI.Clients.Settings
{
    public class BungieClientSettings
    {
        internal string ApiKey;

        internal int AppConcurrencyLevel = Environment.ProcessorCount * 2;
        internal bool CacheDefinitionsInMemory = false;
        internal bool TryDownloadMissingDefinitions = false;
        internal DestinyLocales[] Locales = Array.Empty<DestinyLocales>();

        internal bool IsUsingPreloadedData = false;

        internal string VersionsRepositoryPath;
        internal bool KeepOldVerisons;
        internal bool CheckUpdates;

        internal bool IsLoggingEnabled = false;

        internal bool UseExistingConfig = false;
        internal string ExistingConfigPath;
   
        internal Dictionary<DefinitionsEnum, DefinitionSources> SpecifiedLoadSources;
        internal DefinitionSources PreferredLoadSource;
        internal DefinitionsEnum[] ExcludedDefinitions = Array.Empty<DefinitionsEnum>();

        /// <summary>
        /// Adds API key to use for this app.
        /// </summary>
        /// <param name="key"></param>
        public void IncludeApiKey(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
                ApiKey = key;
            else
                throw new Exception("API key is missing or invalid.");
        }
        /// <summary>
        /// Specifies that you want to load settings from json.
        /// </summary>
        /// <param name="path"></param>
        public void UseExistingSettingsJson(string path)
        {
            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path) && Path.GetExtension(path).Equals("json"))
            {
                UseExistingConfig = true;
                ExistingConfigPath = path;
            }
            else
                throw new Exception("Valid file is missing at given path.");
        }
        /// <summary>
        /// Defines how app will hanlde definitions.
        /// </summary>
        /// <param name="saveToAppMemory"></param>
        /// <param name="tryDownloadMissingDefinitions"></param>
        /// <param name="preferredSource"></param>
        /// <param name="localesToLoad"></param>
        public void SetDefinitionsLoadingBehaviour(bool saveToAppMemory, bool tryDownloadMissingDefinitions, DefinitionSources preferredSource,
            params DestinyLocales[] localesToLoad)
        {
            CacheDefinitionsInMemory = saveToAppMemory;
            TryDownloadMissingDefinitions = tryDownloadMissingDefinitions;
            Locales = localesToLoad;
            PreferredLoadSource = preferredSource;
        }    
        /// <summary>
        /// Makes app use already downloaded manifest databases. (Make sure to download them first))
        /// <para/>
        /// To download you need to run BungieClient.Platform.
        /// </summary>
        /// <param name="path"></param>
        public void UsePreloadedData(string path)
        {
            if (!string.IsNullOrWhiteSpace(path) && Directory.Exists(path))
            {
                IsUsingPreloadedData = true;
                VersionsRepositoryPath = path;
            }
            else
                throw new Exception("Incorrect data folder path.");
        }
        /// <summary>
        /// Uses version control for updating definition databases.
        /// </summary>
        /// <param name="keepOldVersions"></param>
        /// <param name="checkUpdates"></param>
        /// <param name="repositoryPath"></param>
        public void UseVersionControl(bool keepOldVersions, bool checkUpdates, string repositoryPath)
        {
            KeepOldVerisons = keepOldVersions;
            CheckUpdates = checkUpdates;
            if (string.IsNullOrWhiteSpace(VersionsRepositoryPath) && !string.IsNullOrWhiteSpace(repositoryPath))
                VersionsRepositoryPath = repositoryPath;
        }
        /// <summary>
        /// Excludes definitions from loading in this session.
        /// </summary>
        /// <param name="definitions"></param>
        public void ExcludeDefinitionsFromLoading(DefinitionsEnum[] definitions)
        {
            ExcludedDefinitions = definitions;
        }
        /// <summary>
        /// Specifies loading sources for chosen definitions
        /// </summary>
        /// <param name="config"></param>
        public void SpecifyLoadSources(Dictionary<DefinitionsEnum, DefinitionSources> config)
        {
            if (config.Values.Any(x => x.HasFlag(DefinitionSources.None) || x.HasFlag(DefinitionSources.BungieNet) || x.HasFlag(DefinitionSources.All)))
                throw new Exception("While specifying load sources. Choose between JSON and SQLite.");
            SpecifiedLoadSources = config;
        }
        public void ChangeAppConcurrencyLevel(int level)
        {
            if (level > 0)
                AppConcurrencyLevel = level;
            else
                throw new Exception("Concurrency level can't be lower than zero.");
        }
        public void EnableLogging()
        {
            IsLoggingEnabled = true;
        }
    }
}
