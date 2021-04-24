using NetBungieAPI.Models;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Models.Trending;
using System.Threading;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface ITrendingMethodsAccess
    {
        /// <summary>
        /// Returns trending items for Bungie.net, collapsed into the first page of items per category. For pagination within a category, call GetTrendingCategory.
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<TrendingCategories>> GetTrendingCategories(CancellationToken token = default);

        /// <summary>
        /// Returns paginated lists of trending items for a category.
        /// </summary>
        /// <param name="categoryId">The ID of the category for whom you want additional results.</param>
        /// <param name="pageNumber">The page # of results to return.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<SearchResultOfTrendingEntry>> GetTrendingCategory(string categoryId,
            int pageNumber = 0, CancellationToken token = default);

        /// <summary>
        /// Returns the detailed results for a specific trending entry. Note that trending entries are uniquely identified by a combination of *both* the TrendingEntryType *and* the identifier: the identifier alone is not guaranteed to be globally unique.
        /// </summary>
        /// <param name="trendingEntryType">The type of entity to be returned.</param>
        /// <param name="identifier">The identifier for the entity to be returned.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<TrendingDetail>> GetTrendingEntryDetail(TrendingEntryType trendingEntryType,
            string identifier, CancellationToken token = default);
    }
}