using DotNetBungieAPI.Generated.Models;

namespace DotNetBungieAPI.Generated.Methods;

public interface ICommunityContentApi
{
    Task<ApiResponse<Models.Forum.PostSearchResponse>> GetCommunityContent(
        Models.Forum.ForumTopicsCategoryFiltersEnum mediaFilter,
        int page,
        Models.Forum.CommunityContentSortMode sort
    );

}
