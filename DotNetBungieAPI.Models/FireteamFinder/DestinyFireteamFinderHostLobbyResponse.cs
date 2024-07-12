namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderHostLobbyResponse
{
    [JsonPropertyName("lobbyId")]
    public long LobbyId { get; init; }

    [JsonPropertyName("listingId")]
    public long ListingId { get; init; }

    [JsonPropertyName("applicationId")]
    public long ApplicationId { get; init; }

    [JsonPropertyName("offerId")]
    public long OfferId { get; init; }
}
