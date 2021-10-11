using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Models.Destiny.Config;
using DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;

namespace DotNetBungieAPI.Services.Interfaces
{
    public interface IDefinitionProvider : IDisposable, IAsyncDisposable
    {
        ValueTask<T> LoadDefinition<T>(uint hash, BungieLocales locale) where T : IDestinyDefinition;

        ValueTask<DestinyHistoricalStatsDefinition> LoadHistoricalStatsDefinition(string id,
            BungieLocales locale);

        ValueTask<string> ReadDefinitionAsJson(DefinitionsEnum enumValue, uint hash, BungieLocales locale);
        ValueTask<string> LoadHistoricalStatsDefinitionAsJson(string id, BungieLocales locale);

        ValueTask<IEnumerable<DestinyManifest>> GetAvailableManifests();
        ValueTask<DestinyManifest> GetCurrentManifest();
        ValueTask<bool> CheckForUpdates();
        Task Update();
        Task DeleteOldManifestData();
        Task DeleteManifestData(string version);
        ValueTask<bool> CheckExistingManifestData(string version);
        Task DownloadManifestData(DestinyManifest manifestData);
        Task Initialize();
        Task ChangeManifestVersion(string version);
        Task ReadToRepository(IDestiny2DefinitionRepository repository);
    }
}