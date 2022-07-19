using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Forum;
using DotNetBungieAPI.Models.Queries;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

/// <summary>
///     Access to https://bungie.net/Platform/CommunityContent endpoint
/// </summary>
public interface ICommunityContentMethodsAccess
{
    /// <summary>
    ///     Returns community content.
    /// </summary>
    /// <param name="sort">The sort mode.</param>
    /// <param name="mediaFilter">The type of media to get</param>
    /// <param name="page">Zero based page</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BungieResponse<PostSearchResponse>> GetCommunityContent(
        ForumTopicsSortEnum sort,
        ForumMediaType mediaFilter,
        int page = 0,
        CancellationToken cancellationToken = default);
}