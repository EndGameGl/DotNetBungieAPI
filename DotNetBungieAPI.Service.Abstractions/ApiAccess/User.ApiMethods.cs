using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface IUserApi
{
    Task<BungieResponse<Models.User.GeneralUser>> GetBungieNetUserById(
        long id,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Dictionary<Models.BungieCredentialType, string>>> GetSanitizedPlatformDisplayNames(
        long membershipId,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.User.Models.GetCredentialTypesForAccountResponse[]>> GetCredentialTypesForTargetAccount(
        long membershipId,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Config.UserTheme[]>> GetAvailableThemes(AuthorizationTokenData? authorizationToken = null, CancellationToken cancellationToken = default);

    Task<BungieResponse<Models.User.UserMembershipData>> GetMembershipDataById(
        long membershipId,
        Models.BungieMembershipType membershipType,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.User.UserMembershipData>> GetMembershipDataForCurrentUser(
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.User.HardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(
        string credential,
        Models.BungieCredentialType crType,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.User.UserSearchResponse>> SearchByGlobalNamePrefix(
        string displayNamePrefix,
        int page,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.User.UserSearchResponse>> SearchByGlobalNamePost(
        int page,
        Models.User.UserSearchPrefixRequest requestBody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

}
