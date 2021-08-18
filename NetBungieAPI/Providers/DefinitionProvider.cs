using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NetBungieAPI.Clients.Settings;
using NetBungieAPI.Exceptions;
using NetBungieAPI.Logging;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Config;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Providers
{
    /// <summary>
    /// Base class for providing definitions to library
    /// </summary>
    public abstract class DefinitionProvider
    {
        /// <summary>
        ///     Assembly metadata for definitions
        /// </summary>
        protected readonly IDefinitionAssemblyData AssemblyData = StaticUnityContainer.GetAssemblyData();

        /// <summary>
        ///     Direct access to D2 API, in case you'd need fetch a manifest or two
        /// </summary>
        protected readonly IDestiny2MethodsAccess Destiny2MethodsAccess =
            StaticUnityContainer.GetService<IDestiny2MethodsAccess>();

        /// <summary>
        ///     Http client of this lib in case you'd need to download any files (like .content DBs)
        /// </summary>
        protected readonly IHttpClientInstance HttpClientInstance = StaticUnityContainer.GetHTTPClient();

        /// <summary>
        /// Logger in case you'd want some notifications
        /// </summary>
        protected readonly ILogger Logger = StaticUnityContainer.GetLogger();

        /// <summary>
        /// Access to repositories you'd store definition into
        /// </summary>
        protected readonly ILocalisedDestinyDefinitionRepositories Repositories =
            StaticUnityContainer.GetDestinyDefinitionRepositories();

        /// <summary>
        /// Serializer that is used in this lib along with all json converter factories
        /// </summary>
        protected readonly IJsonSerializationHelper SerializationHelper =
            StaticUnityContainer.GetService<IJsonSerializationHelper>();

        /// <summary>
        /// Manifest that is used for this provider
        /// </summary>
        protected DestinyManifest UsedManifest { get; set; }

        /// <summary>
        /// Definition loading settings that you've set while configuring client
        /// </summary>
        protected DefinitionLoadingSettings DefinitionLoadingSettings { get; private set; }

        /// <summary>
        /// Manifest version settings that you've set while configuring client
        /// </summary>
        protected ManifestVersionSettings ManifestVersionSettings { get; private set; }

        /// <summary>
        /// On load that is called internally
        /// </summary>
        /// <param name="configurationService"></param>
        /// <exception cref="BungieResponseErrorException"></exception>
        internal async Task OnLoadInternal(IConfigurationService configurationService)
        {
            DefinitionLoadingSettings = configurationService.Settings.DefinitionLoadingSettings;
            ManifestVersionSettings = configurationService.Settings.ManifestVersionSettings;
            try
            {
                if (DefinitionLoadingSettings.DownloadLatestManifestOnLoad)
                {
                    var manifest = await Destiny2MethodsAccess.GetDestinyManifest();
                    if (!manifest.IsSuccessfulResponseCode)
                        throw manifest.ToException();
                    UsedManifest = manifest.Response;
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.Message, LogType.Error);
            }
        }

        /// <summary>
        /// On load <see cref="Task"/> that is called when first loading client
        /// </summary>
        /// <returns></returns>
        public abstract Task OnLoad();

        /// <summary>
        /// <see cref="Task"/> that defines how definitions are loaded into repository
        /// </summary>
        /// <param name="definitionsToLoad">Definition types to load</param>
        /// <returns></returns>
        public abstract Task ReadDefinitionsToRepository(IEnumerable<DefinitionsEnum> definitionsToLoad);

        /// <summary>
        /// Loads a single definition from provider
        /// </summary>
        /// <param name="hash">Definition hash</param>
        /// <param name="locale">Definition locale</param>
        /// <typeparam name="T">Definition type</typeparam>
        /// <returns></returns>
        public abstract ValueTask<T> LoadDefinition<T>(uint hash, BungieLocales locale) where T : IDestinyDefinition;

        /// <summary>
        /// Reads json string for definition
        /// </summary>
        /// <param name="enumValue">Definition type</param>
        /// <param name="hash">Definition hash</param>
        /// <param name="locale">Definition locale</param>
        /// <returns></returns>
        public abstract ValueTask<string> ReadDefinitionAsJson(DefinitionsEnum enumValue, uint hash,
            BungieLocales locale);

        /// <summary>
        /// Reads multiple definitions of a certain type
        /// </summary>
        /// <param name="hashes">Definition hashes</param>
        /// <param name="locale">Definitions locale</param>
        /// <typeparam name="T">Definitions type</typeparam>
        /// <returns></returns>
        public abstract ValueTask<ReadOnlyCollection<T>> LoadMultipleDefinitions<T>(uint[] hashes, BungieLocales locale)
            where T : IDestinyDefinition;

        /// <summary>
        /// Loads a single historical stats definition
        /// </summary>
        /// <param name="id">Definition ID</param>
        /// <param name="locale">Definition locale</param>
        /// <returns></returns>
        public abstract ValueTask<DestinyHistoricalStatsDefinition> LoadHistoricalStatsDefinition(string id,
            BungieLocales locale);

        /// <summary>
        /// Loads a single historical stats definition as json string
        /// </summary>
        /// <param name="id">Definition ID</param>
        /// <param name="locale">Definition locale</param>
        /// <returns></returns>
        public abstract ValueTask<string> LoadHistoricalStatsDefinitionAsJson(string id, BungieLocales locale);

        /// <summary>
        /// Loads all definitions of specified type
        /// </summary>
        /// <param name="locale">Definitions locale</param>
        /// <typeparam name="T">Definitions type</typeparam>
        /// <returns></returns>
        public abstract ValueTask<ReadOnlyCollection<T>> LoadAllDefinitions<T>(BungieLocales locale)
            where T : IDestinyDefinition;

        /// <summary>
        /// Gets all available manifests
        /// </summary>
        /// <returns></returns>
        public abstract ValueTask<IEnumerable<DestinyManifest>> GetAvailableManifests();

        /// <summary>
        /// Gets current manifest
        /// </summary>
        /// <returns></returns>
        public abstract ValueTask<DestinyManifest> GetCurrentManifest();

        /// <summary>
        /// Checks whether update is available
        /// </summary>
        /// <returns></returns>
        public abstract ValueTask<bool> CheckForUpdates();

        /// <summary>
        /// Updates files for current provider
        /// </summary>
        /// <returns></returns>
        public abstract Task Update();

        /// <summary>
        /// Download manifest data form manifest
        /// </summary>
        /// <param name="manifestData"></param>
        /// <returns></returns>
        public abstract Task DownloadNewManifestData(DestinyManifest manifestData);

        /// <summary>
        /// Deletes all outdated manifests
        /// </summary>
        /// <returns></returns>
        public abstract Task DeleteOldManifestData();

        /// <summary>
        /// Deletes all manifest data
        /// </summary>
        /// <param name="manifestData"></param>
        /// <returns></returns>
        public abstract Task DeleteManifestData(DestinyManifest manifestData);

        /// <summary>
        /// Check whether specified manifest version exists
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public abstract ValueTask<bool> CheckExistingManifestData(string version);
    }
}