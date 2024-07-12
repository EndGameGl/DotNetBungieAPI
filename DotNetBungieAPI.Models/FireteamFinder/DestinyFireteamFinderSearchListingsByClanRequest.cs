namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderSearchListingsByClanRequest
{
    [JsonPropertyName("pageSize")]
    public int PageSize { get; init; }

    [JsonPropertyName("pageToken")]
    public string PageToken { get; init; }

    [JsonPropertyName("lobbyState")]
    public DestinyFireteamFinderLobbyState LobbyState { get; init; }
}
