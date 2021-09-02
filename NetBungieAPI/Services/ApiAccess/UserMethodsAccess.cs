using System;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Exceptions;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Applications;
using NetBungieAPI.Models.Config;
using NetBungieAPI.Models.User;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services.ApiAccess
{
    /// <summary>
    /// <inheritdoc cref="IUserMethodsAccess"/>
    /// </summary>
    public class UserMethodsAccess : IUserMethodsAccess
    {
        private readonly IConfigurationService _configuration;
        private readonly IHttpClientInstance _httpClient;

        internal UserMethodsAccess(
            IHttpClientInstance httpClient,
            IConfigurationService configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async ValueTask<BungieResponse<GeneralUser>> GetBungieNetUserById(
            long id,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/User/GetBungieNetUserById/")
                .AddUrlParam(id.ToString())
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<GeneralUser>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<CredentialTypeForAccount[]>> GetCredentialTypesForTargetAccount(
            long id,
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/User/GetCredentialTypesForTargetAccount/")
                .AddUrlParam(id.ToString())
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<CredentialTypeForAccount[]>(
                    url,
                    cancellationToken,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<UserTheme[]>> GetAvailableThemes(
            CancellationToken cancellationToken = default)
        {
            return await _httpClient
                .GetFromBungieNetPlatform<UserTheme[]>("/User/GetAvailableThemes", cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<UserMembershipData>> GetMembershipDataById(long id,
            BungieMembershipType membershipType, CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/User/GetMembershipsById/")
                .AddUrlParam(id.ToString())
                .AddUrlParam(((int)membershipType).ToString())
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<UserMembershipData>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<UserMembershipData>> GetMembershipDataForCurrentUser(
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.ReadBasicUserProfile))
                throw new InsufficientScopeException(ApplicationScopes.ReadBasicUserProfile);

            return await _httpClient
                .GetFromBungieNetPlatform<UserMembershipData>(
                    "/User/GetMembershipsForCurrentUser/",
                    cancellationToken,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<HardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(
            long credential,
            BungieCredentialType credentialType = BungieCredentialType.SteamId,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/User/GetMembershipFromHardLinkedCredential/")
                .AddUrlParam(((byte)credentialType).ToString())
                .AddUrlParam(credential.ToString())
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<HardLinkedUserMembership>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<UserPrefixSearchResponse>> SearchUsersByPrefix(
            string prefix,
            int page = 0,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/User/Search/Prefix/")
                .AddUrlParam(prefix)
                .AddUrlParam(page.ToString())
                .Build();
            return await _httpClient
                .GetFromBungieNetPlatform<UserPrefixSearchResponse>(url, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}