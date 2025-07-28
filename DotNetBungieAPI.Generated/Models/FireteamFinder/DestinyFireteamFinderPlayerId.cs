namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderPlayerId
{
    [JsonPropertyName("membershipId")]
    public long MembershipId { get; set; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }
}
