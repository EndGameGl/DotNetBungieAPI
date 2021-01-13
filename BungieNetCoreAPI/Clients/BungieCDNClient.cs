using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace BungieNetCoreAPI.Clients
{
    /// <summary>
    /// Bungie client for interacting with CDN
    /// </summary>
    internal class BungieCDNClient
    {
        internal static Uri BungieCDNUri = new Uri("https://www.bungie.net/");
        /// <summary>
        /// Downloads json data from CDN
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> DownloadJSONDataAsync(string url)
        {
            var response = await HttpClientInstance.Get(BungieCDNUri + url);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                throw new Exception(response.ReasonPhrase);
        }
        /// <summary>
        /// Downloads image from CDN
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<Bitmap> DownloadImageAsync(string url)
        {
            Bitmap bitmap = null;
            var response = await HttpClientInstance.Get(BungieCDNUri + url);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    using (var memStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memStream);
                        memStream.Position = 0;
                        bitmap = new Bitmap(memStream);
                    }
                }
            }
            return bitmap;
        }
    }
}
