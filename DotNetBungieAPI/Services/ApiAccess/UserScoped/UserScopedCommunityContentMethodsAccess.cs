using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Forum;
using DotNetBungieAPI.Models.Queries;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetBungieAPI.Services.ApiAccess.UserScoped
{
    public sealed class UserScopedCommunityContentMethodsAccess
    {
        private readonly ICommunityContentMethodsAccess _apiAccess;

        internal UserScopedCommunityContentMethodsAccess(
            ICommunityContentMethodsAccess apiAccess)
        {
            _apiAccess = apiAccess;
        }

        public async ValueTask<BungieResponse<PostSearchResponse>> GetCommunityContent(
            ForumTopicsSortEnum sort,
            ForumMediaType mediaFilter,
            int page = 0,
            CancellationToken token = default)
        {
            return await _apiAccess.GetCommunityContent(sort, mediaFilter, page, token);
        }
    }
}