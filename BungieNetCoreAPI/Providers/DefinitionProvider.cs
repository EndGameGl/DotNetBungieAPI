using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Config;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Providers
{
    public abstract class DefinitionProvider
    {
        protected readonly IJsonSerializationHelper SerializationHelper =
            StaticUnityContainer.GetService<IJsonSerializationHelper>();

        protected readonly IDefinitionAssemblyData AssemblyData = StaticUnityContainer.GetAssemblyData();

        protected readonly ILocalisedDestinyDefinitionRepositories Repositories =
            StaticUnityContainer.GetDestinyDefinitionRepositories();

        protected BungieLocales[] Locales = Array.Empty<BungieLocales>();
        protected string ManifestPath = string.Empty;
        protected DestinyManifest UsedManifest { get; private set; } = null;
        protected ReadOnlyCollection<DefinitionsEnum> DefinitionsToLoad = Defaults.EmptyReadOnlyCollection<DefinitionsEnum>();

        internal async Task InternalOnLoad(IConfigurationService configurationService)
        {
            var assemblyData = StaticUnityContainer.GetAssemblyData();

            DefinitionsToLoad = new ReadOnlyCollection<DefinitionsEnum>(configurationService.Settings.DefinitionLoadingSettings.AllowedDefinitions);
            
            Locales = configurationService.Settings.DefinitionLoadingSettings.Locales;
            ManifestPath = configurationService.Settings.LocalFileSettings.VersionsRepositoryPath;
            var manifestUpdater = StaticUnityContainer.GetManifestUpdateHandler();
            var result = await manifestUpdater.HasUpdates();
            UsedManifest = manifestUpdater.CurrentUsedManifest;
        }

        public abstract Task OnLoad();

        public abstract Task ReadDefinitionsToRepository(IEnumerable<DefinitionsEnum> definitionsToLoad);

        public abstract Task<T> LoadDefinition<T>(uint hash, BungieLocales locale) where T : IDestinyDefinition;

        public abstract Task<string> ReadDefinitionAsJson(DefinitionsEnum enumValue, uint hash, BungieLocales locale);

        public abstract Task<ReadOnlyCollection<T>> LoadMultipleDefinitions<T>(uint[] hashes, BungieLocales locale)
            where T : IDestinyDefinition;

        public abstract Task<DestinyHistoricalStatsDefinition> LoadHistoricalStatsDefinition(string id,
            BungieLocales locale);

        public abstract Task<string> LoadHistoricalStatsDefinitionAsJson(string id, BungieLocales locale);

        public abstract Task<ReadOnlyCollection<T>> LoadAllDefinitions<T>(BungieLocales locale)
            where T : IDestinyDefinition;
    }
}