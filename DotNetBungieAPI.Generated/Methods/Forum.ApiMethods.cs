using DotNetBungieAPI.Generated.Models;

namespace DotNetBungieAPI.Generated.Methods;

public interface IForumApi
{
    Task<ApiResponse<Models.Forum.PostSearchResponse>> GetTopicsPaged(
        Models.Forum.ForumTopicsCategoryFiltersEnum categoryFilter,
        long group,
        int page,
        int pageSize,
        Models.Forum.ForumTopicsQuickDateEnum quickDate,
        Models.Forum.ForumTopicsSortEnum sort,
        string locales,
        string tagstring
    );

    Task<ApiResponse<Models.Forum.PostSearchResponse>> GetCoreTopicsPaged(
        Models.Forum.ForumTopicsCategoryFiltersEnum categoryFilter,
        int page,
        Models.Forum.ForumTopicsQuickDateEnum quickDate,
        Models.Forum.ForumTopicsSortEnum sort,
        string locales
    );

    Task<ApiResponse<Models.Forum.PostSearchResponse>> GetPostsThreadedPaged(
        bool getParentPost,
        int page,
        int pageSize,
        long parentPostId,
        int replySize,
        bool rootThreadMode,
        Models.Forum.ForumPostSortEnum sortMode,
        string showbanned
    );

    Task<ApiResponse<Models.Forum.PostSearchResponse>> GetPostsThreadedPagedFromChild(
        long childPostId,
        int page,
        int pageSize,
        int replySize,
        bool rootThreadMode,
        Models.Forum.ForumPostSortEnum sortMode,
        string showbanned
    );

    Task<ApiResponse<Models.Forum.PostSearchResponse>> GetPostAndParent(
        long childPostId,
        string showbanned
    );

    Task<ApiResponse<Models.Forum.PostSearchResponse>> GetPostAndParentAwaitingApproval(
        long childPostId,
        string showbanned
    );

    Task<ApiResponse<long>> GetTopicForContent(
        long contentId
    );

    Task<ApiResponse<Models.Tags.Models.Contracts.TagResponse[]>> GetForumTagSuggestions(
        string partialtag
    );

    Task<ApiResponse<Models.Forum.PostSearchResponse>> GetPoll(
        long topicId
    );

    Task<ApiResponse<Models.Forum.ForumRecruitmentDetail[]>> GetRecruitmentThreadSummaries(
        long[] body
    );

}
