using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IO;

namespace BungieNetCoreAPI.Clients.Settings
{
    public class BungieClientSettings
    {
        internal string ApiKey;

        internal bool CacheDefinitionsInMemory = false;
        internal bool TryDownloadMissingDefinitions = false;
        internal DestinyLocales[] Locales = null;

        internal bool IsUsingPreloadedData;

        internal string VersionsRepositoryPath;
        internal bool KeepOldVerisons;
        internal bool CheckUpdates;

        internal bool IsLoggingEnabled;

        internal bool UseExistingConfig = false;
        internal string ExistingConfigPath;
   
        internal Dictionary<DefinitionsEnum, bool> DefinitionLoadRules;
        internal DefinitionSources PreferredLoadSource;

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
        public void SetDefinitionsLoadingBehaviour(bool saveToAppMemory, bool tryDownloadMissingDefinitions, DefinitionSources preferredSource,
            params DestinyLocales[] localesToLoad)
        {
            CacheDefinitionsInMemory = saveToAppMemory;
            TryDownloadMissingDefinitions = tryDownloadMissingDefinitions;
            Locales = localesToLoad;
            PreferredLoadSource = preferredSource;
        }    
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
        public void UseVersionControl(bool keepOldVersions, bool checkUpdates, string repositoryPath)
        {
            KeepOldVerisons = keepOldVersions;
            CheckUpdates = checkUpdates;
            if (string.IsNullOrWhiteSpace(VersionsRepositoryPath) && !string.IsNullOrWhiteSpace(repositoryPath))
                VersionsRepositoryPath = repositoryPath;
        }
        public void ExcludeDefinitionsFromLoading(params DefinitionsEnum[] definitions)
        {

        }
    }
}
