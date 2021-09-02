using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Forum;
using NetBungieAPI.Models.Queries;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    /// <summary>
    /// Access to https://bungie.net/Platform/CommunityContent endpoint
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
        ValueTask<BungieResponse<PostSearchResponse>> GetCommunityContent(
            ForumTopicsSortEnum sort,
            ForumMediaType mediaFilter,
            int page = 0,
            CancellationToken cancellationToken = default);
    }
}