using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BungieNetCoreAPI.Clients
{
    public class BungieCDNClient
    {
        private Uri _cdnUri = new Uri("https://www.bungie.net/");
        public async Task<string> DownloadJSON(string path)
        {
            var response = await HttpClientInstance.Get(_cdnUri + path);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                throw new Exception(response.ReasonPhrase);
        }
    }
}
