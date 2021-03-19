using NetBungieAPI.Forum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface ICommunityContentMethodsAccess
    {
        Task<BungieResponse<PostSearchResponse>> GetCommunityContent(ForumTopicsSortEnum sort, ForumMediaType mediaFilter, int page = 0);
    }
}
