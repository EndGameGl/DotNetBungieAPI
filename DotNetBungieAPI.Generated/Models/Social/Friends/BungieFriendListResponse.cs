namespace DotNetBungieAPI.Generated.Models.Social.Friends;

public class BungieFriendListResponse : IDeepEquatable<BungieFriendListResponse>
{
    [JsonPropertyName("friends")]
    public List<Social.Friends.BungieFriend> Friends { get; set; }

    public bool DeepEquals(BungieFriendListResponse? other)
    {
        return other is not null &&
               Friends.DeepEqualsList(other.Friends);
    }
}