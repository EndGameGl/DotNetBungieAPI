using System.Threading.Tasks;
using DotNetBungieAPI.Authorization;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using DotNetBungieAPI.Services.Interfaces;

namespace DotNetBungieAPI.Clients;

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
    IAuthorizationHandler Authentication { get; }

    /// <summary>
    ///     Access to <see cref="IDefinitionProvider"/>, which helps to retrieve definitions from external source
    /// </summary>
    IDefinitionProvider DefinitionProvider { get; }
    
    /// <summary>
    ///     Access to service, which resolves when next Destiny 2 reset will occur
    /// </summary>
    IDestiny2ResetService ResetService { get; }

    /// <summary>
    ///     Creates a scoped user client, that doesn't need user to pass token manually
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    IUserContextBungieClient ScopeToUser(AuthorizationTokenData token);

    /// <summary>
    ///     Tries to get definition async from all available sources
    /// </summary>
    /// <param name="hash"></param>
    /// <param name="locale"></param>
    /// <param name="success"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    ValueTask<bool> TryGetDefinitionAsync<T>(uint hash, BungieLocales locale, Action<T> success)
        where T : IDestinyDefinition;

    bool TryGetDefinition<T>(uint hash, BungieLocales locale, out T definition) where T : IDestinyDefinition;

    ValueTask<bool> TryGetHistoricalStatDefinitionAsync(string key, BungieLocales locale,
        Action<DestinyHistoricalStatsDefinition> success);

    bool TryGetHistoricalStatDefinition(string key, BungieLocales locale,
        out DestinyHistoricalStatsDefinition definition);
}