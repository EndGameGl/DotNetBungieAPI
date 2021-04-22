using System.Threading;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Forum;
using NetBungieAPI.Models.Queries;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface ICommunityContentMethodsAccess
    {
        ValueTask<BungieResponse<PostSearchResponse>> GetCommunityContent(ForumTopicsSortEnum sort,
            ForumMediaType mediaFilter, int page = 0, CancellationToken token = default);
    }
}