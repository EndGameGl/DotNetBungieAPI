using DotNetBungieAPI.Generated.Models;

namespace DotNetBungieAPI.Generated.Methods;

public interface ISocialApi
{
    Task<ApiResponse<Models.Social.Friends.BungieFriendListResponse>> GetFriendList(
        string authToken
    );

    Task<ApiResponse<Models.Social.Friends.BungieFriendRequestListResponse>> GetFriendRequestList(
        string authToken
    );

    Task<ApiResponse<bool>> IssueFriendRequest(
        string membershipId,
        string authToken
    );

    Task<ApiResponse<bool>> AcceptFriendRequest(
        string membershipId,
        string authToken
    );

    Task<ApiResponse<bool>> DeclineFriendRequest(
        string membershipId,
        string authToken
    );

    Task<ApiResponse<bool>> RemoveFriend(
        string membershipId,
        string authToken
    );

    Task<ApiResponse<bool>> RemoveFriendRequest(
        string membershipId,
        string authToken
    );

    Task<ApiResponse<Models.Social.Friends.PlatformFriendResponse>> GetPlatformFriendList(
        Models.Social.Friends.PlatformFriendType friendPlatform,
        string page
    );

}
