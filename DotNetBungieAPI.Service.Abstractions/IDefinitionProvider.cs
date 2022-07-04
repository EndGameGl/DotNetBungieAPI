using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Models.Destiny.Config;
using DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using DotNetBungieAPI.Models.Destiny.Rendering;

namespace DotNetBungieAPI.Service.Abstractions;

/// <summary>
///     Common interface for Destiny 2 definition provider
/// </summary>
public interface IDefinitionProvider : IDisposable, IAsyncDisposable
{
    /// <summary>
    ///     Uses provider to load <see cref="IDestinyDefinition" />
    /// </summary>
    /// <typeparam name="T">Any class that inherits IDestinyDefinition</typeparam>
    /// <param name="hash">Definition hash</param>
    /// <param name="locale">Definition locale</param>
    /// <returns></returns>
    ValueTask<T> LoadDefinition<T>(uint hash, BungieLocales locale) where T : IDestinyDefinition;

    /// <summary>
    ///     Uses provider to load <see cref="DestinyHistoricalStatsDefinition" />
    /// </summary>
    /// <param name="id">Definition id</param>
    /// <param name="locale">Definition locale</param>
    /// <returns></returns>
    ValueTask<DestinyHistoricalStatsDefinition> LoadHistoricalStatsDefinition(string id,
        BungieLocales locale);

    /// <summary>
    ///     Uses provider to load raw definition (JSON string)
    /// </summary>
    /// <param name="enumValue">Definition type</param>
    /// <param name="hash">Definition hash</param>
    /// <param name="locale">Definition locale</param>
    /// <returns></returns>
    ValueTask<string> ReadDefinitionRaw(DefinitionsEnum enumValue, uint hash, BungieLocales locale);

    /// <summary>
    ///     Uses provider to load raw historical stat definition
    /// </summary>
    /// <param name="id">Definition id</param>
    /// <param name="locale">Definition locale</param>
    /// <returns></returns>
    ValueTask<string> ReadHistoricalStatsDefinitionRaw(string id, BungieLocales locale);

    /// <summary>
    ///     Gets all available manifests for current provider
    /// </summary>
    /// <returns></returns>
    ValueTask<IEnumerable<DestinyManifest>> GetAvailableManifests();

    /// <summary>
    ///     Gets current used manifest
    /// </summary>
    /// <returns></returns>
    ValueTask<DestinyManifest> GetCurrentManifest();

    /// <summary>
    ///     Check for manifest updates
    /// </summary>
    /// <returns></returns>
    ValueTask<bool> CheckForUpdates();

    /// <summary>
    ///     Updates manifest files
    /// </summary>
    /// <returns></returns>
    Task Update();

    /// <summary>
    ///     Deletes all manifest files but the latest one
    /// </summary>
    /// <returns></returns>
    Task DeleteOldManifestData();

    /// <summary>
    ///     Deletes specifies manifest data
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    Task DeleteManifestData(string version);

    /// <summary>
    ///     Checks whether specified manifest files are present
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    ValueTask<bool> CheckExistingManifestData(string version);

    /// <summary>
    ///     Downloads manifest files
    /// </summary>
    /// <param name="manifestData">Manifest to download</param>
    /// <returns></returns>
    Task DownloadManifestData(DestinyManifest manifestData);

    /// <summary>
    ///     Initializes this provider instance
    /// </summary>
    /// <returns></returns>
    Task Initialize();

    /// <summary>
    ///     Reloads manifest to other version
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    Task ChangeManifestVersion(string version);

    /// <summary>
    ///     Reads all provider data to repository
    /// </summary>
    /// <param name="repository"></param>
    /// <returns></returns>
    ValueTask ReadToRepository(IDestiny2DefinitionRepository repository);

    ValueTask<DestinyGearAssetDefinition> GetGearAssetDefinition(uint itemHash);
}