using NetBungieAPI.Bungie;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IMiscMethodsAccess
    {
        Task<BungieResponse<Dictionary<string, string>>> GetAvailableLocales();
        Task<BungieResponse<BungieNetSettings>> GetCommonSettings();
        Task<BungieResponse<Dictionary<string, BungieSystemSetting>>> GetUserSystemOverrides();
        Task<BungieResponse<GlobalAlert[]>> GetGlobalAlerts();
    }
}
