namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderListingStatus
{
    [JsonPropertyName("listingId")]
    public long ListingId { get; init; }

    [JsonPropertyName("listingRevision")]
    public int ListingRevision { get; init; }

    [JsonPropertyName("availableSlots")]
    public int AvailableSlots { get; init; }
}
