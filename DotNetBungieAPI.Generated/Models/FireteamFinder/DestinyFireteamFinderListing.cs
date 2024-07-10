namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderListing
{
    [JsonPropertyName("listingId")]
    public long? ListingId { get; set; }

    [JsonPropertyName("revision")]
    public int? Revision { get; set; }

    [JsonPropertyName("ownerId")]
    public FireteamFinder.DestinyFireteamFinderPlayerId? OwnerId { get; set; }

    [JsonPropertyName("settings")]
    public FireteamFinder.DestinyFireteamFinderLobbySettings? Settings { get; set; }

    [JsonPropertyName("availableSlots")]
    public int? AvailableSlots { get; set; }

    [JsonPropertyName("lobbyId")]
    public long? LobbyId { get; set; }

    [JsonPropertyName("lobbyState")]
    public FireteamFinder.DestinyFireteamFinderLobbyState? LobbyState { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }
}
