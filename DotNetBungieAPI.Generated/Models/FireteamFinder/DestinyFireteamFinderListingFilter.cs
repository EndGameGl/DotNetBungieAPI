namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderListingFilter
{
    [JsonPropertyName("listingValue")]
    public FireteamFinder.DestinyFireteamFinderListingValue? ListingValue { get; set; }

    [JsonPropertyName("rangeType")]
    public FireteamFinder.DestinyFireteamFinderListingFilterRangeType? RangeType { get; set; }

    [JsonPropertyName("matchType")]
    public FireteamFinder.DestinyFireteamFinderListingFilterMatchType? MatchType { get; set; }
}
