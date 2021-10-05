using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Authorization;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Queries;
using DotNetBungieAPI.Models.Trending;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;

namespace DotNetBungieAPI.Services.ApiAccess.UserScoped
{
    public sealed class UserScopedTrendingMethodsAccess
    {
        private readonly ITrendingMethodsAccess _apiAccess;
        private AuthorizationTokenData _token;

        internal UserScopedTrendingMethodsAccess(
            ITrendingMethodsAccess apiAccess,
            AuthorizationTokenData token)
        {
            _apiAccess = apiAccess;
            _token = token;
        }

        public async ValueTask<BungieResponse<TrendingCategories>> GetTrendingCategories(
            CancellationToken token = default)
        {
            return await _apiAccess.GetTrendingCategories(token);
        }

        public async ValueTask<BungieResponse<SearchResultOfTrendingEntry>> GetTrendingCategory(
            string categoryId,
            int pageNumber = 0,
            CancellationToken token = default)
        {
            return await _apiAccess.GetTrendingCategory(categoryId, pageNumber, token);
        }

        public async ValueTask<BungieResponse<TrendingDetail>> GetTrendingEntryDetail(
            TrendingEntryType trendingEntryType,
            string identifier,
            CancellationToken token = default)
        {
            return await _apiAccess.GetTrendingEntryDetail(trendingEntryType, identifier, token);
        }
    }
}