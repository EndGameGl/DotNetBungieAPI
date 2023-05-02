namespace DotNetBungieAPI.Generated.Models;

public interface IUserApi
{
    Task<ApiResponse<User.GeneralUser>> GetBungieNetUserById(
        long id
    );

    Task<ApiResponse<Dictionary<BungieCredentialType, string>>> GetSanitizedPlatformDisplayNames(
        long membershipId
    );

    Task<ApiResponse<List<User.Models.GetCredentialTypesForAccountResponse>>> GetCredentialTypesForTargetAccount(
        long membershipId
    );

    Task<ApiResponse<List<Config.UserTheme>>> GetAvailableThemes();

    Task<ApiResponse<User.UserMembershipData>> GetMembershipDataById(
        long membershipId,
        BungieMembershipType membershipType
    );

    Task<ApiResponse<User.UserMembershipData>> GetMembershipDataForCurrentUser(
        string authToken
    );

    Task<ApiResponse<User.HardLinkedUserMembership>> GetMembershipFromHardLinkedCredential(
        string credential,
        BungieCredentialType crType
    );

    Task<ApiResponse<User.UserSearchResponse>> SearchByGlobalNamePrefix(
        string displayNamePrefix,
        int page
    );

    Task<ApiResponse<User.UserSearchResponse>> SearchByGlobalNamePost(
        int page,
        User.UserSearchPrefixRequest body
    );

}
