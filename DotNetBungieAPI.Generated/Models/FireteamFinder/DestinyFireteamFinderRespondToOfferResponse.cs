namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderRespondToOfferResponse
{
    [JsonPropertyName("offerId")]
    public long? OfferId { get; set; }

    [JsonPropertyName("revision")]
    public int? Revision { get; set; }

    [JsonPropertyName("state")]
    public FireteamFinder.DestinyFireteamFinderOfferState? State { get; set; }
}
