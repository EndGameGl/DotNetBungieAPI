using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Models;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IHttpClientInstance
    {
        Task<AuthorizationTokenData> GetAuthorizationToken(string code);
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