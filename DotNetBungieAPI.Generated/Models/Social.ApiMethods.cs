namespace DotNetBungieAPI.Generated.Models;

public interface ISocialApi
{
    Task<ApiResponse<Social.Friends.BungieFriendListResponse>> GetFriendList(
        string authToken
    );

    Task<ApiResponse<Social.Friends.BungieFriendRequestListResponse>> GetFriendRequestList(
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

    Task<ApiResponse<Social.Friends.PlatformFriendResponse>> GetPlatformFriendList(
        Social.Friends.PlatformFriendType friendPlatform,
        string page
    );

}
