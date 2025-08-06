using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface IContentApi
{
    Task<BungieResponse<Models.Content.Models.ContentTypeDescription>> GetContentType(
        string type,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Content.ContentItemPublicContract>> GetContentById(
        long id,
        string locale,
        bool head,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Content.ContentItemPublicContract>> GetContentByTagAndType(
        string locale,
        string tag,
        string type,
        bool head,
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
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfContentItemPublicContract>> SearchContentByTagAndType(
        string locale,
        string tag,
        string type,
        int currentpage,
        bool head,
        int itemsperpage,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<object>> SearchHelpArticles(
        string searchtext,
        string size,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Content.NewsArticleRssResponse>> RssNewsArticles(
        string pageToken,
        string categoryfilter,
        bool includebody,
        CancellationToken cancellationToken = default
    );

}
