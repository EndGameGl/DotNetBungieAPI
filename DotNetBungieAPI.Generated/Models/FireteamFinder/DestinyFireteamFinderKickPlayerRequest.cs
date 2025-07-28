namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderKickPlayerRequest
{
    [JsonPropertyName("targetMembershipType")]
    public BungieMembershipType TargetMembershipType { get; set; }

    [JsonPropertyName("targetCharacterId")]
    public long TargetCharacterId { get; set; }
}
