using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Models;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IDotNetBungieApiHttpClient
    {
        /// <summary>
        ///     Gets an auth token from bungie.net
        /// </summary>
        /// <param name="code">Code for the token</param>
        /// <returns></returns>
        ValueTask<AuthorizationTokenData> GetAuthorizationToken(string code);

        /// <summary>
        ///     Renews auth token whenever possible
        /// </summary>
        /// <param name="oldToken">Token to update</param>
        /// <returns></returns>
        ValueTask<AuthorizationTokenData> RenewAuthorizationToken(AuthorizationTokenData oldToken);

        string GetAuthLink(int clientId, string state);
        ValueTask<string> DownloadJsonDataFromCdnAsync(string url);
        ValueTask<Image> DownloadImageFromCdnAsync(string url);

        Task<Image> DownloadImageFromCdnAndSaveAsync(string url, string folderPath, string filename,
            ImageFormat format);

        Task DownloadFileStreamFromCdnAsync(string query, string savePath);

        ValueTask<BungieResponse<T>> GetFromBungieNetPlatform<T>(string query, CancellationToken token,
            string authToken = null);

        ValueTask<BungieResponse<T>> PostToBungieNetPlatform<T>(string query, CancellationToken token,
            Stream content = null,
            string authToken = null);

        ValueTask<BungieResponse<T>> GetFromBungieNetStatsPlatform<T>(string query, CancellationToken token,
            string authToken = null);

        ValueTask<Stream> GetStreamFromWebSourceAsync(string path);
    }
}