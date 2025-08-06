using System.Diagnostics.CodeAnalysis;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny.HistoricalStats.Definitions;

namespace DotNetBungieAPI.Service.Abstractions;

/// <summary>
///     Interface for bungie.net API client
/// </summary>
public interface IBungieClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    ///     Access to all API methods
    /// </summary>
    IBungieApiAccess ApiAccess { get; }

    /// <summary>
    ///     Access to in-memory definition repository
    /// </summary>
    IDestiny2DefinitionRepository Repository { get; }

    /// <summary>
    ///     Access to OAuth2 methods
    /// </summary>
    IAuthorizationHandler Authorization { get; }

    /// <summary>
    ///     Access to internal serializer with custom converters
    /// </summary>
    IBungieNetJsonSerializer Serializer { get; }

    /// <summary>
    ///     Access to internal api http client
    /// </summary>
    IDotNetBungieApiHttpClient ApiHttpClient { get; }

    /// <summary>
    ///     Access to <see cref="IDefinitionProvider"/>, which helps to retrieve definitions from external source
    /// </summary>
    IDefinitionProvider DefinitionProvider { get; }

    /// <summary>
    ///     Access to service, which resolves when next Destiny 2 reset will occur
    /// </summary>
    IDestiny2ResetService ResetService { get; }

    /// <summary>
    ///     Tries to get definition from all available sources async
    /// </summary>
    /// <param name="hash"></param>
    /// <param name="locale"></param>
    /// <param name="success"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    ValueTask<bool> TryGetDefinitionAsync<T>(uint hash, Action<T> success, BungieLocales locale = BungieLocales.EN)
        where T : class, IDestinyDefinition;

    /// <summary>
    ///     Tries to get definition from all available sources
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="hash"></param>
    /// <param name="definition"></param>
    /// <param name="locale"></param>
    /// <returns></returns>
    bool TryGetDefinition<T>(uint hash, [NotNullWhen(true)] out T? definition, BungieLocales locale = BungieLocales.EN)
        where T : class, IDestinyDefinition;

    /// <summary>
    ///     Tries to get DestinyHistoricalStatsDefinition from all available sources async
    /// </summary>
    /// <param name="key"></param>
    /// <param name="locale"></param>
    /// <param name="success"></param>
    /// <returns></returns>
    ValueTask<bool> TryGetHistoricalStatDefinitionAsync(string key, Action<DestinyHistoricalStatsDefinition> success, BungieLocales locale = BungieLocales.EN);

    /// <summary>
    ///     Tries to get DestinyHistoricalStatsDefinition from all available sources
    /// </summary>
    /// <param name="key"></param>
    /// <param name="locale"></param>
    /// <param name="definition"></param>
    /// <returns></returns>
    bool TryGetHistoricalStatDefinition(string key, [NotNullWhen(true)] out DestinyHistoricalStatsDefinition? definition, BungieLocales locale = BungieLocales.EN);
}
