namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderSearchListingsByClanResponse
{
    [JsonPropertyName("listings")]
    public FireteamFinder.DestinyFireteamFinderListing[]? Listings { get; set; }

    [JsonPropertyName("pageToken")]
    public string PageToken { get; set; }
}
