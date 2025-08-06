using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface ICommunityContentApi
{
    Task<BungieResponse<Models.Forum.PostSearchResponse>> GetCommunityContent(
        Models.Forum.ForumTopicsCategoryFiltersEnum mediaFilter,
        int page,
        Models.Forum.CommunityContentSortMode sort,
        CancellationToken cancellationToken = default
    );

}
