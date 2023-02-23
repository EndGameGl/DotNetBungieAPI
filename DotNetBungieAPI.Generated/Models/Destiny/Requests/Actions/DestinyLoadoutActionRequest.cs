namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public class DestinyLoadoutActionRequest
{
    /// <summary>
    ///     The index of the loadout for this action request.
    /// </summary>
    [JsonPropertyName("loadoutIndex")]
    public int? LoadoutIndex { get; set; }

    [JsonPropertyName("characterId")]
    public long? CharacterId { get; set; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType? MembershipType { get; set; }
}
