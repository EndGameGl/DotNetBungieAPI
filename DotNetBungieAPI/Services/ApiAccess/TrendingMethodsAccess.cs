using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Queries;
using DotNetBungieAPI.Models.Trending;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;

namespace DotNetBungieAPI.Services.ApiAccess;

/// <summary>
///     <inheritdoc cref="ITrendingMethodsAccess" />
/// </summary>
internal sealed class TrendingMethodsAccess : ITrendingMethodsAccess
{
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;

    public TrendingMethodsAccess(IDotNetBungieApiHttpClient dotNetBungieApiHttpClient)
    {
        _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
    }

    public async ValueTask<BungieResponse<TrendingCategories>> GetTrendingCategories(
        CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<TrendingCategories>("/Trending/Categories/", cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<SearchResultOfTrendingEntry>> GetTrendingCategory(
        string categoryId,
        int pageNumber = 0,
        CancellationToken cancellationToken = default)
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Trending/Categories/")
            .AddUrlParam(categoryId)
            .AddUrlParam(pageNumber.ToString())
            .Build();
        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<SearchResultOfTrendingEntry>(url, cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<TrendingDetail>> GetTrendingEntryDetail(
        TrendingEntryType trendingEntryType,
        string identifier,
        CancellationToken cancellationToken = default)
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Trending/Details/")
            .AddUrlParam(((int)trendingEntryType).ToString())
            .AddUrlParam(identifier)
            .Build();
        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<TrendingDetail>(url, cancellationToken)
            .ConfigureAwait(false);
    }
}