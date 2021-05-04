using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using NetBungieAPI.Clients.Settings;
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
    public abstract class DefinitionProvider
    {
        protected readonly IDestiny2MethodsAccess Destiny2MethodsAccess =
            StaticUnityContainer.GetService<IDestiny2MethodsAccess>();

        protected readonly IJsonSerializationHelper SerializationHelper =
            StaticUnityContainer.GetService<IJsonSerializationHelper>();

        protected readonly IDefinitionAssemblyData AssemblyData = StaticUnityContainer.GetAssemblyData();

        protected readonly ILocalisedDestinyDefinitionRepositories Repositories =
            StaticUnityContainer.GetDestinyDefinitionRepositories();

        protected readonly ILogger Logger = StaticUnityContainer.GetLogger();

        protected readonly IHttpClientInstance HttpClientInstance = StaticUnityContainer.GetHTTPClient();
        protected DestinyManifest UsedManifest { get; set; } = null;
        protected DefinitionLoadingSettings DefinitionLoadingSettings { get; private set; }
        protected ManifestVersionSettings ManifestVersionSettings { get; private set; }
        internal async Task OnLoadInternal(IConfigurationService configurationService)
        {
            DefinitionLoadingSettings = configurationService.Settings.DefinitionLoadingSettings;
            ManifestVersionSettings = configurationService.Settings.ManifestVersionSettings;
            try
            {
                if (DefinitionLoadingSettings.DownloadLatestManifestOnLoad)
                    UsedManifest = (await Destiny2MethodsAccess.GetDestinyManifest()).Response;
            }
            catch (Exception e)
            {
                Logger.Log(e.Message, LogType.Error);
            }
        }

        public abstract Task OnLoad();
        public abstract Task ReadDefinitionsToRepository(IEnumerable<DefinitionsEnum> definitionsToLoad);
        public abstract ValueTask<T> LoadDefinition<T>(uint hash, BungieLocales locale) where T : IDestinyDefinition;
        public abstract ValueTask<string> ReadDefinitionAsJson(DefinitionsEnum enumValue, uint hash, BungieLocales locale);
        public abstract ValueTask<ReadOnlyCollection<T>> LoadMultipleDefinitions<T>(uint[] hashes, BungieLocales locale)
            where T : IDestinyDefinition;
        public abstract ValueTask<DestinyHistoricalStatsDefinition> LoadHistoricalStatsDefinition(string id,
            BungieLocales locale);
        public abstract ValueTask<string> LoadHistoricalStatsDefinitionAsJson(string id, BungieLocales locale);
        public abstract ValueTask<ReadOnlyCollection<T>> LoadAllDefinitions<T>(BungieLocales locale)
            where T : IDestinyDefinition;
        public abstract ValueTask<IEnumerable<DestinyManifest>> GetAvailableManifests();
        public abstract ValueTask<DestinyManifest> GetCurrentManifest();
        public abstract ValueTask<bool> CheckForUpdates();
        public abstract Task Update();
        public abstract Task DownloadNewManifestData(DestinyManifest manifestData);
        public abstract Task DeleteOldManifestData();
        public abstract Task DeleteManifestData(DestinyManifest manifestData);
        public abstract ValueTask<bool> CheckExistingManifestData(string version);
    }
}