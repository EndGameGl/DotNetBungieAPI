using NetBungieAPI.Models;
using NetBungieAPI.Models.Content;
using NetBungieAPI.Models.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IContentMethodsAccess
    {
        ValueTask<BungieResponse<ContentTypeDescription>>
            GetContentType(string type, CancellationToken token = default);

        ValueTask<BungieResponse<ContentItemPublicContract>> GetContentById(long id, string locale, bool head = false,
            CancellationToken token = default);

        ValueTask<BungieResponse<ContentItemPublicContract>> GetContentByTagAndType(string tag, string type,
            string locale, CancellationToken token = default);

        ValueTask<BungieResponse<SearchResultOfContentItemPublicContract>> SearchContentWithText(string locale,
            string[] types, string searchtext, string source, string tag, int currentpage = 1,
            CancellationToken token = default);

        ValueTask<BungieResponse<SearchResultOfContentItemPublicContract>> SearchContentByTagAndType(string locale,
            string tag, string type, int currentpage = 1, CancellationToken token = default);
    }
}