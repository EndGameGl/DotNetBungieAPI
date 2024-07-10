namespace DotNetBungieAPI.Models.Requests;

public class DestinyLoadoutActionRequest
{
    [JsonPropertyName("loadoutIndex")]
    public int LoadoutIndex { get; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; }

    public DestinyLoadoutActionRequest(
        int loadoutIndex,
        long characterId,
        BungieMembershipType membershipType
    )
    {
        LoadoutIndex = loadoutIndex;
        CharacterId = characterId;
        MembershipType = membershipType;
    }
}
