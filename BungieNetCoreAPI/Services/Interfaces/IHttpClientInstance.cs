using NetBungieAPI.Authrorization;
using NetBungieAPI.Models;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IHttpClientInstance
    {
        void AddAcceptHeader(string headerValue);
        void AddHeader(string header, string headerValue);
        Task<AuthorizationTokenData> GetAuthorizationToken(string code, string authValue);
        Task<AuthorizationTokenData> RenewAuthorizationToken(AuthorizationTokenData oldToken);
        string GetAuthLink(int clientId, string state);
        ValueTask<string> DownloadJSONDataFromCDNAsync(string url);
        ValueTask<Image> DownloadImageFromCDNAsync(string url);
        Task<Image> DownloadImageFromCDNAndSaveAsync(string url, string folderPath, string filename,
            ImageFormat format);
        Task DownloadFileStreamFromCDNAsync(string query, string savePath);

        ValueTask<BungieResponse<T>> GetFromBungieNetPlatform<T>(string query, CancellationToken token,
            string authToken = null);

        ValueTask<BungieResponse<T>> PostToBungieNetPlatform<T>(string query, CancellationToken token,
            Stream content = null,
            string authToken = null);

        ValueTask<BungieResponse<T>> GetFromBungieNetStatsPlatform<T>(string query, CancellationToken token,
            string authToken = null);
    }
}