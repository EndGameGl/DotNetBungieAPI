namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderLobbyPlayer
{
    [JsonPropertyName("playerId")]
    public DestinyFireteamFinderPlayerId PlayerId { get; init; }

    [JsonPropertyName("referralToken")]
    public long ReferralToken { get; init; }

    [JsonPropertyName("state")]
    public DestinyFireteamFinderPlayerReadinessState State { get; init; }

    [JsonPropertyName("offerId")]
    public long OfferId { get; init; }
}
