namespace DotNetBungieAPI.Models.Requests;

public sealed class DestinyItemActionRequest
{
    public DestinyItemActionRequest(long itemId, long characterId, BungieMembershipType membershipType)
    {
        ItemId = itemId;
        CharacterId = characterId;
        MembershipType = membershipType;
    }

    [JsonPropertyName("itemId")] public long ItemId { get; }

    [JsonPropertyName("characterId")] public long CharacterId { get; }

    [JsonPropertyName("membershipType")] public BungieMembershipType MembershipType { get; }
}