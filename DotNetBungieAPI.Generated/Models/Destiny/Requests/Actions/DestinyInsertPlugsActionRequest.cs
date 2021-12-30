using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public sealed class DestinyInsertPlugsActionRequest
{

    [JsonPropertyName("actionToken")]
    public string ActionToken { get; init; }

    [JsonPropertyName("itemInstanceId")]
    public long ItemInstanceId { get; init; }

    [JsonPropertyName("plug")]
    public Destiny.Requests.Actions.DestinyInsertPlugsRequestEntry Plug { get; init; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }
}
