namespace DotNetBungieAPI.Generated.Models;

public interface IMiscApi
{
    Task<ApiResponse<Dictionary<string, string>>> GetAvailableLocales();

    Task<ApiResponse<Common.Models.CoreSettingsConfiguration>> GetCommonSettings();

    Task<ApiResponse<Dictionary<string, Common.Models.CoreSystem>>> GetUserSystemOverrides();

    Task<ApiResponse<List<GlobalAlert>>> GetGlobalAlerts(
        bool includestreaming
    );

}
