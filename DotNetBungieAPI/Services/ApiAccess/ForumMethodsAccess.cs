using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Extensions;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Forum;
using DotNetBungieAPI.Models.Queries;
using DotNetBungieAPI.Models.Tags;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;
using DotNetBungieAPI.Services.Interfaces;

namespace DotNetBungieAPI.Services.ApiAccess;

internal sealed class ForumMethodsAccess : IForumMethodsAccess
{
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;
    private readonly IBungieNetJsonSerializer _serializer;

    public ForumMethodsAccess(IDotNetBungieApiHttpClient dotNetBungieApiHttpClient, IBungieNetJsonSerializer serializer)
    {
        _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
        _serializer = serializer;
    }

    public async ValueTask<BungieResponse<PostSearchResponse>> GetTopicsPaged(
        ForumPostCategoryEnums categoryFilter,
        ForumTopicsQuickDateEnum quickDate,
        ForumTopicsSortEnum sort, long group,
        int pageSize = 0,
        int page = 0,
        string tagstring = null,
        BungieLocales[] locales = null,
        CancellationToken cancellationToken = default)
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Forum/GetTopicsPaged/")
            .AddUrlParam(page.ToString())
            .AddUrlParam(pageSize.ToString())
            .AddUrlParam(group.ToString())
            .AddUrlParam(((byte)sort).ToString())
            .AddUrlParam(((int)quickDate).ToString())
            .AddUrlParam(((int)categoryFilter).ToString())
            .AddQueryParam("tagstring", tagstring, () => string.IsNullOrWhiteSpace(tagstring))
            .AddQueryParam("locales", string.Join(",", locales.Select(x => x.AsString())))
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<PostSearchResponse>(url, cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<PostSearchResponse>> GetCoreTopicsPaged(
        ForumPostCategoryEnums categoryFilter,
        ForumTopicsQuickDateEnum quickDate,
        ForumTopicsSortEnum sort,
        int page = 0,
        BungieLocales[] locales = null,
        CancellationToken cancellationToken = default)
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Forum/GetCoreTopicsPaged/")
            .AddUrlParam(page.ToString())
            .AddUrlParam(((byte)sort).ToString())
            .AddUrlParam(((int)quickDate).ToString())
            .AddUrlParam(((int)categoryFilter).ToString())
            .AddQueryParam("locales", string.Join(",", locales.Select(x => x.AsString())))
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<PostSearchResponse>(url, cancellationToken)
            .ConfigureAwait(false);
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
        CancellationToken cancellationToken = default)
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Forum/GetPostsThreadedPaged/")
            .AddUrlParam(parentPostId.ToString())
            .AddUrlParam(page.ToString())
            .AddUrlParam(pageSize.ToString())
            .AddUrlParam(replySize.ToString())
            .AddUrlParam(getParentPost.ToString())
            .AddUrlParam(rootThreadMode.ToString())
            .AddUrlParam(((byte)sortMode).ToString())
            .AddQueryParam("showbanned", showbanned.ToString(), () => showbanned.HasValue)
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<PostSearchResponse>(url, cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<PostSearchResponse>> GetPostsThreadedPagedFromChild(
        int page,
        int pageSize,
        long childPostId,
        int replySize,
        bool rootThreadMode,
        ForumTopicsSortEnum sortMode,
        bool? showbanned = null,
        CancellationToken cancellationToken = default)
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Forum/GetPostsThreadedPagedFromChild/")
            .AddUrlParam(childPostId.ToString())
            .AddUrlParam(page.ToString())
            .AddUrlParam(pageSize.ToString())
            .AddUrlParam(replySize.ToString())
            .AddUrlParam(rootThreadMode.ToString())
            .AddUrlParam(((byte)sortMode).ToString())
            .AddQueryParam("showbanned", showbanned.ToString(), () => showbanned.HasValue)
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<PostSearchResponse>(url, cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<PostSearchResponse>> GetPostAndParent(
        long childPostId,
        bool? showbanned = null,
        CancellationToken cancellationToken = default)
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Forum/GetPostAndParent/")
            .AddUrlParam(childPostId.ToString())
            .AddQueryParam("showbanned", showbanned.ToString(), () => showbanned.HasValue)
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<PostSearchResponse>(url, cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<PostSearchResponse>> GetPostAndParentAwaitingApproval(
        long childPostId,
        bool? showbanned = null,
        CancellationToken cancellationToken = default)
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Forum/GetPostAndParentAwaitingApproval/")
            .AddUrlParam(childPostId.ToString())
            .AddQueryParam("showbanned", showbanned.ToString(), () => showbanned.HasValue)
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<PostSearchResponse>(url, cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<long>> GetTopicForContent(
        long contentId,
        CancellationToken cancellationToken = default)
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Forum/GetTopicForContent/")
            .AddUrlParam(contentId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<long>(url, cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<TagResponse[]>> GetForumTagSuggestions(
        string partialtag,
        CancellationToken cancellationToken = default)
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Forum/GetForumTagSuggestions/")
            .AddQueryParam("partialtag", partialtag)
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<TagResponse[]>(url, cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<PostSearchResponse>> GetPoll(
        long topicId,
        CancellationToken cancellationToken = default)
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Forum/Poll/")
            .AddUrlParam(topicId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<PostSearchResponse>(url, cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<ForumRecruitmentDetail[]>> GetRecruitmentThreadSummaries(
        long[] request,
        CancellationToken cancellationToken = default)
    {
        await using var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, request);
        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<ForumRecruitmentDetail[]>("/Forum/Recruit/Summaries/", cancellationToken,
                stream)
            .ConfigureAwait(false);
    }
}