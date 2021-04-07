using NetBungieAPI.Models;
using NetBungieAPI.Models.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IMiscMethodsAccess
    {
        ValueTask<BungieResponse<Dictionary<string, string>>> GetAvailableLocales(CancellationToken token = default);
        ValueTask<BungieResponse<CoreSettingsConfiguration>> GetCommonSettings(CancellationToken token = default);
        ValueTask<BungieResponse<Dictionary<string, CoreSystem>>> GetUserSystemOverrides(CancellationToken token = default);
        ValueTask<BungieResponse<GlobalAlert[]>> GetGlobalAlerts(CancellationToken token = default);
    }
}
