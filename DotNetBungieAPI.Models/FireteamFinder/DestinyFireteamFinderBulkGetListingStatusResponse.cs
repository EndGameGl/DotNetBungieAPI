namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderBulkGetListingStatusResponse
{
    [JsonPropertyName("listingStatus")]
    public ReadOnlyCollection<DestinyFireteamFinderListingStatus> ListingStatus { get; init; } =
        ReadOnlyCollections<DestinyFireteamFinderListingStatus>.Empty;
}
