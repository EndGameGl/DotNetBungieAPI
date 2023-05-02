namespace DotNetBungieAPI.Generated.Models;

public interface IForumApi
{
    Task<ApiResponse<Forum.PostSearchResponse>> GetTopicsPaged(
        Forum.ForumTopicsCategoryFiltersEnum categoryFilter,
        long group,
        int page,
        int pageSize,
        Forum.ForumTopicsQuickDateEnum quickDate,
        Forum.ForumTopicsSortEnum sort,
        string locales,
        string tagstring
    );

    Task<ApiResponse<Forum.PostSearchResponse>> GetCoreTopicsPaged(
        Forum.ForumTopicsCategoryFiltersEnum categoryFilter,
        int page,
        Forum.ForumTopicsQuickDateEnum quickDate,
        Forum.ForumTopicsSortEnum sort,
        string locales
    );

    Task<ApiResponse<Forum.PostSearchResponse>> GetPostsThreadedPaged(
        bool getParentPost,
        int page,
        int pageSize,
        long parentPostId,
        int replySize,
        bool rootThreadMode,
        Forum.ForumPostSortEnum sortMode,
        string showbanned
    );

    Task<ApiResponse<Forum.PostSearchResponse>> GetPostsThreadedPagedFromChild(
        long childPostId,
        int page,
        int pageSize,
        int replySize,
        bool rootThreadMode,
        Forum.ForumPostSortEnum sortMode,
        string showbanned
    );

    Task<ApiResponse<Forum.PostSearchResponse>> GetPostAndParent(
        long childPostId,
        string showbanned
    );

    Task<ApiResponse<Forum.PostSearchResponse>> GetPostAndParentAwaitingApproval(
        long childPostId,
        string showbanned
    );

    Task<ApiResponse<long>> GetTopicForContent(
        long contentId
    );

    Task<ApiResponse<List<Tags.Models.Contracts.TagResponse>>> GetForumTagSuggestions(
        string partialtag
    );

    Task<ApiResponse<Forum.PostSearchResponse>> GetPoll(
        long topicId
    );

    Task<ApiResponse<List<Forum.ForumRecruitmentDetail>>> GetRecruitmentThreadSummaries(
        List<long> body
    );

}
