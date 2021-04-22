using NetBungieAPI.Models;
using NetBungieAPI.Models.Applications;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace NetBungieAPI
{
    public class AppMethodsAccess : IAppMethodsAccess
    {
        private readonly IHttpClientInstance _httpClient;
        private readonly IConfigurationService _configuration;
        internal AppMethodsAccess(IHttpClientInstance httpClient, IConfigurationService configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async ValueTask<BungieResponse<Application[]>> GetBungieApplications(CancellationToken token = default)
        {      
            return await _httpClient.GetFromBungieNetPlatform<Application[]>("/App/FirstParty/", token);
        }
        public async ValueTask<BungieResponse<ApiUsage>> GetApplicationApiUsage(int applicationId, DateTime? start = null, DateTime? end = null, CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes.HasFlag(ApplicationScopes.ReadUserData))
                throw new Exception("ReadUserData scope is required to call this api.");
            if (start.HasValue && end.HasValue && (end.Value - start.Value).TotalHours > 48)
                throw new Exception("Can't request more than 48 hours.");
            if (!end.HasValue)
                end = DateTime.Now;
            if (!start.HasValue)
                start = end.Value.AddHours(-24);
            return await _httpClient.GetFromBungieNetPlatform<ApiUsage>($"/App/ApiUsage/{applicationId}/?start={JsonSerializer.Serialize(start).Replace("\"", "")}&end={JsonSerializer.Serialize(end).Replace("\"", "")}", token);
        }
    }
}
