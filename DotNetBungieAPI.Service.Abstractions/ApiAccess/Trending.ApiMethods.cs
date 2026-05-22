using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface ITrendingApi
{
    Task<BungieResponse<Models.Trending.TrendingCategories>> GetTrendingCategories(AuthorizationTokenData? authorizationToken = null, CancellationToken cancellationToken = default);

    Task<BungieResponse<Models.SearchResultOfTrendingEntry>> GetTrendingCategory(
        string categoryId,
        int pageNumber,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Trending.TrendingDetail>> GetTrendingEntryDetail(
        string identifier,
        Models.Trending.TrendingEntryType trendingEntryType,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

}
