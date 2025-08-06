namespace DotNetBungieAPI.Models.Destiny.Requests.Actions;

public sealed class DestinyLoadoutActionRequest
{
    /// <summary>
    ///     The index of the loadout for this action request.
    /// </summary>
    [JsonPropertyName("loadoutIndex")]
    public int LoadoutIndex { get; init; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }
}
