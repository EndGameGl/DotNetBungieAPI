namespace DotNetBungieAPI.Models.Social.Friends;

public sealed class PlatformFriendResponse
{
    [JsonPropertyName("itemsPerPage")]
    public int ItemsPerPage { get; init; }

    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; init; }

    [JsonPropertyName("hasMore")]
    public bool HasMore { get; init; }

    [JsonPropertyName("platformFriends")]
    public Social.Friends.PlatformFriend[]? PlatformFriends { get; init; }
}
