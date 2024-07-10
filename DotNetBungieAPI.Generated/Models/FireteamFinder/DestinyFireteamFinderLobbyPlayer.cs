namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderLobbyPlayer
{
    [JsonPropertyName("playerId")]
    public FireteamFinder.DestinyFireteamFinderPlayerId? PlayerId { get; set; }

    [JsonPropertyName("referralToken")]
    public long? ReferralToken { get; set; }

    [JsonPropertyName("state")]
    public FireteamFinder.DestinyFireteamFinderPlayerReadinessState? State { get; set; }

    [JsonPropertyName("offerId")]
    public long? OfferId { get; set; }
}
