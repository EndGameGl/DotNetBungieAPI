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
        public async ValueTask<BungieResponse<ContentTypeDescription>> GetContentType(string type, CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<ContentTypeDescription>($"/Content/GetContentType/{type}/", token);
        }
        public async ValueTask<BungieResponse<ContentItemPublicContract>> GetContentById(long id, string locale, bool head = false, CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<ContentItemPublicContract>($"/Content/GetContentById/{id}/{locale}/?head={head}", token);
        }
        public async ValueTask<BungieResponse<ContentItemPublicContract>> GetContentByTagAndType(string tag, string type, string locale, CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<ContentItemPublicContract>($"/Content/GetContentByTagAndType/{tag}/{type}/{locale}/", token);
        }
        public async ValueTask<BungieResponse<SearchResultOfContentItemPublicContract>> SearchContentWithText(string locale, string[] types,
            string searchtext, string source, string tag, int currentpage = 1, CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<SearchResultOfContentItemPublicContract>(
                $"/Content/Search/{locale}/?types={string.Join(" ", types)}&searchtext={searchtext}{(!string.IsNullOrWhiteSpace(source) ? $"&source={source}" : "")}&tag={tag}&currentpage={currentpage}", token);
        }
        public async ValueTask<BungieResponse<SearchResultOfContentItemPublicContract>> SearchContentByTagAndType(string locale, string tag, string type, CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<SearchResultOfContentItemPublicContract>($"/Content/SearchContentByTagAndType/{tag}/{type}/{locale}/", token);
        }
    }
}
