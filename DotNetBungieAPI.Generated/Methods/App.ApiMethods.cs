using DotNetBungieAPI.Generated.Models;

namespace DotNetBungieAPI.Generated.Methods;

public interface IAppApi
{
    Task<ApiResponse<Models.Applications.ApiUsage>> GetApplicationApiUsage(
        int applicationId,
        DateTime end,
        DateTime start,
        string authToken
    );

    Task<ApiResponse<Models.Applications.Application[]>> GetBungieApplications();

}
