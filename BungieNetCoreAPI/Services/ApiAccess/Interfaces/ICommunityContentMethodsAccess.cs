using NetBungieAPI.Models.Forum;
using NetBungieAPI.Models.Queries;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface ICommunityContentMethodsAccess
    {
        Task<BungieResponse<PostSearchResponse>> GetCommunityContent(ForumTopicsSortEnum sort, ForumMediaType mediaFilter, int page = 0);
    }
}
