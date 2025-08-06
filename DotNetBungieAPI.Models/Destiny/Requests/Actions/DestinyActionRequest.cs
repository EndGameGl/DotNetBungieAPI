namespace DotNetBungieAPI.Models.Destiny.Requests.Actions;

public sealed class DestinyActionRequest
{
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }
}
