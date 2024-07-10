namespace DotNetBungieAPI.Models.Requests;

public class DestinyLoadoutUpdateActionRequest
{
    [JsonPropertyName("colorHash")]
    public uint? ColorHash { get; }

    [JsonPropertyName("iconHash")]
    public uint? IconHash { get; }

    [JsonPropertyName("nameHash")]
    public uint? NameHash { get; }

    [JsonPropertyName("loadoutIndex")]
    public int LoadoutIndex { get; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; }

    public DestinyLoadoutUpdateActionRequest(
        int loadoutIndex,
        long characterId,
        BungieMembershipType membershipType,
        uint? colorHash = null,
        uint? iconHash = null,
        uint? nameHash = null
    )
    {
        LoadoutIndex = loadoutIndex;
        CharacterId = characterId;
        MembershipType = membershipType;
        ColorHash = colorHash;
        IconHash = iconHash;
        NameHash = nameHash;
    }
}
