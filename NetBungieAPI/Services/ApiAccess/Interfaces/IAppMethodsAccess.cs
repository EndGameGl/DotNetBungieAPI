using NetBungieAPI.Models;
using NetBungieAPI.Models.Applications;
using System;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IAppMethodsAccess
    {
        /// <summary>
        /// Get list of applications created by Bungie.
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<Application[]>> GetBungieApplications(
            CancellationToken token = default);

        /// <summary>
        /// Get API usage by application for time frame specified. You can go as far back as 30 days ago, and can ask for up to a 48 hour window of time in a single request.
        /// <para/>
        /// You must be authenticated with at least the ReadUserData permission to access this endpoint.
        /// </summary>
        /// <param name="applicationId">ID of the application to get usage statistics.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<ApiUsage>> GetApplicationApiUsage(
            AuthorizationTokenData authToken,
            int applicationId,
            DateTime? start = null, 
            DateTime? end = null,
            CancellationToken token = default);
    }
}