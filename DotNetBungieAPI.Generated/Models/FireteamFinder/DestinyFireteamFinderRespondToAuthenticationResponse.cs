namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderRespondToAuthenticationResponse
{
    [JsonPropertyName("applicationId")]
    public long ApplicationId { get; set; }

    [JsonPropertyName("applicationRevision")]
    public int ApplicationRevision { get; set; }

    [JsonPropertyName("offer")]
    public FireteamFinder.DestinyFireteamFinderOffer? Offer { get; set; }

    [JsonPropertyName("listing")]
    public FireteamFinder.DestinyFireteamFinderListing? Listing { get; set; }
}
