using NetBungieAPI.Content;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess
{
    public class ContentMethodsAccess : IContentMethodsAccess
    {
        private IHttpClientInstance _httpClient;
        internal ContentMethodsAccess()
        {
            _httpClient = StaticUnityContainer.GetHTTPClient();
        }
        public async Task<BungieResponse<ContentTypeDescription>> GetContentType(string type)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<ContentTypeDescription>>($"/Content/GetContentType/{type}/");
        }
        public async Task<BungieResponse<ContentItemPublicContract>> GetContentById(long id, string locale, bool head = false)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<ContentItemPublicContract>>($"/Content/GetContentById/{id}/{locale}/?head={head}");
        }
        public async Task<BungieResponse<ContentItemPublicContract>> GetContentByTagAndType(string tag, string type, string locale)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<ContentItemPublicContract>>($"/Content/GetContentByTagAndType/{tag}/{type}/{locale}/");
        }
        public async Task<BungieResponse<SearchResult<ContentItemPublicContract>>> SearchContentWithText(string locale, string[] types,
            string searchtext, string source, string tag, int currentpage = 1)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<SearchResult<ContentItemPublicContract>>>(
                $"/Content/Search/{locale}/?types={string.Join(" ", types)}&searchtext={searchtext}{(!string.IsNullOrWhiteSpace(source) ? $"&source={source}" : "")}&tag={tag}&currentpage={currentpage}");
        }
        public async Task<BungieResponse<SearchResult<ContentItemPublicContract>>> SearchContentByTagAndType(string locale, string tag, string type)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<SearchResult<ContentItemPublicContract>>>($"/Content/SearchContentByTagAndType/{tag}/{type}/{locale}/");
        }
    }
}
