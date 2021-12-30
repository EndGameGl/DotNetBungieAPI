using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public sealed class DestinyPostmasterTransferRequest
{

    [JsonPropertyName("itemReferenceHash")]
    public uint ItemReferenceHash { get; init; }

    [JsonPropertyName("stackSize")]
    public int StackSize { get; init; }

    [JsonPropertyName("itemId")]
    public long ItemId { get; init; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }
}
