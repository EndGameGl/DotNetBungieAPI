using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Authorization;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Content;
using DotNetBungieAPI.Models.Queries;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;

namespace DotNetBungieAPI.Services.ApiAccess.UserScoped
{
    public class UserScopedContentMethodsAccess
    {
        private readonly IContentMethodsAccess _apiAccess;
        private AuthorizationTokenData _token;

        internal UserScopedContentMethodsAccess(
            IContentMethodsAccess apiAccess,
            AuthorizationTokenData token)
        {
            _apiAccess = apiAccess;
            _token = token;
        }

        public async ValueTask<BungieResponse<ContentTypeDescription>> GetContentType(
            string type,
            CancellationToken token = default)
        {
            return await _apiAccess.GetContentType(type, token);
        }

        public async ValueTask<BungieResponse<ContentItemPublicContract>> GetContentById(
            long id,
            string locale,
            bool head = false,
            CancellationToken token = default)
        {
            return await _apiAccess.GetContentById(id, locale, head, token);
        }

        public async ValueTask<BungieResponse<ContentItemPublicContract>> GetContentByTagAndType(
            string tag,
            string type,
            string locale,
            CancellationToken token = default)
        {
            return await _apiAccess.GetContentByTagAndType(tag, type, locale, token);
        }

        public async ValueTask<BungieResponse<SearchResultOfContentItemPublicContract>> SearchContentWithText(
            string locale,
            string[] types,
            string searchtext,
            string source,
            string tag,
            int currentpage = 1,
            CancellationToken token = default)
        {
            return await _apiAccess.SearchContentWithText(locale, types, searchtext, source, tag, currentpage, token);
        }

        public async ValueTask<BungieResponse<SearchResultOfContentItemPublicContract>> SearchContentByTagAndType(
            string locale,
            string tag,
            string type,
            int currentpage = 1,
            CancellationToken token = default)
        {
            return await _apiAccess.SearchContentByTagAndType(locale, tag, type, currentpage, token);
        }
    }
}