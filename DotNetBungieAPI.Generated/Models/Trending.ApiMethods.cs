namespace DotNetBungieAPI.Generated.Models;

public interface ITrendingApi
{
    Task<ApiResponse<Trending.TrendingCategories>> GetTrendingCategories();

    Task<ApiResponse<SearchResultOfTrendingEntry>> GetTrendingCategory(
        string categoryId,
        int pageNumber
    );

    Task<ApiResponse<Trending.TrendingDetail>> GetTrendingEntryDetail(
        string identifier,
        Trending.TrendingEntryType trendingEntryType
    );

}
