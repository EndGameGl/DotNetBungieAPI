namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderLobbyListingReference
{
    [JsonPropertyName("lobbyId")]
    public long LobbyId { get; init; }

    [JsonPropertyName("listingId")]
    public long ListingId { get; init; }
}
