namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public class DestinyInsertPlugsActionRequest
{
    /// <summary>
    ///     Action token provided by the AwaGetActionToken API call.
    /// </summary>
    [JsonPropertyName("actionToken")]
    public string ActionToken { get; set; }

    /// <summary>
    ///     The instance ID of the item having a plug inserted. Only instanced items can have sockets.
    /// </summary>
    [JsonPropertyName("itemInstanceId")]
    public long ItemInstanceId { get; set; }

    /// <summary>
    ///     The plugs being inserted.
    /// </summary>
    [JsonPropertyName("plug")]
    public Destiny.Requests.Actions.DestinyInsertPlugsRequestEntry? Plug { get; set; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }
}
