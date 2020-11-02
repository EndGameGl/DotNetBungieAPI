using BungieNetCoreAPI.Destiny;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BungieNetCoreAPI.Clients
{
    public class BungiePlatfromClient
    {
        private Uri _platfromUri = new Uri("https://www.bungie.net/Platform/");

        private string _apiKey;

        private int? _oAuthClientID;
        private string _oAuthClientSecret;

        private string _authorizationValue
        {
            get
            {
                if (_oAuthClientID.HasValue && !string.IsNullOrEmpty(_oAuthClientSecret))
                {
                    return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_oAuthClientID}:{_oAuthClientSecret}"));
                }
                else
                    throw new Exception();
            }
            set { }
        }

        public BungiePlatfromClient(string apiKey)
        {
            DefinitionsCacheRepository.RegisterDefinitionsTables();
            _apiKey = apiKey;
            HttpClientInstance.AddAcceptHeader("application/json");
            HttpClientInstance.AddHeader("X-API-Key", apiKey);
        }

        public async Task<DestinyManifest> GetDestinyManifest()
        {
            return await GetData<DestinyManifest>("Destiny2/Manifest");
        }

        private async Task<T> GetData<T>(string query)
        {
            var response = await HttpClientInstance.Get(_platfromUri + query);
            if (response.IsSuccessStatusCode)
            {
                var bungieResponse = JsonConvert.DeserializeObject<BungieResponse<T>>(await response.Content.ReadAsStringAsync());
                if (bungieResponse.ErrorCode == PlatformErrorCodes.Success && bungieResponse.Response != null)
                {
                    return bungieResponse.Response;
                }
                else
                    throw new Exception(bungieResponse.ErrorStatus);
            }
            else
                throw new Exception(response.ReasonPhrase);
        }
    }
}
