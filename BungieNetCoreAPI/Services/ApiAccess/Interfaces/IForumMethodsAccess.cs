using NetBungieAPI.Forum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IForumMethodsAccess
    {
        Task<BungieResponse<PostSearchResponse>> GetTopicsPaged(ForumPostCategoryEnums categoryFilter, ForumTopicsQuickDateEnum quickDate, ForumTopicsSortEnum sort, long group, int pageSize = 0, int page = 0, string tagstring = null, DestinyLocales[] locales = null);
    }
}
