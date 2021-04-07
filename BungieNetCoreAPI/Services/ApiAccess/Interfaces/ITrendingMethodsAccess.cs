using NetBungieAPI.Models.Trending;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface ITrendingMethodsAccess
    {
        Task<BungieResponse<TrendingCategories>> GetTrendingCategories();
        Task<BungieResponse<SearchResult<TrendingEntry>>> GetTrendingCategory(string categoryId, int pageNumber = 0);
        Task<BungieResponse<TrendingDetail>> GetTrendingEntryDetail(TrendingEntryType trendingEntryType, string identifier);
    }
}
