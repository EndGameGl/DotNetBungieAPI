using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Models.Trending;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services.ApiAccess
{
    /// <summary>
    /// <inheritdoc cref="ITrendingMethodsAccess"/>
    /// </summary>
    public class TrendingMethodsAccess : ITrendingMethodsAccess
    {
        private readonly IHttpClientInstance _httpClient;

        internal TrendingMethodsAccess(IHttpClientInstance httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask<BungieResponse<TrendingCategories>> GetTrendingCategories(
            CancellationToken cancellationToken = default)
        {
            return await _httpClient
                .GetFromBungieNetPlatform<TrendingCategories>("/Trending/Categories/", cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<SearchResultOfTrendingEntry>> GetTrendingCategory(
            string categoryId,
            int pageNumber = 0,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Trending/Categories/")
                .AddUrlParam(categoryId)
                .AddUrlParam(pageNumber.ToString())
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<SearchResultOfTrendingEntry>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<TrendingDetail>> GetTrendingEntryDetail(
            TrendingEntryType trendingEntryType,
            string identifier,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Trending/Details/")
                .AddUrlParam(((int)trendingEntryType).ToString())
                .AddUrlParam(identifier)
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<TrendingDetail>(url, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}