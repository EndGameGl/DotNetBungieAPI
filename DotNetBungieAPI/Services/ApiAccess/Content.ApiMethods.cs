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

internal sealed class ContentApi : IContentApi
{
    private readonly IBungieClientConfiguration _configuration;
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;
    private readonly IBungieNetJsonSerializer _serializer;

    public ContentApi(
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
    ///     Gets an object describing a particular variant of content.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Content.Models.ContentTypeDescription>> GetContentType(
        string type,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Content/GetContentType/{type}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Content.Models.ContentTypeDescription>(url, cancellationToken);
    }

    /// <summary>
    ///     Returns a content item referenced by id
    /// </summary>
    /// <param name="head">false</param>
    /// <param name="id"></param>
    /// <param name="locale"></param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Content.ContentItemPublicContract>> GetContentById(
        long id,
        string locale,
        bool head,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Content/GetContentById/{id}/{locale}/")
            .AddQueryParam("head", head)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Content.ContentItemPublicContract>(url, cancellationToken);
    }

    /// <summary>
    ///     Returns the newest item that matches a given tag and Content Type.
    /// </summary>
    /// <param name="head">Not used.</param>
    /// <param name="locale"></param>
    /// <param name="tag"></param>
    /// <param name="type"></param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Content.ContentItemPublicContract>> GetContentByTagAndType(
        string locale,
        string tag,
        string type,
        bool head,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Content/GetContentByTagAndType/{tag}/{type}/{locale}/")
            .AddQueryParam("head", head)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Content.ContentItemPublicContract>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets content based on querystring information passed in. Provides basic search and text search capabilities.
    /// </summary>
    /// <param name="ctype">Content type tag: Help, News, etc. Supply multiple ctypes separated by space.</param>
    /// <param name="currentpage">Page number for the search results, starting with page 1.</param>
    /// <param name="head">Not used.</param>
    /// <param name="locale"></param>
    /// <param name="searchtext">Word or phrase for the search.</param>
    /// <param name="source">For analytics, hint at the part of the app that triggered the search. Optional.</param>
    /// <param name="tag">Tag used on the content to be searched.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.SearchResultOfContentItemPublicContract>> SearchContentWithText(
        string locale,
        string ctype,
        int currentpage,
        bool head,
        string searchtext,
        string source,
        string tag,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Content/Search/{locale}/")
            .AddQueryParam("ctype", ctype)
            .AddQueryParam("currentpage", currentpage)
            .AddQueryParam("head", head)
            .AddQueryParam("searchtext", searchtext)
            .AddQueryParam("source", source)
            .AddQueryParam("tag", tag)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.SearchResultOfContentItemPublicContract>(url, cancellationToken);
    }

    /// <summary>
    ///     Searches for Content Items that match the given Tag and Content Type.
    /// </summary>
    /// <param name="currentpage">Page number for the search results starting with page 1.</param>
    /// <param name="head">Not used.</param>
    /// <param name="itemsperpage">Not used.</param>
    /// <param name="locale"></param>
    /// <param name="tag"></param>
    /// <param name="type"></param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.SearchResultOfContentItemPublicContract>> SearchContentByTagAndType(
        string locale,
        string tag,
        string type,
        int currentpage,
        bool head,
        int itemsperpage,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Content/SearchContentByTagAndType/{tag}/{type}/{locale}/")
            .AddQueryParam("currentpage", currentpage)
            .AddQueryParam("head", head)
            .AddQueryParam("itemsperpage", itemsperpage)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.SearchResultOfContentItemPublicContract>(url, cancellationToken);
    }

    /// <summary>
    ///     Search for Help Articles.
    /// </summary>
    /// <param name="searchtext"></param>
    /// <param name="size"></param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<object>> SearchHelpArticles(
        string searchtext,
        string size,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Content/SearchHelpArticles/{searchtext}/{size}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<object>(url, cancellationToken);
    }

    /// <summary>
    ///     Returns a JSON string response that is the RSS feed for news articles.
    /// </summary>
    /// <param name="categoryfilter">Optionally filter response to only include news items in a certain category.</param>
    /// <param name="includebody">Optionally include full content body for each news item.</param>
    /// <param name="pageToken">Zero-based pagination token for paging through result sets.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Content.NewsArticleRssResponse>> RssNewsArticles(
        string pageToken,
        string categoryfilter,
        bool includebody,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Content/Rss/NewsArticles/{pageToken}/")
            .AddQueryParam("categoryfilter", categoryfilter)
            .AddQueryParam("includebody", includebody)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Content.NewsArticleRssResponse>(url, cancellationToken);
    }

}
