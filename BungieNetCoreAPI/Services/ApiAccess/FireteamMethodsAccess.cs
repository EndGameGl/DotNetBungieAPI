using NetBungieAPI.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Models.Fireteam;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
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
        public async Task<BungieResponse<SearchResult<FireteamSummary[]>>> GetAvailableClanFireteams(long groupId, FireteamPlatform platform, DestinyActivityModeType activityType, FireteamDateRange dateRange, FireteamSlotSearch slotFilter, FireteamPublicSearchOption publicOnly, int page = 0)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<SearchResult<FireteamSummary[]>>>($"/Fireteam/Clan/{groupId}/Available/{platform}/{activityType}/{dateRange}/{slotFilter}/{publicOnly}/{page}/");
        }
        public async Task<BungieResponse<SearchResult<FireteamSummary[]>>> SearchPublicAvailableClanFireteams(FireteamPlatform platform, DestinyActivityModeType activityType, FireteamDateRange dateRange, FireteamSlotSearch slotFilter, int page = 0, string langFilter = null)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<SearchResult<FireteamSummary[]>>>($"/Fireteam/Search/Available/{platform}/{activityType}/{dateRange}/{slotFilter}/{page}/{(string.IsNullOrWhiteSpace(langFilter) == false ? $"?langFilter={langFilter}" : "")}");
        }
        public async Task<BungieResponse<SearchResult<FireteamResponse[]>>> GetMyClanFireteams(long groupId, FireteamPlatform platform, bool includeClosed, int page = 0, string langFilter = null, bool groupFilter = false)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<SearchResult<FireteamResponse[]>>>($"/Fireteam/Clan/{groupId}/My/{platform}/{includeClosed}/{page}/?groupFilter={groupFilter}{(string.IsNullOrWhiteSpace(langFilter) == false ? $"?langFilter={langFilter}" : "")}");
        }
        public async Task<BungieResponse<FireteamResponse>> GetClanFireteam(long groupId, long fireteamId)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<FireteamResponse>>($"/Fireteam/Clan/{groupId}/Summary/{fireteamId}/");
        }
    }
}
