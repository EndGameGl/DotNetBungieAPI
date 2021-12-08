using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Authorization;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Forum;
using DotNetBungieAPI.Models.Queries;
using DotNetBungieAPI.Models.Tags;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;

namespace DotNetBungieAPI.Services.ApiAccess.UserScoped;

public sealed class UsedScopedForumMethodsAccess
{
    private readonly IForumMethodsAccess _apiAccess;
    private AuthorizationTokenData _token;

    internal UsedScopedForumMethodsAccess(
        IForumMethodsAccess apiAccess,
        AuthorizationTokenData token)
    {
        _apiAccess = apiAccess;
        _token = token;
    }

    public async ValueTask<BungieResponse<PostSearchResponse>> GetTopicsPaged(
        ForumPostCategoryEnums categoryFilter,
        ForumTopicsQuickDateEnum quickDate,
        ForumTopicsSortEnum sort,
        long group,
        int pageSize = 0,
        int page = 0,
        string tagstring = null,
        BungieLocales[] locales = null,
        CancellationToken token = default)
    {
        return await _apiAccess.GetTopicsPaged(categoryFilter, quickDate, sort, group, pageSize, page, tagstring,
            locales, token);
    }

    public async ValueTask<BungieResponse<PostSearchResponse>> GetCoreTopicsPaged(
        ForumPostCategoryEnums categoryFilter,
        ForumTopicsQuickDateEnum quickDate,
        ForumTopicsSortEnum sort,
        int page = 0,
        BungieLocales[] locales = null,
        CancellationToken token = default)
    {
        return await _apiAccess.GetCoreTopicsPaged(categoryFilter, quickDate, sort, page, locales, token);
    }

    public async ValueTask<BungieResponse<PostSearchResponse>> GetPostsThreadedPaged(
        bool getParentPost,
        int page,
        int pageSize,
        long parentPostId,
        int replySize,
        bool rootThreadMode,
        ForumTopicsSortEnum sortMode,
        bool? showbanned = null,
        CancellationToken token = default)
    {
        return await _apiAccess.GetPostsThreadedPaged(getParentPost, page, pageSize, parentPostId, replySize,
            rootThreadMode, sortMode, showbanned, token);
    }

    public async ValueTask<BungieResponse<PostSearchResponse>> GetPostsThreadedPagedFromChild(
        int page,
        int pageSize,
        long childPostId,
        int replySize,
        bool rootThreadMode,
        ForumTopicsSortEnum sortMode,
        bool? showbanned = null,
        CancellationToken token = default)
    {
        return await _apiAccess.GetPostsThreadedPagedFromChild(page, pageSize, childPostId, replySize,
            rootThreadMode, sortMode, showbanned, token);
    }

    public async ValueTask<BungieResponse<PostSearchResponse>> GetPostAndParent(
        long childPostId,
        bool? showbanned = null,
        CancellationToken token = default)
    {
        return await _apiAccess.GetPostAndParent(childPostId, showbanned, token);
    }

    public async ValueTask<BungieResponse<PostSearchResponse>> GetPostAndParentAwaitingApproval(
        long childPostId,
        bool? showbanned = null,
        CancellationToken token = default)
    {
        return await _apiAccess.GetPostAndParentAwaitingApproval(childPostId, showbanned, token);
    }

    public async ValueTask<BungieResponse<long>> GetTopicForContent(
        long contentId,
        CancellationToken token = default)
    {
        return await _apiAccess.GetTopicForContent(contentId, token);
    }

    public async ValueTask<BungieResponse<TagResponse[]>> GetForumTagSuggestions(
        string partialtag,
        CancellationToken token = default)
    {
        return await _apiAccess.GetForumTagSuggestions(partialtag, token);
    }

    public async ValueTask<BungieResponse<PostSearchResponse>> GetPoll(
        long topicId,
        CancellationToken token = default)
    {
        return await _apiAccess.GetPoll(topicId, token);
    }

    public async ValueTask<BungieResponse<ForumRecruitmentDetail[]>> GetRecruitmentThreadSummaries(
        long[] request,
        CancellationToken token = default)
    {
        return await _apiAccess.GetRecruitmentThreadSummaries(request, token);
    }
}