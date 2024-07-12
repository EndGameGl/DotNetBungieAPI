namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderRespondToAuthenticationResponse
{
    [JsonPropertyName("applicationId")]
    public long ApplicationId { get; init; }

    [JsonPropertyName("applicationRevision")]
    public int ApplicationRevision { get; init; }

    [JsonPropertyName("offer")]
    public DestinyFireteamFinderOffer Offer { get; init; }

    [JsonPropertyName("listing")]
    public DestinyFireteamFinderListing Listing { get; init; }
}
