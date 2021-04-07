using NetBungieAPI.Models.Applications;
using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NetBungieAPI.Clients.Settings
{
    public class BungieClientSettings
    {
        internal string ApiKey;
        internal int? ClientID = null;
        internal string ClientSecret = null;
        internal ApplicationScopes ApplicationScopes = ApplicationScopes.ReadBasicUserProfile;

        internal int AppConcurrencyLevel = Environment.ProcessorCount * 2;
        internal bool CacheDefinitionsInMemory = false;
        internal DestinyLocales[] Locales = Array.Empty<DestinyLocales>();
        internal bool ShouldRetryDownloading = false;
        internal bool PremapDefinitionPointers = false;

        internal bool IsUsingPreloadedData = false;

        internal bool ShouldLoadSpecifiedManifest;
        internal string PreferredLoadedManifest;
        internal string VersionsRepositoryPath;
        internal bool KeepOldVerisons;
        internal bool CheckUpdates;
        internal Action<IManifestVersionHandler> OnManifestInitiation;

        internal bool IsLoggingEnabled = false;

        internal bool UseExistingConfig = false;
        internal string ExistingConfigPath;

        internal Dictionary<DefinitionsEnum, DefinitionSources> SpecifiedLoadSources = new Dictionary<DefinitionsEnum, DefinitionSources>(0);
        internal DefinitionSources PreferredLoadSource = DefinitionSources.SQLite;
        internal DefinitionsEnum[] ExcludedDefinitions = Array.Empty<DefinitionsEnum>();

        internal int TokenCheckRefreshRate;
        internal bool RenewTokens;

        /// <summary>
        /// Adds API key to use for this app.
        /// </summary>
        /// <param name="key"></param>
        public BungieClientSettings IncludeApiKey(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
                ApiKey = key;
            else
                throw new Exception("API key is missing or invalid.");
            return this;
        }
        /// <summary>
        /// Specifies that you want to load settings from json.
        /// </summary>
        /// <param name="path"></param>
        public BungieClientSettings UseExistingSettingsJson(string path)
        {
            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path) && Path.GetExtension(path).Equals("json"))
            {
                UseExistingConfig = true;
                ExistingConfigPath = path;
            }
            else
                throw new Exception("Valid file is missing at given path.");
            return this;
        }
        /// <summary>
        /// Defines how app will hanlde definitions.
        /// </summary>
        /// <param name="saveToAppMemory"></param>
        /// <param name="tryDownloadMissingDefinitions"></param>
        /// <param name="preferredSource"></param>
        /// <param name="localesToLoad"></param>
        public BungieClientSettings SetDefinitionsLoadingBehaviour(bool saveToAppMemory, DefinitionSources preferredSource, bool retryDownloading,
            params DestinyLocales[] localesToLoad)
        {
            CacheDefinitionsInMemory = saveToAppMemory;
            Locales = localesToLoad;
            PreferredLoadSource = preferredSource;
            ShouldRetryDownloading = retryDownloading;
            return this;
        }    
        /// <summary>
        /// Makes app use already downloaded manifest databases. (Make sure to download them first))
        /// <para/>
        /// To download you need to run BungieClient.Platform.
        /// </summary>
        /// <param name="path"></param>
        public BungieClientSettings UsePreloadedData(string path)
        {
            if (!string.IsNullOrWhiteSpace(path) && Directory.Exists(path))
            {
                IsUsingPreloadedData = true;
                VersionsRepositoryPath = path;
            }
            else
                throw new Exception("Incorrect data folder path.");
            return this;
        }
        /// <summary>
        /// Uses version control for updating definition databases.
        /// </summary>
        /// <param name="keepOldVersions"></param>
        /// <param name="checkUpdates"></param>
        /// <param name="repositoryPath"></param>
        public BungieClientSettings UseVersionControl(bool keepOldVersions, bool checkUpdates, string repositoryPath, 
            Action<IManifestVersionHandler> afterLoad = null)
        {
            KeepOldVerisons = keepOldVersions;
            CheckUpdates = checkUpdates;
            if (string.IsNullOrWhiteSpace(VersionsRepositoryPath) && !string.IsNullOrWhiteSpace(repositoryPath))
                VersionsRepositoryPath = repositoryPath;
            OnManifestInitiation = afterLoad;
            return this;
        }
        /// <summary>
        /// Excludes definitions from loading in this session.
        /// </summary>
        /// <param name="definitions"></param>
        public BungieClientSettings ExcludeDefinitionsFromLoading(DefinitionsEnum[] definitions)
        {
            ExcludedDefinitions = definitions;
            return this;
        }
        /// <summary>
        /// Specifies loading sources for chosen definitions
        /// </summary>
        /// <param name="config"></param>
        public BungieClientSettings SpecifyLoadSources(Dictionary<DefinitionsEnum, DefinitionSources> config)
        {
            if (config.Values.Any(x => x.HasFlag(DefinitionSources.BungieNet) || x.HasFlag(DefinitionSources.All)))
                throw new Exception("While specifying load sources. Choose between JSON and SQLite.");
            SpecifiedLoadSources = config;
            return this;
        }
        /// <summary>
        /// Specifies which concurrency level will be predefined when creating all <see cref="ConcurrentDictionary{T, P}"/>
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public BungieClientSettings ChangeAppConcurrencyLevel(int level)
        {
            if (level > 0)
                AppConcurrencyLevel = level;
            else
                throw new Exception("Concurrency level can't be lower than zero.");
            return this;
        }
        /// <summary>
        /// Enables logging.
        /// </summary>
        /// <returns></returns>
        public BungieClientSettings EnableLogging()
        {
            IsLoggingEnabled = true;
            return this;
        }
        /// <summary>
        /// Premaps every <see cref="DefinitionHashPointer{T}"/> present in repository.
        /// </summary>
        /// <returns></returns>
        public BungieClientSettings PremapPointers()
        {
            PremapDefinitionPointers = true;
            return this;
        }
        /// <summary>
        /// Loads in client ID and secret for OAuth2.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        public BungieClientSettings IncludeClientIdAndSecret(int clientId, string clientSecret)
        {
            ClientID = clientId;
            ClientSecret = clientSecret;
            return this;
        }
        /// <summary>
        /// Enables OAuth2 token renewal at specified intervals.
        /// </summary>
        /// <param name="refreshRate"></param>
        /// <returns></returns>
        public BungieClientSettings EnableTokenRenewal(int refreshRate = 180000)
        {
            RenewTokens = true;
            TokenCheckRefreshRate = refreshRate;
            return this;
        }
        /// <summary>
        /// If you have multiple databases downloaded, this will force app to load which one to load.
        /// </summary>
        /// <param name="manifestVersion"></param>
        /// <returns></returns>
        public BungieClientSettings LoadSpecifiedManifest(string manifestVersion)
        {
            ShouldLoadSpecifiedManifest = true;
            PreferredLoadedManifest = manifestVersion;
            return this;
        }
        /// <summary>
        /// Specifies app client scopes so methods that shouldn't fire won't
        /// </summary>
        /// <param name="scopes"></param>
        /// <returns></returns>
        public BungieClientSettings SpecifyApplicationScopes(ApplicationScopes scopes)
        {
            ApplicationScopes = scopes;
            return this;
        }
    }
}
