using BungieNetCoreAPI.Bungie;
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

        #region User methods
        public async Task<BungieNetUser> GetBungieNetUserById(long id)
        {
            return await GetData<BungieNetUser>($"User/GetBungieNetUserById/{id}");
        }
        public async Task<BungieNetUser[]> SearchUsers(string query)
        {
            if (!string.IsNullOrWhiteSpace(query))
                return await GetData<BungieNetUser[]>($"User/SearchUsers/?q={query}");
            else
                throw new Exception("Query must contain something.");
        }
        public async Task<BungieNetUserAccountCredentialType[]> GetCredentialTypesForTargetAccount(long id)
        {
            return await GetData<BungieNetUserAccountCredentialType[]>($"User/GetCredentialTypesForTargetAccount/{id}");
        }
        public async Task<BungieUserTheme[]> GetAvailableThemes()
        {
            return await GetData<BungieUserTheme[]>($"User/GetAvailableThemes");
        }
        public async Task<BungieNetUserWithMemberships> GetMembershipDataById(long id, BungieMembershipType membershipType)
        {
            return await GetData<BungieNetUserWithMemberships>($"User/GetMembershipsById/{id}/{membershipType}");
        }
        public async Task<BungieNetUserWithMemberships> GetMembershipDataForCurrentUser()
        {
            return await GetData<BungieNetUserWithMemberships>($"User/GetMembershipsForCurrentUser");
        }
        public async Task<DestinyHardLinkedUserMembership> GetMembershipFromHardLinkedCredential(long credential, BungieCredentialType credentialType = BungieCredentialType.SteamId)
        {
            return await GetData<DestinyHardLinkedUserMembership>($"User/GetMembershipFromHardLinkedCredential/{credentialType}/{credential}");
        }
        #endregion

        private async Task<T> GetData<T>(string query)
        {
            var response = await HttpClientInstance.Get(_platfromUri + query);
            //if (response.IsSuccessStatusCode)
            //{
            var bungieResponse = JsonConvert.DeserializeObject<BungieResponse<T>>(await response.Content.ReadAsStringAsync());
            if (bungieResponse.ErrorCode == PlatformErrorCodes.Success && bungieResponse.Response != null)
            {
                return bungieResponse.Response;
            }
            else
                throw new Exception(bungieResponse.ErrorStatus);
            //}
            //else
            //    throw new Exception(response.ReasonPhrase);
        }
    }
}
