namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderLobbyResponse
{
    [JsonPropertyName("lobbyId")]
    public long LobbyId { get; set; }

    [JsonPropertyName("revision")]
    public int Revision { get; set; }

    [JsonPropertyName("state")]
    public FireteamFinder.DestinyFireteamFinderLobbyState State { get; set; }

    [JsonPropertyName("owner")]
    public FireteamFinder.DestinyFireteamFinderPlayerId? Owner { get; set; }

    [JsonPropertyName("settings")]
    public FireteamFinder.DestinyFireteamFinderLobbySettings? Settings { get; set; }

    [JsonPropertyName("players")]
    public FireteamFinder.DestinyFireteamFinderLobbyPlayer[]? Players { get; set; }

    [JsonPropertyName("listingId")]
    public long ListingId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime CreatedDateTime { get; set; }
}
