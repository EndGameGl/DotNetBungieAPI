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
    }
}
