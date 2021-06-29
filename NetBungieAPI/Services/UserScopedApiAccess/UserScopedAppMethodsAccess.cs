using System;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Applications;
using NetBungieAPI.Services.ApiAccess.Interfaces;

namespace NetBungieAPI.Services.UserScopedApiAccess
{
    public class UserScopedAppMethodsAccess
    {
        private IAppMethodsAccess _apiAccess;
        private AuthorizationTokenData _token;

        internal UserScopedAppMethodsAccess(
            IAppMethodsAccess access,
            AuthorizationTokenData token)
        {
            _apiAccess = access;
            _token = token;
        }

        public async ValueTask<BungieResponse<Application[]>> GetBungieApplications(
            CancellationToken token = default)
        {
            return await _apiAccess.GetBungieApplications(token);
        }

        public async ValueTask<BungieResponse<ApiUsage>> GetApplicationApiUsage(
            AuthorizationTokenData authToken, 
            int applicationId, 
            DateTime? start = null, 
            DateTime? end = null, 
            CancellationToken token = default)
        {
            return await _apiAccess.GetApplicationApiUsage(_token, applicationId, start, end, token);
        }
    }
}