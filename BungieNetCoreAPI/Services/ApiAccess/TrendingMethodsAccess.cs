using NetBungieAPI.Models.Queries;
using NetBungieAPI.Models.Trending;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess
{
    public class TrendingMethodsAccess : ITrendingMethodsAccess
    {
        private IHttpClientInstance _httpClient;
        internal TrendingMethodsAccess(IHttpClientInstance httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Returns trending items for Bungie.net, collapsed into the first page of items per category. For pagination within a category, call GetTrendingCategory.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<TrendingCategories>> GetTrendingCategories(CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<TrendingCategories>("/Trending/Categories/", token);
        }
        public async ValueTask<BungieResponse<SearchResultOfTrendingEntry>> GetTrendingCategory(string categoryId, int pageNumber = 0, CancellationToken token = default)
        {
            var url = StringBuilderPool.GetBuilder().Append("/Trending/Categories/").Append(categoryId).Append('/').Append(pageNumber).ToString();
            return await _httpClient.GetFromBungieNetPlatform<SearchResultOfTrendingEntry>(url, token);
        }
        public async ValueTask<BungieResponse<TrendingDetail>> GetTrendingEntryDetail(TrendingEntryType trendingEntryType, string identifier, CancellationToken token = default)
        {
            var url = StringBuilderPool.GetBuilder().Append("/Trending/Details/").Append((int)trendingEntryType).Append('/').Append(identifier).ToString();
            return await _httpClient.GetFromBungieNetPlatform<TrendingDetail>(url, token);
        }

    }
}
