using DotNetBungieAPI.Generated.Models;

namespace DotNetBungieAPI.Generated.Methods;

public interface IUserApi
{
    Task<ApiResponse<Models.User.GeneralUser>> GetBungieNetUserById(
        long id
    );

    Task<ApiResponse<Dictionary<Models.BungieCredentialType, string>>> GetSanitizedPlatformDisplayNames(
        long membershipId
    );

    Task<ApiResponse<Models.User.Models.GetCredentialTypesForAccountResponse[]>> GetCredentialTypesForTargetAccount(
        long membershipId
    );

    Task<ApiResponse<Models.Config.UserTheme[]>> GetAvailableThemes();

    Task<ApiResponse<Models.User.UserMembershipData>> GetMembershipDataById(
        long membershipId,
        Models.BungieMembershipType membershipType
    );

    Task<ApiResponse<Models.User.UserMembershipData>> GetMembershipDataForCurrentUser(
        string authToken
    );

    Task<ApiResponse<Models.User.HardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(
        string credential,
        Models.BungieCredentialType crType
    );

    Task<ApiResponse<Models.User.UserSearchResponse>> SearchByGlobalNamePrefix(
        string displayNamePrefix,
        int page
    );

    Task<ApiResponse<Models.User.UserSearchResponse>> SearchByGlobalNamePost(
        int page,
        Models.User.UserSearchPrefixRequest body
    );

}
