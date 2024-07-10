using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Models.Config;
using DotNetBungieAPI.Models.Exceptions;
using DotNetBungieAPI.Models.Requests;
using DotNetBungieAPI.Models.User;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;

namespace DotNetBungieAPI.Services.ApiAccess;

/// <summary>
///     <inheritdoc cref="IUserMethodsAccess" />
/// </summary>
internal sealed class UserMethodsAccess : IUserMethodsAccess
{
    private readonly IBungieNetJsonSerializer _bungieNetJsonSerializer;
    private readonly IBungieClientConfiguration _configuration;
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;

    public UserMethodsAccess(
        IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
        IBungieClientConfiguration configuration,
        IBungieNetJsonSerializer bungieNetJsonSerializer
    )
    {
        _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
        _configuration = configuration;
        _bungieNetJsonSerializer = bungieNetJsonSerializer;
    }

    public async Task<BungieResponse<GeneralUser>> GetBungieNetUserById(
        long id,
        CancellationToken cancellationToken = default
    )
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

    public async Task<
        BungieResponse<ReadOnlyDictionary<BungieCredentialType, string>>
    > GetSanitizedPlatformDisplayNames(
        long membershipId,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/User/GetSanitizedPlatformDisplayNames/")
            .AddUrlParam(membershipId.ToString())
            .Build();
        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<ReadOnlyDictionary<BungieCredentialType, string>>(
                url,
                cancellationToken
            )
            .ConfigureAwait(false);
    }

    public async Task<
        BungieResponse<ReadOnlyCollection<CredentialTypeForAccount>>
    > GetCredentialTypesForTargetAccount(
        long id,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/User/GetCredentialTypesForTargetAccount/")
            .AddUrlParam(id.ToString())
            .Build();
        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<ReadOnlyCollection<CredentialTypeForAccount>>(
                url,
                cancellationToken,
                authorizationToken.AccessToken
            )
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<ReadOnlyCollection<UserTheme>>> GetAvailableThemes(
        CancellationToken cancellationToken = default
    )
    {
        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<ReadOnlyCollection<UserTheme>>(
                "/User/GetAvailableThemes",
                cancellationToken
            )
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<UserMembershipData>> GetMembershipDataById(
        long id,
        BungieMembershipType membershipType,
        CancellationToken cancellationToken = default
    )
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

    public async Task<BungieResponse<UserMembershipData>> GetMembershipDataForCurrentUser(
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadBasicUserProfile))
            throw new InsufficientScopeException(ApplicationScopes.ReadBasicUserProfile);

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<UserMembershipData>(
                "/User/GetMembershipsForCurrentUser/",
                cancellationToken,
                authorizationToken.AccessToken
            )
            .ConfigureAwait(false);
    }

    public async Task<
        BungieResponse<HardLinkedUserMembership>
    > GetMembershipFromHardLinkedCredential(
        long credential,
        BungieCredentialType credentialType = BungieCredentialType.SteamId,
        CancellationToken cancellationToken = default
    )
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

    public async Task<BungieResponse<UserSearchResponse>> SearchByGlobalNamePost(
        UserSearchPrefixRequest request,
        int page = 0,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/User/Search/GlobalName/")
            .AddUrlParam(page.ToString())
            .Build();

        using var memoryStream = new MemoryStream();
        await _bungieNetJsonSerializer.SerializeAsync(memoryStream, request).ConfigureAwait(false);
        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<UserSearchResponse>(url, cancellationToken, memoryStream)
            .ConfigureAwait(false);
    }
}
