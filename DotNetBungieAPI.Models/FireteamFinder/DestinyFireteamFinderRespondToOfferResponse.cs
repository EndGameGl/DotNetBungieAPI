namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderRespondToOfferResponse
{
    [JsonPropertyName("offerId")]
    public long OfferId { get; init; }

    [JsonPropertyName("revision")]
    public int Revision { get; init; }

    [JsonPropertyName("state")]
    public DestinyFireteamFinderOfferState State { get; init; }
}
