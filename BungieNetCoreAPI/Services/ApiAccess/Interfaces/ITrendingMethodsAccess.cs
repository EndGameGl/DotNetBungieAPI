using NetBungieAPI.Models;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Models.Trending;
using System.Threading;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface ITrendingMethodsAccess
    {
        ValueTask<BungieResponse<TrendingCategories>> GetTrendingCategories(CancellationToken token = default);
        ValueTask<BungieResponse<SearchResultOfTrendingEntry>> GetTrendingCategory(string categoryId, int pageNumber = 0, CancellationToken token = default);
        ValueTask<BungieResponse<TrendingDetail>> GetTrendingEntryDetail(TrendingEntryType trendingEntryType, string identifier, CancellationToken token = default);
    }
}
