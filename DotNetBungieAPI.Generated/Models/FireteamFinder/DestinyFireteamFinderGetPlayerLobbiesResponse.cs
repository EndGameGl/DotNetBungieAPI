namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderGetPlayerLobbiesResponse
{
    /// <summary>
    ///     All available lobbies that this player has created or is a member of.
    /// </summary>
    [JsonPropertyName("lobbies")]
    public FireteamFinder.DestinyFireteamFinderLobbyResponse[]? Lobbies { get; set; }

    /// <summary>
    ///     The number of results requested.
    /// </summary>
    [JsonPropertyName("pageSize")]
    public int PageSize { get; set; }

    /// <summary>
    ///     A string token required to get the next page of results. This will be null or empty if there are no more results.
    /// </summary>
    [JsonPropertyName("nextPageToken")]
    public string NextPageToken { get; set; }
}
