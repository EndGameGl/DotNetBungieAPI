namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderSearchListingsByFiltersRequest
{
    [JsonPropertyName("filters")]
    public List<DestinyFireteamFinderListingFilter> Filters { get; init; }

    [JsonPropertyName("pageSize")]
    public int PageSize { get; init; }

    [JsonPropertyName("pageToken")]
    public string PageToken { get; init; }

    [JsonPropertyName("lobbyState")]
    public DestinyFireteamFinderLobbyState? LobbyState { get; init; }
}
