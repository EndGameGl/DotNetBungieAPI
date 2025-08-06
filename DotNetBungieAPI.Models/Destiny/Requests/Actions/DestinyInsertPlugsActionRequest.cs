namespace DotNetBungieAPI.Models.Destiny.Requests.Actions;

public sealed class DestinyInsertPlugsActionRequest
{
    /// <summary>
    ///     Action token provided by the AwaGetActionToken API call.
    /// </summary>
    [JsonPropertyName("actionToken")]
    public string ActionToken { get; init; }

    /// <summary>
    ///     The instance ID of the item having a plug inserted. Only instanced items can have sockets.
    /// </summary>
    [JsonPropertyName("itemInstanceId")]
    public long ItemInstanceId { get; init; }

    /// <summary>
    ///     The plugs being inserted.
    /// </summary>
    [JsonPropertyName("plug")]
    public Destiny.Requests.Actions.DestinyInsertPlugsRequestEntry? Plug { get; init; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }
}
