namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderGetListingApplicationsResponse
{
    [JsonPropertyName("applications")]
    public FireteamFinder.DestinyFireteamFinderApplication[]? Applications { get; set; }

    [JsonPropertyName("pageSize")]
    public int PageSize { get; set; }

    [JsonPropertyName("nextPageToken")]
    public string NextPageToken { get; set; }
}
