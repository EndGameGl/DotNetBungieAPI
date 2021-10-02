using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Content;
using DotNetBungieAPI.Models.Queries;

namespace DotNetBungieAPI.Services.ApiAccess.Interfaces
{
    /// <summary>
    /// Access to https://bungie.net/Platform/Content endpoint
    /// </summary>
    public interface IContentMethodsAccess
    {
        /// <summary>
        ///     Gets an object describing a particular variant of content.
        /// </summary>
        /// <param name="type">Content type</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<ContentTypeDescription>> GetContentType(
            string type,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Returns a content item referenced by id
        /// </summary>
        /// <param name="id">Content item id</param>
        /// <param name="locale">Locale to return</param>
        /// <param name="head">Not sure what this is</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<ContentItemPublicContract>> GetContentById(
            long id,
            string locale,
            bool head = false,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Returns the newest item that matches a given tag and Content Type.
        /// </summary>
        /// <param name="tag">Tag to look up</param>
        /// <param name="type">Content type</param>
        /// <param name="locale">Locale to return</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<ContentItemPublicContract>> GetContentByTagAndType(
            string tag,
            string type,
            string locale,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets content based on querystring information passed in. Provides basic search and text search capabilities.
        /// </summary>
        /// <param name="locale">Locale to return</param>
        /// <param name="types">Content type tag: Help, News, etc.</param>
        /// <param name="searchtext">Word or phrase for the search.</param>
        /// <param name="source">For analytics, hint at the part of the app that triggered the search. Optional.</param>
        /// <param name="tag">Tag used on the content to be searched.</param>
        /// <param name="currentpage">Page number for the search results, starting with page 1.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<SearchResultOfContentItemPublicContract>> SearchContentWithText(
            string locale,
            string[] types,
            string searchtext,
            string source,
            string tag,
            int currentpage = 1,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Searches for Content Items that match the given Tag and Content Type.
        /// </summary>
        /// <param name="locale">Locale to return</param>
        /// <param name="tag">Tag to search for</param>
        /// <param name="type">Type to search for</param>
        /// <param name="currentpage">Page number for the search results starting with page 1</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<SearchResultOfContentItemPublicContract>> SearchContentByTagAndType(
            string locale,
            string tag,
            string type,
            int currentpage = 1,
            CancellationToken cancellationToken = default);
    }
}