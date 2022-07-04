using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Service.Abstractions;

namespace DotNetBungieAPI.Clients;

public sealed class BungieClientConfiguration : IBungieClientConfiguration
{

    private string _apiKey;
    private int _clientId;
    private string _clientSecret;

    public BungieClientConfiguration()
    {
        
    }

    /// <summary>
    ///     Application API key. You can find one at https://www.bungie.net/en/Application.
    /// </summary>
    public string ApiKey
    {
        get => _apiKey;
        set => _apiKey = Conditions.NotNullOrWhiteSpace(value);
    }

    /// <summary>
    ///     Application OAuth client ID. You can find one at https://www.bungie.net/en/Application.
    /// </summary>
    public int ClientId
    {
        get => _clientId;
        set => _clientId = Conditions.Int32MoreThan(value, 0);
    }

    /// <summary>
    ///     Application OAuth client secret. You can find one at https://www.bungie.net/en/Application.
    /// </summary>
    public string ClientSecret
    {
        get => _clientSecret;
        set => _clientSecret = Conditions.NotNullOrWhiteSpace(value);
    }

    /// <summary>
    ///     Only specified scope API operations will be allowed to run in this app.
    /// </summary>
    public ApplicationScopes ApplicationScopes { get; set; }

    /// <summary>
    ///     Caches definitions to repository if not present currently after fetching from provider.
    /// </summary>
    public bool CacheDefinitions { get; set; }
    
    /// <summary>
    ///     Locales that'll be used in this app
    /// </summary>
    public List<BungieLocales> UsedLocales { get; } = new();

    /// <summary>
    ///     Checks whether scope is available for this app
    /// </summary>
    /// <param name="applicationScope"></param>
    /// <returns></returns>
    public bool HasSufficientRights(ApplicationScopes applicationScope)
    {
        return ApplicationScopes.HasFlag(applicationScope);
    }
}