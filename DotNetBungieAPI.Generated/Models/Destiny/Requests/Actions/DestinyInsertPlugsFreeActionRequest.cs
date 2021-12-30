using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public sealed class DestinyInsertPlugsFreeActionRequest
{

    [JsonPropertyName("plug")]
    public Destiny.Requests.Actions.DestinyInsertPlugsRequestEntry Plug { get; init; }

    [JsonPropertyName("itemId")]
    public long ItemId { get; init; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }
}
