using NetBungieAPI.Bungie.Applications;
using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using System.Threading.Tasks;

namespace NetBungieAPI
{
    public class AppMethodsAccess : IAppMethodsAccess
    {
        private IHttpClientInstance _httpClient;
        internal AppMethodsAccess(IHttpClientInstance httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BungieResponse<BungieApplication[]>> GetBungieApplications()
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<BungieApplication[]>>("/App/FirstParty/");
        }
        public async Task<BungieResponse<ApiUsage>> GetApplicationApiUsage(int applicationId)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<ApiUsage>>($"/App/ApiUsage/{applicationId}/");
        }

    }
}
