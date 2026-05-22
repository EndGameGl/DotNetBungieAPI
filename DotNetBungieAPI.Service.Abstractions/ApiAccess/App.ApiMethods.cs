using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface IAppApi
{
    Task<BungieResponse<Models.Applications.ApiUsage>> GetApplicationApiUsage(
        int applicationId,
        DateTime end,
        DateTime start,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Applications.Application[]>> GetBungieApplications(AuthorizationTokenData? authorizationToken = null, CancellationToken cancellationToken = default);

}
