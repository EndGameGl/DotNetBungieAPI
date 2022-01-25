namespace DotNetBungieAPI.Generated.Models.Social.Friends;

public class PlatformFriendResponse
{
    [JsonPropertyName("itemsPerPage")]
    public int ItemsPerPage { get; set; }

    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; set; }

    [JsonPropertyName("hasMore")]
    public bool HasMore { get; set; }

    [JsonPropertyName("platformFriends")]
    public List<Social.Friends.PlatformFriend> PlatformFriends { get; set; }
}
