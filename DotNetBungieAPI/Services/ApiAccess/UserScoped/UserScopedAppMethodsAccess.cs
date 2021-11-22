using DotNetBungieAPI.Authorization;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetBungieAPI.Services.ApiAccess.UserScoped
{
    public sealed class UserScopedAppMethodsAccess
    {
        private readonly IAppMethodsAccess _apiAccess;
        private readonly AuthorizationTokenData _token;

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