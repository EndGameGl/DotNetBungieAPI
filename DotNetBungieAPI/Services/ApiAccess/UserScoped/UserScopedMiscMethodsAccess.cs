using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Common;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;

namespace DotNetBungieAPI.Services.ApiAccess.UserScoped
{
    public sealed class UserScopedMiscMethodsAccess
    {
        private readonly IMiscMethodsAccess _apiAccess;

        internal UserScopedMiscMethodsAccess(IMiscMethodsAccess access)
        {
            _apiAccess = access;
        }

        public async ValueTask<BungieResponse<Dictionary<string, string>>> GetAvailableLocales(
            CancellationToken token = default)
        {
            return await _apiAccess.GetAvailableLocales(token);
        }

        public async ValueTask<BungieResponse<CoreSettingsConfiguration>> GetCommonSettings(
            CancellationToken token = default)
        {
            return await _apiAccess.GetCommonSettings(token);
        }

        public async ValueTask<BungieResponse<Dictionary<string, CoreSystem>>> GetUserSystemOverrides(
            CancellationToken token = default)
        {
            return await _apiAccess.GetUserSystemOverrides(token);
        }

        public async ValueTask<BungieResponse<GlobalAlert[]>> GetGlobalAlerts(
            bool includestreaming = false,
            CancellationToken token = default)
        {
            return await _apiAccess.GetGlobalAlerts(includestreaming, token);
        }
    }
}