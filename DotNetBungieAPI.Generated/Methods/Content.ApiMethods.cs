using DotNetBungieAPI.Generated.Models;

namespace DotNetBungieAPI.Generated.Methods;

public interface IContentApi
{
    Task<ApiResponse<Models.Content.Models.ContentTypeDescription>> GetContentType(
        string type
    );

    Task<ApiResponse<Models.Content.ContentItemPublicContract>> GetContentById(
        long id,
        string locale,
        bool head
    );

    Task<ApiResponse<Models.Content.ContentItemPublicContract>> GetContentByTagAndType(
        string locale,
        string tag,
        string type,
        bool head
    );

    Task<ApiResponse<Models.SearchResultOfContentItemPublicContract>> SearchContentWithText(
        string locale,
        string ctype,
        int currentpage,
        bool head,
        string searchtext,
        string source,
        string tag
    );

    Task<ApiResponse<Models.SearchResultOfContentItemPublicContract>> SearchContentByTagAndType(
        string locale,
        string tag,
        string type,
        int currentpage,
        bool head,
        int itemsperpage
    );

    Task<ApiResponse<object>> SearchHelpArticles(
        string searchtext,
        string size
    );

    Task<ApiResponse<Models.Content.NewsArticleRssResponse>> RssNewsArticles(
        string pageToken,
        string categoryfilter,
        bool includebody
    );

}
