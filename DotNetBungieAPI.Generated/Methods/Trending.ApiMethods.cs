using DotNetBungieAPI.Generated.Models;

namespace DotNetBungieAPI.Generated.Methods;

public interface ITrendingApi
{
    Task<ApiResponse<Models.Trending.TrendingCategories>> GetTrendingCategories();

    Task<ApiResponse<Models.SearchResultOfTrendingEntry>> GetTrendingCategory(
        string categoryId,
        int pageNumber
    );

    Task<ApiResponse<Models.Trending.TrendingDetail>> GetTrendingEntryDetail(
        string identifier,
        Models.Trending.TrendingEntryType trendingEntryType
    );

}
