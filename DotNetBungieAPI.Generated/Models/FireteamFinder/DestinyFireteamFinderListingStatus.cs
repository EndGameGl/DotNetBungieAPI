namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderListingStatus
{
    [JsonPropertyName("listingId")]
    public long ListingId { get; set; }

    [JsonPropertyName("listingRevision")]
    public int ListingRevision { get; set; }

    [JsonPropertyName("availableSlots")]
    public int AvailableSlots { get; set; }
}
