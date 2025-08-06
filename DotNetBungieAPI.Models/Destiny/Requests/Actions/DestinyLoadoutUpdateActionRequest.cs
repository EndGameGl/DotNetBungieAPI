namespace DotNetBungieAPI.Models.Destiny.Requests.Actions;

public sealed class DestinyLoadoutUpdateActionRequest
{
    [JsonPropertyName("colorHash")]
    public uint? ColorHash { get; init; }

    [JsonPropertyName("iconHash")]
    public uint? IconHash { get; init; }

    [JsonPropertyName("nameHash")]
    public uint? NameHash { get; init; }

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
