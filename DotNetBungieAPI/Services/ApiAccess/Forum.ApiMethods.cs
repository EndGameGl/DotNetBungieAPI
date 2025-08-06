using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Models.Exceptions;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;

namespace DotNetBungieAPI.Services.ApiAccess;

internal sealed class ForumApi : IForumApi
{
    private readonly IBungieClientConfiguration _configuration;
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;
    private readonly IBungieNetJsonSerializer _serializer;

    public ForumApi(
        IBungieClientConfiguration configuration,
        IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
        IBungieNetJsonSerializer serializer
    )
    {
        _configuration = _configuration;
        _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
        _serializer = serializer;
    }

    /// <summary>
    ///     Get topics from any forum.
    /// </summary>
    /// <param name="categoryFilter">A category filter</param>
    /// <param name="group">The group, if any.</param>
    /// <param name="locales">Comma seperated list of locales posts must match to return in the result list. Default 'en'</param>
    /// <param name="page">Zero paged page number</param>
    /// <param name="pageSize">Unused</param>
    /// <param name="quickDate">A date filter.</param>
    /// <param name="sort">The sort mode.</param>
    /// <param name="tagstring">The tags to search, if any.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Forum.PostSearchResponse>> GetTopicsPaged(
        Models.Forum.ForumTopicsCategoryFiltersEnum categoryFilter,
        long group,
        int page,
        int pageSize,
        Models.Forum.ForumTopicsQuickDateEnum quickDate,
        Models.Forum.ForumTopicsSortEnum sort,
        string locales,
        string tagstring,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Forum/GetTopicsPaged/{page}/{pageSize}/{group}/{sort}/{quickDate}/{categoryFilter}/")
            .AddQueryParam("locales", locales)
            .AddQueryParam("tagstring", tagstring)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Forum.PostSearchResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets a listing of all topics marked as part of the core group.
    /// </summary>
    /// <param name="categoryFilter">The category filter.</param>
    /// <param name="locales">Comma seperated list of locales posts must match to return in the result list. Default 'en'</param>
    /// <param name="page">Zero base page</param>
    /// <param name="quickDate">The date filter.</param>
    /// <param name="sort">The sort mode.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Forum.PostSearchResponse>> GetCoreTopicsPaged(
        Models.Forum.ForumTopicsCategoryFiltersEnum categoryFilter,
        int page,
        Models.Forum.ForumTopicsQuickDateEnum quickDate,
        Models.Forum.ForumTopicsSortEnum sort,
        string locales,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Forum/GetCoreTopicsPaged/{page}/{sort}/{quickDate}/{categoryFilter}/")
            .AddQueryParam("locales", locales)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Forum.PostSearchResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Returns a thread of posts at the given parent, optionally returning replies to those posts as well as the original parent.
    /// </summary>
    /// <param name="getParentPost"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <param name="parentPostId"></param>
    /// <param name="replySize"></param>
    /// <param name="rootThreadMode"></param>
    /// <param name="showbanned">If this value is not null or empty, banned posts are requested to be returned</param>
    /// <param name="sortMode"></param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Forum.PostSearchResponse>> GetPostsThreadedPaged(
        bool getParentPost,
        int page,
        int pageSize,
        long parentPostId,
        int replySize,
        bool rootThreadMode,
        Models.Forum.ForumPostSortEnum sortMode,
        string showbanned,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Forum/GetPostsThreadedPaged/{parentPostId}/{page}/{pageSize}/{replySize}/{getParentPost}/{rootThreadMode}/{sortMode}/")
            .AddQueryParam("showbanned", showbanned)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Forum.PostSearchResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Returns a thread of posts starting at the topicId of the input childPostId, optionally returning replies to those posts as well as the original parent.
    /// </summary>
    /// <param name="childPostId"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <param name="replySize"></param>
    /// <param name="rootThreadMode"></param>
    /// <param name="showbanned">If this value is not null or empty, banned posts are requested to be returned</param>
    /// <param name="sortMode"></param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Forum.PostSearchResponse>> GetPostsThreadedPagedFromChild(
        long childPostId,
        int page,
        int pageSize,
        int replySize,
        bool rootThreadMode,
        Models.Forum.ForumPostSortEnum sortMode,
        string showbanned,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Forum/GetPostsThreadedPagedFromChild/{childPostId}/{page}/{pageSize}/{replySize}/{rootThreadMode}/{sortMode}/")
            .AddQueryParam("showbanned", showbanned)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Forum.PostSearchResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Returns the post specified and its immediate parent.
    /// </summary>
    /// <param name="childPostId"></param>
    /// <param name="showbanned">If this value is not null or empty, banned posts are requested to be returned</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Forum.PostSearchResponse>> GetPostAndParent(
        long childPostId,
        string showbanned,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Forum/GetPostAndParent/{childPostId}/")
            .AddQueryParam("showbanned", showbanned)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Forum.PostSearchResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Returns the post specified and its immediate parent of posts that are awaiting approval.
    /// </summary>
    /// <param name="childPostId"></param>
    /// <param name="showbanned">If this value is not null or empty, banned posts are requested to be returned</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Forum.PostSearchResponse>> GetPostAndParentAwaitingApproval(
        long childPostId,
        string showbanned,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Forum/GetPostAndParentAwaitingApproval/{childPostId}/")
            .AddQueryParam("showbanned", showbanned)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Forum.PostSearchResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets the post Id for the given content item's comments, if it exists.
    /// </summary>
    /// <param name="contentId"></param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<long>> GetTopicForContent(
        long contentId,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Forum/GetTopicForContent/{contentId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<long>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets tag suggestions based on partial text entry, matching them with other tags previously used in the forums.
    /// </summary>
    /// <param name="partialtag">The partial tag input to generate suggestions from.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Tags.Models.Contracts.TagResponse[]>> GetForumTagSuggestions(
        string partialtag,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .AddQueryParam("partialtag", partialtag)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Tags.Models.Contracts.TagResponse[]>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets the specified forum poll.
    /// </summary>
    /// <param name="topicId">The post id of the topic that has the poll.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Forum.PostSearchResponse>> GetPoll(
        long topicId,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Forum/Poll/{topicId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Forum.PostSearchResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Allows the caller to get a list of to 25 recruitment thread summary information objects.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Forum.ForumRecruitmentDetail[]>> GetRecruitmentThreadSummaries(
        long[] requestBody,
        CancellationToken cancellationToken = default
    )
    {
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.Forum.ForumRecruitmentDetail[]>("/Forum/Recruit/Summaries/", cancellationToken, stream);
    }

}
