using NetBungieAPI.Models;
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
        public async ValueTask<BungieResponse<TrendingCategories>> GetTrendingCategories(
            CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<TrendingCategories>("/Trending/Categories/", token);
        }
        public async ValueTask<BungieResponse<SearchResultOfTrendingEntry>> GetTrendingCategory(
            string categoryId, 
            int pageNumber = 0, 
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Trending/Categories/")
                .AddUrlParam(categoryId)
                .AddUrlParam(pageNumber.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<SearchResultOfTrendingEntry>(url, token);
        }
        public async ValueTask<BungieResponse<TrendingDetail>> GetTrendingEntryDetail(
            TrendingEntryType trendingEntryType, 
            string identifier, 
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Trending/Details/")
                .AddUrlParam(((int)trendingEntryType).ToString())
                .AddUrlParam(identifier)
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<TrendingDetail>(url, token);
        }

    }
}
