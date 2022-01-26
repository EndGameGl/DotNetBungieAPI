namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public class DestinyItemSetActionRequest : IDeepEquatable<DestinyItemSetActionRequest>
{
    [JsonPropertyName("itemIds")]
    public List<long> ItemIds { get; set; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    public bool DeepEquals(DestinyItemSetActionRequest? other)
    {
        return other is not null &&
               ItemIds.DeepEqualsListNaive(other.ItemIds) &&
               CharacterId == other.CharacterId &&
               MembershipType == other.MembershipType;
    }
}