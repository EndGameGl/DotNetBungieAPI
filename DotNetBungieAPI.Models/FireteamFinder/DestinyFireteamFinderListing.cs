namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderListing
{
    [JsonPropertyName("listingId")]
    public long ListingId { get; init; }

    [JsonPropertyName("revision")]
    public int Revision { get; init; }

    [JsonPropertyName("ownerId")]
    public DestinyFireteamFinderPlayerId OwnerId { get; init; }

    [JsonPropertyName("settings")]
    public DestinyFireteamFinderLobbySettings Settings { get; init; }

    [JsonPropertyName("availableSlots")]
    public int AvailableSlots { get; init; }

    [JsonPropertyName("lobbyId")]
    public long LobbyId { get; init; }

    [JsonPropertyName("lobbyState")]
    public DestinyFireteamFinderLobbyState LobbyState { get; init; }

    [JsonPropertyName("createdDateTime")]
    public DateTime CreatedDateTime { get; init; }
}
