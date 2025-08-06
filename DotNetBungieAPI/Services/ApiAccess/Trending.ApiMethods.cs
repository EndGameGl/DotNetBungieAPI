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

internal sealed class TrendingApi : ITrendingApi
{
    private readonly IBungieClientConfiguration _configuration;
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;
    private readonly IBungieNetJsonSerializer _serializer;

    public TrendingApi(
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
    ///     Returns trending items for Bungie.net, collapsed into the first page of items per category. For pagination within a category, call GetTrendingCategory.
    /// </summary>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Trending.TrendingCategories>> GetTrendingCategories(CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Trending.TrendingCategories>("/Trending/Categories/", cancellationToken);
    }

    /// <summary>
    ///     Returns paginated lists of trending items for a category.
    /// </summary>
    /// <param name="categoryId">The ID of the category for whom you want additional results.</param>
    /// <param name="pageNumber">The page # of results to return.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.SearchResultOfTrendingEntry>> GetTrendingCategory(
        string categoryId,
        int pageNumber,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Trending/Categories/{categoryId}/{pageNumber}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.SearchResultOfTrendingEntry>(url, cancellationToken);
    }

    /// <summary>
    ///     Returns the detailed results for a specific trending entry. Note that trending entries are uniquely identified by a combination of *both* the TrendingEntryType *and* the identifier: the identifier alone is not guaranteed to be globally unique.
    /// </summary>
    /// <param name="identifier">The identifier for the entity to be returned.</param>
    /// <param name="trendingEntryType">The type of entity to be returned.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Trending.TrendingDetail>> GetTrendingEntryDetail(
        string identifier,
        Models.Trending.TrendingEntryType trendingEntryType,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Trending/Details/{trendingEntryType}/{identifier}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Trending.TrendingDetail>(url, cancellationToken);
    }

}
