namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderSearchListingsByFiltersResponse
{
    [JsonPropertyName("listings")]
    public List<FireteamFinder.DestinyFireteamFinderListing> Listings { get; set; }

    [JsonPropertyName("pageToken")]
    public string? PageToken { get; set; }
}
