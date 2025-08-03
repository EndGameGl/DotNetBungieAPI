using DotNetBungieAPI.Generated.Models;

namespace DotNetBungieAPI.Generated.Methods;

public interface IMiscApi
{
    Task<ApiResponse<Dictionary<string, string>>> GetAvailableLocales();

    Task<ApiResponse<Models.Common.Models.CoreSettingsConfiguration>> GetCommonSettings();

    Task<ApiResponse<Dictionary<string, Models.Common.Models.CoreSystem>>> GetUserSystemOverrides();

    Task<ApiResponse<Models.GlobalAlert[]>> GetGlobalAlerts(
        bool includestreaming
    );

}
