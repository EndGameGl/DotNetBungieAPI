using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;

namespace DotNetBungieAPI.Service.Abstractions;

/// <summary>
///     Bungie client configuration
/// </summary>
public interface IBungieClientConfiguration
{
    /// <summary>
    ///     Bungie.net API key
    /// </summary>
    string ApiKey { get; set; }

    /// <summary>
    ///     Bungie.net Client Id
    /// </summary>
    int ClientId { get; set; }

    /// <summary>
    ///     Bungie.net Client secret
    /// </summary>
    string ClientSecret { get; set; }

    /// <summary>
    ///     Application scopes, prevents some actions that should not happen with current scopes
    /// </summary>
    ApplicationScopes ApplicationScopes { get; set; }

    /// <summary>
    ///     Whether definitions should be automatically stored when fetched from db
    /// </summary>
    bool CacheDefinitions { get; set; }

    /// <summary>
    ///     List of available locales
    /// </summary>
    List<BungieLocales> UsedLocales { get; }

    /// <summary>
    ///     Checks whether scope is matching
    /// </summary>
    /// <param name="scopes"></param>
    /// <returns></returns>
    bool HasSufficientRights(ApplicationScopes scopes);

    /// <summary>
    ///     Whether client would attempt to find missing definitions with provider
    /// </summary>
    bool TryFetchDefinitionsFromProvider { get; set; }
}
