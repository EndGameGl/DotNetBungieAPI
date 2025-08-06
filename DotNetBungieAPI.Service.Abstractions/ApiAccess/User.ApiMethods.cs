using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface IUserApi
{
    Task<BungieResponse<Models.User.GeneralUser>> GetBungieNetUserById(
        long id,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Dictionary<Models.BungieCredentialType, string>>> GetSanitizedPlatformDisplayNames(
        long membershipId,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.User.Models.GetCredentialTypesForAccountResponse[]>> GetCredentialTypesForTargetAccount(
        long membershipId,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Config.UserTheme[]>> GetAvailableThemes(CancellationToken cancellationToken = default);

    Task<BungieResponse<Models.User.UserMembershipData>> GetMembershipDataById(
        long membershipId,
        Models.BungieMembershipType membershipType,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.User.UserMembershipData>> GetMembershipDataForCurrentUser(
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.User.HardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(
        string credential,
        Models.BungieCredentialType crType,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.User.UserSearchResponse>> SearchByGlobalNamePrefix(
        string displayNamePrefix,
        int page,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.User.UserSearchResponse>> SearchByGlobalNamePost(
        int page,
        Models.User.UserSearchPrefixRequest requestBody,
        CancellationToken cancellationToken = default
    );

}
