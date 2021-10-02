using System.Collections.Generic;
using System.Threading.Tasks;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Config;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IDefinitionProvider
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