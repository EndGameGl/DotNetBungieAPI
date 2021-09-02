using System;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Applications;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    /// <summary>
    /// Access to https://bungie.net/Platform/App endpoint
    /// </summary>
    public interface IAppMethodsAccess
    {
        /// <summary>
        ///     Get list of applications created by Bungie.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<Application[]>> GetBungieApplications(
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Get API usage by application for time frame specified. You can go as far back as 30 days ago, and can ask for up to
        ///     a 48 hour window of time in a single request.
        ///     <para />
        ///     You must be authenticated with at least the ReadUserData permission to access this endpoint.
        /// </summary>
        /// <param name="authorizationToken"></param>
        /// <param name="applicationId">ID of the application to get usage statistics.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<ApiUsage>> GetApplicationApiUsage(
            AuthorizationTokenData authorizationToken,
            int applicationId,
            DateTime? start = null,
            DateTime? end = null,
            CancellationToken cancellationToken = default);
    }
}