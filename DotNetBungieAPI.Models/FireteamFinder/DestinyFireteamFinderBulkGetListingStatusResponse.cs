namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderBulkGetListingStatusResponse
{
    [JsonPropertyName("listingStatus")]
    public ReadOnlyCollection<DestinyFireteamFinderListingStatus> ListingStatus { get; init; } =
        ReadOnlyCollection<DestinyFireteamFinderListingStatus>.Empty;
}
