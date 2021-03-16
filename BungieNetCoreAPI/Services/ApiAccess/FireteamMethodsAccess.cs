using NetBungieAPI.Services.ApiAccess.Interfaces;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess
{
    public class FireteamMethodsAccess : IFireteamMethodsAccess
    {
        private readonly IHttpClientInstance _httpClient;

        public FireteamMethodsAccess(IHttpClientInstance httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<BungieResponse<int>> GetActivePrivateClanFireteamCount(long groupId)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<int>>($"/Fireteam/Clan/{groupId}/ActiveCount/");
        }

    }
}
