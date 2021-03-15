using NetBungieAPI.Content;
using NetBungieAPI.Services;
using System.Threading.Tasks;

namespace NetBungieAPI
{
    public static class ContentMethods
    {
        private static IHttpClientInstance _httpClient;
        static ContentMethods()
        {
            _httpClient = StaticUnityContainer.GetHTTPClient();
        }
        public static async Task<BungieResponse<ContentTypeDescription>> GetContentType(string type)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<ContentTypeDescription>>($"/Content/GetContentType/{type}/");
        }
        public static async Task<BungieResponse<ContentItemPublicContract>> GetContentById(long id, string locale, bool head = false)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<ContentItemPublicContract>>($"/Content/GetContentById/{id}/{locale}/?head={head}");
        }
        public static async Task<BungieResponse<ContentItemPublicContract>> GetContentByTagAndType(string tag, string type, string locale)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<ContentItemPublicContract>>($"/Content/GetContentByTagAndType/{tag}/{type}/{locale}/");
        }
    }
}
