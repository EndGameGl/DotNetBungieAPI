namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderPlayerId
{
    [JsonPropertyName("membershipId")]
    public long MembershipId { get; init; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }
}
