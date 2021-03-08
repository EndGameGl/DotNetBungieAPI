using BungieNetCoreAPI.Services;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Unity;

namespace BungieNetCoreAPI.Clients
{
    /// <summary>
    /// Bungie client for interacting with CDN
    /// </summary>
    public class BungieCDNClient
    {
        private readonly IHttpClientInstance _httpClient;
        internal BungieCDNClient()
        {
            _httpClient = StaticUnityContainer.GetHTTPClient();
        }
        /// <summary>
        /// Downloads json data from CDN
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> DownloadJSONDataAsync(string url)
        {
            var response = await _httpClient.Get(BungieClient.BungieCDNUri + url);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                throw new Exception(response.ReasonPhrase);
        }
        /// <summary>
        /// Downloads image from CDN (WARNING: It can't be saved into file later)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<Image> DownloadImageAsync(string url)
        {
            Image image = null;
            var response = await _httpClient.Get(BungieClient.BungieCDNUri + url);
            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    using (var memStream = new MemoryStream())
                    {

                        await stream.CopyToAsync(memStream);
                        memStream.Position = 0;
                        image = Image.FromStream(memStream);
                    }
                }
            }
            return image;
        }
        /// <summary>
        /// Downloads an image from give url and saves to disk
        /// </summary>
        /// <param name="url"></param>
        /// <param name="folderPath"></param>
        /// <param name="filename"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public async Task<Image> DownloadImageAndSaveAsync(string url, string folderPath, string filename, ImageFormat format)
        {
            Image image = null;
            var response = await _httpClient.Get(BungieClient.BungieCDNUri + url);
            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    using (var memStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memStream);
                        memStream.Position = 0;
                        image = Image.FromStream(memStream);

                        var targetDirectory = $"{(string.IsNullOrWhiteSpace(folderPath) ? Environment.CurrentDirectory : folderPath)}\\";
                        var targetFileName = $"{(string.IsNullOrWhiteSpace(folderPath) ? Environment.CurrentDirectory : folderPath)}\\{filename}.{format.ToString().ToLower()}";
                        if (Directory.Exists(targetDirectory))
                        {
                            if (!File.Exists(targetFileName))
                            {
                                image.Save(targetFileName, format);
                                image.Dispose();
                            }
                            else
                                throw new Exception("This file already exists.");
                        }
                        else
                            throw new Exception("Directory doesn't exist.");
                    }
                }
            }
            return image;
        }
    }
}
