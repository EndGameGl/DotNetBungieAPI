namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderLobbyResponse
{
    [JsonPropertyName("lobbyId")]
    public long LobbyId { get; init; }

    [JsonPropertyName("revision")]
    public int Revision { get; init; }

    [JsonPropertyName("state")]
    public FireteamFinder.DestinyFireteamFinderLobbyState State { get; init; }

    [JsonPropertyName("owner")]
    public DestinyFireteamFinderPlayerId Owner { get; init; }

    [JsonPropertyName("settings")]
    public DestinyFireteamFinderLobbySettings Settings { get; init; }

    [JsonPropertyName("players")]
    public ReadOnlyCollection<DestinyFireteamFinderLobbyPlayer> Players { get; init; } =
        ReadOnlyCollection<DestinyFireteamFinderLobbyPlayer>.Empty;

    [JsonPropertyName("listingId")]
    public long ListingId { get; init; }

    [JsonPropertyName("createdDateTime")]
    public DateTime CreatedDateTime { get; init; }
}
