namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderKickPlayerRequest
{
    [JsonPropertyName("targetMembershipType")]
    public BungieMembershipType TargetMembershipType { get; init; }

    [JsonPropertyName("targetCharacterId")]
    public long TargetCharacterId { get; init; }
}
