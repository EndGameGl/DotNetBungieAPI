namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderSearchListingsByClanRequest
{
    [JsonPropertyName("pageSize")]
    public int? PageSize { get; set; }

    [JsonPropertyName("pageToken")]
    public string? PageToken { get; set; }

    [JsonPropertyName("lobbyState")]
    public FireteamFinder.DestinyFireteamFinderLobbyState? LobbyState { get; set; }
}
