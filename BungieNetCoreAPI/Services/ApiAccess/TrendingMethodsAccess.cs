using NetBungieAPI.Models.Trending;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
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
        public async Task<BungieResponse<TrendingCategories>> GetTrendingCategories()
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<TrendingCategories>>($"/Trending/Categories/");
        }
        public async Task<BungieResponse<SearchResult<TrendingEntry>>> GetTrendingCategory(string categoryId, int pageNumber = 0)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<SearchResult<TrendingEntry>>>($"/Trending/Categories/{categoryId}/{pageNumber}/");
        }
        public async Task<BungieResponse<TrendingDetail>> GetTrendingEntryDetail(TrendingEntryType trendingEntryType, string identifier)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<TrendingDetail>>($"/Trending/Details/{trendingEntryType}/{identifier}/");
        }

    }
}
