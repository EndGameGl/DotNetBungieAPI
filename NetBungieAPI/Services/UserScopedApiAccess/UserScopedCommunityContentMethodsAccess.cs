using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Forum;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Services.ApiAccess.Interfaces;

namespace NetBungieAPI.Services.UserScopedApiAccess
{
    public class UserScopedCommunityContentMethodsAccess
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