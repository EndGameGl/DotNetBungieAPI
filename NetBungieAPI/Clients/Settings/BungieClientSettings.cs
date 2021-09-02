using System;
using System.Linq;
using NetBungieAPI.Logging;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Applications;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Providers;

namespace NetBungieAPI.Clients.Settings
{
    /// <summary>
    /// Class that contains all settings to be used within this lib
    /// </summary>
    public class BungieClientSettings
    {
        /// <summary>
        /// Settings that are used for identifying client
        /// </summary>
        public ClientIdentificationSettings IdentificationSettings { get; } = ClientIdentificationSettings.Default;

        /// <summary>
        ///  Settings that are used for handling manifest versions
        /// </summary>
        public ManifestVersionSettings ManifestVersionSettings { get; } = ManifestVersionSettings.Default;

        /// <summary>
        /// Settings that are used for handling definition loading
        /// </summary>
        public DefinitionLoadingSettings DefinitionLoadingSettings { get; } = DefinitionLoadingSettings.Default;

        /// <summary>
        /// Some internal settings (as of now, it's mostly logging)
        /// </summary>
        internal InternalSettings InternalSettings { get; } = InternalSettings.Default;


        /// <summary>
        ///     Adds client API key to config
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
        ///     Adds client ID and secret to config.
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
        ///     Specifies in which scope should this app work
        /// </summary>
        /// <param name="scopes"></param>
        /// <returns></returns>
        public BungieClientSettings SpecifyApplicationScopes(ApplicationScopes scopes)
        {
            IdentificationSettings.ApplicationScopes = scopes;
            return this;
        }

        /// <summary>
        ///     Enables logging
        /// </summary>
        /// <returns></returns>
        public BungieClientSettings EnableLogging(LogListener.NewMessageEvent onLog)
        {
            InternalSettings.IsLoggingEnabled = true;
            InternalSettings.OnLog = onLog;
            return this;
        }

        /// <summary>
        ///     Sets up concurrency level for repository.
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
        ///     Specifies which locales can be loaded in this app.
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
        ///     Forbids these definitions from loading
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
        ///     Premaps all repository definitions after loading
        /// </summary>
        /// <returns></returns>
        public BungieClientSettings PremapDefinitions()
        {
            DefinitionLoadingSettings.PremapDefinitionPointers = true;
            return this;
        }

        /// <summary>
        ///     Loads all definitions in memory on startup.
        /// </summary>
        /// <returns></returns>
        public BungieClientSettings LoadAllDefinitionsOnStartup(bool waitEverythingToLoad)
        {
            DefinitionLoadingSettings.LoadAllDefinitionsOnStatup = true;
            DefinitionLoadingSettings.WaitAllDefinitionsToLoad = waitEverythingToLoad;
            return this;
        }

        /// <summary>
        ///     Specifies definition provider
        /// </summary>
        /// <param name="provider">Custom provider to be used</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Provider equals null</exception>
        public BungieClientSettings UseDefinitionProvider(DefinitionProvider provider)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider), "Provider is null.");
            DefinitionLoadingSettings.UsedProvider = provider;
            return this;
        }

        /// <summary>
        ///     Forces app to look up different manifest version available to load
        /// </summary>
        /// <param name="version">Version string to look for</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Empty version will throw an error</exception>
        public BungieClientSettings TryLoadManifestVersion(string version)
        {
            if (string.IsNullOrWhiteSpace(version))
                throw new ArgumentException("Version can't be empty");
            ManifestVersionSettings.ForceLoadManifestVersion = true;
            ManifestVersionSettings.PreferredLoadedManifestVersion = version;
            return this;
        }

        /// <summary>
        ///     Sets up how manifest updater will work.
        /// </summary>
        /// <param name="shouldCheckUpdates">Whether updates will be checked</param>
        /// <param name="keepOldVersions">Whether old versions would be kept after updates</param>
        /// <returns></returns>
        public BungieClientSettings SetUpdateBehaviour(bool shouldCheckUpdates, bool keepOldVersions)
        {
            ManifestVersionSettings.CheckUpdates = shouldCheckUpdates;
            ManifestVersionSettings.KeepOldVersions = keepOldVersions;
            return this;
        }

        /// <summary>
        /// Use default provider for this lib (<see cref="SqliteDefinitionProvider"/>)
        /// </summary>
        /// <param name="filePath">Path to the folder that contains all manifest data</param>
        /// <returns></returns>
        public BungieClientSettings UseDefaultProvider(string filePath)
        {
            DefinitionLoadingSettings.UsedProvider = new SqliteDefinitionProvider(filePath);
            return this;
        }

        /// <summary>
        /// Some actions to take after configuration is finished
        /// </summary>
        /// <exception cref="Exception"></exception>
        internal void AfterConfiguration()
        {
            var assemblyData = StaticUnityContainer.GetAssemblyData();
            var excludedFromLoad = DefinitionLoadingSettings.ForbiddenDefinitions;
            DefinitionLoadingSettings.AllowedDefinitions = assemblyData
                .DefinitionsToTypeMapping
                .Keys
                .Where(x => !excludedFromLoad.Contains(x))
                .ToArray();
            if (DefinitionLoadingSettings.UsedProvider is null)
                throw new Exception("Add UseDefaultProvider to config if you want to use default provider.");
        }
    }
}