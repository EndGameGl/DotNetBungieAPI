using DotNetBungieAPI.Authorization;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Exceptions;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Models.Config;
using DotNetBungieAPI.Models.Requests;
using DotNetBungieAPI.Models.User;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;
using DotNetBungieAPI.Services.Interfaces;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetBungieAPI.Services.ApiAccess
{
    /// <summary>
    /// <inheritdoc cref="IUserMethodsAccess"/>
    /// </summary>
    internal sealed class UserMethodsAccess : IUserMethodsAccess
    {
        private readonly BungieClientConfiguration _configuration;
        private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;
        private readonly IBungieNetJsonSerializer _bungieNetJsonSerializer;

        public UserMethodsAccess(
            IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
            BungieClientConfiguration configuration,
            IBungieNetJsonSerializer bungieNetJsonSerializer)
        {
            _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
            _configuration = configuration;
            _bungieNetJsonSerializer = bungieNetJsonSerializer;
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
            return await _dotNetBungieApiHttpClient
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
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<CredentialTypeForAccount[]>(
                    url,
                    cancellationToken,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<UserTheme[]>> GetAvailableThemes(
            CancellationToken cancellationToken = default)
        {
            return await _dotNetBungieApiHttpClient
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
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<UserMembershipData>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<UserMembershipData>> GetMembershipDataForCurrentUser(
            AuthorizationTokenData authorizationToken,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.ReadBasicUserProfile))
                throw new InsufficientScopeException(ApplicationScopes.ReadBasicUserProfile);

            return await _dotNetBungieApiHttpClient
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
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<HardLinkedUserMembership>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<UserSearchResponse>> SearchByGlobalNamePrefix(
            string displayNamePrefix,
            int page = 0,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/User/Search/Prefix/")
                .AddUrlParam(displayNamePrefix)
                .AddUrlParam(page.ToString())
                .Build();
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<UserSearchResponse>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<UserSearchResponse>> SearchByGlobalNamePost(
            UserSearchPrefixRequest request, 
            int page = 0, 
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/User/Search/GlobalName/")
                .AddUrlParam(page.ToString())
                .Build();

            using var memoryStream = new MemoryStream();
            await _bungieNetJsonSerializer.SerializeAsync(memoryStream, request).ConfigureAwait(false);
            return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<UserSearchResponse>(url, cancellationToken, memoryStream).ConfigureAwait(false);
        }
    }
}