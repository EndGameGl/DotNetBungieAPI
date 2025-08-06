using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface ITrendingApi
{
    Task<BungieResponse<Models.Trending.TrendingCategories>> GetTrendingCategories(CancellationToken cancellationToken = default);

    Task<BungieResponse<Models.SearchResultOfTrendingEntry>> GetTrendingCategory(
        string categoryId,
        int pageNumber,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Trending.TrendingDetail>> GetTrendingEntryDetail(
        string identifier,
        Models.Trending.TrendingEntryType trendingEntryType,
        CancellationToken cancellationToken = default
    );

}
