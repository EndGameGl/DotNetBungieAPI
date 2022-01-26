namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public class DestinyCharacterActionRequest : IDeepEquatable<DestinyCharacterActionRequest>
{
    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    public bool DeepEquals(DestinyCharacterActionRequest? other)
    {
        return other is not null &&
               CharacterId == other.CharacterId &&
               MembershipType == other.MembershipType;
    }
}