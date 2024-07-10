namespace DotNetBungieAPI.Models.Requests;

public sealed class DestinyInsertPlugsActionRequest
{
    public DestinyInsertPlugsActionRequest(
        string actionToken,
        long itemInstanceId,
        DestinyInsertPlugsRequestEntry plug,
        long characterId,
        BungieMembershipType membershipType
    )
    {
        ActionToken = actionToken;
        ItemInstanceId = itemInstanceId;
        Plug = plug;
        CharacterId = characterId;
        MembershipType = membershipType;
    }

    /// <summary>
    ///     Action token provided by the AwaGetActionToken API call.
    /// </summary>
    [JsonPropertyName("actionToken")]
    public string ActionToken { get; }

    /// <summary>
    ///     The instance ID of the item having a plug inserted. Only instanced items can have sockets.
    /// </summary>
    [JsonPropertyName("itemInstanceId")]
    public long ItemInstanceId { get; }

    /// <summary>
    ///     The plugs being inserted.
    /// </summary>
    [JsonPropertyName("plug")]
    public DestinyInsertPlugsRequestEntry Plug { get; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; }
}
