using NetBungieAPI.Content;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IContentMethodsAccess
    {
        Task<BungieResponse<ContentTypeDescription>> GetContentType(string type);
        Task<BungieResponse<ContentItemPublicContract>> GetContentById(long id, string locale, bool head = false);
        Task<BungieResponse<ContentItemPublicContract>> GetContentByTagAndType(string tag, string type, string locale);
        Task<BungieResponse<SearchResult<ContentItemPublicContract>>> SearchContentWithText(string locale, string[] types, string searchtext, string source, string tag, int currentpage = 1);
        Task<BungieResponse<SearchResult<ContentItemPublicContract>>> SearchContentByTagAndType(string locale, string tag, string type);
    }
}
