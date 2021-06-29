using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Exceptions;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Applications;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services.ApiAccess
{
    public class AppMethodsAccess : IAppMethodsAccess
    {
        private readonly IConfigurationService _configuration;
        private readonly IHttpClientInstance _httpClient;

        internal AppMethodsAccess(IHttpClientInstance httpClient, IConfigurationService configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async ValueTask<BungieResponse<Application[]>> GetBungieApplications(
            CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<Application[]>("/App/FirstParty/", token);
        }

        public async ValueTask<BungieResponse<ApiUsage>> GetApplicationApiUsage(
            AuthorizationTokenData authToken,
            int applicationId,
            DateTime? start = null,
            DateTime? end = null,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes.HasFlag(
                ApplicationScopes.ReadUserData))
                throw new InsufficientScopeException(ApplicationScopes.ReadUserData);
            if (start.HasValue && end.HasValue && (end.Value - start.Value).TotalHours > 48)
                throw new Exception("Can't request more than 48 hours.");
            end ??= DateTime.Now;
            start ??= end.Value.AddHours(-24);
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/App/ApiUsage/")
                .AddQueryParam("start",
                    start.Value.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture))
                .AddQueryParam("end",
                    end.Value.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture))
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<ApiUsage>(url, token, authToken.AccessToken);
        }
    }
}