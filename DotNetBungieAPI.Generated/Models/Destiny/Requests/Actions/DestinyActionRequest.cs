namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public class DestinyActionRequest : IDeepEquatable<DestinyActionRequest>
{
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    public bool DeepEquals(DestinyActionRequest? other)
    {
        return other is not null &&
               MembershipType == other.MembershipType;
    }
}