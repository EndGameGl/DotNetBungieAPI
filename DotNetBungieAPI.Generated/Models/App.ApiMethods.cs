namespace DotNetBungieAPI.Generated.Models;

public interface IAppApi
{
    Task<ApiResponse<Applications.ApiUsage>> GetApplicationApiUsage(
        int applicationId,
        DateTime end,
        DateTime start,
        string authToken
    );

    Task<ApiResponse<Applications.Application[]>> GetBungieApplications();

}
