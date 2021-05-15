using NetBungieAPI.Models;
using NetBungieAPI.Models.Content;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess
{
    public class ContentMethodsAccess : IContentMethodsAccess
    {
        private IHttpClientInstance _httpClient;

        internal ContentMethodsAccess(IHttpClientInstance httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask<BungieResponse<ContentTypeDescription>> GetContentType(
            string type,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Content/GetContentType/")
                .AddUrlParam(type)
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<ContentTypeDescription>(url, token);
        }

        public async ValueTask<BungieResponse<ContentItemPublicContract>> GetContentById(
            long id,
            string locale,
            bool head = false,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Content/GetContentById/")
                .AddUrlParam(id.ToString())
                .AddUrlParam(locale)
                .AddQueryParam("head", head.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<ContentItemPublicContract>(url, token);
        }

        public async ValueTask<BungieResponse<ContentItemPublicContract>> GetContentByTagAndType(
            string tag,
            string type,
            string locale,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Content/GetContentByTagAndType/")
                .AddUrlParam(tag)
                .AddUrlParam(type)
                .AddUrlParam(locale)
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<ContentItemPublicContract>(url, token);
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
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Content/Search/")
                .AddUrlParam(locale)
                .AddQueryParam("ctype", string.Join(" ", types))
                .AddQueryParam("currentpage", currentpage.ToString())
                .AddQueryParam("searchtext", searchtext)
                .AddQueryParam("source", source, () => !string.IsNullOrEmpty(source))
                .AddQueryParam("tag", tag)
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<SearchResultOfContentItemPublicContract>(url, token);
        }

        public async ValueTask<BungieResponse<SearchResultOfContentItemPublicContract>> SearchContentByTagAndType(
            string locale,
            string tag,
            string type,
            int currentpage = 1,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Content/SearchContentByTagAndType/")
                .AddUrlParam(tag)
                .AddUrlParam(type)
                .AddUrlParam(locale)
                .AddQueryParam("currentpage", currentpage.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<SearchResultOfContentItemPublicContract>(url, token);
        }
    }
}