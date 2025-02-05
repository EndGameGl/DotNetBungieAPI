namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderGetPlayerLobbiesResponse
{
    /// <summary>
    ///     All available lobbies that this player has created or is a member of.
    /// </summary>
    [JsonPropertyName("lobbies")]
    public ReadOnlyCollection<DestinyFireteamFinderLobbyResponse> Lobbies { get; init; } =
        ReadOnlyCollection<DestinyFireteamFinderLobbyResponse>.Empty;

    /// <summary>
    ///     The number of results requested.
    /// </summary>
    [JsonPropertyName("pageSize")]
    public int PageSize { get; init; }

    /// <summary>
    ///     A string token required to get the next page of results. This will be null or empty if there are no more results.
    /// </summary>
    [JsonPropertyName("nextPageToken")]
    public string NextPageToken { get; init; }
}
