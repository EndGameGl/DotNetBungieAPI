namespace DotNetBungieAPI.Generated.Models;

public interface ICommunityContentApi
{
    Task<ApiResponse<Forum.PostSearchResponse>> GetCommunityContent(
        Forum.ForumTopicsCategoryFiltersEnum mediaFilter,
        int page,
        Forum.CommunityContentSortMode sort
    );

}
