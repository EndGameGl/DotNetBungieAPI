using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface IForumApi
{
    Task<BungieResponse<Models.Forum.PostSearchResponse>> GetTopicsPaged(
        Models.Forum.ForumTopicsCategoryFiltersEnum categoryFilter,
        long group,
        int page,
        int pageSize,
        Models.Forum.ForumTopicsQuickDateEnum quickDate,
        Models.Forum.ForumTopicsSortEnum sort,
        string locales,
        string tagstring,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Forum.PostSearchResponse>> GetCoreTopicsPaged(
        Models.Forum.ForumTopicsCategoryFiltersEnum categoryFilter,
        int page,
        Models.Forum.ForumTopicsQuickDateEnum quickDate,
        Models.Forum.ForumTopicsSortEnum sort,
        string locales,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Forum.PostSearchResponse>> GetPostsThreadedPaged(
        bool getParentPost,
        int page,
        int pageSize,
        long parentPostId,
        int replySize,
        bool rootThreadMode,
        Models.Forum.ForumPostSortEnum sortMode,
        string showbanned,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Forum.PostSearchResponse>> GetPostsThreadedPagedFromChild(
        long childPostId,
        int page,
        int pageSize,
        int replySize,
        bool rootThreadMode,
        Models.Forum.ForumPostSortEnum sortMode,
        string showbanned,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Forum.PostSearchResponse>> GetPostAndParent(
        long childPostId,
        string showbanned,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Forum.PostSearchResponse>> GetPostAndParentAwaitingApproval(
        long childPostId,
        string showbanned,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<long>> GetTopicForContent(
        long contentId,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Tags.Models.Contracts.TagResponse[]>> GetForumTagSuggestions(
        string partialtag,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Forum.PostSearchResponse>> GetPoll(
        long topicId,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Forum.ForumRecruitmentDetail[]>> GetRecruitmentThreadSummaries(
        long[] requestBody,
        CancellationToken cancellationToken = default
    );

}
