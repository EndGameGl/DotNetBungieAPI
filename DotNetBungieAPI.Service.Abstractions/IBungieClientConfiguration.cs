using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;

namespace DotNetBungieAPI.Service.Abstractions;

public interface IBungieClientConfiguration
{
    string ApiKey { get; set; }
    int ClientId { get; set; }
    string ClientSecret { get; set; }
    ApplicationScopes ApplicationScopes { get; set; }
    bool CacheDefinitions { get; set; }
    List<BungieLocales> UsedLocales { get; }
    bool HasSufficientRights(ApplicationScopes scopes);
}