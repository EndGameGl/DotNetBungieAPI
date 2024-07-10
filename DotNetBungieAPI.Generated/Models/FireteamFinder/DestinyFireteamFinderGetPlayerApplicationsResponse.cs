namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderGetPlayerApplicationsResponse
{
    /// <summary>
    ///     All applications that this player has sent.
    /// </summary>
    [JsonPropertyName("applications")]
    public List<FireteamFinder.DestinyFireteamFinderApplication> Applications { get; set; }

    /// <summary>
    ///     String token to request next page of results.
    /// </summary>
    [JsonPropertyName("nextPageToken")]
    public string? NextPageToken { get; set; }
}
