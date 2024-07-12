namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderListingFilter
{
    [JsonPropertyName("listingValue")]
    public DestinyFireteamFinderListingValue ListingValue { get; init; }

    [JsonPropertyName("rangeType")]
    public DestinyFireteamFinderListingFilterRangeType RangeType { get; init; }

    [JsonPropertyName("matchType")]
    public DestinyFireteamFinderListingFilterMatchType MatchType { get; init; }
}
