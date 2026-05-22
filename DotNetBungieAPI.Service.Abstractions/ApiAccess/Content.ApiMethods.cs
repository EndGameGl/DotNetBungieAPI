using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface IContentApi
{
    Task<BungieResponse<Models.Content.Models.ContentTypeDescription>> GetContentType(
        string type,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Content.ContentItemPublicContract>> GetContentById(
        long id,
        string locale,
        bool head,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Content.ContentItemPublicContract>> GetContentByTagAndType(
        string locale,
        string tag,
        string type,
        bool head,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfContentItemPublicContract>> SearchContentWithText(
        string locale,
        string ctype,
        int currentpage,
        bool head,
        string searchtext,
        string source,
        string tag,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfContentItemPublicContract>> SearchContentByTagAndType(
        string locale,
        string tag,
        string type,
        int currentpage,
        bool head,
        int itemsperpage,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<object>> SearchHelpArticles(
        string searchtext,
        string size,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Content.NewsArticleRssResponse>> RssNewsArticles(
        string pageToken,
        string categoryfilter,
        bool includebody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

}
