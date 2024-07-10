using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Models.Destiny.Config;
using DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using DotNetBungieAPI.Models.Destiny.Rendering;
using DotNetBungieAPI.Service.Abstractions;

namespace DotNetBungieAPI.Services.Implementations;

internal class NullDefinitionProvider : IDefinitionProvider
{
    private const string ErrorMessage =
        "You're seeing this message if you tried to do something related to definitions and haven't specified any definition providers";

    public NullDefinitionProvider() { }

    public Task ChangeManifestVersion(string version)
    {
        throw new NotImplementedException(ErrorMessage);
    }

    public ValueTask<bool> CheckExistingManifestData(string version)
    {
        throw new NotImplementedException(ErrorMessage);
    }

    public ValueTask<bool> CheckForUpdates()
    {
        throw new NotImplementedException(ErrorMessage);
    }

    public Task DeleteManifestData(string version)
    {
        throw new NotImplementedException(ErrorMessage);
    }

    public Task DeleteOldManifestData()
    {
        throw new NotImplementedException(ErrorMessage);
    }

    public void Dispose() { }

    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }

    public Task DownloadManifestData(DestinyManifest manifestData)
    {
        throw new NotImplementedException(ErrorMessage);
    }

    public ValueTask<IEnumerable<DestinyManifest>> GetAvailableManifests()
    {
        throw new NotImplementedException(ErrorMessage);
    }

    public ValueTask<DestinyManifest> GetCurrentManifest()
    {
        throw new NotImplementedException(ErrorMessage);
    }

    public ValueTask<DestinyGearAssetDefinition> GetGearAssetDefinition(uint itemHash)
    {
        throw new NotImplementedException(ErrorMessage);
    }

    public Task Initialize()
    {
        throw new NotImplementedException(ErrorMessage);
    }

    public ValueTask<T> LoadDefinition<T>(uint hash, BungieLocales locale)
        where T : IDestinyDefinition
    {
        throw new NotImplementedException(ErrorMessage);
    }

    public ValueTask<DestinyHistoricalStatsDefinition> LoadHistoricalStatsDefinition(
        string id,
        BungieLocales locale
    )
    {
        throw new NotImplementedException(ErrorMessage);
    }

    public ValueTask<string> ReadDefinitionRaw(
        DefinitionsEnum enumValue,
        uint hash,
        BungieLocales locale
    )
    {
        throw new NotImplementedException(ErrorMessage);
    }

    public ValueTask<string> ReadHistoricalStatsDefinitionRaw(string id, BungieLocales locale)
    {
        throw new NotImplementedException(ErrorMessage);
    }

    public ValueTask ReadToRepository(IDestiny2DefinitionRepository repository)
    {
        throw new NotImplementedException(ErrorMessage);
    }

    public Task Update()
    {
        throw new NotImplementedException(ErrorMessage);
    }
}
