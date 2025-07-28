namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderApplyToListingResponse
{
    [JsonPropertyName("isApplied")]
    public bool IsApplied { get; set; }

    [JsonPropertyName("application")]
    public FireteamFinder.DestinyFireteamFinderApplication? Application { get; set; }

    [JsonPropertyName("listing")]
    public FireteamFinder.DestinyFireteamFinderListing? Listing { get; set; }
}
