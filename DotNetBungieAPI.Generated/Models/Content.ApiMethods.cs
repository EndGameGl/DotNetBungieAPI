namespace DotNetBungieAPI.Generated.Models;

public interface IContentApi
{
    Task<ApiResponse<Content.Models.ContentTypeDescription>> GetContentType(
        string type
    );

    Task<ApiResponse<Content.ContentItemPublicContract>> GetContentById(
        long id,
        string locale,
        bool head
    );

    Task<ApiResponse<Content.ContentItemPublicContract>> GetContentByTagAndType(
        string locale,
        string tag,
        string type,
        bool head
    );

    Task<ApiResponse<SearchResultOfContentItemPublicContract>> SearchContentWithText(
        string locale,
        string ctype,
        int currentpage,
        bool head,
        string searchtext,
        string source,
        string tag
    );

    Task<ApiResponse<SearchResultOfContentItemPublicContract>> SearchContentByTagAndType(
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

    Task<ApiResponse<Content.NewsArticleRssResponse>> RssNewsArticles(
        string pageToken,
        string categoryfilter,
        bool includebody
    );

}
