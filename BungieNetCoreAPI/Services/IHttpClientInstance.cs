using NetBungieAPI.Authrorization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetBungieAPI.Services
{
    public interface IHttpClientInstance
    {
        void AddAcceptHeader(string headerValue);
        void AddHeader(string header, string headerValue);
        void RemoveHeader(string header);
        Task<HttpResponseMessage> Get(string query);
        Task<HttpResponseMessage> Send(HttpRequestMessage request);
        Task<AuthorizationTokenData> GetAuthorizationToken(string code, string authValue);
        Task<AuthorizationTokenData> RenewAuthorizationToken(AuthorizationTokenData oldToken);
        Task<HttpResponseMessage> GetFromPlatform(string query);
        Task<HttpResponseMessage> GetFromStatsPlatform(string query);
        string GetAuthLink(int clientId, string state);
        Task<string> DownloadJSONDataFromCDNAsync(string url);
        Task<Image> DownloadImageFromCDNAsync(string url);
        Task<Image> DownloadImageFromCDNAndSaveAsync(string url, string folderPath, string filename, ImageFormat format);
        Task<T> GetFromPlatfromAndDeserialize<T>(string query);
        Task<T> GetFromStatsPlatfromAndDeserialize<T>(string query);

    }
}
