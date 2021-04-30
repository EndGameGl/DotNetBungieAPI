using NetBungieAPI.Models.Applications;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NetBungieAPI.Logging;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Providers;

namespace NetBungieAPI.Clients.Settings
{
    public class BungieClientSettings
    {
        public ClientIdentificationSettings IdentificationSettings { get; } = ClientIdentificationSettings.Default;
        public ManifestVersionSettings ManifestVersionSettings { get; } = ManifestVersionSettings.Default;
        public DefinitionLoadingSettings DefinitionLoadingSettings { get; } = DefinitionLoadingSettings.Default;
        public LocalFileSettings LocalFileSettings { get; } = LocalFileSettings.Default;
        internal InternalSettings InternalSettings { get; } = InternalSettings.Default;


        /// <summary>
        /// Adds client API key to config
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public BungieClientSettings AddApiKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("API key is missing or invalid.");
            IdentificationSettings.ApiKey = key;
            return this;
        }

        /// <summary>
        /// Adds client ID and secret to config.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public BungieClientSettings AddClientIdAndSecret(int id, string secret)
        {
            if (string.IsNullOrWhiteSpace(secret))
                throw new ArgumentException("Client secret can't be empty");
            if (id < 0)
                throw new ArgumentException("Client id can't be less than 0");
            IdentificationSettings.ClientId = id;
            IdentificationSettings.ClientSecret = secret;
            return this;
        }

        /// <summary>
        /// Specifies in which scope should this app work
        /// </summary>
        /// <param name="scopes"></param>
        /// <returns></returns>
        public BungieClientSettings SpecifyApplicationScopes(ApplicationScopes scopes)
        {
            IdentificationSettings.ApplicationScopes = scopes;
            return this;
        }

        /// <summary>
        /// Specifies path to local manifest files
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public BungieClientSettings UseLocalManifestFiles(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path can't be empty");
            if (!Directory.Exists(path))
                throw new Exception("Directory doesn't exist.");
            LocalFileSettings.VersionsRepositoryPath = path;
            return this;
        }

        /// <summary>
        /// Enables logging
        /// </summary>
        /// <returns></returns>
        public BungieClientSettings EnableLogging(LogListener.NewMessageEvent onLog)
        {
            InternalSettings.IsLoggingEnabled = true;
            InternalSettings.OnLog = onLog;
            return this;
        }

        /// <summary>
        /// Sets up concurrency level for repository.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public BungieClientSettings SetAppConcurrencyLevel(int level)
        {
            if (level <= 0)
                throw new ArgumentException("Concurrency level can't be lower than 0");
            DefinitionLoadingSettings.AppConcurrencyLevel = level;
            return this;
        }

        /// <summary>
        /// Specifies which locales can be loaded in this app.
        /// </summary>
        /// <param name="locales"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public BungieClientSettings SetLocales(BungieLocales[] locales)
        {
            if (locales == null || locales.Length == 0)
                throw new ArgumentException("Specify locales before loading");
            DefinitionLoadingSettings.Locales = locales;
            return this;
        }

        /// <summary>
        /// Forbids these definitions from loading
        /// </summary>
        /// <param name="definitions"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public BungieClientSettings ExcludeDefinitionsFromLoading(DefinitionsEnum[] definitions)
        {
            if (definitions == null || definitions.Length == 0)
                throw new ArgumentException("Specify definitions to exclude before loading");
            DefinitionLoadingSettings.ForbiddenDefinitions = definitions;
            return this;
        }

        /// <summary>
        /// Premaps all repository definitions after loading
        /// </summary>
        /// <returns></returns>
        public BungieClientSettings PremapDefinitions()
        {
            DefinitionLoadingSettings.PremapDefinitionPointers = true;
            return this;
        }

        /// <summary>
        /// Loads all definitions in memory on startup.
        /// </summary>
        /// <returns></returns>
        public BungieClientSettings LoadAllDefinitionsOnStartup(bool waitEverythingToLoad)
        {
            DefinitionLoadingSettings.LoadAllDefinitionsOnStatup = true;
            DefinitionLoadingSettings.WaitAllDefinitionsToLoad = waitEverythingToLoad;
            return this;
        }

        /// <summary>
        /// Specifies definition provider
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public BungieClientSettings UseDefinitionProvider(DefinitionProvider provider)
        {
            if (provider is null)
                throw new Exception("Provider is null.");
            DefinitionLoadingSettings.UsedProvider = provider;
            return this;
        }

        /// <summary>
        /// Forces app to look up different manifest version available to load
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public BungieClientSettings TryLoadManifestVersion(string version)
        {
            if (string.IsNullOrWhiteSpace(version))
                throw new ArgumentException("Version can't be empty");
            ManifestVersionSettings.ForceLoadManifestVersion = true;
            ManifestVersionSettings.PreferredLoadedManifestVersion = version;
            return this;
        }

        /// <summary>
        /// Sets up how manifest updater will work.
        /// </summary>
        /// <param name="shouldCheckUpdates"></param>
        /// <param name="keepOldVersions"></param>
        /// <returns></returns>
        public BungieClientSettings SetUpdateBehaviour(bool shouldCheckUpdates, bool keepOldVersions)
        {
            ManifestVersionSettings.CheckUpdates = shouldCheckUpdates;
            ManifestVersionSettings.KeepOldVersions = keepOldVersions;
            return this;
        }
        
        internal void AfterConfigurated()
        {
            var assemblyData = StaticUnityContainer.GetAssemblyData();
            var excludedFromLoad = DefinitionLoadingSettings.ForbiddenDefinitions;
            DefinitionLoadingSettings.AllowedDefinitions = assemblyData
                .DefinitionsToTypeMapping
                .Keys
                .Where(x => !excludedFromLoad.Contains(x))
                .ToArray();
            DefinitionLoadingSettings.UsedProvider ??= new SqliteDefinitionProvider();
        }
    }
}