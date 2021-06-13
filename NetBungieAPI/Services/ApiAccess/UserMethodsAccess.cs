using System;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Config;
using NetBungieAPI.Models.User;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Exceptions;
using NetBungieAPI.Models.Applications;

namespace NetBungieAPI.Services.ApiAccess
{
    public class UserMethodsAccess : IUserMethodsAccess
    {
        private readonly IHttpClientInstance _httpClient;
        private readonly IAuthorizationStateHandler _authHandler;
        private readonly IConfigurationService _configuration;

        internal UserMethodsAccess(IHttpClientInstance httpClient, IAuthorizationStateHandler authHandler,
            IConfigurationService configuration)
        {
            _httpClient = httpClient;
            _authHandler = authHandler;
            _configuration = configuration;
        }

        public async ValueTask<BungieResponse<GeneralUser>> GetBungieNetUserById(
            long id,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/User/GetBungieNetUserById/")
                .AddUrlParam(id.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<GeneralUser>(url, token);
        }

        public async ValueTask<BungieResponse<GeneralUser[]>> SearchUsers(
            string query,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/User/SearchUsers/")
                .AddQueryParam("q", query)
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<GeneralUser[]>(url, token);
        }

        public async ValueTask<BungieResponse<CredentialTypeForAccount[]>> GetCredentialTypesForTargetAccount(
            long id,
            AuthorizationTokenData authToken,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/User/GetCredentialTypesForTargetAccount/")
                .AddUrlParam(id.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<CredentialTypeForAccount[]>(url, token, authToken.AccessToken);
        }

        public async ValueTask<BungieResponse<UserTheme[]>> GetAvailableThemes(
            CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<UserTheme[]>("/User/GetAvailableThemes", token);
        }

        public async ValueTask<BungieResponse<UserMembershipData>> GetMembershipDataById(long id,
            BungieMembershipType membershipType, CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/User/GetMembershipsById/")
                .AddUrlParam(id.ToString())
                .AddUrlParam(((int) membershipType).ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<UserMembershipData>(url, token);
        }

        public async ValueTask<BungieResponse<UserMembershipData>> GetMembershipDataForCurrentUser(
            AuthorizationTokenData authToken, 
            CancellationToken token = default)
        {
            if (!_configuration
                .Settings
                .IdentificationSettings
                .ApplicationScopes
                .HasFlag(ApplicationScopes.ReadBasicUserProfile))
                throw new InsufficientScopeException(ApplicationScopes.ReadBasicUserProfile);

            return await _httpClient.GetFromBungieNetPlatform<UserMembershipData>(
                "/User/GetMembershipsForCurrentUser/", token, authToken.AccessToken);


            throw new Exception("Missing token to make a call.");
        }

        public async ValueTask<BungieResponse<HardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(
            long credential,
            BungieCredentialType credentialType = BungieCredentialType.SteamId,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/User/GetMembershipFromHardLinkedCredential/")
                .AddUrlParam(((byte) credentialType).ToString())
                .AddUrlParam(credential.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<HardLinkedUserMembership>(url, token);
        }
    }
}