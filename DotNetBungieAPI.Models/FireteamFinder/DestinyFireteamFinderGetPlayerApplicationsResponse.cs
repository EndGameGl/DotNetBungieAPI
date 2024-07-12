namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderGetPlayerApplicationsResponse
{
    /// <summary>
    ///     All applications that this player has sent.
    /// </summary>
    [JsonPropertyName("applications")]
    public ReadOnlyCollection<DestinyFireteamFinderApplication> Applications { get; init; } =
        ReadOnlyCollections<DestinyFireteamFinderApplication>.Empty;

    /// <summary>
    ///     String token to request next page of results.
    /// </summary>
    [JsonPropertyName("nextPageToken")]
    public string NextPageToken { get; init; }
}
